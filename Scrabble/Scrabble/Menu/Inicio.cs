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
    public partial class Inicio : Form
    {
        SoundPlayer player = new SoundPlayer(@"Sonidos\Click.wav");
        SoundPlayer player2 = new SoundPlayer(@"Sonidos\But.wav");
        SoundPlayer player3 = new SoundPlayer(@"Sonidos\ClickFast.wav");
        Tablero tablero = new Tablero();
        public Inicio()
        {
            InitializeComponent();
        }
        //El formulario se almacena dos veces para acelerar el programa
        protected override CreateParams CreateParams 
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        //Se carga el gif titulo del menu inicio
        private void Inicio_Load(object sender, EventArgs e) 
        {
            pbScrabble.Image = Image.FromFile(@"Imagenes\Scrabble.gif");
            pbScrabble.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        //Boton > Salir de la aplicacion
        private void ButtSalir_Click(object sender, EventArgs e) 
        {
            player.Play();
            if (buttSalir.Text=="SALIR   ")
                Application.Exit();
            else if (buttSalir.Text=="Comenzar")
            {
                buttSalir.Text = "Atras";
                pbInstruct.Visible = true;
                pbInstruct.Image = Image.FromFile(@"Imagenes\BotonInstrucciones.gif");
            }
            else if (buttSalir.Text=="Atras")
            {
                pbInstruct.Visible = false;
                pbInstruct.Image = Image.FromFile(@"Imagenes\Empezar.png");
                Mostrar();
            }
            
        }
        //Boton > Jugar > Abrimos el form tablero
        private void ButtJugar_Click(object sender, EventArgs e)
        {
            player.Play();
            tablero.Usuario = Microsoft.VisualBasic.Interaction.InputBox(" Hola! Soy Jarvis :) \n Vamos a jugar un rato... \n\n Ingresa tu nombre de usuario:", "Usuario","").ToUpper().Trim();
            if (tablero.Usuario != "Usuario" && tablero.Usuario != "") 
            {
                if (tablero.Usuario != "JARVIS")
                {
                    //Dificultad de la IA 
                    if (lab_facil.ForeColor == Color.Crimson)
                        tablero.Dificultad = 5;
                    else if (lab_normal.ForeColor == Color.Crimson)
                        tablero.Dificultad = 6;
                    else if (lab_dificil.ForeColor == Color.Crimson)
                        tablero.Dificultad = 7;
                    //Primer turno del juego
                    if (lab_usuario.ForeColor == Color.Crimson)
                        tablero.Turno = 0;
                    else if (lab_jarvis.ForeColor == Color.Crimson)
                        tablero.Turno = 1;
                    tablero.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Oye, ese es mi nombre >:( \n Intenta de nuevo...", "No quiero", MessageBoxButtons.OK);
            }
        }
        //Boton > Ver instrucciones del juego
        private void ButtInstrucciones_Click(object sender, EventArgs e) 
        {
            player.Play();
            Esconder();
            pbInstruct.Image = Image.FromFile(@"Imagenes\Empezar.png");
            pbInstruct.Visible = true;
            buttSalir.Text = "Comenzar";
        }
        //Boton > Ver puntajes acumulados
        private void ButtPuntajes_Click(object sender, EventArgs e) 
        {
           player.Play();
        }
        //Boton > Opciones del juego
        private void ButtOpciones_Click(object sender, EventArgs e) 
        {
            player.Play();
            Esconder();
            lb_dificultad.Visible = true;
            lab_inicio.Visible = true;
            lab_facil.Visible = true;
            lab_normal.Visible = true;
            lab_dificil.Visible = true;
            lab_usuario.Visible = true;
            lab_jarvis.Visible = true;

        }
        //Sonido cuando algun boton obtiene el focus
        private void Butt_GotFocus(object sender, EventArgs e) 
        {
            player2.Play();
        }
        //Se esconde el menu para abrir la opcion seleccionada
        private void Esconder()
        {
            buttJugar.Visible = false;
            buttInstrucciones.Visible = false;
            buttOpciones.Visible = false;
            buttSalir.Text = "Atras";
        }
        //Se vuelve a mostrar el menu
        private void Mostrar()
        {
            buttJugar.Visible = true;
            buttInstrucciones.Visible = true;
            buttOpciones.Visible = true;
            lb_dificultad.Visible = false;
            lab_inicio.Visible = false;
            lab_facil.Visible = false;
            lab_normal.Visible = false;
            lab_dificil.Visible = false;
            lab_usuario.Visible = false;
            lab_jarvis.Visible = false;
            buttSalir.Text = "SALIR   ";
        }
        //Boton dificultad normal
        private void lab_normal_Click(object sender, EventArgs e)
        {
            player3.Play();
            lab_facil.ForeColor = Color.Black;
            lab_normal.ForeColor = Color.Crimson;
            lab_dificil.ForeColor = Color.Black;
        }
        //Boton dificultad facil
        private void lab_facil_Click(object sender, EventArgs e)
        {
            player3.Play();
            lab_facil.ForeColor = Color.Crimson;
            lab_normal.ForeColor = Color.Black;
            lab_dificil.ForeColor = Color.Black;
        }
        //Boton dificultad dificil
        private void lab_dificil_Click(object sender, EventArgs e)
        {
            player3.Play();
            lab_facil.ForeColor = Color.Black;
            lab_normal.ForeColor = Color.Black;
            lab_dificil.ForeColor = Color.Crimson;
        }
        //Boton turno de la IA
        private void lab_jarvis_Click(object sender, EventArgs e)
        {
            player3.Play();
            lab_usuario.ForeColor = Color.Black;
            lab_jarvis.ForeColor = Color.Crimson;
        }
        //Boton turno del usuario
        private void lab_usuario_Click(object sender, EventArgs e)
        {
            player3.Play();
            lab_usuario.ForeColor = Color.Crimson;
            lab_jarvis.ForeColor = Color.Black;
        }
    }
}
