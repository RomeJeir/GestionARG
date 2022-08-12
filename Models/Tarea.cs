using System;
using System.ComponentModel;

namespace GestionARG.Models
{
    public class Tarea
    {
        [DisplayName("Nombre")]
        public string? nombre { get; set; }

        [DisplayName("Fecha Limite")]
        public DateTime fechaLimite { get; set; }

        [DisplayName("Fecha de Creacion")]
        public DateTime fechaCreacion { get; set; }

        [DisplayName("Puntaje")]
        public string? puntaje { get; set; }

        [DisplayName("Descr.")]
        public string? descripcion { get; set; }

        public int idEmpleado { get; set; }
    }
}