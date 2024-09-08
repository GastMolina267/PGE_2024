namespace Tarea09
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIniciarBatalla = new Button();
            comboBoxSeleccionPokemon = new ComboBox();
            SuspendLayout();
            // 
            // btnIniciarBatalla
            // 
            btnIniciarBatalla.BackColor = Color.Yellow;
            btnIniciarBatalla.Font = new Font("Determination Sans Web", 12F, FontStyle.Bold);
            btnIniciarBatalla.ForeColor = Color.DodgerBlue;
            btnIniciarBatalla.Location = new Point(114, 73);
            btnIniciarBatalla.Name = "btnIniciarBatalla";
            btnIniciarBatalla.Size = new Size(75, 23);
            btnIniciarBatalla.TabIndex = 0;
            btnIniciarBatalla.Text = "Iniciar";
            btnIniciarBatalla.UseVisualStyleBackColor = false;
            btnIniciarBatalla.Click += btnIniciarBatalla_Click;
            // 
            // comboBoxSeleccionPokemon
            // 
            comboBoxSeleccionPokemon.Font = new Font("Determination Sans Web", 12F, FontStyle.Bold);
            comboBoxSeleccionPokemon.FormattingEnabled = true;
            comboBoxSeleccionPokemon.Items.AddRange(new object[] { "Charmander", "Squirtle", "Bulbasaur" });
            comboBoxSeleccionPokemon.Location = new Point(242, 73);
            comboBoxSeleccionPokemon.Name = "comboBoxSeleccionPokemon";
            comboBoxSeleccionPokemon.Size = new Size(157, 24);
            comboBoxSeleccionPokemon.TabIndex = 1;
            comboBoxSeleccionPokemon.Text = "Selección Pokemon";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Logo;
            ClientSize = new Size(463, 287);
            Controls.Add(comboBoxSeleccionPokemon);
            Controls.Add(btnIniciarBatalla);
            DoubleBuffered = true;
            Name = "FormPrincipal";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnIniciarBatalla;
        private ComboBox comboBoxSeleccionPokemon;
    }
}
