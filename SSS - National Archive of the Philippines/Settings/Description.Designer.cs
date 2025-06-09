namespace SSS___National_Archive_of_the_Philippines
{
    partial class Description
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
            this.lblDescription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnDeleteTitle = new Guna.UI2.WinForms.Guna2Button();
            this.DGDescription = new Guna.UI2.WinForms.Guna2DataGridView();
            this.item_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retention_period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtitle_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateTitle = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddTitle = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.lblDescription);
            this.guna2Panel1.Controls.Add(this.btnDeleteTitle);
            this.guna2Panel1.Controls.Add(this.DGDescription);
            this.guna2Panel1.Controls.Add(this.btnUpdateTitle);
            this.guna2Panel1.Controls.Add(this.btnAddTitle);
            this.guna2Panel1.Location = new System.Drawing.Point(14, 17);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(785, 616);
            this.guna2Panel1.TabIndex = 17;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(208, 16);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(362, 47);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = "MANAGE DESCRIPTION";
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
            // DGDescription
            // 
            this.DGDescription.AllowUserToAddRows = false;
            this.DGDescription.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGDescription.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGDescription.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGDescription.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGDescription.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGDescription.ColumnHeadersHeight = 40;
            this.DGDescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGDescription.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_number,
            this.description_name,
            this.retention_period,
            this.code,
            this.subtitle_id,
            this.subtitle});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGDescription.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGDescription.Location = new System.Drawing.Point(0, 192);
            this.DGDescription.Name = "DGDescription";
            this.DGDescription.ReadOnly = true;
            this.DGDescription.RowHeadersVisible = false;
            this.DGDescription.RowHeadersWidth = 70;
            this.DGDescription.RowTemplate.Height = 28;
            this.DGDescription.Size = new System.Drawing.Size(782, 420);
            this.DGDescription.TabIndex = 14;
            this.DGDescription.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGDescription.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGDescription.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGDescription.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGDescription.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGDescription.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGDescription.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGDescription.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Blue;
            this.DGDescription.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGDescription.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGDescription.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGDescription.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGDescription.ThemeStyle.HeaderStyle.Height = 40;
            this.DGDescription.ThemeStyle.ReadOnly = true;
            this.DGDescription.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGDescription.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGDescription.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGDescription.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGDescription.ThemeStyle.RowsStyle.Height = 28;
            this.DGDescription.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGDescription.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            // description_name
            // 
            this.description_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.description_name.DataPropertyName = "description";
            this.description_name.HeaderText = "DESCRIPTION";
            this.description_name.MinimumWidth = 8;
            this.description_name.Name = "description_name";
            this.description_name.ReadOnly = true;
            this.description_name.Width = 167;
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
            // subtitle_id
            // 
            this.subtitle_id.DataPropertyName = "subtitle_id";
            this.subtitle_id.HeaderText = "SUBTITLE ID";
            this.subtitle_id.MinimumWidth = 8;
            this.subtitle_id.Name = "subtitle_id";
            this.subtitle_id.ReadOnly = true;
            this.subtitle_id.Visible = false;
            this.subtitle_id.Width = 150;
            // 
            // subtitle
            // 
            this.subtitle.DataPropertyName = "subtitle";
            this.subtitle.HeaderText = "FROM SUBTITLE";
            this.subtitle.MinimumWidth = 8;
            this.subtitle.Name = "subtitle";
            this.subtitle.ReadOnly = true;
            this.subtitle.Width = 186;
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
            // Description
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Description";
            this.Size = new System.Drawing.Size(813, 650);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnDeleteTitle;
        private Guna.UI2.WinForms.Guna2DataGridView DGDescription;
        private Guna.UI2.WinForms.Guna2Button btnUpdateTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn description_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn retention_period;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtitle_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtitle;
    }
}
