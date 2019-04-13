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

namespace Rahmat_Casting_Center
{
    public partial class frmFilterTransactions : Form
    {
        public frmFilterTransactions()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if ((rbStocksIn.Checked == false) && (rbStocksOut.Checked == false) && (rbimages.Checked == false) && (rbDebt.Checked == false) && (rbCasting.Checked == false) && (rbCimages.Checked == false))
            {
                Interaction.MsgBox("Please Choose Right Report Generator Option", MsgBoxStyle.Information, "Select Report");
                return;
            }

            if (rbStocksIn.Checked == true)
            {

                frmReportSAccount rs = new frmReportSAccount(dtpStartDate.Value, dtpEndDate.Value,find.Text);
                rs.ShowDialog();
            }

            if (rbStocksOut.Checked == true)
            {
                rptCashDetail rs = new rptCashDetail(dtpStartDate.Value , dtpEndDate.Value , find.Text);
                rs.ShowDialog();

            }
            if (rbimages.Checked == true)
            {
                frmReportImages abc = new frmReportImages(dtpStartDate.Value , dtpEndDate.Value , find.Text);
                abc.ShowDialog();

            }
            if (rbDebt.Checked == true)
            {
                rptDebtIn abc = new rptDebtIn(dtpStartDate.Value , dtpEndDate.Value , find.Text);
                abc.ShowDialog();

            }
            if (rbCasting.Checked == true)
            {
                rptCasting abc = new rptCasting(dtpStartDate.Value , dtpEndDate.Value );
                abc.ShowDialog();

            }
            if (rbCimages.Checked == true)
            {
                rptCashPic abc = new rptCashPic(dtpStartDate.Value , dtpEndDate.Value , find.Text);
                abc.ShowDialog();

            }
        }

    private void rbStocksOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStocksOut.Checked == true)
            {
                rbStocksIn.Checked = false;
                rbimages.Checked = false;
            }
        }

        private void rbStocksIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStocksIn.Checked == true)
            {
                rbStocksOut.Checked = false;
                rbimages.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbimages_CheckedChanged(object sender, EventArgs e)
        {
            if (rbimages.Checked == true)
            {
                rbStocksIn.Checked = false;
                rbStocksOut.Checked = false;
            }
        }

        private void rbDebt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDebt.Checked == true)
            {
                rbStocksIn.Checked = false;
                rbStocksOut.Checked = false;
                rbimages.Checked = false;
                rbCasting.Checked = false;
            }
        }

        private void rbCasting_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCasting.Checked == true)
            {
                rbStocksIn.Checked = false;
                rbStocksOut.Checked = false;
                rbimages.Checked = false;
                rbDebt.Checked = false;
            }
        }
    }
}
