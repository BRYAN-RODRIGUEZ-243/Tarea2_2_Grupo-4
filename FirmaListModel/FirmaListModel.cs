using System;

namespace Tarea2_2_Grupo_4
{
    public class FirmaListModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }

        // Constructor para inicializar la propiedad Descripcion
        public FirmaListModel()
        {
            Descripcion = ""; // O puedes asignar otro valor predeterminado que tenga sentido en tu aplicación
        }
    }
}

