using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiratNotSistemi
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulüpİslemleri fr=new FrmKulüpİslemleri();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersİslemleri fr = new FrmDersİslemleri();
            fr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSınavNotları fr = new FrmSınavNotları();
            fr.Show();
        }
    }
}
