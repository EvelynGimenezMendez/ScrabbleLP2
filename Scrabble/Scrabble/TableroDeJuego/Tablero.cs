using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Media;

namespace Scrabble
{

    public partial class Tablero : Form
    {
        string letra = "", usuario = "Usuario"; //Guarda la letra a ingresar en el tablero
        int cambiar = 0, jugada = 0, mi_puntaje = 0, puntaje,turno=0,dificultad=6;
        LetrasPalabras letras = new LetrasPalabras(); //Clase donde se encuentra contenido el diccionario de letras
        EstadoTablero estadoTablero = new EstadoTablero(); //Clase donde creamos el tablero con la clase casillas
        SoundPlayer player = new SoundPlayer(@"Sonidos\Click.wav");
        SoundPlayer player2 = new SoundPlayer(@"Sonidos\But.wav");
        SoundPlayer player3 = new SoundPlayer(@"Sonidos\Cof.wav");
        public string Usuario { get => usuario; set => usuario = value; } //Nombre del jugador
        public int Dificultad { get => dificultad; set => dificultad = value; } //Dificultad del juego
        public int Turno { get => turno; set => turno = value; } //Primer turno del juego

        public Tablero()
        {
            InitializeComponent();
        }
        //El formulario se guarda dos veces en memoria para aumentar su velocidad de ejecucion
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        //Al iniciar el tablero creamos el tablero y cargamos el atril del usuario
        private void Tablero_Load(object sender, EventArgs e)
        {
            Crear(sender, e);
            CargarTurno();
            letras.Cargar_atril("");
            if (l_7_7.Text == "" && turno == 1)
            {
                char[] palabra=new char[7];
                estadoTablero.Ia1.Cargar_atril(6666);
                estadoTablero.Ia1.Permutaciones(estadoTablero.Ia1.Vector_atril, 1, 7);
                BucadorCoincidencias(estadoTablero.Ia1.PalabraAtril);
                int longitud=estadoTablero.Ia1.mejoresJugadad.Count();
                if (longitud > 0)
                {
                    int maximo = estadoTablero.Ia1.mejoresJugadad[0].Length;
                    palabra = estadoTablero.Ia1.mejoresJugadad[0].ToCharArray();
                    int longi = maximo;

                    if (palabra[0] != '0' && longi != 0) { l_7_7.Text = Convert.ToString(palabra[0]).ToUpper(); longi--; l_7_7.BackColor = Color.DimGray; l_7_7.Enabled=false; }
                    if (longi != 0 && palabra[1] != '0') { l_7_8.Text = Convert.ToString(palabra[1]).ToUpper(); longi--; l_7_8.BackColor = Color.DimGray; l_7_8.Enabled=false; }
                    if (longi != 0 && palabra[2] != '0') { l_7_9.Text = Convert.ToString(palabra[2]).ToUpper(); longi--; l_7_9.BackColor = Color.DimGray; l_7_9.Enabled=false; }
                    if (longi != 0 && palabra[3] != '0') { l_7_10.Text = Convert.ToString(palabra[3]).ToUpper(); longi--; l_7_10.BackColor = Color.DimGray; l_7_10.Enabled=false; }
                    if (longi != 0 && palabra[4] != '0') { l_7_11.Text = Convert.ToString(palabra[4]).ToUpper(); longi--; l_7_11.BackColor = Color.DimGray; l_7_11.Enabled=false; }
                    if (longi != 0 && palabra[5] != '0') { l_7_12.Text = Convert.ToString(palabra[5]).ToUpper(); longi--; l_7_12.BackColor = Color.DimGray; l_7_12.Enabled=false; }
                    if (longi != 0 && palabra[6] != '0') { l_7_13.Text = Convert.ToString(palabra[6]).ToUpper(); longi--; l_7_13.BackColor = Color.DimGray; l_7_13.Enabled=false; }
   
                    MessageBox.Show("Para no ser cruel, no me sumo puntos \n Suerte.","Una ayudita");
                    turno--;
                    CargarTurno();
                }
                else
                {
                    MessageBox.Show("Sin palabras, la tengo dificil. \n Mejor empieza tu...", "No pude");
                    turno--;
                    CargarTurno();
                }
            }
        }
        //Enuentra las coindicencias de las permutaciones en el diccionario utilizado en el juego. 
        public void BucadorCoincidencias(string palabra)
        {
            StreamReader sr = new StreamReader(@"\Documentos\Palabra.txt", System.Text.Encoding.Default, false);
            string palabraStreamReader = ""; bool CoincidenciasAtril = false;
            while ((palabraStreamReader = sr.ReadLine()) != null) // palabrasStreamReader lee las palabras del diccionario
            {
                CoincidenciasAtril =estadoTablero.Ia1.PalabraAtril.Contains(palabraStreamReader);
                // Determina si la palabra esta contenida en las permutaciones
                // Si coincidencia es true, la palabra actual leida esta contenida en la permutacion actual
                // Descarta las jugadas mejores a una letra usada del atril por conveniencia de puntaje y bonus 
                // La palabra seleccionada tiene que ser distinta de la que es padre del nodo actual 
                if (estadoTablero.Ia1.mejoresJugadad.Contains(palabraStreamReader) == false && palabraStreamReader != palabra && palabraStreamReader.Length > 2 && CoincidenciasAtril == true)
                   estadoTablero.Ia1.mejoresJugadad.Add(palabraStreamReader);
            }
            sr.Close();
        }
        //Salir de la aplicacion
        private void Salir_Click(object sender, EventArgs e) 
        {
            player.Play();
            Application.Exit();
        }
        //Volver a la pantalla principal
        private void Volver_Click(object sender, EventArgs e) 
        {
            player.Play();
            Inicio inicio = new Inicio();
            this.Close();
            inicio.Show();    
        }
        //Sonido cuando las letras de nuestra tabla obtienen el focus
        private void Word_GotFocus(object sender, EventArgs e) 
        {
            player2.Play();
        }
        //Obtiene la casilla donde sera contenida la letra elegida, envia parametros a la clase tablero para crear con ellas una casilla 
        private void Buscar(object sender, EventArgs e) 
        {
            if (Turno == 0)
            {
                int resultado = 0;
                if (letra != "")
                {
                    lab_pasar.Visible = false; lab_jugar.Visible = true; //Para que no cambie el boton pasar si la letra esta vacia
                }
                if ((sender as Label).Text == "" && letra != "")
                {
                    (sender as Label).Text = letra;
                    resultado = estadoTablero.Cargar_jugada((sender as Label).Text, (sender as Label).Name);
                    if (letra == "CH" || letra == "LL" || letra == "RR") //Ajustamos las letras especiales
                        (sender as Label).Font = new Font("Microsoft Sans Serif", 12.75F);
                    else
                        (sender as Label).Font = new Font("Microsoft Sans Serif", 21.75F);
                    player3.Play();
                    letra = "";
                    (sender as Label).BackColor = Color.DimGray;
                }

                if (resultado == 0 && letra != "")
                {
                    MessageBox.Show(" Existen fichas CH, LL y RR \n Esa no es una jugada válida :'(");
                    DevolverLetras();
                }
            }
        }
        //Eventos y acciones al hacer click en los label de nuestra tabla de letras
        private void Lb1_lb7_Click(object sender, EventArgs e) 
        {
            if (Turno == 0)
            {
                player.Play();
                if (cambiar == 0)
                {
                    if ((sender as Label).Text != "" && letra == "") //Solo si el label es diferente de vacio y la letra ya no contiene a otra se guarda para agregarla al tablero
                    {
                        letra = (sender as Label).Text;
                        (sender as Label).Text = "";
                    }
                    else if ((sender as Label).Text == "") //Si el label esta vacio la letra se regresa a su posicion y se borra el contenido de la variable
                    {
                        (sender as Label).Text = letra;
                        letra = "";
                    }
                }
                else if (cambiar == 1)
                {
                    if ((sender as Label).ForeColor == Color.White)
                        (sender as Label).ForeColor = Color.Red;
                    else if ((sender as Label).ForeColor == Color.Red)
                        (sender as Label).ForeColor = Color.White;
                }
            }
        }
        //Cargamos las letras iniciales del usuario > Cambiamos las letras del usuario 
        private void Cambiar_letras(object sender, EventArgs e) 
        {
            if (turno == 0)
            {
                DevolverLetras();
                if (cambiar == 0)
                {
                    DialogResult opc;
                    opc = MessageBox.Show(" Cambiar letras cuenta como un turno \n ¿Está seguro? :0", "Cambiar letras", MessageBoxButtons.OKCancel);
                    if (opc == DialogResult.OK)
                    {
                        cambiar = 1;
                        MessageBox.Show(" Seleccione las letras del atril que desea cambiar. \n Oprima cambiar cuando se decida :)", "Cambiar letras", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    cambiar = 0;
                    letras.Cargar_atril("Cambio");
                    turno++;
                    CargarTurno();
                    estadoTablero.Crear_arbol(dificultad);
                }
            }
        }

        private void lab_pasar_Click(object sender, EventArgs e)
        {
            if (turno == 0)
            {
                turno++;
                estadoTablero.Crear_arbol(dificultad);
                CargarTurno();
            }
        }

        //Se cargan las casillas que quedaron vacias al usar letras luego del turno > Se verifica la jugada / Boton jugar
        private void Llenar_letras(object sender, EventArgs e)
        {
            //Se verifica la palabra ingresada, si no es valida se devuelven las letras al atril
            if (l_7_7.Text != "")
            {
                if (estadoTablero.Verificar_palabra(ref jugada,ref puntaje) != "Success")
                    DevolverLetras();
                //Si es valida se llenan las letras del atril
                else
                {
                    if (jugada == 0)
                        jugada++;
                    lab_pasar.Visible = true; lab_jugar.Visible = false;
                    mi_puntaje = mi_puntaje + puntaje;
                    puntaje_yo.Text = Convert.ToString(mi_puntaje);
                    letras.Cargar_atril("");
                    //lb_1.Text = "A"; lb_2.Text = "B"; lb_3.Text = "A"; lb_4.Text = "D"; lb_5.Text = "A";lb_6.Text = "A"; lb_7.Text = "B";
                    turno++;
                    CargarTurno();
                    estadoTablero.Crear_arbol(dificultad); //Se crea la raiz nueva con el estado actual del tablero
                    turno--;
                    CargarTurno();
                }
            }
            //La primera jugada es un caso especial > Llenar label del centro > No necesita estar en contacto con otros labels anteriores
            else if (l_7_7.Text == "")
            {
                MessageBox.Show(" ¡Eres el primero! \n Debes colocar una letra en el centro del tablero :)", "Intenta de nuevo");
                DevolverLetras();
            }
        }
        //Buscar palabra en el diccionario para ver si es valida en nuestro juego
        private void ClickDiccionario(object sender, EventArgs e)
        {
            string palabra_buscar = Microsoft.VisualBasic.Interaction.InputBox("Ingrese palabra a verificar:","Diccionario");
            if (palabra_buscar != "")
            {
                int result = letras.Consultar_palabra(palabra_buscar.ToLower().Trim());
                if (result == 1)
                    MessageBox.Show("Palabra válida :)","Diccionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (result == 0)
                    MessageBox.Show("Palabra no válida :(","Diccionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Funcion que envia a la clase EstadoTablero y LetrasPalabras la referencias de los labels para nuestro tablero y atril
        private void Crear(object sender, EventArgs e)
        {
            foreach (Label Formlabel in this.Controls)
            {
                if (Convert.ToString(Formlabel.Tag) != "no" && Convert.ToString(Formlabel.Tag) != "atril" && Convert.ToString(Formlabel.Tag) != "puntaje")
                {
                    Label labelCargar = Formlabel;
                    estadoTablero.Cargar_tablero(ref labelCargar);
                }
                else if (Convert.ToString(Formlabel.Tag) == "atril")
                {
                    Label labelAtril = Formlabel;
                    letras.Crear_atril(ref labelAtril);
                }
                else if (Convert.ToString(Formlabel.Tag) == "puntaje")
                {
                    Label labelPuntaje = Formlabel;
                    estadoTablero.Puntaje = labelPuntaje;
                }
            }
        }
        //Funcion que devuelve las letras en el tablero o carga nuevas
        private void DevolverLetras()
        {
            lab_pasar.Visible = true; lab_jugar.Visible = false;
            string devolver="";
            foreach (Label Formlabel in this.Controls)
            {
                if (Formlabel is Label && Convert.ToString(Formlabel.Tag) != "no" && Formlabel is Label && Convert.ToString(Formlabel.Tag) != "puntaje" && Formlabel.Enabled == true && Formlabel.Text!="")
                {
                    if (Formlabel.ForeColor == Color.DodgerBlue)
                        Formlabel.Text = "?";

                    devolver = Formlabel.Text;
                    Formlabel.Text = "";
                    Formlabel.BackColor = Color.Transparent;
                    letras.Cargar_atril(devolver);
                }
            }
        }
        //Funcion para devolver todas las letras puestas en el tablero
        private void lab_deshacer_Click(object sender, EventArgs e)
        {
            if (turno == 0)
            {
                if (letra == "")
                {
                    DevolverLetras();
                }
                else MessageBox.Show("Tienes una letra en mano\nDebes devolverla antes D:", "Error");
            }
        }
        private void CargarTurno()
        {
            if (Turno == 0)
                lab_turno.Text = Usuario;            
            else if (Turno == 1)
                lab_turno.Text = "JARVIS";
            
                
        }
    }
}
