using System;
using System.IO;

public class FileManager
{
    public static string LeerArchivo(string ruta)
    {
        if (string.IsNullOrEmpty(ruta))
            throw new ArgumentNullException(nameof(ruta), "La ruta del archivo no puede ser nula o vacía.");

        if (!File.Exists(ruta))
            throw new FileNotFoundException("El archivo especificado no existe.", ruta);

        using (StreamReader reader = new StreamReader(ruta))
        {
            return reader.ReadToEnd();
        }
    }

    public static void EscribirArchivo(string ruta, string contenido)
    {
        if (string.IsNullOrEmpty(ruta))
            throw new ArgumentNullException(nameof(ruta), "La ruta del archivo no puede ser nula o vacía.");

        if (contenido == null)
            throw new ArgumentNullException(nameof(contenido), "El contenido no puede ser nulo.");

        using (StreamWriter writer = new StreamWriter(ruta))
        {
            writer.Write(contenido);
        }
    }

    public static int DividirNumeros(int dividendo, int divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException("No se puede dividir por cero.");

        return dividendo / divisor;
    }

    public static string ProcesarCadena(string input, int startIndex, int length)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input), "La cadena de entrada no puede ser nula o vacía.");

        if (startIndex < 0 || startIndex >= input.Length)
            throw new ArgumentOutOfRangeException(nameof(startIndex), "El índice de inicio está fuera del rango válido.");

        if (length < 0 || startIndex + length > input.Length)
            throw new ArgumentOutOfRangeException(nameof(length), "La longitud especificada es inválida.");

        return input.Substring(startIndex, length);
    }

    public static int ConvertirAEntero(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input), "La cadena de entrada no puede ser nula o vacía.");

        if (!int.TryParse(input, out int result))
            throw new FormatException("La cadena de entrada no tiene un formato válido para un número entero.");

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Ejemplo de uso de LeerArchivo
            string contenido = FileManager.LeerArchivo("ejemplo.txt");
            Console.WriteLine("Contenido del archivo:");
            Console.WriteLine(contenido);

            // Ejemplo de uso de EscribirArchivo
            FileManager.EscribirArchivo("nuevoarchivo.txt", "Este es un nuevo contenido");
            Console.WriteLine("Archivo escrito exitosamente.");

            // Ejemplo de uso de DividirNumeros
            int resultado = FileManager.DividirNumeros(10, 2);
            Console.WriteLine($"Resultado de la división: {resultado}");

            // Ejemplo de uso de ProcesarCadena
            string subcadena = FileManager.ProcesarCadena("Hola Mundo", 0, 4);
            Console.WriteLine($"Subcadena: {subcadena}");

            // Ejemplo de uso de ConvertirAEntero
            int numero = FileManager.ConvertirAEntero("123");
            Console.WriteLine($"Número convertido: {numero}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo un error: {ex.Message}");
        }
    }
}