'''
Este script contendrá un modelo simple usando TensorFlow para entrenar con la letra "A".
Generará un archivo .json con las posiciones de los dedos correspondientes a cada seña reconocida.
'''
import sys
import os
import json  # Importar json para manejar el archivo
import numpy as np  # Importar numpy para manejar datos numéricos
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))

from scripts.preprocess_data import load_and_preprocess_images

import tensorflow as tf
from sklearn.model_selection import train_test_split

# Cargar los datos
X, y = load_and_preprocess_images()

# Dividir en conjunto de entrenamiento y validación
X_train, X_val, y_train, y_val = train_test_split(X, y, test_size=0.2, random_state=42)

# Definir el modelo
model = tf.keras.Sequential([
    tf.keras.layers.Input(shape=(X_train.shape[1],)),
    tf.keras.layers.Dense(512, activation='relu'),
    tf.keras.layers.Dropout(0.5),
    tf.keras.layers.Dense(256, activation='relu'),
    tf.keras.layers.Dropout(0.5),
    tf.keras.layers.Dense(36, activation='softmax')  # 36 clases: 26 letras + 10 números
])

# Compilar el modelo
model.compile(optimizer='adam', loss='sparse_categorical_crossentropy', metrics=['accuracy'])

# Entrenar el modelo
model.fit(X_train, y_train, epochs=10, validation_data=(X_val, y_val))

# Guardar el modelo entrenado
model.save('models/model_full.h5')

# Crear un diccionario para almacenar las posiciones de los dedos
sign_positions = {
    'A': [[0.0, 0.0], [0.1, 0.2], [0.2, 0.3]],  # Ejemplo de posiciones para 'A'
    'B': [[0.1, 0.1], [0.1, 0.2], [0.1, 0.3]],  # Agrega posiciones reales aquí
    # Agrega más letras/números y sus posiciones aquí
}

# Generar archivo JSON
with open('models/sign_positions.json', 'w') as json_file:
    json.dump(sign_positions, json_file, indent=4)

print("Archivo JSON generado con las posiciones de las señas.")
