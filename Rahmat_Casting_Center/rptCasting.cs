using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace Rahmat_Casting_Center
{
    public partial class rptCasting : Form
    {
        DateTime StartDate;
        DateTime EndDate;

        public rptCasting(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            StartDate = startDate;
            EndDate = endDate;
        }

        private void rptCasting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rahmat_casting_centerDataSet.casting' table. You can move, or remove it, as needed.
            this.castingTableAdapter.Fill(this.rahmat_casting_centerDataSet.casting);

            this.reportViewer1.RefreshReport();
            LoadReport();
        }
        private void LoadReport()
        {
            try
            {

                SQLConn.sqL = "SELECT * from casting where DATE_FORMAT(STR_TO_DATE(DateIN, '%m-%d-%Y'), '%Y-%m-%d') BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "'  ORDER BY DateIN";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new MySqlDataAdapter(SQLConn.cmd);

                this.rahmat_casting_centerDataSet.debtin.Clear();
                SQLConn.da.Fill(this.rahmat_casting_centerDataSet.debtin);


                ReportParameter startDate = new ReportParameter("StartDate", StartDate.ToString());
                ReportParameter endDate = new ReportParameter("EndDate", EndDate.ToString());
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { startDate, endDate });

                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
    }
}
