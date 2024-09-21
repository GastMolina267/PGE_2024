# 🎨 Dibujo Libre en WPF

## 📋 Descripción del Proyecto
Este proyecto es una aplicación de Windows Presentation Foundation (WPF) que permite a los usuarios realizar dibujos libres sobre un lienzo. La aplicación simula un lienzo digital donde el usuario puede dibujar con el mouse, permitiendo crear ilustraciones de forma sencilla.

## 🔧 Funcionalidades
- **Dibujo con el Mouse**: Permite dibujar líneas en el lienzo mientras se mantiene presionado el botón izquierdo del mouse.
- **Limpieza del Lienzo**: Opción para limpiar el lienzo y comenzar un nuevo dibujo.
- **Cambio de Color y Grosor**: Posibilidad de cambiar el color y el grosor del pincel (opcional, si se implementa).

## 🛠️ Implementación
### Interfaz de Usuario:
1. **Canvas**: Control principal donde el usuario puede dibujar.
2. **Eventos del Mouse**: 
   - `MouseDown`: Inicia el dibujo en el lienzo.
   - `MouseMove`: Dibuja mientras se mueve el mouse con el botón presionado.
   - `MouseUp`: Termina el dibujo.

### Lógica de Dibujo:
- Se utiliza el evento `MouseMove` para capturar la posición del mouse y dibujar líneas entre la posición actual y la anterior.
- La posición inicial se captura en el evento `MouseDown` y se actualiza cada vez que se dibuja.

### Código de Ejemplo:
```csharp
private bool isDrawing = false;
private Point previousPoint;

private void DibujoCanvas_MouseDown(object sender, MouseButtonEventArgs e)
{
    // Comenzar el dibujo
    isDrawing = true;
    previousPoint = e.GetPosition(DibujoCanvas);
}

private void DibujoCanvas_MouseMove(object sender, MouseEventArgs e)
{
    if (isDrawing)
    {
        // Obtener la posición actual del mouse
        Point currentPoint = e.GetPosition(DibujoCanvas);

        // Crear una línea que conecte el punto anterior con el actual
        Line line = new Line
        {
            Stroke = Brushes.Black,  // Color de la línea
            StrokeThickness = 2,     // Grosor de la línea
            X1 = previousPoint.X,
            Y1 = previousPoint.Y,
            X2 = currentPoint.X,
            Y2 = currentPoint.Y
        };

        // Agregar la línea al Canvas
        DibujoCanvas.Children.Add(line);

        // Actualizar el punto anterior
        previousPoint = currentPoint;
    }
}

private void DibujoCanvas_MouseUp(object sender, MouseButtonEventArgs e)
{
    // Finalizar el dibujo
    isDrawing = false;
}
```

## 🚀 Cómo Ejecutar el Proyecto
1. Clona el repositorio en tu máquina local.
2. Abre el proyecto en Visual Studio.
3. Ejecuta la solución (F5) para iniciar la aplicación.
4. Usa el mouse para dibujar en el lienzo.

## 📦 Requisitos
**.NET Core 3.1 o superior.**
**Visual Studio 2019 o superior.**

---
**¡Diviértete creando tus dibujos en esta aplicación de Dibujo Libre! 🎨** 