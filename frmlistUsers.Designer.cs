namespace TermProject
{
    partial class frmlistUsers
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dGWUsers = new System.Windows.Forms.DataGridView();
            this.clUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGWUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dGWUsers
            // 
            this.dGWUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGWUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clUsername,
            this.clName,
            this.clSurname,
            this.clPassword});
            this.dGWUsers.Location = new System.Drawing.Point(12, 12);
            this.dGWUsers.Name = "dGWUsers";
            this.dGWUsers.RowTemplate.Height = 25;
            this.dGWUsers.Size = new System.Drawing.Size(776, 378);
            this.dGWUsers.TabIndex = 0;
            // 
            // clUsername
            // 
            this.clUsername.HeaderText = "User Name";
            this.clUsername.Name = "clUsername";
            this.clUsername.ReadOnly = true;
            // 
            // clName
            // 
            this.clName.HeaderText = "Name";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            // 
            // clSurname
            // 
            this.clSurname.HeaderText = "Surname";
            this.clSurname.Name = "clSurname";
            this.clSurname.ReadOnly = true;
            // 
            // clPassword
            // 
            this.clPassword.HeaderText = "Password";
            this.clPassword.Name = "clPassword";
            this.clPassword.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total number of Users :";
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Location = new System.Drawing.Point(146, 408);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(13, 15);
            this.lblUserCount.TabIndex = 2;
            this.lblUserCount.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmlistUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblUserCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGWUsers);
            this.Name = "frmlistUsers";
            this.Text = "User List";
            this.Load += new System.EventHandler(this.frmlistUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGWUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dGWUsers;
        private DataGridViewTextBoxColumn clUsername;
        private DataGridViewTextBoxColumn clName;
        private DataGridViewTextBoxColumn clSurname;
        private DataGridViewTextBoxColumn clPassword;
        private Label label1;
        private Label lblUserCount;
        private Button btnClose;
    }
}