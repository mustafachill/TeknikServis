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
    public partial class FrmAnasayfa : Form
    {
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        
        void musteriYorumuListeleme()
        {
            string ad1, konu1, ad2, konu2, ad3, konu3, ad4, konu4, ad5, konu5, ad6, konu6, ad7, konu7, ad8, konu8, ad9, konu9, ad10, konu10;

            // kisi
            ad1 = db.TBLILETISIM.First(x => x.ID == 1).ADSOYAD;
            konu1 = db.TBLILETISIM.First(x => x.ID == 1).KONU;
            labelControl1.Text = $"{ad1} - {konu1}";

            // kisi
            ad2 = db.TBLILETISIM.First(x => x.ID == 2).ADSOYAD;
            konu2 = db.TBLILETISIM.First(x => x.ID == 2).KONU;
            labelControl2.Text = $"{ad2} - {konu2}";

            // kisi
            ad3 = db.TBLILETISIM.First(x => x.ID == 3).ADSOYAD;
            konu3 = db.TBLILETISIM.First(x => x.ID == 3).KONU;
            labelControl3.Text = $"{ad3} - {konu3}";

            // kisi
            ad4 = db.TBLILETISIM.First(x => x.ID == 4).ADSOYAD;
            konu4 = db.TBLILETISIM.First(x => x.ID == 4).KONU;
            labelControl4.Text = $"{ad4} - {konu4}";

            // kisi
            ad5 = db.TBLILETISIM.First(x => x.ID == 5).ADSOYAD;
            konu5 = db.TBLILETISIM.First(x => x.ID == 5).KONU;
            labelControl5.Text = $"{ad5} - {konu5}";

            // kisi
            ad6 = db.TBLILETISIM.First(x => x.ID == 6).ADSOYAD;
            konu6 = db.TBLILETISIM.First(x => x.ID == 6).KONU;
            labelControl6.Text = $"{ad6} - {konu6}";

            // kisi
            ad7 = db.TBLILETISIM.First(x => x.ID == 7).ADSOYAD;
            konu7 = db.TBLILETISIM.First(x => x.ID == 7).KONU;
            labelControl7.Text = $"{ad7} - {konu7}";

            // kisi
            ad8 = db.TBLILETISIM.First(x => x.ID == 8).ADSOYAD;
            konu8 = db.TBLILETISIM.First(x => x.ID == 8).KONU;
            labelControl8.Text = $"{ad8} - {konu8}";

            // kisi
            ad9 = db.TBLILETISIM.First(x => x.ID == 9).ADSOYAD;
            konu9 = db.TBLILETISIM.First(x => x.ID == 9).KONU;
            labelControl9.Text = $"{ad9} - {konu9}";

            // kisi
            ad10 = db.TBLILETISIM.First(x => x.ID == 10).ADSOYAD;
            konu10 = db.TBLILETISIM.First(x => x.ID == 10).KONU;
            labelControl10.Text = $"{ad10} - {konu10}";
        }

        void kritiklisteleme()
        {
            var degerler = (from u in db.TBLURUN
                            select new
                            {
                                u.AD,
                                u.STOK,
                            }).Where(x => x.STOK <= 70);


            gridControl1.DataSource = degerler.ToList();
        }
        void fihristListeleme()
        {
            var degerler = (from u in db.TBLCARI
                            select new
                            {
                                u.AD,
                                u.SOYAD,
                                u.TELEFON,
                                u.MAIL
                            });


            gridControl4.DataSource = degerler.ToList();
        }
        void kategoriListeleme()
        {
            gridControl2.DataSource = db.urunkategori().ToList();
        }
        void yapilacaklarListeleme()
        {
            DateTime bugun = DateTime.Today;
            var deger = (from x in db.TBLNOTLARIM.OrderBy(y => y.ID) where (x.TARIH == bugun) select new { x.BASLIK, x.ICERIK });
            gridControl3.DataSource = deger.ToList();

        }
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            musteriYorumuListeleme();
            kritiklisteleme();
            fihristListeleme();
            kategoriListeleme();
            yapilacaklarListeleme();
        }
    }
}
