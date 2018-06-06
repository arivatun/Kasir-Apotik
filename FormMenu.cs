using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void cUSTOMERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCustomer cs = new FormCustomer();
            cs.ShowDialog();
        }

        private void iNVENTARISOBATToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormObat obat = new FormObat();
            obat.ShowDialog();
        }

        private void iNVENTARISOBATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTransaksi trx = new FormTransaksi();
            trx.ShowDialog();
        }

        private void sIGNOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin lg = new FormLogin();
            lg.Show();
            this.Close();
        }

    }
}
