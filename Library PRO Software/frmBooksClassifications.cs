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
    public partial class frmBooksClassifications : Form
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
        public frmBooksClassifications()
        {
            InitializeComponent();
        }

        private void frmBooksClassifications_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClassification.Text == "")
                {
                    MessageBox.Show("Please Enter Classification", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassification.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select classification from classifications where classification='" + txtClassification.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClassification.Text = "";
                    Reset();
                    txtClassification.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
              
                st1 = lblUser.Text;
                st2 = "Book Classification'" + txtClassification + "' is Added ";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetData()
        {
           
        }
        private void Reset()
        {
            textBox1.Text = "";
            txtClassification.Text = "";
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
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
                txtClassification.Text = dr.Cells[0].Value.ToString();
                textBox1.Text = dr.Cells[0].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate_record.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void delete_records()
        {
           
        }
        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (txtClassification.Text == "")
            {
                MessageBox.Show("Please Enter Classification", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClassification.Focus();
                return;
            }
            GetData();
            st1 = lblUser.Text;
            st2 = "Book Classification'" + txtClassification + "' is Updated ";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
