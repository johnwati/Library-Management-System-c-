namespace School_Software
{
    partial class frmBookReservations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBookReservations));
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.txtStaffMaxID = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.txtJointAuthor = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtAccessionNo = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btngetdata = new System.Windows.Forms.Button();
            this.btnUpdate_record = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewRecord = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.txtStaffid = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblsave = new System.Windows.Forms.Label();
            this.lblgetdata = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(710, 37);
            this.label1.TabIndex = 128;
            this.label1.Text = "Books Reservations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.txtRemarks);
            this.GroupBox3.Controls.Add(this.dtpReservationDate);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.GroupBox3.Location = new System.Drawing.Point(4, 295);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox3.Size = new System.Drawing.Size(502, 195);
            this.GroupBox3.TabIndex = 131;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Reservation Info";
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(11, 55);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(63, 17);
            this.Label7.TabIndex = 322;
            this.Label7.Text = "Remarks :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(132, 63);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(311, 120);
            this.txtRemarks.TabIndex = 321;
            this.txtRemarks.Text = "";
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReservationDate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReservationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReservationDate.Location = new System.Drawing.Point(132, 29);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(104, 24);
            this.dtpReservationDate.TabIndex = 320;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(11, 29);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(108, 17);
            this.Label6.TabIndex = 319;
            this.Label6.Text = "Reservation Date :";
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.Button1);
            this.GroupBox2.Controls.Add(this.txtStaffMaxID);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.txtStaffName);
            this.GroupBox2.Controls.Add(this.Label16);
            this.GroupBox2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(6, 195);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox2.Size = new System.Drawing.Size(405, 96);
            this.GroupBox2.TabIndex = 130;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Staff Info";
            // 
            // Button1
            // 
            this.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.Button1.FlatAppearance.BorderSize = 2;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.Color.Indigo;
            this.Button1.Location = new System.Drawing.Point(234, 29);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(35, 24);
            this.Button1.TabIndex = 320;
            this.Button1.Text = "...";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button1.MouseHover += new System.EventHandler(this.Button1_MouseHover);
            // 
            // txtStaffMaxID
            // 
            this.txtStaffMaxID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStaffMaxID.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffMaxID.Location = new System.Drawing.Point(114, 29);
            this.txtStaffMaxID.Name = "txtStaffMaxID";
            this.txtStaffMaxID.ReadOnly = true;
            this.txtStaffMaxID.Size = new System.Drawing.Size(95, 24);
            this.txtStaffMaxID.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(12, 29);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 17);
            this.Label3.TabIndex = 319;
            this.Label3.Text = "Staff ID :";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(114, 61);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(253, 24);
            this.txtStaffName.TabIndex = 1;
            // 
            // Label16
            // 
            this.Label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(12, 61);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(75, 17);
            this.Label16.TabIndex = 299;
            this.Label16.Text = "Staff Name :";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.txtJointAuthor);
            this.GroupBox1.Controls.Add(this.txtAuthor);
            this.GroupBox1.Controls.Add(this.txtBookTitle);
            this.GroupBox1.Controls.Add(this.txtAccessionNo);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label23);
            this.GroupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(6, 40);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(405, 152);
            this.GroupBox1.TabIndex = 129;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Book Info";
            // 
            // Button2
            // 
            this.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.Button2.FlatAppearance.BorderSize = 2;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ForeColor = System.Drawing.Color.Indigo;
            this.Button2.Location = new System.Drawing.Point(221, 23);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(35, 24);
            this.Button2.TabIndex = 78;
            this.Button2.Text = "...";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            this.Button2.MouseHover += new System.EventHandler(this.Button2_MouseHover);
            // 
            // txtJointAuthor
            // 
            this.txtJointAuthor.Location = new System.Drawing.Point(114, 113);
            this.txtJointAuthor.Name = "txtJointAuthor";
            this.txtJointAuthor.ReadOnly = true;
            this.txtJointAuthor.Size = new System.Drawing.Size(253, 24);
            this.txtJointAuthor.TabIndex = 4;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(114, 83);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(253, 24);
            this.txtAuthor.TabIndex = 3;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Location = new System.Drawing.Point(114, 53);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.ReadOnly = true;
            this.txtBookTitle.Size = new System.Drawing.Size(253, 24);
            this.txtBookTitle.TabIndex = 1;
            // 
            // txtAccessionNo
            // 
            this.txtAccessionNo.Location = new System.Drawing.Point(114, 23);
            this.txtAccessionNo.Name = "txtAccessionNo";
            this.txtAccessionNo.ReadOnly = true;
            this.txtAccessionNo.Size = new System.Drawing.Size(95, 24);
            this.txtAccessionNo.TabIndex = 0;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Location = new System.Drawing.Point(9, 113);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(86, 17);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Joint Authors :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Location = new System.Drawing.Point(9, 83);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 17);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Author(s) :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(9, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 17);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Book Title :";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.BackColor = System.Drawing.Color.Transparent;
            this.Label23.Location = new System.Drawing.Point(9, 24);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(89, 17);
            this.Label23.TabIndex = 0;
            this.Label23.Text = "Accession No. :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btngetdata);
            this.panel1.Controls.Add(this.btnUpdate_record);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNewRecord);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(576, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 198);
            this.panel1.TabIndex = 141;
            // 
            // btngetdata
            // 
            this.btngetdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btngetdata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngetdata.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngetdata.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btngetdata.Location = new System.Drawing.Point(9, 154);
            this.btngetdata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btngetdata.Name = "btngetdata";
            this.btngetdata.Size = new System.Drawing.Size(92, 32);
            this.btngetdata.TabIndex = 21;
            this.btngetdata.Text = "&Getdata";
            this.btngetdata.UseVisualStyleBackColor = false;
            this.btngetdata.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdate_record
            // 
            this.btnUpdate_record.BackColor = System.Drawing.Color.Maroon;
            this.btnUpdate_record.Enabled = false;
            this.btnUpdate_record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_record.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_record.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate_record.Location = new System.Drawing.Point(9, 79);
            this.btnUpdate_record.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate_record.Name = "btnUpdate_record";
            this.btnUpdate_record.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUpdate_record.Size = new System.Drawing.Size(92, 32);
            this.btnUpdate_record.TabIndex = 20;
            this.btnUpdate_record.Text = "&Update";
            this.btnUpdate_record.UseVisualStyleBackColor = false;
            this.btnUpdate_record.Click += new System.EventHandler(this.btnUpdate_record_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = ".";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(9, 42);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.BackColor = System.Drawing.Color.Indigo;
            this.btnNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRecord.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRecord.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewRecord.Location = new System.Drawing.Point(9, 7);
            this.btnNewRecord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Size = new System.Drawing.Size(92, 32);
            this.btnNewRecord.TabIndex = 0;
            this.btnNewRecord.Text = "&New";
            this.btnNewRecord.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Indigo;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(9, 116);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.Transparent;
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.btnCancelReservation);
            this.Panel4.Location = new System.Drawing.Point(560, 261);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(140, 68);
            this.Panel4.TabIndex = 142;
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelReservation.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancelReservation.Enabled = false;
            this.btnCancelReservation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelReservation.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelReservation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelReservation.Location = new System.Drawing.Point(8, 8);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(124, 46);
            this.btnCancelReservation.TabIndex = 0;
            this.btnCancelReservation.Text = "&Cancel Reservation";
            this.btnCancelReservation.UseVisualStyleBackColor = false;
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
            // 
            // txtStaffid
            // 
            this.txtStaffid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStaffid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtStaffid.Location = new System.Drawing.Point(612, 335);
            this.txtStaffid.Name = "txtStaffid";
            this.txtStaffid.Size = new System.Drawing.Size(88, 13);
            this.txtStaffid.TabIndex = 143;
            this.txtStaffid.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Location = new System.Drawing.Point(605, 335);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(95, 13);
            this.txtStatus.TabIndex = 145;
            this.txtStatus.Visible = false;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Location = new System.Drawing.Point(605, 335);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(95, 13);
            this.txtID.TabIndex = 144;
            this.txtID.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUser.Location = new System.Drawing.Point(640, 363);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 349;
            this.lblUser.Text = "User";
            this.lblUser.Visible = false;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.BackColor = System.Drawing.Color.Transparent;
            this.lblUserType.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUserType.Location = new System.Drawing.Point(640, 363);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(53, 13);
            this.lblUserType.TabIndex = 348;
            this.lblUserType.Text = "UserType";
            this.lblUserType.Visible = false;
            // 
            // lblsave
            // 
            this.lblsave.AutoSize = true;
            this.lblsave.BackColor = System.Drawing.Color.Transparent;
            this.lblsave.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblsave.Location = new System.Drawing.Point(663, 363);
            this.lblsave.Name = "lblsave";
            this.lblsave.Size = new System.Drawing.Size(30, 13);
            this.lblsave.TabIndex = 350;
            this.lblsave.Text = "save";
            this.lblsave.Visible = false;
            // 
            // lblgetdata
            // 
            this.lblgetdata.AutoSize = true;
            this.lblgetdata.BackColor = System.Drawing.Color.Transparent;
            this.lblgetdata.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblgetdata.Location = new System.Drawing.Point(663, 363);
            this.lblgetdata.Name = "lblgetdata";
            this.lblgetdata.Size = new System.Drawing.Size(24, 13);
            this.lblgetdata.TabIndex = 351;
            this.lblgetdata.Text = "Get";
            this.lblgetdata.Visible = false;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 5000;
            this.ToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ToolTip1.InitialDelay = 500;
            this.ToolTip1.OwnerDraw = true;
            this.ToolTip1.ReshowDelay = 50;
            // 
            // frmBookReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(705, 495);
            this.Controls.Add(this.lblgetdata);
            this.Controls.Add(this.lblsave);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtStaffid);
            this.Controls.Add(this.Panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBookReservations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Reservations";
            this.Load += new System.EventHandler(this.frmBookReservations_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.RichTextBox txtRemarks;
        internal System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button Button1;
        public System.Windows.Forms.TextBox txtStaffMaxID;
        private System.Windows.Forms.Label Label3;
        public System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.TextBox txtJointAuthor;
        internal System.Windows.Forms.TextBox txtAuthor;
        internal System.Windows.Forms.TextBox txtBookTitle;
        internal System.Windows.Forms.TextBox txtAccessionNo;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label23;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnUpdate_record;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnNewRecord;
        public System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Panel Panel4;
        public System.Windows.Forms.Button btnCancelReservation;
        public System.Windows.Forms.TextBox txtStaffid;
        internal System.Windows.Forms.TextBox txtStatus;
        internal System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.Button btngetdata;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblUserType;
        public System.Windows.Forms.Label lblsave;
        public System.Windows.Forms.Label lblgetdata;
        internal System.Windows.Forms.ToolTip ToolTip1;
    }
}