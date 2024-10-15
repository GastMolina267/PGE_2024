import mediapipe as mp
from collections import deque

# Inicializar MediaPipe Hands
mp_hands = mp.solutions.hands
hands = mp_hands.Hands(static_image_mode=False, max_num_hands=1, min_detection_confidence=0.7)

# Usamos una lista para almacenar las últimas posiciones del dedo
finger_positions = deque(maxlen=5)  # Guardar las últimas 5 posiciones

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
    
    # Gesto de dedo índice levantado (para abrir el juego Snake)
    if (index_tip.y < middle_tip.y and
        index_tip.y < ring_tip.y and
        index_tip.y < pinky_tip.y and
        index_tip.y < wrist.y):
        return "Abrir Snake"
    
    return None

def classify_letter(features):
    thumb_tip = features[3*4:3*4+3]
    index_tip = features[3*8:3*8+3]
    
    if thumb_tip[1] < index_tip[1]:
        return 'A'
    
    pinky_tip = features[3*20:3*20+3]
    
    if abs(index_tip[0] - pinky_tip[0]) < 0.1:
        return 'B'
    
    return 'Unknown'

def update_snake_direction(index_finger_tip, snake_direction):
    if index_finger_tip:
        # Añadir la nueva posición a la lista
        finger_positions.append(index_finger_tip)
        
        # Calcular el promedio de las últimas posiciones
        avg_x = sum([pos[0] for pos in finger_positions]) / len(finger_positions)
        avg_y = sum([pos[1] for pos in finger_positions]) / len(finger_positions)

        # Definir zonas de control claras usando el promedio
        if avg_x < 0.3 and snake_direction != 'RIGHT':  
            snake_direction = 'LEFT'
        elif avg_x > 0.7 and snake_direction != 'LEFT':
            snake_direction = 'RIGHT'
        elif avg_y < 0.3 and snake_direction != 'DOWN':
            snake_direction = 'UP'
        elif avg_y > 0.7 and snake_direction != 'UP':
            snake_direction = 'DOWN'
            
    return snake_direction
