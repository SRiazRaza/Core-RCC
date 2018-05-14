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

namespace Rahmat_Casting_Center
{
    public partial class frmPrint : Form
    {
        String acc = "";
        String ser = "";
        String ans = "";

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
                SQLConn.sqL = "SELECT TDetailNo,CONCAT(Firstname, ' ', Lastname)as Name,adacc.AccountID,SerialNo,adacc.DateIN,TimeIN,Rati,adacc.Labour,L_Money_In_Debt,Total_Money,CurrentGivenMoney,Total_Money_In_Debt,Casting,adacc.Waist,Total_Casting,Impurity,PureGold,AdvanceGivenGold,Subtotal_Gold,L_Gold_In_Debt,Total_Gold,CurrentGivenGold,Total_Gold_In_Debt FROM accountdetails AS adacc,accounts AS acc WHERE adacc.AccountID='"+ acc +"'AND SerialNo='"+ser +"'   ";
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

                     
                    lblDate.Text = SQLConn.dr["DateIN"].ToString();

                    lblDate1.Text = SQLConn.dr["DateIN"].ToString();


                    DateTime xyz = Convert.ToDateTime(SQLConn.dr["TimeIN"]);
                    
                    lblTime.Text = xyz.ToString("hh:mm");
                    lblTime1.Text = xyz.ToString("hh:mm");

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
                    }
                else
                {
                    MessageBox.Show("Error.");
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

                    lblDate.Text = SQLConn.dr["DateIN"].ToString();
                    lblDate1.Text = SQLConn.dr["DateIN"].ToString();

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

                }
                else
                {
                    MessageBox.Show("Error.");
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
            label25.Text = "";
            if (ans == "Single")
            {
                LoadSimple();
            }
            else if (ans == "Cash")
            {
                LoadCash();
            }
            GetMessage();
            PrintDocument1.Print();
            this.Close();
        
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
