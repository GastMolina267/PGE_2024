namespace Tarea09
{
    partial class FormFileManager
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
            btnCreateFile = new Button();
            btnReadFile = new Button();
            btnBackToMain = new Button();
            SuspendLayout();
            // 
            // btnCreateFile
            // 
            btnCreateFile.Location = new Point(73, 84);
            btnCreateFile.Name = "btnCreateFile";
            btnCreateFile.Size = new Size(75, 23);
            btnCreateFile.TabIndex = 0;
            btnCreateFile.Text = "CreateFile";
            btnCreateFile.UseVisualStyleBackColor = true;
            btnCreateFile.Click += btnCreateFile_Click;
            // 
            // btnReadFile
            // 
            btnReadFile.Location = new Point(230, 84);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(75, 23);
            btnReadFile.TabIndex = 1;
            btnReadFile.Text = "ReadFile";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // btnBackToMain
            // 
            btnBackToMain.Location = new Point(150, 169);
            btnBackToMain.Name = "btnBackToMain";
            btnBackToMain.Size = new Size(75, 23);
            btnBackToMain.TabIndex = 2;
            btnBackToMain.Text = "Volver";
            btnBackToMain.UseVisualStyleBackColor = true;
            btnBackToMain.Click += btnBackToMain_Click;
            // 
            // FormFileManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 228);
            Controls.Add(btnBackToMain);
            Controls.Add(btnReadFile);
            Controls.Add(btnCreateFile);
            Name = "FormFileManager";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreateFile;
        private Button btnReadFile;
        private Button btnBackToMain;
    }
}