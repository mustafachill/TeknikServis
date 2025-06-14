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
    public partial class FrmArizaDetaylar: Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            dBTEknikServisEntities db = new dBTEknikServisEntities();
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = richTextBox1.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SERINO = TxtSeriNo.Text;
            db.TBLURUNTAKIP.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı Ürün Detayları Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
