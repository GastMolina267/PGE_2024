namespace RegistroDeGastos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgvGastos = new System.Windows.Forms.DataGridView();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblTotalConvertido = new System.Windows.Forms.Label();
            this.btnConvertir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.Location = new System.Drawing.Point(112, 77);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarGasto.TabIndex = 0;
            this.btnAgregarGasto.Text = "button1";
            this.btnAgregarGasto.UseVisualStyleBackColor = true;
            this.btnAgregarGasto.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // cbMoneda
            // 
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(231, 77);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(121, 21);
            this.cbMoneda.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(112, 25);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // dgvGastos
            // 
            this.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastos.Location = new System.Drawing.Point(112, 118);
            this.dgvGastos.Name = "dgvGastos";
            this.dgvGastos.Size = new System.Drawing.Size(240, 150);
            this.dgvGastos.TabIndex = 3;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(112, 51);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 4;
            // 
            // lblTotalConvertido
            // 
            this.lblTotalConvertido.AutoSize = true;
            this.lblTotalConvertido.Location = new System.Drawing.Point(109, 325);
            this.lblTotalConvertido.Name = "lblTotalConvertido";
            this.lblTotalConvertido.Size = new System.Drawing.Size(35, 13);
            this.lblTotalConvertido.TabIndex = 5;
            this.lblTotalConvertido.Text = "label1";
            // 
            // btnConvertir
            // 
            this.btnConvertir.Location = new System.Drawing.Point(112, 285);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(75, 23);
            this.btnConvertir.TabIndex = 6;
            this.btnConvertir.Text = "button1";
            this.btnConvertir.UseVisualStyleBackColor = true;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 366);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.lblTotalConvertido);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.dgvGastos);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cbMoneda);
            this.Controls.Add(this.btnAgregarGasto);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarGasto;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgvGastos;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblTotalConvertido;
        private System.Windows.Forms.Button btnConvertir;
    }
}

