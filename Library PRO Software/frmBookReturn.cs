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
    public partial class frmBookReturn : Form
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
        public frmBookReturn()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo.Text=="")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo.Focus();
                return;
            }
            if (txtAdmissionNo.Text== "")
            {
                MessageBox.Show("Please retrieve admssion no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }

            con = new SqlConnection(cs.DBcon);
            con.Open();
            string ct = "SELECT Rtrim(Return_Student.IssueID) FROM Return_Student INNER JOIN BookIssue_Student ON Return_Student.IssueID = BookIssue_Student.ID Where Return_Student.IssueID=@d1";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", txtIssueID_Student.Text);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("This Book is Already Returned By Student", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
            try
            {
              con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Update Book Set Status='Available' where AccessionNo=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "Update BookIssue_Student Set Status='Returned' where AccessionNo=@d1 and ID=@d2";
                cmd = new SqlCommand(cb2);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtIssueID_Student.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Book is Returned By Student :'" + txtStudentName.Text + "' Where Book's AccessionNo is'" + txtAccessionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully returned", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Reset()
        {
            txtAccessionNo.Text = "";
            dtpReturnDate.Text = System.DateTime.Now.ToString();
            txtFine.Text = "";
            txtAdmissionNo.Text = "";
            txtAuthor.Text = "";
            txtBookTitle.Text = "";
            txtClass.Text = "";
            txtJointAuthor.Text = "";
            txtRemarks.Text = "";
            txtStudentName.Text = "";
            dtpIssueDate.Text = System.DateTime.Now.ToString();
            dtpDueDate.Text = System.DateTime.Now.ToString();
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            Button2.Enabled = true;
           
        }
        
        public void Reset1()
        {
            txtAccessionNo1.Text = "";
            txtReservationID.Text = "";
            txtStaffID.Text = "";
            txtAuthor1.Text = "";
            txtBookTitle1.Text = "";
            txtJointAuthors1.Text = "";
            txtRemarks1.Text = "";
            txtStaffName.Text = "";
            dtpIssueDate1.Text = System.DateTime.Now.ToString();
            func();
            dtpReturnDate1.Text = System.DateTime.Now.ToString();
            txtFine1.Text = "";
            btnDelete1.Enabled = false;
            btnUpdate1.Enabled = false;
            dtpDueDate1.Text = System.DateTime.Now.ToString();
            Button4.Enabled = true;
       }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo.Text=="")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo.Focus();
                return;
            }
            if (txtAdmissionNo.Text== "")
            {
                MessageBox.Show("Please retrieve admssion no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            try
            {
               st1 = lblUser.Text;
                st2 = "Book is Updated Which is Returned By Student :'" + txtStudentName.Text + "' Having AccessionNo'" + txtAccessionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from Return_Student where ReturnID=@d1";
                cmd = new SqlCommand(cq);
                cmd.Parameters.AddWithValue("@d1", txtID.Text);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                 MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  Reset();
                }
                else
                {
                    st1 = lblUser.Text;
                    st2 = " Deleted The Book Which is Returned By Student :'" + txtStudentName.Text + "' Having AccessionNo'" + txtAccessionNo.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
        public void FillDatastaff()
        {
            try
            {
               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT [Section] FROM Book where AccessionNo=@d1";
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBookType.Text = rdr.GetValue(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT FinePerDay_Staff FROM Setting where BookType=@d1";
                cmd.Parameters.AddWithValue("@d1", txtBookType.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtFinePerDayStaff.Text = rdr.GetValue(0).ToString();
                  
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
               
                if (dtpReturnDate1.Value.Date < dtpDueDate1.Value.Date)
                {
                    txtFine1.Text = ("0").ToString();
                }
                else
                {
                    txttotalDaysStaff.Text = dtpReturnDate1.Value.Date.Subtract(dtpDueDate1.Value.Date).Days.ToString();
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT [Section] FROM Book where AccessionNo=@d1";
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBookType.Text = rdr.GetValue(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT [Section] FROM Book where AccessionNo=@d1";
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBookType.Text = rdr.GetValue(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT FinePerDay_Student FROM Setting where BookType=@d1";
                cmd.Parameters.AddWithValue("@d1", txtBookType.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                 txtFinePerDayStudent.Text = rdr.GetValue(0).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (dtpReturnDate.Value.Date < dtpDueDate.Value.Date)
                {
                    txtFine.Text = ("0").ToString();
                }
                else
                {
                
                   txttotaldaysstudent.Text = dtpReturnDate.Value.Date.Subtract(dtpDueDate.Value.Date).Days.ToString();
                   
               }
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecord1()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from Return_Staff where ID=@d1";
                cmd = new SqlCommand(cq);
                cmd.Parameters.AddWithValue("@d1", txtID1.Text);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Book Return Record is  Deleted For Staff :'" + txtStaffName.Text + "' Where Book's AccessionNo is'" + txtAccessionNo1.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset1();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset1();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo1.Text== "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo1.Focus();
                return;
            }
            if (txtStaffID.Text== "")
            {
                MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffID.Focus();
                return;
            }
            try
            {
                st1 = lblUser.Text;
                st2 = "Book Return Record is  Updated For Staff :'" + txtStaffName.Text + "' Where Book's AccessionNo is'" + txtAccessionNo1.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo1.Text == "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo1.Focus();
                return;
            }
            if (txtStaffID.Text== "")
            {
                MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffID.Focus();
                return;
            }
            con = new SqlConnection(cs.DBcon);
            con.Open();
            string ct = "SELECT Rtrim(Return_Staff.IssueID) FROM Return_Staff INNER JOIN BookIssue_Staff ON Return_Staff.IssueID = BookIssue_Staff.ID Where Return_Staff.IssueID=@d1";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", txtIssueID_Staff.Text);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("This Book is Already Returned By Staff", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into Return_Staff(IssueID,ReturnDate,Fine,Remarks) VALUES (@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d2", txtIssueID_Staff.Text);
                cmd.Parameters.AddWithValue("@d3", dtpReturnDate1.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtFine1.Text);
                cmd.Parameters.AddWithValue("@d5", txtRemarks1.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Update Book Set Status='Available' where AccessionNo=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "Update BookIssue_Staff Set Status='Returned' where AccessionNo=@d1 and ID=@d2";
                cmd = new SqlCommand(cb2);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                cmd.Parameters.AddWithValue("@d2", txtIssueID_Staff.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                if (!string.IsNullOrEmpty(txtReservationID.Text))
                {
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string cb3 = "Update BookReservation Set Status='Returned' where AccessionNo=@d1 and ID=@d2";
                    cmd = new SqlCommand(cb3);
                    cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                    cmd.Parameters.AddWithValue("@d2", txtReservationID.Text);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                }
                st1 = lblUser.Text;
                st2 = "Book is Returned By Staff :'" + txtStaffName.Text + "' Where Book's AccessionNo is'" + txtAccessionNo1.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully returned", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            DeleteRecord1();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void dtpReturnDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpReturnDate.Value.Date < dtpDueDate.Value.Date)
            {
                txtFine.Text = "0";
            }
            else
            {

                txttotaldaysstudent.Text = dtpReturnDate.Value.Date.Subtract(dtpDueDate.Value.Date).Days.ToString();
            }
        }

        private void dtpReturnDate1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReturnDate1.Value.Date < dtpDueDate1.Value.Date)
            {
                txtFine1.Text = "0";
            }
            else
            {

                txttotalDaysStaff.Text = dtpReturnDate1.Value.Date.Subtract(dtpDueDate1.Value.Date).Days.ToString();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
          
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Return' and Users.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lblsave.Text = rdr[0].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblsave.Text == "True")
            {
                this.btnSave.Enabled = true;
                this.btnSave1.Enabled = true;
            }
            else
            {
                this.btnSave.Enabled = false;
                this.btnSave1.Enabled = false;
            }
        }
        private void frmBookReturn_Load(object sender, EventArgs e)
        {

        }
        public void fine()
        {
            decimal val1 = 0;
            decimal val3 = 0;
            decimal.TryParse(txttotaldaysstudent.Text, out val1);
            decimal.TryParse(txtFinePerDayStudent.Text, out val3);
            txtFine.Text = ((val1 * val3)).ToString();
       }
        public void fine1()
        {
            decimal val1 = 0;
            decimal val3 = 0;
            decimal.TryParse(txttotalDaysStaff.Text, out val1);
            decimal.TryParse(txtFinePerDayStaff.Text, out val3);
            txtFine1.Text = ((val1 * val3)).ToString();
        }
        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReturnDate.Value.Date < dtpDueDate.Value.Date)
            {
                txtFine.Text = "0";
            }
            else
            {
               
                 txttotaldaysstudent.Text = dtpReturnDate.Value.Date.Subtract(dtpDueDate.Value.Date).Days.ToString();
           }

        }

        private void txttotaldaysstudent_TextChanged(object sender, EventArgs e)
        {
            fine();
        }

        private void dtpReturnDate1_Validating(object sender, CancelEventArgs e)
        {
            if (dtpReturnDate1.Value.Date < dtpDueDate1.Value.Date)
            {
                txtFine1.Text = "0";
            }
            else
            {

                txttotalDaysStaff.Text = dtpReturnDate1.Value.Date.Subtract(dtpDueDate1.Value.Date).Days.ToString();
            }
        }

        private void txttotalDaysStaff_TextChanged(object sender, EventArgs e)
        {
            fine1();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGetdata1_Click(object sender, EventArgs e)
        {
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void Button4_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button4, "Retrieve book info from Issued books List");
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve book info from Issued books List");
        }
    }
}
