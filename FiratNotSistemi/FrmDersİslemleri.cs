using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FiratNotSistemi
{
    public partial class FrmDersİslemleri : Form
    {
        public FrmDersİslemleri()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=MONSTER-NOTEBOO\\MSSQLSERVER01;Initial Catalog=FiratNotSistemi;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Dersler", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void FrmDersİslemleri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert  into Tbl_Dersler (DersAd) values (@p1)", bgl);
            komut.Parameters.AddWithValue("@p1", TxtDersAd.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Ders Listeye Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Dersler set DersAd=@p1 where Dersid=@p2", bgl);
            komut.Parameters.AddWithValue("@p1", TxtDersAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtDersid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Ders Güncelleme İşlemi Gerçekleşti.");
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Delete From Tbl_Dersler where Dersid=@p1", bgl);
            komut.Parameters.AddWithValue("@p1", TxtDersid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Ders Silme İşlemi Gerçekleşti.");
            listele();
        }
    }
}
