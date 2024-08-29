# 📝 Tarea 08: Parte 1 - Gestión de Recursos y Uso de Dispose() en C#

## 🎯 Objetivo General
Desarrollar una comprensión profunda sobre la gestión de recursos en C# mediante el uso de `Dispose()` y el patrón `using`, asegurando la liberación adecuada de recursos no administrados.

## 📌 Objetivos Específicos
- **💡 Comprender la importancia de liberar recursos no administrados:**
  - Conocer por qué es crucial manejar y liberar recursos no administrados en aplicaciones .NET.
  
- **🔧 Implementar el uso de `using` para manejar recursos:**
  - Aprender a utilizar el patrón `using` en C# para manejar eficientemente recursos como archivos.

## 🛠️ Actividades

### 1. Desarrollo de Funcionalidad Básica
- **Crear una aplicación de consola:**
  - Diseñar una aplicación de consola que permita al usuario leer y escribir en archivos de texto.

- **Implementar la clase `FileManager`:**
  - Desarrollar una clase `FileManager` con los métodos `LeerArchivo(string ruta)` y `EscribirArchivo(string ruta, string contenido)`.

### 2. Implementación del Patrón `using`
- **Aplicar `using` en los métodos de `FileManager`:**
  - Utilizar la estructura `using` para manejar instancias de `StreamReader` y `StreamWriter`, asegurando que los recursos se liberen automáticamente.

### 3. Investigación
- **Funcionamiento del Patrón `using` y `Dispose()`:**
  - Investigar cómo el patrón `using` simplifica la gestión de recursos en C#.
  - Diferenciar entre recursos administrados y no administrados.
  - Documentar ejemplos adicionales donde el uso de `Dispose()` es crucial.

## 📦 Entregables
- **Código fuente de la aplicación de consola:**
  - Incluye la funcionalidad implementada para la gestión de archivos y el uso del patrón `using`.
  
- **Documento de investigación:**
  - Un informe que detalla la gestión de recursos y el uso de `Dispose()` en C#, con ejemplos y explicaciones.

---

✨ **¡Buena suerte con la implementación y la investigación!** ✨
