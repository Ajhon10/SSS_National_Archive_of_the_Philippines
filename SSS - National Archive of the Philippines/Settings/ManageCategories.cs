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
    public partial class ManageCategories : UserControl
    {
        private DataTable dataTable;

        public ManageCategories()
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
            string query = "SELECT id, category_name FROM tbl_record_category";

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

                    DGCategory.DataSource = dataTable;

                    DGCategory.Columns["id"].Visible = false;
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

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddEditCategory addForm = new AddEditCategory(this);
            addForm.ShowDialog();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (DGCategory.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGCategory.SelectedRows[0];

                string category_name = row.Cells["category_name"].Value.ToString();
                int category_id = int.Parse(row.Cells["id"].Value.ToString());

                AddEditCategory addEditCategory = new AddEditCategory(category_id, category_name, this);
                addEditCategory.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (DGCategory.SelectedRows.Count > 0)
            {
                string id = DGCategory.SelectedRows[0].Cells["id"].Value.ToString();
                int cat_id = int.Parse(id.ToString());

                DatabaseHelper dbHelper = new DatabaseHelper();
                int result = dbHelper.CountConnectedCategoryIdFromTitle(cat_id);

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
                            string query = "DELETE FROM tbl_record_category WHERE id = @id";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        
                    }
                    LoadData(); // Refresh DataGridView
                }
            }
        }
    }
}
