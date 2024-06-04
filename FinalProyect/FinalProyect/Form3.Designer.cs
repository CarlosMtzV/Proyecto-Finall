namespace FinalProyect
{
    partial class Form3
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
            dataGridViewStudentsGrades = new DataGridView();
            btnExportStudent = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudentsGrades).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudentsGrades
            // 
            dataGridViewStudentsGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudentsGrades.Location = new Point(234, 44);
            dataGridViewStudentsGrades.Name = "dataGridViewStudentsGrades";
            dataGridViewStudentsGrades.Size = new Size(440, 230);
            dataGridViewStudentsGrades.TabIndex = 20;
            // 
            // btnExportStudent
            // 
            btnExportStudent.BackColor = Color.Thistle;
            btnExportStudent.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            btnExportStudent.Location = new Point(491, 344);
            btnExportStudent.Name = "btnExportStudent";
            btnExportStudent.Size = new Size(105, 62);
            btnExportStudent.TabIndex = 33;
            btnExportStudent.Text = "ADD Studnets";
            btnExportStudent.UseVisualStyleBackColor = false;
            btnExportStudent.Click += btnExportStudent_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportStudent);
            Controls.Add(dataGridViewStudentsGrades);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudentsGrades).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewStudentsGrades;
        private Button btnExportStudent;
    }
}