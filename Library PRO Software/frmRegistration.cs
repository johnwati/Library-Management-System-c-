using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using webs;

namespace School_Software
{
    public partial class frmRegistration : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        bool IsImageChanged = false;

       public string TempFileNames2="";
       string txtStatus = null;
        string txtStatus1 = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public string Photoname = null;
        public frmRegistration()
        {
            InitializeComponent();
        }
        public void Fillsession()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Session) FROM Sessions ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
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
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM ClassSection INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID ";
                cmd = new SqlCommand(ct1);
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
      
        public void Fillschool()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(SchoolName) FROM School ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtschoolName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
      
      
        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
        }

        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from STUDENT where admissionno='" + txtAdmissionNo.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted the Student'" + txtStudentName.Text + "' having AdmissionNo'" + txtAdmissionNo.Text + "' and Class'" + txtClass.Text + "' and School'" + txtschoolName.Text + "'";
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
        public void D1()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            string cb1 = "insert into doc(Admission_No,Document_Name) VALUES (@d1,@d2)";
            cmd = new SqlCommand(cb1);
            cmd.Connection = con;
            cmd.Prepare();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                    cmd.Parameters.AddWithValue("@d2", row.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
         try
         {
          
                        con = new SqlConnection(cs.DBcon);
                        con.Open();
                        string cb5 = "insert into StudentDiscount(Admission_no,FeeType,Discount) VALUES (@d1,@d2,@d3)";
                        cmd = new SqlCommand(cb5);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                        cmd.Parameters.AddWithValue("@d2", "Hostel");
                        cmd.Parameters.AddWithValue("@d3", "0.00");
                        cmd.ExecuteReader();
                        con.Close();
                        st1 = lblUser.Text;
                        st2 = "Added New Student'" + txtStudentName.Text + "' having AdmissionNo'" +txtAdmissionNo.Text + "' and Class'" + txtClass.Text + "' and School'" + txtschoolName.Text + "'";
                        cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Student Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = OpenFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;

                OpenFileDialog1.FileName = "";

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Picture.Image = Image.FromFile(OpenFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtContactNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtContactNo.TextLength >= 15)
            {
                MessageBox.Show("Mobile Number Can not be Greater than 15 digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
        }

        private void txtHomePhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtContactNo.TextLength >= 15)
            {
                MessageBox.Show("Mobile Number Can not be Greater than 15 digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
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
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM ClassSection,class,Section where ClassSection.Class_ID = Class.ClassID and ClassSection.Section_ID = Section.SectionID and Class.className = '" + txtClass.Text + "'";
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

        private void txtSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct Rtrim(ClasssectionID) FROM ClassSection,class,Section where ClassSection.Class_ID = Class.ClassID and ClassSection.Section_ID = Section.SectionID and Class.className = '" + txtClass.Text + "' and Section.SectionName = '" + txtSection.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   txtClassSectionID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void txtschoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(School.SchoolID) FROM School Where School.SchoolName = '" + txtschoolName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSchoolID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(Sessions.SessionID) FROM Sessions Where Sessions.Session = '" + txtSession.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSessionID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
           
           
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtHomePhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtHight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Please add Submitted Documents in a Document Grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtAdmissionNo .Text) != (txtAdmissionNo1.Text))
            {
                con = new SqlConnection(cs.DBcon);
                 con.Open();
                 string ct = "select AdmissionNo from Student where AdmissionNo='" + txtAdmissionNo.Text + "'";
                 cmd = new SqlCommand(ct);
                 cmd.Connection = con;
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     MessageBox.Show("AdmissionNo Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     txtAdmissionNo.Text = "";
                    txtAdmissionNo.Focus();
                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                     return;
                 }
             }
            if ((radioButton1.Checked == false & radioButton2.Checked == false))
            {
                MessageBox.Show("Please select Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((radioButton1.Checked == true))
            {
                txtStatus = radioButton1.Text;
            }
            if ((radioButton2.Checked == true))
            {
                txtStatus = radioButton2.Text;
            }
            if ((txtcheckBox.Checked == true))
            {
                txtStatus1 = txtcheckBox.Text;
            }
            if ((txtcheckBox.Checked == false))
            {
                txtStatus1 = "Inactive";
            }
             con = new SqlConnection(cs.DBcon);
            con.Open();
            string cq1 = "delete from Doc where Admission_No='" + txtAdmissionNo1.Text + "'";
            cmd = new SqlCommand(cq1);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            D1();
            st1 = lblUser.Text;
            st2 = "Updated Student'" + txtStudentName.Text + "' having AdmissionNo'" + txtAdmissionNo.Text + "' and Class'" + txtClass.Text + "' and School'" + txtschoolName.Text + "'";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnUpdate_record.Enabled = false;
           }
          
        public void Reset()
        {
            txtAdmissionNo.Text="";
           txtEnrollmentNo.Text="";
           txtStudentName.Text = "";
            txtFatherName.Text="";
            txtFatherOcc.Text="";
            txtMotherName.Text="";
            txtMotherOcc.Text="";
            txtParentContact.Text="";
            txtPermanentAddress.Text="";
            txtTemporaryAddress.Text="";
            txtContactNo.Text="";
            txtCategory.Text="";
            txtReligion.Text="";
            txtNationality.Text="";
            txtHomePhoneNo.Text = "";
           txtResult.Text = "";
            txtEmailID.Text = "";
             txtSessionID.Text = "";
           txtGuardianContact.Text = "";
            txtGuardianAddress.Text = "";
           dtpAdmissionDate.Text = System.DateTime.Now.ToString();
           txtDOB.Text = "";
            txtGuardianName.Text = "";
            txtWeight.Text = "";
            txtHight.Text = "";
            txtResult.SelectedIndex = -1;
            txtBloodGroup.SelectedIndex = -1;
            txtBoard.Text = "";
            txtAdmissionNo.Text = "";
            txtClass.Text = "";
            txtPercentage.Text = "";
            txtschoolName.Text = "";
            txtSession.Text = "";
            txtcity.Text = "";
            txtCountry.Text = "";
            txtPassingYr.Text = "";
            txtLastClassName.Text = "";
            txtSection.Enabled = false;
            txtlastschool.Text = "";
            txtSchoolID.Text = "";
            txtClassSectionID.Text = "";
            txtAdmissionNo.Focus();
            dataGridView2.Rows.Clear();
            cmbDocumentsSubmitted.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
             radioButton1.Checked = false;
             radioButton2.Checked = false;
             txtcheckBox.Checked = true;
             
             txtPercentage.ReadOnly = true;
             func();
             btnDelete.Enabled = false;
             btnUpdate_record.Enabled = false;
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + lblUser.Text + "' ";
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
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            } 
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
     
        private void BStartCapture_Click(object sender, EventArgs e)
        {
            frmCamera frm = new frmCamera();
            frm.Show();
            if (Convert.ToInt32(TempFileNames2.Length.ToString()) >= 0)
            {
                
                Picture.Image = Image.FromFile(TempFileNames2);
               Photoname = TempFileNames2;
               IsImageChanged = true;
   }
             
            }

      

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                btnRemove.Enabled = true;
            }
            btnRemove.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          if (string.IsNullOrEmpty(this.cmbDocumentsSubmitted.Text))
            {
                MessageBox.Show("Please Select Document", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cmbDocumentsSubmitted.Focus();
                return;
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (cmbDocumentsSubmitted.Text == row.Cells[0].Value.ToString())
                {
                    MessageBox.Show("Document already added", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            dataGridView2.Rows.Add(cmbDocumentsSubmitted.Text);
        }

        private void btnRemovelist_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                dataGridView2.Rows.Remove(row);
            }

            btnRemove.Enabled = false;
        }
        }
    }

