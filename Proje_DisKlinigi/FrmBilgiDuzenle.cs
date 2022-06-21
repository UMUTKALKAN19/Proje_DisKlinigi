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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string tcno;
        SqlBaglanti bgln = new SqlBaglanti();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = tcno;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTC.Text = dr[3].ToString();
                TxtSifre.Text = dr[4].ToString();
                CmbCinsiyet.Text = dr[5].ToString();
                MskTelefon.Text = dr[6].ToString();
            }
            bgln.baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            // Bilgi güncellerken alanların boş bırakılmamasının kontrolünü yapıyoruz.
            if (TxtAd.Text == "" || TxtSoyad.Text=="" || TxtSifre.Text == "" || MskTC.Text == "" || MskTelefon.Text == "" || CmbCinsiyet.Text == "")
            {
                MessageBox.Show("Alanlar Boş bırakılamaz!!!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                // Telefon hanesinin karakter sayısını kontrol etme
                if (MskTelefon.Text.Length == 14)
                {
                    // Şifrenin uzunluğu 4 haneden büyük olmalıdır.
                    if (TxtSifre.Text.Length >= 4)
                    {
                        SqlCommand komut = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1, HastaSoyad=@p2, HastaSifre=@p3, HastaCinsiyet=@p4, HastaTelefon=@p5 where HastaTC=@p6", bgln.baglanti());
                        komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                        komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                        komut.Parameters.AddWithValue("@p3", TxtSifre.Text);
                        komut.Parameters.AddWithValue("@p4", CmbCinsiyet.Text);
                        komut.Parameters.AddWithValue("@p5", MskTelefon.Text);
                        komut.Parameters.AddWithValue("@p6", MskTC.Text);
                        komut.ExecuteNonQuery();
                        bgln.baglanti().Close();
                        this.Hide();
                        MessageBox.Show("Bilgileriniz Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Şifre 4 Haneden fazla olmalıdır!!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Telefon numaranızı doğru giriniz!!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
