using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    //Matriz tablero para la IA
    class Informacion
    {
        string letra;
        bool enabled; //Estado de la casilla
        int valor; //Valor de la letra asignada
        int puntaje, posY, posX, multiplicadorP, multiplicadorL; //Puntaje obtenido en la jugada

        public string Letra { get => letra; set => letra = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public int Valor { get => valor; set => valor = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
        public int MultiplicadorP { get => multiplicadorP; set => multiplicadorP = value; }
        public int MultiplicadorL { get => multiplicadorL; set => multiplicadorL = value; }
    }
}
