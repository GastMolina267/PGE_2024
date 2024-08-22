# 🧮 Simulación de Control de Errores en una Calculadora Científica

¡Bienvenido/a al repositorio de la Tarea 07 de la materia Programación Genérica y Eventos (PGE)! 🚀

Esta actividad se enfoca en el diseño y desarrollo de una calculadora científica en C#, implementando un robusto sistema de control de errores. El objetivo principal es crear una calculadora que no solo realice cálculos avanzados, sino que también gestione eficazmente los errores que puedan ocurrir durante su uso.

## ✨ Objetivos

1. **Diseño de una Calculadora Científica:**
   - Implementar una calculadora que soporte operaciones matemáticas avanzadas como exponenciación, raíces, logaritmos, funciones trigonométricas, y mucho más.

2. **Implementación de Control de Errores:**
   - Desarrollar un sistema de manejo de errores para asegurar que la calculadora pueda manejar entradas inválidas, operaciones matemáticas imposibles, y otros errores comunes sin fallar.

3. **Manejo de Excepciones Personalizadas:**
   - Crear y gestionar excepciones personalizadas que ofrezcan retroalimentación clara y útil al usuario cuando se produzcan errores.

4. **Interfaz de Usuario Intuitiva:**
   - Diseñar una interfaz gráfica de usuario (GUI) en C# que sea fácil de usar y que integre el sistema de control de errores de manera transparente.

## 🎯 Funcionalidades de la Calculadora Científica

### 🧩 Funciones Matemáticas Avanzadas
- **Operaciones Básicas:** Suma, resta, multiplicación, división.
- **Exponentes y Raíces:** Cálculo de potencias y raíces enésimas.
- **Funciones Trigonométricas:** `sin`, `cos`, `tan`, así como sus inversas `arcsin`, `arccos`, `arctan`.
- **Logaritmos:** Logaritmos en cualquier base.

### 🛡️ Control de Errores
- **Validación de Entrada:**
  - Verificación de entradas numéricas antes de realizar operaciones.
  - Prevención de múltiples puntos decimales en un solo número.
  
- **Manejo de Errores Matemáticos:**
  - **División por Cero:** Detectar y manejar intentos de dividir por cero, mostrando un mensaje de error claro.
  - **Operaciones Imposibles:** Gestión de operaciones matemáticas no definidas, como raíces de números negativos en el conjunto de los números reales (excepto cuando se manejan números complejos).

- **Excepciones Personalizadas:**
  - Creación de eventos personalizados para manejar errores específicos y proporcionar retroalimentación detallada.

- **Interfaz de Usuario con Feedback Visual:**
  - Cambios de color en la interfaz para indicar resultados correctos o errores.
  - Mensajes emergentes (`MessageBox`) que notifican al usuario sobre errores específicos.

## 🛠️ Tecnologías Utilizadas

- **Lenguaje:** C#
- **Framework:** .NET
- **Paradigmas:** Programación Orientada a Objetos, Programación Orientada a Eventos

## 🚀 Ejecución del Proyecto

1. Clona este repositorio.
2. Abre la solución en Visual Studio.
3. Compila y ejecuta el código para ver la calculadora en acción.
4. Realiza diversas operaciones y observa cómo el sistema maneja las entradas válidas e inválidas.

## 🌟 Ejemplos de Uso

- **Cálculo de Suma:**
  - Ingrese dos números y presione el botón `+` para ver el resultado.
- **Manejo de Errores:**
  - Intente dividir un número por `0` para ver cómo la calculadora gestiona este error y proporciona un mensaje claro.

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Si deseas mejorar este proyecto o añadir nuevas funcionalidades, por favor abre un issue o envía un pull request.

---
¡Gracias por visitar este proyecto! Si te ha sido útil o interesante, considera dejar una ⭐ en el repositorio.
