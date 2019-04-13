using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rahmat_Casting_Center
{
    public partial class frmRePrint : Form
    {
        public frmRePrint()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            // RePrinting the bill whose data is already in database
            try
            {
                if (mTextBox1.Text != "" && mTextBox2.Text != "")
                {
                    if (checkBox1.Checked == false) //
                    {
                        frmPrint xyz = new frmPrint(mTextBox1.Text, mTextBox2.Text, "Single");
                        xyz.ShowDialog();
                    }
                    else
                    {

                        frmPrint xyz = new frmPrint(mTextBox1.Text, mTextBox2.Text, "Cash");
                        xyz.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Empty fields.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Stop beep on ENter pressing

                mTextBox2.Focus();
            }
        }

        private void mTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // Stop beep on ENter pressing

                button1.PerformClick();
            }
        }

        private void frmRePrint_Load(object sender, EventArgs e)
        {
            mTextBox1.Focus();
        }
    }
}
