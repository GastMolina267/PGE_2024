# 💰 Registro de Gastos en WinForms

## 📋 Descripción del Proyecto
Este proyecto es una aplicación de Windows Forms que permite a los usuarios registrar sus gastos diarios y realizar la conversión de estos a distintas monedas. La aplicación facilita la administración financiera al ofrecer un registro claro de los gastos y la posibilidad de ver su equivalente en otras divisas.

## 🔧 Funcionalidades
- **Registro de Gastos**: Permite al usuario ingresar una descripción y el monto de un gasto.
- **Conversión de Moneda**: Convierte los gastos registrados a diferentes monedas seleccionadas.
- **Visualización de Gastos**: Muestra una lista detallada de todos los gastos registrados.
- **Calcular Total Convertido**: Calcula y muestra el total de los gastos en la moneda seleccionada.

## 🛠️ Implementación
### Interfaz de Usuario:
1. **TextBox**:
   - `txtDescripcion`: Para ingresar la descripción del gasto.
   - `txtValor`: Para ingresar el valor del gasto en la moneda local.
2. **ComboBox**:
   - `cbMoneda`: Para seleccionar la moneda a la cual se desea convertir los gastos (USD, EUR, MXN, etc.).
3. **Button**:
   - `btnAgregarGasto`: Agrega el gasto a la lista de gastos.
   - `btnConvertir`: Realiza la conversión de todos los gastos a la moneda seleccionada.
4. **DataGridView**:
   - `dgvGastos`: Muestra todos los gastos registrados, con la descripción y el valor.
5. **Label**:
   - `lblTotalConvertido`: Muestra el total de los gastos convertidos a la moneda seleccionada.

### Lógica de Conversión:
- El programa utiliza tasas de cambio predefinidas para convertir los gastos registrados a la moneda seleccionada.
- Cada gasto se convierte utilizando la fórmula:
  \[
  \text{Gasto Convertido} = \text{Gasto Original} \times \text{Tasa de Cambio}
  \]
  Donde la `Tasa de Cambio` depende de la moneda seleccionada.

### Código de Ejemplo:
```csharp
private void btnAgregarGasto_Click(object sender, EventArgs e)
{
    if (double.TryParse(txtValor.Text, out double valor) && !string.IsNullOrWhiteSpace(txtDescripcion.Text))
    {
        // Crear un nuevo objeto Gasto
        Gasto nuevoGasto = new Gasto
        {
            Descripcion = txtDescripcion.Text,
            Valor = valor,
            Moneda = "MXN" // Moneda local
        };

        // Agregar el gasto a la lista
        listaGastos.Add(nuevoGasto);

        // Actualizar el DataGridView
        dgvGastos.Rows.Add(nuevoGasto.Descripcion, nuevoGasto.Valor.ToString("F2"));

        // Limpiar los TextBox
        txtDescripcion.Clear();
        txtValor.Clear();
    }
    else
    {
        MessageBox.Show("Por favor, ingrese una descripción y un valor válido para el gasto.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

private void btnConvertir_Click(object sender, EventArgs e)
{
    string monedaSeleccionada = cbMoneda.SelectedItem.ToString();
    double tasaCambio = ObtenerTasaCambio(monedaSeleccionada);

    // Calcular el total de los gastos convertidos
    double totalConvertido = 0;
    foreach (var gasto in listaGastos)
    {
        totalConvertido += gasto.Valor * tasaCambio;
    }

    // Mostrar el total convertido
    lblTotalConvertido.Text = $"Total en {monedaSeleccionada}: {totalConvertido:F2}";
}

private double ObtenerTasaCambio(string moneda)
{
    // Tasas de cambio de ejemplo
    switch (moneda)
    {
        case "USD":
            return 0.05; // Ejemplo: 1 MXN = 0.05 USD
        case "EUR":
            return 0.04; // Ejemplo: 1 MXN = 0.04 EUR
        case "MXN":
        default:
            return 1.0; // Moneda local, sin conversión
    }
}
```

## 🚀 Cómo Ejecutar el Proyecto
1. Clona el repositorio en tu máquina local.
2. Abre el proyecto en Visual Studio.
3. Ejecuta la solución (F5) para iniciar la aplicación.
4. Ingresa una temperatura en Celsius, haz clic en "Convertir" y observa el resultado en Fahrenheit.

## 📦 Requisitos
1. **.NET Framework 4.7.2 o superior.**
2. **Visual Studio 2019 o superior.**

---
**¡Gestiona tus finanzas fácilmente con esta aplicación de Registro de Gastos! 💸**