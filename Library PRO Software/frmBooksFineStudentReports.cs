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
    public partial class frmBooksFineStudentReports : Form
    {
        DataTable dtable = new DataTable();
        frmReport frm = new frmReport();
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        public frmBooksFineStudentReports()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
              
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT * FROM Return_Student INNER JOIN BookIssue_Student ON Return_Student.IssueID = BookIssue_Student.ID INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID Where ReturnDate Between @d1 and @d2 and Fine > 0 order by Return_Student.ReturnDate";
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "BookIssue_Student");
                myDA.Fill(myDS, "Return_Student");
                myDA.Fill(myDS, "Student");
                myDA.Fill(myDS, "School");
               
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
        }
    }
}
