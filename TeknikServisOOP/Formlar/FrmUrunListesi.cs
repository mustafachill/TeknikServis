using DevExpress.CodeParser;
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
    public partial class FrmUrunListesi: Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        dBTEknikServisEntities db = new dBTEknikServisEntities();
        void metot1()
        {
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               kategori = u.TBLKATEGORI.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            // LİSTELEME için Tolist metodu ve Add Remove


            //var degerler = db.TBLURUN.ToList();
            metot1();
            LookUpEdit1.Properties.DataSource = db.TBLKATEGORI.ToList();

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try {
                TBLURUN t = new TBLURUN();
                t.AD = TxtUrunAd.Text;
                t.MARKA = TxtMarka.Text;
                t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
                t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
                t.STOK = short.Parse(TxtStok.Text);
                t.DURUM = false;
                t.KATEGORI = byte.Parse(LookUpEdit1.EditValue.ToString());
                db.TBLURUN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ürün Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) {
                MessageBox.Show("Ürün Kaydedilirken Hata", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            TxtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            LookUpEdit1.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLURUN.Find(id);
            // güncelleme işlemleri
            deger.AD = TxtUrunAd.Text.ToString();
            deger.STOK = short.Parse(TxtStok.Text);
            deger.MARKA = TxtMarka.Text.ToString();
            deger.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            deger.KATEGORI = byte.Parse(LookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
