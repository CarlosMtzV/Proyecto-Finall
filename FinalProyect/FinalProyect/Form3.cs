using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProyect
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            InitializeDataGridView();
            UpdateDataGridView();
        }
        private void UpdateDataGridView()
        {
            // Limpiar el DataGridView
            dataGridViewStudentsGrades.Rows.Clear();

            // Agregar cada estudiante al DataGridView
            foreach (var student in Form1.students)
            {
                // Crear una nueva fila para el estudiante
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewStudentsGrades);
                row.Cells[0].Value = student.RegistrationNumber;
                row.Cells[1].Value = student.Name;
                row.Cells[2].Value = student.LastName;
                row.Cells[3].Value = "";
                


                // Agregar la fila al DataGridView
                dataGridViewStudentsGrades.Rows.Add(row);
            }
        }


        private void InitializeDataGridView()
        {
            // Agregar las columnas al DataGridView
            dataGridViewStudentsGrades.ColumnCount = 4;
            dataGridViewStudentsGrades.Columns[0].Name = "Registration Number";
            dataGridViewStudentsGrades.Columns[1].Name = "Name";
            dataGridViewStudentsGrades.Columns[2].Name = "LastName";
            dataGridViewStudentsGrades.Columns[3].Name = "Summatives";
          

        }

        private void btnExportStudent_Click(object sender, EventArgs e)
        {

        }
    }
}
