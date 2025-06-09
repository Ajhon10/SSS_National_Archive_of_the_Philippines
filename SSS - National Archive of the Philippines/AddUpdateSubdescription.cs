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
    public partial class AddUpdateSubdescription : Form
    {
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        private readonly string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        private bool isEditMode = false; // Flag to check if it's edit mode
        private int subdescriptionID = 0;
        private Subdescription _subdescription;
        public AddUpdateSubdescription(Subdescription subdescriptionUC)
        {
            InitializeComponent();
            LoadDescription();
            _subdescription = subdescriptionUC;
        }

        public AddUpdateSubdescription(int subdescription_id, string subdescription, string retention_period, string code, string description, Subdescription subdescriptionUC)
        {
            InitializeComponent();
            LoadDescription();

            isEditMode = true;
            lblTitle.Text = "EDIT SUB-DESCRIPTION";

            subdescriptionID = subdescription_id;
            txtSubDescription.Text = subdescription;
            txtCode.Text = code;
            txtRetentionPeriod.Text = retention_period;
            CmbDescription.Text = description;

            _subdescription = subdescriptionUC;
        }

        // Load categories into comboBoxCategory
        private void LoadDescription()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, description FROM tbl_record_description WHERE id != 1";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbDescription.DisplayMember = "description";
                CmbDescription.ValueMember = "id";
                CmbDescription.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int subdescription_id = subdescriptionID;
            string subdescription = txtSubDescription.Text;
            string code = txtCode.Text;
            string retention_period = txtRetentionPeriod.Text;
            int selectedId = Convert.ToInt32(CmbDescription.SelectedValue);

            if (isEditMode)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.UpdateSubdescription(subdescription_id, subdescription, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _subdescription?.ReloadData();
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
                bool result = dbHelper.InsertSubdescription(subdescription, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _subdescription?.ReloadData();
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
            LoadDescription();
            txtSubDescription.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtRetentionPeriod.Text = string.Empty;
        }
    }
}
