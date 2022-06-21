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
    public partial class FrmBranslarVeDoktorlarListesi : Form
    {
        public FrmBranslarVeDoktorlarListesi()
        {
            InitializeComponent();
        }
        SqlBaglanti bgln = new SqlBaglanti();
        private void FrmBranslarVeDoktorlarListesi_Load(object sender, EventArgs e)
        {
            //datagridlerin dizaynı değiştirelim
            islemler.DatagridviewDuzenleme(dataGridView1);
            islemler.DatagridviewDuzenleme(dataGridView2);

            //bransları datagride çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd from Tbl_Branslar",bgln.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Branşlar";
            

            //doktorları datagride çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd+' '+DoktorSoyad) as Doktorlar, DoktorBrans from Tbl_Doktorlar", bgln.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns[1].HeaderText = "Branşlar";

        }
    }
}
