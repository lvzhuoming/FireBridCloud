using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FireBridCloud
{
    public partial class FrmKLine : Form
    {
        public FrmKLine()
        {
            InitializeComponent();
            this.KeyDown += this.kLineControl1.KeyDown;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                return false;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }
    }
}
