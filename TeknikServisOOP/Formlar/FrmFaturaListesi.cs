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
    public partial class FrmFaturaListesi: Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        TBLFATURABILGI t = new TBLFATURABILGI();

        void listeleme()
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               u.VERGIDAIRE,
                               CARI = u.TBLCARI.AD + " " + u.TBLCARI.SOYAD,
                               PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                           };
            gridControl1.DataSource = degerler.ToList();

            LookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD,
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from y in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     y.ID,
                                                     AD = y.AD + " " + y.SOYAD,
                                                 }).ToList();
        }
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.SERI = TxtSeri.Text;
            t.SIRANO = TxtSıraNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGIDAIRE = TxtVergiDairesi.Text;
            t.CARI = int.Parse(LookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());

            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Bilgileri Başarıyla Kaydedildi!, Kalem Girişi Yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listeleme();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
            TxtSeri.Text = gridView1.GetFocusedRowCellValue("SERI")?.ToString() ?? "";
            TxtSıraNo.Text = gridView1.GetFocusedRowCellValue("SIRANO")?.ToString() ?? "";
            TxtTarih.Text = gridView1.GetFocusedRowCellValue("TARIH")?.ToString() ?? "";
            TxtSaat.Text = gridView1.GetFocusedRowCellValue("SAAT")?.ToString() ?? "";
            TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRE")?.ToString() ?? "";
            LookUpEdit1.Text = gridView1.GetFocusedRowCellValue("CARI")?.ToString() ?? "";
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("PERSONEL")?.ToString() ?? "";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLFATURABILGI.Find(id);
            db.TBLFATURABILGI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Fatura Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listeleme();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var t = db.TBLFATURABILGI.Find(id);
            // güncelleme işlemleri
            t.SERI = TxtSeri.Text;
            t.SIRANO = TxtSıraNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGIDAIRE = TxtVergiDairesi.Text;
            t.CARI = int.Parse(LookUpEdit1.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());

            db.SaveChanges();
            MessageBox.Show("Fatura Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listeleme();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
