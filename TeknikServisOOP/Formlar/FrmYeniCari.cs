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
    public partial class FrmYeniCari: Form
    {
        public FrmYeniCari()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            dBTEknikServisEntities db = new dBTEknikServisEntities();
            TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text.ToString();
            t.SOYAD = TxtSoyad.Text.ToString();
            t.TELEFON = TxtTelefon.Text.ToString();
            t.MAIL = TxtEmail.Text.ToString();
            //t.IL = lookUpEdit3.Text.ToString();
            //t.ILCE = lookUpEdit2.Text.ToString();
            t.BANKA = TxtBanka.Text.ToString();
            t.VERGIDAIRESI = TxtVergiDairesi.Text.ToString();
            t.VERGINO = TxtVergiNo.Text.ToString();
            t.STATU = TxtCariStatu.Text.ToString();
            t.ADRES = TxtAdres.Text.ToString();
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
