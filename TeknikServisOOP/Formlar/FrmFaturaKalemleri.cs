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
    public partial class FrmFaturaKalemleri: Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        TBLFATURADETAY t = new TBLFATURADETAY();

        void listeleme()
        {
            var degerler = from u in db.TBLFATURADETAY
                           select new
                           {
                               u.FATURADETAYID,
                               u.URUN,
                               u.ADET,
                               u.FIYAT,
                               u.TUTAR,
                               u.FATURAID
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        

        private void FrmFaturaKalemleri_Load(object sender, EventArgs e)
        {
            listeleme();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string id = TxtFaturaID.Text;
            string serino = TxtSeriNo.Text;
            string sirano = TxtSiraNo.Text;
            var degerler = db.TBLFATURADETAY
                .Where(x =>
                    x.FATURAID.ToString() == id ||
                    x.TBLFATURABILGI.SERI == serino ||
                    x.TBLFATURABILGI.SIRANO == sirano
                )
                .Select(u => new
                {
                    u.FATURADETAYID,
                    u.URUN,
                    u.ADET,
                    u.FIYAT,
                    u.TUTAR,
                    u.FATURAID,
                    u.TBLFATURABILGI.SERI,
                    u.TBLFATURABILGI.SIRANO
                })
                .ToList();
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
