namespace Student_Hostel_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRoom = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnRollCall = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelSlide = new System.Windows.Forms.Panel();
            this.btnPolicy = new System.Windows.Forms.Button();
            this.btnFee = new System.Windows.Forms.Button();
            this.btnParent = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogo.SuspendLayout();
            this.panelSlide.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(978, 604);
            this.panelMain.TabIndex = 5;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Green;
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(200, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(978, 40);
            this.panelTitle.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(316, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(351, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TitleName";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(5, 97);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 27);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ln";
            this.lblName.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(52, 115);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(129, 27);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "UserName";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(42, 145);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(163, 27);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Administrator";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnRoom
            // 
            this.btnRoom.BackColor = System.Drawing.Color.DarkGreen;
            this.btnRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoom.FlatAppearance.BorderSize = 0;
            this.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoom.ForeColor = System.Drawing.Color.White;
            this.btnRoom.Image = ((System.Drawing.Image)(resources.GetObject("btnRoom.Image")));
            this.btnRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.Location = new System.Drawing.Point(0, 215);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRoom.Size = new System.Drawing.Size(200, 45);
            this.btnRoom.TabIndex = 2;
            this.btnRoom.Text = " Room";
            this.btnRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRoom.UseVisualStyleBackColor = false;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Green;
            this.panelLogo.Controls.Add(this.lblName);
            this.panelLogo.Controls.Add(this.lblUsername);
            this.panelLogo.Controls.Add(this.lblRole);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 170);
            this.panelLogo.TabIndex = 1;
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.DarkGreen;
            this.btnStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Image = ((System.Drawing.Image)(resources.GetObject("btnStudents.Image")));
            this.btnStudents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.Location = new System.Drawing.Point(0, 260);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnStudents.Size = new System.Drawing.Size(200, 45);
            this.btnStudents.TabIndex = 3;
            this.btnStudents.Text = " Student";
            this.btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnRollCall
            // 
            this.btnRollCall.BackColor = System.Drawing.Color.DarkGreen;
            this.btnRollCall.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRollCall.FlatAppearance.BorderSize = 0;
            this.btnRollCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollCall.ForeColor = System.Drawing.Color.White;
            this.btnRollCall.Image = ((System.Drawing.Image)(resources.GetObject("btnRollCall.Image")));
            this.btnRollCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRollCall.Location = new System.Drawing.Point(0, 395);
            this.btnRollCall.Name = "btnRollCall";
            this.btnRollCall.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRollCall.Size = new System.Drawing.Size(200, 45);
            this.btnRollCall.TabIndex = 5;
            this.btnRollCall.Text = " Attendance";
            this.btnRollCall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRollCall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRollCall.UseVisualStyleBackColor = false;
            this.btnRollCall.Click += new System.EventHandler(this.btnRollCall_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(0, 485);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(200, 45);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = " Setting";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Maroon;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 599);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelSlide
            // 
            this.panelSlide.AutoScroll = true;
            this.panelSlide.BackColor = System.Drawing.Color.Green;
            this.panelSlide.Controls.Add(this.btnLogout);
            this.panelSlide.Controls.Add(this.btnSetting);
            this.panelSlide.Controls.Add(this.btnPolicy);
            this.panelSlide.Controls.Add(this.btnRollCall);
            this.panelSlide.Controls.Add(this.btnFee);
            this.panelSlide.Controls.Add(this.btnParent);
            this.panelSlide.Controls.Add(this.btnStudents);
            this.panelSlide.Controls.Add(this.btnRoom);
            this.panelSlide.Controls.Add(this.btnDashboard);
            this.panelSlide.Controls.Add(this.panelLogo);
            this.panelSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlide.Location = new System.Drawing.Point(0, 0);
            this.panelSlide.Name = "panelSlide";
            this.panelSlide.Size = new System.Drawing.Size(200, 644);
            this.panelSlide.TabIndex = 3;
            // 
            // btnPolicy
            // 
            this.btnPolicy.BackColor = System.Drawing.Color.DarkGreen;
            this.btnPolicy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPolicy.FlatAppearance.BorderSize = 0;
            this.btnPolicy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPolicy.ForeColor = System.Drawing.Color.White;
            this.btnPolicy.Image = ((System.Drawing.Image)(resources.GetObject("btnPolicy.Image")));
            this.btnPolicy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPolicy.Location = new System.Drawing.Point(0, 440);
            this.btnPolicy.Name = "btnPolicy";
            this.btnPolicy.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnPolicy.Size = new System.Drawing.Size(200, 45);
            this.btnPolicy.TabIndex = 11;
            this.btnPolicy.Text = " Rules";
            this.btnPolicy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPolicy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPolicy.UseVisualStyleBackColor = false;
            this.btnPolicy.Click += new System.EventHandler(this.btnPolicy_Click);
            // 
            // btnFee
            // 
            this.btnFee.BackColor = System.Drawing.Color.DarkGreen;
            this.btnFee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFee.FlatAppearance.BorderSize = 0;
            this.btnFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFee.ForeColor = System.Drawing.Color.White;
            this.btnFee.Image = ((System.Drawing.Image)(resources.GetObject("btnFee.Image")));
            this.btnFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFee.Location = new System.Drawing.Point(0, 350);
            this.btnFee.Name = "btnFee";
            this.btnFee.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFee.Size = new System.Drawing.Size(200, 45);
            this.btnFee.TabIndex = 4;
            this.btnFee.Text = " Fee";
            this.btnFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFee.UseVisualStyleBackColor = false;
            this.btnFee.Click += new System.EventHandler(this.btnFee_Click);
            // 
            // btnParent
            // 
            this.btnParent.BackColor = System.Drawing.Color.DarkGreen;
            this.btnParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnParent.FlatAppearance.BorderSize = 0;
            this.btnParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParent.ForeColor = System.Drawing.Color.White;
            this.btnParent.Image = ((System.Drawing.Image)(resources.GetObject("btnParent.Image")));
            this.btnParent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParent.Location = new System.Drawing.Point(0, 305);
            this.btnParent.Name = "btnParent";
            this.btnParent.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnParent.Size = new System.Drawing.Size(200, 45);
            this.btnParent.TabIndex = 10;
            this.btnParent.Text = " Parent";
            this.btnParent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnParent.UseVisualStyleBackColor = false;
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 170);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = " Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1178, 644);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelSlide);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hostel Management";
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelSlide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnRollCall;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelSlide;
        public System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnFee;
        public System.Windows.Forms.Button btnParent;
        private System.Windows.Forms.Button btnPolicy;
    }
}