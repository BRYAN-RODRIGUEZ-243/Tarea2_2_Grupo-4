using System.Collections.Generic;
using System.Linq;
using SQLite;
using Tarea2_2_Grupo_4;

public class FirmaListController
{
    SQLiteConnection database;

    public FirmaListController(string dbPath)
    {
        database = new SQLiteConnection(dbPath);
        database.CreateTable<FirmaModel>(); // Asumiendo que FirmaModel es la clase para las firmas individuales
    }

    public List<FirmaListModel> ObtenerListaFirmas()
    {
        return database.Table<FirmaModel>().Select(f => new FirmaListModel
        {
            Id = f.Id,
            Nombre = f.Nombre,
            Descripcion = f.Descripcion,
            Imagen = f.Imagen // Obtener también la imagen de la base de datos
        }).ToList();
    }
}
