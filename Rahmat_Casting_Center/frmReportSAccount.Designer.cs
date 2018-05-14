namespace Rahmat_Casting_Center
{
    partial class frmReportSAccount
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportSAccount));
            this.accountdetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rahmat_casting_centerDataSet = new Rahmat_Casting_Center.rahmat_casting_centerDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.accountdetailsTableAdapter = new Rahmat_Casting_Center.rahmat_casting_centerDataSetTableAdapters.accountdetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.accountdetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rahmat_casting_centerDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // accountdetailsBindingSource
            // 
            this.accountdetailsBindingSource.DataMember = "accountdetails";
            this.accountdetailsBindingSource.DataSource = this.rahmat_casting_centerDataSet;
            // 
            // rahmat_casting_centerDataSet
            // 
            this.rahmat_casting_centerDataSet.DataSetName = "rahmat_casting_centerDataSet";
            this.rahmat_casting_centerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.accountdetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rahmat_Casting_Center.rptSimpleAccount.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(592, 413);
            this.reportViewer1.TabIndex = 0;
            // 
            // accountdetailsTableAdapter
            // 
            this.accountdetailsTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportSAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 413);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportSAccount";
            this.Text = "Single Account Transactions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportSAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountdetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rahmat_casting_centerDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource accountdetailsBindingSource;
        private rahmat_casting_centerDataSet rahmat_casting_centerDataSet;
        private rahmat_casting_centerDataSetTableAdapters.accountdetailsTableAdapter accountdetailsTableAdapter;
    }
}