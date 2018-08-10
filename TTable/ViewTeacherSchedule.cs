using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;
using Calendar;

namespace TTable
{
    public partial class ViewTeacherSchedule : Form
    {
        string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;
        List<Appointment> m_Appointments;

        public ViewTeacherSchedule()
        {
            InitializeComponent();
        }

        private void ViewTeacherSchedule_Load(object sender, EventArgs e)
        {
            // Load Year combo box
            OleDbConnection oleConn = new OleDbConnection(conText);
            oleConn.Open();

            OleDbDataAdapter yrAdapter = new OleDbDataAdapter("Select * from AcYear", oleConn);
            DataSet dsYear = new DataSet();
            yrAdapter.Fill(dsYear);

            cbAcYear.DisplayMember = "AcademicYear";
            cbAcYear.ValueMember = "AcademicYear";

            cbAcYear.DataSource = dsYear.Tables[0];
            cbAcYear.SelectedIndex = dsYear.Tables[0].Rows.Count - 1;
            
            //Load Teachers combobox
            string teachQuery = "Select TeacherName from Teacher where AcademicYear like '" + cbAcYear.SelectedValue.ToString() +"'";
            
            OleDbDataAdapter teacAdapter = new OleDbDataAdapter(teachQuery, oleConn);
            DataTable dtTeacher = new DataTable();
            teacAdapter.Fill(dtTeacher);
            cbTeacherName.DataSource = dtTeacher;
            cbTeacherName.DisplayMember = "TeacherName";
            cbTeacherName.ValueMember = "TeacherName";

        }

        private void cbAcYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strTeacher = "Select * from Teacher where AcademicYear like '" + cbAcYear.SelectedValue.ToString() + "'";

            try
            {
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();
                OleDbDataAdapter teachAdapter = new OleDbDataAdapter(strTeacher, oleConn);
                DataSet dsTeacher = new DataSet();
                teachAdapter.Fill(dsTeacher);
                //cbTeacherName.Items.Clear();
                cbTeacherName.Text = "";

                cbTeacherName.DataSource = dsTeacher.Tables[0];
                cbTeacherName.DisplayMember = "TeacherName";
                cbTeacherName.ValueMember = "TeacherName";

                oleConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbTeacherName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load day schedule for the teacher

            try
            {
                string strTeacher = "Select * from Teacher where AcademicYear like '" + cbAcYear.SelectedValue.ToString() + "'";
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();
                OleDbDataAdapter teachAdapter = new OleDbDataAdapter(strTeacher, oleConn);
                DataSet dsTeacher = new DataSet();
                teachAdapter.Fill(dsTeacher);

                List<classTeachers> clsTeacher = new List<classTeachers>();
                int subCount = dsTeacher.Tables[0].Rows.Count;
 
                

                for (int s = 0; s < subCount; s++)
                {
                    clsTeacher.Add(new classTeachers()
                    {
                        teacher = dsTeacher.Tables[0].Rows[s][1].ToString(),
                        hoursavailable =Convert.ToInt32(dsTeacher.Tables[0].Rows[s][2]),
                        hoursoccupied = Convert.ToInt32(dsTeacher.Tables[0].Rows[s][3]),
                        subject = dsTeacher.Tables[0].Rows[s][5].ToString(),
                        addsubj = dsTeacher.Tables[0].Rows[s][6].ToString(),
                        allotclass = dsTeacher.Tables[0].Rows[s][7].ToString(),
                        active = Convert.ToBoolean(dsTeacher.Tables[0].Rows[s][9])
                    });
                }

                List<TT> clstimeTable = new List<TT>();
                string strTT = "Select * from TimeTable where AcademicYear like '" + cbAcYear.SelectedValue.ToString() + "'";
                OleDbDataAdapter ttAdapter = new OleDbDataAdapter(strTT, oleConn);
                DataSet dsTT = new DataSet();
                ttAdapter.Fill(dsTT);
                int ttCount = dsTT.Tables[0].Rows.Count;
                //for (int a = 0; a < ttCount; a++)
                //{
                //    clstimeTable.Add(new TT()
                //    {
                //        ACYear = dsTT.Tables[0].Rows[a][1].ToString(),
                //        Class = dsTT.Tables[0].Rows[a][2].ToString(),
                //        Day = Convert.ToInt32(dsTT.Tables[0].Rows[a][3]),
                //        Period = Convert.ToInt32(dsTT.Tables[0].Rows[a][4]),
                //        Subject = dsTT.Tables[0].Rows[a][5].ToString(),
                //        Teacher = dsTT.Tables[0].Rows[a][6].ToString(),
                //        UpdateDate = dsTT.Tables[0].Rows[a][7].ToString()
                //    });
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            m_Appointments = new List<Appointment>();

            DateTime m_Date = DateTime.Now;

            m_Date = m_Date.AddHours(10 - m_Date.Hour);
            m_Date = m_Date.AddMinutes(-m_Date.Minute);

            Appointment m_Appointment = new Appointment();
            m_Appointment.StartDate = m_Date;
            m_Appointment.EndDate = m_Date.AddHours(2);
            m_Appointment.Title = "test1\r\nmultiline";

            m_Appointments.Add(m_Appointment);

            daySchedule.StartDate = DateTime.Now;
            
        }

        private void daySchedule_NewAppointment(object sender, NewAppointmentEventArgs args)
        {
            Appointment m_Appointment = new Appointment();

            m_Appointment.StartDate = args.StartDate;
            m_Appointment.EndDate = args.EndDate;
            m_Appointment.Title = args.Title;

            m_Appointments.Add(m_Appointment);
        }

        private void daySchedule_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void daySchedule_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> m_Apps = new List<Appointment>();

            foreach (Appointment m_App in m_Appointments)
                if ((m_App.StartDate >= args.StartDate) &&
                    (m_App.StartDate <= args.EndDate))
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;
        }

        private void daySchedule_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }
    }

    public class ClassTT
    {
        public string ACYear { get; set; }
        public string Class { get; set; }
        public int Day { get; set; }
        public int Period { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string UpdateDate { get; set; }
    }

    public class classSubject
    {
        public string subject { get; set; }
    }

    public class classTeachers
    {
        public string teacher { get; set; }
        public string subject { get; set; }
        public string addsubj { get; set; }
        public string allotclass { get; set; }
        public int hoursavailable { get; set; }
        public int hoursoccupied { get; set; }
        public bool active { get; set; }
    }

    public class classTeacherLeave
    {
        public string teacher { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string replaceTeacher { get; set; }
    }
}
