using System;

namespace GestionARG.Models
{
    public class Pregunta
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


    public string pregunta{
        get{
            return _Pregunta;
            }
        set{
            _Pregunta=value;
            }
        }
            
            public Pregunta(int idPregunta, string pregunta){
            _IdPregunta =IdPregunta;
            _Pregunta=pregunta;
            }

}
}