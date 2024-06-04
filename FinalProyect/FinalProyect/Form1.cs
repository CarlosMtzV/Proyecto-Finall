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

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;




namespace FinalProyect
{
    public partial class Form1 : Form
    {
        
        public static Student[] students = new Student[0];


        public Form1()
        {
            InitializeComponent();


            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Agregar las columnas al DataGridView
            dataGridViewStudents.ColumnCount = 6;
            dataGridViewStudents.Columns[0].Name = "Registration Number";
            dataGridViewStudents.Columns[1].Name = "Name";
            dataGridViewStudents.Columns[2].Name = "LastName";
            dataGridViewStudents.Columns[3].Name = "Phone";
            dataGridViewStudents.Columns[4].Name = "Major";
            dataGridViewStudents.Columns[5].Name = "Email";
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener datos del estudiante del formulario
                string registrationNumber = txtRegistrationNumber.Text;
                string name = txtName.Text;
                string lastname = txtLastname.Text;
                string phone = txtPhone.Text;
                string major = majorbox.Text;

                // Verificar si alguno de los campos está vacío
                if (string.IsNullOrWhiteSpace(registrationNumber) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(lastname) ||
                    string.IsNullOrWhiteSpace(phone) ||
                    string.IsNullOrWhiteSpace(major))
                {
                    // Mostrar mensaje de advertencia
                    MessageBox.Show("Please fill in all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generar el email
                string email = registrationNumber + "@monclova.tecnm.mx";

                // Crear un nuevo objeto Student
                Student newStudent = new Student(registrationNumber, name, lastname, phone, major, email);

                // Agregar el estudiante al arreglo
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = newStudent;

                // Limpiar los campos del formulario
                ClearFields();

                // Actualizar el DataGridView
                UpdateDataGridView();
                RegistComplete();

                // Mostrar la contraseña de email en un MessageBox
                MessageBox.Show("The email password has been generated.", "Email Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra y mostrar un mensaje de error
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtRegistrationNumber.Clear();
            txtName.Clear();
            txtPhone.Clear();
            
            txtLastname.Clear();
        }

        private void UpdateDataGridView()
        {
            // Limpiar el DataGridView
            dataGridViewStudents.Rows.Clear();



            foreach (var student in students)
            {
                // Crear una nueva fila para el estudiante
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewStudents);
                row.Cells[0].Value = student.RegistrationNumber;
                row.Cells[1].Value = student.Name;
                row.Cells[2].Value = student.LastName;
                row.Cells[3].Value = student.Phone;
                row.Cells[4].Value = student.Major;
                row.Cells[5].Value = student.Email;

                // Agregar la fila al DataGridView
                dataGridViewStudents.Rows.Add(row);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                // Eliminar las filas seleccionadas del DataGridView y del arreglo de estudiantes
                foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
                {
                    string registrationNumber = row.Cells[0].Value.ToString();

                    // Encontrar el índice del estudiante a eliminar
                    int index = Array.FindIndex(students, s => s.RegistrationNumber == registrationNumber);

                    if (index >= 0)
                    {
                        // Eliminar del arreglo de estudiantes
                        for (int i = index; i < students.Length - 1; i++)
                        {
                            students[i] = students[i + 1];
                        }
                        Array.Resize(ref students, students.Length - 1);

                        // Eliminar del DataGridView
                        dataGridViewStudents.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one row to delete.");
            }
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
                foreach (DataGridViewColumn column in dataGridViewStudents.Columns)
                {
                    Cell headerCell = new Cell() { CellValue = new CellValue(column.HeaderText), DataType = CellValues.String };
                    headerRow.Append(headerCell);
                }
                sheetData.Append(headerRow);

                foreach (DataGridViewRow row in dataGridViewStudents.Rows)
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
                for (int i = 0; i < dataGridViewStudents.ColumnCount; i++)
                {
                    writer.Write(dataGridViewStudents.Columns[i].HeaderText);
                    if (i < dataGridViewStudents.ColumnCount - 1)
                    {
                        writer.Write("\t");
                    }
                }
                writer.WriteLine();

                foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < dataGridViewStudents.ColumnCount; i++)
                        {
                            writer.Write(row.Cells[i].Value?.ToString() ?? "");
                            if (i < dataGridViewStudents.ColumnCount - 1)
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

                PdfPTable table = new PdfPTable(dataGridViewStudents.ColumnCount);
                foreach (DataGridViewColumn column in dataGridViewStudents.Columns)
                {
                    table.AddCell(new Phrase(column.HeaderText));
                }

                foreach (DataGridViewRow row in dataGridViewStudents.Rows)
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


        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx|Text File|*.txt|JSON File|*.json|PDF File|*.pdf|XML File|*.xml";
            saveFileDialog.Title = "Save Students Data";
            saveFileDialog.FileName = "Students Data";

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

        private void btnGrade_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Mostrar el segundo formulario
            form2.Show();
            // Ocultar el formulario actual (Form1)
            this.Hide();


        }
        // Método estático



        public static void RegistComplete()
        {
            MessageBox.Show($"Register Complete Correctly");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
