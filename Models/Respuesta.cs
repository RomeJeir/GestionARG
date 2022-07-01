using System;

namespace GestionARG.Models
{
    public class Respuesta
    {
        private int _IdRespuesta;
        private string _Respuesta;
        private string _IdPregunta;
    

    public int IdPregunta{
        get{
            return _IdPregunta;
            }
        set{
            _IdPregunta=value;
        }
        }

    public int Pregunta{
        get{
            return _DNI;
            }
        set{
            _DNI=value;
            }
        }
}
}
