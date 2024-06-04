namespace FinalProyect
{
    partial class Form1
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
            btnAdd = new Button();
            txtRegistrationNumber = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridViewStudents = new DataGridView();
            label5 = new Label();
            txtLastname = new TextBox();
            btnDelete = new Button();
            btnExport = new Button();
            btnGrade = new Button();
            majorbox = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Thistle;
            btnAdd.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            btnAdd.Location = new Point(238, 322);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 51);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtRegistrationNumber
            // 
            txtRegistrationNumber.Location = new Point(111, 80);
            txtRegistrationNumber.Name = "txtRegistrationNumber";
            txtRegistrationNumber.Size = new Size(100, 23);
            txtRegistrationNumber.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(111, 118);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(111, 183);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(2, 54);
            label1.Name = "label1";
            label1.Size = new Size(177, 23);
            label1.TabIndex = 5;
            label1.Text = "Registration Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(14, 180);
            label2.Name = "label2";
            label2.Size = new Size(57, 23);
            label2.TabIndex = 6;
            label2.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(12, 118);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 6;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            label4.Location = new Point(14, 215);
            label4.Name = "label4";
            label4.Size = new Size(57, 23);
            label4.TabIndex = 7;
            label4.Text = "Major";
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(291, 65);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.Size = new Size(360, 198);
            dataGridViewStudents.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            label5.Location = new Point(12, 148);
            label5.Name = "label5";
            label5.Size = new Size(93, 23);
            label5.TabIndex = 10;
            label5.Text = "Last Name";
            // 
            // txtLastname
            // 
            txtLastname.Location = new Point(111, 148);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(100, 23);
            txtLastname.TabIndex = 9;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Thistle;
            btnDelete.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            btnDelete.Location = new Point(384, 322);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 51);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "DELTE ROW";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.Thistle;
            btnExport.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            btnExport.Location = new Point(535, 322);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(105, 62);
            btnExport.TabIndex = 12;
            btnExport.Text = "Export Files";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnGrade
            // 
            btnGrade.BackColor = Color.Thistle;
            btnGrade.Font = new Font("Sitka Text", 12F, FontStyle.Bold | FontStyle.Italic);
            btnGrade.Location = new Point(664, 322);
            btnGrade.Name = "btnGrade";
            btnGrade.Size = new Size(105, 62);
            btnGrade.TabIndex = 13;
            btnGrade.Text = "FORM GRADE";
            btnGrade.UseVisualStyleBackColor = false;
            btnGrade.Click += btnGrade_Click;
            // 
            // majorbox
            // 
            majorbox.FormattingEnabled = true;
            majorbox.Items.AddRange(new object[] { "Informatica ", "Industrial", "Mecanica", "Gestion Emp", "Electronica" });
            majorbox.Location = new Point(111, 218);
            majorbox.Name = "majorbox";
            majorbox.Size = new Size(121, 23);
            majorbox.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Subheading", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(205, -5);
            label6.Name = "label6";
            label6.Size = new Size(325, 39);
            label6.TabIndex = 15;
            label6.Text = "Registration Of Students";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(majorbox);
            Controls.Add(btnGrade);
            Controls.Add(btnExport);
            Controls.Add(btnDelete);
            Controls.Add(label5);
            Controls.Add(txtLastname);
            Controls.Add(dataGridViewStudents);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(txtRegistrationNumber);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private TextBox txtRegistrationNumber;
        private TextBox txtName;
        private TextBox txtPhone;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridViewStudents;
        private Label label5;
        private TextBox txtLastname;
        private Button btnDelete;
        private Button btnExport;
        private Button btnGrade;
        private ComboBox majorbox;
        private Label label6;
    }
}
