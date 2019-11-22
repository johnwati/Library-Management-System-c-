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
    public partial class frmUserGrants : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmMainmenu frm1 = new frmMainmenu();
        bool IsHeaderCheckBoxClicked = false;
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        CheckBox HeaderCheckBox1 = null;
        CheckBox HeaderCheckBox2 = null;
        CheckBox HeaderCheckBox3 = null;
        CheckBox HeaderCheckBox4 = null;
        
      
        public frmUserGrants()
        {
            InitializeComponent();
        }

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);


            this.dgvSelectAll.Controls.Add(HeaderCheckBox);


        }
        private void AddHeaderCheckBox1()
        {
            HeaderCheckBox1 = new CheckBox();
            HeaderCheckBox1.Size = new Size(15, 15);
            this.dgvSelectAll.Controls.Add(HeaderCheckBox1);
        }
        private void AddHeaderCheckBox2()
        {
            HeaderCheckBox2 = new CheckBox();
            HeaderCheckBox2.Size = new Size(15, 15);
            this.dgvSelectAll.Controls.Add(HeaderCheckBox2);
        }
        private void AddHeaderCheckBox3()
        {
            HeaderCheckBox3 = new CheckBox();
            HeaderCheckBox3.Size = new Size(15, 15);
            this.dgvSelectAll.Controls.Add(HeaderCheckBox3);
        }
        private void AddHeaderCheckBox4()
        {
            HeaderCheckBox4 = new CheckBox();
            HeaderCheckBox4.Size = new Size(15, 15);
            this.dgvSelectAll.Controls.Add(HeaderCheckBox4);
        }

        private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (!IsHeaderCheckBoxClicked)
            //    RowCheckBoxClick((DataGridViewCheckBoxCell)dgvSelectAll[e.ColumnIndex, e.RowIndex]);
        }
        private void forms()
        {
            this.dgvSelectAll.Rows.Add("Master Entry View");
            this.dgvSelectAll.Rows.Add("Users View");
            
            this.dgvSelectAll.Rows.Add("Student View");
            this.dgvSelectAll.Rows.Add("Student Registration");
            this.dgvSelectAll.Rows.Add("Books Fine Setting");
            this.dgvSelectAll.Rows.Add("Book Reservation");
            this.dgvSelectAll.Rows.Add("Book Issue");
            this.dgvSelectAll.Rows.Add("Book Return");
            this.dgvSelectAll.Rows.Add("Journal and Magazines Billing");
            this.dgvSelectAll.Rows.Add("Employee Registration");
            this.dgvSelectAll.Rows.Add("Barcode Genrator All");
            this.dgvSelectAll.Rows.Add("Books Barcode Genrator");
            this.dgvSelectAll.Rows.Add("All Records");
            this.dgvSelectAll.Rows.Add("View Student List");
            this.dgvSelectAll.Rows.Add("View Employee List");
            this.dgvSelectAll.Rows.Add("View Book Supplier List");
            this.dgvSelectAll.Rows.Add("View Books List");
            this.dgvSelectAll.Rows.Add("View Books Reservation List");
            this.dgvSelectAll.Rows.Add("View Books Issue List Student");
            this.dgvSelectAll.Rows.Add("View Books Issue List Staff");
            this.dgvSelectAll.Rows.Add("View Books Return List Student");
            this.dgvSelectAll.Rows.Add("View Books Return List Staff");
              this.dgvSelectAll.Rows.Add("View All Reports");
            this.dgvSelectAll.Rows.Add("View SMS Setting");
            this.dgvSelectAll.Rows.Add("View Backup & Recovery");
            this.dgvSelectAll.Rows.Add("View Logs");
            this.dgvSelectAll.Rows.Add("View Help and About");
           
 }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                // Modifiy Counter;            
                if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;


                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }


        private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSelectAll.CurrentCell is DataGridViewCheckBoxCell)
                dgvSelectAll.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        //********* click on header checkbox

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect3"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
            

        }

        private void HeaderCheckBoxClick1(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }
        private void HeaderCheckBoxClick2(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect1"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void HeaderCheckBoxClick3(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect2"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }
        private void HeaderCheckBoxClick4(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvSelectAll.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBxSelect4"]).Value = HCheckBox.Checked;

            dgvSelectAll.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
           
        }
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }


        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }
        private void HeaderCheckBox1_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick1((CheckBox)sender);
        }
        private void HeaderCheckBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick1((CheckBox)sender);
        }

        private void HeaderCheckBox2_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick2((CheckBox)sender);
        }
        private void HeaderCheckBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick2((CheckBox)sender);
        }


        private void HeaderCheckBox3_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick3((CheckBox)sender);
        }
        private void HeaderCheckBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick3((CheckBox)sender);
        }
        private void HeaderCheckBox4_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick4((CheckBox)sender);
        }
        private void HeaderCheckBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick4((CheckBox)sender);
        }


        //************************************************************** locations*********

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)  //for cell painting event
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            HeaderCheckBox.Location = oPoint;
        }
        private void dgvSelectAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);

            if (e.RowIndex == -1 && e.ColumnIndex == 2)
                ResetHeaderCheckBoxLocation1(e.ColumnIndex, e.RowIndex);

            if (e.RowIndex == -1 && e.ColumnIndex == 3)
                ResetHeaderCheckBoxLocation2(e.ColumnIndex, e.RowIndex);

            if (e.RowIndex == -1 && e.ColumnIndex == 4)
                ResetHeaderCheckBoxLocation3(e.ColumnIndex, e.RowIndex);

            if (e.RowIndex == -1 && e.ColumnIndex == 5)
                ResetHeaderCheckBoxLocation4(e.ColumnIndex, e.RowIndex);
        }




        private void ResetHeaderCheckBoxLocation1(int ColumnIndex, int RowIndex)
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox1.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox1.Height) / 2 + 1;
            HeaderCheckBox1.Location = oPoint;
        }
        private void ResetHeaderCheckBoxLocation2(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox2.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox2.Height) / 2 + 1;
            HeaderCheckBox2.Location = oPoint;
        }
        private void ResetHeaderCheckBoxLocation3(int ColumnIndex, int RowIndex)
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox3.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox3.Height) / 2 + 1;
            HeaderCheckBox3.Location = oPoint;
        }
        private void ResetHeaderCheckBoxLocation4(int ColumnIndex, int RowIndex)
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox4.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox4.Height) / 2 + 1;
            HeaderCheckBox4.Location = oPoint;
        }
        public void Filluser()
        {
            try
            { con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(UserID) FROM Users";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtUserID.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void refresh()
        {

            forms();
            AddHeaderCheckBox();
            AddHeaderCheckBox1();
            AddHeaderCheckBox2();
            AddHeaderCheckBox3();
            AddHeaderCheckBox4();
            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dgvSelectAll.CellValueChanged += new DataGridViewCellEventHandler(dgvSelectAll_CellValueChanged);
            dgvSelectAll.CurrentCellDirtyStateChanged += new EventHandler(dgvSelectAll_CurrentCellDirtyStateChanged);
            dgvSelectAll.CellPainting += new DataGridViewCellPaintingEventHandler(dgvSelectAll_CellPainting);

            HeaderCheckBox1.KeyUp += new KeyEventHandler(HeaderCheckBox1_KeyUp); //trial
            HeaderCheckBox1.MouseClick += new MouseEventHandler(HeaderCheckBox1_MouseClick);


            HeaderCheckBox2.KeyUp += new KeyEventHandler(HeaderCheckBox2_KeyUp); //trial
            HeaderCheckBox2.MouseClick += new MouseEventHandler(HeaderCheckBox2_MouseClick);

            HeaderCheckBox3.KeyUp += new KeyEventHandler(HeaderCheckBox3_KeyUp); //trial
            HeaderCheckBox3.MouseClick += new MouseEventHandler(HeaderCheckBox3_MouseClick);

            HeaderCheckBox4.KeyUp += new KeyEventHandler(HeaderCheckBox4_KeyUp); //trial
            HeaderCheckBox4.MouseClick += new MouseEventHandler(HeaderCheckBox4_MouseClick);

        }
        private void frmUserGrants_Load(object sender, EventArgs e)
        {
          
            Filluser();
            refresh();
        }


        public void setting()
        {
            dgvSelectAll.Rows[1].Cells[2].Selected =false;
            dgvSelectAll.Rows[2].Cells[3].Selected = false;
            dgvSelectAll.Rows[3].Cells[1].Selected = false;
            dgvSelectAll.Rows[1].Cells[5].ReadOnly = true;
        }
        public void getrecord()
        {
           
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = new SqlCommand("SELECT RTRIM(UserGrants.Forms), RTRIM(UserGrants.ViewRecord),RTRIM(UserGrants.Saves), RTRIM(UserGrants.Updates), RTRIM(UserGrants.Deletes), RTRIM(UserGrants.Getdata) FROM  Users INNER JOIN UserGrants ON Users.ID = UserGrants.UserID  where Usergrants.userID = '" + txtID.Text + "'", con);
            rdr = cmd.ExecuteReader();
            dgvSelectAll.Rows.Clear();
            while (rdr.Read())
            {
                dgvSelectAll.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
            }
            con.Close();
           btnUpdate.Enabled = true;
        
         }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            string ct = "SELECT RTRIM(UserGrants.Forms), RTRIM(UserGrants.ViewRecord), RTRIM(UserGrants.Saves), RTRIM(UserGrants.Updates), RTRIM(UserGrants.Deletes), RTRIM(UserGrants.Getdata) FROM  Users INNER JOIN UserGrants ON Users.ID = UserGrants.UserID  where Users.ID = '" + txtID.Text + "'";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Permissions already saved for this user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtUserID.Text = "";
                designation.Text = "";
               txtID.Text = "";
                dgvSelectAll.Rows.Clear();

                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
            con = new SqlConnection(cs.DBcon);
            con.Open();
            string cb3 = "insert into Usergrants(Forms,viewRecord,Saves,updates,Deletes,Getdata,UserID) VALUES (@d1,@d2,@d3,@d4,@d5,@d6," + txtID.Text + ")";
            cmd = new SqlCommand(cb3);
            cmd.Connection = con;
            cmd.Prepare();
            foreach (DataGridViewRow row in dgvSelectAll.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chkBxSelect"].Value) == false)
                    row.Cells["chkBxSelect"].Value = false;
                else
                    row.Cells["chkBxSelect"].Value = true;

                if (Convert.ToBoolean(row.Cells["chkBxSelect1"].Value) == false)
                    row.Cells["chkBxSelect1"].Value = false;
                else
                    row.Cells["chkBxSelect1"].Value = true;

                if (Convert.ToBoolean(row.Cells["chkBxSelect2"].Value) == false)
                    row.Cells["chkBxSelect2"].Value = false;
                else
                    row.Cells["chkBxSelect2"].Value = true;

                if (Convert.ToBoolean(row.Cells["chkBxSelect3"].Value) == false)
                    row.Cells["chkBxSelect3"].Value = false;
                else
                    row.Cells["chkBxSelect3"].Value = true;

                if (Convert.ToBoolean(row.Cells["chkBxSelect4"].Value) == false)
                    row.Cells["chkBxSelect4"].Value = false;
                else
                    row.Cells["chkBxSelect4"].Value = true;

                if (!row.IsNewRow)
                {
                    cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@d3", row.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@d4", row.Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@d5", row.Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@d6", row.Cells[5].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

            }
            con.Close();
           MessageBox.Show("Successfully saved", "User Rights", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;


        }
        
        private void btnGetdatas_Click(object sender, EventArgs e)
        {
            try
            {
                getrecord();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct UserID FROM Usergrants where UserID = '" + txtID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    refresh();
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (designation.Text == "Super Admin")
                {
                    MessageBox.Show("Super Admin Account can not be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Delete from usergrants where UserID=" + txtID.Text + "";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvSelectAll_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
             string strRowNumber = (e.RowIndex + 1).ToString();
        SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
        if (dgvSelectAll.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
        {
            dgvSelectAll.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
        }
        Brush b = SystemBrushes.ButtonHighlight;
        e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
    
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvSelectAll.Rows.Clear();
           forms();
        }

       

        private void txtUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(Users.ID), rtrim(Users.Name),Rtrim(Designations.Designation) FROM Users INNER JOIN Designations ON Users.Designation_ID = Designations.DesignationID WHERE users.UserID = '" + txtUserID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtID.Text = rdr.GetValue(0).ToString().Trim();
                    txtName.Text = rdr.GetValue(1).ToString().Trim();
                    designation.Text = rdr.GetValue(2).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
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

        private void dgvSelectAll_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgvSelectAll.CurrentCell is DataGridViewCheckBoxCell)
              dgvSelectAll.CommitEdit(DataGridViewDataErrorContexts.Commit); 
        }

        private void lblMasterentry_TextChanged(object sender, EventArgs e)
        {
          

            
        }

        private void frmUserGrants_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMainmenu frm = new frmMainmenu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }

     }
}
