using SQLite;
using System.IO;

public class FirmaController
{
    SQLiteConnection database;

    public FirmaController(string dbPath)
    {
        database = new SQLiteConnection(dbPath);
        database.CreateTable<FirmaModel>();
    }

    public void InsertarFirma(string nombre, string descripcion, Stream imagenStream)
    {
        byte[] imagenBytes;
        using (MemoryStream ms = new MemoryStream())
        {
            imagenStream.CopyTo(ms);
            imagenBytes = ms.ToArray();
        }

        var firma = new FirmaModel
        {
            Nombre = nombre,
            Descripcion = descripcion,
            Imagen = imagenBytes
        };
        database.Insert(firma);
    }

    public FirmaModel ObtenerFirma(int id)
    {
        return database.Table<FirmaModel>().FirstOrDefault(x => x.Id == id);
    }
}
