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
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciKayit : Form
    {
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }
        //Data Source=LAPTOP-QL9SNOH8\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Encrypt=False;Trust Server Certificate=True
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-QL9SNOH8\\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Encrypt=False;");
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblBolum", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAd.Text) || string.IsNullOrEmpty(TxtSoyad.Text) ||
                string.IsNullOrEmpty(TxtNumara.Text) || string.IsNullOrEmpty(TxtSifre.Text) ||
                string.IsNullOrEmpty(TxtSifreTekrar.Text) || string.IsNullOrEmpty(TxtMail.Text) ||
                string.IsNullOrEmpty(TxtResim.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (TxtSifre.Text == TxtSifreTekrar.Text)
            {
                TblOgrenci t = new TblOgrenci();
                t.OgrAD = TxtAd.Text;
                t.OgrSoyad = TxtSoyad.Text;
                t.OgrNumara = TxtNumara.Text;
                t.OgrSifre = TxtSifre.Text;
                t.OgrMail = TxtMail.Text;
                t.OgrResim = TxtResim.Text;
                t.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());  // Ders seçimi

                db.TblOgrenci.Add(t);
                db.SaveChanges();
                MessageBox.Show("Öğrenci bilgileri sisteme başarılı bir şekilde kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen şifreler birbiriyle aynı olacak şekilde yeniden girin.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResim.Text= openFileDialog1.FileName;
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
