using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServisOOP.Formlar
{
    public partial class FrmArizaListesi: Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        void listele()
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               CARİ = x.TBLCARI.AD + " " +x.TBLCARI.SOYAD,
                               PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                               x.GELISTARIH,
                               x.CIKISTARIHI,
                               x.URUNSERINO,
                               x.URUNDURUM,
                               x.URUNDURUMDETAY
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl2.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == false).ToString();
            labelControl6.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == true).ToString();
            labelControl11.Text = db.TBLURUN.Count().ToString();
            labelControl8.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Parça bekliyor").ToString();
            labelControl4.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Mesaj bekliyor").ToString();
            labelControl13.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "İptal bekliyor").ToString();

            SqlConnection baglanti = new SqlConnection(@"Data Source=CHILL;Initial Catalog=dBTEknikServis;Integrated Security=True;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY, COUNT(*) FROM TBLURUNKABUL GROUP BY URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
