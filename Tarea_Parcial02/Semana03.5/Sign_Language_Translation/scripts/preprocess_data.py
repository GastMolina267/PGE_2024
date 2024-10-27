'''
Este script leerá las imágenes y las preparará para el entrenamiento.
'''
import os
import cv2
import numpy as np

# Ruta del dataset
DATASET_PATH = "data/raw/asl_dataset/"
IMAGE_SIZE = (64, 64)

# Función para cargar y preprocesar imágenes
def load_and_preprocess_images():
    images = []
    labels = []
    
    # Clases que queremos identificar (todas las letras y números)
    classes = list("ABCDEFGHIJKLMNOPQRSTUVWXYZ") + list("0123456789")
    
    for label in classes:
        path = os.path.join(DATASET_PATH, label)
        for img_file in os.listdir(path):
            # Cargar la imagen
            img_path = os.path.join(path, img_file)
            img = cv2.imread(img_path)
            if img is not None:
                # Redimensionar y convertir a escala de grises
                img = cv2.resize(img, IMAGE_SIZE)
                img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
                img = img / 255.0
                images.append(img)
                
                # Asignar un índice numérico a cada letra o número
                labels.append(classes.index(label))
    
    # Convertir listas a arrays de NumPy
    images = np.array(images)
    labels = np.array(labels)
    
    # Aplanar imágenes para ingresarlas a un modelo básico (si es necesario)
    images = images.reshape(-1, IMAGE_SIZE[0] * IMAGE_SIZE[1])
    
    return images, labels

if __name__ == "__main__":
    images, labels = load_and_preprocess_images()
    print(f"Imágenes procesadas: {len(images)}")
    print(f"Etiquetas procesadas: {len(labels)}")
