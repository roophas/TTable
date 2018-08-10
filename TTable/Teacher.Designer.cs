namespace TTable
{
    partial class Teacher
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
            this.grpAddTeacher = new System.Windows.Forms.GroupBox();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.clbSubject = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.clbClass = new System.Windows.Forms.CheckedListBox();
            this.txtTeacher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.dgTeacher = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.grpAddTeacher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTeacher)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAddTeacher
            // 
            this.grpAddTeacher.Controls.Add(this.cbActive);
            this.grpAddTeacher.Controls.Add(this.btnAddTeacher);
            this.grpAddTeacher.Controls.Add(this.clbSubject);
            this.grpAddTeacher.Controls.Add(this.label5);
            this.grpAddTeacher.Controls.Add(this.txtMobile);
            this.grpAddTeacher.Controls.Add(this.label4);
            this.grpAddTeacher.Controls.Add(this.cbSubject);
            this.grpAddTeacher.Controls.Add(this.clbClass);
            this.grpAddTeacher.Controls.Add(this.txtTeacher);
            this.grpAddTeacher.Controls.Add(this.label3);
            this.grpAddTeacher.Controls.Add(this.label2);
            this.grpAddTeacher.Controls.Add(this.label1);
            this.grpAddTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddTeacher.ForeColor = System.Drawing.Color.Green;
            this.grpAddTeacher.Location = new System.Drawing.Point(23, 28);
            this.grpAddTeacher.Name = "grpAddTeacher";
            this.grpAddTeacher.Size = new System.Drawing.Size(933, 358);
            this.grpAddTeacher.TabIndex = 0;
            this.grpAddTeacher.TabStop = false;
            this.grpAddTeacher.Text = "Add Teacher";
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(395, 302);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(117, 29);
            this.btnAddTeacher.TabIndex = 12;
            this.btnAddTeacher.Text = "Add Teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // clbSubject
            // 
            this.clbSubject.FormattingEnabled = true;
            this.clbSubject.Location = new System.Drawing.Point(643, 99);
            this.clbSubject.Name = "clbSubject";
            this.clbSubject.Size = new System.Drawing.Size(284, 174);
            this.clbSubject.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Optional Subjects";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(644, 50);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(195, 22);
            this.txtMobile.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mobile Number";
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(214, 99);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(271, 24);
            this.cbSubject.TabIndex = 7;
            this.cbSubject.SelectedIndexChanged += new System.EventHandler(this.cbSubject_SelectedIndexChanged);
            // 
            // clbClass
            // 
            this.clbClass.FormattingEnabled = true;
            this.clbClass.Location = new System.Drawing.Point(209, 152);
            this.clbClass.Name = "clbClass";
            this.clbClass.Size = new System.Drawing.Size(172, 123);
            this.clbClass.TabIndex = 6;
            // 
            // txtTeacher
            // 
            this.txtTeacher.Location = new System.Drawing.Point(209, 50);
            this.txtTeacher.Name = "txtTeacher";
            this.txtTeacher.Size = new System.Drawing.Size(276, 22);
            this.txtTeacher.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Main Subject Allocation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Main Subject";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teacher Name";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(234, 13);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(79, 13);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Academic Year";
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(334, 10);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(127, 21);
            this.cbYear.TabIndex = 2;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // dgTeacher
            // 
            this.dgTeacher.AllowUserToOrderColumns = true;
            this.dgTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTeacher.Location = new System.Drawing.Point(30, 406);
            this.dgTeacher.Name = "dgTeacher";
            this.dgTeacher.Size = new System.Drawing.Size(1036, 226);
            this.dgTeacher.TabIndex = 3;
            this.dgTeacher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTeacher_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 659);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 659);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(410, 253);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(70, 20);
            this.cbActive.TabIndex = 13;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 709);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgTeacher);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.grpAddTeacher);
            this.Name = "Teacher";
            this.Text = "Teacher";
            this.Load += new System.EventHandler(this.Teacher_Load);
            this.grpAddTeacher.ResumeLayout(false);
            this.grpAddTeacher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTeacher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddTeacher;
        private System.Windows.Forms.CheckedListBox clbSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.CheckedListBox clbClass;
        private System.Windows.Forms.TextBox txtTeacher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgTeacher;
        private System.Windows.Forms.CheckBox cbActive;
    }
}