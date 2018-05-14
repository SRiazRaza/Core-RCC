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
    public partial class frmAddEditAccount : Form
    {
        int LSAccountID;
         bool dec_spe = false;
        public frmAddEditAccount(int accountID)
           
        {
            InitializeComponent();
            LSAccountID=accountID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                AddStaff();
            }
            else
            {
                UpdateStaff();
            }

            if (System.Windows.Forms.Application.OpenForms["frmAccount"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmAccount"] as frmAccount).LoadStaffs("");
            }

            this.Close();
        }

        private void AddStaff()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO ACCOUNTS( Firstname,Lastname, Area, City, ContactNo,ShopNo, Waist, Labour, Gold_Debt,Money_Debt ) VALUES( '" + txtFirstname.Text + "','" + txtLastname.Text + "', '" + txtArea.Text + "', '" + txtCity.Text + "', '" + txtContractNo.Text + "', '" + txtShopNo.Text + "', '" + txt_waist.Text + "', '" + txt_labour.Text + "', '" + txt_gold.Text + "', '" + txt_money.Text + "')";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("New Account successfully added.", MsgBoxStyle.Information, "Add Account");
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

        private void UpdateStaff()
        {
            

            try
            {
                SQLConn.sqL = "Update ACCOUNTS SET  Firstname = '" + txtFirstname.Text + "',Lastname = '" + txtLastname.Text + "', Area = '" + txtArea.Text + "', City = '" + txtCity.Text + "', ContactNo = '" + txtContractNo.Text + "', ShopNo = '" + txtShopNo.Text + "', Waist ='" + txt_waist.Text + "', Labour = '" + txt_labour.Text + "', Gold_Debt = '" + txt_gold.Text + "', Money_Debt = '" + txt_money.Text + "' WHERE AccountID = '" + LSAccountID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("Account record successfully updated", MsgBoxStyle.Information, "Update Account");

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
        private void LoadUpdateStaff()
        {
            check_decimal_func();
            txt_gold.ReadOnly = true;
            txt_money.ReadOnly = true;

            try
            {
                SQLConn.sqL = "SELECT * FROM ACCOUNTS WHERE AccountID = '" + LSAccountID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblAccountNo.Text = SQLConn.dr["AccountID"].ToString();
                    txtFirstname.Text = SQLConn.dr["Firstname"].ToString();
                    txtLastname.Text = SQLConn.dr["lastname"].ToString();


                    
                    txtArea.Text = SQLConn.dr["Area"].ToString();
                    txtCity.Text = SQLConn.dr["City"].ToString();
                    txtShopNo.Text = SQLConn.dr["ShopNo"].ToString();
                    txtContractNo.Text = SQLConn.dr["ContactNo"].ToString();
                    if (dec_spe == true)
                    {
                        txt_gold.Text = Strings.Format(SQLConn.dr["Gold_Debt"], "#,###0.000");
                    }
                    else
                    {
                        String ds = "";
                        decimal d = 0;
                        ds = Strings.Format(Strings.Format(SQLConn.dr["Gold_Debt"], "#,###0.000"));
                        d = Convert.ToDecimal(ds);
                        d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                        txt_gold.Text = d.ToString() + "0";
                    }

                    txt_money.Text = SQLConn.dr["Money_Debt"].ToString();
                    txt_waist.Text = SQLConn.dr["Waist"].ToString();
                    txt_labour.Text = SQLConn.dr["Labour"].ToString();

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetStaffID()
        {
            try
            {
                SQLConn.sqL = "SELECT AccountID FROM ACCOUNTS ORDER BY AccountID DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblAccountNo.Text = (Convert.ToInt32(SQLConn.dr["AccountID"]) + 1).ToString();
                }
                else
                {
                    lblAccountNo.Text = "1";
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



        private void ClearFields()
        {
            lblAccountNo.Text = "";
            txtLastname.Text = "";
            txtFirstname.Text = "";

           
            txtArea.Text = "";
            txtCity.Text = "";
            txtShopNo.Text = "";
            txtContractNo.Text = "";
            txt_money.Text = "";
            txt_gold.Text = "";
            txt_labour.Text = "";
            txt_waist.Text = "";
        }


        private void frmAddEditAccount_Load(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                lblTitle.Text = "Adding New Account";
                ClearFields();
                GetStaffID();
            }
            else
            {
                lblTitle.Text = "Updating Account";
                LoadUpdateStaff();

            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
