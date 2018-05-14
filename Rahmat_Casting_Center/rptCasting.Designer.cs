namespace Rahmat_Casting_Center
{
    partial class rptCasting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptCasting));
            this.castingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rahmat_casting_centerDataSet = new Rahmat_Casting_Center.rahmat_casting_centerDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.castingTableAdapter = new Rahmat_Casting_Center.rahmat_casting_centerDataSetTableAdapters.castingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.castingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rahmat_casting_centerDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // castingBindingSource
            // 
            this.castingBindingSource.DataMember = "casting";
            this.castingBindingSource.DataSource = this.rahmat_casting_centerDataSet;
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
            reportDataSource1.Value = this.castingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rahmat_Casting_Center.rptCasting.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(498, 421);
            this.reportViewer1.TabIndex = 0;
            // 
            // castingTableAdapter
            // 
            this.castingTableAdapter.ClearBeforeFill = true;
            // 
            // rptCasting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 421);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rptCasting";
            this.Text = "Casting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptCasting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.castingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rahmat_casting_centerDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource castingBindingSource;
        private rahmat_casting_centerDataSet rahmat_casting_centerDataSet;
        private rahmat_casting_centerDataSetTableAdapters.castingTableAdapter castingTableAdapter;
    }
}