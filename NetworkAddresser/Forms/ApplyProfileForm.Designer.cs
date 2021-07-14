
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
            this.tvAdapterProfiles = new System.Windows.Forms.TreeView();
            this.btnApplyProfile = new System.Windows.Forms.Button();
            this.btnReloadProfiles = new System.Windows.Forms.Button();
            this.btnAddProfile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tvAdapterProfiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnApplyProfile, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnReloadProfiles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddProfile, 0, 0);
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
            // tvAdapterProfiles
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tvAdapterProfiles, 2);
            this.tvAdapterProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAdapterProfiles.FullRowSelect = true;
            this.tvAdapterProfiles.Location = new System.Drawing.Point(3, 34);
            this.tvAdapterProfiles.Name = "tvAdapterProfiles";
            this.tvAdapterProfiles.Size = new System.Drawing.Size(317, 244);
            this.tvAdapterProfiles.TabIndex = 0;
            this.tvAdapterProfiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAdapterProfiles_AfterSelect);
            // 
            // btnApplyProfile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnApplyProfile, 2);
            this.btnApplyProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApplyProfile.Enabled = false;
            this.btnApplyProfile.Location = new System.Drawing.Point(3, 284);
            this.btnApplyProfile.Name = "btnApplyProfile";
            this.btnApplyProfile.Size = new System.Drawing.Size(317, 26);
            this.btnApplyProfile.TabIndex = 1;
            this.btnApplyProfile.Text = "Apply Profile";
            this.btnApplyProfile.UseVisualStyleBackColor = true;
            this.btnApplyProfile.Click += new System.EventHandler(this.btnApplyProfile_Click);
            // 
            // btnReloadProfiles
            // 
            this.btnReloadProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReloadProfiles.Location = new System.Drawing.Point(164, 3);
            this.btnReloadProfiles.Name = "btnReloadProfiles";
            this.btnReloadProfiles.Size = new System.Drawing.Size(156, 25);
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
            this.btnAddProfile.Size = new System.Drawing.Size(155, 25);
            this.btnAddProfile.TabIndex = 3;
            this.btnAddProfile.Text = "Add Profile";
            this.btnAddProfile.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tvAdapterProfiles;
        private System.Windows.Forms.Button btnApplyProfile;
        private System.Windows.Forms.Button btnReloadProfiles;
        private System.Windows.Forms.Button btnAddProfile;
    }
}