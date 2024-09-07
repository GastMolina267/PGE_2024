# 📝 Tarea 09_01: Migración de Proyecto Integrador a WinForms

## 🎯 Objetivo General
Migrar el proyecto de consola que combina las funcionalidades de las clases `FileManager` y `Calculator` a una aplicación con interfaz gráfica utilizando Windows Forms. Esta migración incluirá la adaptación del sistema de logging y manejo de excepciones implementados en consola.

## 🛠️ Descripción del Proyecto de Consola
El proyecto original de consola integra las siguientes funcionalidades:

- **📁 FileManager:**
  - Gestión de archivos, lectura, y escritura.
- **🧮 Calculator:**
  - Realización de operaciones matemáticas básicas.
  
Además, se implementa un sistema de **logging** que registra las excepciones y las operaciones realizadas, utilizando la estructura `using` para el manejo de archivos de log, y se crean excepciones personalizadas según sea necesario.

## 🚀 Objetivo de la Migración a WinForms
El objetivo principal de la migración es transformar esta aplicación de consola en una interfaz gráfica amigable para el usuario, manteniendo todas las funcionalidades esenciales y mejorando la experiencia de uso mediante controles visuales.

### Características Clave en la Migración:
1. **Menú de Opciones Gráfico:**
   - El menú que selecciona entre las operaciones de `FileManager` y `Calculator` será adaptado a botones interactivos y opciones desplegables.
   
2. **Sistema de Logging:**
   - El sistema de logging seguirá registrando operaciones y excepciones, pero será visualizado dentro de la aplicación mediante cuadros de texto o ventanas emergentes.
   
3. **Manejo de Excepciones:**
   - Se mantendrá el manejo adecuado de excepciones, pero ahora se notificarán a los usuarios mediante mensajes emergentes (`MessageBox`).

4. **Adaptación de Funcionalidades:**
   - Las operaciones del `FileManager` y `Calculator` se realizarán mediante botones, cuadros de texto y otros controles visuales.

## 🛠️ Pasos de la Migración
1. **Crear el Proyecto de WinForms:**
   - En Visual Studio 2022, se creará un nuevo proyecto de Windows Forms y se adaptará el código de la aplicación de consola.

2. **Diseño de la Interfaz:**
   - Usar los controles de WinForms (botones, cuadros de texto, `ListBox`, etc.) para recrear el flujo del programa original, integrando una interfaz intuitiva.

3. **Integración de Funcionalidades:**
   - Copiar y adaptar las clases de `FileManager` y `Calculator` para funcionar con eventos de los botones de WinForms.

4. **Sistema de Logging Visual:**
   - Adaptar el sistema de logging para que muestre las entradas en tiempo real dentro de la interfaz.

5. **Pruebas y Validación:**
   - Probar exhaustivamente la aplicación para asegurar que todas las funcionalidades del proyecto original sigan funcionando correctamente en la nueva interfaz.

## 📦 Entregables
- **Aplicación en WinForms:**
  - Proyecto completo con la interfaz gráfica que incluye todas las funcionalidades migradas de la aplicación de consola.
  
- **Documentación:**
  - Documento explicando el proceso de migración, los desafíos encontrados, y cómo fueron solucionados.

---

✨ **¡Lleva tu proyecto de consola a otro nivel con una interfaz gráfica amigable en WinForms!** ✨
