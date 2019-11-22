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
    public partial class frmMainmenu : Form
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

        public frmMainmenu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           TIME.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       private void schoolEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           frmSchoolEntry frm = new frmSchoolEntry(this);
            frm.ShowDialog();
        }

        private void subjectEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void frmMainmenu_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();

            //Master Entry
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Master Entry View' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblMasterentry.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblMasterentry.Text == "True")
            {
                masterEntryToolStripMenuItem.Enabled = true;
            }
            else
            {
                masterEntryToolStripMenuItem.Enabled = false;
            }

            if (UserType.Text == "Super Admin")
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Users View' and Users.UserID='" + User.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    frm.lblusers.Text = rdr[0].ToString().Trim();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (frm.lblusers.Text == "True")
                {
                    usersSettingToolStripMenuItem.Enabled = true;
                    userRegistrationToolStripMenuItem.Enabled = true;
                }
                else
                {
                    usersSettingToolStripMenuItem.Enabled = true;
                    userRegistrationToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Users View' and Users.UserID='" + User.Text + "' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    frm.lblusers.Text = rdr[0].ToString().Trim();

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (frm.lblusers.Text == "True")
                {
                    usersSettingToolStripMenuItem.Enabled = true;
                    userRegistrationToolStripMenuItem.Enabled = true;
                }
                else
                {
                    usersSettingToolStripMenuItem.Enabled = false;
                    userRegistrationToolStripMenuItem.Enabled = false;
                }
            }
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student View' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStudentAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStudentAll.Text == "True")
            {
                studentToolStripMenuItem.Enabled = true;
                studentToolStripMenuItem1.Enabled = true;
            }
            else
            {
                studentToolStripMenuItem.Enabled = false;
                studentToolStripMenuItem1.Enabled = false;
            }

            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStudentRegistration.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStudentRegistration.Text == "True")
            {
                studentRegistrationToolStripMenuItem.Enabled = true;
                studentToolStripMenuItem1.Enabled = true;
            }
            else
            {
                studentRegistrationToolStripMenuItem.Enabled = false;
                studentToolStripMenuItem1.Enabled = false;
            }

          
         

            //Books Fine

            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Books Fine Setting' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblFine.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblFine.Text == "True")
            {
                booksFineSettingsToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksFineSettingsToolStripMenuItem.Enabled = false;
            }

            //Books Reservation

            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Reservation' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookReservation.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookReservation.Text == "True")
            {
                staffBookReservationToolStripMenuItem.Enabled = true;
            }
            else
            {
                staffBookReservationToolStripMenuItem.Enabled = false;
            }

            //Books Issue
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssue.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssue.Text == "True")
            {
                studentBookIssueToolStripMenuItem.Enabled = true;
            }
            else
            {
                studentBookIssueToolStripMenuItem.Enabled = false;
            }
            //Books Return
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Return' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookReturn.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookReturn.Text == "True")
            {
                studentBookReturnToolStripMenuItem.Enabled = true;
            }
            else
            {
                studentBookReturnToolStripMenuItem.Enabled = false;
            }

            //JM
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblJM.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblJM.Text == "True")
            {
                journalAndMagazinesBillingToolStripMenuItem.Enabled = true;
                bill.Enabled = true;
            }
            else
            {
                journalAndMagazinesBillingToolStripMenuItem.Enabled = false;
                bill.Enabled = false;
            }

        
            //Employee All
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee All' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblEmployeeAll.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblEmployeeAll.Text == "True")
            {
                employeeToolStripMenuItem.Enabled = true;
                employeeToolStripMenuItem1.Enabled = true;
            }
            else
            {
                employeeToolStripMenuItem.Enabled = false;
                employeeToolStripMenuItem1.Enabled = false;
            }
            //Employee Entry
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblEmployeeEntry.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblEmployeeEntry.Text == "True")
            {
                employeeRegistrationToolStripMenuItem.Enabled = true;
                employeeToolStripMenuItem1.Enabled = true;
            }
            else
            {
                employeeRegistrationToolStripMenuItem.Enabled = false;
                employeeToolStripMenuItem1.Enabled = false;
            }
          
            //Barcode
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Barcode Genrator All' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBarcode.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBarcode.Text == "True")
            {
                barcodeGenratorToolStripMenuItem.Enabled = true;
                barcodeGeneratorsToolStripMenuItem.Enabled = true;
            }
            else
            {
                barcodeGenratorToolStripMenuItem.Enabled = false;
                barcodeGeneratorsToolStripMenuItem.Enabled = false;
            }
            //RecordsAll
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='All Records' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAllRecords.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAllRecords.Text == "True")
            {
                recordsToolStripMenuItem.Enabled = true;
            }
            else
            {
                recordsToolStripMenuItem.Enabled = false;
            }
            //RecordsAll
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='All Records' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAllRecords.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAllRecords.Text == "True")
            {
                recordsToolStripMenuItem.Enabled = true;
            }
            else
            {
                recordsToolStripMenuItem.Enabled = false;
            }
            //Student list
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Student List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblStudentRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblStudentRecord.Text == "True")
            {
                studentListToolStripMenuItem.Enabled = true;
            }
            else
            {
                studentListToolStripMenuItem.Enabled = false;
            }
            //Employee
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Employee List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblEmployeeRecord.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblEmployeeRecord.Text == "True")
            {
                employeeListToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeeListToolStripMenuItem.Enabled = false;
            }
         
            //Book Spplier List
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Book Supplier List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSupplierList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSalaryList.Text == "True")
            {
               bookSupplierListToolStripMenuItem.Enabled = true;
            }
            else
            {
               bookSupplierListToolStripMenuItem.Enabled = false;
            }

            //Book list
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSalaryList.Text == "True")
            {
                booksList.Enabled = true;
            }
            else
            {
                booksList.Enabled = false;
            }
            //Book Reservation list
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Reservation List' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookReservation.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookReservation.Text == "True")
            {
                booksReservationListToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksReservationListToolStripMenuItem.Enabled = false;
            }
            //Book Issue list
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Issue List Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksIssueListStudentToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksIssueListStudentToolStripMenuItem.Enabled = false;
            }

            //Book Issue list Staff
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Issue List Staff' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksIssueListStaffToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksIssueListStaffToolStripMenuItem.Enabled = false;
            }

            //Book Return list
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Return List Student' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksReturnListStudentToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksReturnListStudentToolStripMenuItem.Enabled = false;
            }
            //Book Return list Staff
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Books Return List Staff' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBookIssueList.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBookIssueList.Text == "True")
            {
                booksReturnListStaffToolStripMenuItem.Enabled = true;
            }
            else
            {
                booksReturnListStaffToolStripMenuItem.Enabled = false;
            }

        

           

            //All Reports
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View All Reports' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblAllReports.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblAllReports.Text == "True")
            {
                reportsToolStripMenuItem.Enabled = true;
            }
            else
            {
                reportsToolStripMenuItem.Enabled = false;
            }
            //Logs
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Logs' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblLogs.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblLogs.Text == "True")
            {
                logsToolStripMenuItem.Enabled = true;
            }
            else
            {
                logsToolStripMenuItem.Enabled = false;
            }
            //SMS
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View SMS Setting' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSMs.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblSMs.Text == "True")
            {
                sMSSettingToolStripMenuItem.Enabled = true;
                sMSToolStripMenuItem.Enabled = true;
            }
            else
            {
                sMSSettingToolStripMenuItem.Enabled = false;
                sMSToolStripMenuItem.Enabled = true;
            }

            //Database Backup
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(viewRecord)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='View Backup & Recovery' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblBackup.Text = rdr[0].ToString().Trim();

            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (frm.lblBackup.Text == "True")
            {
                dataBaseBackupToolStripMenuItem.Enabled = true;
                Recovery.Enabled = true;
                recoveryToolStripMenuItem.Enabled = true;
                backupToolStripMenuItem.Enabled = true;
            }
            else
            {
                dataBaseBackupToolStripMenuItem.Enabled = false;
                backupToolStripMenuItem.Enabled = false;
                recoveryToolStripMenuItem.Enabled = false;
                Recovery.Enabled = false;
            }
            }
        

        private void schoolTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchoolType frm = new frmSchoolType(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassTypes frm = new frmClassTypes();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassEntry frm = new frmClassEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void sectionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSectionEntry frm = new frmSectionEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmClassSection frm = new frmClassSection();
            frm.ShowDialog();
        }

        private void sessionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSessionEntry frm = new frmSessionEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMembersDepartment frm = new frmMembersDepartment();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeDesignationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmMembersDesignations frm = new frmMembersDesignations();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

      

        private void booksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksEntry frm = new frmBooksEntry(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void bookSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBookSuppliersEntry frm = new frmBookSuppliersEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void journalAndMagazinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournalAndMagazines frm = new frmJournalAndMagazines(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

      

        private void userRegistrationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void userGrantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserGrants frm = new frmUserGrants();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void studentRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmRegistration frm = new frmRegistration();
           frm.lblUser.Text = User.Text;
           con = new SqlConnection(cs.DBcon);
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + User.Text + "' ";
           rdr = cmd.ExecuteReader();
           if (rdr.Read())
           {
               frm.lblsave.Text = rdr[0].ToString().Trim();
               frm.lblview.Text = rdr[1].ToString().Trim();
           }
           if ((rdr != null))
           {
               rdr.Close();
           }
           if (con.State == ConnectionState.Open)
           {
               con.Close();
           }

           if (frm.lblsave.Text == "True")
               frm.btnSave.Enabled = true;
           else
               frm.btnSave.Enabled = false;

           if (frm.lblview.Text == "True")
               frm.btnGetData.Enabled = true;
           else
               frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

       
        private void examScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMembersEntry frm = new frmMembersEntry();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

       

        private void booksClassificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBooksClassifications frm = new frmBooksClassifications();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksSubcategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksSubCategory frm = new frmBooksSubCategory();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksCategory frm = new frmBooksCategory();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

      

       

        private void booksRandomBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRandomBarcodeGenerator frm = new frmRandomBarcodeGenerator();
            frm.ShowDialog();
        }

        private void booksBarcodeGenratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodeGeneration frm = new frmBarcodeGeneration();
           frm.ShowDialog();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogs frm = new frmLogs();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void sMSSettingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSms frm = new frmSms();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksFineSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

      

        private void studentBookReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void staffBookReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void studentBookIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void journalAndMagazinesBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList();
            frm.ShowDialog();
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmMemberList frm = new frmMemberList();
            frm.ShowDialog();
        }

       

      

        private void bookSupplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBookSupplierList frm = new frmBookSupplierList();
            frm.ShowDialog();
        }

        private void booksClassifiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksList frm = new frmBooksList();
            frm.ShowDialog();
        }

        private void booksReservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksReservationsList frm = new frmBooksReservationsList();
            frm.ShowDialog();
        }

        private void booksIssueListStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueListStudent frm = new frmBookIssueListStudent();
            frm.ShowDialog();
        }

        private void booksIssueListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMembersBookIssueList frm = new frmMembersBookIssueList();
            frm.ShowDialog();
        }

        private void booksReturnListStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReturnListStudent frm = new frmBookReturnListStudent();
            frm.ShowDialog();
        }

        private void booksReturnListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksReturnListStaff frm = new frmBooksReturnListStaff();
            frm.ShowDialog();
        }

        
        public void Logout()
        {
            st1 = User.Text;
            st2 = "Successfully logged out";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
            frm.UserID.Text = "";
            frm.Password.Text = "";
            frm.progressBar1.Visible = false;
            frm.UserID.Focus();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
           try
            {
                if (MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Backup();
                        Logout();
                    }
                    else
                    {
                        Logout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Backup()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer2.Enabled = true;
                if ((!System.IO.Directory.Exists("C:\\DBBackup")))
                {
                    System.IO.Directory.CreateDirectory("C:\\DBBackup");
                }
                string destdir = "C:\\DBBackup\\ERPS_DB " + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".bak";
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "backup database [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_DB.mdf] to disk='" + destdir + "'with init,stats=10";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = User.Text;
                st2 = "Successfully backup the database";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully performed", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
        }
        private void dataBaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }

      

        private void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer2.Enabled = false;
        }

      

        private void studentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentReport frm = new frmStudentReport();
            frm.ShowDialog();
        }

   
        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeReport frm = new frmEmployeeReport();
            frm.ShowDialog();
        }

        private void bookReservationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bookIssueReportStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void bookIssueReportsStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bookReturnReportStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void booksFineCollectionReportStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksFineStudentReports frm = new frmBooksFineStudentReports();
            frm.ShowDialog();
        }

        private void booksFineCollectionReportStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmMemberBooksFineReport frm = new frmMemberBooksFineReport();
            frm.ShowDialog();
        }

      

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog();
        }
        public void DBrecovery()
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("DB Backup File|*.bak;");
                _with1.FilterIndex = 4;
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    timer2.Enabled = true;
                    SqlConnection.ClearAllPools();
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string cb = "USE Master ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] SET Single_User WITH Rollback Immediate Restore database [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] FROM disk='" + openFileDialog1.FileName + "' WITH REPLACE ALTER DATABASE [" + System.Windows.Forms.Application.StartupPath + "\\ERPS_db.mdf] SET Multi_User ";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    st1 = User.Text;
                    st2 = "Successfully restore the database";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Recovery_Click(object sender, EventArgs e)
        {
            DBrecovery();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void usersSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRegistration frm = new frmRegistration();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblview.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblview.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMembersEntry frm = new frmMembersEntry();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

      
        private void randomBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRandomBarcodeGenerator frm = new frmRandomBarcodeGenerator();
            frm.ShowDialog();
        }

        private void booksBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodeGeneration frm = new frmBarcodeGeneration();
            frm.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void recoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBrecovery();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactMe frm = new frmContactMe();
            frm.ShowDialog();
        }

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSms frm = new frmSms();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Backup();
                        Logout();
                    }
                    else
                    {
                        Logout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void examManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void journalAndMagazinesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmJournalAndMagazinesBilling frm = new frmJournalAndMagazinesBilling();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBookIssue frm = new frmBookIssue();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
            {
                frm.btnSave.Enabled = true;
                frm.btnSave1.Enabled = true;
            }
            else
            {
                frm.btnSave.Enabled = false;
                frm.btnSave1.Enabled = false;
            }
            if (frm.lblgetdata.Text == "True")
            {
                frm.btnGetdata.Enabled = true;
                frm.btnGetdata1.Enabled = true;
            }
            else
            {
                frm.btnGetdata.Enabled = false;
                frm.btnGetdata1.Enabled = false;
            }
            frm.ShowDialog();
        }

        private void busFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssue frm = new frmBookIssue();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
            {
                frm.btnSave.Enabled = true;
                frm.btnSave1.Enabled = true;
            }
            else
            {
                frm.btnSave.Enabled = false;
                frm.btnSave1.Enabled = false;
            }
            if (frm.lblgetdata.Text == "True")
            {
                frm.btnGetdata.Enabled = true;
                frm.btnGetdata1.Enabled = true;
            }
            else
            {
                frm.btnGetdata.Enabled = false;
                frm.btnGetdata1.Enabled = false;
            }
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmBookReturn frm = new frmBookReturn();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Return' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
            {
                frm.btnSave.Enabled = true;
                frm.btnSave1.Enabled = true;
            }
            else
            {
                frm.btnSave.Enabled = false;
                frm.btnSave1.Enabled = false;
            }
            if (frm.lblgetdata.Text == "True")
            {
                frm.btnGetdata.Enabled = true;
                frm.btnGetdata1.Enabled = true;
            }
            else
            {
                frm.btnGetdata.Enabled = false;
                frm.btnGetdata1.Enabled = false;
            }
            frm.ShowDialog();
        }

        private void hostelFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReturn frm = new frmBookReturn();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Return' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
            {
                frm.btnSave.Enabled = true;
                frm.btnSave1.Enabled = true;
            }
            else
            {
                frm.btnSave.Enabled = false;
                frm.btnSave1.Enabled = false;
            }
            if (frm.lblgetdata.Text == "True")
            {
                frm.btnGetdata.Enabled = true;
                frm.btnGetdata1.Enabled = true;
            }
            else
            {
                frm.btnGetdata.Enabled = false;
                frm.btnGetdata1.Enabled = false;
            }
            frm.ShowDialog();
        }

        private void schoolFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReservations frm = new frmBookReservations();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Reservation' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btngetdata.Enabled = true;
            else
                frm.btngetdata.Enabled = false;
            frm.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmBookReservations frm = new frmBookReservations();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Reservation' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btngetdata.Enabled = true;
            else
                frm.btngetdata.Enabled = false;
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBooksFineSetting frm = new frmBooksFineSetting();
            frm.ShowDialog();
        }

        private void journalAndMagazinesBillingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmJournalAndMagazinesBilling frm = new frmJournalAndMagazinesBilling();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void bill_Click(object sender, EventArgs e)
        {

        }

        private void barcodeGeneratorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       }
}

