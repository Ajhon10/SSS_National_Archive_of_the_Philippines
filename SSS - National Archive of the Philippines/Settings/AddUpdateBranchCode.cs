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
    public partial class formAddUpdateBranchCode : Form
    {
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        private readonly string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        private bool isEditMode = false; // Flag to check if it's edit mode

        private BranchCode _branchCodeControl;
        public formAddUpdateBranchCode(BranchCode branchCodeControl)
        {
            InitializeComponent();
            LoadStatus();
            _branchCodeControl = branchCodeControl;
        }
        
        public formAddUpdateBranchCode(string code, string branch_name, string status, BranchCode branchCodeControl)
        {
            InitializeComponent();
            LoadStatus();

            // Set edit mode
            isEditMode = true;
            lblTitle.Text = "EDIT BRANCH CODE";
            txtCode.Text = code;
            txtBranchName.Text = branch_name;
            CmbStatus.Text = status;
            _branchCodeControl = branchCodeControl;
        }

        private void LoadStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, status FROM tbl_branch_code_status";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbStatus.DisplayMember = "status";
                CmbStatus.ValueMember = "id";
                CmbStatus.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            string branch_code = txtBranchName.Text;
            string status = CmbStatus.Text;

            if (status == "Active")
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                dbHelper.SetAllStatusToInactive();
            }

            if (isEditMode)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.UpdateBranch(code, branch_code, status);

                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _branchCodeControl?.ReloadBranchCodeData(); // Refresh the DataGridView in BranchCode

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
                bool result = dbHelper.InsertBranch(code, branch_code, status);

                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _branchCodeControl?.ReloadBranchCodeData(); // Refresh the DataGridView in BranchCode
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
            txtBranchName.Clear();
            txtCode.Clear();
        }
    }
}
