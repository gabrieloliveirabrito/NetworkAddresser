
namespace NetworkAddresser.Forms
{
    partial class AddProfileForm
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
            this.tlpAddProfile = new System.Windows.Forms.TableLayoutPanel();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblGateway = new System.Windows.Forms.Label();
            this.lblDNS1 = new System.Windows.Forms.Label();
            this.lblDNS2 = new System.Windows.Forms.Label();
            this.lblSubnetMask = new System.Windows.Forms.Label();
            this.cbDHCP = new System.Windows.Forms.CheckBox();
            this.lblAdapters = new System.Windows.Forms.Label();
            this.btnCreateProfile = new System.Windows.Forms.Button();
            this.cbAdapters = new System.Windows.Forms.ComboBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtSubnet = new System.Windows.Forms.TextBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtDNS1 = new System.Windows.Forms.TextBox();
            this.txtDNS2 = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tlpAddProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAddProfile
            // 
            this.tlpAddProfile.ColumnCount = 3;
            this.tlpAddProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpAddProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpAddProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpAddProfile.Controls.Add(this.txtProfileName, 1, 1);
            this.tlpAddProfile.Controls.Add(this.lblIPAddress, 0, 3);
            this.tlpAddProfile.Controls.Add(this.lblGateway, 0, 5);
            this.tlpAddProfile.Controls.Add(this.lblDNS1, 0, 6);
            this.tlpAddProfile.Controls.Add(this.lblDNS2, 0, 7);
            this.tlpAddProfile.Controls.Add(this.lblSubnetMask, 0, 4);
            this.tlpAddProfile.Controls.Add(this.cbDHCP, 1, 2);
            this.tlpAddProfile.Controls.Add(this.lblAdapters, 0, 0);
            this.tlpAddProfile.Controls.Add(this.btnCreateProfile, 0, 8);
            this.tlpAddProfile.Controls.Add(this.cbAdapters, 1, 0);
            this.tlpAddProfile.Controls.Add(this.btnReload, 2, 0);
            this.tlpAddProfile.Controls.Add(this.txtIPAddress, 1, 3);
            this.tlpAddProfile.Controls.Add(this.txtSubnet, 1, 4);
            this.tlpAddProfile.Controls.Add(this.txtGateway, 1, 5);
            this.tlpAddProfile.Controls.Add(this.txtDNS1, 1, 6);
            this.tlpAddProfile.Controls.Add(this.txtDNS2, 1, 7);
            this.tlpAddProfile.Controls.Add(this.lblName, 0, 1);
            this.tlpAddProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAddProfile.Location = new System.Drawing.Point(0, 0);
            this.tlpAddProfile.Name = "tlpAddProfile";
            this.tlpAddProfile.RowCount = 9;
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAddProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAddProfile.Size = new System.Drawing.Size(572, 360);
            this.tlpAddProfile.TabIndex = 0;
            // 
            // txtProfileName
            // 
            this.tlpAddProfile.SetColumnSpan(this.txtProfileName, 2);
            this.txtProfileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProfileName.Location = new System.Drawing.Point(94, 45);
            this.txtProfileName.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(469, 20);
            this.txtProfileName.TabIndex = 16;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIPAddress.Location = new System.Drawing.Point(5, 113);
            this.lblIPAddress.Margin = new System.Windows.Forms.Padding(5);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(75, 26);
            this.lblIPAddress.TabIndex = 6;
            this.lblIPAddress.Text = "IP Address";
            this.lblIPAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGateway
            // 
            this.lblGateway.AutoSize = true;
            this.lblGateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGateway.Location = new System.Drawing.Point(5, 185);
            this.lblGateway.Margin = new System.Windows.Forms.Padding(5);
            this.lblGateway.Name = "lblGateway";
            this.lblGateway.Size = new System.Drawing.Size(75, 26);
            this.lblGateway.TabIndex = 5;
            this.lblGateway.Text = "Gateway";
            this.lblGateway.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDNS1
            // 
            this.lblDNS1.AutoSize = true;
            this.lblDNS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNS1.Location = new System.Drawing.Point(5, 221);
            this.lblDNS1.Margin = new System.Windows.Forms.Padding(5);
            this.lblDNS1.Name = "lblDNS1";
            this.lblDNS1.Size = new System.Drawing.Size(75, 26);
            this.lblDNS1.TabIndex = 4;
            this.lblDNS1.Text = "DNS 1";
            this.lblDNS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDNS2
            // 
            this.lblDNS2.AutoSize = true;
            this.lblDNS2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDNS2.Location = new System.Drawing.Point(5, 257);
            this.lblDNS2.Margin = new System.Windows.Forms.Padding(5);
            this.lblDNS2.Name = "lblDNS2";
            this.lblDNS2.Size = new System.Drawing.Size(75, 26);
            this.lblDNS2.TabIndex = 3;
            this.lblDNS2.Text = "DNS 2";
            this.lblDNS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubnetMask
            // 
            this.lblSubnetMask.AutoSize = true;
            this.lblSubnetMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubnetMask.Location = new System.Drawing.Point(5, 149);
            this.lblSubnetMask.Margin = new System.Windows.Forms.Padding(5);
            this.lblSubnetMask.Name = "lblSubnetMask";
            this.lblSubnetMask.Size = new System.Drawing.Size(75, 26);
            this.lblSubnetMask.TabIndex = 2;
            this.lblSubnetMask.Text = "Subnet mask";
            this.lblSubnetMask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbDHCP
            // 
            this.cbDHCP.AutoSize = true;
            this.cbDHCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDHCP.Location = new System.Drawing.Point(94, 81);
            this.cbDHCP.Margin = new System.Windows.Forms.Padding(9);
            this.cbDHCP.Name = "cbDHCP";
            this.cbDHCP.Size = new System.Drawing.Size(382, 18);
            this.cbDHCP.TabIndex = 0;
            this.cbDHCP.Text = "Use DHCP";
            this.cbDHCP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDHCP.UseVisualStyleBackColor = true;
            this.cbDHCP.CheckedChanged += new System.EventHandler(this.cbDHCP_CheckedChanged);
            // 
            // lblAdapters
            // 
            this.lblAdapters.AutoSize = true;
            this.lblAdapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdapters.Location = new System.Drawing.Point(5, 5);
            this.lblAdapters.Margin = new System.Windows.Forms.Padding(5);
            this.lblAdapters.Name = "lblAdapters";
            this.lblAdapters.Size = new System.Drawing.Size(75, 26);
            this.lblAdapters.TabIndex = 1;
            this.lblAdapters.Text = "Adapter";
            this.lblAdapters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateProfile
            // 
            this.tlpAddProfile.SetColumnSpan(this.btnCreateProfile, 3);
            this.btnCreateProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateProfile.Location = new System.Drawing.Point(15, 303);
            this.btnCreateProfile.Margin = new System.Windows.Forms.Padding(15);
            this.btnCreateProfile.Name = "btnCreateProfile";
            this.btnCreateProfile.Size = new System.Drawing.Size(542, 42);
            this.btnCreateProfile.TabIndex = 7;
            this.btnCreateProfile.Text = "Create Profile";
            this.btnCreateProfile.UseVisualStyleBackColor = true;
            this.btnCreateProfile.Click += new System.EventHandler(this.btnCreateProfile_Click);
            // 
            // cbAdapters
            // 
            this.cbAdapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAdapters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdapters.FormattingEnabled = true;
            this.cbAdapters.Location = new System.Drawing.Point(94, 6);
            this.cbAdapters.Margin = new System.Windows.Forms.Padding(9, 6, 9, 3);
            this.cbAdapters.Name = "cbAdapters";
            this.cbAdapters.Size = new System.Drawing.Size(382, 21);
            this.cbAdapters.TabIndex = 8;
            // 
            // btnReload
            // 
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReload.Location = new System.Drawing.Point(488, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(81, 30);
            this.btnReload.TabIndex = 9;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtIPAddress
            // 
            this.tlpAddProfile.SetColumnSpan(this.txtIPAddress, 2);
            this.txtIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIPAddress.Location = new System.Drawing.Point(94, 117);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(469, 20);
            this.txtIPAddress.TabIndex = 10;
            this.txtIPAddress.Leave += new System.EventHandler(this.txtIPAddress_TextChanged);
            // 
            // txtSubnet
            // 
            this.tlpAddProfile.SetColumnSpan(this.txtSubnet, 2);
            this.txtSubnet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSubnet.Location = new System.Drawing.Point(94, 153);
            this.txtSubnet.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.txtSubnet.Name = "txtSubnet";
            this.txtSubnet.Size = new System.Drawing.Size(469, 20);
            this.txtSubnet.TabIndex = 11;
            // 
            // txtGateway
            // 
            this.tlpAddProfile.SetColumnSpan(this.txtGateway, 2);
            this.txtGateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGateway.Location = new System.Drawing.Point(94, 189);
            this.txtGateway.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(469, 20);
            this.txtGateway.TabIndex = 12;
            // 
            // txtDNS1
            // 
            this.tlpAddProfile.SetColumnSpan(this.txtDNS1, 2);
            this.txtDNS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDNS1.Location = new System.Drawing.Point(94, 225);
            this.txtDNS1.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.txtDNS1.Name = "txtDNS1";
            this.txtDNS1.Size = new System.Drawing.Size(469, 20);
            this.txtDNS1.TabIndex = 13;
            // 
            // txtDNS2
            // 
            this.tlpAddProfile.SetColumnSpan(this.txtDNS2, 2);
            this.txtDNS2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDNS2.Location = new System.Drawing.Point(94, 261);
            this.txtDNS2.Margin = new System.Windows.Forms.Padding(9, 9, 9, 3);
            this.txtDNS2.Name = "txtDNS2";
            this.txtDNS2.Size = new System.Drawing.Size(469, 20);
            this.txtDNS2.TabIndex = 14;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(5, 41);
            this.lblName.Margin = new System.Windows.Forms.Padding(5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 26);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Profile Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 360);
            this.Controls.Add(this.tlpAddProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetworkAddresser - Add Profile";
            this.tlpAddProfile.ResumeLayout(false);
            this.tlpAddProfile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAddProfile;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label lblGateway;
        private System.Windows.Forms.Label lblDNS1;
        private System.Windows.Forms.Label lblDNS2;
        private System.Windows.Forms.Label lblSubnetMask;
        private System.Windows.Forms.CheckBox cbDHCP;
        private System.Windows.Forms.Label lblAdapters;
        private System.Windows.Forms.Button btnCreateProfile;
        private System.Windows.Forms.ComboBox cbAdapters;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtSubnet;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.TextBox txtDNS1;
        private System.Windows.Forms.TextBox txtDNS2;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Label lblName;
    }
}