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
    public partial class Subjects : Form
    {

        public Subjects()
        {
            InitializeComponent();
        }

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            if (txtSubject.TextLength.ToString() == "" || txtHours.TextLength.ToString() == "")
            {
                MessageBox.Show("Subject or Hours cannot be Empty. Please enter a correct value!");
            }
            else
            {
                string subject = txtSubject.Text.ToString();
                string hrsperweek = txtHours.Text.ToString();

                try
                {
                    string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;
                    OleDbConnection oleConn = new OleDbConnection(conText);
                    oleConn.Open();

                    OleDbCommand oleCmd = new OleDbCommand();
                    oleCmd.Connection = oleConn;
                    oleCmd.CommandText = "Insert into Subject (Subject, PeriodperWeek, AcademicYear) values ('" + subject + "','" + hrsperweek+"','"+ cbYear.SelectedValue.ToString()+"')";
                    
                    int i = oleCmd.ExecuteNonQuery();

                    if (i != 0)
                    {
                        MessageBox.Show("Subject " + txtSubject.Text.ToString() + " Saved!");
                    }

                    OleDbDataAdapter oleAdapter = new OleDbDataAdapter("Select * from Subject where AcademicYear like '"+cbYear.SelectedValue.ToString()+"'", oleConn);
                    DataTable dt = new DataTable();

                    oleAdapter.Fill(dt);
                    lvSubjects.Items.Clear();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataRow dr = dt.Rows[j];
                        ListViewItem lvSub = new ListViewItem(dr["Subject"].ToString());
                        lvSub.SubItems.Add(dr["PeriodperWeek"].ToString());

                        lvSubjects.Items.Add(lvSub);
                    }

                    oleConn.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            
            try{
            string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;
            OleDbConnection oleConn = new OleDbConnection(conText);

            OleDbDataAdapter yrAdapter = new OleDbDataAdapter("Select * from AcYear", oleConn);
            DataSet dsYear = new DataSet();
            yrAdapter.Fill(dsYear);

            cbYear.DisplayMember = "AcademicYear";
            cbYear.ValueMember = "AcademicYear";
            
            cbYear.DataSource = dsYear.Tables[0];
            cbYear.SelectedIndex = dsYear.Tables[0].Rows.Count - 1;

            OleDbDataAdapter oleAdapter = new OleDbDataAdapter("Select * from Subject where AcademicYear like '" + cbYear.SelectedValue.ToString() + "'", oleConn);
            DataTable dt = new DataTable();

            oleAdapter.Fill(dt);
            lvSubjects.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem lvSub = new ListViewItem(dr["Subject"].ToString());
                lvSub.SubItems.Add(dr["PeriodperWeek"].ToString());

                lvSubjects.Items.Add(lvSub);


            }

            lvSubjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to connect to the Database...."+ex.Message);
            }
        
                
                    
        }

        

        //private void cbYear_MouseClick(object sender, MouseEventArgs e)
        //{
        //    int selIndex = cbYear.SelectedIndex;
        //    string AcYear = cbYear.Items[selIndex].ToString();

        //    try
        //    {

        //        string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;
        //        OleDbConnection oleConn = new OleDbConnection(conText);

        //        OleDbDataAdapter oleAdapter = new OleDbDataAdapter("Select * from Subject where AcademicYear like '" + AcYear + "'", oleConn);
        //        DataTable dt = new DataTable();

        //        oleAdapter.Fill(dt);
        //        lvSubjects.Items.Clear();
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            DataRow dr = dt.Rows[i];
        //            ListViewItem lvSub = new ListViewItem(dr["Subject"].ToString());
        //            lvSub.SubItems.Add(dr["PeriodperWeek"].ToString());

        //            lvSubjects.Items.Add(lvSub);


        //        }

        //        lvSubjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIndex = cbYear.SelectedIndex;
            string AcYear = cbYear.Items[selIndex].ToString();

            try
            {
                string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();

                OleDbDataAdapter oleAdapter = new OleDbDataAdapter("Select * from Subject where AcademicYear like '" + cbYear.SelectedValue.ToString() + "'", oleConn);
                DataTable dt = new DataTable();

                oleAdapter.Fill(dt);
                lvSubjects.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem lvSub = new ListViewItem(dr["Subject"].ToString());
                    lvSub.SubItems.Add(dr["PeriodperWeek"].ToString());

                    lvSubjects.Items.Add(lvSub);


                }

                oleConn.Close();
                lvSubjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
    }
}
