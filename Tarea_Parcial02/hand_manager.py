import cv2
from collections import deque
import mediapipe as mp
import numpy as np
import pygame
import sys
import random
import pyautogui
import win32gui
import win32con
import threading

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

# Variables globales para el juego Snake
snake_game_active = False
snake_direction = 'RIGHT'
index_finger_tip = None

# Usamos una lista para almacenar las últimas posiciones del dedo
finger_positions = deque(maxlen=5)  # Guardar las últimas 5 posiciones

# Bloqueo global para sincronizar el acceso a variables compartidas
lock = threading.Lock()

# Configuración de la ventana del juego Snake
SNAKE_WINDOW_WIDTH = 640
SNAKE_WINDOW_HEIGHT = 480

def get_hand_features(hand_landmarks):
    features = []
    for lm in hand_landmarks.landmark:
        features.extend([lm.x, lm.y, lm.z])
    return features

def classify_gesture(landmarks):
    global index_finger_tip
    wrist = landmarks[mp_hands.HandLandmark.WRIST]
    thumb_tip = landmarks[mp_hands.HandLandmark.THUMB_TIP]
    index_tip = landmarks[mp_hands.HandLandmark.INDEX_FINGER_TIP]
    middle_tip = landmarks[mp_hands.HandLandmark.MIDDLE_FINGER_TIP]
    ring_tip = landmarks[mp_hands.HandLandmark.RING_FINGER_TIP]
    pinky_tip = landmarks[mp_hands.HandLandmark.PINKY_TIP]

    # Actualizar la posición del dedo índice para el control del Snake
    index_finger_tip = (index_tip.x, index_tip.y)

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
    # (Mantener la lógica existente para clasificar letras)
    thumb_tip = features[3*4:3*4+3]
    index_tip = features[3*8:3*8+3]
    
    if thumb_tip[1] < index_tip[1]:
        return 'A'
    
    pinky_tip = features[3*20:3*20+3]
    
    if abs(index_tip[0] - pinky_tip[0]) < 0.1:
        return 'B'
    
    return 'Unknown'

def update_snake_direction():
    global snake_direction, index_finger_tip, finger_positions
    
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
            
# Modificar la función de inicio del juego de Snake
def start_snake_game():
    global snake_game_active, snake_direction
    snake_game_active = True
    
    # Inicializar Pygame
    pygame.init()

    # Configuración de la ventana
    screen = pygame.display.set_mode((SNAKE_WINDOW_WIDTH, SNAKE_WINDOW_HEIGHT))
    pygame.display.set_caption('Snake Game')

    # Colores
    BLACK = (0, 0, 0)
    WHITE = (255, 255, 255)
    RED = (255, 0, 0)

    # Snake
    snake_pos = [100, 50]
    snake_body = [[100, 50], [90, 50], [80, 50]]

    # Comida
    food_pos = [random.randrange(1, (SNAKE_WINDOW_WIDTH//10)) * 10,
                random.randrange(1, (SNAKE_WINDOW_HEIGHT//10)) * 10]
    food_spawn = True

    # Velocidad del juego
    clock = pygame.time.Clock()

    while snake_game_active:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                snake_game_active = False

        # Bloquear el acceso a las variables compartidas
        with lock:
            # Actualizar la dirección de la serpiente basada en el movimiento del dedo
            update_snake_direction()

        # Mover la serpiente
        if snake_direction == 'UP':
            snake_pos[1] -= 10
        if snake_direction == 'DOWN':
            snake_pos[1] += 10
        if snake_direction == 'LEFT':
            snake_pos[0] -= 10
        if snake_direction == 'RIGHT':
            snake_pos[0] += 10

        # Implementar la pantalla envolvente
        snake_pos[0] = snake_pos[0] % SNAKE_WINDOW_WIDTH
        snake_pos[1] = snake_pos[1] % SNAKE_WINDOW_HEIGHT

        # Mecanismo de crecimiento de la serpiente
        snake_body.insert(0, list(snake_pos))
        if snake_pos[0] == food_pos[0] and snake_pos[1] == food_pos[1]:
            food_spawn = False
        else:
            snake_body.pop()
        
        if not food_spawn:
            food_pos = [random.randrange(1, (SNAKE_WINDOW_WIDTH//10)) * 10,
                        random.randrange(1, (SNAKE_WINDOW_HEIGHT//10)) * 10]
        food_spawn = True

        # Fondo
        screen.fill(BLACK)
        
        # Dibujar la serpiente
        for pos in snake_body:
            pygame.draw.rect(screen, WHITE, pygame.Rect(pos[0], pos[1], 10, 10))
        
        # Dibujar la comida
        pygame.draw.rect(screen, RED, pygame.Rect(food_pos[0], food_pos[1], 10, 10))

        # Condiciones de Game Over (solo colisión con sí misma)
        for block in snake_body[1:]:
            if snake_pos[0] == block[0] and snake_pos[1] == block[1]:
                snake_game_active = False

        pygame.display.update()
        clock.tick(15)

    pygame.quit()

# Asegurarse de que solo se inicie el juego una vez
def open_snake_game():
    global snake_game_active
    if not snake_game_active:
        threading.Thread(target=start_snake_game, daemon=True).start()

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
            elif gesture == "Mover ventana" and not snake_game_active:
                # Solo permite mover la ventana si el juego de Snake NO está activo
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
            elif gesture == "Abrir Snake":
                cv2.putText(image, "Abriendo Snake...", (10, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
                open_snake_game()
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
snake_game_active = False