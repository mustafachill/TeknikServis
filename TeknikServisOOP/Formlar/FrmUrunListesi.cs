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
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            // LİSTELEME için Tolist metodu ve Add Remove
            var degerler = db.TBLURUN.ToList();
            gridControl1.DataSource = degerler;

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
