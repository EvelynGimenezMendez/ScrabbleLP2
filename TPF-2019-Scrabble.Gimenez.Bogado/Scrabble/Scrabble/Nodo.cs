﻿using System;
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
        public Informacion[,] Informacion { get => informacion; set => informacion = value; }

        public void Ver_nodo( )
        {
            Informacion[0, 0].Enabled = false;
        }
    }
}