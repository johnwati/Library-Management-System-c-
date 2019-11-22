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
    public partial class frmMemberBooksFineReport : Form
    {
     
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        frmReport frm = new frmReport();
        SqlDataAdapter adp;
        DataSet ds;
        Connectionstring cs = new Connectionstring();
        public frmMemberBooksFineReport()
        {
            InitializeComponent();
        }
       
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Return_Staff.ID, Return_Staff.ReturnDate, Return_Staff.Fine, Employee.EMPMAXID, Employee.EmployeeName, School.SchoolName, Department.DepartmentName, Designations.Designation, Book.AccessionNo,Book.BookTitle FROM Return_Staff INNER JOIN BookIssue_Staff ON Return_Staff.IssueID = BookIssue_Staff.ID INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo Where Return_Staff.ReturnDate Between @d1 and @d2 and Fine > 0 order by Return_Staff.ReturnDate", con);
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "ReturnDate").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "ReturnDate").Value = dtpDateTo.Value.Date;
                adp = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adp.Fill(table);
                ds = new DataSet();
                con.Close();
                ds.Tables.Add(table);
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
