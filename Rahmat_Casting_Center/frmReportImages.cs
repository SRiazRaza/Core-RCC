using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
namespace Rahmat_Casting_Center
{
    public partial class frmReportImages : Form
    {
       
        DateTime StartDate;
        DateTime EndDate;
        String find;
        public frmReportImages(DateTime startDate, DateTime endDate,String a)
        {
            InitializeComponent();
            StartDate = startDate;
            EndDate = endDate;
            find = a;
        }

        private void frmReportImages_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rahmat_casting_centerDataSet.accountdetails' table. You can move, or remove it, as needed.
            this.accountdetailsTableAdapter.Fill(this.rahmat_casting_centerDataSet.accountdetails);

            LoadReport();
        }
        private void LoadReport()
        {
            try
            {
                if (find == "")
                {
                    SQLConn.sqL = "SELECT TDetailNo, AccountID,SerialNo,DateIN,TimeIN,image,image1 from accountdetails where DATE_FORMAT(STR_TO_DATE(DateIN, '%m-%d-%Y'), '%Y-%m-%d') BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "'   GROUP BY TDetailNo,AccountID ORDER BY DateIN";
                }
                else {
                    SQLConn.sqL = "SELECT TDetailNo, AccountID,SerialNo,DateIN,TimeIN,image,image1 from accountdetails where AccountID='"+find+ "' AND DATE_FORMAT(STR_TO_DATE(DateIN, '%m-%d-%Y'), '%Y-%m-%d') BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + EndDate.ToString("yyyy-MM-dd") + "'   GROUP BY TDetailNo,AccountID ORDER BY DateIN";

                }
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new MySqlDataAdapter(SQLConn.cmd);

          
         
                this.rahmat_casting_centerDataSet.accountdetails.Clear();
               SQLConn.da.Fill(this.rahmat_casting_centerDataSet.accountdetails);

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
