# 🛠️ Programa_Integrado
---

## 📜 Descripción Básica

**Programa_Integrado** es un proyecto en C++ que integra cuatro enunciados relacionados en un único programa. Este programa se centra en la creación de una clase base `Persona`, a partir de la cual se derivan tres subclases: `Empleado`, `Estudiante` y `Trabajador`. El objetivo es aplicar conceptos fundamentales de la Programación Orientada a Objetos (POO), como la herencia, encapsulación y polimorfismo, en un contexto unificado.

## 📂 Estructura del Programa

### 1️⃣ **Clase Persona**
   - **Descripción:** La clase `Persona` representa a un individuo con atributos básicos como nombre, edad y género. Es la clase base de la cual se derivan las demás subclases.
   - **Objetivo:** Establecer una estructura común para las entidades `Empleado`, `Estudiante` y `Trabajador`.

### 2️⃣ **Clase Empleado**
   - **Descripción:** `Empleado` hereda de `Persona` y añade atributos específicos como salario y cargo. Representa a una persona en un contexto laboral.
   - **Objetivo:** Extender la funcionalidad de `Persona` para gestionar información laboral.

### 3️⃣ **Clase Estudiante**
   - **Descripción:** `Estudiante` es otra subclase de `Persona`, que incluye un atributo adicional, `nota`, para reflejar el desempeño académico.
   - **Objetivo:** Especializar la clase `Persona` para el contexto educativo.

### 4️⃣ **Clase Trabajador**
   - **Descripción:** `Trabajador` es una clase que contiene un objeto `Persona` y añade atributos como departamento y horas trabajadas. Incluye métodos para calcular el salario según el departamento y horas trabajadas.
   - **Objetivo:** Demostrar la composición y la gestión de cálculos específicos basados en atributos adicionales.

## 🚀 **Cómo Utilizar este Programa**

1. **Clona el Repositorio:**
   ```bash
   git clone https://github.com/GastMolina/Programa_Integrado.git
2. **Navega al Directorio del Proyecto:**
    ```bash
   cd Programa_Integrado
3. **Compila y Ejecuta el Código:**
    ```bash
    g++ programa_integrado.cpp -o programa_integrado
    ./programa_integrado
4. **Interacción del Usuario:**
    El programa ofrece un menú interactivo que permite al usuario agregar empleados, estudiantes y trabajadores, y visualizar la información completa del personal registrado.

## 🎯 **Objetivos del Proyecto**
- **Comprender y Aplicar POO:** Profundizar en conceptos clave de la Programación Orientada a Objetos, integrando varias clases en un programa cohesivo.
- **Desarrollar Código Modular:** Fomentar la creación de clases reutilizables y fácilmente extensibles mediante el uso de herencia y composición.
- **Simulación de Escenarios Reales:** Aplicar el conocimiento de POO para modelar escenarios laborales y educativos en un entorno de programación.

## 🌐 Recursos Adicionales
- **Documentación de C++**: [cppreference.com](https://en.cppreference.com/w/)
- **Material de Estudio**: Revisa los apuntes y ejemplos de clase para reforzar conceptos.
- **Comunicación**: Si tienes dudas, no dudes en contactar al profesor o discutir en el foro de la clase.

## 🤝 Contribuciones
Este proyecto es una parte fundamental del aprendizaje colaborativo, por lo que se anima a los estudiantes a compartir ideas y discutir diferentes enfoques en las sesiones grupales.

---
**¡Buena suerte y sigue desarrollando tus habilidades en C++ con este Programa_Integrado! 🎉**