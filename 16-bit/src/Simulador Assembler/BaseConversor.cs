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
    public partial class BaseConversor : Form
    {
        public BaseConversor()
        {
            InitializeComponent();
        }
        private void txtDEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }
        private void txtBIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '1' || e.KeyChar == '0' || e.KeyChar == '\b'))
                e.Handled = true;
        }

        private void txtHEX_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '\b'
                || e.KeyChar == 'A' || e.KeyChar == 'A' || e.KeyChar == 'B' || e.KeyChar == 'C' || e.KeyChar == 'D' || e.KeyChar == 'E' || e.KeyChar == 'F'))
                e.Handled = true;
        }

        private void txtHEX_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            try
            {
                if (txt.Name == "txtHEX")
                {
                    txtBIN.Text = Convert.ToString(Convert.ToInt32(txtHEX.Text, 16), 2);
                    txtDEC.Text = Convert.ToString(Convert.ToInt32(txtHEX.Text, 16), 10);
                }
                else if (txt.Name == "txtBIN")
                {
                    txtHEX.Text = Convert.ToString(Convert.ToInt32(txtBIN.Text, 2), 16).ToUpper();
                    txtDEC.Text = Convert.ToString(Convert.ToInt32(txtBIN.Text, 2), 10);
                }
                else if (txt.Name == "txtDEC")
                {
                    txtHEX.Text = Convert.ToString(Convert.ToInt32(txtDEC.Text, 10), 16).ToUpper();
                    txtBIN.Text = Convert.ToString(Convert.ToInt32(txtDEC.Text, 10), 2);
                }

                if (Convert.ToInt32(txtHEX.Text, 16) > 0xFFFF)
                    txtHEX.Text = "FFFF";


            }
            catch { }
        }
    }
}
