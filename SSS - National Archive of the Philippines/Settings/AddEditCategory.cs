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
    public partial class AddEditCategory : Form
    {
        private bool isEditMode = false; // Flag to check if it's edit mode
        int category_id = 0;

        private ManageCategories _managecategories; 

        // Initialized Add mode
        public AddEditCategory(ManageCategories managecategories)
        {
            InitializeComponent();
            _managecategories = managecategories;
        }

        // Initialized Edit mode
        public AddEditCategory(int id, string category_name, ManageCategories managecategories)
        {
            InitializeComponent();

            isEditMode = true;
            lblAddEditCategory.Text = "EDIT CATEGORY";
            txtCategoryName.Text = category_name;
            category_id = id;

            _managecategories = managecategories;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string category_name = txtCategoryName.Text;
            int catID = category_id;
            if (isEditMode)
            {
                DatabaseHelper dbHelper = new DatabaseHelper();
                bool result = dbHelper.UpdateCategory(catID, category_name);

                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _managecategories?.ReloadData();

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
                bool result = dbHelper.InsertCategory(category_name);

                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _managecategories?.ReloadData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Adding Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}
