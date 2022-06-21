
namespace Proje_DisKlinigi
{
    partial class FrmSekreterDetay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSekreterDetay));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblTc = new System.Windows.Forms.Label();
            this.LblAdSoyad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDuyuruYayinla = new System.Windows.Forms.Button();
            this.RchDuyuru = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbDoktor = new System.Windows.Forms.ComboBox();
            this.CmbBrans = new System.Windows.Forms.ComboBox();
            this.ChkDurum = new System.Windows.Forms.CheckBox();
            this.MskTc = new System.Windows.Forms.MaskedTextBox();
            this.MskTarih = new System.Windows.Forms.MaskedTextBox();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.Txtid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MskSaat = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BtnDuyurular = new System.Windows.Forms.Button();
            this.BtnCikis = new System.Windows.Forms.Button();
            this.BtnBranslarVeDoktorlarListesi = new System.Windows.Forms.Button();
            this.BtnRandevuPanel = new System.Windows.Forms.Button();
            this.BtnBranşPanel = new System.Windows.Forms.Button();
            this.BtnDoktorPanel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblTc);
            this.groupBox1.Controls.Add(this.LblAdSoyad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kişi Bilgi";
            // 
            // LblTc
            // 
            this.LblTc.AutoSize = true;
            this.LblTc.Location = new System.Drawing.Point(134, 70);
            this.LblTc.Name = "LblTc";
            this.LblTc.Size = new System.Drawing.Size(25, 23);
            this.LblTc.TabIndex = 13;
            this.LblTc.Text = "tc";
            // 
            // LblAdSoyad
            // 
            this.LblAdSoyad.AutoSize = true;
            this.LblAdSoyad.Location = new System.Drawing.Point(134, 35);
            this.LblAdSoyad.Name = "LblAdSoyad";
            this.LblAdSoyad.Size = new System.Drawing.Size(75, 23);
            this.LblAdSoyad.TabIndex = 12;
            this.LblAdSoyad.Text = "adsoyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "TC Kimlik No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ad Soyad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDuyuruYayinla);
            this.groupBox2.Controls.Add(this.RchDuyuru);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 299);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duyuru Oluştur";
            // 
            // BtnDuyuruYayinla
            // 
            this.BtnDuyuruYayinla.Location = new System.Drawing.Point(19, 238);
            this.BtnDuyuruYayinla.Name = "BtnDuyuruYayinla";
            this.BtnDuyuruYayinla.Size = new System.Drawing.Size(223, 40);
            this.BtnDuyuruYayinla.TabIndex = 1;
            this.BtnDuyuruYayinla.Text = "Duyuru Yayınla";
            this.BtnDuyuruYayinla.UseVisualStyleBackColor = true;
            this.BtnDuyuruYayinla.Click += new System.EventHandler(this.BtnDuyuruYayinla_Click);
            // 
            // RchDuyuru
            // 
            this.RchDuyuru.Location = new System.Drawing.Point(19, 39);
            this.RchDuyuru.Name = "RchDuyuru";
            this.RchDuyuru.Size = new System.Drawing.Size(223, 193);
            this.RchDuyuru.TabIndex = 0;
            this.RchDuyuru.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.CmbDoktor);
            this.groupBox3.Controls.Add(this.CmbBrans);
            this.groupBox3.Controls.Add(this.ChkDurum);
            this.groupBox3.Controls.Add(this.MskTc);
            this.groupBox3.Controls.Add(this.MskTarih);
            this.groupBox3.Controls.Add(this.BtnGuncelle);
            this.groupBox3.Controls.Add(this.BtnKaydet);
            this.groupBox3.Controls.Add(this.Txtid);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.MskSaat);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(274, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 412);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Randevu Oluştur";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 23);
            this.label9.TabIndex = 26;
            this.label9.Visible = false;
            // 
            // CmbDoktor
            // 
            this.CmbDoktor.FormattingEnabled = true;
            this.CmbDoktor.Location = new System.Drawing.Point(97, 204);
            this.CmbDoktor.Name = "CmbDoktor";
            this.CmbDoktor.Size = new System.Drawing.Size(158, 31);
            this.CmbDoktor.TabIndex = 6;
            // 
            // CmbBrans
            // 
            this.CmbBrans.FormattingEnabled = true;
            this.CmbBrans.Location = new System.Drawing.Point(97, 163);
            this.CmbBrans.Name = "CmbBrans";
            this.CmbBrans.Size = new System.Drawing.Size(158, 31);
            this.CmbBrans.TabIndex = 5;
            this.CmbBrans.SelectedIndexChanged += new System.EventHandler(this.CmbBrans_SelectedIndexChanged);
            // 
            // ChkDurum
            // 
            this.ChkDurum.AutoSize = true;
            this.ChkDurum.Location = new System.Drawing.Point(97, 286);
            this.ChkDurum.Name = "ChkDurum";
            this.ChkDurum.Size = new System.Drawing.Size(84, 27);
            this.ChkDurum.TabIndex = 8;
            this.ChkDurum.Text = "Durum";
            this.ChkDurum.UseVisualStyleBackColor = true;
            // 
            // MskTc
            // 
            this.MskTc.Location = new System.Drawing.Point(97, 249);
            this.MskTc.Mask = "00000000000";
            this.MskTc.Name = "MskTc";
            this.MskTc.Size = new System.Drawing.Size(158, 31);
            this.MskTc.TabIndex = 7;
            this.MskTc.ValidatingType = typeof(int);
            // 
            // MskTarih
            // 
            this.MskTarih.Location = new System.Drawing.Point(97, 80);
            this.MskTarih.Mask = "00/00/0000";
            this.MskTarih.Name = "MskTarih";
            this.MskTarih.Size = new System.Drawing.Size(158, 31);
            this.MskTarih.TabIndex = 3;
            this.MskTarih.ValidatingType = typeof(System.DateTime);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Location = new System.Drawing.Point(97, 359);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(158, 34);
            this.BtnGuncelle.TabIndex = 10;
            this.BtnGuncelle.Text = "Güncelle";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Location = new System.Drawing.Point(97, 316);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(158, 34);
            this.BtnKaydet.TabIndex = 9;
            this.BtnKaydet.Text = "Kaydet";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // Txtid
            // 
            this.Txtid.Location = new System.Drawing.Point(97, 38);
            this.Txtid.Name = "Txtid";
            this.Txtid.Size = new System.Drawing.Size(158, 31);
            this.Txtid.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 23);
            this.label5.TabIndex = 25;
            this.label5.Text = "TC:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 23);
            this.label6.TabIndex = 24;
            this.label6.Text = "Branş:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tarih:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "İd:";
            // 
            // MskSaat
            // 
            this.MskSaat.Location = new System.Drawing.Point(97, 119);
            this.MskSaat.Mask = "00:00";
            this.MskSaat.Name = "MskSaat";
            this.MskSaat.Size = new System.Drawing.Size(158, 31);
            this.MskSaat.TabIndex = 4;
            this.MskSaat.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Doktor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Saat:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BtnDuyurular);
            this.groupBox6.Controls.Add(this.BtnCikis);
            this.groupBox6.Controls.Add(this.BtnBranslarVeDoktorlarListesi);
            this.groupBox6.Controls.Add(this.BtnRandevuPanel);
            this.groupBox6.Controls.Add(this.BtnBranşPanel);
            this.groupBox6.Controls.Add(this.BtnDoktorPanel);
            this.groupBox6.Location = new System.Drawing.Point(15, 430);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(537, 140);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hızlı Erişim";
            // 
            // BtnDuyurular
            // 
            this.BtnDuyurular.Location = new System.Drawing.Point(386, 74);
            this.BtnDuyurular.Name = "BtnDuyurular";
            this.BtnDuyurular.Size = new System.Drawing.Size(115, 60);
            this.BtnDuyurular.TabIndex = 34;
            this.BtnDuyurular.Text = "Duyurlar";
            this.BtnDuyurular.UseVisualStyleBackColor = true;
            this.BtnDuyurular.Click += new System.EventHandler(this.BtnDuyurular_Click);
            // 
            // BtnCikis
            // 
            this.BtnCikis.Location = new System.Drawing.Point(386, 34);
            this.BtnCikis.Name = "BtnCikis";
            this.BtnCikis.Size = new System.Drawing.Size(115, 34);
            this.BtnCikis.TabIndex = 7;
            this.BtnCikis.Text = "Çıkış";
            this.BtnCikis.UseVisualStyleBackColor = true;
            this.BtnCikis.Click += new System.EventHandler(this.BtnCikis_Click);
            // 
            // BtnBranslarVeDoktorlarListesi
            // 
            this.BtnBranslarVeDoktorlarListesi.Location = new System.Drawing.Point(26, 74);
            this.BtnBranslarVeDoktorlarListesi.Name = "BtnBranslarVeDoktorlarListesi";
            this.BtnBranslarVeDoktorlarListesi.Size = new System.Drawing.Size(233, 60);
            this.BtnBranslarVeDoktorlarListesi.TabIndex = 7;
            this.BtnBranslarVeDoktorlarListesi.Text = "Branşlar Ve Doktorlar Listesi";
            this.BtnBranslarVeDoktorlarListesi.UseVisualStyleBackColor = true;
            this.BtnBranslarVeDoktorlarListesi.Click += new System.EventHandler(this.BtnBranslarVeDoktorlarListesi_Click);
            // 
            // BtnRandevuPanel
            // 
            this.BtnRandevuPanel.Location = new System.Drawing.Point(265, 74);
            this.BtnRandevuPanel.Name = "BtnRandevuPanel";
            this.BtnRandevuPanel.Size = new System.Drawing.Size(115, 60);
            this.BtnRandevuPanel.TabIndex = 33;
            this.BtnRandevuPanel.Text = "Randevu Paneli";
            this.BtnRandevuPanel.UseVisualStyleBackColor = true;
            this.BtnRandevuPanel.Click += new System.EventHandler(this.BtnRandevuPanel_Click);
            // 
            // BtnBranşPanel
            // 
            this.BtnBranşPanel.Location = new System.Drawing.Point(265, 34);
            this.BtnBranşPanel.Name = "BtnBranşPanel";
            this.BtnBranşPanel.Size = new System.Drawing.Size(115, 34);
            this.BtnBranşPanel.TabIndex = 32;
            this.BtnBranşPanel.Text = "Branş Paneli";
            this.BtnBranşPanel.UseVisualStyleBackColor = true;
            this.BtnBranşPanel.Click += new System.EventHandler(this.BtnBranşPanel_Click);
            // 
            // BtnDoktorPanel
            // 
            this.BtnDoktorPanel.Location = new System.Drawing.Point(26, 34);
            this.BtnDoktorPanel.Name = "BtnDoktorPanel";
            this.BtnDoktorPanel.Size = new System.Drawing.Size(233, 34);
            this.BtnDoktorPanel.TabIndex = 31;
            this.BtnDoktorPanel.Text = "Doktor Paneli";
            this.BtnDoktorPanel.UseVisualStyleBackColor = true;
            this.BtnDoktorPanel.Click += new System.EventHandler(this.BtnDoktorPanel_Click);
            // 
            // FrmSekreterDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(566, 582);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmSekreterDetay";
            this.Text = "Sekreter Paneli";
            this.Load += new System.EventHandler(this.FrmSekreterDetay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnDuyuruYayinla;
        private System.Windows.Forms.RichTextBox RchDuyuru;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button BtnRandevuPanel;
        private System.Windows.Forms.Button BtnBranşPanel;
        private System.Windows.Forms.Button BtnDoktorPanel;
        private System.Windows.Forms.Button BtnCikis;
        private System.Windows.Forms.Button BtnBranslarVeDoktorlarListesi;
        private System.Windows.Forms.Button BtnDuyurular;
        public System.Windows.Forms.TextBox Txtid;
        public System.Windows.Forms.MaskedTextBox MskSaat;
        public System.Windows.Forms.MaskedTextBox MskTc;
        public System.Windows.Forms.MaskedTextBox MskTarih;
        public System.Windows.Forms.CheckBox ChkDurum;
        public System.Windows.Forms.ComboBox CmbDoktor;
        public System.Windows.Forms.ComboBox CmbBrans;
        public System.Windows.Forms.Label LblAdSoyad;
        public System.Windows.Forms.Label LblTc;
        public System.Windows.Forms.Label label9;
    }
}