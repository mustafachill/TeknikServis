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
    public partial class FrmDepartman: Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        TBLDEPARTMAN t = new TBLDEPARTMAN();

        void listeleme()
        {
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.ACIKLAMA
                           };


            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            listeleme();
            labelControl13.Text = db.TBLDEPARTMAN.Count().ToString();
            labelControl15.Text = db.TBLPERSONEL.Count().ToString();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD")?.ToString() ?? "";
            TxtAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA")?.ToString() ?? "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "" && TxtAciklama.Text.Length <= 50 && TxtAciklama.Text != "") {
                t.AD = TxtAd.Text.ToString();
                t.ACIKLAMA = TxtAciklama.Text.ToString();

                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("HATA, Departman Kaydedilemedi!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            // güncelleme işlemleri
            deger.AD = TxtAd.Text.ToString();
            deger.ACIKLAMA = TxtAciklama.Text.ToString();

            db.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
