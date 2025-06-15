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
    public partial class FrmAnasayfa: Form
    {
        dBTEknikServisEntities db = new dBTEknikServisEntities();

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
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            kritiklisteleme();
            fihristListeleme();
        }
    }
}
