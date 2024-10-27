import sys
import os
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))
import json  # Importar json para manejar el archivo
import cv2
import tensorflow as tf
import numpy as np
import mediapipe as mp
from utils.audio_utils import speak_text  # Para la reproducción de voz
import time

# Configuración de MediaPipe
mp_hands = mp.solutions.hands
mp_drawing = mp.solutions.drawing_utils
hands = mp_hands.Hands(static_image_mode=False, max_num_hands=1, min_detection_confidence=0.5, min_tracking_confidence=0.5)

# Cargar el modelo
try:
    model = tf.keras.models.load_model('models/sign_model_full.h5')
    print("Modelo cargado. Arquitectura del modelo:")
    model.summary()
except Exception as e:
    print(f"Error al cargar el modelo: {e}")
    model = None

# Clases que podemos predecir
classes = list("ABCDEFGHIJKLMNOPQRSTUVWXYZ") + list("0123456789")

# Cargar posiciones de señas desde el archivo JSON
try:
    with open('models/sign_positions.json', 'r') as json_file:
        sign_positions = json.load(json_file)
except Exception as e:
    print(f"Error al cargar el archivo JSON: {e}")
    sign_positions = {}

def preprocess_image(image):
    resized = cv2.resize(image, (64, 64))  # Redimensiona a 64x64
    gray = cv2.cvtColor(resized, cv2.COLOR_BGR2GRAY)  # Convierte a escala de grises
    normalized = gray / 255.0  # Normaliza a valores entre 0 y 1
    flattened = normalized.flatten().reshape(1, -1)  # Aplana la imagen
    return flattened, resized

def predict_sign(image):
    preprocessed_image, _ = preprocess_image(image)
    if model is not None:
        prediction = model.predict(preprocessed_image)
        predicted_class = classes[np.argmax(prediction)]
        confidence = np.max(prediction)
        # Umbral de confianza
        if confidence < 0.80:
            return None, 0  # Ignorar predicciones con baja confianza
        return predicted_class, confidence
    return None, 0

def detect_hand(frame):
    rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
    results = hands.process(rgb_frame)

    if results.multi_hand_landmarks:
        for hand_landmarks in results.multi_hand_landmarks:
            mp_drawing.draw_landmarks(frame, hand_landmarks, mp_hands.HAND_CONNECTIONS)
            h, w, _ = frame.shape
            x_min = int(min([lm.x for lm in hand_landmarks.landmark]) * w)
            x_max = int(max([lm.x for lm in hand_landmarks.landmark]) * w)
            y_min = int(min([lm.y for lm in hand_landmarks.landmark]) * h)
            y_max = int(max([lm.y for lm in hand_landmarks.landmark]) * h)
            return frame, (x_min, y_min, x_max, y_max), hand_landmarks.landmark  # Devolver también los landmarks
    return frame, None, None

def hand_positions_match(landmarks, target_positions):
    detected_positions = [(lm.x, lm.y) for lm in landmarks]
    # Comparar las posiciones de los dedos (esto puede necesitar ajustes según tu formato)
    for target in target_positions:
        if np.linalg.norm(np.array(detected_positions) - np.array(target)) > 0.1:  # Tolerancia de 10%
            return False
    return True

def predict_sign_from_webcam():
    cap = cv2.VideoCapture(0)
    hand_detected = False
    start_time = 0
    pred_time_window = 3  # Tiempo para que el usuario haga la seña

    while True:
        ret, frame = cap.read()
        if not ret:
            print("Error al acceder a la cámara")
            break

        annotated_frame, bbox, hand_landmarks = detect_hand(frame)

        if hand_landmarks is not None:
            # Mostrar la detección de la mano con un rectángulo
            x_min, y_min, x_max, y_max = bbox
            cv2.rectangle(annotated_frame, (x_min, y_min), (x_max, y_max), (0, 255, 0), 2)
            
            if start_time == 0:  # Si se detecta la mano, iniciar la cuenta atrás
                start_time = time.time()
                print("Mano detectada. Preparándose para capturar la seña...")

            elapsed_time = time.time() - start_time

            if elapsed_time > pred_time_window:  # Capturar seña después de un margen de tiempo
                print("Capturando seña...")

                # Verifica primero las posiciones conocidas
                for sign, target_positions in sign_positions.items():
                    if hand_positions_match(hand_landmarks, target_positions):
                        predicted_class = sign
                        confidence = 1.0  # Confianza máxima ya que hay coincidencia
                        break
                else:
                    # Si no hay coincidencia, usa el modelo de predicción
                    hand_image = frame[y_min:y_max, x_min:x_max]
                    predicted_class, confidence = predict_sign(hand_image)  # Fallback a predicción del modelo

                if predicted_class:
                    print(f"Predicción: {predicted_class} con confianza {confidence:.2f}")
                    cv2.putText(annotated_frame, f"Predicción: {predicted_class} ({confidence:.2f})", 
                                (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
                    speak_text(predicted_class)  # Reproducir la predicción en voz

                start_time = 0  # Reiniciar el contador para la próxima seña
        else:
            start_time = 0  # Si no hay mano, reiniciar el tiempo

        cv2.imshow('Webcam - Detección de Señas', annotated_frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

    cap.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    predict_sign_from_webcam()
