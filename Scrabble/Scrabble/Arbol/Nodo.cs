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
        int direccion = -1; 
        string palabra = "";
        string palabraPadre = "";
        bool hijoVerificado = false;
        int inicio_i_padre = 0;
        int inicio_j_padre = 0;
        int puntaje = 0;


        public Nodo Hijo { get => hijo; set => hijo = value; }
        public Nodo Hermano { get => hermano; set => hermano = value; }
        public Informacion[,] Informacion { get => informacion; set => informacion = value; }
        public string Palabra { get => palabra; set => palabra = value; }
        public int Direccion { get => direccion; set => direccion = value; }
        public string PalabraPadre { get => palabraPadre; set => palabraPadre = value; }
        public int Inicio_i_padre { get => inicio_i_padre; set => inicio_i_padre = value; }
        public int Inicio_j_padre { get => inicio_j_padre; set => inicio_j_padre = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public bool HijoVerificado { get => hijoVerificado; set => hijoVerificado = value; }


        //Por defecto hijos y hermanos son null
        public Nodo ()
        {
            Hijo = null;
            Hermano = null;
        }  
    }
}
