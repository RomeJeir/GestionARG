using System;

namespace GestionARG.Models
{
    public class Respuesta
    {
        private int _IdRespuesta;
        private int _Respuesta;
        private int _IdPregunta;


        public int IdRespuesta
        {
            get
            {
                return _IdRespuesta;
            }
            set
            {
                _IdRespuesta = value;
            }
        }

        public int respuesta
        {
            get
            {
                return _Respuesta;
            }
            set
            {
                _Respuesta = value;
            }
        }

        public int IdPregunta
        {
            get
            {
                return _IdPregunta;
            }
            set
            {
                _IdPregunta = value;
            }
        }
    }
}
