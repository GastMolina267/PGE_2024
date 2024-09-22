# 📊 Visualización de Ventas Mensuales en WPF

## 📋 Descripción del Proyecto
Este proyecto es una aplicación de Windows Presentation Foundation (WPF) que permite visualizar los datos de ventas mensuales en un gráfico de barras. La aplicación proporciona una representación gráfica de las ventas de diferentes productos a lo largo del año, facilitando el análisis visual de los datos.

## 🔧 Funcionalidades
- **Visualización de Ventas por Producto**: Permite seleccionar diferentes productos y ver sus ventas mensuales representadas en un gráfico de barras.
- **Selección de Producto**: Un `ComboBox` permite seleccionar el producto para el cual se desean ver los datos de ventas.
- **Gráfico de Barras Dinámico**: Un gráfico de barras que se actualiza dinámicamente para mostrar las ventas del producto seleccionado.

## 🛠️ Implementación
### Interfaz de Usuario:
1. **ComboBox**:
   - `cbProductos`: Permite seleccionar entre diferentes productos (e.g., Producto A, Producto B) para visualizar sus datos de ventas.
2. **Button**:
   - `btnActualizar`: Actualiza el gráfico de ventas según el producto seleccionado.
3. **PlotView**:
   - `plotView`: Un control de la librería OxyPlot para mostrar el gráfico de barras con las ventas mensuales.

### Lógica de Visualización:
- El gráfico de barras muestra las ventas de cada mes en el eje X, con la cantidad de ventas en el eje Y.
- Al seleccionar un producto del `ComboBox` y presionar el botón "Actualizar", el gráfico se actualiza para mostrar los datos de ventas correspondientes.

### Código de Ejemplo:
```csharp
private void GenerarGrafico(string producto)
{
    plotModel.Series.Clear();

    // Datos de ventas ficticios por mes
    var ventasMensuales = ObtenerDatosVentas(producto);

    // Crear una serie de columnas (gráfico de barras)
    var barSeries = new ColumnSeries
    {
        Title = producto,
        FillColor = OxyColors.Blue
    };

    // Agregar datos de ventas a la serie
    foreach (var venta in ventasMensuales)
    {
        barSeries.Items.Add(new ColumnItem(venta));
    }

    // Agregar la serie al modelo de gráfico
    plotModel.Series.Add(barSeries);

    // Actualizar el gráfico
    plotView.InvalidatePlot(true);
}

private List<double> ObtenerDatosVentas(string producto)
{
    // Datos ficticios de ventas mensuales
    if (producto == "Producto A")
    {
        return new List<double> { 150, 180, 120, 140, 200, 220, 210, 190, 170, 160, 180, 200 };
    }
    else if (producto == "Producto B")
    {
        return new List<double> { 130, 160, 110, 130, 190, 210, 220, 180, 160, 140, 170, 190 };
    }

    return new List<double>();
}
```
## 🚀 Cómo Ejecutar el Proyecto
1. Clona el repositorio en tu máquina local.
2. Abre el proyecto en Visual Studio.
3. Asegúrate de tener instalada la librería OxyPlot.Wpf.
4. Ejecuta la solución (F5) para iniciar la aplicación.
5. Selecciona un producto del ComboBox y presiona "Actualizar" para ver el gráfico de ventas.

## 📦 Requisitos
1. .NET Core 3.1 o superior.
2. Visual Studio 2019 o superior.
3. Librería OxyPlot.Wpf instalada (se puede agregar usando NuGet).

**¡Visualiza y analiza fácilmente las ventas mensuales con esta aplicación en WPF! 📈**