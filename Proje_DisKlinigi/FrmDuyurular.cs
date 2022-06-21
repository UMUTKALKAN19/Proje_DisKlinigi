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
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();

        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            //datagrid dizayn
            islemler.DatagridviewDuzenleme(dataGridView1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select duyuru as DUYURULAR from Tbl_Duyurular",bgln.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // SELECT top 5 * FROM Tbl_Randevular ORDER BY Randevuid DESC
        }
    }
}
