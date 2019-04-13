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
    public partial class frmAddEditC_Account : Form
    {
        int StaffID;
        public frmAddEditC_Account(int staffId)
        {
            InitializeComponent();
            StaffID = staffId;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

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

            if (System.Windows.Forms.Application.OpenForms["frmC_Account"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmC_Account"] as frmC_Account).LoadStaffs("");
            }

            this.Close();

        }
        private void AddStaff()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO cash_account( AccountName, Waist, Labour,Rati,Description) VALUES( '" + txt_Name.Text + "', '" + txt_waist.Text + "', '" + txt_labour.Text + "', '" + txRati.Text + "', '" + txDesc.Text + "')";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
             //   Interaction.MsgBox("New Cash Account successfully added.", MsgBoxStyle.Information, "Add Cash Account");
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
                SQLConn.sqL = "Update cash_account SET  AccountName = '" + txt_Name.Text + "', Waist ='" + txt_waist.Text + "', Labour = '" + txt_labour.Text + "', Rati= '"+txRati.Text+ "', Description= '" + txDesc.Text + "' WHERE AccountID = '" + StaffID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
           //     Interaction.MsgBox("Cash Account record successfully updated", MsgBoxStyle.Information, "Update Cash Account");

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

        private void frmAddEditC_Account_Load(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                lblTitle.Text = "Adding New Cash Account";
                ClearFields();
                GetStaffID();
            }
            else
            {
                lblTitle.Text = "Updating Cash Account";
                LoadUpdateStaff();

            }
        }
        private void ClearFields()
        {
            lblNo.Text = "";
           
            txt_Name.Text = "";
            txt_labour.Text = "";
            txt_waist.Text = "";
            txRati.Text = "";
            txDesc.Text = "";
        }
        private void GetStaffID()
        {
            try
            {
                SQLConn.sqL = "SELECT AccountID FROM cash_account ORDER BY AccountID DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblNo.Text = (Convert.ToInt32(SQLConn.dr["AccountID"]) + 1).ToString();
                }
                else
                {
                    lblNo.Text = "1";
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

            try
            {
                SQLConn.sqL = "SELECT * FROM cash_account WHERE AccountID = '" + StaffID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    lblNo.Text = SQLConn.dr["AccountID"].ToString();
                    txt_Name.Text = SQLConn.dr["AccountName"].ToString();
                    txt_waist.Text = SQLConn.dr["Waist"].ToString();
                    txt_labour.Text = SQLConn.dr["Labour"].ToString();
                    txRati.Text= SQLConn.dr["Rati"].ToString();
                    txDesc.Text = SQLConn.dr["Description"].ToString();


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
    }
}
