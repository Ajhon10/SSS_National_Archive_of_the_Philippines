using Google.Protobuf;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
    public partial class AddEditForm : Form
    {
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        private readonly string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        public string SelectedCategory { get; set; } // Property to store the selected category
        public string SelectedTitle { get; set; }
        public string SelectedSubtitle { get; set; }
        public string SelectedDescription { get; set; }
        public string SelectedSubdrescription { get; set; }
        
        private bool isEditMode = false; // Flag to check if it's edit mode
        private int numericValue = 0;

        public AddEditForm()
        {
            InitializeComponent();
            LoadCategories();
            txtReferenceNumber.ReadOnly = false;
        }
        public AddEditForm(string referenceNumber, string dateReceived, string code, string category,
                     string title, string subtitle, string description, string subDescription,
                     string fileDescription, string retentionPeriod)
        {
            InitializeComponent();
            LoadCategories();

            // Set edit mode
            isEditMode = true;
            lblTitle.Text = "UPDATE FILE DESCRIPTION";

            // Assign values to TextBoxes
            txtReferenceNumber.Text = referenceNumber;
            dateDateReceived.Text = dateReceived;
            txtCode.Text = code;
            txtFileDescirption.Text = fileDescription;
            txtRetentionPeriod.Text = retentionPeriod;

            // Assign values to ComboBoxes
            CmbCategory.Text = category;
            CmbTitle.Text = title;
            CmbSubTitle.Text = subtitle;
            CmbTitleDescription.Text = description;
            CmbSubDescription.Text = subDescription;

            string input = referenceNumber;
            string[] parts = input.Split('-');
            string lastPart = parts[parts.Length - 1];
            numericValue = int.Parse(lastPart);
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

                // Set the selected item
                if (!string.IsNullOrEmpty(SelectedCategory))
                {
                    CmbCategory.SelectedValue = SelectedCategory;
                }
            }
        }


        // Load titles based on selected category
        private void LoadTitles(int categoryId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, title FROM tbl_record_title WHERE cat_id = @CategoryId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbTitle.ValueMember = "id";
                CmbTitle.DisplayMember = "title";
                CmbTitle.DataSource = dt;

                // Set the selected item
                if (!string.IsNullOrEmpty(SelectedTitle))
                {
                    CmbTitle.SelectedValue = SelectedTitle;
                }
            }
        }

        private void LoadSubTitles(int titleId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, subtitle FROM tbl_record_subtitle WHERE title_id = @TitleId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TitleId", titleId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbSubTitle.ValueMember = "id";
                CmbSubTitle.DisplayMember = "subtitle";
                CmbSubTitle.DataSource = dt;

                // Set the selected item
                if (!string.IsNullOrEmpty(SelectedSubtitle))
                {
                    CmbSubTitle.SelectedValue = SelectedSubtitle;
                }
            }
        }

        private void LoadTitleDescription(int subtitleId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, description FROM tbl_record_description WHERE subtitle_id = @SubTitleId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubTitleId", subtitleId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbTitleDescription.ValueMember = "id";
                CmbTitleDescription.DisplayMember = "description";
                CmbTitleDescription.DataSource = dt;

                // Set the selected item
                if (!string.IsNullOrEmpty(SelectedDescription))
                {
                    CmbTitleDescription.SelectedValue = SelectedDescription;
                }
            }
        }

        private void LoadTitleSubDescription(int descriptionId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, sub_description FROM tbl_record_subdescription WHERE description_id = @descriptionId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@descriptionId", descriptionId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbSubDescription.ValueMember = "id";
                CmbSubDescription.DisplayMember = "sub_description";
                CmbSubDescription.DataSource = dt;

                // Set the selected item
                if (!string.IsNullOrEmpty(SelectedSubdrescription))
                {
                    CmbSubDescription.SelectedValue = SelectedSubdrescription;
                }
            }
        }

        private void LoadTitleDetails(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT code, retention_period FROM tbl_record_title WHERE id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DatabaseHelper dbHelper = new DatabaseHelper();
                            string branchCode = dbHelper.GetActiveBranchCode();
                            int tableCount = dbHelper.GetTableCount();
                            string code = reader["code"].ToString();

                            int reference_num = 0;
                            if (isEditMode == true) 
                            {
                                reference_num = numericValue;
                            } 
                            else
                            {
                                reference_num = tableCount + 1;
                            }
                            
                            string formattedReferenceNum = reference_num.ToString("D3"); // Ensures 3-digit format

                            if (code != null)
                            {
                                txtReferenceNumber.Text = branchCode + code + "-" + formattedReferenceNum;
                                txtCode.Text = branchCode + code;
                                txtRetentionPeriod.Text = reader["retention_period"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading title details: " + ex.Message);
                }
            }
        }

        private void LoadSubTitleDetails(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT code, retention_period FROM tbl_record_subtitle WHERE id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DatabaseHelper dbHelper = new DatabaseHelper();
                            string branchCode = dbHelper.GetActiveBranchCode();
                            int tableCount = dbHelper.GetTableCount();
                            string code = reader["code"].ToString();

                            int reference_num = 0;
                            if (isEditMode == true)
                            {
                                reference_num = numericValue;
                            }
                            else
                            {
                                reference_num = tableCount + 1;
                            }

                            string formattedReferenceNum = reference_num.ToString("D3"); // Ensures 3-digit format

                            if (code != null)
                            {
                                txtReferenceNumber.Text = branchCode + code + "-" + formattedReferenceNum;
                                txtCode.Text = branchCode + code;
                                txtRetentionPeriod.Text = reader["retention_period"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading title details: " + ex.Message);
                }
            }
        }

        private void LoadDescriptionDetails(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT code, retention_period FROM tbl_record_description WHERE id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DatabaseHelper dbHelper = new DatabaseHelper();
                            string branchCode = dbHelper.GetActiveBranchCode();
                            int tableCount = dbHelper.GetTableCount();
                            string code = reader["code"].ToString();

                            int reference_num = 0;
                            if (isEditMode == true)
                            {
                                reference_num = numericValue;
                            }
                            else
                            {
                                reference_num = tableCount + 1;
                            }

                            string formattedReferenceNum = reference_num.ToString("D3"); // Ensures 3-digit format

                            if (code != null)
                            {
                                txtReferenceNumber.Text = branchCode + code + "-" + formattedReferenceNum;
                                txtCode.Text = branchCode + code;
                                txtRetentionPeriod.Text = reader["retention_period"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading title details: " + ex.Message);
                }
            }
        }

        private void LoadSubDescriptionDetails(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT code, retention_period FROM tbl_record_subdescription WHERE id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DatabaseHelper dbHelper = new DatabaseHelper();
                            string branchCode = dbHelper.GetActiveBranchCode();
                            int tableCount = dbHelper.GetTableCount();
                            string code = reader["code"].ToString();

                            int reference_num = 0;
                            if (isEditMode == true)
                            {
                                reference_num = numericValue;
                            }
                            else
                            {
                                reference_num = tableCount + 1;
                            }

                            string formattedReferenceNum = reference_num.ToString("D3"); // Ensures 3-digit format

                            if (code != null)
                            {
                                txtReferenceNumber.Text = branchCode + code + "-" + formattedReferenceNum;
                                txtCode.Text = branchCode + code;
                                txtRetentionPeriod.Text = reader["retention_period"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading title details: " + ex.Message);
                }
            }
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCategory.SelectedValue is int selectedCategoryId)
            {
                LoadTitles(selectedCategoryId);
                ClearDependentComboBoxes("CmbCategory");
            }
        }

        private void CmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = 0;
            if (CmbTitle.SelectedValue is int selectedTitleId)
            {
                selectedID = selectedTitleId;
                LoadSubTitles(selectedTitleId);
                ClearDependentComboBoxes("CmbTitle");
            }

            if (CmbTitle.SelectedValue != null && CmbSubTitle.SelectedValue == null ||
                CmbTitleDescription.SelectedValue == null || CmbSubDescription.SelectedValue == null)
            {
                LoadTitleDetails(selectedID);
            }
        }

        private void CmbSubTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = 0;
            if (CmbSubTitle.SelectedValue is int selectedSubTitleId)
            {
                selectedID = selectedSubTitleId;
                LoadTitleDescription(selectedSubTitleId);
                ClearDependentComboBoxes("CmbSubTitle");
            }

            if (CmbSubTitle.SelectedValue != null &&
                CmbTitleDescription.SelectedValue == null || CmbSubDescription.SelectedValue == null)
            {
                LoadSubTitleDetails(selectedID);
            }
        }

        private void CmbTitleDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = 0;
            if (CmbTitleDescription.SelectedValue is int selectedDescriptionId)
            {
                selectedID = selectedDescriptionId;
                LoadTitleSubDescription(selectedDescriptionId);
            }

            if (CmbTitleDescription.SelectedValue != null && CmbSubDescription.SelectedValue == null)
            {
                LoadDescriptionDetails(selectedID);
            }
        }

        private void CmbSubDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedID = 0;
            if (CmbSubDescription.SelectedValue is int selectedDescriptionId)
            {
                selectedID = selectedDescriptionId;
            }

            if (CmbSubDescription.SelectedValue != null)
            {
                LoadSubDescriptionDetails(selectedID);
            }
        }

        private void ClearDependentComboBoxes(string changedCombo)
        {
            switch (changedCombo)
            {
                case "CmbCategory":
                    CmbSubTitle.DataSource = null;
                    CmbTitleDescription.DataSource = null;
                    CmbSubDescription.DataSource = null;
                    break;

                case "CmbTitle":
                    CmbTitleDescription.DataSource = null;
                    CmbSubDescription.DataSource = null;
                    break;

                case "CmbSubTitle":
                    CmbSubDescription.DataSource = null;
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadCategories();
            txtFileDescirption.Text = "";
            dateDateReceived.Value = DateTime.Now;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Geet the input of text boxes
            string reference_number = txtReferenceNumber.Text;
            string code = txtCode.Text;
            string retention_period = txtRetentionPeriod.Text;
            string file_description = txtFileDescirption.Text;

            // Get the value of date
            DateTime date = dateDateReceived.Value;
            string formattedDate = date.ToString("yyyy-MM-dd");

            // Get the value of combo boxes
            string selectedCategory = CmbCategory.Text;
            string selectedTitle = CmbTitle.Text;
            string selectedSubtitle = CmbSubTitle.Text;
            string selectedDescription = CmbTitleDescription.Text;
            string selectedSubDescription = CmbSubDescription.Text;

            if (isEditMode)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.UpdateFileDescription(reference_number, formattedDate, code, file_description, selectedCategory, selectedTitle, selectedSubtitle, selectedDescription, selectedSubDescription, retention_period);

                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Dashboard)
                        {
                            ((Dashboard)form).ReloadData();
                            break;
                        }
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            } 
            else
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.InsertFileDescription(reference_number, formattedDate, code, file_description, selectedCategory, selectedTitle, selectedSubtitle, selectedDescription, selectedSubDescription, retention_period);

                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Dashboard)
                        {
                            ((Dashboard)form).ReloadData();
                            break;
                        }
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Adding Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }






        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
