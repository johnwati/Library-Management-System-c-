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
    public partial class frmBookIssue : Form
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
        int count = 0;
        public frmBookIssue()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            txtAccessionNo.Text = "";
            txtAdmissionNo.Text = "";
            txtAuthor.Text = "";
            txtBookTitle.Text = "";
            txtClass.Text = "";
            txtJointAuthor.Text = "";
            txtRemarks.Text = "";
            txtStudentName.Text = "";
            dtpIssueDate.Text = System.DateTime.Now.ToString();
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            Button1.Enabled = true;
            Button2.Enabled = true;
            dtpDueDate.Text = (dtpIssueDate.Value.Date.AddDays(Convert.ToInt32(txtMaxDay_Student.Text)).ToString());
        }
        public void fillStudents()
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
            cmd.CommandText = "SELECT MaxDays_Student,MaxBooks_Student FROM Setting where BookType=@d1";
            cmd.Parameters.AddWithValue("@d1", txtBookType.Text);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                txtMaxDay_Student.Text = rdr.GetValue(0).ToString();
                txtMaxBooksAllowedStudent.Text = rdr.GetValue(1).ToString();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            dtpDueDate.Text = (dtpIssueDate.Value.Date.AddDays(Convert.ToInt32(txtMaxDay_Student.Text)).ToString());
        }
        public void FillStaffs()
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
                cmd.CommandText = "SELECT MaxDays_Staff,MaxBooks_Staff FROM Setting where BookType=@d1";
                cmd.Parameters.AddWithValue("@d1", txtBookType.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtMaxDay_Staff.Text = rdr.GetValue(0).ToString();
                    txtMaxBooksAllowedStaff.Text = rdr.GetValue(1).ToString();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
    
                dtpDueDate1.Text = dtpIssueDate1.Value.Date.AddDays(Convert.ToInt32(txtMaxDay_Staff.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo.Text == "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo.Focus();
                return;
            }
            if (txtAdmissionNo.Text == "")
            {
                MessageBox.Show("Please retrieve admssion no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Count(AccessionNo) FROM BookIssue_Student where AccessionNo=@d1 and Status='Issued'";
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count = (int)(rdr.GetValue(0));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (count >= Convert.ToInt32(txtMaxBooksAllowedStudent.Text))
                {
                    MessageBox.Show("Maximum no. of books already issued", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into BookIssue_Student(AccessionNo,AdmissionNo,IssueDate,Duedate, Status, Remarks) VALUES (@d2,@d3,@d4,@d5,'Issued',@d6)";
                cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d2", txtAccessionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d4", dtpIssueDate.Value.Date);
                cmd.Parameters.AddWithValue("@d5", dtpDueDate.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtRemarks.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Update Book Set Status='Issued' where AccessionNo=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Book is Issued By Student :'"+txtStudentName.Text+"' Where Book's AccessionNo is'" + txtAccessionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully issued", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo.Text == "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo.Focus();
                return;
            }
            if (txtAdmissionNo.Text == "")
            {
                MessageBox.Show("Please retrieve admssion no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "Update BookIssue_Student set AccessionNo=@d2,AdmissionNo=@d3,IssueDate=@d4,Duedate=@d5,Remarks=@d6 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d2", txtAccessionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d4", dtpIssueDate.Value.Date);
                cmd.Parameters.AddWithValue("@d5", dtpDueDate.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtRemarks.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Issued Book is Updated Having Student :'" + txtStudentName.Text + "' and Book's AccessionNo is'" + txtAccessionNo.Text + "'";
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
                if ((txtStatus.Text == "Issued"))
                {
                    MessageBox.Show("Book is issued..Record can not be deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ctm4 = "select IssueID from Return_Student where IssueID='" + txtID.Text + "'";
                cmd = new SqlCommand(ctm4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Book using on Student's Book Return List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAccessionNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                string ctm5 = "select IssueID from Return_Staff where IssueID='" + txtID1.Text + "'";
                cmd = new SqlCommand(ctm5);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Book using on Staff's Book Return List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    txtAccessionNo1.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cl = "select BookIssue_Student.ID from BookIssue_Student,Return_Student where BookIssue_Student.ID=Return_Student.IssueID and BookIssue_Student.ID=@d1";
                cmd = new SqlCommand(cl);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use in Book Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from BookIssue_Student where ID=@d1";
                cmd = new SqlCommand(cq);
                cmd.Parameters.AddWithValue("@d1", txtID.Text);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "deleted the issued book record for student '" + txtStudentName.Text + "' having Issue ID='" + txtID.Text + "'"; 
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                   MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteRecord();
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset1()
        {
            txtAccessionNo1.Text = "";
            txtStaffID.Text = "";
            txtAuthor1.Text = "";
            txtBookTitle1.Text = "";
            txtJointAuthors1.Text = "";
            txtRemarks1.Text = "";
            txtStaffName.Text = "";
            btnIssueReservation.Enabled = false;
            dtpIssueDate1.Text = System.DateTime.Now.ToString();
            func();
            btnDelete1.Enabled = false;
            btnUpdate1.Enabled = false;
            Button3.Enabled = true;
            Button4.Enabled = true;
       }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo1.Text == "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo1.Focus();
                return;
            }
            if (txtStaffID.Text=="")
            {
                MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffID.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Count(AccessionNo) FROM BookIssue_Staff where AccessionNo=@d1 and Status='Issued'";
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count = (int)(rdr.GetValue(0));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (count >= Convert.ToInt32(txtMaxBooksAllowedStaff.Text))
                {
                    MessageBox.Show("Maximum no. of books already issued", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into BookIssue_Staff(AccessionNo,StaffID,IssueDate,Duedate, Status, Remarks) VALUES (@d2,@d3,@d4,@d5,'Issued',@d6)";
                cmd = new SqlCommand(cb);
              cmd.Parameters.AddWithValue("@d2", txtAccessionNo1.Text);
                cmd.Parameters.AddWithValue("@d3", txtS_ID.Text);
                cmd.Parameters.AddWithValue("@d4", dtpIssueDate1.Value.Date);
                cmd.Parameters.AddWithValue("@d5", dtpDueDate1.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtRemarks1.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Update Book Set Status='Issued' where AccessionNo=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Book is Issued By Staff :'" + txtStaffName.Text + "' Where Book's AccessionNo is'" + txtAccessionNo1.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully issued", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo1.Text== "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo1.Focus();
                return;
            }
            if (txtStaffID.Text == "")
            {
                MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffID.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "Update BookIssue_Staff set AccessionNo=@d2,StaffID=@d3,IssueDate=@d4,Duedate=@d5,Remarks=@d6 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d1", txtID1.Text);
                cmd.Parameters.AddWithValue("@d2", txtAccessionNo1.Text);
                cmd.Parameters.AddWithValue("@d3", txtS_ID.Text);
                cmd.Parameters.AddWithValue("@d4", dtpIssueDate1.Value.Date);
                cmd.Parameters.AddWithValue("@d5", dtpDueDate1.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtRemarks1.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Updated Issued Book Record For Staff '" + txtStaffName.Text + "' Where Book's AccessionNo is'" + txtAccessionNo1.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                 MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnIssueReservation_Click(object sender, EventArgs e)
        {
            if (txtAccessionNo1.Text== "")
            {
                MessageBox.Show("Please retrieve accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessionNo1.Focus();
                return;
            }
            if (txtStaffID.Text=="")
            {
                MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffID.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Count(AccessionNo) FROM BookIssue_Staff where AccessionNo=@d1 and Status='Issued'";
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count = (int)(rdr.GetValue(0));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (count >= Convert.ToInt32(txtMaxBooksAllowedStaff.Text))
                {
                    MessageBox.Show("Maximum no. of books already issued", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();

                string cb = "insert into BookIssue_Staff(AccessionNo,StaffID,IssueDate,Duedate, Status, Remarks) VALUES (@d2,@d3,@d4,@d5,'Issued',@d6)";
                cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d2", txtAccessionNo1.Text);
                cmd.Parameters.AddWithValue("@d3", txtS_ID.Text);
                cmd.Parameters.AddWithValue("@d4", dtpIssueDate1.Value.Date);
                cmd.Parameters.AddWithValue("@d5", dtpDueDate1.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtRemarks1.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Update Book Set Status='Issued' where AccessionNo=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "Update BookReservation Set Status='Issued' where AccessionNo=@d1 and ID=@d2";
                cmd = new SqlCommand(cb2);
                cmd.Parameters.AddWithValue("@d1", txtAccessionNo1.Text);
                cmd.Parameters.AddWithValue("@d2", txtReservationID.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb3 = "Insert into Book_RI(IssueID,ReservationID) values(@d1,@d2)";
                cmd = new SqlCommand(cb3);
                cmd.Parameters.AddWithValue("@d1", txtID1.Text);
                cmd.Parameters.AddWithValue("@d2", txtReservationID.Text);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
               MessageBox.Show("Successfully issued", "Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave1.Enabled = false;
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
                string cl = "select BookIssue_Staff.ID from BookIssue_Staff,Return_Staff where BookIssue_Staff.ID=Return_Staff.IssueID and BookIssue_Staff.ID=@d1";
                cmd = new SqlCommand(cl);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already in use in Book Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from BookIssue_Staff where ID=@d1";
                cmd = new SqlCommand(cq);
                cmd.Parameters.AddWithValue("@d1", txtID1.Text);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted Issued Book Record For Staff '" + txtStaffName.Text + "' Where Book's AccessionNo is'" + txtAccessionNo1.Text + "'";
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

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            DeleteRecord1();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            
        }
        private void Button5_Click(object sender, EventArgs e)
        {
          
        }

        private void Button5_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button5, "Retrieve book info and staff info from list of books reservation");
        }

        private void Button4_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button4, "Retrieve book info from list of books");
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve book info from list of books");
        }
       
        private void ToolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button1, "Retrieve Student info from list of Students");
        }

        private void Button3_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button3, "Retrieve Staff info from list of Staffs");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Book Issue' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmBookIssue_Load(object sender, EventArgs e)
        {
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            frmMemberList frm = new frmMemberList(this);
            frm.lblSET.Text = "BIS";
            frm.Show();
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {
            Reset1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void btnGetdata1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtMaxDay_Student_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            double val1 = 0;
            double.TryParse(txtMaxDay_Student.Text, out val1);
            dtpDueDate.Text = (dtpIssueDate.Value.Date.AddDays(val1).ToString());
        }

        private void dtpIssueDate1_ValueChanged(object sender, EventArgs e)
        {
            double val1 = 0;
            double.TryParse(txtMaxDay_Staff.Text, out val1);
            dtpDueDate.Text = (dtpIssueDate.Value.Date.AddDays(val1).ToString());
        }
    }
}
