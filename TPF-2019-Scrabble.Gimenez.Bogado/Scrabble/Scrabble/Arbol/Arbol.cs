using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class Arbol
    {
        EstadoTablero estadoTablero;
        Nodo raiz;
        Nodo aux;



        public EstadoTablero EstadoTablero { get => estadoTablero; set => estadoTablero = value; }
        public Nodo Raiz { get => raiz; set => raiz = value; }
        public Nodo Aux { get => aux; set => aux = value; }
        public Arbol()
        {
            raiz = new Nodo();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    raiz.Informacion[i, j] = new Informacion
                    {

                        Letra = estadoTablero.Casilla_matriz[i, j].LabelCasilla.Text,
                        Tag = Convert.ToString(estadoTablero.Casilla_matriz[i, j].LabelCasilla.Tag),
                        Valor = estadoTablero.Casilla_matriz[i, j].Valor,
                        Enabled = estadoTablero.Casilla_matriz[i, j].LabelCasilla.Enabled
                    };
           
                }
            }
        }


        public Nodo Insertar(Informacion[,] info, Nodo pNodo)
        {
            //Si no hay donde insertar se toma como si fuera la raiz
            if (pNodo == null)
            {
                raiz = new Nodo();
                raiz.Informacion = info;

                //No hay hijo 
                raiz.NodoHijo = null;
                //No hay hermano
                raiz.NodoHermano = null;

                return raiz;
            }
            //Verificamos si no tiene hijo
            //Insertamos el dato como hijo
            if (pNodo.NodoHijo == null)
            {
                Nodo temp = new Nodo();
                temp.Informacion = info;
                //Conectamos el nuevo nodo como hijo
                pNodo.NodoHijo = temp;
                return temp;
            }
            else //Ya tiene un hijo, tenemos que insertarlo como hermano
            {
                aux = pNodo.NodoHijo;
                //Avanzamos hasta el ultimo hermano
                while (aux.NodoHermano!= null)
                {
                    aux = aux.NodoHermano;
                }
                //Creamos nodo temporal
                Nodo temp = new Nodo();
                temp.Informacion = info; ;

                //Unimos el temp al ultimo hermano
                aux.NodoHermano= temp;
                return temp;
            }
        }
    }
}
