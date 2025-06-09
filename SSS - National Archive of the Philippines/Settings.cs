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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            LoadUserControl(new BranchCode());
        }

        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        private UserControl currentControl;

        private void LoadUserControl(UserControl uc)
        {
            // Clear previous content
            splitContainer1.Panel2.Controls.Clear();

            // Store reference to the current control
            currentControl = uc;

            // Dock to fill the panel
            uc.Dock = DockStyle.Fill;

            // Add control to Panel2
            splitContainer1.Panel2.Controls.Add(uc);
        }


        private void btnBranchCode_Click(object sender, EventArgs e)
        {
            LoadUserControl(new BranchCode());
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ManageCategories());
        }

        private void btnManageTitle_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Title());
        }

        private void btnSubTitle_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Subtitle());
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Description());
        }

        private void btnSubDescription_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Subdescription());
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all records?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Disable foreign key checks
                            using (MySqlCommand cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 0;", conn, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Delete from child tables first
                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_record_subdescription WHERE id != 1;", conn, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_record_description WHERE id != 1;", conn, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_record_subtitle WHERE id != 1;", conn, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_record_title;", conn, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Delete from the parent table
                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_record_category;", conn, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Enable foreign key checks again
                            using (MySqlCommand cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 1;", conn, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("All records deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Rollback if any error occurs
                            transaction.Rollback();
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }


        }
    }
}
