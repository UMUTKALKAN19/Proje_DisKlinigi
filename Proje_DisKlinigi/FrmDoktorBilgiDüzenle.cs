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
namespace Proje_DisKlinigi
{
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();

        public string tcno;
        public string AdSoyad;

        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = tcno;
            // Doktor Bilgilerini çekme
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1",bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbBrans.Text = dr[3].ToString();
            }
            bgln.baglanti().Close();
            AdSoyad = TxtAd.Text + " " + TxtSoyad.Text;

            //Comboboxa branşları çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgln.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgln.baglanti().Close();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            // Doktorlar tablosunda güncelleme
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorSifre=@p4 where DoktorTC=@p5",bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.ExecuteNonQuery();
            bgln.baglanti().Close();
            
            String AdSoyadNew = TxtAd.Text + " " + TxtSoyad.Text;
            // Randevular tablosunda Ad Soyad güncelleme
            SqlCommand komut2 = new SqlCommand("Update Tbl_Randevular set RandevuDoktor=@r1 where RandevuDoktor=@r2",bgln.baglanti());
            komut2.Parameters.AddWithValue("@r2", AdSoyad);
            komut2.Parameters.AddWithValue("@r1", AdSoyadNew);
            komut2.ExecuteNonQuery();
            bgln.baglanti().Close();
            MessageBox.Show("Bilgiler Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doktorlar kendileri branşlarını istedikleri gibi değiştiremeyecekleri için uyarı verdiriyoruz.
            //Doktorlar branş değişikliği için üst kuruma başvurması gerekiyor.
            CmbBrans.Items.Clear();
            MessageBox.Show("Branş değişikliği için Baş Hekimliğe başvurunuz... (322)-034-0101 'i arayınız..");
            
        }
    }
}
