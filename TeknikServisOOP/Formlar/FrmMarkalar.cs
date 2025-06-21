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
using System.Data.SqlClient;

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
            labelControl6.Text = db.maksurunmarka2().FirstOrDefault().Marka;


            // graph
            // chartControl1.Series["Series 1"].Points.AddPoint("Siemens",4);

            SqlConnection baglanti = new SqlConnection(@"Data Source=CHILL;Initial Catalog=dBTEknikServis;Integrated Security=True;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT MARKA, COUNT(*) FROM TBLURUN GROUP BY MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT TBLKATEGORI.AD,COUNT(*) FROM TBLURUN\r\nINNER JOIN TBLKATEGORI ON TBLKATEGORI.ID = TBLURUN.KATEGORI\r\nGROUP BY TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }
    }
}
