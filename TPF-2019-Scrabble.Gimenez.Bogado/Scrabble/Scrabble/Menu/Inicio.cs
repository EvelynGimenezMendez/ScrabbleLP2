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
            Application.Exit();
        }
        //Boton > Jugar > Abrimos el form tablero
        private void ButtJugar_Click(object sender, EventArgs e)
        {
            player.Play();
            tablero.Show();
            this.Hide();
        }
        //Boton > Ver instrucciones del juego
        private void ButtInstrucciones_Click(object sender, EventArgs e) 
        {
            player.Play();
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
        }
        //Sonido cuando algun boton obtiene el focus
        private void Butt_GotFocus(object sender, EventArgs e) 
        {
            player2.Play();
        }
    }
}
