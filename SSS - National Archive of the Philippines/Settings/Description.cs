using MySql.Data.MySqlClient;
using National_Archive_of_the_Philippines_Project;
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
    public partial class Description : UserControl
    {
        public Description()
        {
            InitializeComponent();
            LoadData();
        }

        private DataTable dataTable;

        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        Database DB = new Database();

        private void LoadData()
        {
            string query = "SELECT d.id, d.description, d.retention_period, d.code, d.subtitle_id, subtitle " +
                            "FROM tbl_record_description AS d " +
                            "INNER JOIN tbl_record_subtitle AS s ON d.subtitle_id = s.id " +
                            "WHERE s.id != 1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Add a new column for row numbers at the beginning
                    dataTable.Columns.Add("item_number", typeof(int)).SetOrdinal(0);

                    // Populate the ItemNumber column
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["item_number"] = i + 1;
                    }

                    DGDescription.DataSource = dataTable;

                    DGDescription.Columns["id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void ReloadData()
        {
            LoadData();
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            AddUpdateDescription addUpdateDescription = new AddUpdateDescription(this);
            addUpdateDescription.ShowDialog();
        }

        private void btnUpdateTitle_Click(object sender, EventArgs e)
        {
            if (DGDescription.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGDescription.SelectedRows[0];

                int description_id = int.Parse(row.Cells["id"].Value.ToString());
                string description = row.Cells["description_name"].Value.ToString();
                string retention_period = row.Cells["retention_period"].Value.ToString();
                string code = row.Cells["code"].Value.ToString();
                string subtitle = row.Cells["subtitle"].Value.ToString();

                AddUpdateDescription addUpdateDescription = new AddUpdateDescription(description_id, description, retention_period, code, subtitle, this);
                addUpdateDescription.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
            
        }

        private void btnDeleteTitle_Click(object sender, EventArgs e)
        {
            if (DGDescription.SelectedRows.Count > 0)
            {
                string description_id = DGDescription.SelectedRows[0].Cells["id"].Value.ToString();
                int descID = int.Parse(description_id);

                DatabaseHelper dbHelper = new DatabaseHelper();
                int result = dbHelper.CountConnectedDescriptionIdFromSubdescription(descID);

                if (MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        if (result > 0)
                        {
                            MessageBox.Show("Please delete the connected data first and try again", "Try Again",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return;
                        }
                        else
                        {
                            conn.Open();
                            string query = "DELETE FROM tbl_record_description WHERE id = @description_id";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@description_id", description_id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    LoadData(); // Refresh DataGridView
                }
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }
    }
}
