import cv2
import matplotlib.pyplot as plt

def preprocess_image(image):
    # Redimensionar la imagen a 64x64 píxeles
    resized = cv2.resize(image, (64, 64))
    # Convertir a escala de grises
    gray = cv2.cvtColor(resized, cv2.COLOR_BGR2GRAY)
    # Normalizar los valores de píxeles
    normalized = gray / 255.0
    # Aplanar la imagen
    flattened = normalized.reshape(1, 64 * 64)
    return flattened, gray

def visualize_preprocessed(gray):
    plt.imshow(gray, cmap='gray')
    plt.title('Imagen Preprocesada')
    plt.show()
