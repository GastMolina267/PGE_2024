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

            if gesture == "Comiste":    
                cv2.putText(image, gesture, (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)
            elif gesture == "Mover ventana":
                cv2.putText(image, "Moviendo ventana...", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (255, 0, 0), 2)
                x, y = pyautogui.position()
                win32gui.SetWindowPos(hwnd, win32con.HWND_TOP, x, y, 0, 0, win32con.SWP_NOSIZE)
            elif gesture == "Cerrar aplicación":
                cv2.putText(image, "Cerrando aplicación...", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 255), 2)
                closing = True
            else:
                cv2.putText(image, f"Letra: {letter}", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)

    cv2.imshow(window_name, image)

    if closing or cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()