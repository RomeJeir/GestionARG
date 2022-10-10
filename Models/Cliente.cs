using System;

namespace GestionARG.Models
{
    public class Cliente
    {
        private int _IdCliente;
        private string _Nombre;

        private string _Email;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public Cliente(int idCliente, string nombre, string email)
        {
            _IdCliente = idCliente;
            _Nombre = nombre;
            _Email = email;
        }

        public Cliente()
        {

        }
    }
}
