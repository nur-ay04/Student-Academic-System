using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmHarita : Form
    {
        public FrmHarita()
        {
            InitializeComponent();
        }

        private void PnlBolumListesi_Click(object sender, EventArgs e)
        {
            FrmBolumListesi frm = new FrmBolumListesi();
            frm.Show();
        }

        private void PnlYeniBolum_Click(object sender, EventArgs e)
        {
            FrmBolumler frm = new FrmBolumler();
            frm.Show();
        }

        private void PnlNotlarFormu_Click(object sender, EventArgs e)
        {
            FrmNotlar frm = new FrmNotlar();
            frm.Show();
        }

        private void PnlOgrenciFormu_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
        }

        private void PnlOgrenciKaydi_Click(object sender, EventArgs e)
        {
            FrmOgrenciKayit frm = new FrmOgrenciKayit();
            frm.Show();
        }

        private void PnlDersListesi_Click(object sender, EventArgs e)
        {
            FrmDersListesi frm = new FrmDersListesi();
            frm.Show();
        }



        private void PnlCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PnlYeniDers_Click(object sender, EventArgs e)
        {
            FrmYeniDers frm = new FrmYeniDers();
            frm.Show();
        }

        private void PnlYardim_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje, veri tabanına dayalı bir uygulama olarak kendimi geliştirmek amacıyla hazırlanmıştır. " +
                "Proje kapsamında akademisyenler ve öğrenciler, giriş ekranında numara ve şifrelerini kullanarak " +
                "kendi panellerine yönlendirilmektedir. " +
                "Akademisyen panelinde öğrenci, ders, bölüm ve sınav notları gibi işlemler kolaylıkla yönetilebilir. " +
                "Sisteme giriş yapan öğrenciler ise yalnızca kendi bilgilerine ait sınav notlarını görüntüleyebilir.",
                "YARDIM PENCERESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public string numara;
        private void FrmHarita_Load(object sender, EventArgs e)
        {
            TxtNumara.Text = numara;

        }
    }
}
