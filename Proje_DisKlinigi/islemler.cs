using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Proje_DisKlinigi
{
    
    static class islemler
    {

        public static string tcno;
        static SqlBaglanti bgln = new SqlBaglanti();
        public static void HastaDetayRandevuCekme(DataGridView datagrid1)
        {
            //Hasta Detay formunda randevu çekme işlemi yapan fonksiyon
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select RandevuBrans as Brans,RandevuDoktor as Doktor,RandevuTarih as Tarih,RandevuSaat as Saat,HastaSikayet as Sikayet from Tbl_Randevular where HastaTC=" + tcno, bgln.baglanti());
            da.Fill(dt);
            datagrid1.DataSource = dt;
        }
        public static void DatagridviewDuzenleme(DataGridView dt)
        {
            //Renk, Boyut, Buglı yerleri düzeltme fonksiyonu
            dt.DefaultCellStyle.Font = new Font("Tahoma", 15);
            dt.DefaultCellStyle.ForeColor = Color.Black;
            dt.DefaultCellStyle.BackColor = Color.Beige;
            dt.ReadOnly = true;
            //tıklanma özelliğinde bug oluşturduğu için başlangıçtaki kısmı gizliyoruz.
            dt.RowHeadersVisible = false;
        }
        public static void HastaFormuDatagridviewBoyut(DataGridView dt,byte a)
        {
            //datagridlerin sütun boyutlarını ayarlayalım
            if (a==1)
            {
                dt.Columns[1].Width = 150;
                dt.Columns[2].Width = 120;
                dt.Columns[3].Width = 65;
                dt.Columns[4].Width = 160;
            }
            if (a == 2)
            {
                dt.Columns[0].Width = 30;
                dt.Columns[1].Width = 120;
                dt.Columns[2].Width = 75;
            }
        }
        public static void DoktorPanelineDoktorCekme(DataGridView dgv)
        {
            //doktorları datagridviewe çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Doktorlar", bgln.baglanti());
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[0].Width = 30;
            dgv.Columns[4].Width = 150;
            dgv.Columns[0].HeaderText = "Id";
            dgv.Columns[1].HeaderText = "Ad";
            dgv.Columns[2].HeaderText = "Soyad";
            dgv.Columns[3].HeaderText = "Branş";
            dgv.Columns[4].HeaderText = "Tc";
            dgv.Columns[5].HeaderText = "Şifre";
        }
        
        public static void BransPaneliBransCekme(DataGridView dgv)
        {
            // Branşları datagride çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgln.baglanti());
            da.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "Id";
            dgv.Columns[1].HeaderText = "Branş Adı";
            dgv.Columns[0].Width = 40;
        }
        
        public static void EskiRandevularDatagridview(DataGridView dgv)
        {
            // Eski randevuda şikayet bölümünün boyutunu belirliyoruz.
            dgv.Columns[0].Width = 125;
            dgv.Columns[1].Width = 75;
            dgv.Columns[2].Width = 491;
        }
    }
}
