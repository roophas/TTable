namespace TTable
{
    partial class UserMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnClass = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnClass,
            this.subjectToolStripMenuItem,
            this.teacherToolStripMenuItem,
            this.timeTableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(576, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnClass
            // 
            this.mnClass.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeleteClassToolStripMenuItem});
            this.mnClass.Name = "mnClass";
            this.mnClass.Size = new System.Drawing.Size(46, 20);
            this.mnClass.Text = "Class";
            // 
            // addDeleteClassToolStripMenuItem
            // 
            this.addDeleteClassToolStripMenuItem.Name = "addDeleteClassToolStripMenuItem";
            this.addDeleteClassToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addDeleteClassToolStripMenuItem.Text = "Add/Delete Class";
            // 
            // subjectToolStripMenuItem
            // 
            this.subjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeleteSubjectToolStripMenuItem,
            this.assignClassToolStripMenuItem,
            this.assignTeacherToolStripMenuItem});
            this.subjectToolStripMenuItem.Name = "subjectToolStripMenuItem";
            this.subjectToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.subjectToolStripMenuItem.Text = "Subject";
            // 
            // addDeleteSubjectToolStripMenuItem
            // 
            this.addDeleteSubjectToolStripMenuItem.Name = "addDeleteSubjectToolStripMenuItem";
            this.addDeleteSubjectToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addDeleteSubjectToolStripMenuItem.Text = "Add/Delete Subject";
            // 
            // assignClassToolStripMenuItem
            // 
            this.assignClassToolStripMenuItem.Name = "assignClassToolStripMenuItem";
            this.assignClassToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.assignClassToolStripMenuItem.Text = "Assign Class";
            // 
            // assignTeacherToolStripMenuItem
            // 
            this.assignTeacherToolStripMenuItem.Name = "assignTeacherToolStripMenuItem";
            this.assignTeacherToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.assignTeacherToolStripMenuItem.Text = "Assign Teacher";
            // 
            // teacherToolStripMenuItem
            // 
            this.teacherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeleteTeacherToolStripMenuItem});
            this.teacherToolStripMenuItem.Name = "teacherToolStripMenuItem";
            this.teacherToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.teacherToolStripMenuItem.Text = "Teacher";
            // 
            // addDeleteTeacherToolStripMenuItem
            // 
            this.addDeleteTeacherToolStripMenuItem.Name = "addDeleteTeacherToolStripMenuItem";
            this.addDeleteTeacherToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addDeleteTeacherToolStripMenuItem.Text = "Add/Delete Teacher";
            // 
            // timeTableToolStripMenuItem
            // 
            this.timeTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPeriodToolStripMenuItem});
            this.timeTableToolStripMenuItem.Name = "timeTableToolStripMenuItem";
            this.timeTableToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.timeTableToolStripMenuItem.Text = "Time Table";
            // 
            // addPeriodToolStripMenuItem
            // 
            this.addPeriodToolStripMenuItem.Name = "addPeriodToolStripMenuItem";
            this.addPeriodToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addPeriodToolStripMenuItem.Text = "Add Period";
            // 
            // UserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Name = "UserMenu";
            this.Size = new System.Drawing.Size(576, 277);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnClass;
        private System.Windows.Forms.ToolStripMenuItem addDeleteClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeleteSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeleteTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPeriodToolStripMenuItem;
    }
}
