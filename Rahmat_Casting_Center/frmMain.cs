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

namespace Rahmat_Casting_Center
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SQLConn.getData();
            load_chart();

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            SQLConn.getData();
            this.Focus();

        }
        void load_chart()
        {

            try
            {
                SQLConn.sqL = "SELECT  * FROM accounts";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                while (SQLConn.dr.Read() == true)
                {

                        this.chart1.Series["Money Debt"].Points.AddXY(SQLConn.dr["AccountID"].ToString(), SQLConn.dr["Money_Debt"].ToString());          
                
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());


            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo, "Exit System") == MsgBoxResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAccount abc = new frmAccount();
            abc.ShowDialog();
            this.chart1.Series["Money Debt"].Points.Clear();
            load_chart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmBill abc = new frmBill();
            abc.ShowDialog();
            this.chart1.Series["Money Debt"].Points.Clear();
            load_chart();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmFilterTransactions abc = new frmFilterTransactions();
            abc.ShowDialog();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                frmDataBaseConf abc = new frmDataBaseConf();
                abc.ShowDialog();
            }
        }



        private void timer1_Tick(object sender, EventArgs e) 
        {
            lblDateTime.Text = "Date_Time : " + DateTime.Now.ToString("dd MMMM, yyyy hh:mm:ss tt");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmSetting abc = new frmSetting();
            abc.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmC_Account abc = new frmC_Account();
            abc.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCasting abc = new frmCasting();
            abc.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmAbout abc = new frmAbout();
            abc.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
