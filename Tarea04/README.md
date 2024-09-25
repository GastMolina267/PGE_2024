# 🎮 Simulación de Aventura Pokémon
---

> **Nota:** Estos ejercicios te guiarán desde conceptos básicos hasta la implementación avanzada de herencia, polimorfismo y más, para reforzar tus conocimientos en POO. Junto a la implementación de CallBacks y Bucles Espaciadores de eventos.

¡Bienvenido a la **Simulación de Aventura Pokémon**! En este emocionante proyecto, podrás explorar un mundo lleno de Pokémon, combatir contra criaturas salvajes, desafiar a líderes de gimnasio y, por supuesto, curar a tus Pokémon en el Centro Pokémon. Todo esto mientras aprovechas las ventajas de las funciones callback en C++ para crear una experiencia de juego altamente modular y personalizable.

## Descripción 🚀

Esta simulación recrea una aventura Pokémon clásica en un entorno de consola. El jugador puede:
- 🗺️ Explorar un mapa dinámico.
- ⚔️ Enfrentarse a Pokémon salvajes y líderes de gimnasio.
- 🏥 Curar y recuperar a sus Pokémon.
- 📈 Subir de nivel a sus Pokémon tras ganar combates.
- 🏆 Derrotar a líderes de gimnasio para completar la aventura.

## Uso de Funciones Callback🔧 

El proyecto implementa funciones callback en diversos puntos para una mayor flexibilidad:

1. **Inicio del Combate:**
   - **Selección del Jugador:** Callback que selecciona el Pokémon del jugador al iniciar el combate.
   - **Selección del Oponente:** Callback que selecciona al Pokémon enemigo, ajustado al nivel del jugador.

2. **Acciones de Combate:**
   - **Selección de Movimientos:** Callbacks que seleccionan los movimientos tanto del jugador como del oponente.
   - **Ataque:** Callback que realiza el ataque de un Pokémon al otro.

3. **Resultados del Combate:**
   - **Victoria:** Callback que sube de nivel al Pokémon del jugador al ganar un combate.
   - **Derrota:** Callback que envía al Pokémon derrotado al Centro Pokémon para su recuperación.

## Funcionalidades📋 

- **Exploración del Mapa:** Mueve a tu personaje a través de diferentes ubicaciones.
- **Sistema de Combate:** Lucha contra Pokémon salvajes y líderes de gimnasio con un sistema de combate escalado.
- **Curación:** Lleva a tus Pokémon al Centro Pokémon para restaurar su salud.
- **Centro Pokémon:** Recupera Pokémon debilitados después de los combates.
- **Gimnasios:** Enfrenta y derrota a líderes de gimnasio para avanzar en la aventura.

## Requisitos del Sistema💻 

- **Lenguaje de Programación:** C++
- **Compilador:** Compatible con C++11 o superior
- **Librerías:** Librerías estándar de C++

## Instrucciones de Instalación🛠️ 

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/GastMolina267/Tarea04.git
2. **Compilar el código:**
    ```bash
    g++ main.cpp -o pokemon_aventura
3. **Ejecutar el programa:**
    ```bash
    ./pokemon_aventura

## Cómo Jugar🎮 
- **Moverse:** Usa las teclas [N], [S], [E], [W] para moverte en el mapa.
- **Curar Pokémon:** Presiona [C] para curar a tus Pokémon en el Centro Pokémon.
- **Recoger Pokémon:** Presiona [R] para recoger Pokémon debilitados del Centro Pokémon.
- **Salir:** Presiona [Q] para salir del juego.

## Contribuciones🤝 
Las contribuciones son bienvenidas. Si deseas mejorar este proyecto, realiza un fork del repositorio y envía un pull request con tus mejoras. ¡Aportaciones de código, reportes de bugs y sugerencias son siempre bienvenidos!

---
**¡Gracias por explorar el mundo Pokémon con nosotros! ¡Esperamos que disfrutes de esta aventura y de la experiencia de desarrollo en C++ con funciones callback!**