using System;
using System.ComponentModel;

namespace GestionARG.Models
{
    public class TareaHecha
    {
        [DisplayName("Nombre")]
        public string? nombre { get; set; }

        [DisplayName("Fecha de Creacion")]
        public DateTime fechaCreacion { get; set; }

        [DisplayName("Puntaje")]
        public string puntaje { get; set; }

        [DisplayName("Descr.")]
        public string? descripcion { get; set; }

        public int idEmpleado { get; set; }

        public int idTarea { get; set; }

        public int idTareaRealizada { get; set; }

        public int idArea { get; set; }
    }
    
}