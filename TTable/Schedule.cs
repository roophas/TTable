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
    

    public partial class Schedule : Form
    {
        string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;

        public Schedule()
        {
            this.InitializeComponent();
            
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            try
            {
                // Load Year combo box
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();

                OleDbDataAdapter yrAdapter = new OleDbDataAdapter("Select * from AcYear", oleConn);
                DataSet dsYear = new DataSet();
                yrAdapter.Fill(dsYear);

                cbYear.DisplayMember = "AcademicYear";
                cbYear.ValueMember = "AcademicYear";

                cbYear.DataSource = dsYear.Tables[0];
                cbYear.SelectedIndex = dsYear.Tables[0].Rows.Count - 1;
                
                //Populate Class combo box
                string clsQuery = "Select ([Class]+' '+[Section]) as Class from Class where AcademicYear like '" + cbYear.SelectedValue.ToString() + "'";
                OleDbDataAdapter clsAdapter = new OleDbDataAdapter(clsQuery, oleConn);
                DataSet dsClass = new DataSet();
                
                clsAdapter.Fill(dsClass);

                cbClass.DisplayMember = "Class";
                cbClass.ValueMember = "Class";

                cbClass.DataSource = dsClass.Tables[0];

                //Populate Subjects listbox

                string subjQuery = "Select Subject from Subject where AcademicYear like '" + cbYear.SelectedValue.ToString() + "'";
                OleDbDataAdapter subAdapter = new OleDbDataAdapter(subjQuery, oleConn);
                DataSet dsSubj = new DataSet();

                subAdapter.Fill(dsSubj);

                List<Sub> Subject = new List<Sub>();
                int subCount = dsSubj.Tables[0].Rows.Count;

                for (int s = 0; s < subCount; s++)
                {
                    Subject.Add(new Sub() {subject = dsSubj.Tables[0].Rows[s][0].ToString()
                    });
                }


                foreach (Sub sub in Subject)
                {
                    lbSubjects.Items.Add(sub.subject.ToString());
                }

                oleConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

              
        private void lbSubjects_MouseDown(object sender, MouseEventArgs e)
        {

            if (lbSubjects.Items.Count == 0)
                return;
            string s = lbSubjects.Items[lbSubjects.IndexFromPoint(e.X, e.Y)].ToString();
            //string s = lbSubjects.SelectedValue.ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            try
            {
                //Populate teachers for the corresponding subject and class

                string selSubj = s;

                string teachQuery = "Select TeacherName,MainSubject, OptionalSubjects, HoursAvailable, HoursOccupied,ClasstobeAlloted,Active from Teacher where AcademicYear like '" + cbYear.SelectedValue.ToString() + "' and ClasstobeAlloted like '%" + cbClass.SelectedValue.ToString() + "%'";
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();

                OleDbDataAdapter teacAdapter = new OleDbDataAdapter(teachQuery, oleConn);
                DataTable dtTeacher = new DataTable();
                teacAdapter.Fill(dtTeacher);

                int rowCount = dtTeacher.Rows.Count;
                lbTeachers.Items.Clear();

                List<Teachers> t = new List<Teachers>();
                foreach (DataRow row in dtTeacher.Rows)
                {
                    t.Add(new Teachers() { teacher = row[0].ToString(), subject = row[1].ToString(), addsubj = row[2].ToString(), hoursavailable = Convert.ToInt32(row[3].ToString()), hoursoccupied = Convert.ToInt32(row[4].ToString()), allotclass = row[5].ToString(), active = Convert.ToBoolean(row[6].ToString()) });
                }

                foreach (Teachers te in t)
                {
                    if (te.subject.Contains(s) || (te.addsubj.Contains(s)))
                    {
                        lbTeachers.Items.Add(te.teacher.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (Mon1.Items.Count > 1)
            {
                MessageBox.Show("Please add one Subject and a Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon1.Items.Add(str);
                }
            }
        }

        private void listBox1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lbTeachers_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbTeachers.Items.Count == 0)
                return;
            string s = lbTeachers.Items[lbTeachers.IndexFromPoint(e.X, e.Y)].ToString();
            DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);
        }

        private void Mon2_DragDrop(object sender, DragEventArgs e)
        {
            if (Mon2.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon2.Items.Add(str);
                }
            }
        }

        private void Mon2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Mon3_DragDrop(object sender, DragEventArgs e)
        {
            if (Mon3.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon3.Items.Add(str);
                }
            }
        }

        private void Mon3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Mon4_DragDrop(object sender, DragEventArgs e)
        {
            if (Mon4.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon4.Items.Add(str);
                }
            }
        }

        private void Mon4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Mon5_DragDrop(object sender, DragEventArgs e)
        {
            if (Mon5.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon5.Items.Add(str);
                }
            }
        }

        private void Mon5_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Mon6_DragDrop(object sender, DragEventArgs e)
        {
            if (Mon6.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon6.Items.Add(str);
                }
            }
        }

        private void Mon6_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Mon7_DragDrop(object sender, DragEventArgs e)
        {
            if (Mon7.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon7.Items.Add(str);
                }
            }
        }

        private void Mon7_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Mon8_DragDrop(object sender, DragEventArgs e)
        {
            if (Mon8.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Mon8.Items.Add(str);
                }
            }
        }

        private void Mon8_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues1_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues1.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues1.Items.Add(str);
                }
            }
        }

        private void Tues1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues2_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues2.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues2.Items.Add(str);
                }
            }
        }

        private void Tues2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues3_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues3.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues3.Items.Add(str);
                }
            }
        }

        private void Tues3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues4_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues4.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues4.Items.Add(str);
                }
            }
        }

        private void Tues4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues5_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues5.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues5.Items.Add(str);
                }
            }
        }

        private void Tues6_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues6.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues6.Items.Add(str);
                }
            }
        }

        private void Tues7_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues7.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues7.Items.Add(str);
                }
            }
        }

        private void Tues8_DragDrop(object sender, DragEventArgs e)
        {
            if (Tues8.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Tues8.Items.Add(str);
                }
            }
        }

        private void Tues8_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues7_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues6_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Tues5_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed5_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed6_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed7_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed8_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs5_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs6_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs7_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Thurs8_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri3_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri4_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri5_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri6_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri7_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Fri8_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Wed1_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed1.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed1.Items.Add(str);
                }
            }
        }

        private void Wed2_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed2.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed2.Items.Add(str);
                }
            }
        }

        private void Wed3_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed3.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed3.Items.Add(str);
                }
            }
        }

        private void Wed4_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed4.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed4.Items.Add(str);
                }
            }
        }

        private void Wed5_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed5.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed5.Items.Add(str);
                }
            }
        }

        private void Wed6_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed6.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed6.Items.Add(str);
                }
            }
        }

        private void Wed7_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed7.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed7.Items.Add(str);
                }
            }
        }

        private void Wed8_DragDrop(object sender, DragEventArgs e)
        {
            if (Wed8.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Wed8.Items.Add(str);
                }
            }
        }

        private void Thurs1_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs1.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs1.Items.Add(str);
                }
            }
        }

        private void Thurs2_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs2.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs2.Items.Add(str);
                }
            }
        }

        private void Thurs3_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs3.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs3.Items.Add(str);
                }
            }
        }

        private void Thurs4_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs4.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs4.Items.Add(str);
                }
            }
        }

        private void Thurs5_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs5.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs5.Items.Add(str);
                }
            }
        }

        private void Thurs6_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs6.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs6.Items.Add(str);
                }
            }
        }

        private void Thurs7_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs7.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs7.Items.Add(str);
                }
            }
        }

        private void Thurs8_DragDrop(object sender, DragEventArgs e)
        {
            if (Thurs8.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Thurs8.Items.Add(str);
                }
            }
        }

        private void Fri1_DragDrop(object sender, DragEventArgs e)
        {
            if (Fri1.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Fri1.Items.Add(str);
                }
            }
        }

        private void Fri2_DragDrop(object sender, DragEventArgs e)
        {
            if (Fri2.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Fri2.Items.Add(str);
                }
            }
        }

        private void Fri3_DragDrop(object sender, DragEventArgs e)
        {
            if (Fri3.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Fri3.Items.Add(str);
                }
            }
        }

        private void Fri4_DragDrop(object sender, DragEventArgs e)
        {
            if (Fri4.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Fri4.Items.Add(str);
                }
            }
        }

        private void Fri5_DragDrop(object sender, DragEventArgs e)
        {
            if (Fri5.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Fri5.Items.Add(str);
                }
            }
        }

        private void Fri6_DragDrop(object sender, DragEventArgs e)
        {
            if (Fri6.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Fri6.Items.Add(str);
                }
            }
        }

        private void Fri7_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (String)e.Data.GetData(DataFormats.StringFormat);

                Fri7.Items.Add(str);
            }
        }

        private void Fri8_DragDrop(object sender, DragEventArgs e)
        {
            if (Fri8.Items.Count > 1)
            {
                MessageBox.Show("Please add 1 Subject and 1 Teacher");
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string str = (String)e.Data.GetData(DataFormats.StringFormat);

                    Fri8.Items.Add(str);
                }
            }
        }

        private void btnSaveTT_Click(object sender, EventArgs e)
        {
            try
            {
                List<TT> timeTable = new List<TT>();
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 1,
                    Subject = Mon1.Items[0].ToString(),
                    Teacher = Mon1.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });

                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 2,
                    Subject = Mon2.Items[0].ToString(),
                    Teacher = Mon2.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 3,
                    Subject = Mon3.Items[0].ToString(),
                    Teacher = Mon3.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 4,
                    Subject = Mon4.Items[0].ToString(),
                    Teacher = Mon4.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 5,
                    Subject = Mon5.Items[0].ToString(),
                    Teacher = Mon5.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 6,
                    Subject = Mon6.Items[0].ToString(),
                    Teacher = Mon6.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 7,
                    Subject = Mon7.Items[0].ToString(),
                    Teacher = Mon7.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 1,
                    Period = 8,
                    Subject = Mon8.Items[0].ToString(),
                    Teacher = Mon8.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 1,
                    Subject = Tues1.Items[0].ToString(),
                    Teacher = Tues1.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 2,
                    Subject = Tues2.Items[0].ToString(),
                    Teacher = Tues2.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 3,
                    Subject = Tues3.Items[0].ToString(),
                    Teacher = Tues3.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 4,
                    Subject = Tues4.Items[0].ToString(),
                    Teacher = Tues4.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 5,
                    Subject = Tues5.Items[0].ToString(),
                    Teacher = Tues5.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 6,
                    Subject = Tues6.Items[0].ToString(),
                    Teacher = Tues6.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 7,
                    Subject = Tues7.Items[0].ToString(),
                    Teacher = Tues7.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 2,
                    Period = 8,
                    Subject = Tues8.Items[0].ToString(),
                    Teacher = Tues8.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 1,
                    Subject = Wed1.Items[0].ToString(),
                    Teacher = Wed1.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 2,
                    Subject = Wed2.Items[0].ToString(),
                    Teacher = Wed2.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 3,
                    Subject = Wed3.Items[0].ToString(),
                    Teacher = Wed3.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 4,
                    Subject = Wed4.Items[0].ToString(),
                    Teacher = Wed4.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 5,
                    Subject = Wed5.Items[0].ToString(),
                    Teacher = Wed5.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 6,
                    Subject = Wed6.Items[0].ToString(),
                    Teacher = Wed6.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 7,
                    Subject = Wed7.Items[0].ToString(),
                    Teacher = Wed7.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 3,
                    Period = 8,
                    Subject = Wed8.Items[0].ToString(),
                    Teacher = Wed8.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 1,
                    Subject = Thurs1.Items[0].ToString(),
                    Teacher = Thurs1.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 2,
                    Subject = Thurs2.Items[0].ToString(),
                    Teacher = Thurs2.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 3,
                    Subject = Thurs3.Items[0].ToString(),
                    Teacher = Thurs3.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });

                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 4,
                    Subject = Thurs4.Items[0].ToString(),
                    Teacher = Thurs4.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 5,
                    Subject = Thurs5.Items[0].ToString(),
                    Teacher = Thurs5.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 6,
                    Subject = Thurs6.Items[0].ToString(),
                    Teacher = Thurs6.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 7,
                    Subject = Thurs7.Items[0].ToString(),
                    Teacher = Thurs7.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 4,
                    Period = 8,
                    Subject = Thurs8.Items[0].ToString(),
                    Teacher = Thurs8.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 1,
                    Subject = Fri1.Items[0].ToString(),
                    Teacher = Fri1.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });

                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 2,
                    Subject = Fri2.Items[0].ToString(),
                    Teacher = Fri2.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 3,
                    Subject = Fri3.Items[0].ToString(),
                    Teacher = Fri3.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 4,
                    Subject = Fri4.Items[0].ToString(),
                    Teacher = Fri4.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 5,
                    Subject = Fri5.Items[0].ToString(),
                    Teacher = Fri5.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 6,
                    Subject = Fri6.Items[0].ToString(),
                    Teacher = Fri6.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 7,
                    Subject = Fri7.Items[0].ToString(),
                    Teacher = Fri7.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });
                timeTable.Add(new TT()
                {
                    ACYear = cbYear.SelectedValue.ToString(),
                    Class = cbClass.SelectedValue.ToString(),
                    Day = 5,
                    Period = 8,
                    Subject = Fri8.Items[0].ToString(),
                    Teacher = Fri8.Items[1].ToString(),
                    UpdateDate = DateTime.Now.Date.ToShortDateString()
                });

                int rowCount = timeTable.Count;
                OleDbConnection oleConn = new OleDbConnection(conText);
                oleConn.Open();
                for (int c = 0; c < rowCount; c++)
                {
                    string strQuery = "Insert into Timetable (AcademicYear,Class, [Day], Period, [Subject], [Teacher], updDate) values ('" + timeTable[c].ACYear + "','" + timeTable[c].Class + "'," + timeTable[c].Day + "," + timeTable[c].Period + "," + "'" + timeTable[c].Subject + "','" + timeTable[c].Teacher + "','" + DateTime.Now.Date.ToShortDateString() + "')";
                    OleDbCommand oleCmd = new OleDbCommand();
                    oleCmd.Connection = oleConn;
                    oleCmd.CommandText = strQuery;

                    int i = oleCmd.ExecuteNonQuery();

                }


                oleConn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
            
        }

    public class TT
    {
        public string ACYear { get; set; }
        public string Class { get; set; }
        public int Day { get; set; }
        public int Period { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string UpdateDate { get; set; }
    }

    public class Sub
    {
        public string subject { get; set; }
    }

    public class Teachers
    {
        public string teacher { get; set; }
        public string subject { get; set; }
        public string addsubj { get; set; }
        public string allotclass { get; set; }
        public int hoursavailable { get; set; }
        public int hoursoccupied { get; set; }
        public bool active { get; set; }
    }

    }

