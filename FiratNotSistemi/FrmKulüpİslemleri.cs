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
    public partial class FrmKulüpİslemleri : Form
    {
        public FrmKulüpİslemleri()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=MONSTER-NOTEBOO\\MSSQLSERVER01;Initial Catalog=FiratNotSistemi;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Kulupler", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulüpİslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert  into Tbl_Kulupler (KulupAd) values (@p1)",bgl);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp Listeye Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupid.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Delete From Tbl_Kulupler where Kulupid=@p1",bgl);
            komut.Parameters.AddWithValue("@p1", TxtKulupid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp Silme İşlemi Gerçekleşti.");
            listele();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Kulupler set KulupAd=@p1 where Kulupid=@p2", bgl);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKulupid.Text);
            komut.ExecuteNonQuery();
            bgl.Close ();
            MessageBox.Show("Kulüp Güncelleme İşlemi Gerçekleşti.");
            listele();
        }

        }
}

