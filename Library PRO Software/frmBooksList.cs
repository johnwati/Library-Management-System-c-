using System;
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
    public partial class frmBooksList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmBooksEntry frmBookEntry = null;
        frmBookReservations frmBR = null;
    
        public frmBooksList()
        {
            InitializeComponent();
        }
        public frmBooksList(frmBooksEntry par)
        {
            frmBookEntry = par;
            InitializeComponent();
        }
        public frmBooksList(frmBookReservations par1)
        {
            frmBR = par1;
            InitializeComponent();
        }
       
        public void Reset()
    {
        txtAccessionNo.Text = "";
        txtBookTitle.Text = "";
        txtCategory.Text = "";
        txtClassifications.Text = "";
        txtLanguage.Text = "";
        txtPublisher.Text = "";
        txtSubCategory.Text = "";
        cmbCondition.SelectedIndex = -1;
        cmbStatus.SelectedIndex = -1;
        dtpDateFrom.Text=System.DateTime.Now.ToString();
        dtpDateTo.Text =System.DateTime.Now.ToString();
        Auto();
        }
        public void Auto()
        {
           
        }
        private void frmBooksList_Load(object sender, EventArgs e)
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
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.AccessionNo like '%" + txtAccessionNo.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSubCategory_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtClass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Publisher like '%" + txtPublisher.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void cmbCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Condition ='" + cmbCondition.Text + "' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where BillDate Between @date1 and @Date2 order by AccessionNo ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "BillDate").Value = dtpDateTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Language like '%" + txtLanguage.Text + "%' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Book.AccessionNo),Rtrim(Book.BookTitle),Book.EntryDate,Rtrim(Book.BookPosition),Rtrim(Book.NoOfPages),Rtrim(Book.Language),Rtrim(Book.SubCategoryID),Rtrim(BooksSubCategory.SubCategoryName),Rtrim(BooksCategory.CategoryName),Rtrim(Bookscategory.Classification),Rtrim(Book.Author),Rtrim(Book.JointAuthors),Rtrim(Book.Publisher),Rtrim(Book.PlaceOfPublisher),Rtrim(Book.PublishingYear),Rtrim(Book.Edition),Rtrim(Book.Barcode),Rtrim(Book.ISBN),Rtrim(Book.Volume),Rtrim(Book.SupplierID),Rtrim(Supplier.SupplierMax),Rtrim(Supplier.SupplierName),Rtrim(Book.BillNo),Book.BillDate,Rtrim(Book.Price),Rtrim(Book.Condition),Rtrim(Book.Status),Rtrim(Book.Section),Rtrim(Book.Remarks) FROM Book INNER JOIN BooksSubCategory ON Book.SubCategoryID = BooksSubCategory.SubCategoryID INNER JOIN BooksCategory ON BooksSubCategory.Category_ID = BooksCategory.CategoryID INNER JOIN Classifications ON BooksCategory.Classification = Classifications.Classification INNER JOIN Supplier ON Book.SupplierID = Supplier.SupplierID Where Book.Status ='" + cmbStatus.Text + "' order by AccessionNo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20], rdr[21], rdr[22], rdr[23], rdr[24], rdr[25], rdr[26], rdr[27], rdr[28]);
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
           
            }

           

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }
    }
}
