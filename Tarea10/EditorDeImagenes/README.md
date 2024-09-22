# 🖼️ Editor de Imágenes en WinForms

## 📋 Descripción del Proyecto
El proyecto "Editor de Imágenes" es una aplicación de Windows Forms diseñada para aplicar diversas transformaciones y efectos a imágenes. Permite a los usuarios cargar imágenes, aplicar filtros, redimensionar y rotar las imágenes, entre otras funcionalidades. Es una herramienta sencilla pero potente para realizar ediciones básicas de imágenes.

## 🔧 Funcionalidades
- **Cargar Imagen**: Permite al usuario cargar una imagen desde su computadora.
- **Aplicar Filtros**: Incluye filtros básicos como escala de grises, sepia y negativo.
- **Rotar Imagen**: Permite rotar la imagen cargada en 90, 180 o 270 grados.
- **Redimensionar Imagen**: Cambia el tamaño de la imagen según las dimensiones especificadas por el usuario.
- **Guardar Imagen Editada**: Guarda la imagen editada en el formato y ubicación deseados por el usuario.

## 🛠️ Implementación
### Interfaz de Usuario:
1. **Menú**:
   - `Abrir`: Permite cargar una imagen desde el explorador de archivos.
   - `Guardar`: Guarda la imagen editada.
   - `Salir`: Cierra la aplicación.
2. **Panel de Controles**:
   - `btnEscalaGrises`: Aplica el filtro de escala de grises.
   - `btnSepia`: Aplica el filtro sepia.
   - `btnNegativo`: Aplica el filtro negativo.
   - `btnRotar90`: Rota la imagen 90 grados.
   - `btnRotar180`: Rota la imagen 180 grados.
   - `btnRotar270`: Rota la imagen 270 grados.
   - `btnRedimensionar`: Permite redimensionar la imagen con dimensiones específicas.
3. **PictureBox**:
   - Muestra la imagen cargada y las ediciones aplicadas en tiempo real.

### Lógica de Edición:
- Los filtros se aplican manipulando los píxeles de la imagen cargada.
- Las rotaciones se realizan cambiando la orientación de los píxeles en el `PictureBox`.
- La redimensión se logra escalando la imagen según los valores ingresados por el usuario.

### Código de Ejemplo:
```csharp
private void btnEscalaGrises_Click(object sender, EventArgs e)
{
    if (imagenOriginal != null)
    {
        Bitmap bmp = new Bitmap(imagenOriginal);
        for (int i = 0; i < bmp.Width; i++)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                Color pixelColor = bmp.GetPixel(i, j);
                int escalaGris = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                Color newColor = Color.FromArgb(escalaGris, escalaGris, escalaGris);
                bmp.SetPixel(i, j, newColor);
            }
        }
        pictureBox.Image = bmp;
    }
}

private void btnRotar90_Click(object sender, EventArgs e)
{
    if (imagenOriginal != null)
    {
        imagenOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
        pictureBox.Image = imagenOriginal;
    }
}

private void btnRedimensionar_Click(object sender, EventArgs e)
{
    if (imagenOriginal != null)
    {
        int nuevoAncho = int.Parse(txtAncho.Text);
        int nuevoAlto = int.Parse(txtAlto.Text);
        Bitmap nuevaImagen = new Bitmap(imagenOriginal, new Size(nuevoAncho, nuevoAlto));
        pictureBox.Image = nuevaImagen;
    }
}
```
## 🚀 Cómo Ejecutar el Proyecto
1. Clona el repositorio en tu máquina local.
2. Abre el proyecto en Visual Studio.
3. Ejecuta la solución (F5) para iniciar la aplicación.
4. Utiliza el menú Abrir para cargar una imagen y aplicar las transformaciones desde el panel de controles.

## 📦 Requisitos
1. .NET Framework 4.7.2 o superior.
2. Visual Studio 2019 o superior.

---
**¡Empieza a editar y transformar tus imágenes con esta poderosa herramienta! 🖌️**