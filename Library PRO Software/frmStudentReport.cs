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
    public partial class frmStudentReport : Form
    {
        DataTable dtable = new DataTable();
        DataTable dt = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        frmReport frm = new frmReport();
        SqlDataAdapter adp;
        DataSet ds;
        SqlDataReader rdr = null;
        Connectionstring cs = new Connectionstring();
       public frmStudentReport()
        {
            InitializeComponent();
        }

        public void School()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(School.SchoolName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSchool.Items.Clear();
                while (rdr.Read())
                {
                    txtSchool.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Sessions()
        {
            try
            {
                txtSession.Items.Clear();
                txtSession.Text = "";
                txtSession.Enabled = true;
                txtSession.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Sessions.Session) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where School.schoolname='" + txtSchool.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSession.Items.Clear();
                while (rdr.Read())
                {
                    txtSession.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStudentReport_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSection.Items.Clear();
            txtSection.Text = "";
            txtSection.Enabled = true;
            txtSection.Focus();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID  and SchoolName=@d1 and Session=@d2 and class.className =@d3";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSection.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtClass.Items.Clear();
                txtClass.Text = "";
                txtClass.Enabled = true;
                txtClass.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where Sessions.session= @d2 and schoolname= @d1";
                cmd = new SqlCommand(ct1);
                cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            txtSchool.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            School();

        }
        private void txtSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
           Sessions();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSchool.Text == "")
                {
                    MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSchool.Focus();
                    return;
                }
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please Enter Session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSession.Focus();
                    return;
                }
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClass.Focus();
                    return;
                }
                if (txtSection.Text == "")
                {
                    MessageBox.Show("Please Enter Section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSection.Focus();
                    return;
                }
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Timer1.Enabled = true;
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    cmd = new SqlCommand("SELECT Student.AdmissionNo,Student.Status, Student.EnrollmentNo, Student.StudentName, Student.FatherName, Student.MotherName, Student.ParentContact, Student.PermanentAddress, Student.ContactNo, Student.DOB,Student.Gender, Student.AdmissionDate, Student.Religion, Student.Nationality, Sessions.Session, School.SchoolName, School.Photo, Class.ClassName, Section.SectionName FROM Student INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where SchoolName=@d1 and Session=@d2 and ClassName=@d3  and SectionName=@d4 order by StudentName", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                    cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                    cmd.Parameters.AddWithValue("@d4", txtSection.Text);
                    adp = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adp.Fill(table);
                    ds = new DataSet();
                    con.Close();
                    ds.Tables.Add(table);
                    ds.WriteXmlSchema("Student.xml");
                   RptStudents rpt = new RptStudents();
                    rpt.SetDataSource(ds);
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
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
        public void Reset1()
        {
            txtSchool.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            School();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset1();
        }
    }
}
