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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection bgl=new SqlConnection("Data Source=MONSTER-NOTEBOO\\MSSQLSERVER01;Initial Catalog=FiratNotSistemi;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DersAd,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum from Tbl_Notlar inner join Tbl_Dersler on Tbl_Notlar.Dersid=Tbl_Dersler.Dersid where Ogrid=@p1", bgl);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text=numara.ToString();
            SqlDataAdapter da= new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;

        }
    }
}
