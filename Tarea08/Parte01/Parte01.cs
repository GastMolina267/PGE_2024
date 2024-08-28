using System;
using System.IO;

public class FileManager
{
    public static string LeerArchivo(string ruta)
    {
        string contenido = "";
        using (StreamReader reader = new StreamReader(ruta))
        {
            contenido = reader.ReadToEnd();
        }
        return contenido;
    }

    public static void EscribirArchivo(string ruta, string contenido)
    {
        using (StreamWriter writer = new StreamWriter(ruta))
        {
            writer.Write(contenido);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Leer archivo");
            Console.WriteLine("2. Escribir archivo");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la ruta del archivo a leer: ");
                    string rutaLectura = Console.ReadLine();
                    try
                    {
                        string contenido = FileManager.LeerArchivo(rutaLectura);
                        Console.WriteLine("Contenido del archivo:");
                        Console.WriteLine(contenido);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                    }
                    break;

                case "2":
                    Console.Write("Ingrese la ruta del archivo a escribir: ");
                    string rutaEscritura = Console.ReadLine();
                    Console.Write("Ingrese el contenido a escribir: ");
                    string nuevoContenido = Console.ReadLine();
                    try
                    {
                        FileManager.EscribirArchivo(rutaEscritura, nuevoContenido);
                        Console.WriteLine("Archivo escrito exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al escribir el archivo: {ex.Message}");
                    }
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine();
        }
    }
}