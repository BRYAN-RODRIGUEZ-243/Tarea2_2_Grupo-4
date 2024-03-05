using SQLite;

public class FirmaModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public byte[] Imagen { get; set; }

    public FirmaModel()
    {
        Descripcion = ""; // Inicializa la propiedad Descripcion con una cadena vacía

        // Asignar los bytes de la imagen adecuadamente
       
    }

  
}
