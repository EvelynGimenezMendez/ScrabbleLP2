using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    class Nodo
    {
        Informacion[,] informacion = new Informacion[15, 15]; //Matriz de tipo Informacion. Con ello se forma el tablero estado del juego
        Nodo hijo; //Nodo hijo del nodo creado
        Nodo hermano; //Nodo hermano del nodo creado

        public Nodo Hijo { get => hijo; set => hijo = value; }
        public Nodo Hermano { get => hermano; set => hermano = value; }
        public Informacion[,] Informacion { get => informacion; set => informacion = value; }

        //Por defecto hijos y hermanos son null
        public Nodo ()
        {
            Hijo = null;
            Hermano = null;
        }  
    }
}
