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
    public partial class FrmYeniPersonel: Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            dBTEknikServisEntities db = new dBTEknikServisEntities();
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = TxtAd.Text.ToString();
            t.SOYAD = TxtSoyad.Text.ToString();
            t.TELEFON = TxtTelefon.Text.ToString();
            t.MAIL = TxtEmail.Text.ToString();
            //t.IL = lookUpEdit3.Text.ToString();
            //t.ILCE = lookUpEdit2.Text.ToString();
            t.DEPARTMAN = byte.Parse(TxtDepartman.Text.ToString());
            t.FOTOGRAF = TxtFotograf.Text.ToString();
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
