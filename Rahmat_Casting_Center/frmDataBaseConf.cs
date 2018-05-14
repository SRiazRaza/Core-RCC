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
    public partial class frmDataBaseConf : Form
    {
        public frmDataBaseConf()
        {
            InitializeComponent();
        }
        private String TstServerMySQL;
        private String TstPortMySQL;
        private String TstUserNameMySQL;
        private String TstPwdMySQL;
        private String TstDBNameMySQL;
        private void cmdTest_Click(object sender, EventArgs e)
        {
            //Test database connection

            TstServerMySQL = txtServerHost.Text;
            TstPortMySQL = txtPort.Text;
            TstUserNameMySQL = txtUserName.Text;
            TstPwdMySQL = txtPassword.Text;
            TstDBNameMySQL = txtDatabase.Text;


            try
            {
                SQLConn.conn.ConnectionString = "Server = '" + TstServerMySQL + "';  " + "Port = '" + TstPortMySQL + "'; " + "Database = '" + TstDBNameMySQL + "'; " + "user id = '" + TstUserNameMySQL + "'; " + "password = '" + TstPwdMySQL + "'";


                SQLConn.conn.Open();
                Interaction.MsgBox("Test connection successful", MsgBoxStyle.Information, "Database Settings");

            }
            catch
            {
                Interaction.MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings");

            }
            SQLConn.DisconnMy();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            TstServerMySQL = txtServerHost.Text;
            TstPortMySQL = txtPort.Text;
            TstUserNameMySQL = txtUserName.Text;
            TstPwdMySQL = txtPassword.Text;
            TstDBNameMySQL = txtDatabase.Text;

            try
            {
                SQLConn.conn.ConnectionString = "Server = '" + TstServerMySQL + "';  " + "Port = '" + TstPortMySQL + "'; " + "Database = '" + TstDBNameMySQL + "'; " + "user id = '" + TstUserNameMySQL + "'; " + "password = '" + TstPwdMySQL + "'";
                SQLConn.conn.Open();

                SQLConn.DBNameMySQL = txtDatabase.Text;
                SQLConn.ServerMySQL = txtServerHost.Text;
                SQLConn.UserNameMySQL = txtUserName.Text;
                SQLConn.PortMySQL = txtPort.Text;
                SQLConn.PwdMySQL = txtPassword.Text;

                SQLConn.SaveData();
                this.Close();
            }
            catch
            {
                Interaction.MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings");
            }
            SQLConn.DisconnMy();
            //save database
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDataBaseConf_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(178, 127);
            txtServerHost.Text = SQLConn.ServerMySQL;
            txtPort.Text = SQLConn.PortMySQL;
            txtUserName.Text = SQLConn.UserNameMySQL;
            txtPassword.Text = SQLConn.PwdMySQL;
            txtDatabase.Text = SQLConn.DBNameMySQL;
        }
    }
}
