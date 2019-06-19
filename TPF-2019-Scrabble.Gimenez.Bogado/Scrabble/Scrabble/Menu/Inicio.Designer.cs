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
            this.buttPuntajes = new System.Windows.Forms.Button();
            this.buttOpciones = new System.Windows.Forms.Button();
            this.buttSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbScrabble)).BeginInit();
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
            this.buttInstrucciones.Location = new System.Drawing.Point(145, 276);
            this.buttInstrucciones.Name = "buttInstrucciones";
            this.buttInstrucciones.Size = new System.Drawing.Size(193, 73);
            this.buttInstrucciones.TabIndex = 2;
            this.buttInstrucciones.Text = "INSTRUCCIONES";
            this.buttInstrucciones.UseVisualStyleBackColor = false;
            this.buttInstrucciones.Click += new System.EventHandler(this.ButtInstrucciones_Click);
            this.buttInstrucciones.MouseEnter += new System.EventHandler(this.Butt_GotFocus);
            // 
            // buttPuntajes
            // 
            this.buttPuntajes.BackColor = System.Drawing.Color.Transparent;
            this.buttPuntajes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttPuntajes.BackgroundImage")));
            this.buttPuntajes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttPuntajes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttPuntajes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttPuntajes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttPuntajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttPuntajes.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttPuntajes.ForeColor = System.Drawing.Color.Black;
            this.buttPuntajes.Location = new System.Drawing.Point(145, 364);
            this.buttPuntajes.Name = "buttPuntajes";
            this.buttPuntajes.Size = new System.Drawing.Size(193, 73);
            this.buttPuntajes.TabIndex = 3;
            this.buttPuntajes.Text = "PUNTAJES";
            this.buttPuntajes.UseVisualStyleBackColor = false;
            this.buttPuntajes.Click += new System.EventHandler(this.ButtPuntajes_Click);
            this.buttPuntajes.MouseEnter += new System.EventHandler(this.Butt_GotFocus);
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
            this.buttOpciones.Location = new System.Drawing.Point(145, 452);
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
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(480, 650);
            this.Controls.Add(this.buttSalir);
            this.Controls.Add(this.buttOpciones);
            this.Controls.Add(this.buttPuntajes);
            this.Controls.Add(this.buttInstrucciones);
            this.Controls.Add(this.buttJugar);
            this.Controls.Add(this.pbScrabble);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scrabble";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbScrabble)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScrabble;
        private System.Windows.Forms.Button buttJugar;
        private System.Windows.Forms.Button buttInstrucciones;
        private System.Windows.Forms.Button buttPuntajes;
        private System.Windows.Forms.Button buttOpciones;
        private System.Windows.Forms.Button buttSalir;
    }
}