namespace SSS___National_Archive_of_the_Philippines
{
    partial class BranchCode
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitleBranchCode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DGBranchCode = new Guna.UI2.WinForms.Guna2DataGridView();
            this.item_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddBranchCode = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDeleteBranchCode = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditBranchCode = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGBranchCode)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitleBranchCode
            // 
            this.lblTitleBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleBranchCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleBranchCode.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBranchCode.Location = new System.Drawing.Point(200, 16);
            this.lblTitleBranchCode.Name = "lblTitleBranchCode";
            this.lblTitleBranchCode.Size = new System.Drawing.Size(383, 47);
            this.lblTitleBranchCode.TabIndex = 0;
            this.lblTitleBranchCode.Text = "MANAGE BRANCH CODE";
            // 
            // DGBranchCode
            // 
            this.DGBranchCode.AllowUserToAddRows = false;
            this.DGBranchCode.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGBranchCode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGBranchCode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGBranchCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGBranchCode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGBranchCode.ColumnHeadersHeight = 40;
            this.DGBranchCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGBranchCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_number,
            this.branch_code,
            this.branch_name,
            this.status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGBranchCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGBranchCode.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGBranchCode.Location = new System.Drawing.Point(0, 264);
            this.DGBranchCode.MultiSelect = false;
            this.DGBranchCode.Name = "DGBranchCode";
            this.DGBranchCode.ReadOnly = true;
            this.DGBranchCode.RowHeadersVisible = false;
            this.DGBranchCode.RowHeadersWidth = 62;
            this.DGBranchCode.RowTemplate.Height = 28;
            this.DGBranchCode.Size = new System.Drawing.Size(777, 354);
            this.DGBranchCode.TabIndex = 1;
            this.DGBranchCode.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGBranchCode.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGBranchCode.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGBranchCode.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGBranchCode.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGBranchCode.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGBranchCode.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGBranchCode.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGBranchCode.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGBranchCode.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGBranchCode.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGBranchCode.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGBranchCode.ThemeStyle.HeaderStyle.Height = 40;
            this.DGBranchCode.ThemeStyle.ReadOnly = true;
            this.DGBranchCode.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGBranchCode.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGBranchCode.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGBranchCode.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGBranchCode.ThemeStyle.RowsStyle.Height = 28;
            this.DGBranchCode.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGBranchCode.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // item_number
            // 
            this.item_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.item_number.DataPropertyName = "item_num";
            this.item_number.FillWeight = 20F;
            this.item_number.HeaderText = "#";
            this.item_number.MinimumWidth = 8;
            this.item_number.Name = "item_number";
            this.item_number.ReadOnly = true;
            this.item_number.Width = 59;
            // 
            // branch_code
            // 
            this.branch_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.branch_code.DataPropertyName = "branch_code";
            this.branch_code.HeaderText = "BRANCH CODE";
            this.branch_code.MinimumWidth = 8;
            this.branch_code.Name = "branch_code";
            this.branch_code.ReadOnly = true;
            this.branch_code.Width = 179;
            // 
            // branch_name
            // 
            this.branch_name.DataPropertyName = "branch_name";
            this.branch_name.HeaderText = "BRANCH NAME";
            this.branch_name.MinimumWidth = 200;
            this.branch_name.Name = "branch_name";
            this.branch_name.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "STATUS";
            this.status.MinimumWidth = 8;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 114;
            // 
            // btnAddBranchCode
            // 
            this.btnAddBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBranchCode.BorderRadius = 10;
            this.btnAddBranchCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBranchCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBranchCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddBranchCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddBranchCode.FillColor = System.Drawing.Color.Blue;
            this.btnAddBranchCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddBranchCode.ForeColor = System.Drawing.Color.White;
            this.btnAddBranchCode.Location = new System.Drawing.Point(421, 208);
            this.btnAddBranchCode.Name = "btnAddBranchCode";
            this.btnAddBranchCode.Size = new System.Drawing.Size(112, 48);
            this.btnAddBranchCode.TabIndex = 2;
            this.btnAddBranchCode.Text = "ADD";
            this.btnAddBranchCode.Click += new System.EventHandler(this.btnAddBranchCode_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.Controls.Add(this.DGBranchCode);
            this.guna2Panel1.Controls.Add(this.btnDeleteBranchCode);
            this.guna2Panel1.Controls.Add(this.btnEditBranchCode);
            this.guna2Panel1.Controls.Add(this.lblTitleBranchCode);
            this.guna2Panel1.Controls.Add(this.btnAddBranchCode);
            this.guna2Panel1.Location = new System.Drawing.Point(16, 16);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(780, 626);
            this.guna2Panel1.TabIndex = 3;
            // 
            // btnDeleteBranchCode
            // 
            this.btnDeleteBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBranchCode.BorderRadius = 10;
            this.btnDeleteBranchCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteBranchCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteBranchCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteBranchCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteBranchCode.FillColor = System.Drawing.Color.Blue;
            this.btnDeleteBranchCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteBranchCode.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBranchCode.Location = new System.Drawing.Point(661, 208);
            this.btnDeleteBranchCode.Name = "btnDeleteBranchCode";
            this.btnDeleteBranchCode.Size = new System.Drawing.Size(112, 48);
            this.btnDeleteBranchCode.TabIndex = 4;
            this.btnDeleteBranchCode.Text = "DELETE";
            this.btnDeleteBranchCode.Click += new System.EventHandler(this.btnDeleteBranchCode_Click);
            // 
            // btnEditBranchCode
            // 
            this.btnEditBranchCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBranchCode.BorderRadius = 10;
            this.btnEditBranchCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditBranchCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditBranchCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditBranchCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditBranchCode.FillColor = System.Drawing.Color.Blue;
            this.btnEditBranchCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditBranchCode.ForeColor = System.Drawing.Color.White;
            this.btnEditBranchCode.Location = new System.Drawing.Point(541, 208);
            this.btnEditBranchCode.Name = "btnEditBranchCode";
            this.btnEditBranchCode.Size = new System.Drawing.Size(112, 48);
            this.btnEditBranchCode.TabIndex = 3;
            this.btnEditBranchCode.Text = "UPDATE";
            this.btnEditBranchCode.Click += new System.EventHandler(this.btnEditBranchCode_Click);
            // 
            // BranchCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "BranchCode";
            this.Size = new System.Drawing.Size(813, 650);
            ((System.ComponentModel.ISupportInitialize)(this.DGBranchCode)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitleBranchCode;
        private Guna.UI2.WinForms.Guna2DataGridView DGBranchCode;
        private Guna.UI2.WinForms.Guna2Button btnAddBranchCode;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnDeleteBranchCode;
        private Guna.UI2.WinForms.Guna2Button btnEditBranchCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}
