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
    public partial class frmBooksEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmMainmenu frm = null;
        string s = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmBooksEntry()
        {
            InitializeComponent();
        }
        public frmBooksEntry(frmMainmenu par)
        {
            frm = par;
            InitializeComponent();
        }
          public void  Reset()
          {
        txtAccessionNo.Text = "";
        txtAuthor.Text = "";
        txtBarcode.Text = "";
        txtBillNo.Text = "";
        txtBookPosition.Text = "";
        txtBookTitle.Text = "";
        txtEdition.Text = "";
        txtSupplierName.Text = "";
        txtISBN.Text = "";
        txtJointAuthor.Text = "";
        txtLanguage.Text = "";
        txtNoOfPages.Text = "";
        txtPlaceOfPublisher.Text = "";
        txtPrice.Text = "";
        txtPublisherName.Text = "";
        txtPublishingYear.Text = "";
        txtRemarks.Text = "";
        txtSupplierID.Text = "";
        txtVolume.Text = "";
        cmbCategory.SelectedIndex = -1;
        cmbClassification.SelectedIndex = -1;
        cmbSubCategory.SelectedIndex = -1;
        cmbCondition.SelectedIndex = -1;
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSubCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        dtpBillDate.Text = System.DateTime.Now.ToString();
        dtpEntryDate.Text = System.DateTime.Now.ToString();
        cmbCategory.Enabled = false;
        cmbSubCategory.Enabled = false;
        btnSave.Enabled = true;
        btnDelete.Enabled = false;
        btnUpdate_record.Enabled = false;
        rbNormal.Checked = false;
        rbReference.Checked = false;
        txtAccessionNo.Focus();
      }
        private void AutocompletePublisher()
        {
          
        }
        private void AutocompleteTitle()
        {
           
        }
        private void AutocompleteAuthor()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct Author FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
               txtAuthor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtAuthor.AutoCompleteCustomSource = col;
                txtAuthor.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompletePosition()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct BookPosition FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["BookPosition"].ToString().Trim());

                }
                txtBookPosition.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBookPosition.AutoCompleteCustomSource = col;
                txtBookPosition.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Autocompletejoint()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct JointAuthors FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                
                txtJointAuthor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtJointAuthor.AutoCompleteCustomSource = col;
                txtJointAuthor.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void AutocompletePlace()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct PlaceOfPublisher FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
              
                txtPlaceOfPublisher.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPlaceOfPublisher.AutoCompleteCustomSource = col;
                txtPlaceOfPublisher.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutocompletePLanguage()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Distinct Language FROM Book", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Book");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Language"].ToString().Trim());

                }
                txtLanguage.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtLanguage.AutoCompleteCustomSource = col;
                txtLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
          
        }

        private void frmBooksEntry_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtAccessionNo.Text == "")
                {
                    MessageBox.Show("Please enter accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccessionNo.Focus();
                    return;
                }
                if (txtBookTitle.Text == "")
                {
                    MessageBox.Show("Please enter book title", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookTitle.Focus();
                    return;
                }
                if (txtAuthor.Text == "")
                {
                    MessageBox.Show("Please enter author", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAuthor.Focus();
                    return;
                }
                if (cmbClassification.Text == "")
                {
                    MessageBox.Show("Please select classification", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClassification.Focus();
                    return;
                }
                if (cmbCategory.Text == "")
                {
                    MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCategory.Focus();
                    return;
                }
                if (cmbSubCategory.Text == "")
                {
                    MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubCategory.Focus();
                    return;
                }
                if (txtPublisherName.Text == "")
                {
                    MessageBox.Show("Please enter publisher", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPublisherName.Focus();
                    return;
                }
                if (((rbNormal.Checked == false) & (rbReference.Checked == false)))
                {
                    MessageBox.Show("Please select section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNoOfPages.Text == "")
                {
                    MessageBox.Show("Please enter no. of pages", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoOfPages.Focus();
                    return;
                }

                if (cmbCondition.Text == "")
                {
                    MessageBox.Show("Please select condition", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCondition.Focus();
                    return;
                }
                if (txtPrice.Text == "")
                {
                    MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus();
                    return;
                }
                
                if (txtSupplierID.Text == "")
                {
                    MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierID.Focus();
                    return;
                }
                   con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string ct = "select AccessionNo from Book where AccessionNo=@d1";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtAccessionNo.Text);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        MessageBox.Show("Accession No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAccessionNo.Text = "";
                        txtAccessionNo.Focus();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string ct1 = "select Barcode from Book where Barcode=@d1";
                    cmd = new SqlCommand(ct1);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtBarcode.Text);
                    rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                    {
                        MessageBox.Show("Barcode No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBarcode.Text = "";
                        txtBarcode.Focus();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    if ((rbNormal.Checked == true))
                    {
                        s = rbNormal.Text;
                    }
                    if ((rbReference.Checked == true))
                    {
                        s = rbReference.Text;
                    }
                    Fill();
                    con = new SqlConnection(cs.DBcon);
                   
                    st1 = lblUser.Text;
                    st2 = "New Book '" + txtBookTitle.Text + "' is Added having AccessionNo='" + txtAccessionNo.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    AutocompleteAuthor();
                    Autocompletejoint();
                    AutocompletePlace();
                    AutocompletePLanguage();
                    AutocompletePosition();
                    AutocompletePublisher();
                    AutocompleteTitle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

      
        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        public void Fill()
        {
          
        }

       private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

       private void btnUpdate_record_Click(object sender, EventArgs e)
       {
           try
           {

               if (txtAccessionNo.Text == "")
               {
                   MessageBox.Show("Please enter accession no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtAccessionNo.Focus();
                   return;
               }
               if (txtBookTitle.Text == "")
               {
                   MessageBox.Show("Please enter book title", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtBookTitle.Focus();
                   return;
               }
               if (txtAuthor.Text == "")
               {
                   MessageBox.Show("Please enter author", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtAuthor.Focus();
                   return;
               }
               if (cmbClassification.Text == "")
               {
                   MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbClassification.Focus();
                   return;
               }
               if (cmbCategory.Text == "")
               {
                   MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbCategory.Focus();
                   return;
               }
               if (cmbSubCategory.Text == "")
               {
                   MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbSubCategory.Focus();
                   return;
               }
               if (txtPublisherName.Text == "")
               {
                   MessageBox.Show("Please enter publisher", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtPublisherName.Focus();
                   return;
               }
               if (((rbNormal.Checked == false) & (rbReference.Checked == false)))
               {
                   MessageBox.Show("Please select section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return;
               }

               if (txtNoOfPages.Text == "")
               {
                   MessageBox.Show("Please enter no. of pages", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtNoOfPages.Focus();
                   return;
               }

               if (cmbCondition.Text == "")
               {
                   MessageBox.Show("Please select condition", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   cmbCondition.Focus();
                   return;
               }
               if (txtPrice.Text == "")
               {
                   MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtPrice.Focus();
                   return;
               }
               if (txtSupplierID.Text == "")
               {
                   MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   txtSupplierID.Focus();
                   return;
               }
              if ((rbNormal.Checked == true))
               {
                   s = rbNormal.Text;
               }
               if ((rbReference.Checked == true))
               {
                   s = rbReference.Text;
               }
               Fill();
              st1 = lblUser.Text;
               st2 = "Book '" + txtBookTitle.Text + "' is Updated having AccessionNo='"+txtAccessionNo.Text+"'";
               cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnSave.Enabled = false;
               AutocompleteAuthor();
               Autocompletejoint();
               AutocompletePlace();
               AutocompletePLanguage();
               AutocompletePosition();
               AutocompletePublisher();
               AutocompleteTitle();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void btnGetData_Click(object sender, EventArgs e)
       {
           frmBooksList frm = new frmBooksList(this);
           frm.lblSET.Text = "R1";
           frm.ShowDialog();
       }

       private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

       private void btnNewRecord_Click(object sender, EventArgs e)
       {
           Reset();
       }

       private void btnDelete_Click(object sender, EventArgs e)
       {
          
       }
    }
}
