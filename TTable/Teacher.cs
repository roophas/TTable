using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace TTable
{
    public partial class Teacher : Form
    {
        string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;
        

        public Teacher()
        {
            InitializeComponent();
        }


        private void Teacher_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();
                
                // Populate Year Combo box
                OleDbDataAdapter yrAdapter = new OleDbDataAdapter("Select * from AcYear", oleConn);
                DataSet dsYear = new DataSet();
                yrAdapter.Fill(dsYear);

                cbYear.DisplayMember = "AcademicYear";
                cbYear.ValueMember = "AcademicYear";

                cbYear.DataSource = dsYear.Tables[0];
                cbYear.SelectedIndex = dsYear.Tables[0].Rows.Count - 1;
                
                // Populate Main Subject combo box
                OleDbDataAdapter subAdapter = new OleDbDataAdapter("Select * from Subject where AcademicYear like '" + cbYear.SelectedValue.ToString() + "'", oleConn);
                DataSet dsSub = new DataSet();
                subAdapter.Fill(dsSub);

                cbSubject.DisplayMember = "Subject";
                cbSubject.ValueMember = "Subject";

                cbSubject.DataSource = dsSub.Tables[0];

                string strCls = "Select ([Class]+' '+[Section]) as Class from Class where AcademicYear like '" + cbYear.SelectedValue.ToString() + "'";
                OleDbDataAdapter classAdapter = new OleDbDataAdapter(strCls, oleConn);
                DataSet dsClass = new DataSet();
                classAdapter.Fill(dsClass);

                ((ListBox)clbClass).DataSource = dsClass.Tables[0];
                ((ListBox)clbClass).DisplayMember = "Class";
                ((ListBox)clbClass).ValueMember = "Class";
                ((ListBox)clbClass).Text = "Class";

                // Populate Teacher data grid

                string strTeacher = "Select * from Teacher where AcademicYear like '" + cbYear.SelectedValue.ToString()+"'";
                OleDbDataAdapter teachAdapter = new OleDbDataAdapter(strTeacher,oleConn);
                DataSet dsTeacher = new DataSet();
                teachAdapter.Fill(dsTeacher);
                
                dgTeacher.DataSource = dsTeacher.Tables[0];
                DataGridViewButtonColumn btnAct = new DataGridViewButtonColumn();
                btnAct.Text = "Edit";
                btnAct.HeaderText = "Action";
                btnAct.Name = "btnAction";
                btnAct.UseColumnTextForButtonValue = true;

                dgTeacher.Columns.Add(btnAct);
                
                oleConn.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIndex = cbSubject.SelectedIndex;


            string strQuery = "Select * from Subject where AcademicYear like '" + cbYear.SelectedValue.ToString() + "' and Subject <> '" + cbSubject.SelectedValue.ToString() + "'";

            try
            {
                OleDbConnection oleConn = new OleDbConnection(conText);
                OleDbDataAdapter subAdapter = new OleDbDataAdapter(strQuery, oleConn);
                DataSet dsSub = new DataSet();
                subAdapter.Fill(dsSub);

                ((ListBox)clbSubject).DataSource = dsSub.Tables[0];
                ((ListBox)clbSubject).DisplayMember = "Subject";
                ((ListBox)clbSubject).ValueMember = "Subject";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            
            // Get selected Optional Subject List
            string[] OptionalSub = new string[10];
            DataRow[] optSub = new DataRow[10];
            int subCount = clbSubject.CheckedItems.Count;

            //for (int i = 0; i < subCount; i++)
            //{
            //    OptionalSub[i] = ((DataRowView)clbSubject.CheckedItems[i]).Row[1].ToString();

            //}         

            //Get Selected class assigned list
            string strClass = String.Empty;
            int clsCount = clbClass.CheckedItems.Count;

            for (int j = 0; j < clsCount; j++)
            {
                if(j==clsCount-1)
                {
                    strClass += ((DataRowView)clbClass.CheckedItems[j]).Row[0].ToString();
                }
                else
                {
                    strClass += ((DataRowView)clbClass.CheckedItems[j]).Row[0].ToString() + ",";
                }
            }

            //Add teacher to Database
            int actStatus = 1;
            if (cbActive.CheckState == CheckState.Checked)
            {
                actStatus = 1;
            }
            else
            {
                actStatus = 0;
            }

            try
            {

                OleDbConnection oleConn = new OleDbConnection(conText);
                OleDbCommand oleCmd = new OleDbCommand();
                oleConn.Open();
                    oleCmd.Connection = oleConn;

                    for (int i = 0; i < subCount; i++)
                    {

                        OptionalSub[i] = ((DataRowView)clbSubject.CheckedItems[i]).Row[1].ToString();

                        string strAddTeacher = "Insert into Teacher (TeacherName, HoursAvailable, HoursOccupied, AcademicYear, MainSubject, OptionalSubjects, ClasstobeAlloted,MobileNumber,Active) values ('" + txtTeacher.Text.ToString() + "',30,0,'" + cbYear.SelectedValue.ToString() + "','" + cbSubject.Text.ToString() + "','" + OptionalSub[i] + "','" + strClass + "','" + txtMobile.Text.ToString() + "'," + actStatus + ")";

                        oleCmd.CommandText = strAddTeacher;
                        int sts = oleCmd.ExecuteNonQuery();

                        if (sts != 0)
                        {
                            MessageBox.Show("Teacher " + txtTeacher.Text.ToString() + " Saved!");
                        }
                    }
                                    
                    oleConn.Close();
                // Refresh the Teacher Gridview with added teacher
                
                string strTeacher = "Select * from Teacher where AcademicYear like '" + cbYear.SelectedValue.ToString()+"'";
                oleConn.Open();
                OleDbDataAdapter teachAdapter = new OleDbDataAdapter(strTeacher,oleConn);
                DataSet dsTeacher = new DataSet();
                teachAdapter.Fill(dsTeacher);

                dgTeacher.DataSource = dsTeacher.Tables[0];
                oleConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strTeacher = "Select * from Teacher where AcademicYear like '" + cbYear.SelectedValue.ToString() + "'";

            try
            {
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();
                OleDbDataAdapter teachAdapter = new OleDbDataAdapter(strTeacher, oleConn);
                DataSet dsTeacher = new DataSet();
                teachAdapter.Fill(dsTeacher);
                dgTeacher.Columns.Clear();
                               
                dgTeacher.DataSource = dsTeacher.Tables[0];
                DataGridViewButtonColumn btnAct = new DataGridViewButtonColumn();
                btnAct.Text = "Edit";
                btnAct.HeaderText = "Action";
                btnAct.Name = "btnAction";
                btnAct.UseColumnTextForButtonValue = true;

                dgTeacher.Columns.Add(btnAct);

                

                oleConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dgTeacher.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dgTeacher.Columns["btnAction"].Index)
            {
                //string strTeacher = dgTeacher
            }
        }

    }
}
