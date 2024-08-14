# Proyecto Pokémon - Clase 3 de PDG 💻

> **Nota:** Estos ejercicios te guiarán desde conceptos básicos hasta la implementación avanzada de herencia, polimorfismo y más, para reforzar tus conocimientos en POO. Junto a la implementación de CallBacks y Bucles Espaciadores de eventos.

## Descripción📂

Este proyecto es un simulador básico de combates de Pokémon desarrollado en C++. Permite al usuario enfrentar a Pokémon enemigos, ganar experiencia y subir de nivel. El juego incluye un sistema de niveles que aumenta la dificultad progresivamente y una mecánica de curación en un centro Pokémon tras perder un combate.

## Características del Juego🎯

- **Combates Pokémon:** Enfréntate a Pokémon enemigos en emocionantes batallas.
- **Sistema de Niveles:**
  - Subirás de nivel después de ganar combates.
  - La cantidad de combates necesarios para subir de nivel aumenta progresivamente.
  - Los Pokémon enemigos escalan en nivel en función del nivel de tu Pokémon.
- **Centro Pokémon:** Si tu Pokémon es derrotado, será llevado automáticamente al centro Pokémon para ser curado.
- **Exploración del Mapa:** Explora diferentes ubicaciones dentro del juego.

## Estructura del Código📋

El programa está organizado en varias clases clave:

- **`Pokemon`**: Representa a un Pokémon, con atributos como nivel, salud y habilidades. Maneja combates y la subida de nivel.
- **`Mapa`**: Define el entorno en el que el jugador puede moverse y explorar.
- **`CentroPokemon`**: Representa el lugar donde los Pokémon son curados después de los combates.

### Métodos Clave📁

- **`void subirNivel();`**: Maneja la subida de nivel del Pokémon, incrementando atributos y restaurando la salud tras la cantidad necesaria de combates ganados.
- **`void curarPokemon();`**: Restaura la salud de un Pokémon en el centro Pokémon.
- **`void iniciarCombate();`**: Simula un combate entre el Pokémon del jugador y un Pokémon enemigo.

## Instalación y Ejecución🛠️

1. **Requisitos Previos:**
   - Compilador C++ compatible con C++11 o superior.

2. **Compilación:**
   Para compilar el programa, navega al directorio del proyecto y ejecuta:
   ```bash
   g++ -o pokemon_game main.cpp Pokemon.cpp Mapa.cpp CentroPokemon.cpp
3. **Ejecución:**
    Una vez compilado, ejecuta el programa con:
    ./pokemon_game

### **Futuras Mejoras**🚀
El proyecto puede ser ampliado con:
- **Mayor variedad de Pokémon y habilidades.**
- **Implementación de una interfaz gráfica.**
- **Mejoras en la inteligencia artificial de los Pokémon enemigos.**

## Contribuciones🤝

Este es un trabajo grupal, así que se fomenta el ooder compartir ideas y discutir enfoques en las sesiones de estudio. 

---
¡Buena suerte y disfruta aprendiendo C++ con POO! 🎉