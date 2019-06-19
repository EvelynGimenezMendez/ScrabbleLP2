using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class Informacion
    {
        string letra, tag;
        bool enabled;
        int valor;

        public string Letra { get => letra; set => letra = value; }
        public string Tag { get => tag; set => tag = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public int Valor { get => valor; set => valor = value; }
    }
}
