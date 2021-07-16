
namespace NetworkAddresser.Forms
{
    partial class ApplyProfileForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.tvAdapterProfiles = new System.Windows.Forms.TreeView();
            this.btnApplyProfile = new System.Windows.Forms.Button();
            this.btnReloadProfiles = new System.Windows.Forms.Button();
            this.btnAddProfile = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnQuit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteProfile, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tvAdapterProfiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnApplyProfile, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnReloadProfiles, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAddProfile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEditProfile, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 313);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnQuit
            // 
            this.btnQuit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuit.Location = new System.Drawing.Point(217, 284);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(103, 26);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteProfile.Enabled = false;
            this.btnDeleteProfile.Location = new System.Drawing.Point(217, 3);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(103, 25);
            this.btnDeleteProfile.TabIndex = 5;
            this.btnDeleteProfile.Text = "Delete Profile";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // tvAdapterProfiles
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tvAdapterProfiles, 3);
            this.tvAdapterProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAdapterProfiles.FullRowSelect = true;
            this.tvAdapterProfiles.Location = new System.Drawing.Point(3, 34);
            this.tvAdapterProfiles.Name = "tvAdapterProfiles";
            this.tvAdapterProfiles.Size = new System.Drawing.Size(317, 244);
            this.tvAdapterProfiles.TabIndex = 0;
            this.tvAdapterProfiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAdapterProfiles_AfterSelect);
            this.tvAdapterProfiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvAdapterProfiles_MouseDoubleClick);
            // 
            // btnApplyProfile
            // 
            this.btnApplyProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApplyProfile.Enabled = false;
            this.btnApplyProfile.Location = new System.Drawing.Point(3, 284);
            this.btnApplyProfile.Name = "btnApplyProfile";
            this.btnApplyProfile.Size = new System.Drawing.Size(101, 26);
            this.btnApplyProfile.TabIndex = 1;
            this.btnApplyProfile.Text = "Apply Profile";
            this.btnApplyProfile.UseVisualStyleBackColor = true;
            this.btnApplyProfile.Click += new System.EventHandler(this.btnApplyProfile_Click);
            // 
            // btnReloadProfiles
            // 
            this.btnReloadProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReloadProfiles.Location = new System.Drawing.Point(110, 284);
            this.btnReloadProfiles.Name = "btnReloadProfiles";
            this.btnReloadProfiles.Size = new System.Drawing.Size(101, 26);
            this.btnReloadProfiles.TabIndex = 2;
            this.btnReloadProfiles.Text = "Reload";
            this.btnReloadProfiles.UseVisualStyleBackColor = true;
            this.btnReloadProfiles.Click += new System.EventHandler(this.btnReloadProfiles_Click);
            // 
            // btnAddProfile
            // 
            this.btnAddProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddProfile.Location = new System.Drawing.Point(3, 3);
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(101, 25);
            this.btnAddProfile.TabIndex = 3;
            this.btnAddProfile.Text = "Add Profile";
            this.btnAddProfile.UseVisualStyleBackColor = true;
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditProfile.Enabled = false;
            this.btnEditProfile.Location = new System.Drawing.Point(110, 3);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(101, 25);
            this.btnEditProfile.TabIndex = 4;
            this.btnEditProfile.Text = "Edit Profile";
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // ApplyProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 313);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ApplyProfileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tvAdapterProfiles;
        private System.Windows.Forms.Button btnApplyProfile;
        private System.Windows.Forms.Button btnReloadProfiles;
        private System.Windows.Forms.Button btnAddProfile;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Button btnQuit;
    }
}