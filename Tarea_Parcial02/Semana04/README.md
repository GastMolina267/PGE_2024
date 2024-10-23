# 🖥️ Proyecto de Traducción de Lengua de Señas a Texto - Semana 04

---

## 📅 Descripción de la Semana 04

En esta última semana del proyecto, nos enfocamos en la implementación del **software traductor de lengua de señas a texto** utilizando **PyTorch** y **PyQt5**. El sistema captura las posiciones de las manos y la pose del cuerpo en tiempo real y realiza la predicción de señas, traduciendo gestos a texto de manera eficiente.

Este proyecto combina conceptos fundamentales de **aprendizaje profundo**, con especial enfoque en la arquitectura de **Transformers**, y técnicas de **visión por computadora** para capturar y procesar secuencias de imágenes de una cámara frontal.

---

## 🛠️ Especificaciones Técnicas

### 🔍 Conjunto de Datos

El conjunto de datos utilizado en este proyecto contiene **5800 secuencias** capturadas con **MediaPipe**, que incluyen los puntos clave de las manos y el cuerpo de una persona realizando diferentes señas.

### 🧠 Modelo de Aprendizaje

El modelo fue desarrollado utilizando **PyTorch** y **PyTorch Lightning** como framework. La clasificación de secuencias se realizó utilizando el bloque **Transformer Encoder**, basado en la arquitectura descrita en el paper **Attention Is All You Need**.

- **Data Augmentation**: Se realizaron técnicas de aumento de datos para obtener más características útiles. En lugar de entrenar al modelo directamente con los puntos crudos, se calcularon distancias entre las manos y ángulos que aportaron más información para la etapa de aprendizaje.

### 🖼️ Interfaz de Usuario

La interfaz gráfica fue desarrollada utilizando **PyQt5**, proporcionando una experiencia interactiva que permite seleccionar la cámara y visualizar la predicción en tiempo real.

---

## ⚙️ Funcionamiento del Programa

1. El programa inicia pulsando el botón **Iniciar**.
2. Se debe seleccionar la cámara (0 indica la cámara interna del computador, otros números indican cámaras externas conectadas).
3. El programa captura a una persona realizando una seña durante **30 fotogramas**, ya sea una seña estática o dinámica.
4. Después de capturar los fotogramas, los datos se envían al modelo para realizar la predicción de la seña.
5. El programa muestra debajo la letra, número o palabra predicha.
6. El texto predicho se concatena para formar oraciones más largas.

---

**¡Gracias por revisar nuestro proyecto de traducción de lenguaje de señas a texto!**
