using System;

namespace GestionARG.Models
{
    public class Persona
    {
        private int _DNI;
        private string _Nombre;
        private string _Direccion;
        private string _Area;
        private string _Descripcion;
        private int _IdJefe;

        public int DNI{
            get{
                return _DNI;
            }
            set{
                _DNI=value;
            }
        }
        public string Direccion{
            get{
                return _Direccion;
            }
            set{
                _Direccion=value;
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
        public string Area{
            get{
                return _Area;
            }
            set{
                _Area=value;
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
        public int IdJefe{
            get{
                return _IdJefe;
            }
            set{
                _IdJefe=value;
            }
                }
        public Persona(int dni, string nombre, string area, string descripcion, string direccion, int idjefe)
        {
            _DNI = dni;
            _Nombre = Nombre;
            _Area=area;
            _Descripcion=descripcion;
            _Direccion=direccion;
            _IdJefe=idjefe;
        }
    }
}
    

