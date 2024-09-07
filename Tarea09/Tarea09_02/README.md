# 🎮 Tarea09_02: Migración de Simulación de Aventura Pokémon a WinForms

## 🎯 Objetivo General
Migrar el proyecto de simulación de aventura Pokémon desde un entorno de consola a una aplicación con interfaz gráfica utilizando Windows Forms. El objetivo es conservar todas las mecánicas del juego y mejorar la experiencia del usuario mediante una interfaz visual, manteniendo el uso de funciones callback y la escalabilidad del sistema de combate.

## 🛠️ Descripción del Proyecto de Consola
El proyecto original simula una aventura Pokémon clásica en consola, donde el jugador puede:
- ⚔️ Combatir contra Pokémon salvajes y líderes de gimnasio.

El sistema utiliza **funciones callback** para modular las diferentes etapas del combate y la progresión del jugador, permitiendo una mayor flexibilidad y personalización.

### Uso de Funciones Callback
- **Selección de Pokémon y movimientos.**
- **Ejecución de ataques y cálculo de resultados.**
- **Subida de nivel y recuperación en el Centro Pokémon.**

## 🚀 Objetivo de la Migración a WinForms
El principal objetivo es trasladar la experiencia de juego a una interfaz gráfica amigable, donde los jugadores puedan interactuar de manera más visual con los diferentes sistemas de combate y gestión de Pokémon. Esto permitirá un acceso más intuitivo a las funcionalidades del juego, mientras se mantienen las mecánicas clave y la flexibilidad de las callbacks.

### Características Clave en la Migración:
1. **Interfaz Gráfica Dinámica:**
   - El mapa, las batallas, y el Centro Pokémon se implementarán mediante botones, imágenes y cuadros de diálogo.
   
2. **Sistema de Combate Visual:**
   - El sistema de combate será visualizado con barras de salud, opciones de ataque, y animaciones que representen el estado de los Pokémon.

## 🛠️ Pasos de la Migración
1. **Crear el Proyecto en WinForms:**
   - Iniciar un nuevo proyecto de Windows Forms en Visual Studio y migrar el código de la simulación en consola a esta nueva estructura.

2. **Diseño de la Interfaz:**
   - Usar controles como botones, imágenes, y barras de progreso para representar la salud de los Pokémon, sus ataques y los movimientos en el mapa.

3. **Adaptación del Sistema de Callbacks:**
   - Integrar las funciones callback dentro de los eventos de los botones y controles de la interfaz gráfica.

4. **Pruebas y Ajustes:**
   - Asegurarse de que la aplicación gráfica mantenga la misma funcionalidad del proyecto de consola, con una mejora en la experiencia del usuario.

## 📦 Entregables
- **Aplicación en WinForms:**
  - Proyecto completo de la simulación Pokémon en Windows Forms, con todas las funcionalidades migradas y una interfaz gráfica atractiva.
  
- **Documentación:**
  - Informe explicando el proceso de migración, los desafíos encontrados y las soluciones implementadas, con capturas de pantalla del juego en su nueva interfaz.

---

✨ **¡Explora el mundo Pokémon ahora con una interfaz gráfica interactiva y desafía a los líderes de gimnasio en WinForms!** ✨