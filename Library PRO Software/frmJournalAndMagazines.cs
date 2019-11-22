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
    public partial class frmJournalAndMagazines : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmMainmenu frm = null;
        public frmJournalAndMagazines()
        {
            InitializeComponent();
        }
        public frmJournalAndMagazines(frmMainmenu par)
        {
            frm = par;
            InitializeComponent();
        }
        public void Reset()
        {
            txtSupplierID.Text = "";
           dtpSubDate.Text=System.DateTime.Now.ToString();
            dtpSubDateFrom.Text = System.DateTime.Now.ToString();
            dtpSubDateTo.Text = System.DateTime.Now.ToString();
            txtSupplierName.Text = "";
            txtSupplierMax.Text = "";
            txttitle.Text = "";
            txtSub.Text = "";
            txtRemarks.Text = "";
           txtSupplierMax.Focus();
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
           frmBookSupplierList frm = new frmBookSupplierList(this);
            frm.lblSET.Text = "R";
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttitle.Text == "")
                {
                    MessageBox.Show("Please enter Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttitle.Focus();
                    return;
                }
                if (txtSubNo.Text == "")
                {
                    MessageBox.Show("Please enter SubscriptionNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Focus();
                    return;
                }
                if (dtpSubDateFrom.Value.Date >= dtpSubDateTo.Value.Date)
                {
                    MessageBox.Show("Per Annum SubscriptionDateTo cannot be less than or equal to Per Annum SubscriptionDateFrom ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select SubNo from JM where Subno='" + txtSubNo.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("SubscriptionNo Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Text = "";
                    txtSubNo.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into JM(SubNo, Title, SubscriptionDate, Subscription, SubscriptionDateFrom, SubscriptionDateTo, SupplierID) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSubNo.Text);
                cmd.Parameters.AddWithValue("@d2", txttitle.Text);
                cmd.Parameters.AddWithValue("@d3", dtpSubDate.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtSub.Text);
                cmd.Parameters.AddWithValue("@d5", dtpSubDateFrom.Value.Date);
                cmd.Parameters.AddWithValue("@d6", dtpSubDateTo.Value.Date);
                cmd.Parameters.AddWithValue("@d7", txtSupplierID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
               MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmJournalAndMagazines_Load(object sender, EventArgs e)
        {

        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from JM where Sub_no=" + txtSubNo.Text + "";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
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
                if (txttitle.Text == "")
                {
                    MessageBox.Show("Please enter Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttitle.Focus();
                    return;
                }
                if (txtSubNo.Text == "")
                {
                    MessageBox.Show("Please enter SubscriptionNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubNo.Focus();
                    return;
                }
                if (dtpSubDateFrom.Value.Date >= dtpSubDateTo.Value.Date)
                {
                    MessageBox.Show("Per Annum SubscriptionDateTo cannot be less than or equal to Per Annum SubscriptionDateFrom ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "update Set Title=@d2, SubscriptionDate=@d3, Subscription=@d4, SubscriptionDateFrom=@d5, SubscriptionDateTo=@d6, SupplierID=@d7) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSubNo.Text);
                cmd.Parameters.AddWithValue("@d2", txttitle.Text);
                cmd.Parameters.AddWithValue("@d3", dtpSubDate.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtSub.Text);
                cmd.Parameters.AddWithValue("@d5", dtpSubDateFrom.Value.Date);
                cmd.Parameters.AddWithValue("@d6", dtpSubDateTo.Value.Date);
                cmd.Parameters.AddWithValue("@d7", txtSupplierID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
           frmJournalAndMagazinesList frm = new frmJournalAndMagazinesList(this);
            frm.lblSET.Text = "R2";
            frm.ShowDialog();
        }
    }
}
