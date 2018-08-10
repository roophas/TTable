namespace TTable
{
    partial class ViewTeacherSchedule
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
            Calendar.DrawTool drawTool2 = new Calendar.DrawTool();
            this.daySchedule = new Calendar.DayView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTeacherName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAcYear = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnView = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // daySchedule
            // 
            drawTool2.DayView = this.daySchedule;
            this.daySchedule.ActiveTool = drawTool2;
            this.daySchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daySchedule.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.daySchedule.Location = new System.Drawing.Point(0, 0);
            this.daySchedule.Name = "daySchedule";
            this.daySchedule.SelectionEnd = new System.DateTime(((long)(0)));
            this.daySchedule.SelectionStart = new System.DateTime(((long)(0)));
            this.daySchedule.Size = new System.Drawing.Size(838, 401);
            this.daySchedule.StartDate = new System.DateTime(((long)(0)));
            this.daySchedule.StartHour = 9;
            this.daySchedule.TabIndex = 0;
            this.daySchedule.Text = "dayView1";
            this.daySchedule.WorkingHourEnd = 5;
            this.daySchedule.WorkingHourStart = 9;
            this.daySchedule.SelectionChanged += new System.EventHandler(this.daySchedule_SelectionChanged);
            this.daySchedule.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.daySchedule_ResolveAppointments);
            this.daySchedule.NewAppointment += new Calendar.NewAppointmentEventHandler(this.daySchedule_NewAppointment);
            this.daySchedule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.daySchedule_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teacher Name";
            // 
            // cbTeacherName
            // 
            this.cbTeacherName.FormattingEnabled = true;
            this.cbTeacherName.Location = new System.Drawing.Point(140, 70);
            this.cbTeacherName.Name = "cbTeacherName";
            this.cbTeacherName.Size = new System.Drawing.Size(290, 21);
            this.cbTeacherName.TabIndex = 1;
            this.cbTeacherName.SelectedIndexChanged += new System.EventHandler(this.cbTeacherName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Academic Year";
            // 
            // cbAcYear
            // 
            this.cbAcYear.FormattingEnabled = true;
            this.cbAcYear.Location = new System.Drawing.Point(140, 43);
            this.cbAcYear.Name = "cbAcYear";
            this.cbAcYear.Size = new System.Drawing.Size(121, 21);
            this.cbAcYear.TabIndex = 3;
            this.cbAcYear.SelectedIndexChanged += new System.EventHandler(this.cbAcYear_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAcYear);
            this.groupBox1.Controls.Add(this.cbTeacherName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(168, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View/Edit Schedule";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(568, 10);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(179, 122);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(134, 23);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View Day Schedule";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.daySchedule);
            this.panel1.Location = new System.Drawing.Point(137, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 401);
            this.panel1.TabIndex = 5;
            // 
            // ViewTeacherSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 742);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewTeacherSchedule";
            this.Text = "ViewTeacherSchedule";
            this.Load += new System.EventHandler(this.ViewTeacherSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTeacherName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAcYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel panel1;
        private Calendar.DayView daySchedule;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}