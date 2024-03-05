using SQLite;

public class FirmaController
{
    SQLiteConnection database;

    public FirmaController(string dbPath)
    {
        database = new SQLiteConnection(dbPath);
        database.CreateTable<FirmaModel>();
    }

    public void InsertarFirma(string nombre, string descripcion, byte[] imagen)
    {
        var firma = new FirmaModel
        {
            Nombre = nombre,
            Descripcion = descripcion,
            Imagen = imagen
        };
        database.Insert(firma);
    }

    public FirmaModel ObtenerFirma(int id)
    {
        return database.Table<FirmaModel>().FirstOrDefault(x => x.Id == id);
    }
}
