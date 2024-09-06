namespace Tarea09
{
    partial class FormMain
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
            btnOpenCalculator = new Button();
            btnOpenFileManager = new Button();
            SuspendLayout();
            // 
            // btnOpenCalculator
            // 
            btnOpenCalculator.Location = new Point(125, 119);
            btnOpenCalculator.Name = "btnOpenCalculator";
            btnOpenCalculator.Size = new Size(81, 23);
            btnOpenCalculator.TabIndex = 0;
            btnOpenCalculator.Text = "Calculator";
            btnOpenCalculator.UseVisualStyleBackColor = true;
            btnOpenCalculator.Click += btnOpenCalculator_Click;
            // 
            // btnOpenFileManager
            // 
            btnOpenFileManager.Location = new Point(238, 119);
            btnOpenFileManager.Name = "btnOpenFileManager";
            btnOpenFileManager.Size = new Size(86, 23);
            btnOpenFileManager.TabIndex = 1;
            btnOpenFileManager.Text = "FileManager";
            btnOpenFileManager.UseVisualStyleBackColor = true;
            btnOpenFileManager.Click += btnOpenFileManager_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 299);
            Controls.Add(btnOpenFileManager);
            Controls.Add(btnOpenCalculator);
            Name = "FormMain";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpenCalculator;
        private Button btnOpenFileManager;
    }
}
