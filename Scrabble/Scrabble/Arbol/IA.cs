using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scrabble
{
    class IA
    {
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  Variable globales <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        int iteradorhorizontal = 0, iteradorvertical = 0, mayor_puntaje=0;
        string palabra_elegida = "", palabraAtril = "";
        LetrasPalabras LetrasPalabras = new LetrasPalabras();
        public List<string> mejoresJugadad = new List<string>();
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Atributos <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        string[,] palabras_horizontales = new string[3, 50];
        string[,] palabras_verticales = new string[3, 50];
        string[] vector_atril = new string[7];
        ///string[] vector_atril ={"N","S","S","F","G","J","L" };
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  Constructores <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public string[,] Palabras_verticales { get => palabras_verticales; set => palabras_verticales = value; }
        public string[] Vector_atril { get => vector_atril; set => vector_atril = value; }
        public string[,] Palabras_horizontales { get => palabras_horizontales; set => palabras_horizontales = value; }
        public string Palabra_elegida { get => palabra_elegida; set => palabra_elegida = value; }
        internal LetrasPalabras LetrasPalabras1 { get => LetrasPalabras; set => LetrasPalabras = value; }
        public List<string> MejoresJugadad { get => mejoresJugadad; set => mejoresJugadad = value; }
        public int Mayor_puntaje { get => mayor_puntaje; set => mayor_puntaje = value; }
        public string PalabraAtril { get => palabraAtril; set => palabraAtril = value; }

        //Se encuentra las palabras horizontales existentes en el tablero actual
        public void Encuentra_palabras_Horizontales(Informacion[,] info)
        {
            string palabra = "";
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (info[i, j].Letra != "")
                    {
                        if (j + 1 < 15 && info[i, j + 1].Letra == "")
                        {
                            if (j < 12)
                                j += 2;
                            else i++;
                        }
                        else if (j + 1 < 15 && info[i, j + 1].Letra != "")
                        {
                            palabras_horizontales[1, iteradorhorizontal] = Convert.ToString(i);
                            palabras_horizontales[2, iteradorhorizontal] = Convert.ToString(j);
#pragma warning disable CS1717 // Assignment made to same variable
                            for (j = j; j < 15 && info[i, j].Letra != ""; j++)
#pragma warning restore CS1717 // Assignment made to same variable
                            {
                                palabra += info[i, j].Letra;
                            }
                            Palabras_horizontales[0, iteradorhorizontal] = palabra;

                            iteradorhorizontal++;
                            palabra = "";
                        }
                    }
                }
            }
        }
        //Encuentra las palabras verticales existentes en el tablero actual
        public void Encuentra_palabrasVerticales(Informacion[,] info)
        {
            string palabra = "";
            for (int j = 0; j < 15; j++)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (info[i, j].Letra != "")
                    {
                        if (i + 1 < 15 && info[i + 1, j].Letra == "")
                        {
                            if (i < 12)
                                i += 2;
                            else j++;
                        }

                        else if (i + 1 < 15 && info[i + 1, j].Letra != "")
                        {
                            Palabras_verticales[1, iteradorvertical] = Convert.ToString(i);
                            Palabras_verticales[2, iteradorvertical] = Convert.ToString(j);
#pragma warning disable CS1717 // Assignment made to same variable
                            for (i = i; i < 15 && info[i, j].Letra != ""; i++)
#pragma warning restore CS1717 // Assignment made to same variable
                            {
                                palabra += info[i, j].Letra;
                            }
                            palabras_verticales[0, iteradorvertical] = palabra;
                            iteradorvertical++;
                            palabra = "";
                        }
                    }
                }
            }
        }
        //Se carga el atril de la IA 
        public void Cargar_atril(int seed)
        {
            int i = 0, suma = 0;
            for (i = 0; i < LetrasPalabras.CantLetras.Length - 1; i++) suma += LetrasPalabras.CantLetras[i];
            if (suma > 0)
            {
                for (i = 0; i < 7; i++)
                    if (Vector_atril[i] == "" || Vector_atril[i] == null)
                    {
                        Vector_atril[i] = LetrasPalabras.Cargar_letras(Environment.TickCount + i + seed);
                        if (vector_atril[i] == "") Cargar_atril(Environment.TickCount + seed);
                    }
            }
        }
        //Se busca las palabras validas de las permutaciones del atril y las palabras del tablero
        public void BucadorCoincidencias(string palabra)
        {
            StreamReader sr = new StreamReader(@"Documentos\IA.txt", System.Text.Encoding.Default, false);
            string palabraStreamReader = ""; bool CoincidenciasAtril = false;
            while ((palabraStreamReader = sr.ReadLine()) != null) // palabrasStreamReader lee las palabras del diccionario
            {
                CoincidenciasAtril = palabraAtril.Contains(palabraStreamReader);
                // Determina si la palabra esta contenida en las permutaciones
                // Si coincidencia es true, la palabra actual leida esta contenida en la permutacion actual
                // Descarta las jugadas mejores a una letra usada del atril por conveniencia de puntaje y bonus 
                // La palabra seleccionada tiene que ser distinta de la que es padre del nodo actual 
                if (mejoresJugadad.Contains(palabraStreamReader) == false && palabraStreamReader != palabra && palabraStreamReader.Length > 2 && CoincidenciasAtril == true)
                    mejoresJugadad.Add(palabraStreamReader);
            }
            sr.Close();
        }
        //Realiza las permutaciones del atril de la IA y una palabra del tablero
        public void Permutaciones(string[] vec, int k, int n)
        {
            int i;
            string aux;
            if (k < n)
            {
                for (i = k; i < n; i++)
                {
                    aux = vec[k];
                    vec[k] = vec[i];
                    vec[i] = aux;
                    Permutaciones(vec, k + 1, n);
                    aux = vec[k];
                    vec[k] = vec[i];
                    vec[i] = aux;
                }
            }
            else for (int y = 0; y < n; y++) palabraAtril += vec[y].ToLower();
        }

        //Se encuentra las mejores jugadas y se descartan las jugadas de bajo puntaje. Las verifica y crea su nuevo nodo hijo
        public int RecorteAlphaBeta(List<string> mejoresJugadas, Nodo nodo,int i) // retorna la mejor jugada posible
        {
            if (ColocaPalabraIA(nodo, mejoresJugadad[i]) == 2)  // para cada mejor jugada del nodo actual 
                return 2;
            else return 0;
        }

        public int ColocaPalabraIA(Nodo nodo, string palabra) // nodo = nodo actual
        {
            int i = 0, j = 0;
            string PalabraHijo = "", verificado = "";
            char[] palabrahijoVec = null;    // Vector que contiene los caracteres del hijo 

            //|||||||||||||||||||||||||||||||||||||||||||||||||||||| Casos en los que el nodo padre esta contenido||||||||||||||||||||||||||||||||||||||||

            if (palabra.Contains(nodo.PalabraPadre.ToLower()) == true)// La jugada es en el sentido de la palabra padre
            {
                //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< La palabra del nodo padre es vertical <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                if (nodo.Direccion == 1) // El padre es vertical
                {
                    PalabraHijo = palabra.Replace(nodo.PalabraPadre.ToLower(), "");
                    palabrahijoVec = PalabraHijo.ToCharArray(0, PalabraHijo.Length);

                    if ((PalabraHijo + nodo.PalabraPadre.ToLower()) == palabra) // El padre complementa al hijo
                    {
                        for (i = (nodo.Inicio_i_padre - PalabraHijo.Length); i < nodo.Inicio_i_padre; i++) // Desde el inicio del hijo hasta el final del padre
                        {
                            if (nodo.Informacion[i, nodo.Inicio_j_padre].Letra == "")
                            {
                                nodo.Informacion[i, nodo.Inicio_j_padre].Letra = Convert.ToString(palabrahijoVec[j]); j++;
                            }
                            else if (nodo.Informacion[i, nodo.Inicio_j_padre].Letra != Convert.ToString(palabrahijoVec[j])) return 0;
                        }
                    }
                    else if ((nodo.PalabraPadre.ToLower() + PalabraHijo) == palabra) // El hijo complementa al padre
                    {
                        for (i = (nodo.Inicio_i_padre + nodo.PalabraPadre.Length), j = 0; i < (nodo.Inicio_i_padre + nodo.PalabraPadre.Length + PalabraHijo.Length); i++) // desde el inicio del hijo hasta el final del padre
                        {
                            if (nodo.Informacion[i, nodo.Inicio_j_padre].Letra == "")
                            {
                                nodo.Informacion[i, nodo.Inicio_j_padre].Letra = Convert.ToString(palabrahijoVec[j]); j++;
                            }
                            else if (nodo.Informacion[i, nodo.Inicio_j_padre].Letra != Convert.ToString(palabrahijoVec[j])) return 0;
                        }
                    }
                    else
                    {
                        int aux = 0;
                        PalabraHijo = palabra.Replace(nodo.PalabraPadre.ToLower(), ".");
                        palabrahijoVec = PalabraHijo.ToCharArray();
                        for (i = 0; palabrahijoVec[i] != '.'; i++) ; for (int k = i + 1; k < palabrahijoVec.Length; k++) j++;
                        for (int k = nodo.Inicio_i_padre - i; k < nodo.Inicio_i_padre; k++)
                        {
                            nodo.Informacion[k, nodo.Inicio_j_padre].Letra = Convert.ToString(palabrahijoVec[aux++]);
                        }
                        aux++;
                        for (int k = nodo.Inicio_i_padre + nodo.PalabraPadre.Length; k < (nodo.Inicio_i_padre + nodo.PalabraPadre.Length + j) && aux < palabrahijoVec.Length; k++)
                        {
                            nodo.Informacion[k, nodo.Inicio_j_padre].Letra = Convert.ToString(palabrahijoVec[aux]);
                            aux++;
                        }

                    }
                }
                //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  La  palabra del nodo padre es horizontal   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                else if (nodo.Direccion == 0) // El padre es horizontal
                {
                    PalabraHijo = palabra.Replace(nodo.PalabraPadre.ToLower(), "");
                    palabrahijoVec = PalabraHijo.ToCharArray(0, PalabraHijo.Length);

                    if ((PalabraHijo + nodo.PalabraPadre.ToLower()) == palabra) // El padre complementa al hijo
                    {
                        for (i = (nodo.Inicio_j_padre - PalabraHijo.Length); i < nodo.Inicio_j_padre; i++) // desde el inicio del hijo hasta el final del padre
                        {
                            if (nodo.Informacion[nodo.Inicio_i_padre, i].Letra == "")
                            {
                                nodo.Informacion[nodo.Inicio_i_padre, i].Letra = Convert.ToString(palabrahijoVec[j]); j++;
                            }
                            else if (nodo.Informacion[nodo.Inicio_i_padre, i].Letra != Convert.ToString(palabrahijoVec[j])) return 0;
                        }
                    }
                    else if ((nodo.PalabraPadre.ToLower() + PalabraHijo) == palabra) // El hijo complementa al padre
                    {
                        for (i = (nodo.Inicio_j_padre + nodo.PalabraPadre.Length); i < (nodo.Inicio_j_padre + nodo.PalabraPadre.Length + PalabraHijo.Length); i++) // desde el inicio del hijo hasta el final del padre
                        {
                            if (nodo.Informacion[nodo.Inicio_i_padre, i].Letra == "")
                            {
                                nodo.Informacion[nodo.Inicio_i_padre, i].Letra = Convert.ToString(palabrahijoVec[j]);
                                j++;
                            }
                            else if (nodo.Informacion[nodo.Inicio_i_padre, i].Letra != Convert.ToString(palabrahijoVec[j])) return 0;
                        }
                    }
                    else
                    {
                        int aux = 0;
                        PalabraHijo = palabra.Replace(nodo.PalabraPadre.ToLower(), ".");
                        palabrahijoVec = PalabraHijo.ToCharArray();
                        for (i = 0; palabrahijoVec[i] != '.'; i++) ; for (int k = i + 1; k < palabrahijoVec.Length; k++) j++;
                        for (int k = nodo.Inicio_j_padre - i; k < nodo.Inicio_j_padre; k++)
                        {
                            nodo.Informacion[nodo.Inicio_i_padre, k].Letra = Convert.ToString(palabrahijoVec[aux++]);
                        }
                        aux++;
                        for (int k = nodo.Inicio_i_padre + nodo.PalabraPadre.Length ; k < (nodo.Inicio_i_padre + nodo.PalabraPadre.Length + j) && aux < palabrahijoVec.Length; k++)
                        {
                            nodo.Informacion[nodo.Inicio_i_padre, k].Letra = Convert.ToString(palabrahijoVec[aux]);
                            aux++;
                        }

                    }

                }
               // |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| El hijo usa al padre pero incompleto ||||||||||||||||||||||||||||||||||||||||||||||||||||| 
            }
            else // casos en los que el padre no pertenece a la palabra 
            {
                if (nodo.Direccion == 0)
                {
                    verificado = SinPadreHorizontal(nodo, palabra);
                }
                else if (nodo.Direccion == 1)
                {
                    verificado = SinPadreVertical(nodo, palabra);
                }
            }
            if (verificado == "Success")
            {
                if (nodo.Puntaje > mayor_puntaje)
                    mayor_puntaje = nodo.Puntaje;
                return 2;
            }
            else
            {
                for (int fi = 0; fi < 15; fi++)
                {
                    for (int cu = 0; cu < 15; cu++)
                    {
                        if (nodo.Informacion[fi, cu].Letra != "" && nodo.Informacion[fi, cu].Enabled == true)
                            nodo.Informacion[fi, cu].Letra = "";
                        nodo.Puntaje = 0;
                    }
                }
            }
            return -1;
        }


        public string SinPadreHorizontal(Nodo nodo, string palabra)
        {
            char[] palabraHijo = palabra.ToCharArray();
            char[] palabraPadre = nodo.PalabraPadre.ToLower().ToCharArray();
            for(int i = 0; i < (nodo.PalabraPadre.Length ); i++)    // cantidad de letras del padre
            {
                for (int j = 0; j < palabra.Length; j++)          // cantidad de letras del hijo 
                {
                    if (palabraPadre[i] == palabraHijo[j])            // coincidencias entre los dos 
                    {
                        for (int k = (nodo.Inicio_i_padre - j), aux = 0; k < ((nodo.Inicio_i_padre-j)+palabraHijo.Length); k++, aux++)
                        {
                            if (nodo.Informacion[k, nodo.Inicio_j_padre + i].Letra == "")
                            {
                                nodo.Informacion[k, nodo.Inicio_j_padre + i].Letra = Convert.ToString(palabraHijo[aux]);
                            }
                        } 

                    }
                }
                if (VerificarJugadaIA(nodo) == "Success")
                {
                    return "Success";
                }
            }
            return "Exit";
        }
        public string SinPadreVertical(Nodo nodo, string palabra)
        {
            char[] palabraHijo = palabra.ToCharArray();
            char[] palabraPadre = nodo.PalabraPadre.ToLower().ToCharArray();
            for (int i = 0; i < (nodo.PalabraPadre.Length); i++)    // cantidad de letras del padre
            {
                for (int j = 0; j < palabra.Length; j++)          // cantidad de letras del hijo 
                {
                    if (palabraPadre[i] == palabraHijo[j])            // coincidencias entre los dos 
                    {
                        for (int k = (nodo.Inicio_j_padre +j), aux = 0; k < ((nodo.Inicio_j_padre - j) + palabraHijo.Length); k++, aux++)
                        {
                            if (nodo.Informacion[k, nodo.Inicio_j_padre + i].Letra == "")
                            {
                                nodo.Informacion[k, nodo.Inicio_j_padre + i].Letra = Convert.ToString(palabraHijo[aux]);
                            }
                        }

                    }
                }
                if (VerificarJugadaIA(nodo) == "Success")
                {
                    return "Success";
                }
            }
            return "Exit";
        }


        public string VerificarJugadaIA(Nodo nodo)
        {
            StreamReader letrasPuntos = new StreamReader(@"Documentos\LetrasPuntos.txt", System.Text.Encoding.Default, false);
            int[] info_label_comparar = new int[2]; //Vector para almacenar los valores de una letra del texto plano
            int[] info_label = new int[2]; //Vector para almacenar los valores de una letra del texto plano
            int i, j, ban = 0, posx = 0, posy = 0, x = 0, y = 0, separadas = 0, disabled = 0;
            string leer; string[] puntos_valor = new string[8];

            for (int fil = 0; fil < 15; fil++)
            {
                for (int col = 0; col < 15; col++)
                {
                    ban = 0;
                    if (nodo.Informacion[fil, col].Enabled == true && nodo.Informacion[fil, col].Letra != "")
                        while (ban == 0 && (leer = letrasPuntos.ReadLine()) != null)
                        {
                            puntos_valor = leer.Split(',');
                            if (puntos_valor[0] == nodo.Informacion[fil, col].Letra.ToUpper())
                            {
                                nodo.Informacion[fil, col].Valor = int.Parse(puntos_valor[1]);
                                ban = 1;
                            }
                        }
                    
                }
            }
            letrasPuntos.Close();
            //Se verifica que la jugada sea valida > Parte 1 : Misma linea
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    if (nodo.Informacion[i, j].Letra != "" && nodo.Informacion[i, j].Enabled == true && ban == 1)
                    {
                        //Si es horizontal
                        info_label[0] = nodo.Informacion[i, j].PosY; info_label[1] = nodo.Informacion[i, j].PosX;
                        if (info_label_comparar[0] == info_label[0])
                            posx++;
                        //Si es vertical
                        else if (info_label_comparar[1] == info_label[1])
                            posy++;
                        //Si se encuentran en lineas diferentes
                        else
                        {
                            return "Loss";
                        }
                    } //Se guardan las posiciones con las cuales trabajar posteriormente
                    if (nodo.Informacion[i, j].Letra != "" && nodo.Informacion[i, j].Enabled == true && ban == 0)
                    {
                        info_label_comparar[0] = nodo.Informacion[i, j].PosY; info_label_comparar[1] = nodo.Informacion[i, j].PosX;
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
                    if (nodo.Informacion[i, x].Letra == "" && nodo.Informacion[i, x].Enabled == true)
                        separadas++;
                    if (nodo.Informacion[i, x].Letra != "" && nodo.Informacion[i, x].Enabled == true && separadas == 1)
                    {
                        return "Loss";
                    }
                    else if (i > 1)
                        if (nodo.Informacion[i, x].Letra != "" && nodo.Informacion[i, x].Enabled == false || nodo.Informacion[i - 2, x].Letra != "" && nodo.Informacion[i - 2, x].Enabled == false)
                            disabled++;
                }
                if (disabled == 0)
                {
                    return "Loss";
                }
                //Verificacion parte 3 > Palabras creadas
                int score_colateral = 0; //Para los puntajes obtenidos en el turno
                if (Verificar_vertical(y, x, true, ref score_colateral, ref nodo) == 1) //Jugada principal
                {
                    for (i = y; i < 15; i++)
                    {
                        if (nodo.Informacion[i, x].Letra != "" && nodo.Informacion[i, x].Enabled == true)
                            if (Verificar_horizontal(i, x, false, ref score_colateral, ref nodo) == 0) //Jugadas segundarias
                                return "Loss";
                    }
                }
                else
                    return "Loss";
                //Se vuelven disabled las casillas utilizadas
                /*for (i = y; i < 15 && nodo.Informacion[i, x].Letra != ""; i++)
                    if (nodo.Informacion[i, x].Letra != "" && nodo.Informacion[i, x].Enabled == true)
                        nodo.Informacion[i, x].Enabled = false; SE VUELVE FALSE Y QUEREMOS BORRAR. COMENTAMOS*/
                //Se suma a nuestro puntaje total el puntaje obtenido en este turno
                nodo.Puntaje = score_colateral;
                return "Success";
            }
            else if (posx > 0 && posy == 0) //Verificacion parte 2 > Si la palabra es horizontal
            {
                for (j = x + 1; j < 15; j++)
                {
                    if (nodo.Informacion[y, j].Letra == "" && nodo.Informacion[y, j].Enabled == true)
                        separadas++;
                    if (nodo.Informacion[y, j].Letra != "" && nodo.Informacion[y, j].Enabled == true && separadas == 1)
                    {
                        return "Loss";
                    }
                    else if (j > 1)
                        if (nodo.Informacion[y, j].Letra != "" && nodo.Informacion[y, j].Enabled == false || nodo.Informacion[y, j - 2].Letra != "" && nodo.Informacion[y, j - 2].Enabled == false)
                            disabled++;
                }
                if (disabled == 0)
                {
                    return "Loss";
                }
                //Verificacion parte 3 > Palabras creadas
                int score_colateral = 0; //Para los puntajes obtenidos en el turno
                if (Verificar_horizontal(y, x, true, ref score_colateral, ref nodo) == 1) //Jugada principal
                {
                    for (j = x; j < 15; j++)
                    {
                        if (nodo.Informacion[y, j].Letra != "")
                            if (nodo.Informacion[y, j].Enabled == true)
                                if (Verificar_vertical(y, j, false, ref score_colateral, ref nodo) == 0) //Jugadas segundarias
                                    return "Loss";
                    }
                }
                else
                    return "Loss";
                nodo.Puntaje = score_colateral;
                return "Success";
            }
            else if (posx == 0 && posy == 0 && ban == 1) //Verificacion parte 3 > Si solo se ingreso una letra
            {
                //Caso general
                if (y > 0 && x > 0 && y < 14 && x < 14)
                {
                    if (nodo.Informacion[y - 1, x].Letra != "" && nodo.Informacion[y - 1, x].Enabled == false || nodo.Informacion[y + 1, x].Letra != "" && nodo.Informacion[y + 1, x].Enabled == false || nodo.Informacion[y, x - 1].Letra != "" && nodo.Informacion[y, x - 1].Enabled == false || nodo.Informacion[y, x + 1].Letra != "" && nodo.Informacion[y, x + 1].Enabled == false)
                        disabled++;
                }
                //Casos de esquinas y bordes
                else if (y == 0 && x == 0)
                {
                    if (nodo.Informacion[y + 1, x].Letra != "" && nodo.Informacion[y + 1, x].Enabled == false || nodo.Informacion[y, x + 1].Letra != "" && nodo.Informacion[y, x + 1].Enabled == false)
                        disabled++;
                }
                else if (y == 14 && x == 14)
                {
                    if (nodo.Informacion[y - 1, x].Letra != "" && nodo.Informacion[y - 1, x].Enabled == false || nodo.Informacion[y, x - 1].Letra != "" && nodo.Informacion[y, x - 1].Enabled == false)
                        disabled++;
                }
                else if (y == 0 && x == 14)
                {
                    if (nodo.Informacion[y + 1, x].Letra != "" && nodo.Informacion[y + 1, x].Enabled == false || nodo.Informacion[y, x - 1].Letra != "" && nodo.Informacion[y, x - 1].Enabled == false)
                        disabled++;
                }
                else if (y == 14 && x == 0)
                {
                    if (nodo.Informacion[y - 1, x].Letra != "" && nodo.Informacion[y - 1, x].Enabled == false || nodo.Informacion[y, x + 1].Letra != "" && nodo.Informacion[y, x + 1].Enabled == false)
                        disabled++;
                }
                else if (y == 0 && x > 0 && x < 14)
                {
                    if (nodo.Informacion[y + 1, x].Letra != "" && nodo.Informacion[y + 1, x].Enabled == false || nodo.Informacion[y, x + 1].Letra != "" && nodo.Informacion[y, x + 1].Enabled == false || nodo.Informacion[y, x - 1].Letra != "" && nodo.Informacion[y, x - 1].Enabled == false)
                        disabled++;
                }
                else if (x == 0 && y > 0 && y < 14)
                {
                    if (nodo.Informacion[y + 1, x].Letra != "" && nodo.Informacion[y + 1, x].Enabled == false || nodo.Informacion[y - 1, x].Letra != "" && nodo.Informacion[y - 1, x].Enabled == false || nodo.Informacion[y, x + 1].Letra != "" && nodo.Informacion[y, x + 1].Enabled == false)
                        disabled++;
                }
                else if (x == 14 && y > 0 && y < 14)
                {
                    if (nodo.Informacion[y + 1, x].Letra != "" && nodo.Informacion[y + 1, x].Enabled == false || nodo.Informacion[y - 1, x].Letra != "" && nodo.Informacion[y - 1, x].Enabled == false || nodo.Informacion[y, x - 1].Letra != "" && nodo.Informacion[y, x - 1].Enabled == false)
                        disabled++;
                }
                else if (y == 14 && x > 0 && x < 14)
                {
                    if (nodo.Informacion[y - 1, x].Letra != "" && nodo.Informacion[y - 1, x].Enabled == false || nodo.Informacion[y, x + 1].Letra != "" && nodo.Informacion[y, x + 1].Enabled == false || nodo.Informacion[y, x - 1].Letra != "" && nodo.Informacion[y, x - 1].Enabled == false)
                        disabled++;
                }
                if (disabled == 0)
                {
                    return "Loss";
                }
                int score_colateral = 0; //Para el puntaje obtenido en el turno
                if (Verificar_horizontal(y, x, false, ref score_colateral, ref nodo) == 1 && Verificar_vertical(y, x, false, ref score_colateral, ref nodo) == 1) //Jugadas posibles
                {
                    //nodo.Informacion[y, x].Enabled = false; SE VUELVE FALSE Y QUEREMOS BORRAR. COMENTAMOS
                    //Se suma a nuestro puntaje general el obtenido en el turno
                    nodo.Puntaje = score_colateral;
                    return "Success";
                }
                else
                    return "Loss";
            }
            else
                return "Exit";
        }

        public int Verificar_vertical(int fila, int columna, bool principal, ref int score_colateral, ref Nodo nodo)
        {
            int MulP = 1, obtenido = 0;
            string formar_palabra_vertical = "";
            while (fila >= 0 && nodo.Informacion[fila, columna].Letra != "")
                fila--;
            fila++;
            while (fila < 15 && nodo.Informacion[fila, columna].Letra != "")
            {
                formar_palabra_vertical += nodo.Informacion[fila, columna].Letra;
                //Contamos el puntaje obtenido con las palabras verticales
                if (nodo.Informacion[fila, columna].Enabled == true && nodo.Informacion[fila, columna].Letra != "")
                {
                    obtenido += nodo.Informacion[fila, columna].Valor * nodo.Informacion[fila, columna].MultiplicadorL;
                    MulP *= nodo.Informacion[fila, columna].MultiplicadorP;
                }
                else if (nodo.Informacion[fila, columna].Enabled == false)
                    obtenido += nodo.Informacion[fila, columna].Valor;
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
            if (LetrasPalabras1.Consultar_palabra(formar_palabra_vertical.ToLower()) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //Verificacion de la palabra horizontal formada segun la posicion recibida
        public int Verificar_horizontal(int fila, int columna, bool principal, ref int score_colateral, ref Nodo nodo)
        {
            int MulP = 1, obtenido = 0;
            string formar_palabra_horizontal = "";
            //Contamos el puntaje obtenido con las palabras verticales
            while (columna >= 0 && nodo.Informacion[fila, columna].Letra != "")
                columna--;
            columna++;
            while (columna < 15 && nodo.Informacion[fila, columna].Letra != "")
            {
                formar_palabra_horizontal += nodo.Informacion[fila, columna].Letra;
                //Contamos el puntaje realizado con las palabras horizontales
                if (nodo.Informacion[fila, columna].Enabled == true && nodo.Informacion[fila, columna].Letra != "")
                {
                    obtenido += nodo.Informacion[fila, columna].Valor * nodo.Informacion[fila, columna].MultiplicadorL;
                    MulP *= nodo.Informacion[fila, columna].MultiplicadorP;
                }
                else if (nodo.Informacion[fila, columna].Enabled == false)
                    obtenido += nodo.Informacion[fila, columna].Valor;
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
            if (LetrasPalabras1.Consultar_palabra(formar_palabra_horizontal.ToLower()) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
 }


