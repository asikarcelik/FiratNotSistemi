using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FiratNotSistemi
{
    public partial class FrmSınavNotları : Form
    {
        SqlConnection bgl = new SqlConnection("Data Source=MONSTER-NOTEBOO\\MSSQLSERVER01;Initial Catalog=FiratNotSistemi;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public FrmSınavNotları()
        {
            InitializeComponent();
        }
        
        private void BtnAra_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select Notid,Dersid,Ogrid,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum from Tbl_Notlar where Ogrid=@Ogrid",bgl);
            komut.Parameters.AddWithValue("Ogrid",Txtid.Text);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSınavNotları_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Select * from Tbl_Dersler", bgl);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            CmbDers.DisplayMember = "DersAd";
            CmbDers.ValueMember = "Dersid";
            CmbDers.DataSource = dt2;
            bgl.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            

        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;
            string durum;
            sinav1=Convert.ToInt32(TxtSınav1.Text);
            sinav2 = Convert.ToInt32(TxtSınav2.Text);
            sinav3 = Convert.ToInt32(TxtSınav3.Text);
            proje = Convert.ToInt32(TxtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            ortalama=Math.Round(ortalama,2);
            TxtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
            
            
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtSınav1.Clear();
            TxtSınav2.Clear();
            TxtSınav3.Clear(); 
            TxtProje.Clear();
            TxtOrtalama.Clear();
            TxtDurum.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
