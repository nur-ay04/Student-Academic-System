using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;


namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        void listele()
        { 
            var deger = from x in db.TblOgrenci select new  
            {
                x.OgrID,
                x.OgrAD,
                x.OgrSoyad,
                x.OgrNumara,
                x.OgrMail,
                x.OgrSifre,
                x.OgrResim,
                x.OgrBolum,
                x.OgrDurum,
                x.TblBolum.BolumAd
            };
            dataGridView1.DataSource = deger.Where(x => x.OgrDurum == true).ToList();

        }
        //SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-QL9SNOH8\\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Encrypt=False;");
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            listele();
            var bolumler = db.TblBolum.ToList();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("Select * from TblBolum", baglanti);
            //SqlDataAdapter da = new SqlDataAdapter(komut);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            //comboBox1.DataSource = dt;
            comboBox1.DataSource = bolumler;

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtResim.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //var bolumID = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //comboBox1.SelectedValue = bolumID;
            // Bölüm ID'sini kontrol et
            var bolumID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            //MessageBox.Show("Bölüm ID: " + bolumID.ToString());  // Bu satır eklenerek kontrol edelim

            comboBox1.SelectedValue = bolumID;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var x = db.TblOgrenci.Find(id);
            x.OgrDurum = false;
            db.SaveChanges();
            MessageBox.Show("Öğrenci başarıyla sistemden silindi, silinin öğrencilere pasif listesinden erişebilirsiniz.", "BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResim.Text = openFileDialog1.FileName;
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var x = db.TblOgrenci.Find(id);
            x.OgrAD = TxtAd.Text;
            x.OgrSoyad = TxtSoyad.Text;
            x.OgrNumara = TxtNumara.Text;
            x.OgrMail = TxtMail.Text;
            x.OgrSifre = TxtSifre.Text;
            x.OgrResim = TxtResim.Text;
            //x.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
            int bolumID = Convert.ToInt32(comboBox1.SelectedValue);
            x.OgrBolum = bolumID;
            db.SaveChanges();
            MessageBox.Show("Öğrenci başarıyla güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }



        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
