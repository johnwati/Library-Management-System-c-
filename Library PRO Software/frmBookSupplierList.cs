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
    public partial class frmBookSupplierList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmJournalAndMagazines frm = null;
        frmBooksEntry frm1 = null;
        public frmBookSupplierList()
        {
            InitializeComponent();
        }
        public frmBookSupplierList(frmJournalAndMagazines par)
        {
            frm = par;
            InitializeComponent();
        }
        public frmBookSupplierList(frmBooksEntry par1)
        {
            frm1 = par1;
            InitializeComponent();
        }
        public void Auto()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(SupplierID),RTRIM(SupplierMax),RTRIM(SupplierName),RTRIM(S_Books),RTRIM(S_NewsPaper), RTRIM(S_Magazines), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks) from supplier order by supplierid", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmBookSupplierList_Load(object sender, EventArgs e)
        {
            Auto();
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(SupplierID),RTRIM(SupplierMax),RTRIM(SupplierName),RTRIM(S_Books),RTRIM(S_NewsPaper), RTRIM(S_Magazines), RTRIM(Address), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks) from supplier order by supplierid Where SupplerName like '%" + txtSupplier.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R")
            {
                try
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    this.Hide();
                    frm.Show();
                    frm.txtSupplierID.Text = dr.Cells[0].Value.ToString();
                    frm.txtSupplierMax.Text = dr.Cells[1].Value.ToString();
                    frm.txtSupplierName.Text = dr.Cells[2].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lblSET.Text == "R0")
            {
                try
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    this.Hide();
                    frm1.Show();
                    frm1.txtSupplierID.Text = dr.Cells[0].Value.ToString();
                    frm1.txtSupplierMax.Text = dr.Cells[1].Value.ToString();
                    frm1.txtSupplierName.Text = dr.Cells[2].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtSupplier.Text = "";
            DataGridView1.Rows.Clear();
            Auto();
        }

    }
}