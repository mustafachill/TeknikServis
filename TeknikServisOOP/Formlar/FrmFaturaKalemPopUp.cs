using DevExpress.PivotGrid.OLAP.AdoWrappers;
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
    public partial class FrmFaturaKalemPopUp: Form
    {
        public FrmFaturaKalemPopUp()
        {
            InitializeComponent();
        }
        public int id;
        private void FrmFaturaKalemPopUp_Load(object sender, EventArgs e)
        {
            dBTEknikServisEntities db = new dBTEknikServisEntities();
            gridControl1.DataSource = db.TBLFATURADETAY.Where(x => x.FATURAID == id).ToList();
        }
    }
}
