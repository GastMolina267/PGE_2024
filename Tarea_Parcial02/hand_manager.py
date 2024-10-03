import cv2
import mediapipe as mp
import numpy as np
import pyautogui
import win32gui
import win32con

# Inicializar MediaPipe Hands
mp_hands = mp.solutions.hands
hands = mp_hands.Hands(static_image_mode=False, max_num_hands=1, min_detection_confidence=0.7)
mp_draw = mp.solutions.drawing_utils

# Inicializar la cámara
cap = cv2.VideoCapture(0)

# Obtener el handle de la ventana
window_name = 'Sign Language and Gesture Detection'
cv2.namedWindow(window_name)
hwnd = win32gui.FindWindow(None, window_name)

def get_hand_features(hand_landmarks):
    features = []
    for lm in hand_landmarks.landmark:
        features.extend([lm.x, lm.y, lm.z])
    return features

def classify_gesture(landmarks):
    wrist = landmarks[mp_hands.HandLandmark.WRIST]
    thumb_tip = landmarks[mp_hands.HandLandmark.THUMB_TIP]
    index_tip = landmarks[mp_hands.HandLandmark.INDEX_FINGER_TIP]
    middle_tip = landmarks[mp_hands.HandLandmark.MIDDLE_FINGER_TIP]
    ring_tip = landmarks[mp_hands.HandLandmark.RING_FINGER_TIP]
    pinky_tip = landmarks[mp_hands.HandLandmark.PINKY_TIP]

    # Gesto específico (dedo medio)
    if (middle_tip.y < index_tip.y and 
        middle_tip.y < ring_tip.y and 
        middle_tip.y < pinky_tip.y and
        middle_tip.y < wrist.y and
        thumb_tip.y > wrist.y):
        return "Comiste"
    
    # Gesto de mano abierta (para mover la ventana)
    if (all(finger.y < wrist.y for finger in [thumb_tip, index_tip, middle_tip, ring_tip, pinky_tip]) and
        max(finger.y for finger in [index_tip, middle_tip, ring_tip, pinky_tip]) - min(finger.y for finger in [index_tip, middle_tip, ring_tip, pinky_tip]) < 0.1):
        return "Mover ventana"
    
    # Gesto de pulgar arriba (para cerrar la aplicación)
    if (thumb_tip.y < wrist.y and
        all(finger.y > thumb_tip.y for finger in [index_tip, middle_tip, ring_tip, pinky_tip]) and
        abs(thumb_tip.x - wrist.x) > 0.1):
        return "Cerrar aplicación"
    
    return None

def classify_letter(features):
    # (Mantener la lógica existente para clasificar letras)
    thumb_tip = features[3*4:3*4+3]
    index_tip = features[3*8:3*8+3]
    
    if thumb_tip[1] < index_tip[1]:
        return 'A'
    
    pinky_tip = features[3*20:3*20+3]
    
    if abs(index_tip[0] - pinky_tip[0]) < 0.1:
        return 'B'
    
    return 'Unknown'

closing = False
moving_window = False
prev_hand_center = None

while True:
    success, image = cap.read()
    if not success:
        print("No se pudo leer el frame de la cámara.")
        break

    image_rgb = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    results = hands.process(image_rgb)

    if results.multi_hand_landmarks:
        for hand_landmarks in results.multi_hand_landmarks:
            mp_draw.draw_landmarks(image, hand_landmarks, mp_hands.HAND_CONNECTIONS)

            features = get_hand_features(hand_landmarks)
            letter = classify_letter(features)
            gesture = classify_gesture(hand_landmarks.landmark)

            # Calcular el centro de la mano
            hand_center = np.mean([(lm.x, lm.y) for lm in hand_landmarks.landmark], axis=0)

            if gesture == "Comiste":    
                cv2.putText(image, gesture, (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)
                moving_window = False
            elif gesture == "Mover ventana":
                cv2.putText(image, "Moviendo ventana... ", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (255, 0, 0), 2)
                moving_window = True
                if prev_hand_center is not None:
                    # Calcular el desplazamiento de la mano
                    dx = hand_center[0] - prev_hand_center[0]
                    dy = hand_center[1] - prev_hand_center[1]
                    
                    # Obtener la posición actual de la ventana
                    rect = win32gui.GetWindowRect(hwnd)
                    x, y = rect[0], rect[1]
                    
                    # Calcular la nueva posición de la ventana
                    new_x = int(x + dx * image.shape[1] * 2)  # Multiplicar por 2 para aumentar la sensibilidad
                    new_y = int(y + dy * image.shape[0] * 2)
                    
                    # Mover la ventana
                    win32gui.SetWindowPos(hwnd, win32con.HWND_TOP, new_x, new_y, 0, 0, win32con.SWP_NOSIZE)
            elif gesture == "Cerrar aplicación":
                cv2.putText(image, "Cerrando aplicación...", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 255), 2)
                closing = True
                moving_window = False
            else:
                cv2.putText(image, f"Letra: {letter}", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
                moving_window = False

            # Actualizar la posición previa de la mano
            prev_hand_center = hand_center
    else:
        moving_window = False
        prev_hand_center = None

    cv2.imshow(window_name, image)

    if closing or cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()