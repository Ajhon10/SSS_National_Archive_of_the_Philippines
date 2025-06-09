using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSS___National_Archive_of_the_Philippines
{
    public partial class BranchCode : UserControl
    {
        private DataTable dataTable;
        public BranchCode()
        {
            InitializeComponent();
            LoadDataBranchCode();
        }

        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        private void LoadDataBranchCode()
        {
            string query = "SELECT * FROM tbl_branch_code";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Add a new column for row numbers
                    dataTable.Columns.Add("item_num", typeof(int)).SetOrdinal(0); // Add as the first column

                    // Populate the ItemNumber column
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["item_num"] = i + 1;
                    }


                    // Bind DataTable to DataGridView
                    DGBranchCode.DataSource = dataTable;

                    // Hide unnecessary columns (if needed)
                    // Clear Selection 
                    DGBranchCode.ClearSelection();
                    // Cell Alignment
                    DGBranchCode.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DGBranchCode.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DGBranchCode.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //Function that Reloads Data
        public void ReloadBranchCodeData()
        {
            LoadDataBranchCode();
        }

        private void btnAddBranchCode_Click(object sender, EventArgs e)
        {
            formAddUpdateBranchCode formAddUpdate = new formAddUpdateBranchCode(this);
            formAddUpdate.ShowDialog();
        }

        private void btnEditBranchCode_Click(object sender, EventArgs e)
        {
            if (DGBranchCode.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGBranchCode.SelectedRows[0];

                string code = row.Cells["branch_code"].Value.ToString();
                string branch_name = row.Cells["branch_name"].Value.ToString();
                string status = row.Cells["status"].Value.ToString();


                // Pass the BranchCode reference to update it later
                formAddUpdateBranchCode formAddUpdate = new formAddUpdateBranchCode(code, branch_name, status, this);
                formAddUpdate.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        private void btnDeleteBranchCode_Click(object sender, EventArgs e)
        {
            if (DGBranchCode.SelectedRows.Count > 0)
            {
                string branch_code = DGBranchCode.SelectedRows[0].Cells["branch_code"].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM tbl_branch_code WHERE branch_code = @code";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@code", branch_code);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadDataBranchCode(); // Refresh DataGridView
                }
            }
        }
    }
}
