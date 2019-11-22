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
    public partial class frmBusHolderStudents : Form
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
      
        public frmBusHolderStudents()
        {
           
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList(this);
            frm.lblSET.Text = "R1";
            frm.Show();
        }
        public void Reset()
        {
        txtJoiningDate.Text = System.DateTime.Now.ToString();
        txtStatus.SelectedIndex = 0;
        txtBusNo.SelectedIndex = -1;
        txtStudentName.Text = "";
        txtSection.Text = "";
         txtSession.Text = "";
        txtBusID.Text = "";
        txtBusholderID.Text = "";
        txtAdmissionNo.Text = "";
        txtClass.Text = "";
        txtSchoolName.Text = "";
        txtLocationName.SelectedIndex = -1;
        func();
        btnUpdate_record.Enabled = false;
        btnDelete.Enabled = false;
        txtAdmissionNo.Focus();
       }
        public void Fill()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(BusNO) FROM Bus ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                 while (rdr.Read())
                {
                    txtBusNo.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillLocation()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Location) FROM Locations ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtLocationName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student BusHolder Entry' and Users.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lblSave.Text = rdr[0].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblSave.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }
        private void frmBusHolderStudents_Load(object sender, EventArgs e)
        {
            Fill();
            FillLocation();
           
         }

        private void txtBusNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(BusID) FROM Bus WHERE BusNo = '" + txtBusNo.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBusID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void txtLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(LocationID) FROM Locations WHERE Location = '" + txtLocationName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtLocationID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
             if (txtBusNo.Text == "")
                {
                    MessageBox.Show("Please enter BusNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBusNo.Focus();
                    return;
                }
                if (txtAdmissionNo.Text == "")
                {
                    MessageBox.Show("Please Retrive Admissionno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAdmissionNo.Focus();
                    return;
                }
               if (txtLocationName.Text == "")
                {
                    MessageBox.Show("Please enter Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLocationName.Focus();
                    return;
                }
                if (txtStatus.Text == "")
                {
                    MessageBox.Show("Please Select Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStatus.Focus();
                    return;
                }
               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select Admission_No from StudentBusHolder where Admission_No='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBusNo.Text = "";
                    txtBusNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into StudentBusHolder(Admission_No, Bus_ID, Location_ID, JoiningDate, Status) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtBusID.Text);
                cmd.Parameters.AddWithValue("@d3", txtLocationID.Text);
                cmd.Parameters.AddWithValue("@d4", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d5", txtStatus.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "New BusHolder '" + txtStudentName.Text + " is Added Successfully  Having AdmissionNo'" + txtAdmissionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmBusHolderStudentList frm = new frmBusHolderStudentList(this);
            frm.lblSET.Text = "R0";
            frm.ShowDialog();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ctm3 = "select BusHolder_ID from BusFeesPayment where BusHolder_ID='" + txtBusholderID.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this BusHolder using on Student's BusFeesPayment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentName.Text = "";
                    Reset();
                    txtBusholderID.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from StudentBusHolder where BusHolderID='" + txtBusholderID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "BusHolder '" + txtStudentName.Text + " is Deleted Successfully  Having AdmissionNo'" + txtAdmissionNo.Text + "'";
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
                delete_records();
             } 
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
           try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "update Studentbusholder set Admission_No=@d2,Bus_ID=@d3,Location_ID=@d4,JoiningDate=@d5,Status=@d6 where BusholderID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtBusholderID.Text);
                cmd.Parameters.AddWithValue("@d2", txtAdmissionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtBusID.Text);
                cmd.Parameters.AddWithValue("@d4", txtLocationID.Text);
                cmd.Parameters.AddWithValue("@d5", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d6", txtStatus.Text);
                cmd.ExecuteReader();
                st1 = lblUser.Text;
                st2 = "BusHolder '" + txtStudentName.Text + " is Updated Successfully  Having AdmissionNo'" + txtAdmissionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Student Busholder Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Student info from Student List");
        }
    }
}
