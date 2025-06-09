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
    public partial class Subtitle : UserControl
    {
        public Subtitle()
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
            string query = "SELECT s.id, subtitle, s.retention_period, s.code, title_id, title " +
                            "FROM tbl_record_subtitle AS s " +
                            "INNER JOIN tbl_record_title AS t ON s.title_id = t.id " +
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

                    DGSubtitle.DataSource = dataTable;

                    DGSubtitle.Columns["id"].Visible = false;
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

        private void btnAddSubtitle_Click(object sender, EventArgs e)
        {
            AddUpdateSubtitle addUpdateSubtitle = new AddUpdateSubtitle(this);
            addUpdateSubtitle.ShowDialog();
        }

        private void btnUpdateSubtitle_Click(object sender, EventArgs e)
        {
            if (DGSubtitle.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGSubtitle.SelectedRows[0];

                int subtitle_id = int.Parse(row.Cells["id"].Value.ToString());
                string subtitle = row.Cells["subtitle_name"].Value.ToString();
                string retention_period = row.Cells["retention_period"].Value.ToString();
                string code = row.Cells["code"].Value.ToString();
                string title = row.Cells["title"].Value.ToString();

                AddUpdateSubtitle addUpdateSubtitle = new AddUpdateSubtitle(subtitle_id, subtitle, code, retention_period, title, this);
                addUpdateSubtitle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        private void btnDeleteSubtitle_Click(object sender, EventArgs e)
        {
            if (DGSubtitle.SelectedRows.Count > 0)
            {
                string subtitle_id = DGSubtitle.SelectedRows[0].Cells["id"].Value.ToString();
                int subtitleID = int.Parse(subtitle_id);

                DatabaseHelper dbHelper = new DatabaseHelper();
                int result = dbHelper.CountConnectedSubtitleIdFromDescription(subtitleID);

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
                            string query = "DELETE FROM tbl_record_subtitle WHERE id = @subtitle_id";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@subtitle_id", subtitle_id);
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
