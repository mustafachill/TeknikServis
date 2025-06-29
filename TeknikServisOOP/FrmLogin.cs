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

namespace TeknikServisOOP
{
    public partial class FrmLogin: Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        dBTEknikServisEntities db = new dBTEknikServisEntities();
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.TBLADMIN where x.KULLANICIAD == textBox1.Text.ToString() & x.SIFRE == textBox2.Text.ToString() select x;
            if (sorgu.Any())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else {
                XtraMessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
