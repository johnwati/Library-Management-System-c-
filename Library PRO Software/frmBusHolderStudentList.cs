using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmBusHolderStudentList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        frmBusFeesPaymentStudent frm = null;
        frmBusHolderStudents frm1 = null;
        Connectionstring cs = new Connectionstring();

        public frmBusHolderStudentList()
        {

            InitializeComponent();
        }
    
        public frmBusHolderStudentList(frmBusFeesPaymentStudent par)
        {
            frm = par;
            InitializeComponent();
        }
        public frmBusHolderStudentList(frmBusHolderStudents par1)
        {
            frm1 = par1;
            InitializeComponent();
        }
       
        public void Auto1()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StudentBusHolder.BusholderID),Rtrim(StudentBusHolder.Admission_No),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Sessions.SessionID),Rtrim(Sessions.Session),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(StudentBusHolder.Bus_ID),Rtrim(Bus.BusNo),Rtrim(StudentBusHolder.Location_ID),Rtrim(Locations.Location),StudentBusHolder.JoiningDate,Rtrim(StudentBusHolder.Status) FROM StudentBusHolder INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo INNER JOIN Bus ON StudentBusHolder.Bus_ID = Bus.BusID INNER JOIN Locations ON StudentBusHolder.Location_ID = Locations.LocationID INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID and StudentBusHolder.Status='Active'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBusHolderStudentList_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
           
                try
                {
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    cmd = new SqlCommand("SELECT Rtrim(StudentBusHolder.BusholderID),Rtrim(StudentBusHolder.Admission_No),Rtrim(Student.StudentName),Rtrim(School.SchoolName),Rtrim(Sessions.SessionID),Rtrim(Sessions.Session),Rtrim(Class.ClassName),Rtrim(Section.SectionName),Rtrim(StudentBusHolder.Bus_ID),Rtrim(Bus.BusNo),Rtrim(StudentBusHolder.Location_ID),Rtrim(Locations.Location),StudentBusHolder.JoiningDate,Rtrim(StudentBusHolder.Status) FROM StudentBusHolder INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo INNER JOIN Bus ON StudentBusHolder.Bus_ID = Bus.BusID INNER JOIN Locations ON StudentBusHolder.Location_ID = Locations.LocationID INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID and locations.Location like '%" + txtLocation.Text + "%'", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    DataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13]);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM StudentBusHolder INNER JOIN Student ON StudentBusHolder.Admission_No = Student.AdmissionNo INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID and Class.className = '" + txtClass.Text + "'";
                cmd = new SqlCommand(ct);
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
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ButtonHighlight;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
        public void reset()
        {
            txtStudentName.Text = "";
            txtLocation.Text = "";
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            txtAdmissionNo.Text = "";
            DataGridView1.Rows.Clear();
            Sessions();
            if (lblSET.Text == "R")
            {
                Auto1();
            }
            else
            {
                Auto();
            }
}
        private void button4_Click(object sender, EventArgs e)
        {
            reset();
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }
    }
}