using System;

namespace GestionARG.Models
{
    public class Formulario
    {
        private int _IdFormulario;
        private int _IdEmpleado;
        private DateTime _FechaCreacion;


    public int IdFormulario{
        get{
            return _IdFormulario;
            }set{
            _IdFormulario=value;
            }
        }

    public int IdEmpleado{
        get{
            return _IdEmpleado;
            }
        set{
            _IdEmpleado=value;
            }
        }

    public DateTime FechaCreacion{
        get{
            return _FechaCreacion;
            }
        set{
            _FechaCreacion=value;
            }
        }
}
}