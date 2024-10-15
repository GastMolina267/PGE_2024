# 🐍🧠 Snake AI - Aprendizaje Automático para Jugar Snake

---

## 📋 Descripción General

Este proyecto implementa un modelo de **aprendizaje automático** utilizando **PyTorch** para enseñar a una IA a jugar el clásico juego de **Snake**. El sistema utiliza técnicas de **aprendizaje por refuerzo** para que el agente aprenda a navegar por el tablero, recoger comida y evitar colisiones, mejorando su rendimiento con el tiempo.

La IA aprende a tomar decisiones basadas en el estado actual del juego, incluyendo la posición de la serpiente, la ubicación de la comida y los obstáculos. Este proyecto combina conceptos de **redes neuronales**, **algoritmos de optimización** y **teoría de juegos** para crear un agente inteligente capaz de dominar Snake.

## 🚀 Funcionalidades

- **Implementación del juego Snake**: Recreación del clásico juego Snake en Python.
- **Modelo de IA basado en PyTorch**: Utiliza redes neuronales para procesar el estado del juego y tomar decisiones.
- **Aprendizaje por refuerzo**: El agente mejora su estrategia a través de múltiples episodios de juego.
- **Visualización del aprendizaje**: Gráficos que muestran el progreso del aprendizaje del agente.
- **Modo de juego autónomo**: Observa cómo la IA juega Snake por sí misma.
- **Modo de entrenamiento**: Permite entrenar al modelo desde cero o continuar el entrenamiento desde un punto guardado.

## 🛠️ Requisitos

Para ejecutar este proyecto, necesitarás las siguientes dependencias:

- **Python 3.x**
- **PyTorch** para la implementación del modelo de aprendizaje automático.
- **Numpy** para cálculos numéricos eficientes.
- **Matplotlib** para la visualización de datos y el progreso del aprendizaje.
- **Pygame** (opcional) para una visualización mejorada del juego.

### Instalación de dependencias:

```bash
pip install torch numpy matplotlib pygame
```

## 🔧 Cómo Ejecutar el Proyecto

1. Clonar el repositorio o copiar el código fuente en tu entorno local.
2. Instalar las dependencias listadas arriba si no lo has hecho.
3. Ejecutar el script principal para iniciar el entrenamiento o el modo de juego:

```bash
python snake_ai_main.py
```

4. Usar los argumentos de línea de comando para seleccionar el modo:
   - `--train`: Inicia el modo de entrenamiento.
   - `--play`: Inicia el modo de juego autónomo con el modelo entrenado.
   - `--episodes`: Especifica el número de episodios para entrenar (por defecto: 1000).

## 🖱️ Controles y Configuración

- **Modo de entrenamiento:**
  - Ajusta los hiperparámetros en el archivo de configuración `config.py`.
  - Modifica la arquitectura de la red neural en `model.py`.
- **Modo de juego:**
  - Presiona **Espacio** para pausar/reanudar el juego.
  - Usa las teclas de flecha para controlar manualmente la serpiente (si está habilitado).
  - Presiona **Q** para salir del juego.

## 🧠 Lógica del Aprendizaje

-> **Arquitectura del modelo:**

- Utiliza una red neuronal profunda implementada en PyTorch.
- La entrada incluye el estado actual del juego (posición de la serpiente, comida, obstáculos).
- La salida es una distribución de probabilidad sobre las posibles acciones (arriba, abajo, izquierda, derecha).

-> **Algoritmo de aprendizaje:**

- Implementa Q-Learning con aproximación de función utilizando redes neuronales (Deep Q-Network).
- Utiliza una memoria de repetición para almacenar y muestrear experiencias pasadas.
- Aplica aprendizaje por lotes para mejorar la estabilidad del entrenamiento.

-> **Proceso de entrenamiento:**

1. El agente juega múltiples episodios, almacenando sus experiencias.
2. En cada paso, el modelo predice la mejor acción basada en el estado actual.
3. Se aplica una política ε-greedy para balancear exploración y explotación.
4. El modelo se actualiza periódicamente utilizando el error entre la recompensa predicha y la real.

## 📊 Evaluación del Rendimiento

- El sistema registra métricas clave como la puntuación por episodio, la longitud de la serpiente y el tiempo de supervivencia.
- Se generan gráficos que muestran la evolución del rendimiento a lo largo del tiempo.
- Se guardan los mejores modelos basados en criterios de rendimiento predefinidos.

---

**¡Gracias por explorar el proyecto Snake AI con aprendizaje automático!**
