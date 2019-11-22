using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_Software
{
    public partial class frmWebCam : Form
    {
        public TouchlessLib.TouchlessMgr CamMgr;
       

        public string TempFileNames2;

        public frmWebCam()
        {
            InitializeComponent();
        }

        private void frmWebCam_Load(object sender, EventArgs e)
        {
            CamMgr = new TouchlessLib.TouchlessMgr();
            
            TempFileNames2 = "";

            for (int i = 0; i <= CamMgr.Cameras.Count - 1; i++)
            {
                cmbCamera.Items.Add(CamMgr.Cameras[i].ToString());
            }
            if (cmbCamera.Items.Count > 0)
            {
                cmbCamera.SelectedIndex = 0;
                Timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("There are no Camera ...");
                this.Close();
            }


        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {

            string sTempFileName = System.IO.Path.GetTempFileName();
            TempFileNames2 = sTempFileName;
            Bitmap b = (Bitmap)picPreview.Image;
            b.Save(sTempFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            Timer1.Enabled = false;
            CamMgr.CurrentCamera.Dispose();
           // CamMgr.Cameras.item[cmbCamera.SelectedIndex].Dispose();
            CamMgr.Dispose();
            this.Close();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            picPreview.Image = CamMgr.CurrentCamera.GetCurrentImage();
            btnSave.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            picFeed.Image = CamMgr.CurrentCamera.GetCurrentImage();
        }

        private void frmWebCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Timer1.Enabled = false;
                CamMgr.CurrentCamera.Dispose();
                CamMgr.Cameras.ElementAt(cmbCamera.SelectedIndex).Dispose();
                 CamMgr.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            CamMgr.CurrentCamera = CamMgr.Cameras.ElementAt(cmbCamera.SelectedIndex);
        }
    }
}
