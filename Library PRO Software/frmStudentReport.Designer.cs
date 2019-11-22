namespace School_Software
{
    partial class frmStudentReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentReport));
            this.btnReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSchool = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.ComboBox();
            this.txtClass = new System.Windows.Forms.ComboBox();
            this.txtSession = new System.Windows.Forms.ComboBox();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel15.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReset.Location = new System.Drawing.Point(8, 24);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(82, 30);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Indigo;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(678, 34);
            this.label3.TabIndex = 378;
            this.label3.Text = "Student Report";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.btnReset);
            this.panel15.Controls.Add(this.button10);
            this.panel15.Location = new System.Drawing.Point(2, 135);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(195, 73);
            this.panel15.TabIndex = 379;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Indigo;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button10.Location = new System.Drawing.Point(103, 25);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(82, 30);
            this.button10.TabIndex = 1;
            this.button10.Text = "Close";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.txtSchool);
            this.GroupBox4.Controls.Add(this.label8);
            this.GroupBox4.Controls.Add(this.Button1);
            this.GroupBox4.Controls.Add(this.label1);
            this.GroupBox4.Controls.Add(this.Label2);
            this.GroupBox4.Controls.Add(this.label4);
            this.GroupBox4.Controls.Add(this.txtSection);
            this.GroupBox4.Controls.Add(this.txtClass);
            this.GroupBox4.Controls.Add(this.txtSession);
            this.GroupBox4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox4.Location = new System.Drawing.Point(3, 37);
            this.GroupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox4.Size = new System.Drawing.Size(665, 92);
            this.GroupBox4.TabIndex = 380;
            this.GroupBox4.TabStop = false;
            // 
            // txtSchool
            // 
            this.txtSchool.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSchool.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSchool.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchool.FormattingEnabled = true;
            this.txtSchool.Location = new System.Drawing.Point(11, 42);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(193, 24);
            this.txtSchool.TabIndex = 44;
            this.txtSchool.SelectedIndexChanged += new System.EventHandler(this.txtSchool_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 43;
            this.label8.Text = "School :";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.OrangeRed;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Button1.Location = new System.Drawing.Point(569, 37);
            this.Button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(87, 30);
            this.Button1.TabIndex = 36;
            this.Button1.Text = "&Search";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Section :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(349, 18);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(45, 17);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "Class  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Session :";
            // 
            // txtSection
            // 
            this.txtSection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSection.Enabled = false;
            this.txtSection.FormattingEnabled = true;
            this.txtSection.Location = new System.Drawing.Point(456, 41);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(100, 25);
            this.txtSection.TabIndex = 2;
            // 
            // txtClass
            // 
            this.txtClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtClass.Enabled = false;
            this.txtClass.FormattingEnabled = true;
            this.txtClass.Location = new System.Drawing.Point(350, 41);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(95, 25);
            this.txtClass.TabIndex = 1;
            this.txtClass.SelectedIndexChanged += new System.EventHandler(this.txtClass_SelectedIndexChanged);
            // 
            // txtSession
            // 
            this.txtSession.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSession.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSession.Enabled = false;
            this.txtSession.FormattingEnabled = true;
            this.txtSession.Location = new System.Drawing.Point(215, 43);
            this.txtSession.Name = "txtSession";
            this.txtSession.Size = new System.Drawing.Size(124, 25);
            this.txtSession.TabIndex = 0;
            this.txtSession.SelectedIndexChanged += new System.EventHandler(this.txtSession_SelectedIndexChanged);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // frmStudentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(672, 213);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStudentReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Report";
            this.Load += new System.EventHandler(this.frmStudentReport_Load);
            this.panel15.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Panel panel15;
        public System.Windows.Forms.Button button10;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.ComboBox txtSchool;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox txtSection;
        internal System.Windows.Forms.ComboBox txtClass;
        internal System.Windows.Forms.ComboBox txtSession;
        internal System.Windows.Forms.Timer Timer1;
    }
}