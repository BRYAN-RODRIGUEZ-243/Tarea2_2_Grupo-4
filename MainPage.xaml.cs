using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace Tarea2_2_Grupo_4
{
    public partial class MainPage : ContentPage
    {
        FirmaController firmaController;

        public MainPage()
        {
            InitializeComponent();

            // Ruta a la base de datos SQLite
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Firmas.db3");

            // Crear una instancia del controlador
            firmaController = new FirmaController(dbPath);
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var image = await drawingView.GetImageStream(200, 200);

            if (image != null)
            {
                // Obtener el nombre y la descripción de los Entry
                string nombre = nombreEntry.Text;
                string descripcion = descripcionEntry.Text;

                // Guardar la firma en la base de datos
                firmaController.InsertarFirma(nombre, descripcion, image);

                // Mostrar alerta de éxito
                await DisplayAlert("Éxito", "Firma guardada con éxito", "Aceptar");
            }
        }



        private void ListaBtn_Clicked(object sender, EventArgs e)
        {
            // Crear una instancia de la página FirmaListPage
            var firmaListPage = new FirmaListPage();

            // Navegar a la página FirmaListPage
            Navigation.PushAsync(firmaListPage);
        }

    }
}
