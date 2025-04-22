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

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-QL9SNOH8\\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Encrypt=False;");


        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblOgrenci where OgrNumara = @p1 and OgrSifre = @p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtNumara.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmOgrenciPanel frm = new FrmOgrenciPanel();
                frm.numara = TxtNumara.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                dr.Close();
                SqlCommand komutAkademisyen = new SqlCommand("Select * from TblAkademisyen where AkademisyenNumara = @p1 and AkademisyenSifre = @p2", baglanti);
                komutAkademisyen.Parameters.AddWithValue("@p1", TxtNumara.Text);
                komutAkademisyen.Parameters.AddWithValue("@p2", TxtSifre.Text);
                SqlDataReader drAkademisyen = komutAkademisyen.ExecuteReader();

                if (drAkademisyen.Read())
                {

                    FrmHarita frmHarita = new FrmHarita();
                    frmHarita.numara = TxtNumara.Text;
                    frmHarita.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Geçersiz numara veya şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            baglanti.Close();

        }
    }
}
