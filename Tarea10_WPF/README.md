# 🧮 Calculadora WPF

## Descripción del Proyecto

Este proyecto consiste en la implementación de una calculadora sencilla utilizando **Windows Presentation Foundation (WPF)** en C#. La calculadora permite realizar operaciones básicas como suma, resta, multiplicación y división, con una interfaz gráfica moderna y personalizable.

![Captura de Pantalla](./screenshots/calculadora.png)

## ¿Qué es WPF?

**Windows Presentation Foundation (WPF)** es una tecnología de Microsoft utilizada para desarrollar aplicaciones de escritorio en el entorno .NET. WPF permite crear interfaces de usuario avanzadas y personalizadas, combinando el uso de XAML para el diseño de la interfaz y C# para la lógica de la aplicación.

### Diferencias entre WPF y Windows Forms

| Característica                 | WPF                                   | Windows Forms                      |
|--------------------------------|---------------------------------------|------------------------------------|
| **Interfaz de Usuario**        | Uso de XAML para definir UI           | Basado en controles .NET estándar  |
| **Estilo y Personalización**   | Altamente personalizable con Styles y Templates | Personalización limitada          |
| **Gráficos**                   | Soporte avanzado de gráficos 2D y 3D  | Limitado a gráficos 2D             |
| **Enlace de Datos (Data Binding)** | Soporte robusto y flexible           | Más limitado y menos intuitivo     |
| **Rendimiento**                | Mejor manejo de renderizado, ideal para interfaces complejas | Menos eficiente en interfaces complejas |
| **Facilidad de Uso**           | Curva de aprendizaje más pronunciada  | Más fácil de aprender y usar       |

### Ventajas de WPF

- **Interfaz Avanzada**: Permite crear interfaces gráficas atractivas y modernas con el uso de animaciones y gráficos avanzados.
- **Flexibilidad**: La separación entre diseño (XAML) y lógica (C#) facilita el desarrollo y mantenimiento de la aplicación.
- **Soporte para Gráficos**: WPF ofrece soporte nativo para gráficos 2D y 3D, ideal para aplicaciones visualmente intensivas.
- **Enlace de Datos**: El sistema de Data Binding de WPF permite enlazar la UI con datos de forma simple y eficiente.

### Desventajas de WPF

- **Curva de Aprendizaje**: La combinación de XAML y C# puede ser compleja al inicio para desarrolladores acostumbrados a Windows Forms.
- **Requiere .NET Framework**: Las aplicaciones WPF dependen del .NET Framework, lo que puede limitar su compatibilidad en algunos sistemas.
- **Rendimiento en Aplicaciones Simples**: Para aplicaciones muy simples, el uso de WPF puede ser excesivo en comparación con Windows Forms.

## Funcionalidades de la Calculadora

- Realiza operaciones básicas: suma, resta, multiplicación y división.
- Interfaz gráfica moderna con botones estilizados y barra de visualización.
- Manejo de errores básicos, como la división por cero.
- Botón de "Limpiar" para resetear la calculadora.

## Implementación

### Requisitos Previos

- Visual Studio 2022 (o superior)
- .NET Framework 4.8 (o superior)

### Estructura del Proyecto

CalculadoraWPF/ ├── CalculadoraWPF.sln # Solución de Visual Studio ├── MainWindow.xaml # Diseño de la interfaz (XAML) ├── MainWindow.xaml.cs # Lógica de la calculadora (C#) ├── Assets/ # Recursos como iconos y capturas └── README.md # Este archivo

### Código Principal (MainWindow.xaml.cs)

```csharp
using System.Windows;

namespace CalculadoraWPF
{
    public partial class MainWindow : Window
    {
        private double _currentValue = 0;
        private double _storedValue = 0;
        private string _operation = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el clic de botones numéricos
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar las operaciones aritméticas
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para calcular el resultado
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para limpiar la calculadora
        }
    }
}

Contribuciones
¡Las contribuciones son bienvenidas! Si deseas mejorar la calculadora o agregar nuevas funcionalidades, no dudes en hacer un fork del proyecto y enviar un pull request.