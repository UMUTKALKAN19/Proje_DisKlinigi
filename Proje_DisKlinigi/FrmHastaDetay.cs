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
using System.Text.RegularExpressions;

namespace Proje_DisKlinigi
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc;
        SqlBaglanti bgln = new SqlBaglanti();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            // datagridlerin özelliklerini düzenliyoruz.
            islemler.DatagridviewDuzenleme(dataGridView1);
            islemler.DatagridviewDuzenleme(dataGridView2);
            LblTc.Text = tc;
            islemler.tcno = tc;

            // Kişi bilgilerini Forma çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTC=@p1", bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgln.baglanti().Close();

            //Randevu Geçmişini getirme
            islemler.HastaDetayRandevuCekme(dataGridView1);

            //Branşları çekiyoruz
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar",bgln.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgln.baglanti().Close();

            //datagridlerin sütun boyutlarını ayarlayalım
            islemler.HastaFormuDatagridviewBoyut(dataGridView1, 1);
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            CmbDoktor.Text = "";
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1",bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgln.baglanti().Close();
        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Randevuid as id,RandevuTarih as Tarih,RandevuSaat as Saat,RandevuBrans as Brans,RandevuDoktor as Doktor from Tbl_Randevular where RandevuBrans='"+CmbBrans.Text+"'"+ " and RandevuDoktor='"+ CmbDoktor.Text+"' and RandevuDurum=0",bgln.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            // datagrid sütun boyutlarını ayarlayalım
            islemler.HastaFormuDatagridviewBoyut(dataGridView2, 2);
        }

        private void LnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.tcno = LblTc.Text;
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TxtRandevuid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            // Randevu id boş ise hata verdirme sorgusu.
            if(TxtRandevuid.Text=="")
            {
                MessageBox.Show("RANDEVU SEÇİLMEMİŞTİR!!. Randevu seçip tekrar deneyiniz.");
            }
            else
            {
                SqlCommand komut = new SqlCommand("update Tbl_Randevular set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3", bgln.baglanti());
                komut.Parameters.AddWithValue("@p1", tc);
                komut.Parameters.AddWithValue("@p2", RchSikayet.Text);
                komut.Parameters.AddWithValue("@p3", TxtRandevuid.Text);
                komut.ExecuteNonQuery();
                bgln.baglanti().Close();
                MessageBox.Show("Randevu Başarıyla Alınmıştır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Randevu alındığında güncel olarak randevuları tekrardan datagride çekiyoruz.
                islemler.HastaDetayRandevuCekme(dataGridView1);
            }
        }
    }
}
