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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            //Datagrid düzen
            islemler.DatagridviewDuzenleme(dataGridView1);
            //Doktorları DataGride Çekme
            islemler.DoktorPanelineDoktorCekme(dataGridView1);

            // branşları comboboxa çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgln.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgln.baglanti().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            // doktor eklenirken alanların boş veya eksik doldurulması kontrolü
            if (TxtAd.Text == "" || TxtSoyad.Text == "" || CmbBrans.Text == "")
            {
                MessageBox.Show("Ad, soyad veya branş boş bırakılamaz!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (MskTC.Text.Length < 11)
                {
                    MessageBox.Show("TC hanesi 11 karakterden az olamaz!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (TxtSifre.Text.Length < 4)
                    {
                        MessageBox.Show("Şifre 4 karakterden büyük olmalıdır!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //doktorları ekleme işlemi
                        SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", bgln.baglanti());
                        komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                        komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                        komut.Parameters.AddWithValue("@p3", CmbBrans.Text);
                        komut.Parameters.AddWithValue("@p4", MskTC.Text);
                        komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
                        komut.ExecuteNonQuery();
                        bgln.baglanti().Close();
                        MessageBox.Show("Doktor Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islemler.DoktorPanelineDoktorCekme(dataGridView1);
                    }
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagrid'de çift tıkladığımız satırdaki verileri alıp sil ve güncelle butonları için kullanacağız
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (MskTC.Text.Length < 11)
            {
                MessageBox.Show("Tc hanesi 11 karakterden az olamaz!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                // Girilen tcnin bir doktora ait olup olmadığını kontrol etme
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Doktorlar where DoktorTc=" + MskTC.Text, bgln.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                if (dataGridView1.CurrentCell == null)
                {
                    islemler.DoktorPanelineDoktorCekme(dataGridView1);
                    MessageBox.Show("Girilen Tc YANLIŞ!!!");
                }
                else
                {
                    // Doktoru silme
                    SqlCommand komut = new SqlCommand("Delete  from Tbl_Doktorlar where DoktorTc = @p1 ", bgln.baglanti());
                    komut.Parameters.AddWithValue("@p1", MskTC.Text);
                    komut.ExecuteNonQuery();
                    bgln.baglanti().Close();
                    MessageBox.Show("Doktor Başarıyla Silindi!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    islemler.DoktorPanelineDoktorCekme(dataGridView1);
                }
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || TxtSoyad.Text == "" || CmbBrans.Text == "")
            {
                MessageBox.Show("Ad, soyad veya branş boş bırakılamaz!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (MskTC.Text.Length < 11)
                {
                    MessageBox.Show("TC hanesi 11 karakterden az olamaz!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (TxtSifre.Text.Length < 4)
                    {
                        MessageBox.Show("Şifre 4 karakterden büyük olmalıdır!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Girilen tcnin bir doktora ait olup olmadığını kontrol etme
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Doktorlar where DoktorTc=" + MskTC.Text, bgln.baglanti());
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        if (dataGridView1.CurrentCell == null)
                        {
                            islemler.DoktorPanelineDoktorCekme(dataGridView1);
                            MessageBox.Show("Girilen Tc YANLIŞ!!!");
                        }
                        else
                        {
                            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p5 where DoktorTC=@p4", bgln.baglanti());
                            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                            komut.Parameters.AddWithValue("@p3", CmbBrans.Text);
                            komut.Parameters.AddWithValue("@p4", MskTC.Text);
                            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
                            komut.ExecuteNonQuery();
                            bgln.baglanti().Close();
                            MessageBox.Show("Doktor Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            islemler.DoktorPanelineDoktorCekme(dataGridView1);
                        }  
                    }
                }
            }
        }
    }
}
