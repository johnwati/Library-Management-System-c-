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

namespace School_Software
{
    public partial class frmMembersEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string txtStatus = null;
        string txtStatus1 = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        Connectionstring cs = new Connectionstring();
        public frmMembersEntry()
        {
            InitializeComponent();
        }
        public void Crypto()
        {
            try
            {
                int Num = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string sql = "SELECT MAX(EMPID+1) FROM Employee";
                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                if (Convert.IsDBNull(cmd.ExecuteScalar()))
                {
                    Num = 1;
                    txtEmployeeID.Text = Convert.ToString(Num);
                    txtEmployeeMAX.Text = Convert.ToString("EMP-" + Num);
                }
                else
                {
                    Num = (int)(cmd.ExecuteScalar());
                    txtEmployeeID.Text = Convert.ToString(Num);
                    txtEmployeeMAX.Text = Convert.ToString("EMP-" + Num);
                }
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillDepartment()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Departmentname) FROM Department ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtDepartment.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillDesignation()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Designation) FROM Designations ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                  txtDesignation.Items.Add(rdr[0]);
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
                    txtSchoolName.Items.Add(rdr[0]);
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
            pictureBox1.Image = School_Software.Properties.Resources.photo;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtEmployeeID.Text = "";
            txtBloodGroup.Text = "";
            txtEmployeeID.Text = "";
            txtDesignationID.Text = "";
            txtEmployeeID.Text = "";
            txtBasicSalary.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtCity.Text = "";
            txtmotherName.Text = "";
            txtFatherName.Text = "";
            txtReligion.Text = "";
            txtDOB.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeeMAX.Text= "";
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            txtEmployeeName.Focus();
        }
        private void d2()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from Employee where EMPID=" + txtEmployeeID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Reset();
                    st1 = lblUser.Text;
                    st2 = "Deleted the Employee'" + txtEmployeeName.Text + "' having StaffID='" + txtEmployeeID.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmEmployeeEntry_Load(object sender, EventArgs e)
        {
            Crypto();
            FillDepartment();
            FillDesignation();
            Fillschool();
        }
      
        private void txtSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(School.SchoolID) FROM School Where School.SchoolName = '" + txtSchoolName.Text + "'";
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {

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
                if (txtEmployeeName.Text == "")
                {
                    MessageBox.Show("Please enter Employee name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeName.Focus();
                    return;
                }
                if (!txtDOB.MaskFull)
                {
                    MessageBox.Show("Please Enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDOB.Focus();
                    return;
                }
                if (DOB.Text == "")
                {
                    MessageBox.Show("Please enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DOB.Focus();
                    return;
                }
                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtCity.Text == "")
                {
                    MessageBox.Show("Please enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCity.Focus();
                    return;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please enter Country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCountry.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }

                if (txtDepartment.Text == "")
                {
                    MessageBox.Show("Please select department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDepartment.Focus();
                    return;
                }
                if (txtBloodGroup.Text == "")
                {
                    MessageBox.Show("Please Select Blood Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBloodGroup.Focus();
                    return;
                }

                if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Please enter staff designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesignation.Focus();
                    return;
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                if (txtBasicSalary.Text == "")
                {
                    MessageBox.Show("Please enter basic salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBasicSalary.Focus();
                    return;
                }

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please browse & select photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Browse.Focus();
                    return;
                }
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Select School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into Employee(EmpID,EmpMaxID,EmployeeName,Gender,DOB,Religion,FatherName,MotherName,City,Country,Address,contactNo,DateofJoining,Email,Salary,Status,Photo,Department_ID,Designation_ID,BloodGroup,SchoolID,AccountName,AccountNumber,Bank,Branch,IFSCcode) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtEmployeeID.Text);
                cmd.Parameters.AddWithValue("@d2", txtEmployeeMAX.Text);
                cmd.Parameters.AddWithValue("@d3", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@d4", txtStatus);
                cmd.Parameters.AddWithValue("@d5", txtDOB.Text);
                cmd.Parameters.AddWithValue("@d6", txtReligion.Text);
                cmd.Parameters.AddWithValue("@d7", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@d8", txtmotherName.Text);
                cmd.Parameters.AddWithValue("@d9", txtCity.Text);
                cmd.Parameters.AddWithValue("@d10", txtCountry.Text);
                cmd.Parameters.AddWithValue("@d11", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d12", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@d13", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d14", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d15", txtBasicSalary.Text);
                cmd.Parameters.AddWithValue("@d16", txtStatus1);
                cmd.Parameters.AddWithValue("@d18", txtDepartmentID.Text);
                cmd.Parameters.AddWithValue("@d19", txtDesignationID.Text);
                cmd.Parameters.AddWithValue("@d20", txtBloodGroup.Text);
                cmd.Parameters.AddWithValue("@d21", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d22", txtAccountName.Text);
                cmd.Parameters.AddWithValue("@d23", txtAccountNo.Text);
                cmd.Parameters.AddWithValue("@d24", txtBank.Text);
                cmd.Parameters.AddWithValue("@d25", txtBranch.Text);
                cmd.Parameters.AddWithValue("@d26", txtIFSCcode.Text);
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d17", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Added the New Employee'" + txtEmployeeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
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

        private void btnUpdate_record_Click_1(object sender, EventArgs e)
        {
            try
            {
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
                if (txtEmployeeName.Text == "")
                {
                    MessageBox.Show("Please enter Employee name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeName.Focus();
                    return;
                }
                if (!txtDOB.MaskFull)
                {
                    MessageBox.Show("Please Enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDOB.Focus();
                    return;
                }
                if (DOB.Text == "")
                {
                    MessageBox.Show("Please enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DOB.Focus();
                    return;
                }
                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtCity.Text == "")
                {
                    MessageBox.Show("Please enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCity.Focus();
                    return;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please enter Country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCountry.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }

                if (txtDepartment.Text == "")
                {
                    MessageBox.Show("Please select department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDepartment.Focus();
                    return;
                }
                if (txtBloodGroup.Text == "")
                {
                    MessageBox.Show("Please Select Blood Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBloodGroup.Focus();
                    return;
                }

                if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Please enter staff designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesignation.Focus();
                    return;
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                if (txtBasicSalary.Text == "")
                {
                    MessageBox.Show("Please enter basic salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBasicSalary.Focus();
                    return;
                }

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please browse & select photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Browse.Focus();
                    return;
                }
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Select School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "update Employee Set EmpMaxID=@d1,EmployeeName=@d2,Gender=@d3,DOB=@d4,Religion=@d5,FatherName=@d6,MotherName=@d7,City=@d8,Country=@d9,Address=@d10,contactNo=@d11,DateofJoining=@d12,Email=@d13,Salary=@d14,Status=@d15,Photo=@d16,Department_ID=@d17,Designation_ID=@d18,BloodGroup=@d19,SchoolID=@d20,AccountName=@d21,AccountNumber=@d22,Bank=@d23,Branch=@d24,IFSCcode=@d25 where EMPID='" + txtEmployeeID.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtEmployeeMAX.Text);
                cmd.Parameters.AddWithValue("@d2", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@d3", txtStatus);
                cmd.Parameters.AddWithValue("@d4", txtDOB.Text);
                cmd.Parameters.AddWithValue("@d5", txtReligion.Text);
                cmd.Parameters.AddWithValue("@d6", txtFatherName.Text);
                cmd.Parameters.AddWithValue("@d7", txtmotherName.Text);
                cmd.Parameters.AddWithValue("@d8", txtCity.Text);
                cmd.Parameters.AddWithValue("@d9", txtCountry.Text);
                cmd.Parameters.AddWithValue("@d10", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d11", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@d12", txtJoiningDate.Value.Date);
                cmd.Parameters.AddWithValue("@d13", txtEmail.Text);
                cmd.Parameters.AddWithValue("@d14", txtBasicSalary.Text);
                cmd.Parameters.AddWithValue("@d15", txtStatus1);
                cmd.Parameters.AddWithValue("@d17", txtDepartmentID.Text);
                cmd.Parameters.AddWithValue("@d18", txtDesignationID.Text);
                cmd.Parameters.AddWithValue("@d19", txtBloodGroup.Text);
                cmd.Parameters.AddWithValue("@d20", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d21", txtAccountName.Text);
                cmd.Parameters.AddWithValue("@d22", txtAccountNo.Text);
                cmd.Parameters.AddWithValue("@d23", txtBank.Text);
                cmd.Parameters.AddWithValue("@d24", txtBranch.Text);
                cmd.Parameters.AddWithValue("@d25", txtIFSCcode.Text);
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d16", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteReader();
                //  auto();
                st1 = lblUser.Text;
                st2 = "Updated the Staff'" + txtEmployeeName.Text + "' having EmployeeID '" + txtEmployeeID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtDepartment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DepartmentID FROM Department WHERE DepartmentName = '" + txtDepartment.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtDepartmentID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void txtDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DesignationID FROM Designations WHERE Designation = '" + txtDesignation.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtDesignationID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void Browse_Click_1(object sender, EventArgs e)
        {
            var _with1 = OpenFileDialog1;

            _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
            _with1.FilterIndex = 4;

            //Clear the file name
            OpenFileDialog1.FileName = "";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = School_Software.Properties.Resources.photo;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                d2();
            }
        }

        private void btnGetData_Click_1(object sender, EventArgs e)
        {
           frmMemberList frm = new frmMemberList(this);
           frm.lblSET.Text = "ST";
            frm.ShowDialog();
        }
    }
}
