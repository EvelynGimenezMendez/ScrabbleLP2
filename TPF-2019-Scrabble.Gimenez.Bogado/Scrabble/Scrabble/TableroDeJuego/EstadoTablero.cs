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
        Informacion[,] info = new Informacion[15, 15]; //Matriz de tipo Informacion. Con ello se forma el tablero estado del juego
        LetrasPalabras letras = new LetrasPalabras();//Clase donde se encuentra contenido el diccionario de letras
        Casilla[,] casilla_matriz = new Casilla[15, 15]; //Matriz de tipo Casilla. Con ello se forma el tablero estado del juego
        public Casilla[,] Casilla_matriz { get => casilla_matriz; set => casilla_matriz = value; }
        internal LetrasPalabras Letras { get => letras; set => letras = value; }
        internal Informacion[,] Info { get => info; set => info = value; }

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
            Casilla_matriz[y, x].PosX = x; Casilla_matriz[y, x].PosY = y; //Posiciones x e y de las casillas
            Casilla_matriz[y, x].LabelCasilla = labelR; //Se asigna el label correspondiente a la matriz
            //Se asignan los multiplicadores
            if (Convert.ToString(labelR.Tag) == "2L")
            {
                Casilla_matriz[y, x].MultiplicadorL = 2;
                Casilla_matriz[y, x].MultiplicadorP = 1;
            }
            else if (Convert.ToString(labelR.Tag) == "3L")
            {
                Casilla_matriz[y, x].MultiplicadorL = 3;
                Casilla_matriz[y, x].MultiplicadorP = 1;
            }
            else if (Convert.ToString(labelR.Tag) == "2P")
            {
                Casilla_matriz[y, x].MultiplicadorP = 2;
                Casilla_matriz[y, x].MultiplicadorL = 1;
            }
            else if (Convert.ToString(labelR.Tag) == "3P")
            {
                Casilla_matriz[y, x].MultiplicadorP = 3;
                Casilla_matriz[y, x].MultiplicadorL = 1;
            }
            else
            {
                //Por defecto los multiplicadores valen 1
                Casilla_matriz[y, x].MultiplicadorP = 1; 
                Casilla_matriz[y, x].MultiplicadorL = 1;
            }
        }
        //Funcion para agregar el valor de la letra jugada en la matriz y uso del comodin
        public int Cargar_jugada(string letra_marcada, string nombreLabel)
        {
            bool band = false;
            StreamReader letrasPuntos = new StreamReader(@"Documentos\LetrasPuntos.txt", System.Text.Encoding.Default, false);
            string leer; //Variable donde almacenar el string leido en el archivo de texto plano
            string[] nombre = new string[3]; //Vactor para almacenar posicion obtenida del nombre del objeto
            string[] puntos_valor = new string[3]; //Vector para almacenar los valores de una letra del texto plano

            nombre = nombreLabel.Split('_');
            int y = int.Parse(nombre[1]); //Fila
            int x = int.Parse(nombre[2]); //Columna

            //Si la ficha jugada es el comodin se deja al usuario elegir la letra con la cual reemplazar
            if(letra_marcada=="?")
            {
                string palabra_buscar = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la letra por la cual reemplazar su comodin:", "Diccionario").ToUpper().Trim();
                for(int i = 0; i < 29; i++)
                {
                    if (palabra_buscar == letras.Dictionary[i]) //Si la letra ingresada coincide con nuestro diccionario de letras se la asignamos al comodin
                    {
                        band = true;
                        Casilla_matriz[y, x].LabelCasilla.Text = palabra_buscar; //Si la letra ingresada es valida se asigna al label
                        Casilla_matriz[y, x].LabelCasilla.ForeColor = Color.DodgerBlue; //Color especial para el comodin
                    }
                }
                if (band == false)
                {
                    MessageBox.Show("La letra ingresada no es valida"); //Se llama a la funcion mientras la letra ingresada no sea valida
                    Cargar_jugada("?", nombreLabel);
                }
            }
            //Se ingresa el valor de la letra marcada
            while ((leer = letrasPuntos.ReadLine()) != null)
            {
                puntos_valor = leer.Split(',');
                if (puntos_valor[0] == letra_marcada)
                    Casilla_matriz[y, x].Valor = int.Parse(puntos_valor[1]);
            }
            //Se retorna 0 y termina la funcion si la jugada no es valida
            //Caso CH
            if (letra_marcada == "C")
                if (Casilla_matriz[y + 1, x].LabelCasilla.Text == "H" || Casilla_matriz[y - 1, x].LabelCasilla.Text == "H" || Casilla_matriz[y, x + 1].LabelCasilla.Text == "H" || Casilla_matriz[y, x - 1].LabelCasilla.Text == "H" )
                    return 0;  
            //Caso CH
            else if (letra_marcada == "H")
                if (Casilla_matriz[y + 1, x].LabelCasilla.Text == "C" || Casilla_matriz[y - 1, x].LabelCasilla.Text == "C" || Casilla_matriz[y, x + 1].LabelCasilla.Text == "C" || Casilla_matriz[y, x - 1].LabelCasilla.Text == "C")
                    return 0;
            //Caso RR
            else if (letra_marcada == "R")
                if (Casilla_matriz[y + 1, x].LabelCasilla.Text == "R" || Casilla_matriz[y - 1, x].LabelCasilla.Text == "R" || Casilla_matriz[y, x + 1].LabelCasilla.Text == "R" || Casilla_matriz[y, x - 1].LabelCasilla.Text == "R")
                    return 0;
            //Caso LL 
            else if (letra_marcada == "L") 
                if (Casilla_matriz[y + 1, x].LabelCasilla.Text == "L" || Casilla_matriz[y - 1, x].LabelCasilla.Text == "L" || Casilla_matriz[y, x + 1].LabelCasilla.Text == "L" || Casilla_matriz[y, x - 1].LabelCasilla.Text == "L")               
                    return 0;      
            //Si la jugada es valida se retorna 1
            return 1;
        }
        //Funcion para verificar la jugada > Verifica la palabra ingresada en caso de que la jugada (disposicion de las letras) sea valida
        public string Verificar_palabra(ref int jugada, ref int puntaje)
        {
            puntaje = 0;
            int[] info_label_comparar = new int[2]; //Vector para almacenar los valores de una letra del texto plano
            int[] info_label = new int[2]; //Vector para almacenar los valores de una letra del texto plano
            int i, j, ban = 0, posx = 0, posy = 0, x = 0, y = 0, separadas = 0, disabled = 0;
            if (jugada == 0)
            {
                if (Casilla_matriz[7, 8].LabelCasilla.Text != "" || Casilla_matriz[8, 7].LabelCasilla.Text != "" || Casilla_matriz[6, 7].LabelCasilla.Text != "" || Casilla_matriz[7, 6].LabelCasilla.Text != "")
                    ban++;
                if (ban == 0)
                {
                    MessageBox.Show(Casilla_matriz[7, 7].LabelCasilla.Text + "\nNo es una palabra válida :(", "Intenta nuevamente");
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
                    } //Se guardan las posiciones con las cuales trabajar posteriormente
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
                int score_colateral = 0; //Para los puntajes obtenidos en el turno
                if (Verificar_vertical(y, x, true, ref score_colateral) == 1) //Jugada principal
                {
                    for (i = y; i < 15; i++)
                    {
                        if (Casilla_matriz[i, x].LabelCasilla.Text != "" && Casilla_matriz[i, x].LabelCasilla.Enabled == true)
                            if (Verificar_horizontal(i, x, false, ref score_colateral) == 0) //Jugadas segundarias
                                return "Loss";
                    }
                }
                else
                    return "Loss";
                //Se vuelven disabled las casillas utilizadas
                for (i = y; i < 15 && Casilla_matriz[i, x].LabelCasilla.Text != ""; i++)
                    if (Casilla_matriz[i, x].LabelCasilla.Text != "" && Casilla_matriz[i, x].LabelCasilla.Enabled == true)
                        Casilla_matriz[i, x].LabelCasilla.Enabled = false;
                //Se suma a nuestro puntaje total el puntaje obtenido en este turno
                puntaje = score_colateral;
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
                int score_colateral = 0; //Para los puntajes obtenidos en el turno
                if (Verificar_horizontal(y, x, true, ref score_colateral) == 1) //Jugada principal
                {
                    for (j = x; j < 15; j++)
                    {
                        if (Casilla_matriz[y, j].LabelCasilla.Text != "")
                            if (Casilla_matriz[y, j].LabelCasilla.Enabled == true)
                                if (Verificar_vertical(y, j, false, ref score_colateral) == 0) //Jugadas segundarias
                                    return "Loss";
                    }
                }
                else
                    return "Loss";
                //Se vuelven disabled las casillas utilizadas
                for (j = x; j < 15 && Casilla_matriz[y, j].LabelCasilla.Text != ""; j++)
                    if (Casilla_matriz[y, j].LabelCasilla.Text != "" && Casilla_matriz[y, j].LabelCasilla.Enabled == true)
                        Casilla_matriz[y, j].LabelCasilla.Enabled = false;
                //Se suma a nuestro puntaje total el puntaje obtenido en este turno
                puntaje = score_colateral;
                return "Success";

            }
            else if (posx == 0 && posy == 0 && ban == 1) //Verificacion parte 3 > Si solo se ingreso una letra
            {
                //Caso general
                if (y > 0 && x > 0 && y < 14 && x < 14)
                {
                    if (Casilla_matriz[y - 1, x].LabelCasilla.Text != "" && Casilla_matriz[y - 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y + 1, x].LabelCasilla.Text != "" && Casilla_matriz[y + 1, x].LabelCasilla.Enabled == false || Casilla_matriz[y, x - 1].LabelCasilla.Text != "" && Casilla_matriz[y, x - 1].LabelCasilla.Enabled == false || Casilla_matriz[y, x + 1].LabelCasilla.Text != "" && Casilla_matriz[y, x + 1].LabelCasilla.Enabled == false)
                        disabled++;
                }
                //Casos de esquinas y bordes
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
                int score_colateral = 0; //Para el puntaje obtenido en el turno
                if (Verificar_horizontal(y, x, false, ref score_colateral) == 1 && Verificar_vertical(y, x, false, ref score_colateral) == 1) //Jugadas posibles
                {
                    Casilla_matriz[y, x].LabelCasilla.Enabled = false;
                    //Se suma a nuestro puntaje general el obtenido en el turno
                    puntaje = score_colateral;
                    return "Success";
                }
                else
                    return "Loss";
            }
            else
                return "Exit";
        }
        //Verificacion de las palabra vertical formada segun la posicion recibida
        public int Verificar_vertical(int fila, int columna, bool principal, ref int score_colateral)
        {
            int MulP = 1, obtenido = 0;
            string formar_palabra_vertical = "";
            while (fila >= 0 && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
                fila--;
            fila++;
            while (fila < 15 && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
            {
                formar_palabra_vertical += Casilla_matriz[fila, columna].LabelCasilla.Text;
                //Contamos el puntaje obtenido con las palabras verticales
                if (Casilla_matriz[fila, columna].LabelCasilla.Enabled == true && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
                {
                    obtenido += Casilla_matriz[fila, columna].Valor * Casilla_matriz[fila, columna].MultiplicadorL;
                    MulP *= Casilla_matriz[fila, columna].MultiplicadorP;
                }
                else if (Casilla_matriz[fila, columna].LabelCasilla.Enabled == false)
                    obtenido += Casilla_matriz[fila, columna].Valor;
                fila++;
            }
            fila--;
            //Si la palabra es menor a una letra y no es la palabra principal no se suma el puntaje de la letra
            if (formar_palabra_vertical.Length == 1 && principal == false)
                return 1;
            //Si es la jugada principal o una jugada correcta segundaria se suman los puntajes individuales con multiplicadores de letras y se multiplica por los multiplicadores de palabras
            else
            {
                score_colateral += obtenido;
                score_colateral *= MulP;
            }
            //Se verifica la existencia de la palabra
            if (Letras.Consultar_palabra(formar_palabra_vertical.ToLower()) == 1)
            {
                return 1;
            }
            else
            {
                MessageBox.Show(formar_palabra_vertical + "\nNo es una palabra válida :(", "Consulta el diccionario");
                return 0;
            }
        }
        //Verificacion de la palabra horizontal formada segun la posicion recibida
        public int Verificar_horizontal(int fila, int columna, bool principal, ref int score_colateral)
        {
            int MulP = 1, obtenido = 0;
            string formar_palabra_horizontal = "";
            //Contamos el puntaje obtenido con las palabras verticales
            while (columna >= 0 && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
                columna--;
            columna++;
            while (columna < 15 && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
            {
                formar_palabra_horizontal += Casilla_matriz[fila, columna].LabelCasilla.Text;
                //Contamos el puntaje realizado con las palabras horizontales
                if (Casilla_matriz[fila, columna].LabelCasilla.Enabled == true && Casilla_matriz[fila, columna].LabelCasilla.Text != "")
                {
                    obtenido += Casilla_matriz[fila, columna].Valor * Casilla_matriz[fila, columna].MultiplicadorL;
                    MulP *= Casilla_matriz[fila, columna].MultiplicadorP;
                }
                else if (Casilla_matriz[fila, columna].LabelCasilla.Enabled == false)
                    obtenido += Casilla_matriz[fila, columna].Valor;
                columna++;
            }
            columna--;
            //Si la palabra es menor a una letra y no es la palabra principal no se suma el puntaje de la letra
            if (formar_palabra_horizontal.Length == 1 && principal == false)
                return 1;
            //Si es la jugada principal o una jugada correcta segundaria se suman los puntajes individuales con multiplicadores de letras y se multiplica por los multiplicadores de palabras
            else
            {
                score_colateral += obtenido;
                score_colateral *= MulP;
            }
            //Se verifica la existencia de la palabra
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

        public void Crear_info_nodo() //Copia el estado actual del tablero de juego en una matriz
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    Info[i, j] = new Informacion
                    {
                        Letra = Casilla_matriz[i, j].LabelCasilla.Text,
                        Tag = Convert.ToString(Casilla_matriz[i, j].LabelCasilla.Tag),
                        Valor = Casilla_matriz[i, j].Valor,
                        Enabled = Casilla_matriz[i, j].LabelCasilla.Enabled
                    };
        }

        public void Crear_arbol()
        {
            Crear_info_nodo(); //Se crea la nueva matriz de estado
            Arbol arbol = new Arbol(); //Se crea un nuevo arbol para cada jugada de la IA 
            Nodo raiz = arbol.Insertar(Info, "Hola", null); //Se inserta la jugada, un dato,y el nodo al que va hacer referencia
        }

    }
}