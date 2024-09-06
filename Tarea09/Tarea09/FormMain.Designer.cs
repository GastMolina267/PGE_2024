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
            btnOpenCalculator.BackColor = Color.Maroon;
            btnOpenCalculator.Font = new Font("Determination Sans Web", 15.75F, FontStyle.Bold);
            btnOpenCalculator.Location = new Point(79, 121);
            btnOpenCalculator.Name = "btnOpenCalculator";
            btnOpenCalculator.Size = new Size(142, 60);
            btnOpenCalculator.TabIndex = 0;
            btnOpenCalculator.TabStop = false;
            btnOpenCalculator.Text = "Calculator";
            btnOpenCalculator.UseVisualStyleBackColor = false;
            btnOpenCalculator.Click += btnOpenCalculator_Click;
            // 
            // btnOpenFileManager
            // 
            btnOpenFileManager.BackColor = Color.Maroon;
            btnOpenFileManager.Font = new Font("Determination Sans Web", 15.75F, FontStyle.Bold);
            btnOpenFileManager.Location = new Point(242, 121);
            btnOpenFileManager.Name = "btnOpenFileManager";
            btnOpenFileManager.Size = new Size(142, 60);
            btnOpenFileManager.TabIndex = 1;
            btnOpenFileManager.TabStop = false;
            btnOpenFileManager.Text = "FileManager";
            btnOpenFileManager.UseVisualStyleBackColor = false;
            btnOpenFileManager.Click += btnOpenFileManager_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(462, 299);
            Controls.Add(btnOpenFileManager);
            Controls.Add(btnOpenCalculator);
            Name = "FormMain";
            Text = "Main";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpenCalculator;
        private Button btnOpenFileManager;
    }
}
