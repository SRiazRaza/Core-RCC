using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using System.IO;

namespace Rahmat_Casting_Center
{
    public partial class frmImportAccounts : Form
    {
        public frmImportAccounts()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String filePath = String.Empty;
            String fileExt = String.Empty;

            OpenFileDialog file = new OpenFileDialog();
            file.CheckFileExists = true;
            file.AddExtension = true;
            file.Multiselect = true;
            file.Filter = "Excel files (*.xlsx)|*.xlsx;*.xls";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = file.FileName; //get the path of the file 
                lblFilePath.Text = filePath;
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();

                        dtExcel = ReadExcel(filePath, fileExt); //read excel file  

                        dataGridView1.DataSource = dtExcel;
                        dataGridView1.Refresh();
                        GroupBox1.Text = dtExcel.Rows.Count.ToString("N0") + " Products to be imported.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in selecting file." + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private String[] GetExcelSheetNames(String excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            String connString = "";

            try
            {
                // Connection String. Change the excel file to the file you
                // will search.
                if (excelFile.CompareTo(".xls") == 0)
                    connString = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
                else
                    connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
                // Create connection object by using the preceding connection String.
                objConn = new OleDbConnection(connString);
                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the String array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    // Query each excel sheet.
                }

                return excelSheets;
            }
            catch
            {
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        public DataTable ReadExcel(String fileName, String fileExt)
        {
            String conn = String.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
            {
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            }
            else
            {
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HRD=Yes;IMEX=1';"; //for above excel 2007  
            }
            using (OleDbConnection oledcon = new OleDbConnection(conn))
            {
                try
                {

                    String sheetName = GetExcelSheetNames(fileName)[0];




                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [" + sheetName + "] ", oledcon); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Reading :" + ex);
                }
            }
            return dtexcel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ImportProducts();

                if (System.Windows.Forms.Application.OpenForms["frmAccount"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["frmAccount"] as frmAccount).LoadStaffs("");
                }

                this.Close();
            }
            else
            {
                Interaction.MsgBox("No Product to Import! Please select file to import.", MsgBoxStyle.Exclamation, "Import Product");
            }
        }
        public void ImportProducts()
        {
            try
            {

                int importCount = 0;
                int duplicateCount = 0;
                for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                {
                    int AccountID = 0;
                    String FirstName="";
                    String LastName = "";
                    int contact = 0, shop = 0;
                    double waist = 0.0000, Gold_Debt = 0.000;
                    int labour = 0, Money_Debt = 0;
                    String area = "", city = "", DateIN = "";

                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
                    {
                       
                        if ((dataGridView1.Rows[i].Cells[0].Value.ToString() != "")&& (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")&& (dataGridView1.Rows[i].Cells[2].Value.ToString() != ""))
                        {
                             AccountID = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                            FirstName = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            LastName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        }
                      

                        

                        if ((dataGridView1.Rows[i].Cells[3].Value.ToString() != "")&& (dataGridView1.Rows[i].Cells[4].Value.ToString() != ""))
                        {
                            contact = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                            shop = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());

                        }
                        

                        

                        if ((dataGridView1.Rows[i].Cells[5].Value.ToString() != "")&&(dataGridView1.Rows[i].Cells[9].Value.ToString() != ""))
                        {
                            waist = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value.ToString());
                            Gold_Debt = Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString());

                        }
                     
                        if ((dataGridView1.Rows[i].Cells[6].Value.ToString() != "") && (dataGridView1.Rows[i].Cells[10].Value.ToString() != ""))
                        {
                            labour = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());
                            Money_Debt = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value.ToString());

                        }

                       
                        if ((dataGridView1.Rows[i].Cells[7].Value.ToString() != "") && (dataGridView1.Rows[i].Cells[8].Value.ToString() != "")&& (dataGridView1.Rows[i].Cells[11].Value.ToString() != ""))
                        {
                            area = dataGridView1.Rows[i].Cells[7].Value.ToString();
                            city =dataGridView1.Rows[i].Cells[8].Value.ToString();
                              DateIN = dataGridView1.Rows[i].Cells[11].Value.ToString();
                        }
                        if (IsAccountExist(AccountID) == true)
                        {
                            duplicateCount++;
                        }
                        else
                        {
                            AddAccounts(AccountID,FirstName, LastName, contact, shop, waist, labour,area,city,Gold_Debt,Money_Debt,DateIN);
                            importCount++;
                        }
                    }
                }

                Interaction.MsgBox(importCount + " Products successfully imported. " + duplicateCount + " Duplicate product.", MsgBoxStyle.Information, "Import Product");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error in importing" + ex);
            }

        }
        private bool IsAccountExist(int AccountID)
        {

            bool ret = false;
            try
            {
                SQLConn.sqL = "SELECT * FROM accounts WHERE AccountID= '" + AccountID+ "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                
             if (SQLConn.dr.Read())
              {
                ret = true;
              }
                return ret;
            }
            catch (Exception)
            {

            }

            return ret;
        }

        private void AddAccounts(int account, String first, String last,int contact,int shop,double waist,int labour,String area,String city, double gold, int money, String date)
        {
            

            try
            {
                SQLConn.sqL = "INSERT INTO ACCOUNTS( AccountID,Firstname,Lastname, ContactNo,ShopNo, Waist, Labour, Area, City, Gold_Debt,Money_Debt,DateIN ) VALUES( '" +account + "','" + first + "', '" + last + "', '" + contact + "', '" + shop + "', '" + waist + "', '" + labour + "', '" + area + "', '" + city + "', '" + gold + "', '" + money + "', '" + date + "')";
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

    }
}
