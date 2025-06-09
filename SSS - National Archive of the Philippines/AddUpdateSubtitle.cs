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
    public partial class AddUpdateSubtitle : Form
    {
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        private readonly string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        private bool isEditMode = false; // Flag to check if it's edit mode
        private int subtitleID = 0;

        private Subtitle _subtitle;
        public AddUpdateSubtitle(Subtitle subtitleUC)
        {
            InitializeComponent();
            LoadTitles();
            _subtitle = subtitleUC;
        }

        public AddUpdateSubtitle(int subtitle_id, string subtitle, string code, string retention_period, string title, Subtitle subtitleUC)
        {
            InitializeComponent();
            LoadTitles();

            isEditMode = true;
            lblTitle.Text = "EDIT SUB-TITLE";

            subtitleID = subtitle_id;
            txtSubitle.Text = subtitle;
            txtCode.Text = code;
            txtRetentionPeriod.Text = retention_period;
            CmbTitle.Text = title;

            _subtitle = subtitleUC;
        }

        // Load titles into comboBoxTitle
        private void LoadTitles()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id, title FROM tbl_record_title";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                CmbTitle.DisplayMember = "title";
                CmbTitle.ValueMember = "id";
                CmbTitle.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int subtitle_id = subtitleID;
            string subtitle = txtSubitle.Text;
            string code = txtCode.Text;
            string retention_period = txtRetentionPeriod.Text;
            int selectedId = Convert.ToInt32(CmbTitle.SelectedValue);

            if (isEditMode)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.UpdateSubtitle(subtitle_id, subtitle, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _subtitle?.ReloadData();

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
                bool result = dbHelper.InsertSubtitle(subtitle, retention_period, code, selectedId);

                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _subtitle?.ReloadData();
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
            LoadTitles();
            txtSubitle.Text = "";
            txtCode.Text = "";
            txtRetentionPeriod.Text = "";
        }
    }
}
