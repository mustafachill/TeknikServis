﻿using System;
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
    public partial class FrmKurlar: Form
    {
        public FrmKurlar()
        {
            InitializeComponent();
        }

        private void FrmKurlar_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
