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
    public partial class frmC_Account : Form
    {
        int staffID;
        public frmC_Account()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLConn.adding = true;
            SQLConn.updating = false;
            int init = 0;
            frmAddEditC_Account f2 = new frmAddEditC_Account(init);
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
                    ListView1.FocusedItem.Focused = false;
                    frmAddEditC_Account f2 = new frmAddEditC_Account(staffID);
                    f2.ShowDialog();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
        }
        public void LoadStaffs(String search)
        {
            try
            {
                SQLConn.sqL = "SELECT AccountID, AccountName,Waist,Labour,Description,Rati FROM cash_account WHERE AccountName LIKE '" + search.Trim() + "%' ORDER By AccountID";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                ListViewItem x = null;
                ListView1.Items.Clear();

                while (SQLConn.dr.Read() == true)
                {
                    x = new ListViewItem(SQLConn.dr["AccountID"].ToString());
                    x.SubItems.Add(SQLConn.dr["AccountName"].ToString());
                    x.SubItems.Add(SQLConn.dr["Description"].ToString());
                    x.SubItems.Add(SQLConn.dr["Waist"].ToString());
                    x.SubItems.Add(SQLConn.dr["Labour"].ToString());
                    x.SubItems.Add(SQLConn.dr["Rati"].ToString());

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

        private void frmC_Account_Load(object sender, EventArgs e)
        {
            LoadStaffs("");
        }

        private void frmC_Account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { btnClose.PerformClick(); }
        }
    }
}
