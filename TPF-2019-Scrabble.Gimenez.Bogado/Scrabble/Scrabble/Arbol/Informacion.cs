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
        string letra, tag; //Multiplicadores
        bool enabled; //Estado de la casilla
        int valor; //Valor de la letra asignada
        int puntaje; //Puntaje obtenido en la jugada

        public string Letra { get => letra; set => letra = value; }
        public string Tag { get => tag; set => tag = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public int Valor { get => valor; set => valor = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
    }
}
