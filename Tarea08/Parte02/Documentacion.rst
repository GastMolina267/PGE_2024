======================================
Manejo de Excepciones en C#
======================================

Tipos de Excepciones Específicas
-------------------

1. FileNotFoundException
~~~~~~~~~~~~
- **Descripción**: Se lanza cuando se intenta acceder a un archivo que no existe en la ruta especificada.
- **Cuándo usarla**: Al trabajar con operaciones de archivo donde la existencia del archivo es crucial.

2. IOException
~~~~~~~~~~~~
- **Descripción**: Es una excepción base para varios errores de E/S, incluyendo errores de lectura/escritura de archivos.
- **Cuándo usarla**: Para capturar una amplia gama de errores relacionados con operaciones de E/S.

3. UnauthorizedAccessException
~~~~~~~~~~~~
- **Descripción**: Se lanza cuando el sistema operativo deniega el acceso debido a un error de E/S o a un permiso específico.
- **Cuándo usarla**: Al trabajar con archivos o recursos que pueden tener restricciones de acceso.

Excepciones Específicas vs. Excepciones Generales
-------------------

Cuándo capturar excepciones específicas:
~~~~~~~~~~~~
1. Cuando se puede proporcionar un manejo significativo para ese tipo específico de error.
2. Cuando se necesita realizar acciones diferentes basadas en el tipo de excepción.
3. Para proporcionar mensajes de error más precisos y útiles al usuario.

Cuándo capturar excepciones generales:
~~~~~~~~~~~~
1. Como una "red de seguridad" para capturar cualquier excepción no prevista.
2. Cuando el manejo de errores es el mismo independientemente del tipo específico de excepción.
3. En la capa más externa de la aplicación para evitar que el programa se cierre inesperadamente.

Mejores prácticas:
~~~~~~~~~~~~
1. Siempre capturar las excepciones más específicas primero, seguidas de las más generales.
2. Evitar capturar `Exception` de forma general, a menos que sea absolutamente necesario.
3. Registrar o mostrar información detallada sobre las excepciones para facilitar la depuración.
4. Considerar relanzar excepciones cuando sea apropiado, para permitir que sean manejadas en un nivel superior.