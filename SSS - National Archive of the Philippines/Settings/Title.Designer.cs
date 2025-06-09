namespace SSS___National_Archive_of_the_Philippines
{
    partial class Title
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnDeleteTitle = new Guna.UI2.WinForms.Guna2Button();
            this.DGTitle = new Guna.UI2.WinForms.Guna2DataGridView();
            this.item_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retention_period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cat_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateTitle = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddTitle = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.lblTitle);
            this.guna2Panel1.Controls.Add(this.btnDeleteTitle);
            this.guna2Panel1.Controls.Add(this.DGTitle);
            this.guna2Panel1.Controls.Add(this.btnUpdateTitle);
            this.guna2Panel1.Controls.Add(this.btnAddTitle);
            this.guna2Panel1.Location = new System.Drawing.Point(14, 17);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(785, 616);
            this.guna2Panel1.TabIndex = 16;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(272, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 47);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "MANAGE TITLE";
            // 
            // btnDeleteTitle
            // 
            this.btnDeleteTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTitle.BorderRadius = 10;
            this.btnDeleteTitle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteTitle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteTitle.FillColor = System.Drawing.Color.Blue;
            this.btnDeleteTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteTitle.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTitle.Location = new System.Drawing.Point(662, 136);
            this.btnDeleteTitle.Name = "btnDeleteTitle";
            this.btnDeleteTitle.Size = new System.Drawing.Size(112, 48);
            this.btnDeleteTitle.TabIndex = 13;
            this.btnDeleteTitle.Text = "DELETE";
            this.btnDeleteTitle.Click += new System.EventHandler(this.btnDeleteTitle_Click);
            // 
            // DGTitle
            // 
            this.DGTitle.AllowUserToAddRows = false;
            this.DGTitle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGTitle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGTitle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGTitle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGTitle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGTitle.ColumnHeadersHeight = 40;
            this.DGTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGTitle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_number,
            this.title_name,
            this.retention_period,
            this.code,
            this.cat_id,
            this.cat_name});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGTitle.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGTitle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGTitle.Location = new System.Drawing.Point(0, 192);
            this.DGTitle.Name = "DGTitle";
            this.DGTitle.ReadOnly = true;
            this.DGTitle.RowHeadersVisible = false;
            this.DGTitle.RowHeadersWidth = 70;
            this.DGTitle.RowTemplate.Height = 28;
            this.DGTitle.Size = new System.Drawing.Size(782, 420);
            this.DGTitle.TabIndex = 14;
            this.DGTitle.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGTitle.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGTitle.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGTitle.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGTitle.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGTitle.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGTitle.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGTitle.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            this.DGTitle.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGTitle.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGTitle.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGTitle.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGTitle.ThemeStyle.HeaderStyle.Height = 40;
            this.DGTitle.ThemeStyle.ReadOnly = true;
            this.DGTitle.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGTitle.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGTitle.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGTitle.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGTitle.ThemeStyle.RowsStyle.Height = 28;
            this.DGTitle.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGTitle.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // item_number
            // 
            this.item_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.item_number.DataPropertyName = "item_number";
            this.item_number.HeaderText = "#";
            this.item_number.MinimumWidth = 8;
            this.item_number.Name = "item_number";
            this.item_number.ReadOnly = true;
            this.item_number.Width = 59;
            // 
            // title_name
            // 
            this.title_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.title_name.DataPropertyName = "title";
            this.title_name.HeaderText = "TITLE";
            this.title_name.MinimumWidth = 8;
            this.title_name.Name = "title_name";
            this.title_name.ReadOnly = true;
            this.title_name.Width = 91;
            // 
            // retention_period
            // 
            this.retention_period.DataPropertyName = "retention_period";
            this.retention_period.HeaderText = "RETENTION PERIOD";
            this.retention_period.MinimumWidth = 8;
            this.retention_period.Name = "retention_period";
            this.retention_period.ReadOnly = true;
            this.retention_period.Width = 221;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "CODE";
            this.code.MinimumWidth = 8;
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 97;
            // 
            // cat_id
            // 
            this.cat_id.DataPropertyName = "cat_id";
            this.cat_id.HeaderText = "CATEGORY ID";
            this.cat_id.MinimumWidth = 8;
            this.cat_id.Name = "cat_id";
            this.cat_id.ReadOnly = true;
            this.cat_id.Visible = false;
            this.cat_id.Width = 167;
            // 
            // cat_name
            // 
            this.cat_name.DataPropertyName = "category_name";
            this.cat_name.HeaderText = "FROM CATEGORY";
            this.cat_name.MinimumWidth = 8;
            this.cat_name.Name = "cat_name";
            this.cat_name.ReadOnly = true;
            this.cat_name.Width = 203;
            // 
            // btnUpdateTitle
            // 
            this.btnUpdateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateTitle.BorderRadius = 10;
            this.btnUpdateTitle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateTitle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdateTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdateTitle.FillColor = System.Drawing.Color.Blue;
            this.btnUpdateTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdateTitle.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTitle.Location = new System.Drawing.Point(542, 136);
            this.btnUpdateTitle.Name = "btnUpdateTitle";
            this.btnUpdateTitle.Size = new System.Drawing.Size(112, 48);
            this.btnUpdateTitle.TabIndex = 12;
            this.btnUpdateTitle.Text = "UPDATE";
            this.btnUpdateTitle.Click += new System.EventHandler(this.btnUpdateTitle_Click);
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTitle.BorderRadius = 10;
            this.btnAddTitle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTitle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddTitle.FillColor = System.Drawing.Color.Blue;
            this.btnAddTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddTitle.ForeColor = System.Drawing.Color.White;
            this.btnAddTitle.Location = new System.Drawing.Point(422, 136);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(112, 48);
            this.btnAddTitle.TabIndex = 11;
            this.btnAddTitle.Text = "ADD";
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Title";
            this.Size = new System.Drawing.Size(813, 650);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnDeleteTitle;
        private Guna.UI2.WinForms.Guna2DataGridView DGTitle;
        private Guna.UI2.WinForms.Guna2Button btnUpdateTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn title_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn retention_period;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cat_name;
    }
}
