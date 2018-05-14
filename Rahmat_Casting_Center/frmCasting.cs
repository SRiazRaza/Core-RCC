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
    public partial class frmCasting : Form
    {
        decimal d;
        String ds = "";
        double sum = 0;
        bool dec_spe = false;
        public frmCasting()
        {
            InitializeComponent();
            
        }
        void sumAccDet()
        {

            try
            {
                SQLConn.sqL = "select *  FROM accountdetails where DateIN='" + dtpStartDate.Value.ToString("MM-dd-yyyy") + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                while (SQLConn.dr.Read() == true)
                {
                    sum =sum+ Convert.ToDouble(SQLConn.dr["Casting"]);
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
        }   // Sum all Simple Account Castings
        void sumCashAcc()
        {

            try
            {
                SQLConn.sqL = "select *  FROM caccountdetails where DateIN='" + dtpStartDate.Value.ToString("MM-dd-yyyy") + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                while(SQLConn.dr.Read() == true)
                {
                    sum = sum + Convert.ToDouble(SQLConn.dr["Casting"]);
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
        } //Then Sum all Cash Account Castings

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCasting_Load(object sender, EventArgs e)
        {
           check_decimal_func();
            load_casting();

        }
        void load_casting() {

            call_balance();
            sumAccDet();
            sumCashAcc();
            if (dec_spe == true)
            {
                textBox3.Text = Strings.Format(sum, "#,###0.000");
            }
            else
            {
                ds = Strings.Format(sum, "#,###0.000");
                d = Convert.ToDecimal(ds);
                d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                textBox3.Text = d.ToString() + "0";
            }
        }
        void call_balance()
        {
            try
            {
                SQLConn.sqL = "SELECT Balance FROM casting";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                while (SQLConn.dr.Read() == true)
                {
                    if (dec_spe == true)
                    {
                        textBox1.Text = Strings.Format(SQLConn.dr["Balance"], "#,###0.000");

                    }
                    else
                    {
                        ds = Strings.Format(SQLConn.dr["Balance"], "#,###0.000");
                        d = Convert.ToDecimal(ds);
                        d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                        textBox1.Text = d.ToString() + "0";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
      
            if (dec_spe == true)
            {
                textBox4.Text = Strings.Format((Conversion.Val(textBox1.Text) + Conversion.Val(textBox2.Text)) - Conversion.Val(textBox3.Text), "#,###0.000");

            }
            else
            {
                ds = Strings.Format((Conversion.Val(textBox1.Text) + Conversion.Val(textBox2.Text)) - Conversion.Val(textBox3.Text), "#,###0.000");
                d = Convert.ToDecimal(ds);
                d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58
                textBox4.Text = d.ToString() + "0";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            insert_casting();
            Interaction.MsgBox("Casting Record Successfully added.", MsgBoxStyle.Information, "Casting Record");
            clear_r();
        }
       void clear_r()
        {
            textBox1.Text = "0.000";
            textBox2.Text = "0.000";
            textBox3.Text = "0.000";
            textBox4.Text = "0.000";

        }

        public void insert_casting()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO casting(DateIN,CurrentCasting,CastingCame,SaleCasting,Balance) VALUES('" + dtpStartDate.Value.ToString("MM-dd-yyyy") + "','" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            sum = 0;
            clear_r();
            load_casting();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = Strings.Format(Conversion.Val(textBox1.Text.Replace(",", "") ), "#,###0.000");

        }
    }
}
