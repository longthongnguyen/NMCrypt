using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMCrypt
{
    public partial class formOptions : Form
    {
        public formOptions()
        {
            InitializeComponent();
        }

        public delegate void GETDATA(string data);
        public GETDATA _AESMode;
        public GETDATA _AESKeySize;
        public string tempMode;
        public string tempKeySize;

        private void formOptions_Load(object sender, EventArgs e)
        {
            cbxAesmode.Text = tempMode;
            cbxAESkeysize.Text = tempKeySize;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _AESMode(cbxAesmode.Text);
            _AESKeySize(cbxAESkeysize.Text);
            this.Close();
        }
    }
}
