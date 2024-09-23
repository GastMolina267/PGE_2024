# 🧊 Conversión de Temperatura en WinForms
---

## 📋 Descripción del Proyecto
Esta aplicación de WinForms permite al usuario convertir una temperatura de grados Celsius a Fahrenheit. Proporciona una interfaz simple e intuitiva para ingresar la temperatura en Celsius y, con solo un clic, obtener el resultado en Fahrenheit.

## 🔧 Funcionalidades
- **Ingreso de Temperatura en Celsius**: Un campo de texto para que el usuario ingrese la temperatura que desea convertir.
- **Conversión a Fahrenheit**: Un botón que, al ser presionado, realiza la conversión de Celsius a Fahrenheit utilizando una fórmula matemática.
- **Visualización del Resultado**: Muestra la temperatura convertida en un `Label` de forma clara y legible.

## 🛠️ Implementación
### Interfaz de Usuario:
1. **TextBox**: Permite ingresar la temperatura en grados Celsius.
2. **Button**: Etiquetado como "Convertir", realiza la conversión cuando se presiona.
3. **Label**: Muestra el resultado de la conversión en grados Fahrenheit.

### Lógica de Conversión:
- Utiliza la fórmula de conversión: 
  \[
  F = \left(\frac{9}{5} \times C\right) + 32
  \]
  Donde:
  - `F` es la temperatura en Fahrenheit.
  - `C` es la temperatura en Celsius.

### Código de Ejemplo:
```csharp
private void btnConvertir_Click(object sender, EventArgs e)
{
    // Validar que el valor ingresado sea numérico
    if (double.TryParse(txtCelsius.Text, out double celsius))
    {
        // Convertir Celsius a Fahrenheit
        double fahrenheit = (celsius * 9 / 5) + 32;
        lblResultado.Text = $"Temperatura en Fahrenheit: {fahrenheit:F2}°F";
    }
    else
    {
        MessageBox.Show("Por favor, ingrese un valor numérico válido para la temperatura en Celsius.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```
## 🚀 Cómo Ejecutar el Proyecto
1. Clona el repositorio en tu máquina local.
2. Abre el proyecto en Visual Studio.
3. Ejecuta la solución (F5) para iniciar la aplicación.
4. Ingresa una temperatura en Celsius, haz clic en "Convertir" y observa el resultado en Fahrenheit.

## 📦 Requisitos
**.NET Framework 4.7.2 o superior.**
**Visual Studio 2019 o superior.**

---
✨ **Seguimos Programando!** ✨