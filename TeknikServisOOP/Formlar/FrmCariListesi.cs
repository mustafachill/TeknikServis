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
    public partial class FrmCariListesi: Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        TBLCARI t = new TBLCARI();

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLCARI.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD")?.ToString() ?? "";
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD")?.ToString() ?? "";
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON")?.ToString() ?? "";
            TxtEmail.Text = gridView1.GetFocusedRowCellValue("MAIL")?.ToString() ?? "";
            lookUpEdit3.Text = gridView1.GetFocusedRowCellValue("IL")?.ToString() ?? "";
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("ILCE")?.ToString() ?? "";
            TxtBanka.Text = gridView1.GetFocusedRowCellValue("BANKA")?.ToString() ?? "";
            TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRESI")?.ToString() ?? "";
            TxtVergiNo.Text = gridView1.GetFocusedRowCellValue("VERGINO")?.ToString() ?? "";
            TxtCariStatu.Text = gridView1.GetFocusedRowCellValue("STATU")?.ToString() ?? "";
            TxtAdres.Text = gridView1.GetFocusedRowCellValue("ADRES")?.ToString() ?? "";

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            t.AD = TxtAd.Text.ToString();
            t.SOYAD = TxtSoyad.Text.ToString();
            t.TELEFON = TxtTelefon.Text.ToString();
            t.MAIL = TxtEmail.Text.ToString();
            //t.IL = lookUpEdit3.Text.ToString();
            //t.ILCE = lookUpEdit2.Text.ToString();
            t.BANKA = TxtBanka.Text.ToString();
            t.VERGIDAIRESI = TxtVergiDairesi.Text.ToString();
            t.VERGINO = TxtVergiNo.Text.ToString();
            t.STATU = TxtCariStatu.Text.ToString();
            t.ADRES = TxtAdres.Text.ToString();
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cari Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Cari Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLCARI.Find(id);
            // güncelleme işlemleri
            deger.AD = TxtAd.Text.ToString();
            deger.SOYAD = TxtSoyad.Text.ToString();
            deger.TELEFON = TxtTelefon.Text.ToString();
            deger.MAIL = TxtEmail.Text.ToString();
            //deger.IL = lookUpEdit3.Text.ToString();
            //deger.ILCE = lookUpEdit2.Text.ToString();
            deger.BANKA = TxtBanka.Text.ToString();
            deger.VERGIDAIRESI = TxtVergiDairesi.Text.ToString();
            deger.VERGINO = TxtVergiNo.Text.ToString();
            deger.STATU = TxtCariStatu.Text.ToString();
            deger.ADRES = TxtAdres.Text.ToString();
            db.SaveChanges();
            MessageBox.Show("Cari Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLCARI.ToList();
        }
    }
}
