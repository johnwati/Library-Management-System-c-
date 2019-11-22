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
    public partial class frmBookSuppliersEntry : Form
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
        string txtStatus1 = null;
        string txtStatus2 = null;
        string txtStatus3 = null;
        public frmBookSuppliersEntry()
        {
            InitializeComponent();
        }
        public void Reset()
        {
        txtSupplierName.Text = "";
        txtAddress.Text = "";
        txtRemarks.Text = "";
        txtSupplierID.Text = "";
        txtContactNo.Text = "";
        txtEmailID.Text = "";
        chkBooks.Checked = false;
        ChkJM.Checked = false;
        ChkNewsPaper.Checked = false;
        txtSupplierName.Focus();
        btnSave.Enabled = true;
        btnUpdate_record.Enabled = false;
        btnDelete.Enabled = false;
        Auto();
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierName.Text == "")
                {
                    MessageBox.Show("Please enter Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSupplierName.Focus();
                    return;
                }
                if ((chkBooks.Checked == false & ChkJM.Checked == false & ChkNewsPaper.Checked == false))
                {
                    MessageBox.Show("Please select Supplier Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contactno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }
                Auto();
                st1 = lblUser.Text;
                st2 = "New Book Supplier '" + txtSupplierName.Text + "' is Added";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Auto()
        {
           
        }
        private void frmBookSuppliersEntry_Load(object sender, EventArgs e)
        {
           Auto();
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierName.Text == "")
                {
                    MessageBox.Show("Please enter Supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSupplierName.Focus();
                    return;
                }
                if ((chkBooks.Checked == false & ChkJM.Checked == false & ChkNewsPaper.Checked == false))
                {
                    MessageBox.Show("Please select Supplier Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contactno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }
                st1 = lblUser.Text;
                st2 = "Book Supplier '" + txtSupplierName.Text + "' is Updated";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ButtonHighlight;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
     
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
              DataGridViewRow dr = DataGridView1.SelectedRows[0];
             txtSupplierID.Text = dr.Cells[0].Value.ToString();
            txtSupplierMax.Text = dr.Cells[1].Value.ToString();
            txtSupplierName.Text = dr.Cells[2].Value.ToString();
           
            if ((dr.Cells[3].Value.ToString() =="Yes" ))
            {
                chkBooks.Checked = true;
            }
            else
            {
                chkBooks.Checked = false;
            }
            
             if ((dr.Cells[4].Value.ToString() =="Yes" ))
             {
                ChkNewsPaper.Checked = true;
             }
             else
             {
                ChkNewsPaper.Checked = false;
             }
            if ((dr.Cells[5].Value.ToString() =="Yes" ))
            {
              ChkJM.Checked = true;
            }
            else
            {
                ChkJM.Checked = false;
            }
              txtAddress.Text = dr.Cells[6].Value.ToString();
            txtContactNo.Text = dr.Cells[7].Value.ToString();
            txtEmailID.Text = dr.Cells[8].Value.ToString();
            txtRemarks.Text = dr.Cells[9].Value.ToString();
            btnSave.Enabled = false;
            btnUpdate_record.Enabled = true;
             btnDelete.Enabled = true;
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
    }
}
