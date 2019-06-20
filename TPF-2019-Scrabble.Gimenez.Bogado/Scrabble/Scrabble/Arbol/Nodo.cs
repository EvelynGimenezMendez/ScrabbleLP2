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

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Atributos <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        Informacion[,] informacion = new Informacion[15, 15]; //Matriz de tipo Informacion. Con ello se forma el tablero estado del juego
        Nodo nodoHijo;
        Nodo nodoHermano;

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Contructores <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public Nodo NodoHijo { get => nodoHijo; set => nodoHijo = value; }
        public Nodo NodoHermano { get => nodoHermano; set => nodoHermano = value; }
        public Informacion[,] Informacion { get => informacion; set => informacion = value; }

        public Nodo ()
        {
        }





        



        
    }
}
