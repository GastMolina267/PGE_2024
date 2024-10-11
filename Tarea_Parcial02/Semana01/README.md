# 🐍 Gesture-Controlled Snake Game & Sign Language Detection 🎮
---

## 📋 Descripción General

Este proyecto combina el reconocimiento de gestos utilizando **MediaPipe** y **OpenCV** con un **juego de Snake** controlado por gestos de la mano. El objetivo principal es demostrar cómo las tecnologías de visión por computadora pueden integrarse para controlar aplicaciones, en este caso, un juego clásico de **Snake**.

El sistema captura en tiempo real los gestos de la mano utilizando la cámara, permite el movimiento de la ventana de la aplicación con un gesto de mano abierta, y controla la serpiente del juego de Snake con el dedo índice. Además, el programa está preparado para reconocer algunas letras a partir de la posición de los dedos y tiene gestos específicos para **cerrar la aplicación** o **abrir el juego**.

## 🚀 Funcionalidades

### 1. **Detección de Gestos**
   - **MediaPipe Hands** se utiliza para capturar y analizar la posición de la mano y los dedos.
   - El programa reconoce gestos como:
     - **Gesto de mano abierta** para mover la ventana.
     - **Pulgar hacia arriba** para cerrar la aplicación.
     - **Dedo índice levantado** para abrir el juego Snake.
     - **Gestos personalizados** para el control del juego.

### 2. **Juego Snake Controlado por Gestos**
   - El juego **Snake** se controla moviendo el dedo índice.
   - Utiliza el promedio de las últimas 5 posiciones del dedo para suavizar el control del movimiento.
   - Implementa colisión con la comida y consigo misma para el crecimiento de la serpiente y el Game Over.

### 3. **Interacción con la Ventana**
   - El programa permite mover la ventana de la aplicación utilizando gestos de la mano, siempre y cuando el juego Snake no esté activo.

## 🛠️ Requisitos

Para ejecutar este proyecto, necesitarás las siguientes dependencias:

- **Python 3.x**
- **OpenCV** (`cv2`) para la captura de video.
- **MediaPipe** para la detección de manos.
- **Pygame** para el juego Snake.
- **PyAutoGUI** para la manipulación de la interfaz.
- **Win32GUI** y **Win32Con** para la manipulación de la ventana (opcional en Windows).

### Instalación de dependencias:

```bash
pip install opencv-python mediapipe pygame pyautogui pywin32
```

### 🔧 Cómo Ejecutar el Proyecto
1. Clonar el repositorio o copiar el código fuente en tu entorno local.
2. Instalar las dependencias listadas arriba si no lo has hecho.
3. Ejecutar el script:
```bash
python hand_manager.py
```
4. Funcionalidades disponibles:
-Al ejecutar el programa, la cámara se activará y comenzará a detectar gestos.
-Si realizas el gesto del dedo índice levantado, el juego de Snake se abrirá en una ventana separada.
-Usa el movimiento de tu dedo índice para controlar la dirección de la serpiente.
-Si realizas el gesto de pulgar arriba, el programa cerrará.

### 🖱️ Controles del Juego y Gestos
1. Dedo índice levantado: Inicia el juego de Snake.
2. Mover el dedo índice: Controla la dirección del Snake (izquierda, derecha, arriba, abajo).
3. Mano abierta: Mueve la ventana de la aplicación (solo si el juego Snake no está activo).
4. Pulgar hacia arriba: Cierra la aplicación.

### 🧠 Lógica de Control del Snake
El control del Snake utiliza la posición del dedo índice capturada por MediaPipe. Las coordenadas del dedo índice se actualizan continuamente y el sistema mantiene un promedio móvil de las últimas 5 posiciones para hacer el movimiento más fluido y estable. La dirección de la serpiente se determina de la siguiente manera:

-Si el dedo índice está en la zona izquierda (x < 0.3) y no se dirige a la derecha, la serpiente girará hacia la izquierda.
-Si el dedo índice está en la zona derecha (x > 0.7) y no se dirige a la izquierda, la serpiente girará a la derecha.
-Si el dedo índice está en la zona superior (y < 0.3) y no se dirige hacia abajo, la serpiente subirá.
-Si el dedo índice está en la zona inferior (y > 0.7) y no se dirige hacia arriba, la serpiente bajará.

### 🛠️ Tecnologías Utilizadas
- **Python:** Lenguaje de programación principal.
- **OpenCV:** Para la captura de imágenes en tiempo real.
- **MediaPipe:** Para la detección de manos y gestos.
- **Pygame:** Para el desarrollo del juego Snake.
- **PyAutoGUI y Win32:** Para la manipulación de ventanas (en sistemas Windows).

### 🏗️ Estructura del Código
- MediaPipe se encarga de la detección de manos y la extracción de puntos clave (landmarks).
- Las posiciones de la mano se usan para determinar la dirección del Snake y gestionar las interacciones con la ventana.
- Se utiliza una cola (deque) para almacenar las últimas posiciones del dedo índice, lo que permite un suavizado del movimiento.
- Pygame se utiliza para crear la interfaz del juego Snake, que incluye el control de la serpiente y el manejo de la comida.

### 🐍 Detalles del Juego Snake
- **Control de la serpiente:** Se basa en el movimiento de tu dedo índice capturado por la cámara.
- **Comida:** Aparece aleatoriamente, y la serpiente crece al comerla.
- **Pantalla envolvente:** La serpiente reaparece en el lado opuesto si atraviesa los bordes de la pantalla.
- **olisión con la serpiente:** Si la serpiente se choca con su propio cuerpo, el juego termina.

### 📝 Futuras Mejoras
- **Añadir más gestos:** Ampliar el reconocimiento de gestos para controlar otras funcionalidades.
- **Modo multijugador:** Integrar varios jugadores controlados por diferentes gestos.
- **Interfaz gráfica avanzada:** Usar una GUI completa para mejorar la experiencia del usuario.
- **Compatibilidad multiplataforma:** Mejorar la compatibilidad en otros sistemas operativos como Linux o macOS.

---
**¡Gracias por usar el Snake controlado por gestos y el sistema de detección de lenguaje de señas!**