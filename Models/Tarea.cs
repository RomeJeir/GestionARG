using System;

namespace GestionARG.Models
{
    public class Tarea
    {
        private int _IdTarea;
        private string _Nombre;
        private DateTime _FechaLimite;
        private DateTime _FechaCreacion;
        private string _Puntaje;
        private string _Descripcion;
        private int _IdEmpleado;

        public int IdTarea{
            get{
                return _IdTarea;
            }
            set{
                _IdTarea=value;
            }
        }
        public string Nombre{
            get{
                return _Nombre;
            }
            set{
                _Nombre=value;
            }
                }

         public DateTime FechaLimite{
            get{
                return _FechaLimite;
            }
            set{
                _FechaLimite=value;
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

        public string Puntaje{
            get{
                return _Puntaje;
            }
            set{
                _Puntaje=value;
            }
                }
        public string Descripcion{
            get{
                return _Descripcion;
            }
            set{
                _Descripcion=value;
            }
                }
        public Tarea (int IdTarea, string Nombre, DateTime FechaCreacion, DateTime FechaLimite, string Puntaje, string Descripcion, int IdEmpleado)
        {
            _IdTarea = IdTarea;
            _Nombre = Nombre;
            _FechaCreacion = FechaCreacion;
            _FechaLimite = FechaLimite;
            _Puntaje = Puntaje;
            _Descripcion = Descripcion;
            _IdEmpleado = IdEmpleado;
        }
    }
}