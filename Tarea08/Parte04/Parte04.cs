using System;
using System.IO;

namespace ConsoleApp
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private string _logFilePath;

        private Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public static Logger GetInstance(string logFilePath = "ejemplo.txt")
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger(logFilePath);
                    }
                }
            }
            return _instance;
        }

        public void Log(string message, string severity = "Info")
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} [{severity}] {message}");
            }
        }

        public void Info(string message) => Log(message, "Info");
        public void Warning(string message) => Log(message, "Warning");
        public void Error(string message) => Log(message, "Error");
    }
}

namespace ConsoleApp
{
    class Program
    {
        static Logger logger = Logger.GetInstance();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Operaciones de Archivos");
                Console.WriteLine("2. Calculadora");
                Console.WriteLine("3. Salir");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FileOperations();
                        break;
                    case "2":
                        CalculatorOperations();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        break;
                }
            }
        }

        static void FileOperations()
        {
            try
            {
                Console.WriteLine("Operaciones de archivo seleccionadas.");

                string filePath = "archivoEjemplo.txt";

                // Crear o escribir en un archivo
                File.WriteAllText(filePath, "Este es un ejemplo de texto escrito en el archivo.");

                // Leer y mostrar el contenido del archivo
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Contenido del archivo:");
                Console.WriteLine(content);

                logger.Info("Operaciones de archivo realizadas con éxito.");
            }
            catch (Exception ex)
            {
                logger.Error($"Ocurrió un error en las operaciones de archivo: {ex.Message}");
                Console.WriteLine("Ocurrió un error en las operaciones de archivo.");
            }
        }

        static void CalculatorOperations()
        {
            try
            {
                Console.WriteLine("Calculadora seleccionada.");

                // Solicitar entrada de números
                Console.Write("Ingrese el primer número: ");
                double num1 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese el segundo número: ");
                double num2 = double.Parse(Console.ReadLine());

                // Evaluar división por cero
                if (num2 == 0)
                {
                    throw new DivideByZeroException(); // Lanza una excepción si el divisor es cero
                }

                // Realizar la división
                double result = num1 / num2;

                // Mostrar el resultado
                Console.WriteLine($"{num1} / {num2} = {result}");

                // Registrar el éxito en el log
                logger.Info("Operación de cálculo realizada con éxito.");
            }
            catch (DivideByZeroException ex)
            {
                logger.Error("Intento de división por cero.");
                Console.WriteLine("Error: No se puede dividir por cero.");
            }
            catch (FormatException ex)
            {
                logger.Error($"Error de formato: {ex.Message}");
                Console.WriteLine("Error: Entrada inválida. Asegúrese de ingresar números válidos.");
            }
            catch (Exception ex)
            {
                logger.Error($"Ocurrió un error en la calculadora: {ex.Message}");
                Console.WriteLine("Ocurrió un error en la calculadora.");
            }
        }


    }
}
