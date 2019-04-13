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
using Microsoft.VisualBasic;

namespace Rahmat_Casting_Center
{
    public partial class frmDebtIn : Form
    {
        int accountID;
        bool dec_spe = false;
        public frmDebtIn(int abc)
        {
            InitializeComponent();
            accountID = abc;
        }
        private void GetDebtInfo()
        {

            try
            {

                SQLConn.sqL = "SELECT CONCAT(Firstname,' ',Lastname) as name,Gold_Debt,Money_Debt FROM ACCOUNTS WHERE AccountID =" + accountID + "";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblName.Text = SQLConn.dr[0].ToString();
                    if (dec_spe == true)
                    {
                        lblGold.Text = Strings.Format(SQLConn.dr[1], "#,###0.000");
                    }
                    else {
                        String ds = "";
                        decimal d = 0;
                        ds = Strings.Format(Strings.Format(SQLConn.dr[1], "#,###0.000"));
                        d = Convert.ToDecimal(ds);
                        d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                        lblGold.Text = d.ToString() + "0";
                    }
                    lblMoney.Text = SQLConn.dr[2].ToString();

                    txtGold_Debt.Text = "0.000";

                    txtMoney_Debt.Text = "0";
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

        private void AddDebtIn()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO DebtIN(AccountID,Name,LastGoldDebt,LastMoneyDebt,NewGoldDebt,NewMoneyDebt,GivenGold,GivenMoney,DateIn,TimeIN) Values('" + accountID + "', '" + lblName.Text + "', '" + lblGold.Text + "', '" + lblMoney.Text + "', '" + txtTotalGoldDebt.Text + "', '" + txtTotalMoneyDebt.Text + "','" + txtGold_Debt.Text + "','" + txtMoney_Debt.Text + "', '" + System.DateTime.Now.ToString("MM-dd-yyyy") + "','" + System.DateTime.Now.ToString("hh:mm:ss") + "')";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();

                UpdateAccountDebt();
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
        private void UpdateAccountDebt()
        {
            try
            {
                SQLConn.sqL = "UPDATE accounts SET DateIN='" + System.DateTime.Now.ToString("MM-dd-yyyy") + "',Gold_Debt =  '" + txtTotalGoldDebt.Text + "',Money_Debt =  '" + txtTotalMoneyDebt.Text + "' WHERE AccountID = '" + accountID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
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



        private void frmDebtIn_Load(object sender, EventArgs e)
        {
            check_decimal_func();
            txtGold_Debt.Text = "";
            txtTotalGoldDebt.Text = "";
            txtMoney_Debt.Text = "";
            txtTotalMoneyDebt.Text = "";
            GetDebtInfo();
           
                }
        void check_decimal_func()
        {
            try
            {
                SQLConn.sqL = "SELECT digit FROM setting";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();


                if (SQLConn.dr.Read())
                {


                    if (SQLConn.dr["digit"].ToString() == "true")
                    {
                        dec_spe = true;
                    }
                    else
                    {
                        dec_spe = false;
                    }

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
        private void txtGold_Debt_TextChanged(object sender, EventArgs e)
        {
            
            double abc = Conversion.Val(lblGold.Text) - Conversion.Val(txtGold_Debt.Text);

            if (dec_spe == true)
            {
                txtTotalGoldDebt.Text = Strings.Format(abc, "#,###0.000");
            }
            else
            {
                String ds = "";
                decimal d = 0;
                ds = Strings.Format(Strings.Format(abc, "#,###0.000"));
                d = Convert.ToDecimal(ds);
                d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                txtTotalGoldDebt.Text = d.ToString() + "0";
            }
           
        }

        private void txtMoney_Debt_TextChanged(object sender, EventArgs e)
        {
            txtTotalMoneyDebt.Text = Strings.Format(Conversion.Val(lblMoney.Text) - Conversion.Val(txtMoney_Debt.Text));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddDebtIn();
            if (System.Windows.Forms.Application.OpenForms["frmAccount"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmAccount"] as frmAccount).LoadStaffs("");
            }

            this.Close();
        }

     
    }
}
