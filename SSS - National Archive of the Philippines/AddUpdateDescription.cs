using Guna.UI2.WinForms.Suite;
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
    public partial class AddUpdateDescription : Form
    {
        
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        private readonly string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        private bool isEditMode = false; // Flag to check if it's edit mode
        private int descriptionID = 0;
        private Description _description;

        public AddUpdateDescription(Description descriptionUC)
        {
            InitializeComponent();
            LoadSubTitles();
            _description = descriptionUC;
        }

        public AddUpdateDescription(int description_id, string description, string retention_period, string code, string subtitle, Description descriptionUC)
        {
            InitializeComponent();
            LoadSubTitles();

            isEditMode = true;
            lblTitle.Text = "EDIT DESCRIPTION";

            descriptionID = description_id;
            txtDescription.Text = description;
            txtCode.Text = code;
            txtRetentionPeriod.Text = retention_period;
            CmbSubtitle.Text = subtitle;

            _description = descriptionUC;
        }

        // Load categories into comboBoxCategory
        private void LoadSubTitles()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, subtitle FROM tbl_record_subtitle WHERE id != 1";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbSubtitle.DisplayMember = "subtitle";
                CmbSubtitle.ValueMember = "id";
                CmbSubtitle.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int description_id = descriptionID;
            string description = txtDescription.Text;
            string code = txtCode.Text;
            string retention_period = txtRetentionPeriod.Text;
            int selectedId = Convert.ToInt32(CmbSubtitle.SelectedValue);

            if (isEditMode)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.UpdateDescription(description_id, description, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _description?.ReloadData();

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
                bool result = dbHelper.InsertDescription(description, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _description?.ReloadData();
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
            LoadSubTitles();
            txtDescription.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtRetentionPeriod.Text = string.Empty;
        }
    }
}
