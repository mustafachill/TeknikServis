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
    public partial class FrmMarkalar: Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();


        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();

            labelControl3.Text = db.TBLURUN.Count().ToString();
            labelControl2.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl8.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            chartControl1.Series["Series 1"].Points.AddPoint("Siemens",4);
            chartControl1.Series["Series 1"].Points.AddPoint("Monster",4);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik",4);
            chartControl1.Series["Series 1"].Points.AddPoint("MSI",4);
            chartControl1.Series["Series 1"].Points.AddPoint("Asus",4);

            chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisayar", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("TV", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Telefon", 4);

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }
    }
}
