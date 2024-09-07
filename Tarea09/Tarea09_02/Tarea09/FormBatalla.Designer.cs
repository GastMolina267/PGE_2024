namespace Tarea09
{
    partial class FormBatalla
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
            lblPokemonJugador = new Label();
            lblPokemonOponente = new Label();
            lblVidaJugador = new Label();
            lblVidaOponente = new Label();
            lblMovimiento = new Label();
            lblEstadoCombate = new Label();
            btnMovimiento1 = new Button();
            btnMovimiento2 = new Button();
            btnMovimiento3 = new Button();
            btnMovimiento4 = new Button();
            btnVolver = new Button();
            progressBarJugador = new ProgressBar();
            progressBarOponente = new ProgressBar();
            SuspendLayout();
            // 
            // lblPokemonJugador
            // 
            lblPokemonJugador.AutoSize = true;
            lblPokemonJugador.Location = new Point(36, 154);
            lblPokemonJugador.Name = "lblPokemonJugador";
            lblPokemonJugador.Size = new Size(38, 15);
            lblPokemonJugador.TabIndex = 0;
            lblPokemonJugador.Text = "label1";
            // 
            // lblPokemonOponente
            // 
            lblPokemonOponente.AutoSize = true;
            lblPokemonOponente.Location = new Point(325, 154);
            lblPokemonOponente.Name = "lblPokemonOponente";
            lblPokemonOponente.Size = new Size(38, 15);
            lblPokemonOponente.TabIndex = 1;
            lblPokemonOponente.Text = "label1";
            // 
            // lblVidaJugador
            // 
            lblVidaJugador.AutoSize = true;
            lblVidaJugador.Location = new Point(36, 183);
            lblVidaJugador.Name = "lblVidaJugador";
            lblVidaJugador.Size = new Size(38, 15);
            lblVidaJugador.TabIndex = 2;
            lblVidaJugador.Text = "label1";
            // 
            // lblVidaOponente
            // 
            lblVidaOponente.AutoSize = true;
            lblVidaOponente.Location = new Point(325, 183);
            lblVidaOponente.Name = "lblVidaOponente";
            lblVidaOponente.Size = new Size(38, 15);
            lblVidaOponente.TabIndex = 3;
            lblVidaOponente.Text = "label1";
            // 
            // lblMovimiento
            // 
            lblMovimiento.AutoSize = true;
            lblMovimiento.Location = new Point(181, 76);
            lblMovimiento.Name = "lblMovimiento";
            lblMovimiento.Size = new Size(38, 15);
            lblMovimiento.TabIndex = 4;
            lblMovimiento.Text = "label1";
            // 
            // lblEstadoCombate
            // 
            lblEstadoCombate.AutoSize = true;
            lblEstadoCombate.Location = new Point(181, 234);
            lblEstadoCombate.Name = "lblEstadoCombate";
            lblEstadoCombate.Size = new Size(38, 15);
            lblEstadoCombate.TabIndex = 5;
            lblEstadoCombate.Text = "label1";
            // 
            // btnMovimiento1
            // 
            btnMovimiento1.Location = new Point(45, 21);
            btnMovimiento1.Name = "btnMovimiento1";
            btnMovimiento1.Size = new Size(75, 23);
            btnMovimiento1.TabIndex = 6;
            btnMovimiento1.Text = "button1";
            btnMovimiento1.UseVisualStyleBackColor = true;
            // 
            // btnMovimiento2
            // 
            btnMovimiento2.Location = new Point(126, 21);
            btnMovimiento2.Name = "btnMovimiento2";
            btnMovimiento2.Size = new Size(75, 23);
            btnMovimiento2.TabIndex = 7;
            btnMovimiento2.Text = "button2";
            btnMovimiento2.UseVisualStyleBackColor = true;
            // 
            // btnMovimiento3
            // 
            btnMovimiento3.Location = new Point(207, 21);
            btnMovimiento3.Name = "btnMovimiento3";
            btnMovimiento3.Size = new Size(75, 23);
            btnMovimiento3.TabIndex = 8;
            btnMovimiento3.Text = "button3";
            btnMovimiento3.UseVisualStyleBackColor = true;
            // 
            // btnMovimiento4
            // 
            btnMovimiento4.Location = new Point(288, 21);
            btnMovimiento4.Name = "btnMovimiento4";
            btnMovimiento4.Size = new Size(75, 23);
            btnMovimiento4.TabIndex = 9;
            btnMovimiento4.Text = "button4";
            btnMovimiento4.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(36, 230);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 10;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // progressBarJugador
            // 
            progressBarJugador.Location = new Point(36, 119);
            progressBarJugador.Name = "progressBarJugador";
            progressBarJugador.Size = new Size(100, 23);
            progressBarJugador.TabIndex = 11;
            // 
            // progressBarOponente
            // 
            progressBarOponente.Location = new Point(263, 119);
            progressBarOponente.Name = "progressBarOponente";
            progressBarOponente.Size = new Size(100, 23);
            progressBarOponente.TabIndex = 12;
            // 
            // FormBatalla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 268);
            Controls.Add(progressBarOponente);
            Controls.Add(progressBarJugador);
            Controls.Add(btnVolver);
            Controls.Add(btnMovimiento4);
            Controls.Add(btnMovimiento3);
            Controls.Add(btnMovimiento2);
            Controls.Add(btnMovimiento1);
            Controls.Add(lblEstadoCombate);
            Controls.Add(lblMovimiento);
            Controls.Add(lblVidaOponente);
            Controls.Add(lblVidaJugador);
            Controls.Add(lblPokemonOponente);
            Controls.Add(lblPokemonJugador);
            Name = "FormBatalla";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPokemonJugador;
        private Label lblPokemonOponente;
        private Label lblVidaJugador;
        private Label lblVidaOponente;
        private Label lblMovimiento;
        private Label lblEstadoCombate;
        private Button btnMovimiento1;
        private Button btnMovimiento2;
        private Button btnMovimiento3;
        private Button btnMovimiento4;
        private Button btnVolver;
        private ProgressBar progressBarJugador;
        private ProgressBar progressBarOponente;
    }
}