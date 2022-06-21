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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();
        public string tc;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            //datagridview dizayn
            islemler.DatagridviewDuzenleme(dataGridView1);
            islemler.DatagridviewDuzenleme(dataGridView2);
            islemler.DatagridviewDuzenleme(dataGridView3);

            LblTc.Text = tc;

            // Doktor bilgilerini çekme

            SqlCommand komut = new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1",bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgln.baglanti().Close();
            // Fonksiyon ile tüm randevular datagridini dolduruyoruz 
            datagriddondur(dataGridView1, 1);
            // Fonksiyon ile aktif randevular datagridini dolduruyoruz
            datagriddondur(dataGridView2, 0);

            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("Select Randevuid as id, RandevuDurum as Durum, RandevuTarih as Tarih, RandevuSaat as Saat, HastaTC as HastaTc, HastaSikayet as Sikayet, RandevuBrans as Brans From Tbl_Randevular where RandevuDoktor='" + LblAdSoyad.Text+ "'"+" and RandevuDurum=1 ", bgln.baglanti());
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //dataGridView1.ReadOnly = true;
            //// DataGrid Hücre Boyutlarını ayarlama
            //dataGridView1.Columns[0].Width = 30;
            //dataGridView1.Columns[1].Width = 68;
            //dataGridView1.Columns[3].Width = 60;
            //dataGridView1.Columns[4].Width = 110;
            //dataGridView1.Columns[5].Width = 137;
            //// Durum hücresinin değerlerini ortalayalım
            //dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //// Baştaki hücreyi kaldıralım
            ////dataGridView1.RowHeadersVisible = false;
            ///

            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
        }

        private DataGridView datagriddondur(DataGridView dgv, int randevudurum)
        {
            if(randevudurum==1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select Randevuid as id, RandevuTarih as Tarih, RandevuSaat as Saat, HastaTC as HastaTc, HastaSikayet as Sikayet, RandevuBrans as Brans From Tbl_Randevular where RandevuDoktor='" + LblAdSoyad.Text + "'" + " and RandevuDurum=1 ", bgln.baglanti());
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns[3].Width = 139;
                dgv.Columns[4].Width = 201;
            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select Randevuid as id, RandevuTarih as Tarih, RandevuSaat as Saat, RandevuBrans as Brans From Tbl_Randevular where RandevuDoktor='" + LblAdSoyad.Text + "'" + " and RandevuDurum=0 ", bgln.baglanti());
                da.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns[3].Width = 124;
            }
            dgv.ReadOnly = true;
            // DataGrid Hücre Boyutlarını ayarlama
            dgv.Columns[1].Width = 130;
            dgv.Columns[0].Width = 50;
            dgv.Columns[2].Width = 80;
            // Baştaki hücreyi kaldıralım
            //dataGridView1.RowHeadersVisible = false;

            return dgv;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDoktorBilgiDüzenle fdbd = new FrmDoktorBilgiDüzenle();
            fdbd.tcno = tc;
            fdbd.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tıklanılan hastanın şikayetini, bilgilerini ve ilgili hekim için olan randevularını çekelim.
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string secilen2 = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            SqlCommand komut = new SqlCommand("Select HastaAd, HastaSoyad, HastaTelefon From Tbl_Hastalar where HastaTC=" + secilen2, bgln.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblHastaAdSoyad.Text = dr[0] + " " + dr[1];
                LblHastaTelefon.Text = dr[2].ToString();
            }
            bgln.baglanti().Close();

            string doktorad = LblAdSoyad.Text;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select RandevuTarih as Tarih, RandevuSaat as Saat, HastaSikayet as Sikayet From Tbl_Randevular where RandevuDoktor='" + LblAdSoyad.Text + "'" + " and HastaTC="+secilen2, bgln.baglanti());
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            
            // Eski randevuda şikayet bölümünün boyutunu ve stilini belirliyoruz.
            islemler.EskiRandevularDatagridview(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd = new FrmDuyurular();
            frd.Show();
        }
    }
}
