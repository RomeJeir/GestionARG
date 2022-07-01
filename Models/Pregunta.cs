using System;

namespace GestionARG.Models
{
    public class Preguna
    {
        private int _IdPregunta;
        private string _Pregunta;
    

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