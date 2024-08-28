using System;

class Program
{
    static void Main(string[] args)
    {
        // Si ocurre alguna excepci�n durante la ejecuci�n del bloque try,
        // el flujo del programa se desviar� al bloque catch correspondiente
        try
        {
            Console.Write("Ingrese un n�mero: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            int result = 100 / number;
            Console.WriteLine($"El resultado de 100 dividido por {number} es: {result}");
        }
        catch (FormatException ex)
        // Este bloque se ejecutar� si el usuario ingresa algo que no puede ser convertido a un entero
        {
            Console.WriteLine("Error: Entrada inv�lida. Por favor, ingrese un n�mero v�lido.");
            Console.WriteLine($"Detalles: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        // Este bloque se ejecutar� si el usuario ingresa cero, lo que causar�a una divisi�n por cero
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
            Console.WriteLine($"Detalles: {ex.Message}");
        }
        catch (Exception ex)
        // Este es un bloque de captura general para cualquier otra excepci�n no prevista en los bloques anteriores
        {
            Console.WriteLine("Se ha producido un error inesperado.");
            Console.WriteLine($"Detalles: {ex.Message}");
        }
        finally
        // Este bloque siempre se ejecutar�, independientemente de si se produjo una excepci�n o no
        {
            Console.WriteLine("Fin del programa.");
        }
    }
}