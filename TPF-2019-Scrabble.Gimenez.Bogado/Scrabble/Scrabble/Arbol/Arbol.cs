using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class Arbol
    {
        Nodo raiz; //Nodo raiz del arbol. Recibe el estado actual del tablero al comenzar el turno
        Nodo aux; //Nodo auxiliar para trabajar dentro del arbol
        int i = 0;

        public Nodo Raiz { get => raiz; set => raiz = value; }
        public Nodo Aux { get => aux; set => aux = value; }

        public Arbol()
        {
            raiz = new Nodo(); //Se crea una raiz
        }
        //Funcion para insertar un nodo al arbol
        public Nodo Insertar(Informacion[,] Info, string palabra, Nodo NuevoNodo)
        {
            //Si no hay nada en el nodo, es el primero y se inserta como la raiz
            if (NuevoNodo == null)
            {
                raiz = new Nodo();
                raiz.Informacion = Info; //Se le pasa el tablero actual
                raiz.Hijo = null; //Aun no tiene hijos 
                raiz.Hermano = null; //Aun no tiene hermanos
                return raiz; //Retornamos la raiz creada
            }
            //Si el nodo no era null, verificamos si insertarlo como hijo o como hermano. 
            if (NuevoNodo.Hijo == null) //Si no tenia ningun nodo hijo, lo insertarmos como hijo.
            {
                Nodo temp = new Nodo(); //Nodo temporal para conectar
                temp.Informacion = Info; //Le asignamos un tablero para la jugada
                NuevoNodo.Hijo = temp; //Asignamos el nuevo nodo como hijo
                return temp; //Retornamos el nodo creado
            }
            else //Si ya tiene un hijo, tenemos que insertarlo como hermano
            {
                aux = NuevoNodo.Hijo; //Usamos el nodo auxiliar para pasar por todos los nodos hermanos
                while (aux.Hermano!= null)  //Avanzamos hasta el ultimo hermano
                {
                    aux = aux.Hermano;
                }
                Nodo temp = new Nodo(); //Nodo temporal para conectar
                temp.Informacion = Info; //Le asignamos un tablero para la jugada
                aux.Hermano= temp; //Asignamos el nodo como hermano del ultimo hijo del nodo padre
                return temp; //Retornamos el nodo creado
            }
        }
        public void Procesar_arbol(Nodo NuevoNodo) //Se trabaja con el arbol de forma descendente, desde la raiz hasta las hojas
        {
            if (NuevoNodo == null) //Caso base. Si el nodo recibido es null, terminamos el proceso, no hay acciones a realizar. 
                return;
           
            //Trabajamos con el nodo
            for (int n = 0; n < i; n++)
            //SE HACE EL PROCESO QUE SE QUIERA (VERIFICACION, LETRAS, ETC) LLAMADA A LA IA.

            //Si tiene hijo trabajamos con el hijo
            if (NuevoNodo.Hijo != null)
            {
                i++;
                Procesar_arbol(NuevoNodo.Hijo);
                i--;
            }
            //Si tiene hermanos trabajamos con ellos
            if (NuevoNodo.Hermano != null)
                Procesar_arbol(NuevoNodo.Hermano);
        }
    }
}
