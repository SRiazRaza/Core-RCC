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
using System.IO;
using WinFormCharpWebCam;
using System.Media;

namespace Rahmat_Casting_Center
{
    public partial class frmBill : Form
    {
        bool dec_spe = false;
        decimal d;
        String ds = "";
        String waist = "";
        int labour = 0;
        public frmBill()
        {

            InitializeComponent();

        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void close_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trans_b_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0.000";
            textBox11.Text = "0.000";
            textBox12.Text = "0.000";
            textBox13.Text = "0.000";
            textBox14.Text = "0.000";
            textBox15.Text = "0.000";
            textBox16.Text = "0.000";
            textBox17.Text = "0.000";
            textBox20.Text = "0.000";
            textBox21.Text = "0.000";
            textBox22.Text = "0.000";
            textBox23.Text = "";
            label22.Text = "";
            textBox1.Focus();


        }

        void clear_accounts()
        {
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0.000";
            textBox11.Text = "0.000";
            textBox12.Text = "0.000";
            textBox13.Text = "0.000";
            textBox14.Text = "0.000";
            textBox15.Text = "0.000";
            textBox16.Text = "0.000";
            textBox17.Text = "0.000";

            textBox20.Text = "0.000";
            textBox21.Text = "0.000";
            textBox22.Text = "0.000";

            label22.Text = "";
            if (checkBox1.Checked == true) //
            {
                textBox23.Text = "";

            }

        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("dd MMMM, yyyy");

            SQLConn.getData();
            //for cash Acc name
            textBox23.ReadOnly = true;
            //for Cash
            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;


            check_decimal_func();
            if (dec_spe == true) {
                button4.Text = "3";
            }
            else
            {
                button4.Text = "2";
            }
            //      textBox1.Focus();

        }


