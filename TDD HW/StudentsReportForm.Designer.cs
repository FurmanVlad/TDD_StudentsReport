namespace TDD_HW
{
    partial class StudentsReportForm
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
            this.StudentReport = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // StudentReport
            // 
            this.StudentReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentReport.ItemHeight = 25;
            this.StudentReport.Location = new System.Drawing.Point(0, 0);
            this.StudentReport.Name = "StudentReport";
            this.StudentReport.Size = new System.Drawing.Size(800, 450);
            this.StudentReport.TabIndex = 0;
            // 
            // StudentsReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StudentReport);
            this.Name = "StudentsReportForm";
            this.ShowIcon = false;
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox StudentReport;
    }
}