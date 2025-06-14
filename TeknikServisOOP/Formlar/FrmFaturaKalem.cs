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
    public partial class FrmFaturaKalem: Form
    {
        public FrmFaturaKalem()
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
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.URUN = TxtUrun.Text;
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaID.EditValue.ToString());

            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalem Bilgileri Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listeleme();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("FATURADETAYID")?.ToString() ?? "";
            TxtUrun.Text = gridView1.GetFocusedRowCellValue("URUN")?.ToString() ?? "";
            TxtAdet.Text = gridView1.GetFocusedRowCellValue("ADET")?.ToString() ?? "";
            TxtFiyat.Text = gridView1.GetFocusedRowCellValue("FIYAT")?.ToString() ?? "";
            TxtTutar.Text = gridView1.GetFocusedRowCellValue("TUTAR")?.ToString() ?? "";
            TxtFaturaID.Text = gridView1.GetFocusedRowCellValue("FATURAID")?.ToString() ?? "";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLFATURADETAY.Find(id);
            db.TBLFATURADETAY.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalem Bilgileri Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listeleme();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var t = db.TBLFATURADETAY.Find(id);
            // güncelleme işlemleri
            t.URUN = TxtUrun.Text;
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaID.EditValue.ToString());

            db.SaveChanges();
            MessageBox.Show("Fatura Kalem Bilgileri Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listeleme();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
