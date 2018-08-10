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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";

            string conText = ConfigurationManager.ConnectionStrings["oleConStr"].ConnectionString;
            OleDbConnection oleConn = new OleDbConnection(conText);
            OleDbDataAdapter oleAdapter = new OleDbDataAdapter("Select count(*) from Login where Username = '" + txtUserName.Text.ToString()+"'and Password = '"+txtPassword.Text.ToString()+"'",oleConn);
            DataTable dt = new DataTable();

            oleAdapter.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid UserName or Password");
            }
           
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
