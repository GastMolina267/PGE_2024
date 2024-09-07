# 🛠️ Tarea09_03: Migración del Programa_Integrado a WinForms

## 🎯 Objetivo General
El objetivo de esta tarea es migrar el proyecto **Programa_Integrado**, desarrollado originalmente en consola, a una aplicación con interfaz gráfica en Windows Forms. Manteniendo la misma funcionalidad, se busca mejorar la interacción del usuario utilizando controles gráficos y aprovechar las ventajas de una interfaz visual más intuitiva.

## 📜 Descripción del Proyecto Original en Consola
El **Programa_Integrado** es un proyecto en C++ que aplica los conceptos fundamentales de la Programación Orientada a Objetos (POO), como herencia, encapsulación y polimorfismo. Integra la gestión de distintas entidades a través de las clases `Persona`, `Empleado`, `Estudiante` y `Trabajador`, permitiendo la simulación de escenarios laborales y educativos.

### Estructura de Clases:
1. **Clase Persona:**
   - Clase base que define los atributos comunes de una persona: nombre, edad, y género.
   
2. **Clase Empleado:**
   - Hereda de `Persona` y añade atributos como salario y cargo, representando a una persona en un contexto laboral.
   
3. **Clase Estudiante:**
   - Hereda de `Persona` y añade un atributo `nota`, representando a una persona en un contexto educativo.

4. **Clase Trabajador:**
   - Contiene un objeto `Persona` y añade atributos como departamento y horas trabajadas, calculando el salario en función de estos parámetros.

### Funcionalidad:
- El programa de consola permite agregar empleados, estudiantes y trabajadores, visualizar la información y realizar cálculos basados en los atributos proporcionados por el usuario.

## 🚀 Objetivo de la Migración a WinForms
La migración del **Programa_Integrado** a una aplicación de Windows Forms tiene como propósito ofrecer una interfaz gráfica interactiva que permita gestionar de forma más amigable los diferentes elementos del programa. Se implementarán formularios que faciliten la creación, visualización y gestión de empleados, estudiantes y trabajadores, manteniendo el mismo flujo lógico y funcionalidad del programa original.

### Características Clave en la Migración:
1. **Interfaz Gráfica Intuitiva:**
   - Crear formularios que representen las distintas funcionalidades: registro de personas, empleados, estudiantes y trabajadores, así como la visualización de la información correspondiente.
   
2. **Entradas y Salidas Visuales:**
   - Los datos de entrada se recogerán mediante controles como `TextBox` y `ComboBox`, mientras que los resultados se mostrarán en controles como `Label` y `ListBox`.

3. **Gestión Dinámica de Información:**
   - La aplicación contará con formularios para agregar, editar y visualizar la información de las distintas entidades (`Empleado`, `Estudiante`, `Trabajador`), haciendo uso de eventos gráficos.

4. **Cálculos Automáticos:**
   - Los cálculos de salario y otros atributos se realizarán automáticamente al ingresar los datos, mostrando los resultados de forma clara y visual en la interfaz.

## 🛠️ Pasos de la Migración
1. **Creación del Proyecto en WinForms:**
   - Iniciar un nuevo proyecto de Windows Forms en Visual Studio y migrar el código existente del programa de consola.

2. **Diseño de la Interfaz:**
   - Diseñar formularios para gestionar cada entidad (`Persona`, `Empleado`, `Estudiante`, `Trabajador`) utilizando controles visuales como botones, cuadros de texto y etiquetas.

3. **Implementación de Funcionalidad:**
   - Adaptar la lógica del proyecto original de consola a los eventos de la interfaz gráfica, utilizando los métodos existentes con pequeñas modificaciones para interactuar con los controles gráficos.

4. **Pruebas y Optimización:**
   - Realizar pruebas para asegurar que la aplicación conserva toda la funcionalidad del proyecto de consola, mejorando la experiencia del usuario con una interfaz visual más atractiva.

## 📦 Entregables
- **Aplicación en WinForms:**
  - Proyecto migrado completo, que permita realizar las mismas operaciones que el programa de consola, pero con una interfaz gráfica en Windows Forms.

- **Documentación:**
  - Un informe que detalle el proceso de migración, las decisiones de diseño, los desafíos encontrados y las soluciones implementadas, acompañado de capturas de pantalla de la interfaz.

---

✨ **¡Experimenta una nueva forma de gestionar empleados, estudiantes y trabajadores con la nueva interfaz gráfica del Programa_Integrado en WinForms!** ✨