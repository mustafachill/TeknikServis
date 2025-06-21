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
    public partial class FrmPersonel: Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        TBLPERSONEL t = new TBLPERSONEL();

        void listeleme()
        {
            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.DEPARTMAN,
                               u.FOTOGRAF,
                               u.MAIL,
                               u.TELEFON
                           };


            gridControl1.DataSource = degerler.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                 select new
                                                 {
                                                     x.AD,
                                                 }).ToList();


        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            listeleme();


            // 1. personel
            string ad1 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 1)?.AD ?? "";
            string soyad1 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 1)?.SOYAD ?? "";
            labelControl4.Text = $"{ad1} {soyad1}";
            labelControl5.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 1)?.TBLDEPARTMAN.AD.ToString() ?? "";
            labelControl10.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 1)?.MAIL ?? "";
            labelControl8.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 1)?.TELEFON ?? "";

            // 2. personel
            string ad2 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 2)?.AD ?? "";
            string soyad2 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 2)?.SOYAD ?? "";
            labelControl18.Text = $"{ad2} {soyad2}";
            labelControl16.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 2)?.TBLDEPARTMAN.AD.ToString() ?? "";
            labelControl12.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 2)?.MAIL ?? "";
            labelControl14.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 2)?.TELEFON ?? "";

            // 3. personel
            string ad3 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 3)?.AD ?? "";
            string soyad3 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 3)?.SOYAD ?? "";
            labelControl26.Text = $"{ad3} {soyad3}";
            labelControl24.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 3)?.TBLDEPARTMAN.AD.ToString() ?? "";
            labelControl20.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 3)?.MAIL ?? "";
            labelControl22.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 3)?.TELEFON ?? "";

            // 4. personel
            string ad4 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 4)?.AD ?? "";
            string soyad4 = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 4)?.SOYAD ?? "";
            labelControl34.Text = $"{ad4} {soyad4}";
            labelControl32.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 4)?.TBLDEPARTMAN.AD.ToString() ?? "";
            labelControl28.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 4)?.MAIL ?? "";
            labelControl30.Text = db.TBLPERSONEL.FirstOrDefault(x => x.ID == 4)?.TELEFON ?? "";


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD")?.ToString() ?? "";
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD")?.ToString() ?? "";
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("DEPARTMAN")?.ToString() ?? "";
            TxtFotograf.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF")?.ToString() ?? "";
            TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL")?.ToString() ?? "";
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON")?.ToString() ?? "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            t.AD = TxtAd.Text.ToString();
            t.SOYAD = TxtSoyad.Text.ToString();
            //t.DEPARTMAN = byte.Parse(lookUpEdit1.Text.ToString());
            t.FOTOGRAF = TxtFotograf.Text.ToString();
            t.MAIL = TxtMail.Text.ToString();
            t.TELEFON = TxtTelefon.Text.ToString();


            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLPERSONEL.Find(id);
            // güncelleme işlemleri
            deger.AD = TxtAd.Text.ToString();
            deger.SOYAD = TxtSoyad.Text.ToString();
            //deger.DEPARTMAN = byte.Parse(lookUpEdit1.Text.ToString());
            deger.FOTOGRAF = TxtFotograf.Text.ToString();
            deger.MAIL = TxtMail.Text.ToString();
            deger.TELEFON = TxtTelefon.Text.ToString();

            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listeleme();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
