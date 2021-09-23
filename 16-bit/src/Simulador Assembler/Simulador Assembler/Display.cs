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
    public partial class Display : Form
    {
        OrdenadorRD1601 consola;
        public Display(OrdenadorRD1601 consola)
        {
            InitializeComponent();
            this.consola = consola;
        }

        private void graficador_Tick(object sender, EventArgs e)
        {
            Graphics form = CreateGraphics();
            BufferedGraphicsContext bfc = BufferedGraphicsManager.Current;
            BufferedGraphics bf = bfc.Allocate(form, this.ClientRectangle);

            consola.GraficarOUT_TEXT(bf.Graphics);
            bf.Render(form);
        }

        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            consola.Input((ushort)e.KeyValue);
        }
    }
}
