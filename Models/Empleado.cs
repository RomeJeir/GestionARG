using System;

namespace GestionARG.Models
{
    public class Empleado
    {
        private int _IdEmpleado;
        private int _DNI;
        private string _Nombre;
        private string _Direccion;
        private int _IdArea;
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
        public int IdArea{
            get{
                return _IdArea;
            }
            set{
                _IdArea=value;
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

                //(System.Int32 IdEmpleado, System.Int32 DNI, System.String Nombre, System.String Descripcion, System.String Direccion, System.Int32 IdJefe, System.Int32 IdArea)
        public Empleado (int idEmpleado, int dni, string nombre, string descripcion, string direccion, int idjefe, int idArea)
        {
            _IdEmpleado=idEmpleado;
            _DNI = dni;
            _Nombre = nombre;
            _Descripcion=descripcion;
            _Direccion=direccion;
            _IdJefe=idjefe;
            _IdArea=idArea;
        }

        public Empleado(){

        }
    }
}
    

