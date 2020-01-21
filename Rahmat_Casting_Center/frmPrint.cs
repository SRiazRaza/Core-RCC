using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Globalization;
namespace Rahmat_Casting_Center
{
    public partial class frmPrint : Form
    {
        String acc = "";
        String ser = "";
        String ans = "";
        bool printing;
        public frmPrint(String a, String s,String an)
        {
            InitializeComponent();
            acc = a;
            ser = s;
            ans = an;
          
        }
       public void LoadSimple()
        {
            try
            {
                SQLConn.sqL = "SELECT TDetailNo,CONCAT(Firstname, ' ', Lastname)as Name,acc.AccountID,adacc.AccountID,SerialNo,adacc.DateIN,TimeIN,Rati,adacc.Labour,L_Money_In_Debt,Total_Money,CurrentGivenMoney,Total_Money_In_Debt,Casting,adacc.Waist,Total_Casting,Impurity,PureGold,AdvanceGivenGold,Subtotal_Gold,L_Gold_In_Debt,Total_Gold,CurrentGivenGold,Total_Gold_In_Debt FROM accountdetails AS adacc,accounts AS acc WHERE acc.AccountID = adacc.AccountID AND adacc.AccountID='" + acc +"'AND SerialNo='"+ser +"'   ";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblName.Text = SQLConn.dr["Name"].ToString();
                    lblName1.Text = SQLConn.dr["Name"].ToString();

                    lblAcc.Text = SQLConn.dr["AccountID"].ToString();
                    lblAcc1.Text = SQLConn.dr["AccountID"].ToString();

                    lblSerial.Text = SQLConn.dr["SerialNo"].ToString();
                    lblSerial1.Text = SQLConn.dr["SerialNo"].ToString();

                    string chang = SQLConn.dr["DateIN"].ToString();
                    DateTime dt = DateTime.ParseExact(chang, "MM-dd-yyyy", CultureInfo.InvariantCulture);
  
                    lblDate.Text = dt.ToString("dd-MMM-yyyy");
                    lblDate1.Text = dt.ToString("dd-MMM-yyyy");
                    

                   
                    lblTime.Text = SQLConn.dr["TimeIN"].ToString();
                    lblTime1.Text = SQLConn.dr["TimeIN"].ToString();

                    lblRati.Text = SQLConn.dr["Rati"].ToString();
                    lblRati1.Text = SQLConn.dr["Rati"].ToString();

                    lblLabour.Text = SQLConn.dr["Labour"].ToString();
                    lblLabour1.Text = SQLConn.dr["Labour"].ToString();

                    lblMDebt.Text = SQLConn.dr["L_Money_In_Debt"].ToString();
                    lblMDebt1.Text = SQLConn.dr["L_Money_In_Debt"].ToString();

                    lblSubTM.Text = SQLConn.dr["Total_Money"].ToString();

                    lblCM.Text = SQLConn.dr["CurrentGivenMoney"].ToString();
                    lblCM1.Text = SQLConn.dr["CurrentGivenMoney"].ToString();

                    lblTMD.Text = SQLConn.dr["Total_Money_In_Debt"].ToString();
                    lblTMD1.Text = SQLConn.dr["Total_Money_In_Debt"].ToString();

                    lblCasting.Text = String.Format(SQLConn.dr["Casting"].ToString(), "#,###0.000");
                    lblCasting1.Text = String.Format(SQLConn.dr["Casting"].ToString(), "#,###0.000");

                    lblWaist.Text = String.Format(SQLConn.dr["Waist"].ToString(), "#,###0.000");
                    lblTWaist.Text = String.Format(SQLConn.dr["Total_Casting"].ToString(), "#,###0.000");
                    lblImpurity.Text = String.Format(SQLConn.dr["Impurity"].ToString(), "#,###0.000");
                    lblPGold.Text = String.Format(SQLConn.dr["PureGold"].ToString(), "#,###0.000");

                    lblAdvG.Text = String.Format(SQLConn.dr["AdvanceGivenGold"].ToString(), "#,###0.000");
                    lblAdvG1.Text = String.Format(SQLConn.dr["AdvanceGivenGold"].ToString(), "#,###0.000");

                    lblRGold.Text = String.Format(SQLConn.dr["Subtotal_Gold"].ToString(), "#,###0.000");

                    lblGD.Text = String.Format(SQLConn.dr["L_Gold_In_Debt"].ToString(), "#,###0.000");
                    lblGD1.Text = String.Format(SQLConn.dr["L_Gold_In_Debt"].ToString(), "#,###0.000");

                    lblTG.Text = String.Format(SQLConn.dr["Total_Gold"].ToString(), "#,###0.000");

                    lblCGG.Text = String.Format(SQLConn.dr["CurrentGivenGold"].ToString(), "#,###0.000");
                    lblCGG1.Text = String.Format(SQLConn.dr["CurrentGivenGold"].ToString(), "#,###0.000");
                 
                    lblTGD.Text = String.Format(SQLConn.dr["Total_Gold_In_Debt"].ToString(), "#,###0.000");
                    lblTGD1.Text = String.Format(SQLConn.dr["Total_Gold_In_Debt"].ToString(), "#,###0.000");

                    lblRate.Text = "";
                    lblPrice.Text = "";

                    printing = true;

                    }
                else
                {
                    MessageBox.Show("Not Found.");
                    printing = false;
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }

            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        public void LoadCash()
        {
            try
            {
                SQLConn.sqL = "SELECT TDetailNo,Name,AccountID,SerialNo,DateIN,TimeIN,GoldRate,GoldPrice,Rati,Labour,L_Money_In_Debt,Total_Money,CurrentGivenMoney,Total_Money_In_Debt,Casting,Waist,Total_Casting,Impurity,PureGold,AdvanceGivenGold,Subtotal_Gold,L_Gold_In_Debt,Total_Gold,CurrentGivenGold,Total_Gold_In_Debt from caccountdetails WHERE AccountID='" + acc + "'AND SerialNo='" + ser + "'  ";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblName.Text = SQLConn.dr["Name"].ToString();
                    lblName1.Text = SQLConn.dr["Name"].ToString();

                    lblAcc.Text = SQLConn.dr["AccountID"].ToString();
                    lblAcc1.Text = SQLConn.dr["AccountID"].ToString();

                    lblSerial.Text = SQLConn.dr["SerialNo"].ToString();
                    lblSerial1.Text = SQLConn.dr["SerialNo"].ToString();

                    string chang = SQLConn.dr["DateIN"].ToString();
                    DateTime dt = DateTime.ParseExact(chang, "MM-dd-yyyy", CultureInfo.InvariantCulture);

                    lblDate.Text = dt.ToString("dd-MMM-yyyy");
                    lblDate1.Text = dt.ToString("dd-MMM-yyyy");

                    lblTime.Text = SQLConn.dr["TimeIN"].ToString();
                    lblTime1.Text = SQLConn.dr["TimeIN"].ToString();

                    lblRate.Text = SQLConn.dr["GoldRate"].ToString();
                    lblPrice.Text = SQLConn.dr["GoldPrice"].ToString();

                    lblRati.Text = SQLConn.dr["Rati"].ToString();
                    lblRati1.Text = SQLConn.dr["Rati"].ToString();

                    lblLabour.Text = SQLConn.dr["Labour"].ToString();
                    lblLabour1.Text = SQLConn.dr["Labour"].ToString();

                    lblMDebt.Text = SQLConn.dr["L_Money_In_Debt"].ToString();
                    lblMDebt1.Text = SQLConn.dr["L_Money_In_Debt"].ToString();

                    lblSubTM.Text = SQLConn.dr["Total_Money"].ToString();

                    lblCM.Text = SQLConn.dr["CurrentGivenMoney"].ToString();
                    lblCM1.Text = SQLConn.dr["CurrentGivenMoney"].ToString();

                    lblTMD.Text = SQLConn.dr["Total_Money_In_Debt"].ToString();
                    lblTMD1.Text = SQLConn.dr["Total_Money_In_Debt"].ToString();

                    lblCasting.Text = String.Format(SQLConn.dr["Casting"].ToString(), "#,###0.000");
                    lblCasting1.Text = String.Format(SQLConn.dr["Casting"].ToString(), "#,###0.000");

                    lblWaist.Text = String.Format(SQLConn.dr["Waist"].ToString(), "#,###0.000");
                    lblTWaist.Text = String.Format(SQLConn.dr["Total_Casting"].ToString(), "#,###0.000");
                    lblImpurity.Text = String.Format(SQLConn.dr["Impurity"].ToString(), "#,###0.000");
                    lblPGold.Text = String.Format(SQLConn.dr["PureGold"].ToString(), "#,###0.000");

                    lblAdvG.Text = String.Format(SQLConn.dr["AdvanceGivenGold"].ToString(), "#,###0.000");
                    lblAdvG1.Text = String.Format(SQLConn.dr["AdvanceGivenGold"].ToString(), "#,###0.000");

                    lblRGold.Text = String.Format(SQLConn.dr["Subtotal_Gold"].ToString(), "#,###0.000");

                    lblGD.Text = String.Format(SQLConn.dr["L_Gold_In_Debt"].ToString(), "#,###0.000");
                    lblGD1.Text = String.Format(SQLConn.dr["L_Gold_In_Debt"].ToString(), "#,###0.000");

                    lblTG.Text = String.Format(SQLConn.dr["Total_Gold"].ToString(), "#,###0.000");

                    lblCGG.Text = String.Format(SQLConn.dr["CurrentGivenGold"].ToString(), "#,###0.000");
                    lblCGG1.Text = String.Format(SQLConn.dr["CurrentGivenGold"].ToString(), "#,###0.000");

                    lblTGD.Text = String.Format(SQLConn.dr["Total_Gold_In_Debt"].ToString(), "#,###0.000");
                    lblTGD1.Text = String.Format(SQLConn.dr["Total_Gold_In_Debt"].ToString(), "#,###0.000");

                    type.Text = "Cash";
                    printing = true;

                }
                else
                {
                    MessageBox.Show("Not Found.");
                    printing = false;
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }

            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            ChangeFont();
            printing = false;

            label25.Text = "";
            if (ans == "Single")
            {
                LoadSimple();
            }
            else if (ans == "Cash")
            {
                LoadCash();
            }

            if (printing == true)
            {
                GetMessage();
                PrintDocument1.Print();
            }
            if (System.Windows.Forms.Application.OpenForms["frmBill"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmBill"] as frmBill).SetFocusonExit();
            }
            this.Close();
        
        }
        private void ChangeFont() {

           /* foreach (Label la in Controls)
            {

                la.Font = new Font("Georgia", 12);
            }*/
        }
        public void GetMessage()
        {
            try
            {
                SQLConn.sqL = "SELECT msg FROM setting";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();


                if (SQLConn.dr.Read())
                {
                    label25.Text = SQLConn.dr[0].ToString();
                }
                else {
                    label25.Text = "";
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.Panel1.Width, this.Panel1.Height);
            Panel1.DrawToBitmap(bm, new Rectangle(0, 0, this.Panel1.Width, this.Panel1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

            PageSetupDialog aPS = new PageSetupDialog();
            aPS.Document = PrintDocument1;
        }


      
    }
}
