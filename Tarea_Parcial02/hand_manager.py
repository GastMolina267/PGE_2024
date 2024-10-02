import cv2
import mediapipe as mp
import numpy as np

# Inicializar MediaPipe Hands
mp_hands = mp.solutions.hands
hands = mp_hands.Hands(static_image_mode=False, max_num_hands=1, min_detection_confidence=0.5)
mp_draw = mp.solutions.drawing_utils

# Inicializar la cámara
cap = cv2.VideoCapture(0)

def get_hand_features(hand_landmarks):
    features = []
    for lm in hand_landmarks.landmark:
        features.extend([lm.x, lm.y, lm.z])
    return features

def classify_gesture(landmarks):
    # Obtener las coordenadas relevantes
    wrist = landmarks[mp_hands.HandLandmark.WRIST].y
    thumb_tip = landmarks[mp_hands.HandLandmark.THUMB_TIP].y
    index_tip = landmarks[mp_hands.HandLandmark.INDEX_FINGER_TIP].y
    middle_tip = landmarks[mp_hands.HandLandmark.MIDDLE_FINGER_TIP].y
    ring_tip = landmarks[mp_hands.HandLandmark.RING_FINGER_TIP].y
    pinky_tip = landmarks[mp_hands.HandLandmark.PINKY_TIP].y

    # Verificar el gesto específico
    if (middle_tip < index_tip and 
        middle_tip < ring_tip and 
        middle_tip < pinky_tip and
        middle_tip < wrist and
        thumb_tip > wrist):
        return "Comiste"
    
    return None

def classify_letter(features):
    # Lógica existente para clasificar letras
    thumb_tip = features[3*4:3*4+3]
    index_tip = features[3*8:3*8+3]
    
    if thumb_tip[1] < index_tip[1]:
        return 'A'
    
    pinky_tip = features[3*20:3*20+3]
    
    if abs(index_tip[0] - pinky_tip[0]) < 0.1:
        return 'B'
    
    return 'Unknown'

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

            # Mostrar el resultado de la detección
            if gesture:
                cv2.putText(image, gesture, (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)
            else:
                cv2.putText(image, f"Letra: {letter}", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)

    cv2.imshow('Sign Language and Gesture Detection', image)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()