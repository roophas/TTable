namespace TTable
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectOfferingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutShikshaTimeTableViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(862, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.actionToolStripMenuItem.Text = "Login";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectOfferingToolStripMenuItem,
            this.teacherScheduleToolStripMenuItem,
            this.classScheduleToolStripMenuItem,
            this.teachersScheduleToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.viewToolStripMenuItem.Text = "Manage";
            // 
            // subjectOfferingToolStripMenuItem
            // 
            this.subjectOfferingToolStripMenuItem.Name = "subjectOfferingToolStripMenuItem";
            this.subjectOfferingToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.subjectOfferingToolStripMenuItem.Text = "Subject Offering";
            this.subjectOfferingToolStripMenuItem.Click += new System.EventHandler(this.subjectOfferingToolStripMenuItem_Click);
            // 
            // teacherScheduleToolStripMenuItem
            // 
            this.teacherScheduleToolStripMenuItem.Name = "teacherScheduleToolStripMenuItem";
            this.teacherScheduleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.teacherScheduleToolStripMenuItem.Text = "Add Teachers";
            this.teacherScheduleToolStripMenuItem.Click += new System.EventHandler(this.teacherScheduleToolStripMenuItem_Click);
            // 
            // classScheduleToolStripMenuItem
            // 
            this.classScheduleToolStripMenuItem.Name = "classScheduleToolStripMenuItem";
            this.classScheduleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.classScheduleToolStripMenuItem.Text = "Class Schedule";
            this.classScheduleToolStripMenuItem.Click += new System.EventHandler(this.classScheduleToolStripMenuItem_Click);
            // 
            // teachersScheduleToolStripMenuItem
            // 
            this.teachersScheduleToolStripMenuItem.Name = "teachersScheduleToolStripMenuItem";
            this.teachersScheduleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.teachersScheduleToolStripMenuItem.Text = "Teachers Schedule";
            this.teachersScheduleToolStripMenuItem.Click += new System.EventHandler(this.teachersScheduleToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutShikshaTimeTableViewerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutShikshaTimeTableViewerToolStripMenuItem
            // 
            this.aboutShikshaTimeTableViewerToolStripMenuItem.Name = "aboutShikshaTimeTableViewerToolStripMenuItem";
            this.aboutShikshaTimeTableViewerToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.aboutShikshaTimeTableViewerToolStripMenuItem.Text = "About Shiksha TimeTable Viewer";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 399);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shiksha - Time Table Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectOfferingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teacherScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutShikshaTimeTableViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachersScheduleToolStripMenuItem;
    }
}

