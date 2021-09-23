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
    public partial class Pantalla : Form
    {
        OrdenadorRD1601 consola;
        public Pantalla(OrdenadorRD1601 consola)
        {
            InitializeComponent();
            this.consola = consola;

            

            int f = 0; int i = 0;
            Task t = new Task(() => { while (consola.EjecutarInstruccion(ref i, ref f)) ; } );
            t.Start();
        }
        private void Graficador_Tick(object sender, EventArgs e)
        {
            try
            {
                Graphics form = CreateGraphics();
                BufferedGraphicsContext bfc = BufferedGraphicsManager.Current;
                BufferedGraphics bf = bfc.Allocate(form, this.ClientRectangle);

                consola.Display(bf.Graphics);
                bf.Render(form);
            }
            catch { }
        }
        
        
        private void Pantalla_KeyDown(object sender, KeyEventArgs e)
        {
            consola.Input((ushort)e.KeyValue);
        }

        private void Pantalla_FormClosed(object sender, FormClosedEventArgs e)
        {
            consola.Parar();
        }
    }
}
