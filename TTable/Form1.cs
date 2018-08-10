using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TTable
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }


        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Login logForm = new Login())
            {
                logForm.ShowDialog();
                
                loginToolStripMenuItem.Enabled = false;
                changePasswordToolStripMenuItem.Enabled = false;
                subjectOfferingToolStripMenuItem.Enabled = true;
                teacherScheduleToolStripMenuItem.Enabled = true;
                classScheduleToolStripMenuItem.Enabled = true;
                teachersScheduleToolStripMenuItem.Enabled = true;
               }
               
            }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            loginToolStripMenuItem.Enabled = true;
            changePasswordToolStripMenuItem.Enabled = false;
            subjectOfferingToolStripMenuItem.Enabled = false;
            teacherScheduleToolStripMenuItem.Enabled = false;
            classScheduleToolStripMenuItem.Enabled = false;
            teachersScheduleToolStripMenuItem.Enabled = false;

        }

        private void subjectOfferingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subjects subForm = new Subjects();
            subForm.MdiParent = this;
            
            subForm.WindowState = FormWindowState.Maximized;
            subForm.Show();
            subForm.Activate();
        }

        private void classScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule scheduleForm = new Schedule();
            scheduleForm.MdiParent = this;
            scheduleForm.WindowState = FormWindowState.Maximized;
            scheduleForm.Show();
            scheduleForm.Activate();
        }

        private void teacherScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher teacherForm = new Teacher();
            teacherForm.MdiParent = this;
            teacherForm.WindowState = FormWindowState.Maximized;
            teacherForm.Show();
            teacherForm.Activate();
        }

        private void teachersScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Teacher_Schedule teachScheduleFrm = new Teacher_Schedule();
            //teachScheduleFrm.MdiParent = this;
            //teachScheduleFrm.WindowState = FormWindowState.Maximized;
            //teachScheduleFrm.Show();
            //teachScheduleFrm.Activate();

            ViewTeacherSchedule viewTeacher = new ViewTeacherSchedule();
            viewTeacher.MdiParent = this;
            viewTeacher.WindowState = FormWindowState.Maximized;
            viewTeacher.Show();
            viewTeacher.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
