using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Scrabble
{
    class LetrasPalabras
    {

        Dictionary<int, string> dictionary = new Dictionary<int,string>
        {
            {0,"?"},{1,"A"},{2,"B"},{3,"C"},{4,"CH"},{5,"D"},{6,"E"},{7,"F"},{8,"G"},{9,"H"},{10,"I"},{11,"J"},{12,"L"},{13,"LL"},{14,"M"},{15,"N"},{16,"Ñ"},{17,"O"},{18,"P"},{19,"Q"},{20,"R"},{21,"RR"},{22,"S"},{23,"T"},{24,"U" },{25,"V"},{26,"X"},{27,"Y"},{28,"Z"}
        };
        string letra_ran;
        string leer;
        int encontrado;
        public Label [] vector_atril = new Label[7]; //Vector de tipo Casilla. Con ello se forma el atril de letras
        public Label[] Vector_atril { get => vector_atril; set => vector_atril = value; }
        //int[] CantLetras = { 2, 12, 2, 4, 1, 5, 12, 1, 2, 2, 6, 1, 4, 1, 2, 5, 1, 9, 2, 1, 5, 1, 6, 4, 5, 1, 1, 1, 1 };
        int[] CantLetras = { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //Cargamos el atril del usuario / Devolvemos las letras / Cambiamos las letras
        public void Cargar_atril(string devolver)
        {
            int i;
            int ban = 0;

            for (i = 0; i < 7; i++)
                if (Vector_atril[i].Text == "" && ban == 0 || devolver=="Cambio")
                {
                    //Si devolver es igual a "" la funcion carga nuevas letras a los espacios vacios
                    if (devolver == "")
                        Vector_atril[i].Text = Cargar_letras(Environment.TickCount + i); //A cada semilla le sumamos el siguiente indice para no obtener letras iguales
                    //Si devolver es igual a "Cambio" cambiamos las letras seleccionadas
                    else if (devolver=="Cambio")
                    {
                        if (Vector_atril[i].ForeColor==Color.Red)
                        {
                            Vector_atril[i].ForeColor = Color.White;
                            for(int j = 0; j < CantLetras.Length - 1; j++)
                            {
                                if (dictionary[j] == Vector_atril[i].Text)
                                {
                                    CantLetras[j]++;
                                }
                            }
                            Vector_atril[i].Text = Cargar_letras(Environment.TickCount + i);
                        }
                    }
                    //Si se envia una palabra a devolver, devolvemos las letras que se encuentran activas en el tablero
                    else
                    {
                        //Le damos al atril la letra que sacamos al introducirlo al tablero
                        Vector_atril[i].Text = devolver;
                        ban = 1;
                    }
                    //Se ajustan las letras especiales
                    if (Vector_atril[i].Text == "CH" || Vector_atril[i].Text == "LL" || Vector_atril[i].Text == "RR")
                        Vector_atril[i].Font = new Font("Microsoft Sans Serif", 18.7F);
                    else
                        Vector_atril[i].Font = new Font("Microsoft Sans Serif", 36F);
                }
        }
        //Funcion para crear el atril del usuario
        public void Crear_atril(ref Label atril)
        {
            string[] nombre = new string[3];
            nombre = atril.Name.Split('_');
            int i = int.Parse(nombre[1]); //Numero de posicion atril
            Vector_atril[i-1] = new Label();
            Vector_atril[i-1] = atril; 
        }
    
        //Diccionario de las letras disponibles en el juego y su indice numerico
        public string Cargar_letras(int seed) 
        {
            int ran;
            
            var random = new Random(seed);
            ran = random.Next(0, 29);
            if (CantLetras[ran] != 0) { CantLetras[ran]--; letra_ran = dictionary[ran]; }
            else Cargar_letras(seed + Environment.TickCount);
            return letra_ran;
        }
        //Verificamos la existencia de una palabra en nuestro diccionario
        public int Consultar_palabra(string palabra) 
        {
            int ban = 0;

            StreamReader diccionarioPalabras = new StreamReader(@"Documentos\Palabras.txt",System.Text.Encoding.Default,false);
            while ((leer = diccionarioPalabras.ReadLine()) != null && ban != 1)
            {
                if (leer == palabra)
                {
                    ban = 1;
                }
            }
            if (ban == 1)
                encontrado = 1;
            else if (ban==0)
                encontrado = 0;
            diccionarioPalabras.Close(); //Cerramos el archivo
            return encontrado; //Retornamos 1 si la palabra es valida. 0 si no lo es.
        }
    }
}
