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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti bgln = new SqlBaglanti();

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUyeOl fr = new FrmUyeOl();
            fr.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC = @p1 and HastaSifre = @p2",bgln.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = MskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatali TC veya Şifre", "Uyarı",MessageBoxButtons.RetryCancel ,MessageBoxIcon.Warning);
            }
            bgln.baglanti().Close();
        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
