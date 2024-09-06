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
            btnCreateFile.BackColor = Color.Maroon;
            btnCreateFile.Font = new Font("Determination Sans Web", 15.75F, FontStyle.Bold);
            btnCreateFile.Location = new Point(49, 69);
            btnCreateFile.Name = "btnCreateFile";
            btnCreateFile.Size = new Size(122, 32);
            btnCreateFile.TabIndex = 0;
            btnCreateFile.TabStop = false;
            btnCreateFile.Text = "CreateFile";
            btnCreateFile.UseVisualStyleBackColor = false;
            btnCreateFile.Click += btnCreateFile_Click;
            // 
            // btnReadFile
            // 
            btnReadFile.BackColor = Color.Maroon;
            btnReadFile.Font = new Font("Determination Sans Web", 15.75F, FontStyle.Bold);
            btnReadFile.Location = new Point(206, 69);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(122, 32);
            btnReadFile.TabIndex = 1;
            btnReadFile.TabStop = false;
            btnReadFile.Text = "ReadFile";
            btnReadFile.UseVisualStyleBackColor = false;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // btnBackToMain
            // 
            btnBackToMain.BackColor = Color.Maroon;
            btnBackToMain.Font = new Font("Determination Sans Web", 15.75F, FontStyle.Bold);
            btnBackToMain.Location = new Point(126, 154);
            btnBackToMain.Name = "btnBackToMain";
            btnBackToMain.Size = new Size(122, 32);
            btnBackToMain.TabIndex = 2;
            btnBackToMain.TabStop = false;
            btnBackToMain.Text = "Volver";
            btnBackToMain.UseVisualStyleBackColor = false;
            btnBackToMain.Click += btnBackToMain_Click;
            // 
            // FormFileManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(377, 228);
            Controls.Add(btnBackToMain);
            Controls.Add(btnReadFile);
            Controls.Add(btnCreateFile);
            MinimumSize = new Size(393, 267);
            Name = "FormFileManager";
            Text = "File_Manager";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreateFile;
        private Button btnReadFile;
        private Button btnBackToMain;
    }
}