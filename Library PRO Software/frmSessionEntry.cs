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
    public partial class frmSessionEntry : Form
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
        public frmSessionEntry()
        {
            InitializeComponent();
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
              {
                  if (!txtSession.MaskFull)
                  {
                      MessageBox.Show("Please Enter Session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      txtSession.Focus();  
                      return;
                  }
                  con = new SqlConnection(cs.DBcon);
                  con.Open();
                  string ct = "select distinct Session from Sessions where Session='" +txtSession.Text+ "'";
                  cmd = new SqlCommand(ct);
                  cmd.Connection = con;
                  rdr = cmd.ExecuteReader();
                  if (rdr.Read())
                  {
                      MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      txtSession.Text = "";
                
                      txtSession.Focus();
                      if ((rdr != null))
                      {
                          rdr.Close();
                      }
                      return;
                  }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into Sessions(Session) VALUES (@d1)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSession.Text);
                cmd.ExecuteReader();
                con.Close();
                btnSave.Enabled = false;
                st1 = lblUser.Text;
                st2 = "New Session '" + txtSession.Text + "' is Added Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ButtonHighlight;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
    
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
              
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cbz = "update BusFeesPayment set Session='" + txtSession.Text + "'where  Session='" + textBox1.Text + "'";
                cmd = new SqlCommand(cbz);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "update HostelFeesPayment set Session='" + txtSession.Text + "'where  Session='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb3 = "update SchoolFeesPayment set Session='" + txtSession.Text + "'where  Session='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Session '" + txtSession.Text + "' is Updated Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Session Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
          
        }

        private void frmSessionEntry_Load(object sender, EventArgs e)
        {
          
        }

        
    }
}
