using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Rahmat_Casting_Center
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            //Thread.Sleep(5000);
            //this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
