namespace HelixReportViewer
{
    partial class MainForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.treeViewReports = new System.Windows.Forms.TreeView();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonLandscape = new System.Windows.Forms.RadioButton();
            this.radioButtonPortrait = new System.Windows.Forms.RadioButton();
            this.radioButtonNoOptimize = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(243, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(903, 604);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // treeViewReports
            // 
            this.treeViewReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewReports.Location = new System.Drawing.Point(12, 119);
            this.treeViewReports.Name = "treeViewReports";
            this.treeViewReports.Size = new System.Drawing.Size(225, 351);
            this.treeViewReports.TabIndex = 1;
            this.treeViewReports.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewReports_NodeMouseClick);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(84, 90);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(84, 12);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(100, 20);
            this.textBoxDatabase.TabIndex = 3;
            this.textBoxDatabase.Text = "RNA1";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(84, 38);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserName.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(84, 64);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.radioButtonLandscape);
            this.groupBox1.Controls.Add(this.radioButtonPortrait);
            this.groupBox1.Controls.Add(this.radioButtonNoOptimize);
            this.groupBox1.Location = new System.Drawing.Point(12, 476);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 140);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optimize Display";
            // 
            // radioButtonLandscape
            // 
            this.radioButtonLandscape.AutoSize = true;
            this.radioButtonLandscape.Location = new System.Drawing.Point(7, 66);
            this.radioButtonLandscape.Name = "radioButtonLandscape";
            this.radioButtonLandscape.Size = new System.Drawing.Size(108, 17);
            this.radioButtonLandscape.TabIndex = 2;
            this.radioButtonLandscape.Text = "Landscape Letter";
            this.radioButtonLandscape.UseVisualStyleBackColor = true;
            this.radioButtonLandscape.CheckedChanged += new System.EventHandler(this.radioButtonLandscape_CheckedChanged);
            // 
            // radioButtonPortrait
            // 
            this.radioButtonPortrait.AutoSize = true;
            this.radioButtonPortrait.Location = new System.Drawing.Point(7, 43);
            this.radioButtonPortrait.Name = "radioButtonPortrait";
            this.radioButtonPortrait.Size = new System.Drawing.Size(88, 17);
            this.radioButtonPortrait.TabIndex = 1;
            this.radioButtonPortrait.Text = "Portrait Letter";
            this.radioButtonPortrait.UseVisualStyleBackColor = true;
            this.radioButtonPortrait.CheckedChanged += new System.EventHandler(this.radioButtonPortrait_CheckedChanged);
            // 
            // radioButtonNoOptimize
            // 
            this.radioButtonNoOptimize.AutoSize = true;
            this.radioButtonNoOptimize.Checked = true;
            this.radioButtonNoOptimize.Location = new System.Drawing.Point(7, 20);
            this.radioButtonNoOptimize.Name = "radioButtonNoOptimize";
            this.radioButtonNoOptimize.Size = new System.Drawing.Size(51, 17);
            this.radioButtonNoOptimize.TabIndex = 0;
            this.radioButtonNoOptimize.TabStop = true;
            this.radioButtonNoOptimize.Text = "None";
            this.radioButtonNoOptimize.UseVisualStyleBackColor = true;
            this.radioButtonNoOptimize.CheckedChanged += new System.EventHandler(this.radioButtonNoOptimize_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 47);
            this.label4.TabIndex = 3;
            this.label4.Text = "* This should only be used if the display is being formatted incorrectly based on your defaul" +
    "t printer (such as a Zebra printer).";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 628);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxDatabase);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.treeViewReports);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "MainForm";
            this.Text = "Helix Reports Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TreeView treeViewReports;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonLandscape;
        private System.Windows.Forms.RadioButton radioButtonPortrait;
        private System.Windows.Forms.RadioButton radioButtonNoOptimize;
        private System.Windows.Forms.Label label4;
    }
}

