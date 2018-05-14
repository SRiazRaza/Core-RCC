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
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
          //  Camera_Connection.Start();

        }
        public void GetCompanyInfo()
        {
            try
            {
                SQLConn.sqL = "SELECT Gold_Rate,digit,msg FROM setting";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();


                if (SQLConn.dr.Read())
                {
                   
                   
                    textBox2.Text = SQLConn.dr[0].ToString();
                   
                    if (SQLConn.dr[1].ToString() == "true")
                    {
                        checkBox1.Checked = true;
                    }
                    else {
                        checkBox1.Checked = false;

                    }
                    textBox1.Text = SQLConn.dr[2].ToString();


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
        public void AddEditCompany(bool isAdding)
        {
            try
            {
                if (isAdding == true)
                {
                    SQLConn.sqL = "INSERT INTO setting(id, Gold_Rate,digit,msg) VALUES(@id, @Gold_Rate,@digit,@msg)";
                }
                else
                {
                    SQLConn.sqL = "UPDATE setting SET id=@id, Gold_Rate=@Gold_Rate, digit =@digit,msg=@msg";
                }
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);

                SQLConn.cmd.Parameters.AddWithValue("@id", "1");
              
                SQLConn.cmd.Parameters.AddWithValue("@Gold_Rate", textBox2.Text);
                SQLConn.cmd.Parameters.AddWithValue("@msg", textBox1.Text);

                if (checkBox1.Checked == true)
                {
                    SQLConn.cmd.Parameters.AddWithValue("@digit", "true");
                }
                else {
                    SQLConn.cmd.Parameters.AddWithValue("@digit", "false");

                }


                int i = SQLConn.cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    if (isAdding == true)
                    {
                        Interaction.MsgBox("Information Successfully Added", MsgBoxStyle.Information, "Adding Information");
                    }
                    else
                    {
                        Interaction.MsgBox("Information Successfully Updated", MsgBoxStyle.Information, "Editing Information");
                    }
                }
                else
                {
                    Interaction.MsgBox("Saving Information Failed", MsgBoxStyle.Exclamation, "Failed");
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
        private bool IsAdding()
        {
            bool ret = false;
            try
            {
                SQLConn.sqL = "SELECT * FROM setting";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read() == true)
                {
                    ret = false;
                }
                else
                {
                    ret = true;
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
            return ret;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEditCompany(IsAdding());
            this.Close();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
           
            textBox2.Text = "";
            textBox2.Text = "";


            GetCompanyInfo();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
        }

       // private void button1_Click(object sender, EventArgs e)
       // {
         //   frmpicture_form abc = new frmpicture_form("", "", "");
          //  abc.ShowDialog();
    //    }
    }
}
