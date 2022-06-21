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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string tc;
        SqlBaglanti bgln = new SqlBaglanti();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;
            MskTc.Text = null;

            MskTc.Text = label9.Text;
            

            // sekreter bilgilerini forma çekme
            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1 ",bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgln.baglanti().Close();

            // branşları comboboxa çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgln.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgln.baglanti().Close();
        }

        private void BtnBranslarVeDoktorlarListesi_Click(object sender, EventArgs e)
        {
            FrmBranslarVeDoktorlarListesi frmb = new FrmBranslarVeDoktorlarListesi();
            frmb.Show();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // randevu yayınlarken tarih saat brans ve doktor girme zorunluluğu ekliyoruz.
            if(MskTarih.Text.Length < 10 || MskSaat .Text == "" || CmbBrans.Text == "" || CmbDoktor.Text == "")
            {
                MessageBox.Show("Tarih, Saat, Brans veya Doktor Boş Bırakılamaz!!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor, HastaTC, RandevuDurum ) values (@r1,@r2,@r3,@r4,@r5,@r6)", bgln.baglanti());
                komutkaydet.Parameters.AddWithValue("@r1", MskTarih.Text);
                komutkaydet.Parameters.AddWithValue("@r2", MskSaat.Text);
                komutkaydet.Parameters.AddWithValue("@r3", CmbBrans.Text);
                komutkaydet.Parameters.AddWithValue("@r4", CmbDoktor.Text);
                if (MskTc.Text.Length > 1)
                {
                    komutkaydet.Parameters.AddWithValue("@r5", MskTc.Text);
                }
                else
                {
                    komutkaydet.Parameters.AddWithValue("@r5", DBNull.Value);
                }
                if (ChkDurum.Checked)
                {
                    komutkaydet.Parameters.AddWithValue("@r6", 1);
                }
                else
                {
                    komutkaydet.Parameters.AddWithValue("@r6", 0);
                }
                komutkaydet.ExecuteNonQuery();
                bgln.baglanti().Close();
                MessageBox.Show("Randevuyu Oluşturdunuz");
            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
        }

        private void BtnDuyuruYayinla_Click(object sender, EventArgs e)
        {
            // Boş duyuru yayınlamayı engelleme kontrolü
            if(RchDuyuru.Text=="")
            {
                MessageBox.Show("Boş içerik duyurusu yayınlanamaz!!!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (duyuru) values (@p1)", bgln.baglanti());
                komut.Parameters.AddWithValue("@p1", RchDuyuru.Text);
                komut.ExecuteNonQuery();
                bgln.baglanti().Close();
                MessageBox.Show("Duyuru Yayınlandı");
                RchDuyuru.Text = "";
            }
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fdp = new FrmDoktorPaneli();
            fdp.Show();
        }

        private void BtnBranşPanel_Click(object sender, EventArgs e)
        {
            FrmBrans fb = new FrmBrans();
            fb.Show();
        }

        private void BtnRandevuPanel_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frl = new FrmRandevuListesi();
            // Sekreterin adını soyadını gönderiyoruz çünkü geri sekreter detay formuna dönerken ad soyadı yazdırabilmek için.
            frl.sekretertcno = tc;
            frl.sekreterad = LblAdSoyad.Text;
            frl.Show();
            this.Hide();
            
        }

        public string idKontrol="";

        

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // Güncelleme yaparken id tarih saat brans doktor girme zorunluluğu
            if(Txtid.Text=="" || MskTarih.Text.Length <10 || MskSaat.Text == "" || CmbBrans.Text == "" || CmbDoktor.Text == "")
            {
                MessageBox.Show("İD, Tarih, Saat, Brans veya Doktor Boş Bırakılamaz!!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                // girilen idye ait bir randevu var mı onu kontrol ediyoruz.
                SqlCommand komut2 = new SqlCommand("Select RandevuDoktor from Tbl_Randevular where Randevuid=@p1 ", bgln.baglanti());
                // girilen id int mi kontrolü yapıyoruz.
                if (!Int32.TryParse(Txtid.Text, out int sayi))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Sayı Giriniz!!");
                    return;
                }
                komut2.Parameters.AddWithValue("@p1", Txtid.Text);
                SqlDataReader dr = komut2.ExecuteReader();
                while (dr.Read())
                {
                   idKontrol = dr[0].ToString();
                }
                bgln.baglanti().Close();
                if (idKontrol==string.Empty)
                {
                    MessageBox.Show("Girilen id YANLIŞ!!!");
                }
                else
                {
                    idKontrol = "";
                    SqlCommand komut = new SqlCommand("update Tbl_Randevular set RandevuTarih=@p2, RandevuSaat=@p3, RandevuBrans=@p4, RandevuDoktor=@p5, RandevuDurum=@p6, HastaTC=@p7  where Randevuid=@p1", bgln.baglanti());
                    komut.Parameters.AddWithValue("@p1", Txtid.Text);
                    komut.Parameters.AddWithValue("@p2", MskTarih.Text);
                    komut.Parameters.AddWithValue("@p3", MskSaat.Text);
                    komut.Parameters.AddWithValue("@p4", CmbBrans.Text);
                    komut.Parameters.AddWithValue("@p5", CmbDoktor.Text);
                    if (MskTc.Text.Length > 1)
                    {
                        komut.Parameters.AddWithValue("@p7", MskTc.Text);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@p7", DBNull.Value);
                    }

                    if (ChkDurum.Checked)
                    {
                        komut.Parameters.AddWithValue("@p6", 1);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@p6", 0);
                    }
                    komut.ExecuteNonQuery();
                    bgln.baglanti().Close();
                    MessageBox.Show("Randevu Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }   
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fd = new FrmDuyurular();
            fd.Show();
        }
    }
}
