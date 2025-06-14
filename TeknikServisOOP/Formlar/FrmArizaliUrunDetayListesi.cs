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
    public partial class FrmArizaliUrunDetayListesi: Form
    {
        public FrmArizaliUrunDetayListesi()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        TBLURUNTAKIP t = new TBLURUNTAKIP();

        void listeleme()
        {
            var degerler = from x in db.TBLURUNTAKIP
                           select new
                           {
                               x.TAKIPID,
                               x.SERINO,
                               x.TARIH,
                               x.ACIKLAMA
                           };


            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmArizaliUrunDetayListesi_Load(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
