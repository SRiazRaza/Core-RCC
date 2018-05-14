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
    public partial class frmReportSAccount : Form
    {
        DateTime StartDate;
        DateTime EndDate;
        String find ;
        public frmReportSAccount(DateTime startDate, DateTime endDate,String s)
        {
            InitializeComponent();
            StartDate = startDate;
            EndDate = endDate;
            find = s;
        }

        private void frmReportSAccount_Load(object sender, EventArgs e)
        {
          this.accountdetailsTableAdapter.Fill(this.rahmat_casting_centerDataSet.accountdetails);  
            LoadReport();
        }
        private void LoadReport()
        {
            try
            {
                if (find == "")
                {
                    SQLConn.sqL = "SELECT TDetailNo,CONCAT(Firstname, ' ', Lastname)as Name,ad.AccountID,SerialNo,ad.DateIN,TimeIN,Rati,ad.Labour,L_Money_In_Debt,Total_Money,CurrentGivenMoney,Total_Money_In_Debt,Casting,ad.Waist,Total_Casting,Impurity,PureGold,AdvanceGivenGold,Subtotal_Gold,L_Gold_In_Debt,Total_Gold,CurrentGivenGold,Total_Gold_In_Debt from accountdetails as ad,accounts as a where ad.AccountID=a.AccountID AND ad.DateIN BETWEEN '" + StartDate.ToString("MM-dd-yyyy") + "' AND '" + EndDate.ToString("MM-dd-yyyy") + "'   GROUP BY TDetailNo,ad.AccountID ORDER BY ad.DateIN";

                }
                else
                {
                    SQLConn.sqL = "SELECT TDetailNo,CONCAT(Firstname, ' ', Lastname)as Name,ad.AccountID,SerialNo,ad.DateIN,TimeIN,Rati,ad.Labour,L_Money_In_Debt,Total_Money,CurrentGivenMoney,Total_Money_In_Debt,Casting,ad.Waist,Total_Casting,Impurity,PureGold,AdvanceGivenGold,Subtotal_Gold,L_Gold_In_Debt,Total_Gold,CurrentGivenGold,Total_Gold_In_Debt from accountdetails as ad,accounts as a where ad.AccountID='" + find + "' AND ad.AccountID=a.AccountID AND ad.DateIN BETWEEN '" + StartDate.ToString("MM-dd-yyyy") + "' AND '" + EndDate.ToString("MM-dd-yyyy") + "'   GROUP BY TDetailNo,ad.AccountID ORDER BY ad.DateIN";
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
