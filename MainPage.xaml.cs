using System.IO;

namespace Tarea2_2_Grupo_4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var image = await drawingView.GetImageStream(200, 200);

            if (image != null)
            {
                // Convertir la imagen en un arreglo de bytes en formato PNG
                byte[] bytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    ((Stream)image).CopyTo(ms);
                    bytes = ms.ToArray();
                }

                string folderPath = "/storage/emulated/0";

                // Asegúrate de que la carpeta exista, si no existe, créala
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Construir la ruta completa del archivo
                var filename = Path.Combine(folderPath, "drawing.png");
                File.WriteAllBytes(filename, bytes);

                await DisplayAlert("Guardado", "El dibujo ha sido guardado en el dispositivo.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar el dibujo.", "OK");
            }
        }
        
    }
}
