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
    public partial class frmBusFeesPaymentStudent : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        frmReport frm = new frmReport();
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmBusFeesPaymentStudent()
        {
            InitializeComponent();
        }
      
        private void Button2_Click(object sender, EventArgs e)
        {
            frmBusHolderStudentList frm = new frmBusHolderStudentList(this);
            frm.lblSET.Text = "R";
            frm.Show();
        }
        
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from BusFeesPayment where BFP_ID='" + txtBFPID.Text + "'";
                cmd = new SqlCommand(cq1);
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
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
        public void Reset()
        {
            txtGrandTotal.Text = "";
            txtDiscount.Text = "";
           txtBFPID.Text="";
            txtBusHolderID.Text="";
            txtFeePaymentID.Text="";
            txtPaymentMode.SelectedIndex = -1;
            txtPaymentModeDetails.Text = "";
            txtStudentName.Text = "";
            txtSection.Text = "";
            txtSession.Text = "";
            txtDiscountPer.Text = "";
            txtAdmissionNo.Text = "";
            txtClass.Text = "";
            txtSchoolname.Text = "";
            txtLocation.Text = "";
            txtPreviousDue.Text="";
            txtFine.Text="";
            txtGrandTotal.Text="";
            txtTotalPaid.Text="";
            txtPaymentMode.Text="";
            txtPaymentModeDetails.Text="";
            txtBalance.Text="";
            func();
            btnPrint.Enabled = false;
            Button2.Enabled = true;
          
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            txtAdmissionNo.Focus();
           }
        private void frmBusFeesPaymentStudent_Load(object sender, EventArgs e)
        {
            Reset();
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Bus Fees Payment Student' and Users.UserID='" + lblUser.Text + "' ";
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
        private void txtInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
       
        private void txtFine_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtTotalPaid_Validating(object sender, CancelEventArgs e)
        {
           ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {try{
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve busHolder's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
            
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (txtPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
           
            if (Convert.ToDecimal(txtTotalPaid.Text) < 0)
            {
                MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalPaid.Focus();
                return;
            }
            if (Convert.ToDecimal(txtBalance.Text) < 0)
            {
                MessageBox.Show("Balance is not possible less than zero", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
             MessageBox.Show("Successfully paid", "Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                btnPrint.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve busHolder's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
           
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (txtPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }

            if (Convert.ToDecimal(txtTotalPaid.Text) < 0)
            {
                MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalPaid.Focus();
                return;
            }
            if (Convert.ToDecimal(txtBalance.Text) < 0)
            {
                MessageBox.Show("Balance is not possible less than zero", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
}
  

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
           } 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Student's Info from BusHolder's List");
        }

      }
}
