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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            //Bransları datagride çekme
            islemler.BransPaneliBransCekme(dataGridView1);
            islemler.DatagridviewDuzenleme(dataGridView1);
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtBransAd.Text == "")
            {
                MessageBox.Show("Branş boş bırakılamaz!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                //Branş ekleme
                SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@p1)", bgln.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtBransAd.Text);
                //komut.Parameters.AddWithValue("@p2", TxtBransID.Text);
                komut.ExecuteNonQuery();
                bgln.baglanti().Close();
                islemler.BransPaneliBransCekme(dataGridView1);
                MessageBox.Show("Branş Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //data gride çift tıklama özelliği eklendi
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtBransID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtBransID.Text == "")
            {
                MessageBox.Show("Bransid boş olduğu için silme işlemi gerçekleşemiyor.", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                // Girilen id bir branşa ait olup olmadığını kontrol etme
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Branslar where Bransid=" + TxtBransID.Text, bgln.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                if (dataGridView1.CurrentCell == null)
                {
                    islemler.BransPaneliBransCekme(dataGridView1);
                    MessageBox.Show("Girilen id YANLIŞ!!!");
                }
                else
                {
                    //Branş Silme
                    SqlCommand komut = new SqlCommand("delete from Tbl_Branslar where Bransid=@p1", bgln.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtBransID.Text);
                    komut.ExecuteNonQuery();
                    bgln.baglanti().Close();
                    islemler.BransPaneliBransCekme(dataGridView1);
                    MessageBox.Show("Branş Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtBransID.Text == "" || TxtBransAd.Text == "")
            {
                MessageBox.Show("Brans adı veya Branş id boş girilemez!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                // Girilen tcnin bir doktora ait olup olmadığını kontrol etme
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Branslar where Bransid=" + TxtBransID.Text, bgln.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                if (dataGridView1.CurrentCell == null)
                {
                    islemler.BransPaneliBransCekme(dataGridView1);
                    MessageBox.Show("Girilen İD YANLIŞ!!!");
                }
                else
                {
                    //Branş Güncelleme
                    SqlCommand komut = new SqlCommand("update Tbl_Branslar set BransAd=@p1 where Bransid=@p2", bgln.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtBransAd.Text);
                    komut.Parameters.AddWithValue("@p2", TxtBransID.Text);
                    komut.ExecuteNonQuery();
                    bgln.baglanti().Close();
                    islemler.BransPaneliBransCekme(dataGridView1);
                    MessageBox.Show("Branş Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
