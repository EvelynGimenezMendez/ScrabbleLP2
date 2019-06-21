using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class Arbol
    {
        Nodo raiz;
        Nodo aux;

        public Nodo Raiz { get => raiz; set => raiz = value; }
        public Nodo Aux { get => aux; set => aux = value; }

        public Arbol()
        {
            raiz = new Nodo();
        }

        public Nodo Insertar(Informacion[,] Info, string palabra, Nodo pNodo)
        {
            //Si no hay donde insertar se toma como si fuera la raiz
            if (pNodo == null)
            {
                raiz = new Nodo();
                raiz.Informacion = Info;
                //No hay hijo 
                raiz.Hijo = null;
                //No hay hermano
                raiz.Hermano = null;

                return raiz;
            }
            //Verificamos si no tiene hijo
            //Insertamos el dato como hijo
            if (pNodo.Hijo == null)
            {
                Nodo temp = new Nodo();
                temp.Informacion = Info;
                //Conectamos el nuevo nodo como hijo
                pNodo.Hijo = temp;
                return temp;
            }
            else //Ya tiene un hijo, tenemos que insertarlo como hermano
            {
                aux = pNodo.Hijo;
                //Avanzamos hasta el ultimo hermano
                while (aux.Hermano!= null)
                {
                    aux = aux.Hermano;
                }
                //Creamos nodo temporal
                Nodo temp = new Nodo();
                temp.Informacion = Info;

                //Unimos el temp al ultimo hermano
                aux.Hermano= temp;
                return temp;
            }
        }
        /*public void TransversaPreO(Nodo pNodo)
        {
            if (pNodo == null)
                return;

            //Me proceso
            //SE HACE EL PROCESO QUE SE QUIERA (VERIFICACION, LETRAS, ETC)
            for (int n = 0; n < i; n++)
                Console.Write(" ");

            Console.WriteLine(pNodo.Dato);

            //Proceso a mi hijo
            if (pNodo.Hijo != null)
            {
                i++;
                TransversaPreO(pNodo.Hijo);
                i--;
            }

            //Si tengo hermanos los proceso
            if (pNodo.Hermano != null)
                TransversaPreO(pNodo.Hermano);
        }*/
    }
}
