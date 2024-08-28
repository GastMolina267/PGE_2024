using System;

class Program
{
    static void Main(string[] args)
    {
        // Si ocurre alguna excepción durante la ejecución del bloque try,
        // el flujo del programa se desviará al bloque catch correspondiente
        try
        {
            Console.Write("Ingrese un número: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            int result = 100 / number;
            Console.WriteLine($"El resultado de 100 dividido por {number} es: {result}");
        }
        catch (FormatException ex)
        // Este bloque se ejecutará si el usuario ingresa algo que no puede ser convertido a un entero
        {
            Console.WriteLine("Error: Entrada inválida. Por favor, ingrese un número válido.");
            Console.WriteLine($"Detalles: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        // Este bloque se ejecutará si el usuario ingresa cero, lo que causaría una división por cero
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
            Console.WriteLine($"Detalles: {ex.Message}");
        }
        catch (Exception ex)
        // Este es un bloque de captura general para cualquier otra excepción no prevista en los bloques anteriores
        {
            Console.WriteLine("Se ha producido un error inesperado.");
            Console.WriteLine($"Detalles: {ex.Message}");
        }
        finally
        // Este bloque siempre se ejecutará, independientemente de si se produjo una excepción o no
        {
            Console.WriteLine("Fin del programa.");
        }
    }
}