        private void checkSerial()
        {
            try
            {
                SQLConn.sqL = "SELECT SerialNo FROM accountdetails where AccountID='" + textBox1.Text + "' ORDER BY SerialNo DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    label22.Text = (Convert.ToInt32(SQLConn.dr["SerialNo"]) + 1).ToString();
                }
                else
                {
                    label22.Text = "1";
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
        private void checkSerialCash()
        {
            try
            {
                SQLConn.sqL = "SELECT SerialNo FROM caccountdetails where AccountID='" + textBox1.Text + "' ORDER BY SerialNo DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    label22.Text = (Convert.ToInt32(SQLConn.dr["SerialNo"]) + 1).ToString();
                }
                else
                {
                    label22.Text = "1";
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



        void loadAccount(String accountID)
        {

            try
            {
                SQLConn.sqL = "select *  FROM accounts where AccountID='" + accountID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();



                if (SQLConn.dr.Read() == true)
                {
                    //Without Decimal Money , Labour
                    labour = Convert.ToInt32(SQLConn.dr["Labour"]);
                    textBox6.Text = SQLConn.dr["Money_Debt"].ToString();

                    // With Decimals Gold , Waist
                    waist = Strings.Format(SQLConn.dr["Waist"], "#,###0.000");
                    if (dec_spe == true)
                    {
                        textBox10.Text = Strings.Format(SQLConn.dr["Gold_Debt"], "#,###0.000");
                    }
                    else
                    {
                        ds = Strings.Format(SQLConn.dr["Gold_Debt"], "#,###0.000");
                        d = Convert.ToDecimal(ds);
                        d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                        textBox10.Text = d.ToString() + "0";
                    }
                    String f_name = SQLConn.dr["Firstname"].ToString();
                    String l_name = SQLConn.dr["Lastname"].ToString();
                    String full_name = f_name + " " + l_name;
                    textBox23.Text = full_name;
                    textBox7.Text = Strings.Format(Conversion.Val(textBox5.Text) + Conversion.Val(textBox6.Text));
                    checkSerial();
                    textBox3.Focus();

                }
                else {
                    SystemSounds.Beep.Play();
                    textBox1.Focus();

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }



        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox9.Text = Strings.Format(Conversion.Val(textBox7.Text) - Conversion.Val(textBox8.Text));
            }
            catch (Exception ex)
            {
                string bbb = ex.ToString();
            }

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (dec_spe == true)
            {

                try
                {
                    textBox16.Text = Strings.Format(Convert.ToDouble(waist) * Convert.ToDouble(textBox17.Text), "#,###0.000");

                    textBox15.Text = Strings.Format(Convert.ToDouble(textBox16.Text) + Convert.ToDouble(textBox17.Text), "#,###0.000");

                    // textBox11.Text = Strings.Format(Conversion.Val(textBox13.Text) - Conversion.Val(textBox12.Text), "#,###0.000");


                    int minim = 96;
                    minim = minim - Convert.ToInt16(textBox3.Text);
                    double a = Convert.ToDouble(minim) * Convert.ToDouble(textBox15.Text);
                    a = a / 96;
                    textBox13.Text = Strings.Format(Convert.ToDouble(a), "#,###0.000");

                    textBox14.Text = Strings.Format(Convert.ToDouble(textBox15.Text) - Convert.ToDouble(textBox13.Text), "#,###0.000");

                }
                catch (Exception ex) {
                    string bbb = ex.ToString();

                }


            }
            else {
                try
                {
                    //Waist
                    // Lines after changing 0.003
                    double chng = Convert.ToDouble(waist) * Convert.ToDouble(textBox17.Text);
                    chng = chng + 0.003; // Custom value changing

                    ds = Strings.Format(chng, "#,###0.000");
                    d = Convert.ToDecimal(ds);
                    d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                    textBox16.Text = d.ToString() + "0";

                    //Total
                    ds = Strings.Format(Convert.ToDouble(textBox16.Text) + Convert.ToDouble(textBox17.Text), "#,###0.000");
                    d = Convert.ToDecimal(ds);
                    d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                    textBox15.Text = d.ToString() + "0";

                    //Remaining Gold 1st CAll
                    /*    ds = Strings.Format(Conversion.Val(textBox13.Text) - Conversion.Val(textBox12.Text), "#,###0.000");  
                       d = Convert.ToDecimal(ds);
                       d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                       textBox11.Text = d.ToString() + "0";
                       */

                    //Pure Gold
                    // Changing value here 0.003
                    int minim = 96;
                    minim = minim - Convert.ToInt16(textBox3.Text);
                    double a = Convert.ToDouble(minim) * Convert.ToDouble(textBox15.Text);
                    a = a / 96;
                    a = a + 0.003; // Custom value changing

                    ds = Strings.Format(a, "#,###0.000");
                    d = Convert.ToDecimal(ds);
                    d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                    textBox13.Text = d.ToString() + "0";

                    //Impurity
                    ds = Strings.Format(Convert.ToDouble(textBox15.Text) - Convert.ToDouble(textBox13.Text), "#,###0.000");
                    d = Convert.ToDecimal(ds);
                    d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                    textBox14.Text = d.ToString() + "0";


                    textBox12.Text = "0.000";
                }
                catch (Exception ex)

                {
                    string bbb = ex.ToString();
                }

            }
        }




        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dec_spe == true)
                {
                    //Remaining Gold 2nd Call

                    textBox11.Text = Strings.Format(Convert.ToDouble(textBox13.Text) - Convert.ToDouble(textBox12.Text.Replace(",", "")), "#,###0.000");
                    textBox22.Text = Strings.Format(Convert.ToDouble(textBox10.Text) + Convert.ToDouble(textBox11.Text), "#,###0.000");
                }
                else
                {
                    //Remaining Gold 2nd Call
                    ds = Strings.Format(Convert.ToDouble(textBox13.Text) - Convert.ToDouble(textBox12.Text), "#,###0.000");
                    d = Convert.ToDecimal(ds);
                    d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                    textBox11.Text = d.ToString() + "0";

                    ds = Strings.Format(Convert.ToDouble(textBox10.Text) + Convert.ToDouble(textBox11.Text), "#,###0.000");
                    d = Convert.ToDecimal(ds);
                    d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                    textBox22.Text = d.ToString() + "0";
                }
            }
            catch (Exception ex)
            {
                string bbb = ex.ToString();
            }

        }


        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dec_spe == true)
                {
                    textBox20.Text = Strings.Format(Convert.ToDouble(textBox22.Text) - Convert.ToDouble(textBox21.Text), "#,###0.000");
                }
                else
                {
                    ds = Strings.Format(Convert.ToDouble(textBox22.Text) - Convert.ToDouble(textBox21.Text), "#,###0.000");
                    d = Convert.ToDecimal(ds);
                    d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                    textBox20.Text = d.ToString() + "0";
                }
            }
            catch (Exception ex)
            {
                string bbb = ex.ToString();
            }
        }

        private void settle_b_Click(object sender, EventArgs e)
        {
            if (label22.Text != "")
            {
                if (checkBox1.Checked == false) //
                {
                    insert_accountdetails(); //inserting bill info for each
                    insert_account();        // inserting account transactions personal

                    frmpicture_form picForm = new frmpicture_form(textBox1.Text, label22.Text, "Single");
                    picForm.ShowDialog();

                    frmPrint xyz = new frmPrint(textBox1.Text, label22.Text, "Single");
                    xyz.ShowDialog();
                }

                else
                {
                    insert_Caccounts();

                    frmpicture_form picForm = new frmpicture_form(textBox1.Text, label22.Text, "Cash");
                    picForm.ShowDialog();

                    frmPrint xyz = new frmPrint(textBox1.Text, label22.Text, "Cash");
                    xyz.ShowDialog();

                }
            }
            else {
                return;
            }


        }
        public void SetFocusonExit() {

            if (Interaction.MsgBox("Do you want to perform another transaction?", MsgBoxStyle.YesNo, "Transaction Successfully Completed.") == MsgBoxResult.Yes)
            {
                trans_b.PerformClick();
                textBox1.Focus();
            }
            else
            {
                this.Close();
            }

        }
        void insert_Caccounts() {
            try
            {
                SQLConn.sqL = "INSERT INTO caccountdetails(AccountID,SerialNo,Name,DateIN,TimeIN,GoldRate,GoldPrice,Rati,Labour,L_Money_In_Debt,Total_Money,CurrentGivenMoney,Total_Money_In_Debt,Casting,Waist,Total_Casting,Impurity,PureGold,AdvanceGivenGold,Subtotal_Gold,L_Gold_In_Debt,Total_Gold,CurrentGivenGold,Total_Gold_In_Debt) VALUES('" + textBox1.Text + "','" + label22.Text + "','" + textBox23.Text + "', '" + System.DateTime.Now.ToString("MM-dd-yyyy") + "', '" + System.DateTime.Now.ToString("hh:mm") + "' ,'" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','" + textBox11.Text + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox21.Text + "','" + textBox20.Text + "')";
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
        public void insert_accountdetails()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO accountdetails(AccountID,SerialNo,DateIN,TimeIN,Rati,Labour,L_Money_In_Debt,Total_Money,CurrentGivenMoney,Total_Money_In_Debt,Casting,Waist,Total_Casting,Impurity,PureGold,AdvanceGivenGold,Subtotal_Gold,L_Gold_In_Debt,Total_Gold,CurrentGivenGold,Total_Gold_In_Debt) VALUES('" + textBox1.Text + "','" + label22.Text + "', '" + System.DateTime.Now.ToString("MM-dd-yyyy") + "', '" + System.DateTime.Now.ToString("hh:mm") + "' ,'" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','" + textBox11.Text + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox21.Text + "','" + textBox20.Text + "')";
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
        public void insert_account()
        {
            try
            {
                SQLConn.sqL = "UPDATE accounts SET Gold_Debt='" + textBox20.Text + "',Money_Debt='" + textBox9.Text + "',DateIN='"+System.DateTime.Now.ToString("MM-dd-yyyy")+"' where AccountID='"+textBox1.Text+"'";
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



        private void button1_Click_1(object sender, EventArgs e)
        {
            

            if (textBox1.Text == "")
            {

            }
            else
            {
                if (checkBox1.Checked == false)            // For simple account
                {                       
                    loadAccount(textBox1.Text);
                }
                else if (checkBox1.Checked == true)        // For Cash account
                {
                    if (textBox23.Text != "" && textBox1.Text != "")
                    {
                        load_cashAccount();                      
                    }
                }

            }
        }
       void  load_gold()
        {
            try
            {
                SQLConn.sqL = "select *  FROM setting";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();



                if (SQLConn.dr.Read() == true)
                {
                    //Without Decimal Money , Labour
                    textBox2.Text = SQLConn.dr["Gold_Rate"].ToString();
                   
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }




        }

        void load_cashAccount() {
            try
            {
                SQLConn.sqL = "select *  FROM cash_account where AccountName='" + textBox1.Text + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();



                if (SQLConn.dr.Read() == true)
                {

                    labour = Convert.ToInt32(SQLConn.dr["Labour"]);
                     textBox3.Text= SQLConn.dr["Rati"].ToString();
                    waist = SQLConn.dr["Waist"].ToString();
                    load_gold();
                    checkSerialCash();
                    textBox17.Focus();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    textBox1.Focus();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }

          //  textBox7.Text = Strings.Format(Conversion.Val(textBox5.Text) + Conversion.Val(textBox6.Text)+Conversion.Val(textBox4.Text));


        }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) //Cash Account
            {
                textBox3.ReadOnly = true;

                textBox1.ReadOnly = false;
                textBox23.ReadOnly = false;
                textBox10.ReadOnly = false;
                textBox6.ReadOnly = false;
                

            }
            else if (checkBox1.Checked == false) //Simple Account
            {
                textBox1.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox23.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox6.ReadOnly = true;


            }
        }

        private void frmBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                trans_b.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                remove_b.PerformClick();
            }
            else if (e.KeyCode == Keys.F12)
            {
                settle_b.PerformClick();
            }
            else if (e.KeyCode == Keys.F4)
            {
                
                    if (checkBox1.Checked == false)
                    {
                        checkBox1.Checked = true;
                    }
                    else if (checkBox1.Checked == true)
                    {
                        checkBox1.Checked = false;
                    }
                
            }
            else if (e.KeyCode == Keys.F3)
            {
                button2.PerformClick();
            }
            else if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;   // Stop beep on ENter pressing


                    if (checkBox1.Checked == false) //
                    {
                        
                        button1.PerformClick();

                    }
                    else
                    {
                        textBox23.Focus();
                    }
                }
            }
            else {

            }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();

            }
          
        }
        
        void check_decimal_func() {
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
                    else {
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try {
                int a = Convert.ToInt32(textBox2.Text);

                double b = Convert.ToDouble(textBox22.Text);
                var abc = a * b;
                int xyz = Convert.ToInt32(abc);
                textBox4.Text = xyz.ToString();
            }
            catch (Exception ex)
            {
                string bbb = ex.ToString();
            }

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            clear_accounts();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //e.Handled = true;                // Same
                e.SuppressKeyPress = true;         // Stop beep in Enter
                textBox17.Focus();
              
                
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                textBox12.Focus();

            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                textBox21.Focus();

            }
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                textBox17.Focus();

            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                textBox5.Focus();

            }
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                textBox12.Focus();
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            double a = labour * Convert.ToDouble(textBox15.Text);
            int b = Convert.ToInt32(a);
            textBox5.Text = b.ToString();

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            trans_b.PerformClick();
        }

       
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = Strings.Format(Conversion.Val(textBox5.Text) + Conversion.Val(textBox6.Text) + Conversion.Val(textBox4.Text));
                textBox8.Text = "0";
            }
            catch (Exception ex) {
                string bbb = ex.ToString();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                textBox8.Focus();
            }
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                textBox21.Focus();
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(textBox2.Text);

                double b = Convert.ToDouble(textBox20.Text);
                var abc = a * b;
                int xyz = Convert.ToInt32(abc);
                textBox4.Text = xyz.ToString();

                textBox7.Text = Strings.Format(Conversion.Val(textBox5.Text) + Conversion.Val(textBox6.Text) + Conversion.Val(textBox4.Text));
                textBox8.Text = "0";
            }
            catch (Exception ex)
            {
                string bbb = ex.ToString();
            }


        }

        private void panel7_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
            }
            else if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void remove_b_Click(object sender, EventArgs e)
        {
            clear_accounts();
            clear_accounts();
            textBox1.Focus();
        }

        private void textBox17_Enter(object sender, EventArgs e)
        {
            la1.Text = "*";
        
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            la1.Text = "";

        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            la2.Text = "*";
            textBox12.Text = " ";

        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            la2.Text = "";

        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            la3.Text = "*";
            textBox21.Text = "";

        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            la3.Text = "";

        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            la4.Text = "*";

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            la4.Text = "";

        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            la5.Text = "*";

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            la5.Text = "";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmRePrint abc = new frmRePrint();
            abc.ShowDialog();
        }
    }
}
