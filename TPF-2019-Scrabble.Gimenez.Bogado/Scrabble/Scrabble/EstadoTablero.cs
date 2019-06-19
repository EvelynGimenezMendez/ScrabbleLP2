using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Scrabble
{
    class EstadoTablero
    {
        LetrasPalabras letras = new LetrasPalabras();//Clase donde se encuentra contenido el diccionario de letras
        Casilla[,] casilla_matriz = new Casilla[15, 15]; //Matriz de tipo Casilla. Con ello se forma el tablero estado del juego
        public Casilla[,] Casilla_matriz { get => casilla_matriz; set => casilla_matriz = value; }
        internal LetrasPalabras Letras { get => letras; set => letras = value; }
        Nodo nodo = new Nodo();

        //Funcion para cargar el tablero
        public void Cargar_tablero(ref Label labelR)
        {
            string[] nombre = new string[3]; //Vector para almacenar posicion obtenida del nombre del objeto
            string[] puntos_valor = new string[3]; //Vector para almacenar los valores de una letra del texto plano

            nombre = labelR.Name.Split('_');
            int y = int.Parse(nombre[1]); //Fila
            int x = int.Parse(nombre[2]); //Columna
            Casilla_matriz[y, x] = new Casilla();
            Casilla_matriz[y, x].PosX = x; Casilla_matriz[y, x].PosY = y;
            Casilla_matriz[y, x].LabelCasilla = labelR;
            if (Convert.ToString(labelR.Tag) == "2L")
                Casilla_matriz[y, x].MultiplicadorL = 2;
            else if (Convert.ToString(labelR.Tag) == "3L")
                Casilla_matriz[y, x].MultiplicadorL = 3;
            else if (Convert.ToString(labelR.Tag) == "2P")
                Casilla_matriz[y, x].MultiplicadorP = 2;
            else if (Convert.ToString(labelR.Tag) == "2P")
                Casilla_matriz[y, x].MultiplicadorP = 3;
            else
            {
                Casilla_matriz[y, x].MultiplicadorP = 1;
                Casilla_matriz[y, x].MultiplicadorL = 1;
            }
         }
        //Funcion para agregar el valor de la letra jugada en la matriz
        public void Cargar_jugada(string letra_marcada,string nombreLabel)
        {
            StreamReader letrasPuntos = new StreamReader(@"Documentos\LetrasPuntos.txt");
            string leer; //Variable donde almacenar el string leido en el archivo de texto plano
            string[] nombre = new string[3]; //Vactor para almacenar posicion obtenida del nombre del objeto
            string[] puntos_valor = new string[3]; //Vector para almacenar los valores de una letra del texto plano

            nombre = nombreLabel.Split('_');
            int y = int.Parse(nombre[1]); //Fila
            int x = int.Parse(nombre[2]); //Columna
            while ((leer = letrasPuntos.ReadLine()) != null)
            {
                puntos_valor = leer.Split(',');
                if (puntos_valor[0] == letra_marcada)
                    Casilla_matriz[y, x].Valor = int.Parse(puntos_valor[1]);
            }
        }
        //Funcion para verificar la jugada > Verifica la palabra ingresada en caso de que la jugada (disposicion de las letras) sea valida
        public string Verificar_palabra(ref int jugada)
        {
            int[] info_label_comparar = new int[2]; //Vector para almacenar los valores de una letra del texto plano
            int[] info_label = new int[2]; //Vector para almacenar los valores de una letra del texto plano
            int i, j, ban = 0, posx = 0, posy = 0, x = 0, y = 0, separadas = 0, disabled = 0;
            if (jugada == 0)
            {
                if (Casilla_matriz[7, 8].LabelCasilla.Text != "" || Casilla_matriz[8, 7].LabelCasilla.Text != "" || Casilla_matriz[6, 7].LabelCasilla.Text != "" || Casilla_matriz[7, 6].LabelCasilla.Text != "")
                    ban++;
                if (ban == 0)
                {
                    MessageBox.Show(Casilla_matriz[7,7].LabelCasilla.Text + "\nNo es una palabra válida :(", "Intenta nuevamente");
                    return "Loss";
                }
                else
                    disabled = 1;
            }
            ban = 0;
            //Se verifica que la jugada sea valida > Parte 1 : Misma linea
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    if (Casilla_matriz[i, j].LabelCasilla.Text != "" && Casilla_matriz[i, j].LabelCasilla.Enabled == true && ban == 1)
                    {
                        //Si es horizontal
                        info_label[0] = Casilla_matriz[i, j].PosY; info_label[1] = Casilla_matriz[i, j].PosX;
                        if (info_label_comparar[0] == info_label[0])
                            posx++;
                        //Si es vertical
                        else if (info_label_comparar[1] == info_label[1])
                            posy++;
                        //Si se encuentran en lineas diferentes
                        else
                        {
                            MessageBox.Show("Las letras no se encuentran en la misma linea :(", "Intenta de nuevo");
                            return "Loss";
                        }
                    }
                    if (Casilla_matriz[i, j].LabelCasilla.Text != "" && Casilla_matriz[i, j].LabelCasilla.Enabled == true && ban == 0)
                    {
                        info_label_comparar[0] = Casilla_matriz[i, j].PosY; info_label_comparar[1] = Casilla_matriz[i, j].PosX;
                        y = i; x = j;
                        ban = 1;
                    }
                }
            }
            //Verificación de la jugada > Parte 2: Sin espacios vacios / Sin letras que no esten en contacto
            if (posx == 0 && posy > 0) // Verificacion parte 2 > Si la palabra es vertical
            {
                for (i = y + 1; i < 15; i++)
                {
                    if (Casilla_matriz[i, x].LabelCasilla.Text == "" && Casilla_matriz[i, x].LabelCasilla.Enabled == true)
                        separadas++;
                    if (Casilla_matriz[i, x].LabelCasilla.Text != "" && Casilla_matriz[i, x].LabelCasilla.Enabled == true && separadas == 1)
                    {
                        MessageBox.Show("Algunas de las letras no están en contacto :(", "Intenta de nuevo");
                        return "Loss";
                    }
                    else if (i > 1)
                        if (Casilla_matriz[i, x].LabelCasilla.Text != "" && Casilla_matriz[i, x].LabelCasilla.Enabled == false || Casilla_matriz[i - 2, x].LabelCasilla.Text != "" && Casilla_matriz[i - 2, x].LabelCasilla.Enabled == false)
                            disabled++;
                }
                if (disabled == 0)
                {
                    MessageBox.Show(" La nueva palabra debe tocar como minimo\n a una letra ya existente en el tablero :)", "Intenta de nuevo");
                    return "Loss";
                }
                //Verificacion parte 3 > Palabras creadas
                if (Verificar_vertical(y, x) == 1)
                {
                    for (i = y; i < 15; i++)
                    {
                        if (Casilla_matriz[i, x].LabelCasilla.Text != "" && Casilla_matriz[i, x].LabelCasilla.Enabled == true)
                            if (Verificar_horizontal(i, x) == 0)
                                return "Loss";
                    }
                }
                else
                    return "Loss";
                for (i = y; i < 15; i++)
                {
                    if (Casilla_matriz[i, x].LabelCasilla.Text != "" && Casilla_matriz[i, x].LabelCasilla.Enabled == true)
                        Casilla_matriz[i, x].LabelCasilla.Enabled = false;
                }
                return "Success";

            }
            else if (posx > 0 && posy == 0) //Verificacion parte 2 > Si la palabra es horizontal
            {
                for (j = x + 1; j < 15; j++)
                {
                    if (Casilla_matriz[y, j].LabelCasilla.Text == "" && Casilla_matriz[y, j].LabelCasilla.Enabled == true)
                        separadas++;
                    if (Casilla_matriz[y, j].LabelCasilla.Text != "" && Casilla_matriz[y, j].LabelCasilla.Enabled == true && separadas == 1)
                    {
                        MessageBox.Show("Algunas de las letras no están en contacto :(", "Intenta de nuevo");
                        return "Loss";
                    }
                    else if (j > 1)
                        if (Casilla_matriz[y, j].LabelCasilla.Text != "" && Casilla_matriz[y, j].LabelCasilla.Enabled == false || Casilla_matriz[y, j - 2].LabelCasilla.Text != "" && Casilla_matriz[y, j - 2].LabelCasilla.Enabled == false)
                            disabled++;
                }
                if (disabled == 0)
                {
                    MessageBox.Show(" La nueva palabra debe tocar como minimo\n a una letra ya existente en el tablero :)", "Intenta de nuevo");
                    return "Loss";
                }
                //Verificacion parte 3 > Palabras creadas
                if (Verificar_horizontal(y, x) == 1)
                {
                    for (j = x; j < 15; j++)
                    {
                        if (Casilla_matriz[y, j].LabelCasilla.Text != "" && Casilla_matriz[y, j].LabelCasilla.Enabled == true)
                            if (Verificar_vertical(y, j) == 0)
                                return "Loss";
                    }
                }
                else
                    return "Loss";
                for (j = x; j < 15; j++)
                {
                    if (Casilla_matriz[y, j].LabelCasilla.Text != "" && Casilla_matriz[y, j].LabelCasilla.Enabled == true)
                        Casilla_matriz[y, j].LabelCasilla.Enabled = false;
                }
                return "Success";

            }
            else if (posx == 0 && posy == 0 && ban == 1) //Verificacion parte 3 > Si solo se ingreso una letra
            {
                if (y > 0 && x > 0 && y < 14 && x < 14)
                {
                    if (Casilla_matriz[y - 1, x].LabelCasilla.Text != "" && Casilla_matriz[y - 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y + 1, x].LabelCasilla.Text != "" && Casilla_matriz[y + 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x - 1].LabelCasilla.Text != "" && Casilla_matriz[y, x - 1].LabelCasilla.Enabled == false || Casilla_matriz[y, x + 1].LabelCasilla.Text != "" && Casilla_matriz[y, x + 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (y == 0 && x == 0)
                {
                    if (Casilla_matriz[y + 1, x].LabelCasilla.Text != "" && Casilla_matriz[y + 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x + 1].LabelCasilla.Text != "" && Casilla_matriz[y, x + 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (y == 14 && x == 14)
                {
                    if (Casilla_matriz[y - 1, x].LabelCasilla.Text != "" && Casilla_matriz[y - 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x - 1].LabelCasilla.Text != "" && Casilla_matriz[y, x - 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (y == 0 && x == 14)
                {
                    if (Casilla_matriz[y + 1, x].LabelCasilla.Text != "" && Casilla_matriz[y + 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x - 1].LabelCasilla.Text != "" && Casilla_matriz[y, x - 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (y == 14 && x == 0)
                {
                    if (Casilla_matriz[y - 1, x].LabelCasilla.Text != "" && Casilla_matriz[y - 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x + 1].LabelCasilla.Text != "" && Casilla_matriz[y, x + 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (y == 0 && x > 0 && x < 14)
                {
                    if (Casilla_matriz[y + 1, x].LabelCasilla.Text != "" && Casilla_matriz[y + 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x + 1].LabelCasilla.Text != "" && Casilla_matriz[y, x + 1].LabelCasilla.Enabled == false || Casilla_matriz[y, x - 1].LabelCasilla.Text != "" && Casilla_matriz[y, x - 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (x == 0 && y > 0 && y < 14)
                {
                    if (Casilla_matriz[y + 1, x].LabelCasilla.Text != "" && Casilla_matriz[y + 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y - 1, x].LabelCasilla.Text != "" && Casilla_matriz[y - 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x + 1].LabelCasilla.Text != "" && Casilla_matriz[y, x + 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (x == 14 && y > 0 && y < 14)
                {
                    if (Casilla_matriz[y + 1, x].LabelCasilla.Text != "" && Casilla_matriz[y + 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y - 1, x].LabelCasilla.Text != "" && Casilla_matriz[y - 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x - 1].LabelCasilla.Text != "" && Casilla_matriz[y, x - 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                else if (y == 14 && x > 0 && x < 14)
                {
                    if (Casilla_matriz[y - 1, x].LabelCasilla.Text != "" && Casilla_matriz[y - 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x + 1].LabelCasilla.Text != "" && Casilla_matriz[y, x + 1].LabelCasilla.Enabled == false || Casilla_matriz[y, x - 1].LabelCasilla.Text != "" && Casilla_matriz[y, x - 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                if (disabled == 0)
                {
                    MessageBox.Show(" La nueva palabra debe tocar como minimo\n a una letra ya existente en el tablero :)", "Intenta de nuevo");
                    return "Loss";
                }
                if (Verificar_horizontal(y, x) == 1 && Verificar_vertical(y, x) == 1)
                {
                    Casilla_matriz[y, x].LabelCasilla.Enabled = false;
                    return "Success";
                }
                else
                    return "Loss";
            }
            else
                return "Exit";
        }
        //Verificacion de las palabra vertical formada segun la posicion recibida
        public int Verificar_vertical (int fila , int columna)
        {
            string formar_palabra_vertical = "";
            while (fila >= 0 && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
                fila--;
            fila++;
            while (fila < 15 && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
            {
                formar_palabra_vertical = formar_palabra_vertical + Casilla_matriz[fila, columna].LabelCasilla.Text;
                fila++;
            }
            fila--;
            if (Letras.Consultar_palabra(formar_palabra_vertical.ToLower()) == 1)
            {
                return 1;
            }
            else
            {
                MessageBox.Show( formar_palabra_vertical+"\nNo es una palabra válida :(", "Consulta el diccionario");
                return 0;
            }
        }
        //Verificacion de la palabra horizontal formada segun la posicion recibida
        public int Verificar_horizontal (int fila, int columna)
        {
            string formar_palabra_horizontal = "";
            while (columna >= 0 && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
                columna--;
            columna++;
            while (columna < 15 && Casilla_matriz[fila, columna].LabelCasilla.Text != "" )
            {
                formar_palabra_horizontal = formar_palabra_horizontal + Casilla_matriz[fila, columna].LabelCasilla.Text;
                columna++;
            }
            columna--;
            if (Letras.Consultar_palabra(formar_palabra_horizontal.ToLower()) == 1)
            {
                return 1;
            }
            else
            {
                MessageBox.Show(formar_palabra_horizontal + "\nNo es una palabra válida :(", "Consulta el diccionario");
                return 0;
            }
        }

        public void Crear_raiz() //Se crea la raiz nueva del arbol
        {
            for (int i=0;i<15;i++)
                for (int j=0;j<15;j++)
                {
                    nodo.Informacion[i, j] = new Informacion();
                    nodo.Informacion[i, j].Letra = Casilla_matriz[i, j].LabelCasilla.Text;
                    nodo.Informacion[i, j].Tag = Convert.ToString(Casilla_matriz[i, j].LabelCasilla.Tag);
                    nodo.Informacion[i, j].Valor = Casilla_matriz[i, j].Valor;
                    nodo.Informacion[i, j].Enabled = Casilla_matriz[i, j].LabelCasilla.Enabled;
                }
            nodo.Ver_nodo();
        }
    }
}
