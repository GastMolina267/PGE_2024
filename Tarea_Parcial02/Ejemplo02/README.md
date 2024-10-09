# ✋🗿📰✂️ Piedra, Papel, Tijeras - Reconocimiento de Señas
---

## 📋 Descripción General

Este proyecto implementa el clásico juego de **Piedra, Papel, Tijeras**, pero con una vuelta moderna: el jugador utiliza **señas** para seleccionar su jugada. El sistema utiliza **reconocimiento de gestos de la mano** mediante la cámara, permitiendo al jugador interactuar con la IA (Inteligencia Artificial) de manera natural, levantando la mano para empezar a jugar y luego realizando tres movimientos para elegir la seña deseada (piedra, papel o tijeras).

El juego detecta la mano del jugador y compara su jugada contra una **selección aleatoria** hecha por la IA. Este proyecto usa **OpenCV** y **MediaPipe** para capturar y procesar los gestos, haciendo que el juego sea intuitivo y divertido.

## 🚀 Funcionalidades

- **Detección de la mano en tiempo real**: El programa detecta cuando una mano está levantada para indicar que hay una persona lista para jugar.
- **Selección de seña mediante gestos**: El jugador mueve la mano tres veces para indicar su jugada entre las opciones de **Piedra**, **Papel** o **Tijeras**.
- **IA integrada**: La IA selecciona aleatoriamente entre las tres jugadas y compite con el jugador.
- **Tecla "S" para iniciar**: El jugador debe presionar la tecla **S** para comenzar el juego.

## 🛠️ Requisitos

Para ejecutar este proyecto, necesitarás las siguientes dependencias:

- **Python 3.x**
- **OpenCV** para la captura de video y procesamiento de imágenes.
- **MediaPipe** para el reconocimiento de gestos de la mano.
- **Numpy** (opcional) para cálculos adicionales.

### Instalación de dependencias:

```bash
pip install opencv-python mediapipe numpy
```

## 🔧 Cómo Ejecutar el Proyecto
1. Clonar el repositorio o copiar el código fuente en tu entorno local.
2. Instalar las dependencias listadas arriba si no lo has hecho.
3. Ejecutar el script para iniciar el juego:
```bash
python piedra_papel_tijeras_señas.py
```
4. Iniciar el juego:
- Presiona la tecla S para comenzar.
- Levanta tu mano frente a la cámara para indicarle a la IA que hay un jugador.
- Realiza tres movimientos con tu mano para seleccionar tu jugada:
    - Piedra: Mano cerrada.
    - Papel: Mano abierta.
    -Tijeras: Mano en forma de tijeras (índice y medio levantados).

## 🖱️ Controles del Juego
- Presionar "S": Inicia el juego y pone en marcha el reconocimiento de gestos.
- Levantamiento de la mano: Indica al sistema que el jugador está listo para hacer una jugada.
- Tres movimientos: Realiza tres movimientos consecutivos con la mano para seleccionar tu jugada (piedra, papel o tijeras).
- IA hace su jugada: La IA selecciona aleatoriamente una jugada.

## 🧠 Lógica del Juego
-> **Flujo del Juego:**
- El jugador presiona la tecla S para iniciar la partida.
- La cámara comienza a detectar la presencia de una mano levantada para confirmar que hay un jugador listo para jugar contra la IA.
- Tres movimientos de mano: El jugador debe mover su mano tres veces frente a la cámara para indicar su elección:
- **Piedra:** Mano cerrada.
- **Papel:** Mano abierta.
- **Tijeras:** Mano en forma de tijeras.
- La **IA** hace una jugada aleatoria entre piedra, papel, o tijeras.
- El sistema compara las dos jugadas (la del jugador y la de la IA) y determina el ganador.
- El resultado se muestra en pantalla (gana el jugador, la IA o empate).
-> **IA:**
- La **IA** selecciona aleatoriamente entre las tres opciones y compite con el jugador, creando una experiencia similar a la clásica piedra, papel o tijeras, pero controlada por gestos.

## 🎨 Reconocimiento de Señas
- El sistema detecta tres gestos principales de la mano:
- **Piedra:** Mano completamente cerrada.
- **Papel:** Mano completamente abierta.
- **Tijeras:** Mano en forma de tijeras, con el dedo índice y el dedo medio levantados.
->¿Cómo selecciona el jugador su jugada?
- El jugador debe realizar **tres movimientos** frente a la cámara para que el sistema entienda cuál es su jugada final. Al finalizar, el sistema toma la última seña capturada como la jugada final.

---
**¡Gracias por jugar a Piedra, Papel, Tijeras con reconocimiento de señas!**