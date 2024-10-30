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
    public partial class FrmOgrenci : Form
    {
        SqlConnection bgl = new SqlConnection("Data Source=MONSTER-NOTEBOO\\MSSQLSERVER01;Initial Catalog=FiratNotSistemi;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select Ogrid,OgrAd,OgrSoyad,KulupAd,OgrCinsiyet from Tbl_Ogrenciler inner join Tbl_Kulupler on Tbl_Ogrenciler.OgrKulup=Tbl_Kulupler.Kulupid", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("select Ogrid,OgrAd,OgrSoyad,KulupAd,OgrCinsiyet from Tbl_Ogrenciler inner join Tbl_Kulupler on Tbl_Ogrenciler.OgrKulup=Tbl_Kulupler.Kulupid",bgl);
            komut.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand komut2 = new SqlCommand("Select * from Tbl_Kulupler", bgl);
            SqlDataAdapter da2= new SqlDataAdapter(komut2);
            DataTable dt2= new DataTable();
            da2.Fill(dt2);
            CmbKulup.DisplayMember = "KulupAd";
            CmbKulup.ValueMember = "Kulupid";
            CmbKulup.DataSource = dt2;
            bgl.Close();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            String C = " ";
            SqlCommand komut = new SqlCommand("insert into Tbl_Ogrenciler (OgrAd,OgrSoyad,OgrKulup,OgrCinsiyet) values (@OgrAd,@OgrSoyad,@OgrKulup,@OgrCinsiyet)", bgl);
            komut.Parameters.AddWithValue("@OgrAd", TxtAd.Text);
            komut.Parameters.AddWithValue("@OgrSoyad", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@OgrKulup", CmbKulup.SelectedValue);
            
            if (RadioErkek.Checked == true)
            {
                C = "Erkek";

            }
            if (RadioKiz.Checked == true)
            {
                C = "Kız";
            }
            komut.Parameters.AddWithValue("@OgrCinsiyet", C.ToString());
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Öğrenci Listeye Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Delete From Tbl_Ogrenciler where (Ogrid=@Ogrid)",bgl);
            komut.Parameters.AddWithValue("@Ogrid", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.Close() ;
            MessageBox.Show("Silme İşlemi Gerçekleşti.", "Bilgi", MessageBoxButtons.OK);
            listele() ;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (cinsiyet == "Erkek")
            {
                RadioErkek.Checked = true;
            }
            else if (cinsiyet == "Kız")
            {
                RadioKiz.Checked = true;
            }


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            string C = " ";
            bgl.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Ogrenciler set OgrAd=@OgrAd,OgrSoyad=@OgrSoyad,OgrKulup=@OgrKulup,OgrCinsiyet=@OgrCinsiyet where Ogrid=@Ogrid", bgl);

            komut.Parameters.AddWithValue("@OgrAd", TxtAd.Text);
            komut.Parameters.AddWithValue("@OgrSoyad", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@OgrKulup", CmbKulup.SelectedValue);
            if (RadioErkek.Checked == true)
            {
                C = "Erkek";

            }
            if (RadioKiz.Checked == true)
            {
                C = "Kız";
            }
            komut.Parameters.AddWithValue("@OgrCinsiyet", C.ToString());
            komut.Parameters.AddWithValue("@Ogrid",Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Öğrenci Güncelleme İşlemi Gerçekleşti.");
            listele();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select Tbl_Ogrenciler.Ogrid,Tbl_Ogrenciler.OgrAd,Tbl_Ogrenciler.OgrSoyad,Tbl_Kulupler.KulupAd,Tbl_Ogrenciler.OgrCinsiyet From Tbl_Ogrenciler inner join Tbl_Kulupler on Tbl_Ogrenciler.OgrKulup=Tbl_Kulupler.Kulupid where (Tbl_Ogrenciler.OgrAd=@OgrAd)",bgl);
            komut.Parameters.AddWithValue("@OgrAd", TxtAdıAra.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.Close();
        }

        
    }
}
