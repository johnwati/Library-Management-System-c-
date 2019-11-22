using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School_Software
{
    public partial class frmLogin : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void fillusernType()
        {
            try
            {
               con = new SqlConnection(cs.DBcon);
               con.Open();
               string ct = "SELECT Rtrim(Designations.Designation) FROM Users INNER JOIN Designations ON Users.Designation_ID = Designations.DesignationID";
              cmd = new SqlCommand(ct);
              cmd.Connection = con;
              rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbUsertype.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (UserID.Text == "")
            {
                MessageBox.Show("Please enter user ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserID.Focus();
                return;
            }
            if (Password.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Focus();
                return;
            }
           
           }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           lblDate.Text = DateTime.Now.ToString();
            timer1.Start();
        }
    }
}
