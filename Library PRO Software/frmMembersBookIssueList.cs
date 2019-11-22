﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmMembersBookIssueList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
       
      
        public frmMembersBookIssueList()
        {

            InitializeComponent();
        }
        public void Auto()
        {
           
        }
        private void frmBookIssueListStaff_Load(object sender, EventArgs e)
        {
            Auto();
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

        private void txtAccessionNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnIssueDate_Click(object sender, EventArgs e)
        {
           
        }
        public void Reset()
        {
            txtAccessionNo.Text = "";
            txtBookTitle.Text = "";
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            txtBookTitle.Text = "";
          
        }
        private void btnduedate_Click(object sender, EventArgs e)
        {
            
        }

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }

        }

        private void txtTo_Validating(object sender, CancelEventArgs e)
        {
            if ((txtFrom.Value.Date) > (txtTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTo.Focus();
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R2")
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button10_Click(object sender, EventArgs e)
        {
          
        }
    }
}
