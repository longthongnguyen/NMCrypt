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
        public GETDATA _isDelete;
        public string tempMode;
        public string tempKeySize;
        public string tempIsDelete;

        private void formOptions_Load(object sender, EventArgs e)
        {
            cbxAesmode.Text = tempMode;
            cbxAESkeysize.Text = tempKeySize;
            if(tempIsDelete == "true")
            {
                chbIsdelete.Checked = true;
            }
            else
            {
                chbIsdelete.Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _AESMode(cbxAesmode.Text);
            _AESKeySize(cbxAESkeysize.Text);
            if(chbIsdelete.Checked)
            {
                _isDelete("true");
            }
            else
            {
                _isDelete("false");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
