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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        

        SqlBaglanti bgln = new SqlBaglanti();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTC = @p1 and DoktorSifre = @p2", bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmDoktorDetay fr = new FrmDoktorDetay();
                fr.tc = MskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali TC veya Şifre", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            bgln.baglanti().Close();
        }
    }
}
