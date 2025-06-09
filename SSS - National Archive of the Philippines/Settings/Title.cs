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
    public partial class Title : UserControl
    {
        private DataTable dataTable;
        public Title()
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

        private void LoadData()
        {
            string query = "SELECT t.id, title, retention_period, CODE, cat_id, category_name " +
                            "FROM tbl_record_title AS t " +
                            "INNER JOIN tbl_record_category AS c ON t.cat_id = c.id ";

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

                    DGTitle.DataSource = dataTable;

                    DGTitle.Columns["id"].Visible = false;
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
            AddUpdateTitle addUpdateTitle = new AddUpdateTitle(this);
            addUpdateTitle.ShowDialog();
        }

        private void btnUpdateTitle_Click(object sender, EventArgs e)
        {
            if (DGTitle.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGTitle.SelectedRows[0];

                int title_id = int.Parse(row.Cells["id"].Value.ToString());
                string title = row.Cells["title_name"].Value.ToString();
                string retention_period = row.Cells["retention_period"].Value.ToString();
                string code = row.Cells["code"].Value.ToString();
                string category_name = row.Cells["cat_name"].Value.ToString();


                AddUpdateTitle addUpdateTitle = new AddUpdateTitle(title_id, title, code, retention_period, category_name, this);
                addUpdateTitle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        private void btnDeleteTitle_Click(object sender, EventArgs e)
        {
            if (DGTitle.SelectedRows.Count > 0)
            {
                string title_id = DGTitle.SelectedRows[0].Cells["id"].Value.ToString();
                int titleID = int.Parse(title_id);

                DatabaseHelper dbHelper = new DatabaseHelper();
                int result = dbHelper.CountConnectedTitleIdFromSubtitle(titleID);

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
                            string query = "DELETE FROM tbl_record_title WHERE id = @title_id";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@title_id", title_id);
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
