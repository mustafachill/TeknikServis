using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServisOOP.Formlar
{
    public partial class FrmYeniKategori: Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            dBTEknikServisEntities db = new dBTEknikServisEntities();
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = TxtKategori.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            FrmYeniUrun fr = new FrmYeniUrun();
            //fr.Hide();
        }
    }
}
