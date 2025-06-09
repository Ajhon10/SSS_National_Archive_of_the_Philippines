using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using National_Archive_of_the_Philippines_Project;
using SSS___National_Archive_of_the_Philippines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; // For Excel Interop

namespace SSS___National_Archive_of_the_Philippines
{
    public partial class Dashboard : Form
    {
        private System.Data.DataTable dataTable;  // Fully qualify DataTable to avoid ambiguity
        public Dashboard()
        {
            InitializeComponent();
            LoadData();
        }

        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        Database DB = new Database();

        //function that loads the data into the data grid
        private void LoadData()
        {
            string query = "SELECT reference_number, date_received, file_descript, category, title, subtitle, description, subdescription, code, retention_period " +
                            "FROM tbl_records ORDER BY created_date DESC";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    dataTable = new System.Data.DataTable(); // System.Data.DataTable
                    dataAdapter.Fill(dataTable);

                    // Add a new column for row numbers at the beginning
                    dataTable.Columns.Add("item_num", typeof(int)).SetOrdinal(0);

                    // Populate the ItemNumber column
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["item_num"] = i + 1;
                    }

                    // Format the 'date_received' to exclude the time part (MM/dd/yyyy)
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DateTime dateReceived = Convert.ToDateTime(row["date_received"]);
                        row["date_received"] = dateReceived;  // Store only the date part in MM/dd/yyyy format
                    }



                    // Add a new column for concatenated title and description
                    dataTable.Columns.Add("title_and_descript", typeof(string));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string title = row["title"].ToString();
                        string subtitle = row["subtitle"].ToString();
                        string description = row["description"].ToString();
                        string subDescription = row["subdescription"].ToString();

                        row["title_and_descript"] = $"{title} - {subtitle} - {description} - {subDescription}";
                    }

                    // Bind DataTable to DataGridView
                    DGRecords.DataSource = dataTable;

                    // Hide unnecessary columns
                    DGRecords.Columns["title"].Visible = false;
                    DGRecords.Columns["subtitle"].Visible = false;
                    DGRecords.Columns["description"].Visible = false;
                    DGRecords.Columns["subdescription"].Visible = false;

                    DGRecords.Columns[0].Width = 20;
                    DGRecords.Columns[1].Width = 20;
                    DGRecords.ClearSelection();
                    DGRecords.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DGRecords.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //Function that Reloads Data
        public void ReloadData()
        {
            LoadData();
        }

        //Position the menu strip when clicked
        private void btnMenu_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(btnMenu, 0, btnMenu.Height);
        }

        //When Add button is clicked
        private void btnAddFileDescript_Click(object sender, EventArgs e)
        {
            AddEditForm addForm = new AddEditForm();
            addForm.Show();
        }

        //When Update button is clicked
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DGRecords.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGRecords.SelectedRows[0];

                string reference_number = row.Cells["reference_number"].Value.ToString();
                string date_received = row.Cells["date_received"].Value.ToString();
                string code = row.Cells["code"].Value.ToString();
                string category = row.Cells["category_name"].Value.ToString();
                string title = row.Cells["title"].Value.ToString();
                string subtitle = row.Cells["subtitle"].Value.ToString();
                string description = row.Cells["description"].Value.ToString();
                string subdescription = row.Cells["subdescription"].Value.ToString();
                string file_description = row.Cells["file_descript"].Value.ToString();
                string retention_period = row.Cells["retention_period"].Value.ToString();

                // Open EditForm and pass data
                AddEditForm editForm = new AddEditForm(reference_number, date_received, code, category,
                                                 title, subtitle, description, subdescription,
                                                 file_description, retention_period);
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DGRecords.SelectedRows.Count > 0)
            {
                string ref_number = DGRecords.SelectedRows[0].Cells["reference_number"].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM tbl_records WHERE reference_number = @REFNUM";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@REFNUM", ref_number);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not found or deletion failed.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    LoadData(); // Refresh DataGridView
                }
            }
        }

        //Dynamic Search Box
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (dataTable != null)
            {
                // Apply filter to the DataTable
                string filterExpression = $"category LIKE '%{searchTerm}%' OR " +
                                          $"code LIKE '%{searchTerm}%' OR " +
                                         $"title_and_descript LIKE '%{searchTerm}%' OR " +
                                         $"file_descript LIKE '%{searchTerm}%' OR " +
                                         $"reference_number LIKE '%{searchTerm}%'";

                dataTable.DefaultView.RowFilter = filterExpression;

                // Refresh the DataGridView
                DGRecords.DataSource = dataTable.DefaultView;
            }
        }

        //When the settings button is clicked in the profile strip menu
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;

            try
            {
                if (DGRecords.Rows.Count > 0)
                {
                    excelApp = new Excel.Application();
                    workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.Sheets[1];

                    // Define columns to exclude
                    string[] excludedColumns = { "title", "subtitle", "description", "sub_description" };

                    // Find visible/exportable columns
                    List<int> exportableColumns = new List<int>();
                    int colIndex = 0;
                    for (int i = 0; i < DGRecords.Columns.Count; i++)
                    {
                        if (DGRecords.Columns[i].Visible && !excludedColumns.Contains(DGRecords.Columns[i].Name))
                        {
                            exportableColumns.Add(i);
                            worksheet.Cells[1, colIndex + 1] = DGRecords.Columns[i].HeaderText; // Add header
                            colIndex++;
                        }
                    }

                    // Export row data
                    for (int i = 0; i < DGRecords.Rows.Count; i++)
                    {
                        colIndex = 0;
                        foreach (int col in exportableColumns)
                        {
                            // If the column is "date_received", format it to show only the date (without time)
                            if (DGRecords.Columns[col].Name == "date_received")
                            {
                                DateTime dateReceived;
                                if (DateTime.TryParse(DGRecords.Rows[i].Cells[col].Value?.ToString(), out dateReceived))
                                {
                                    worksheet.Cells[i + 2, colIndex + 1] = dateReceived.ToString("MM/dd/yyyy"); // Format as desired
                                }
                            }
                            else
                            {
                                worksheet.Cells[i + 2, colIndex + 1] = DGRecords.Rows[i].Cells[col].Value?.ToString();
                            }
                            colIndex++;
                        }
                    }

                    // AutoFit columns
                    worksheet.Columns.AutoFit();

                    // Save File Dialog
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Save an Excel File",
                        FileName = "SSS_Sorsogon.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Export canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure cleanup
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
            }
        }

    }
}
