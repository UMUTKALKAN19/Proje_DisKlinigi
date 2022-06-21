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
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            //datagrid dizayn
            islemler.DatagridviewDuzenleme(dataGridView1);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular",bgln.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Tarih";
            dataGridView1.Columns[2].HeaderText = "Saat";
            dataGridView1.Columns[3].HeaderText = "Branş";
            dataGridView1.Columns[4].HeaderText = "Doktorlar";
            dataGridView1.Columns[5].HeaderText = "Durum";
            dataGridView1.Columns[5].HeaderText = "Hasta TC";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 65;
        }

        public string sekreterad,sekretertcno;
        string randevudurum;
        public bool randevu;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //data gridden verinin idsini sekreter detay formuna çekiyoruz
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            FrmSekreterDetay sekreterform = new FrmSekreterDetay();

            sekreterform.Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            sekreterform.MskTarih.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sekreterform.MskSaat.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            sekreterform.CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            sekreterform.CmbDoktor.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            sekreterform.label9.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            randevudurum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            sekreterform.Show();
            if (randevudurum == "1")
            {
                sekreterform.ChkDurum.Checked = true;
            }
            else if (randevudurum == "0")
            {
                sekreterform.ChkDurum.Checked = false;
            }
            // Sekreterin adını soyadını tcsini tekrardan sekreter detay formuna gönderiyoruz.
            sekreterform.LblAdSoyad.Text = sekreterad;
            sekreterform.LblTc.Text = sekretertcno;
            this.Hide();
        }
    }
}
