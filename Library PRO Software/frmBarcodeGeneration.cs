using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
namespace School_Software
{
    public partial class frmBarcodeGeneration : Form
    {
      
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        Connectionstring cs = new Connectionstring();
        
    
         public frmBarcodeGeneration()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
       
        private void frmBarcodeGenration_Load(object sender, EventArgs e)
        {
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        }
      
     
        private void btnAll_Click(object sender, EventArgs e)
        {
          
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtAccessionNo.Text = "";
            txtNoPrint.Text = "1";
            crystalReportViewer1.ReportSource = null;
        }
    }
}
