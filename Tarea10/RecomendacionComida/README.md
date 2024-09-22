# 🍔 Proyecto de Recomendación de Comida en WPF

## 📋 Descripción del Proyecto
Esta aplicación de Windows Presentation Foundation (WPF) permite a los usuarios explorar y calificar diferentes productos de comida rápida. La aplicación ofrece un sistema de recomendación intuitivo, donde los usuarios pueden ver categorías de productos, seleccionar alimentos, ver detalles e imágenes, y calificar los productos utilizando un sistema de estrellas.

## 🔧 Funcionalidades
- **Exploración de Categorías de Comida**: Los usuarios pueden explorar varias categorías como Burgers, Pizza, French Fries, Chinese y Drinks.
- **Visualización de Productos**: Muestra una lista de productos disponibles en la categoría seleccionada.
- **Detalles del Producto**: Muestra la imagen, descripción y calificación promedio del producto seleccionado.
- **Sistema de Calificación con Estrellas**: Permite a los usuarios calificar productos seleccionando de 1 a 5 estrellas. Las estrellas no seleccionadas se mostrarán en negro para una mejor visualización.
- **Cálculo de Calificación Promedio**: Calcula el promedio de calificaciones basado en la cantidad de críticas realizadas.

## 🛠️ Implementación
### Interfaz de Usuario:
1. **ListBox**:
   - `lbCategorias`: Muestra las categorías de comida (Burgers, Pizza, etc.).
   - `lbProductos`: Muestra los productos disponibles para la categoría seleccionada.
2. **StackPanel**:
   - `spDetallesProducto`: Muestra la imagen, nombre y descripción del producto seleccionado.
   - `btnStar1` a `btnStar5`: Botones que representan las estrellas para calificar.
3. **Button**:
   - `btnCalificar`: Al hacer clic, registra la calificación seleccionada.
4. **TextBlock**:
   - `txtCalificacionPromedio`: Muestra la calificación promedio del producto.
   - `txtCantidadCriticas`: Muestra la cantidad de críticas recibidas.

### Lógica de Calificación:
- Los botones de estrellas permiten al usuario seleccionar una calificación. Las estrellas seleccionadas se muestran como llenas, mientras que las posteriores a la calificación se muestran como negras.
- Al hacer clic en "Calificar", la calificación se registra y se recalcula el promedio.

### Código de Ejemplo:
```csharp
private void Star_Click(object sender, RoutedEventArgs e)
{
    if (sender is Button botonEstrella)
    {
        calificacionTemporal = Convert.ToInt32(botonEstrella.Tag);
        ActualizarEstrellas(calificacionTemporal);
    }
}

private void ActualizarEstrellas(int calificacion)
{
    // Establecer las estrellas llenas hasta la calificación asignada
    for (int i = 1; i <= calificacion; i++)
    {
        Button botonEstrella = (Button)FindName($"btnStar{i}");
        if (botonEstrella != null)
        {
            botonEstrella.Content = new Image { Source = new BitmapImage(new Uri(starFilled, UriKind.Relative)) };
        }
    }

    // Establecer las estrellas negras para las restantes
    for (int i = calificacion + 1; i <= 5; i++)
    {
        Button botonEstrella = (Button)FindName($"btnStar{i}");
        if (botonEstrella != null)
        {
            botonEstrella.Content = new Image { Source = new BitmapImage(new Uri(starBlack, UriKind.Relative)) };
        }
    }
}

private void btnCalificar_Click(object sender, RoutedEventArgs e)
{
    if (lbProductos.SelectedItem is Producto productoSeleccionado)
    {
        // Agregar la calificación temporal al producto seleccionado
        productoSeleccionado.AgregarCalificacion(calificacionTemporal);

        // Mostrar la calificación actualizada y el número de críticas
        txtCalificacionPromedio.Text = $"Calificación Promedio: {productoSeleccionado.PromedioCalificaciones():F1}";
        txtCantidadCriticas.Text = $"Número de Críticas: {productoSeleccionado.CantidadCriticas}";

        // Mostrar mensaje de confirmación
        MessageBox.Show($"Gracias por calificar este producto con {calificacionTemporal} estrellas.", "Calificación");
    }
}
```
## 🚀 Cómo Ejecutar el Proyecto
1. Clona el repositorio en tu máquina local.
2. Abre el proyecto en Visual Studio.
3. Asegúrate de que las imágenes de productos y estrellas están correctamente referenciadas en la carpeta Img.
4. Ejecuta la solución (F5) para iniciar la aplicación.
5. Explora las diferentes categorías, selecciona un producto y califícalo usando el sistema de estrellas.

## 📦 Requisitos
1. .NET Core 3.1 o superior.
2. Visual Studio 2019 o superior.
3. Imágenes de productos y estrellas colocadas en la carpeta Img del proyecto.

---
**¡Explora y califica tus comidas favoritas con esta aplicación de Recomendación de Comida en WPF! 🍕🍟🥤**