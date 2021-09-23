using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador_Assembler
{
    public partial class KeyCode : Form
    {
        public KeyCode()
        {
            InitializeComponent();
        }
        private void txtTestKey_KeyDown(object sender, KeyEventArgs e)
        {
            txtTestKey.Text = "0x" + Convert.ToString(e.KeyValue, 16).ToUpper();

        }

    }
}
