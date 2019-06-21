using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class IA
    {
        Arbol arbol;
        string[] vector_atril;
        EstadoTablero estadoTablero;
        LetrasPalabras letrasPalabras;
        public LetrasPalabras LetrasPalabras{ get => letrasPalabras; set => letrasPalabras = value; }
        public EstadoTablero EstadoTablero { get => estadoTablero; set => estadoTablero = value; }
        public string[] Vector_atril { get => vector_atril; set => vector_atril = value; }
        public Arbol Arbol { get=>arbol; set=>arbol=value; }

        public void Cargar_atril() //Se carga el atril de la IA 
        {
            int i;
            for (i = 0; i < 7; i++)
                if (vector_atril[i] == "")
                    vector_atril[i] = letrasPalabras.Cargar_letras(Environment.TickCount + i); //A cada semilla le sumamos el siguiente indice para no obtener letras iguales                      
        }

        public int Verificar_vertical(int fila, int columna)
        {
            string formar_palabra_vertical = "";
            while (fila >= 0 && estadoTablero.Casilla_matriz[fila, columna].LabelCasilla.Text != "")
                fila--;
            fila++;
            while (fila < 15 && estadoTablero.Casilla_matriz[fila, columna].LabelCasilla.Text != "")
            {
                formar_palabra_vertical = formar_palabra_vertical + estadoTablero.Casilla_matriz[fila, columna].LabelCasilla.Text;
                fila++;
            }
            fila--;
            if (letrasPalabras.Consultar_palabra(formar_palabra_vertical.ToLower()) == 1)
                return 1;
            else return 0;   
        } 
    }
}
