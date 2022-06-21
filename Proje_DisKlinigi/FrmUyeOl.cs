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
    public partial class FrmUyeOl : Form
    {
        public FrmUyeOl()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();


        private void BtnKayitYap_Click(object sender, EventArgs e)
        {
            // Üye olurken alanların boş bırakılmamasının kontrolünü yapıyoruz.
            if (TxtAd.Text == "" || TxtSoyad.Text == "" || MskTC.Text == "" || MskTelefon.Text == "" || TxtSifre.Text == "" || CmbCinsiyet.Text == "")
            {
                MessageBox.Show("Alanlar Boş bırakılamaz!!!");
            }
            else
            {
                // Tc hanesine 11 rakam girilmesi gerekiyor
                if(MskTC.Text.Length==11)
                {
                    // Telefon hanesinin karakter sayısını kontrol etme
                    if(MskTelefon.Text.Length==14)
                    {
                        // Şifrenin uzunluğu 4 haneden büyük olmalıdır.
                        if (TxtSifre.Text.Length >= 4)
                        {
                            // Alanlar boş değilse kaydı ilgili tabloya ekliyoruz.
                            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgln.baglanti());
                            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                            komut.Parameters.AddWithValue("@p3", MskTC.Text);
                            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
                            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
                            komut.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
                            komut.ExecuteNonQuery();
                            bgln.baglanti().Close();
                            MessageBox.Show("Üye Oldunuz Şifreniz: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Şifre 4 Haneden fazla olmalıdır!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Telefon numaranızı doğru giriniz!!");
                    }
                }
                else
                {
                    MessageBox.Show("TC 11 Haneli olmak zorundadır!!");
                }
            }
        }
    }
}
