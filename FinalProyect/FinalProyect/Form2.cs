using System.Data;




using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace FinalProyect
{
    public partial class Form2 : Form
    {

        //public static List<Student> students = new List<Student>();
        public static Student[] students = new Student[0];

        public Form2()
        {
            InitializeComponent();
            InitializeDataGridView();
            UpdateDataGridView(); // Actualiza el DataGridView con los estudiantes existentes

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
                row.Cells[4].Value = "";
                row.Cells[5].Value = "";
                row.Cells[6].Value = "";
                row.Cells[7].Value = "";
                row.Cells[8].Value = "";
                row.Cells[9].Value = "";
                row.Cells[10].Value = "";

                // Agregar la fila al DataGridView
                dataGridViewStudentsGrades.Rows.Add(row);
            }
        }



        private void InitializeDataGridView()
        {
            // Agregar las columnas al DataGridView
            dataGridViewStudentsGrades.ColumnCount = 11;
            dataGridViewStudentsGrades.Columns[0].Name = "Registration Number";
            dataGridViewStudentsGrades.Columns[1].Name = "Name";
            dataGridViewStudentsGrades.Columns[2].Name = "LastName";
            dataGridViewStudentsGrades.Columns[3].Name = "Unit1";
            dataGridViewStudentsGrades.Columns[4].Name = "Unit2";
            dataGridViewStudentsGrades.Columns[5].Name = "Unit3";
            dataGridViewStudentsGrades.Columns[6].Name = "Unit4";
            dataGridViewStudentsGrades.Columns[7].Name = "Unit5";
            dataGridViewStudentsGrades.Columns[8].Name = "Unit6";
            dataGridViewStudentsGrades.Columns[9].Name = "Summative";
            dataGridViewStudentsGrades.Columns[10].Name = "Average";

        }









        private void btnAddin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnit1.Text) ||
       string.IsNullOrWhiteSpace(txtUnit2.Text) ||
       string.IsNullOrWhiteSpace(txtUnit3.Text) ||
       string.IsNullOrWhiteSpace(txtUnit4.Text) ||
       string.IsNullOrWhiteSpace(txtUnit5.Text) ||
       string.IsNullOrWhiteSpace(txtUnit6.Text))
            {
                MessageBox.Show("Please fill in all the unit grades.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si algún TextBox está vacío
            }


            double unit1, unit2, unit3, unit4, unit5, unit6;

            try
            {
                // Intentar convertir los valores de los TextBox a double
                if (!double.TryParse(txtUnit1.Text, out unit1) ||
                    !double.TryParse(txtUnit2.Text, out unit2) ||
                    !double.TryParse(txtUnit3.Text, out unit3) ||
                    !double.TryParse(txtUnit4.Text, out unit4) ||
                    !double.TryParse(txtUnit5.Text, out unit5) ||
                    !double.TryParse(txtUnit6.Text, out unit6))
                {
                    throw new FormatException("One or more grades are not valid numbers.");
                }

                if (dataGridViewStudentsGrades.SelectedRows.Count > 0)
                {
                    // Eliminar las filas seleccionadas del DataGridView y de la lista de estudiantes
                    foreach (DataGridViewRow row in dataGridViewStudentsGrades.SelectedRows)
                    {
                        row.Cells[3].Value = unit1;
                        row.Cells[4].Value = unit2;
                        row.Cells[5].Value = unit3;
                        row.Cells[6].Value = unit4;
                        row.Cells[7].Value = unit5;
                        row.Cells[8].Value = unit6;


                        // Contar cuántas unidades son menores a 7
                        int sumativas = 0;
                        if (unit1 < 7) sumativas++;
                        if (unit2 < 7) sumativas++;
                        if (unit3 < 7) sumativas++;
                        if (unit4 < 7) sumativas++;
                        if (unit5 < 7) sumativas++;
                        if (unit6 < 7) sumativas++;

                        // Actualizar la columna "Sumativas"
                        row.Cells[9].Value = sumativas;

                        //Agregar el promedio 
                        double averageGrade = CalculateAverageGrade(unit1, unit2, unit3, unit4, unit5, unit6);
                        row.Cells[10].Value = averageGrade;
                    }


                    RegistComplete();
                }
                else
                {
                    MessageBox.Show("Please select at least one row to add grade.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearFields();
        }

        private void ClearFields()
        {
            txtUnit1.Clear();
            txtUnit2.Clear();
            txtUnit3.Clear();
            txtUnit4.Clear();
            txtUnit5.Clear();
            txtUnit6.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudentsGrades.SelectedRows.Count > 0)
            {
                // Eliminar las filas seleccionadas del DataGridView y de la lista de estudiantes
                foreach (DataGridViewRow row in dataGridViewStudentsGrades.SelectedRows)
                {


                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                    row.Cells[5].Value = "";
                    row.Cells[6].Value = "";
                    row.Cells[7].Value = "";
                    row.Cells[8].Value = "";
                    row.Cells[9].Value = "";
                    row.Cells[10].Value = "";

                }
            }
            else
            {
                MessageBox.Show("Please select at least one row to Delete Grade.");
            }

            ClearFields();
        }

        private void SaveAsJson(string fileName)
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }


        private void SaveAsExcel(string fileName)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                SheetData sheetData = new SheetData();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                Row headerRow = new Row();
                foreach (DataGridViewColumn column in dataGridViewStudentsGrades.Columns)
                {
                    Cell headerCell = new Cell() { CellValue = new CellValue(column.HeaderText), DataType = CellValues.String };
                    headerRow.Append(headerCell);
                }
                sheetData.Append(headerRow);

                foreach (DataGridViewRow row in dataGridViewStudentsGrades.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Row newRow = new Row();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            Cell newCell = new Cell() { CellValue = new CellValue(cell.Value?.ToString() ?? ""), DataType = CellValues.String };
                            newRow.Append(newCell);
                        }
                        sheetData.Append(newRow);
                    }
                }

                workbookPart.Workbook.Save();
            }
        }

        private void SaveAsText(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Escribir encabezados
                for (int i = 0; i < dataGridViewStudentsGrades.ColumnCount; i++)
                {
                    writer.Write(dataGridViewStudentsGrades.Columns[i].HeaderText);
                    if (i < dataGridViewStudentsGrades.ColumnCount - 1)
                    {
                        writer.Write("\t");
                    }
                }
                writer.WriteLine();

                foreach (DataGridViewRow row in dataGridViewStudentsGrades.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < dataGridViewStudentsGrades.ColumnCount; i++)
                        {
                            writer.Write(row.Cells[i].Value?.ToString() ?? "");
                            if (i < dataGridViewStudentsGrades.ColumnCount - 1)
                            {
                                writer.Write("\t");
                            }
                        }
                        writer.WriteLine();
                    }
                }
            }
        }


        private void SaveAsPdf(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                PdfPTable table = new PdfPTable(dataGridViewStudentsGrades.ColumnCount);
                foreach (DataGridViewColumn column in dataGridViewStudentsGrades.Columns)
                {
                    table.AddCell(new Phrase(column.HeaderText));
                }

                foreach (DataGridViewRow row in dataGridViewStudentsGrades.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                        }
                    }
                }

                pdfDoc.Add(table);
                pdfDoc.Close();
            }
        }




        private void SaveAsXml(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, students);
            }
        }



        private void btnExportGrd_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx|Text File|*.txt|JSON File|*.json|PDF File|*.pdf|XML File|*.xml";
            saveFileDialog.Title = "Save Students Data Grade";
            saveFileDialog.FileName = "Students Data Grade";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(saveFileDialog.FileName);
                switch (extension.ToLower())
                {

                    case ".xlsx":
                        SaveAsExcel(saveFileDialog.FileName);
                        break;
                    case ".txt":
                        SaveAsText(saveFileDialog.FileName);
                        break;
                    case ".json":
                        SaveAsJson(saveFileDialog.FileName);
                        break;
                    case ".pdf":
                        SaveAsPdf(saveFileDialog.FileName);
                        break;
                    case ".xml":
                        SaveAsXml(saveFileDialog.FileName);
                        break;

                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            // Mostrar el segundo formulario
            form1.Show();
            // Ocultar el formulario actual (Form1)
            this.Hide();


        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una lista temporal para almacenar las filas que cumplen con el criterio
                var rowsToKeep = new List<DataGridViewRow>();

                // Recorrer todas las filas del DataGridView
                foreach (DataGridViewRow row in dataGridViewStudentsGrades.Rows)
                {
                    // Obtener las calificaciones de las unidades
                    double unit1 = Convert.ToDouble(row.Cells[3].Value);
                    double unit2 = Convert.ToDouble(row.Cells[4].Value);
                    double unit3 = Convert.ToDouble(row.Cells[5].Value);
                    double unit4 = Convert.ToDouble(row.Cells[6].Value);
                    double unit5 = Convert.ToDouble(row.Cells[7].Value);
                    double unit6 = Convert.ToDouble(row.Cells[8].Value);

                    // Contar cuántas unidades son menores a 7
                    int sumativas = 0;
                    if (unit1 < 7) sumativas++;
                    if (unit2 < 7) sumativas++;
                    if (unit3 < 7) sumativas++;
                    if (unit4 < 7) sumativas++;
                    if (unit5 < 7) sumativas++;
                    if (unit6 < 7) sumativas++;

                    // Si tiene al menos una unidad con calificación menor a 7, mantener la fila
                    if (sumativas > 0)
                    {
                        rowsToKeep.Add(row);
                    }
                    
                }

                // Limpiar el DataGridView y volver a agregar solo las filas que cumplen con el criterio
                dataGridViewStudentsGrades.Rows.Clear();

                foreach (var row in rowsToKeep)
                {
                    dataGridViewStudentsGrades.Rows.Add(row);

                }

                MessageBox.Show("Filter applied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RemoveFirstEmptyRow();

                // Calcular total alumnos en sumative  c
                int totalStudents = GetTotalStudents();
                MessageBox.Show($"Total students in Sumative is : {totalStudents}");


            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra y mostrar un mensaje de error
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void RegistComplete()
        {
            MessageBox.Show($"Register Complete Correctly");
        }

        // Método que no recibe parámetros pero devuelve algo
        private int GetTotalStudents()
        {
            return dataGridViewStudentsGrades.Rows.Count -1;
        }
       

        // Método que recibe parámetros y devuelve algo
        private double CalculateAverageGrade(double unit1, double unit2, double unit3, double unit4, double unit5, double unit6)
        {
            double totalUnits = 6;
            double sumGrades = unit1 + unit2 + unit3 + unit4 + unit5 + unit6;
            return sumGrades / totalUnits;
        }

        private void RemoveFirstEmptyRow()
        {
            foreach (DataGridViewRow row in dataGridViewStudentsGrades.Rows)
            {
                bool isEmpty = true;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmpty = false;
                        break;
                    }
                }

                if (isEmpty)
                {
                    dataGridViewStudentsGrades.Rows.Remove(row);
                    break; // Salir del bucle una vez que se haya eliminado la primera fila vacía
                }
            }
        }
    }
}
