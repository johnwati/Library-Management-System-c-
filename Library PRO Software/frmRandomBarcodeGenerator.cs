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
using System.Security.Cryptography;

namespace School_Software
{
    public partial class frmRandomBarcodeGenerator : Form
    {
        DataTable dt;
        Connectionstring cs = new Connectionstring();
        ReportDocument cry = new ReportDocument();
        public frmRandomBarcodeGenerator()
        {
            InitializeComponent();
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void frmRandomBarcodeGenrator_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.TableName = "Book";
            dt.Columns.Add("AccessionNo", typeof(String));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoPrint.Text))
            {
                MessageBox.Show("Please Enter Number of prints you want.");
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                RptBarCodes rpt = new RptBarCodes();
                for (int j = 1; j <= Int32.Parse(txtNoPrint.Text); j++)
                {
                    textBox1.Text = "B" + GetUniqueKey(8);
                    dt.Rows.Add(textBox1.Text);
                   cry.Load(Application.StartupPath + "\\RptBarCodes.rpt"); 
                    cry.SetDataSource(dt);
                }
                crystalReportViewer1.ReportSource = cry;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNoPrint.Text = "1";
            crystalReportViewer1.ReportSource = null;
        }
    }
}
