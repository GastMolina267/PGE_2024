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
            btnIniciarBatalla.Location = new Point(70, 88);
            btnIniciarBatalla.Name = "btnIniciarBatalla";
            btnIniciarBatalla.Size = new Size(75, 23);
            btnIniciarBatalla.TabIndex = 0;
            btnIniciarBatalla.Text = "Iniciar";
            btnIniciarBatalla.UseVisualStyleBackColor = true;
            btnIniciarBatalla.Click += btnIniciarBatalla_Click;
            // 
            // comboBoxSeleccionPokemon
            // 
            comboBoxSeleccionPokemon.FormattingEnabled = true;
            comboBoxSeleccionPokemon.Items.AddRange(new object[] { "Charmander", "Squirtle", "Bulbasaur" });
            comboBoxSeleccionPokemon.Location = new Point(210, 89);
            comboBoxSeleccionPokemon.Name = "comboBoxSeleccionPokemon";
            comboBoxSeleccionPokemon.Size = new Size(121, 23);
            comboBoxSeleccionPokemon.TabIndex = 1;
            comboBoxSeleccionPokemon.Text = "Selección Pokemon";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 284);
            Controls.Add(comboBoxSeleccionPokemon);
            Controls.Add(btnIniciarBatalla);
            Name = "FormPrincipal";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnIniciarBatalla;
        private ComboBox comboBoxSeleccionPokemon;
    }
}
