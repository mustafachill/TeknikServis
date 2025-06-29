using DevExpress.PivotGrid.OLAP.AdoWrappers;
using DevExpress.Utils.DirectXPaint.Svg;
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
            
            MessageBox.Show("Arızalı Ürün Detayları Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //2. GÜNCELLEME
            TBLURUNKABUL tb = new TBLURUNKABUL();
            tb.URUNDURUMDETAY = comboBox1.Text;
            db.SaveChanges();
        }

        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {

        }
    }
}
