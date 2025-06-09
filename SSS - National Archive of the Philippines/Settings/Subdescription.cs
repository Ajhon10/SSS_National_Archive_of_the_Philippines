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
    public partial class Subdescription : UserControl
    {
        public Subdescription()
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
            string query = "SELECT s.id, s.sub_description, s.retention_period, s.code, s.description_id, d.description " +
                            "FROM tbl_record_subdescription AS s " +
                            "INNER JOIN tbl_record_description AS d ON s.description_id = d.id " +
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

                    DGSubdescription.DataSource = dataTable;

                    DGSubdescription.Columns["id"].Visible = false;
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
            AddUpdateSubdescription addUpdateSubdescription = new AddUpdateSubdescription(this);
            addUpdateSubdescription.ShowDialog();
        }

        private void btnUpdateTitle_Click(object sender, EventArgs e)
        {
            if (DGSubdescription.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGSubdescription.SelectedRows[0];

                int subdescription_id = int.Parse(row.Cells["id"].Value.ToString());
                string subdescription = row.Cells["subdescription_name"].Value.ToString();
                string retention_period = row.Cells["retention_period"].Value.ToString();
                string code = row.Cells["code"].Value.ToString();
                string description = row.Cells["description"].Value.ToString();

                AddUpdateSubdescription addUpdateSubdescription = new AddUpdateSubdescription(subdescription_id, subdescription, retention_period, code, description, this);
                addUpdateSubdescription.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        private void btnDeleteTitle_Click(object sender, EventArgs e)
        {
            if (DGSubdescription.SelectedRows.Count > 0)
            {
                string subdescription_id = DGSubdescription.SelectedRows[0].Cells["id"].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM tbl_record_subdescription WHERE id = @subdescription_id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@subdescription_id", subdescription_id);
                            cmd.ExecuteNonQuery();
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
