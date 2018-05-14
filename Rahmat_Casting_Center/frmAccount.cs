using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Rahmat_Casting_Center
{
    public partial class frmAccount : Form
    {
        bool dec_spe = false;
        public frmAccount()
        {
            InitializeComponent();
        }
        int staffID;
        private void button1_Click(object sender, EventArgs e)
        {
            SQLConn.adding = true;
            SQLConn.updating = false;
            int init = 0;
            frmAddEditAccount f2 = new frmAddEditAccount(init);
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ListView1.Items.Count == 0)
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
            try
            {
                if (String.IsNullOrEmpty(ListView1.FocusedItem.Text))
                {

                }
                else
                {
                    SQLConn.adding = false;
                    SQLConn.updating = true;
                    staffID = Convert.ToInt32(ListView1.FocusedItem.Text);
                    frmAddEditAccount f2 = new frmAddEditAccount(staffID);
                    f2.ShowDialog();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        public void LoadStaffs(String search)
        {
            try
            {
                SQLConn.sqL = "SELECT AccountID, CONCAT( Firstname,' ',Lastname,  ' ') as ClientName, CONCAT( Area, ', ', City) as Address, ContactNo,ShopNo,Gold_Debt,Money_Debt,DateIN FROM accounts WHERE FIRSTNAME LIKE '" + search.Trim() + "%' ORDER By AccountID";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                ListViewItem x = null;
                ListView1.Items.Clear();

                while (SQLConn.dr.Read() == true)
                {
                    x = new ListViewItem(SQLConn.dr["AccountId"].ToString());
                    x.SubItems.Add(SQLConn.dr["ClientName"].ToString());
                    if (dec_spe == true)
                    {
                        x.SubItems.Add(Strings.Format(SQLConn.dr["Gold_Debt"], "#,###0.000"));
                    }
                    else
                    {
                        String ds = "";
                        decimal d = 0;
                        ds = Strings.Format(Strings.Format(SQLConn.dr["Gold_Debt"], "#,###0.000"));
                        d = Convert.ToDecimal(ds);
                        d = decimal.Round(d, 2, MidpointRounding.AwayFromZero); //2.58                    
                        x.SubItems.Add(d.ToString() + "0");

                    }
                    x.SubItems.Add(SQLConn.dr["Money_debt"].ToString());
                    x.SubItems.Add(SQLConn.dr["ContactNo"].ToString());
                    x.SubItems.Add(SQLConn.dr["Address"].ToString());
                    x.SubItems.Add(SQLConn.dr["ShopNo"].ToString());
                    x.SubItems.Add(SQLConn.dr["DateIN"].ToString());


                    ListView1.Items.Add(x);
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            check_decimal_func();
            LoadStaffs("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SQLConn.strSearch = textBox1.Text;

            if (SQLConn.strSearch.Length >= 1)
            {
                LoadStaffs(SQLConn.strSearch.Trim());
            }
            else if (String.IsNullOrEmpty(SQLConn.strSearch))
            {
                LoadStaffs("");
            }
        }

        private void frmAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            { btnClose.PerformClick(); }
        }

        private void btnStocksIn_Click(object sender, EventArgs e)
        {
            if (ListView1.Items.Count == 0)
            {
                Interaction.MsgBox("Please select record to add Debt", MsgBoxStyle.Exclamation, "DebtIn");
                return;
            }
            try
            {
                if (String.IsNullOrEmpty(ListView1.FocusedItem.Text))
                {

                }
                else
                {

                    int account = Convert.ToInt32(ListView1.FocusedItem.Text);
                    frmDebtIn aeP = new frmDebtIn(account);
                    aeP.ShowDialog();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to add Debt", MsgBoxStyle.Exclamation, "DebtIn");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                        abc.Add("accounts");
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

        private void btnImport_Click(object sender, EventArgs e)
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
                    LoadStaffs("");
                    MessageBox.Show("Restoring Successfully Completed.");
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Restroring UnSuccessfull. " + ex);
            }

        }
    }
}
