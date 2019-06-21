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
        string letra=""; //Guarda la letra a ingresar en el tablero
        int cambiar = 0, jugada = 0, mi_puntaje = 0, puntaje;
        LetrasPalabras letras = new LetrasPalabras(); //Clase donde se encuentra contenido el diccionario de letras
        EstadoTablero estadoTablero = new EstadoTablero(); //Clase donde creamos el tablero con la clase casillas
        SoundPlayer player = new SoundPlayer(@"Sonidos\Click.wav");
        SoundPlayer player2 = new SoundPlayer(@"Sonidos\But.wav");
        SoundPlayer player3 = new SoundPlayer(@"Sonidos\Cof.wav");

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
            int resultado=0;
            if (letra != "")
            {
                lab_pasar.Visible = false; lab_jugar.Visible = true; //Para que no cambie el boton pasar si la letra esta vacia
            }
            if ((sender as Label).Text == "" && letra != "")
            {
                (sender as Label).Text = letra;
                resultado=estadoTablero.Cargar_jugada((sender as Label).Text, (sender as Label).Name);
                if (letra == "CH" || letra == "LL" || letra == "RR") //Ajustamos las letras especiales
                    (sender as Label).Font = new Font("Microsoft Sans Serif", 12.75F);
                else
                    (sender as Label).Font = new Font("Microsoft Sans Serif", 21.75F);
                player3.Play();
                letra = "";
                (sender as Label).BackColor = Color.DimGray;
            }   

            if (resultado==0)
            {
                MessageBox.Show(" Existen fichas CH, LL y RR \n Esa no es una jugada válida :'(");
                DevolverLetras();
            }
        }
        //Eventos y acciones al hacer click en los label de nuestra tabla de letras
        private void Lb1_lb7_Click(object sender, EventArgs e) 
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
            else if (cambiar==1)
            {
                if ((sender as Label).ForeColor == Color.White)
                    (sender as Label).ForeColor = Color.Red;
                else if ((sender as Label).ForeColor == Color.Red)
                    (sender as Label).ForeColor = Color.White;  
            }
        }
        //Al iniciar el tablero creamos el tablero y cargamos el atril del usuario
        private void Tablero_Load(object sender, EventArgs e) 
        {
            Crear(sender, e);
            letras.Cargar_atril("");
        }
        //Cargamos las letras iniciales del usuario > Cambiamos las letras del usuario 
        private void Cambiar_letras(object sender, EventArgs e) 
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
                    estadoTablero.Crear_arbol(); //Se crea la raiz nueva con el estado actual del tablero
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
                if (Convert.ToString(Formlabel.Tag) != "no" && Convert.ToString(Formlabel.Tag) != "atril")
                {
                    Label labelCargar = Formlabel;
                    estadoTablero.Cargar_tablero(ref labelCargar);
                }
                else if (Convert.ToString(Formlabel.Tag) == "atril")
                {
                    Label labelAtril = Formlabel;
                    letras.Crear_atril(ref labelAtril);
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
                if (Formlabel is Label && Convert.ToString(Formlabel.Tag) != "no" && Formlabel.Enabled == true && Formlabel.Text!="")
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
            if (letra == "")
            {
                DevolverLetras();
            }
            else MessageBox.Show("Tienes una letra en mano\nDebes devolverla antes D:","Error");
        }
    }
}
