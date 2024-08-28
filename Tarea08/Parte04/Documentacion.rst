Excepciones Específicas de la Librería Estándar de .NET
=======================================================

Introducción
------------

Las excepciones son una parte fundamental del manejo de errores en .NET. La librería estándar proporciona una variedad de excepciones predefinidas que ayudan a los desarrolladores a manejar situaciones de error específicas de manera más efectiva.

Excepciones Comunes y Sus Usos
------------------------------

ArgumentNullException
^^^^^^^^^^^^^^^^^^^^^

**Descripción:** Se lanza cuando se pasa un argumento nulo a un método que no acepta argumentos nulos.

**Uso:** Validar que los argumentos pasados a un método no sean nulos.

**Ejemplo:**

.. code-block:: csharp

   public void ProcesarDatos(string datos)
   {
       if (datos == null)
           throw new ArgumentNullException(nameof(datos), "Los datos no pueden ser nulos.");
       // Procesar datos...
   }

ArgumentOutOfRangeException
^^^^^^^^^^^^^^^^^^^^^^^^^^^

**Descripción:** Se lanza cuando el valor de un argumento está fuera del rango permitido.

**Uso:** Validar que los valores de los argumentos estén dentro de rangos específicos.

**Ejemplo:**

.. code-block:: csharp

   public void EstablecerEdad(int edad)
   {
       if (edad < 0 || edad > 120)
           throw new ArgumentOutOfRangeException(nameof(edad), "La edad debe estar entre 0 y 120.");
       // Establecer edad...
   }

FormatException
^^^^^^^^^^^^^^^

**Descripción:** Se lanza cuando el formato de un argumento no es válido.

**Uso:** Validar que los datos de entrada tengan el formato correcto, especialmente en conversiones.

**Ejemplo:**

.. code-block:: csharp

   public int ConvertirAEntero(string input)
   {
       if (!int.TryParse(input, out int result))
           throw new FormatException("La cadena de entrada no tiene un formato válido para un número entero.");
       return result;
   }

InvalidOperationException
^^^^^^^^^^^^^^^^^^^^^^^^^

**Descripción:** Se lanza cuando una operación no es válida debido al estado actual del objeto.

**Uso:** Indicar que una operación no puede ser realizada en el estado actual del objeto.

**Ejemplo:**

.. code-block:: csharp

   public class Cuenta
   {
       private decimal saldo;

       public void Retirar(decimal cantidad)
       {
           if (saldo < cantidad)
               throw new InvalidOperationException("Saldo insuficiente para realizar el retiro.");
           // Realizar retiro...
       }
   }

NullReferenceException
^^^^^^^^^^^^^^^^^^^^^^

**Descripción:** Se lanza cuando se intenta usar un objeto que es null.

**Uso:** Aunque es mejor prevenir este error con comprobaciones null, puede usarse para indicar que un objeto necesario es null.

**Ejemplo:**

.. code-block:: csharp

   public void ProcesarUsuario(Usuario usuario)
   {
       if (usuario == null)
           throw new NullReferenceException("El usuario no puede ser null.");
       // Procesar usuario...
   }

IndexOutOfRangeException
^^^^^^^^^^^^^^^^^^^^^^^^

**Descripción:** Se lanza cuando se intenta acceder a un índice que está fuera del rango de un array.

**Uso:** Indicar que se está intentando acceder a un elemento de un array con un índice inválido.

**Ejemplo:**

.. code-block:: csharp

   public int ObtenerElemento(int[] array, int indice)
   {
       if (indice < 0 || indice >= array.Length)
           throw new IndexOutOfRangeException("El índice está fuera del rango del array.");
       return array[indice];
   }

Conclusión
----------

El uso adecuado de estas excepciones estándar mejora la robustez y la claridad del código. Permiten comunicar de manera precisa los errores que ocurren durante la ejecución del programa, facilitando el debug y el mantenimiento del código. Es importante seleccionar la excepción más apropiada para cada situación para maximizar la utilidad de la información de error proporcionada.