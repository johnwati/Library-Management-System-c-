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
    public partial class frmBooksFineSetting : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmBooksFineSetting()
        {
            InitializeComponent();
        }

        private void frmBooksFineSetting_Load(object sender, EventArgs e)
        {
            //Getdata();
        }
        public void Reset()
        {
            txtMaxDaysAllowedStaff.Text = "";
            txtFinePerDayStaff.Text = "";
            txtFinePerDayStudent.Text = "";
            txtMaxDaysAllowedStudent.Text = "";
            txtMaxBooksAllowedStaff.Text = "";
            txtMaxBooksAllowedStudent.Text = "";
            cmbBookType.SelectedIndex = -1;
            textBox1.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            txtMaxDaysAllowedStaff.Focus();
        }
    
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from Setting where where BookType=@d1";
                cmd = new SqlCommand(cq1);
                cmd.Parameters.AddWithValue("@d1", cmbBookType.Text);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbBookType.Text))
            {
                MessageBox.Show("Please select book type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBookType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStaff.Text))
            {
                MessageBox.Show("Please enter fine per day (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStudent.Text))
            {
                MessageBox.Show("Please enter fine per day (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStudent.Focus();
                return;
            }
           }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1 .SelectedRows[0];
                cmbBookType.Text = dr.Cells[0].Value.ToString();
                textBox1.Text = dr.Cells[0].Value.ToString();
                txtMaxBooksAllowedStudent.Text = dr.Cells[1].Value.ToString();
                txtMaxBooksAllowedStaff.Text = dr.Cells[2].Value.ToString();
                txtMaxDaysAllowedStudent.Text = dr.Cells[3].Value.ToString();
                txtMaxDaysAllowedStaff.Text = dr.Cells[4].Value.ToString();
                txtFinePerDayStudent.Text = dr.Cells[5].Value.ToString();
                txtFinePerDayStaff.Text = dr.Cells[6].Value.ToString();
                btnUpdate_record.Enabled = true;
                btnDelete.Enabled = true;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try{
            if (string.IsNullOrEmpty(cmbBookType.Text))
            {
                MessageBox.Show("Please select book type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBookType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxDaysAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. days allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxDaysAllowedStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStaff.Text))
            {
                MessageBox.Show("Please enter fine per day (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFinePerDayStudent.Text))
            {
                MessageBox.Show("Please enter fine per day (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFinePerDayStudent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStaff.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Staff)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStaff.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaxBooksAllowedStudent.Text))
            {
                MessageBox.Show("Please enter max. books allowed (Student)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxBooksAllowedStudent.Focus();
                return;
            }
          
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update Setting Set MaxDays_Staff=@d2, MaxDays_Student=@d3, FinePerDay_Student=@d4, FinePerDay_Staff=@d5,MaxBooks_Staff=@d6,MaxBooks_Student=@d7,BookType=@d1 where BookType=@d8";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbBookType.Text);
                cmd.Parameters.AddWithValue("@d2", txtMaxDaysAllowedStaff.Text);
                cmd.Parameters.AddWithValue("@d3", txtMaxDaysAllowedStudent.Text);
                cmd.Parameters.AddWithValue("@d4", txtFinePerDayStudent .Text);
                cmd.Parameters.AddWithValue("@d5", txtFinePerDayStaff .Text);
                cmd.Parameters.AddWithValue("@d6", txtMaxBooksAllowedStaff  .Text);
                cmd.Parameters.AddWithValue("@d7", txtMaxBooksAllowedStudent.Text);
                cmd.Parameters.AddWithValue("@d8", textBox1.Text);
               cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                //Getdata();
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
    }
}
