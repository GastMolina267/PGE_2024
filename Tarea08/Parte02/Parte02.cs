using System;
using System.IO;

public class FileManager
{
    public static void WriteToFile(string filePath, string content)
    {
        try
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine("Contenido escrito exitosamente.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: No tienes permisos para escribir en este archivo. Detalles: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error de E/S al escribir el archivo. Detalles: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al escribir el archivo. Detalles: {ex.Message}");
        }
    }

    public static string ReadFromFile(string filePath)
    {
        try
        {
            string content = File.ReadAllText(filePath);
            return content;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: El archivo no se encuentra. Detalles: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: No tienes permisos para leer este archivo. Detalles: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error de E/S al leer el archivo. Detalles: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado al leer el archivo. Detalles: {ex.Message}");
        }
        return null;
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Ingrese la ruta del archivo: ");
            string filePath = Console.ReadLine();

            Console.Write("¿Desea leer (R) o escribir (W) en el archivo? ");
            string operation = Console.ReadLine().ToUpper();

            if (operation == "W")
            {
                Console.Write("Ingrese el contenido a escribir: ");
                string content = Console.ReadLine();
                WriteToFile(filePath, content);
            }
            else if (operation == "R")
            {
                string fileContent = ReadFromFile(filePath);
                if (fileContent != null)
                {
                    Console.WriteLine("Contenido del archivo:");
                    Console.WriteLine(fileContent);
                }
            }
            else
            {
                Console.WriteLine("Operación no válida.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado en el programa principal. Detalles: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Programa finalizado.");
        }
    }
}