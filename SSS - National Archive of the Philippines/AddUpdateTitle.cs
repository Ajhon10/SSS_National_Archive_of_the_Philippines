using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SSS___National_Archive_of_the_Philippines
{
    public partial class AddUpdateTitle : Form
    {
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        private readonly string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        private bool isEditMode = false; // Flag to check if it's edit mode
        private int titleID = 0;

        private Title _title;
        public AddUpdateTitle(Title titleUC)
        {
            InitializeComponent();
            LoadCategories();

            _title = titleUC;
        }

        public AddUpdateTitle(int title_id, string title, string code, string retention_period, string category_name, Title titleUC)
        {
            InitializeComponent();
            LoadCategories();

            isEditMode = true;
            lblTitle.Text = "EDIT TITLE";

            titleID = title_id;
            txtTitle.Text = title;
            txtCode.Text = code;
            txtRetentionPeriod.Text = retention_period;
            CmbCategory.Text = category_name;

            _title = titleUC;
        }

        // Load categories into comboBoxCategory
        private void LoadCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, category_name FROM tbl_record_category";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbCategory.DisplayMember = "category_name";
                CmbCategory.ValueMember = "id";
                CmbCategory.DataSource = dt;
            }
        }

        private void ReloadCategories()
        {
            LoadCategories();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int title_id = titleID;
            int selectedId = Convert.ToInt32(CmbCategory.SelectedValue);
            string title = txtTitle.Text;
            string code = txtCode.Text;
            string retention_period = txtRetentionPeriod.Text;

            if (isEditMode)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.UpdateTitle(title_id, title, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _title?.ReloadData();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updating Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
            }
            else
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.InsertTitle(title, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _title?.ReloadData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Adding Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ReloadCategories();
            txtCode.Text = "";
            txtRetentionPeriod.Text = "";
            txtTitle.Text = "";
        }
    }
}
