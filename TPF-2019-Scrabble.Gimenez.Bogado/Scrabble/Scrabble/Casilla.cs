using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    class Casilla
    {
        int valor, multiplicadorl,multiplicadorp,posX,posY;
        //string letra_marcada;
        Label labelCasilla;
        public int Valor { get => valor; set => valor = value; } //Valor de la letra
        public int MultiplicadorL { get => multiplicadorl; set => multiplicadorl = value; } //Multiplicador de Letra
        public int MultiplicadorP { get => multiplicadorp; set => multiplicadorp = value; } //Multiplicador de Palabra
        public Label LabelCasilla { get => labelCasilla; set => labelCasilla = value; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
    }  
}
