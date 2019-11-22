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
    public partial class frmJournalAndMagazinesBilling : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmJournalAndMagazinesBilling()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            txtBillNo.Text = "";
            dtpBillDate.Text = System.DateTime.Now.ToString();
            dtpPaidOn.Text = System.DateTime.Now.ToString();
            txtAmount.Text = "";
            txtIssueNo.Text = "";
            txttitle.Text = "";
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            txttitle.Focus();
            func();
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Journal and Magazines Billing' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmJournalAndMagazinesBilling_Load(object sender, EventArgs e)
        {
         for (int i = 2010; i <= 2050; i++)
            {
                cmbYear.Items.Add(i);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
           
             if (txttitle.Text == "")
                {
                    MessageBox.Show("Please Retrive Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttitle.Focus();
                    return;
                }
                if (txtSubNo.Text == "")
                {
                    MessageBox.Show("Please Retrive SubscriptionNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Focus();
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    MessageBox.Show("Please Enter BillNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBillNo.Focus();
                    return;
                }
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Please Enter Bill Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please Select month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (cmbYear.Text == "")
                {
                    MessageBox.Show("Please Select year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbYear.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select Sub_No,Month,Year from JMB where Sub_no='" + txtSubNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Bill of This Month Already Paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Text = "";
                    txtSubNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmJournalAndMagazinesList frm = new frmJournalAndMagazinesList(this);
            frm.lblSET.Text = "R1";
            frm.Show();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {

                if (txttitle.Text == "")
                {
                    MessageBox.Show("Please Retrive Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttitle.Focus();
                    return;
                }
                if (txtSubNo.Text == "")
                {
                    MessageBox.Show("Please Retrive SubscriptionNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Focus();
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    MessageBox.Show("Please Enter BillNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBillNo.Focus();
                    return;
                }
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Please Enter Bill Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please Select month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (cmbYear.Text == "")
                {
                    MessageBox.Show("Please Select year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbYear.Focus();
                    return;
                }
            
                MessageBox.Show("Successfully Updated Billing Info", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delete_records()
        {
          
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
           
        }
    }
}
