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
                     //   Interaction.MsgBox("Information Successfully Added", MsgBoxStyle.Information, "Adding Information");
                    }
                    else
                    {
                     //   Interaction.MsgBox("Information Successfully Updated", MsgBoxStyle.Information, "Editing Information");
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
            LoadFontInfo();
            GetCompanyInfo();
            getFont();
           
        }
       
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getFont() {

            Font f =Properties.Settings.Default.bill_font;
            Font_Family.Text=f.OriginalFontName.ToString();
            Font_Size.Text= f.SizeInPoints.ToString();



        }
        private void LoadFontInfo() {

            foreach (FontFamily font in FontFamily.Families) {
                Font_Family.Items.Add(font.Name.ToString());
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myS = null;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "BackUp File (*.sql)|*.sql";
            saveFileDialog1.RestoreDirectory = true;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    if ((myS = saveFileDialog1.OpenFile()) != null)
                    {

                        SQLConn.ConnDB();
                        SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                        MySqlBackup mb = new MySqlBackup(SQLConn.cmd);
                        string file = Path.GetFullPath(saveFileDialog1.FileName);
                        myS.Close();


                        mb.ExportInfo.AddCreateDatabase = true;
                        List<string> abc = new List<string>();
                        abc.Add("accountdetails");
                        abc.Add("caccountdetails");
                        abc.Add("casting");
                        abc.Add("debtin");
                        abc.Add("setting");
                        mb.ExportInfo.TablesToBeExportedList = abc;
                        mb.ExportInfo.ExportTableStructure = true;
                        mb.ExportInfo.ExportRows = true;
                        mb.ExportToFile(file);
                        MessageBox.Show("BackUp Successfully Completed.");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BackUp UnSuccessfull. " + ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Open Text File";
                theDialog.Filter = "BackUp File (*.sql)|*.sql";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {

                    string file = Path.GetFullPath(theDialog.FileName);
                    SQLConn.ConnDB();
                    SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                    MySqlBackup mb = new MySqlBackup(SQLConn.cmd);
                    mb.ImportInfo.TargetDatabase = "rahmat_casting_center";
                    mb.ImportInfo.DatabaseDefaultCharSet = "utf8";
                    mb.ImportFromFile(file);

                    MessageBox.Show("Restoring Successfully Completed.");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Restroring UnSuccessfull. " + ex);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            SaveData();

         }
        private void SaveData()
        {
            Font font1 = new Font(Font_Family.Text,Convert.ToInt32(Font_Size.Text));
            Properties.Settings.Default["bill_font"] = font1;
            Properties.Settings.Default.Save();
            // Saves settings in application configuration file
            Interaction.MsgBox("Information Successfully Added", MsgBoxStyle.Information, "Adding Information");

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46) { e.Handled = true; }

        }

        // private void button1_Click(object sender, EventArgs e)
        // {
        //   frmpicture_form abc = new frmpicture_form("", "", "");
        //  abc.ShowDialog();
        //    }
    }
}
