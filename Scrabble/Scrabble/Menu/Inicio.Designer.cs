namespace Scrabble
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.pbScrabble = new System.Windows.Forms.PictureBox();
            this.buttJugar = new System.Windows.Forms.Button();
            this.buttInstrucciones = new System.Windows.Forms.Button();
            this.buttOpciones = new System.Windows.Forms.Button();
            this.buttSalir = new System.Windows.Forms.Button();
            this.pbInstruct = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_dificultad = new System.Windows.Forms.Label();
            this.lab_facil = new System.Windows.Forms.Label();
            this.lab_normal = new System.Windows.Forms.Label();
            this.lab_dificil = new System.Windows.Forms.Label();
            this.lab_inicio = new System.Windows.Forms.Label();
            this.lab_jarvis = new System.Windows.Forms.Label();
            this.lab_usuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbScrabble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstruct)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScrabble
            // 
            this.pbScrabble.Location = new System.Drawing.Point(0, 35);
            this.pbScrabble.Name = "pbScrabble";
            this.pbScrabble.Size = new System.Drawing.Size(480, 47);
            this.pbScrabble.TabIndex = 0;
            this.pbScrabble.TabStop = false;
            // 
            // buttJugar
            // 
            this.buttJugar.BackColor = System.Drawing.Color.Transparent;
            this.buttJugar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttJugar.BackgroundImage")));
            this.buttJugar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttJugar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttJugar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttJugar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttJugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttJugar.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttJugar.ForeColor = System.Drawing.Color.Black;
            this.buttJugar.Location = new System.Drawing.Point(109, 149);
            this.buttJugar.Name = "buttJugar";
            this.buttJugar.Size = new System.Drawing.Size(265, 103);
            this.buttJugar.TabIndex = 1;
            this.buttJugar.Text = " JUGAR ";
            this.buttJugar.UseVisualStyleBackColor = false;
            this.buttJugar.Click += new System.EventHandler(this.ButtJugar_Click);
            this.buttJugar.MouseEnter += new System.EventHandler(this.Butt_GotFocus);
            // 
            // buttInstrucciones
            // 
            this.buttInstrucciones.BackColor = System.Drawing.Color.Transparent;
            this.buttInstrucciones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttInstrucciones.BackgroundImage")));
            this.buttInstrucciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttInstrucciones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttInstrucciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttInstrucciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttInstrucciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttInstrucciones.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttInstrucciones.ForeColor = System.Drawing.Color.Black;
            this.buttInstrucciones.Location = new System.Drawing.Point(145, 301);
            this.buttInstrucciones.Name = "buttInstrucciones";
            this.buttInstrucciones.Size = new System.Drawing.Size(193, 73);
            this.buttInstrucciones.TabIndex = 2;
            this.buttInstrucciones.Text = "INSTRUCCIONES";
            this.buttInstrucciones.UseVisualStyleBackColor = false;
            this.buttInstrucciones.Click += new System.EventHandler(this.ButtInstrucciones_Click);
            this.buttInstrucciones.MouseEnter += new System.EventHandler(this.Butt_GotFocus);
            // 
            // buttOpciones
            // 
            this.buttOpciones.BackColor = System.Drawing.Color.Transparent;
            this.buttOpciones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttOpciones.BackgroundImage")));
            this.buttOpciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttOpciones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttOpciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttOpciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttOpciones.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttOpciones.ForeColor = System.Drawing.Color.Black;
            this.buttOpciones.Location = new System.Drawing.Point(145, 429);
            this.buttOpciones.Name = "buttOpciones";
            this.buttOpciones.Size = new System.Drawing.Size(193, 73);
            this.buttOpciones.TabIndex = 4;
            this.buttOpciones.Text = "OPCIONES";
            this.buttOpciones.UseVisualStyleBackColor = false;
            this.buttOpciones.Click += new System.EventHandler(this.ButtOpciones_Click);
            this.buttOpciones.MouseEnter += new System.EventHandler(this.Butt_GotFocus);
            // 
            // buttSalir
            // 
            this.buttSalir.BackColor = System.Drawing.Color.Transparent;
            this.buttSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttSalir.BackgroundImage")));
            this.buttSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttSalir.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttSalir.ForeColor = System.Drawing.Color.Maroon;
            this.buttSalir.Location = new System.Drawing.Point(145, 540);
            this.buttSalir.Name = "buttSalir";
            this.buttSalir.Size = new System.Drawing.Size(193, 73);
            this.buttSalir.TabIndex = 5;
            this.buttSalir.Text = "SALIR   ";
            this.buttSalir.UseVisualStyleBackColor = false;
            this.buttSalir.Click += new System.EventHandler(this.ButtSalir_Click);
            this.buttSalir.MouseEnter += new System.EventHandler(this.Butt_GotFocus);
            // 
            // pbInstruct
            // 
            this.pbInstruct.BackColor = System.Drawing.Color.Transparent;
            this.pbInstruct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbInstruct.Location = new System.Drawing.Point(0, 126);
            this.pbInstruct.Name = "pbInstruct";
            this.pbInstruct.Size = new System.Drawing.Size(480, 382);
            this.pbInstruct.TabIndex = 6;
            this.pbInstruct.TabStop = false;
            this.pbInstruct.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // lb_dificultad
            // 
            this.lb_dificultad.AutoSize = true;
            this.lb_dificultad.BackColor = System.Drawing.Color.Transparent;
            this.lb_dificultad.Font = new System.Drawing.Font("Kristen ITC", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dificultad.Image = ((System.Drawing.Image)(resources.GetObject("lb_dificultad.Image")));
            this.lb_dificultad.Location = new System.Drawing.Point(102, 149);
            this.lb_dificultad.Name = "lb_dificultad";
            this.lb_dificultad.Size = new System.Drawing.Size(272, 47);
            this.lb_dificultad.TabIndex = 8;
            this.lb_dificultad.Text = "DIFICULTAD";
            this.lb_dificultad.Visible = false;
            // 
            // lab_facil
            // 
            this.lab_facil.AutoSize = true;
            this.lab_facil.BackColor = System.Drawing.Color.Transparent;
            this.lab_facil.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_facil.ForeColor = System.Drawing.Color.Black;
            this.lab_facil.Location = new System.Drawing.Point(40, 234);
            this.lab_facil.Name = "lab_facil";
            this.lab_facil.Size = new System.Drawing.Size(91, 39);
            this.lab_facil.TabIndex = 9;
            this.lab_facil.Text = "Facil";
            this.lab_facil.Visible = false;
            this.lab_facil.Click += new System.EventHandler(this.lab_facil_Click);
            // 
            // lab_normal
            // 
            this.lab_normal.AutoSize = true;
            this.lab_normal.BackColor = System.Drawing.Color.Transparent;
            this.lab_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_normal.ForeColor = System.Drawing.Color.Crimson;
            this.lab_normal.Location = new System.Drawing.Point(171, 234);
            this.lab_normal.Name = "lab_normal";
            this.lab_normal.Size = new System.Drawing.Size(130, 39);
            this.lab_normal.TabIndex = 10;
            this.lab_normal.Text = "Normal";
            this.lab_normal.Visible = false;
            this.lab_normal.Click += new System.EventHandler(this.lab_normal_Click);
            // 
            // lab_dificil
            // 
            this.lab_dificil.AutoSize = true;
            this.lab_dificil.BackColor = System.Drawing.Color.Transparent;
            this.lab_dificil.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_dificil.ForeColor = System.Drawing.Color.Black;
            this.lab_dificil.Location = new System.Drawing.Point(333, 234);
            this.lab_dificil.Name = "lab_dificil";
            this.lab_dificil.Size = new System.Drawing.Size(102, 39);
            this.lab_dificil.TabIndex = 11;
            this.lab_dificil.Text = "Dificil";
            this.lab_dificil.Visible = false;
            this.lab_dificil.Click += new System.EventHandler(this.lab_dificil_Click);
            // 
            // lab_inicio
            // 
            this.lab_inicio.AutoSize = true;
            this.lab_inicio.BackColor = System.Drawing.Color.Transparent;
            this.lab_inicio.Font = new System.Drawing.Font("Kristen ITC", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_inicio.Image = ((System.Drawing.Image)(resources.GetObject("lab_inicio.Image")));
            this.lab_inicio.Location = new System.Drawing.Point(91, 352);
            this.lab_inicio.Name = "lab_inicio";
            this.lab_inicio.Size = new System.Drawing.Size(298, 44);
            this.lab_inicio.TabIndex = 12;
            this.lab_inicio.Text = "PRIMER TURNO";
            this.lab_inicio.Visible = false;
            // 
            // lab_jarvis
            // 
            this.lab_jarvis.AutoSize = true;
            this.lab_jarvis.BackColor = System.Drawing.Color.Transparent;
            this.lab_jarvis.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_jarvis.ForeColor = System.Drawing.Color.Black;
            this.lab_jarvis.Location = new System.Drawing.Point(279, 429);
            this.lab_jarvis.Name = "lab_jarvis";
            this.lab_jarvis.Size = new System.Drawing.Size(110, 39);
            this.lab_jarvis.TabIndex = 14;
            this.lab_jarvis.Text = "Jarvis";
            this.lab_jarvis.Visible = false;
            this.lab_jarvis.Click += new System.EventHandler(this.lab_jarvis_Click);
            // 
            // lab_usuario
            // 
            this.lab_usuario.AutoSize = true;
            this.lab_usuario.BackColor = System.Drawing.Color.Transparent;
            this.lab_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_usuario.ForeColor = System.Drawing.Color.Crimson;
            this.lab_usuario.Location = new System.Drawing.Point(129, 429);
            this.lab_usuario.Name = "lab_usuario";
            this.lab_usuario.Size = new System.Drawing.Size(59, 39);
            this.lab_usuario.TabIndex = 15;
            this.lab_usuario.Text = "Yo";
            this.lab_usuario.Visible = false;
            this.lab_usuario.Click += new System.EventHandler(this.lab_usuario_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(480, 650);
            this.Controls.Add(this.lab_usuario);
            this.Controls.Add(this.lab_jarvis);
            this.Controls.Add(this.lab_inicio);
            this.Controls.Add(this.lab_dificil);
            this.Controls.Add(this.lab_normal);
            this.Controls.Add(this.lab_facil);
            this.Controls.Add(this.lb_dificultad);
            this.Controls.Add(this.buttSalir);
            this.Controls.Add(this.buttOpciones);
            this.Controls.Add(this.buttInstrucciones);
            this.Controls.Add(this.buttJugar);
            this.Controls.Add(this.pbScrabble);
            this.Controls.Add(this.pbInstruct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scrabble";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbScrabble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstruct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScrabble;
        private System.Windows.Forms.Button buttJugar;
        private System.Windows.Forms.Button buttInstrucciones;
        private System.Windows.Forms.Button buttOpciones;
        private System.Windows.Forms.Button buttSalir;
        private System.Windows.Forms.PictureBox pbInstruct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_dificultad;
        private System.Windows.Forms.Label lab_facil;
        private System.Windows.Forms.Label lab_normal;
        private System.Windows.Forms.Label lab_dificil;
        private System.Windows.Forms.Label lab_inicio;
        private System.Windows.Forms.Label lab_jarvis;
        private System.Windows.Forms.Label lab_usuario;
    }
}