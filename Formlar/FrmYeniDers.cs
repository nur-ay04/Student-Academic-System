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
    public partial class FrmYeniDers : Form
    {
        public FrmYeniDers()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {   if (!string.IsNullOrWhiteSpace(TxtDersAdi.Text))
            {
                TblDersler td = new TblDersler();
                td.DersAd = TxtDersAdi.Text;
                db.TblDersler.Add(td);
                db.SaveChanges();
                MessageBox.Show("Ders ekleme işlemi başarılı bir şekilde gerçekleşti.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir ders ismi yazınız!","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
