using DevExpress.XtraEditors;
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
    public partial class FrmYeniArizaliUrunKaydi: Form
    {
        public FrmYeniArizaliUrunKaydi()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        private void FrmYeniArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AdSoyad = x.AD + " " + x.SOYAD
                                                 }).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();
            t.CARI = int.Parse(TxtID.Text.ToString());
            t.GELISTARIH = DateTime.Parse(TxtTarih.Text);
            t.PERSONEL = short.Parse(LookUpEdit1.EditValue.ToString());
            t.URUNSERINO = TxtSeriNo.Text;
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kabul Edildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
