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
    public partial class FrmNotlar: Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        TBLNOTLARIM t = new TBLNOTLARIM();
        void listeleme()
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();

        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            t.BASLIK = TxtBaslik.Text.ToString();
            t.ICERIK = TxtIcerik.Text.ToString();
            t.DURUM = CheckEdit1.Checked;


            db.TBLNOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("NOT Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listeleme();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID")?.ToString() ?? "";
            TxtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK")?.ToString() ?? "";
            TxtIcerik.Text = gridView1.GetFocusedRowCellValue("ICERIK")?.ToString() ?? "";
            bool durum = Convert.ToBoolean(t.DURUM);
            gridView1.SetFocusedRowCellValue("DURUM", durum);
            CheckEdit1.Checked = durum;
        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID2.Text = gridView2.GetFocusedRowCellValue("ID")?.ToString() ?? "";
            TxtBaslik2.Text = gridView2.GetFocusedRowCellValue("BASLIK")?.ToString() ?? "";
            TxtIcerik2.Text = gridView2.GetFocusedRowCellValue("ICERIK")?.ToString() ?? "";
            bool durum = Convert.ToBoolean(t.DURUM);
            gridView2.SetFocusedRowCellValue("DURUM", durum);
            CheckEdit1.Checked = durum;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtID2.Text))
            {
                MessageBox.Show("Okunmayan not silinemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(TxtID2.Text);
            var deger = db.TBLNOTLARIM.Find(id);

            db.TBLNOTLARIM.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Not başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listeleme();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (CheckEdit1.Checked == true)
            {
                int id = int.Parse(TxtID.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.BASLIK = TxtBaslik.Text.ToString();
                deger.ICERIK = TxtIcerik.Text.ToString();
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listeleme();
            }
            else {
                int id = int.Parse(TxtID.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.BASLIK = TxtBaslik.Text.ToString();
                deger.ICERIK = TxtIcerik.Text.ToString();
                deger.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Not Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listeleme();
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (CheckEdit1.Checked == false)
            {
                int id = int.Parse(TxtID2.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.BASLIK = TxtBaslik2.Text.ToString();
                deger.ICERIK = TxtIcerik2.Text.ToString();
                deger.DURUM = false;
                db.SaveChanges();
                MessageBox.Show("Not Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listeleme();
            }
            else
            {
                int id = int.Parse(TxtID2.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.BASLIK = TxtBaslik2.Text.ToString();
                deger.ICERIK = TxtIcerik2.Text.ToString();
                deger.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listeleme();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
