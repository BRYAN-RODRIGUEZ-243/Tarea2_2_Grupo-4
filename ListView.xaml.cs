using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Tarea2_2_Grupo_4
{
    public partial class FirmaListPage : ContentPage
    {
        FirmaListController firmaListController;

        public FirmaListPage()
        {
            InitializeComponent();

            // Ruta a la base de datos SQLite
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Firmas.db3");

            // Crear una instancia del controlador de lista de firmas
            firmaListController = new FirmaListController(dbPath);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Obtener la lista de firmas
            List<FirmaListModel> firmas = firmaListController.ObtenerListaFirmas();

            // Asignar la lista de firmas al ListView
            firmasListView.ItemsSource = firmas;
        }
    }
}
