using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciPanel : Form
    {
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        public string numara;
        int ogrenciid;
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            TxtNumara.Text= numara;
            TxtAd.Text = db.TblOgrenci.Where(x => x.OgrNumara== numara).Select(y=> y.OgrAD).FirstOrDefault();
            TxtSoyad.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrSoyad).FirstOrDefault();
            TxtSifre.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrSifre).FirstOrDefault();
            TxtMail.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrMail).FirstOrDefault();
            TxtBolum.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrBolum).FirstOrDefault().ToString();

            ogrenciid = db.TblOgrenci.Where(x => x.OgrNumara== numara).Select(y => y.OgrID).FirstOrDefault();
            var sinavnotlari = from x in db.TblNotlar
                               select new
                               {
                                   x.TblDersler.DersAd,
                                   x.Sinav1,
                                   x.Sinav2,
                                   x.Sinav3,
                                   x.Quiz1,
                                   x.Quiz2,
                                   x.Proje,
                                   x.Ortalama,
                                   x.Ogrenci
                               };
            dataGridView1.DataSource = sinavnotlari.Where(y => y.Ogrenci == ogrenciid).ToList(); ;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {   
            string mevcutsifre = TxtSifre.Text;
            string veritabanindakisifre= db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrSifre).FirstOrDefault();
            if (mevcutsifre == veritabanindakisifre)
            {
                if (TxtYeniSifre1.Text == TxtYeniSifre2.Text)
                {
                    var deger = db.TblOgrenci.Find(ogrenciid);
                    deger.OgrSifre = TxtYeniSifre1.Text;
                    db.SaveChanges();
                    MessageBox.Show("Şifre değiştirme işlemi başarılı bir şekilde değişti!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Şifreler birbiriyle uyuşmuyor!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mevcut şifreniz hatalıdır.", "HATA", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
