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
    public partial class EditarImagenes : Form
    {
        EditorRD1601 editor;
        public EditarImagenes(EditorRD1601 editor)
        {
            InitializeComponent();
            this.editor = editor;
        }
        private void pbSelected_MouseMove(object sender, MouseEventArgs e)
        {
            int ancho = pbSelected.Width / 8;
            int alto = pbSelected.Height / 4;
            
            _sx = (e.X / ancho);
            _sy = (e.Y / alto);


        }
        private void pbSelected_Click(object sender, EventArgs e)
        {
            sx = _sx;
            sy = _sy;
            label1.Text = "SX:" + _sx;
            label2.Text = "SY:" + _sy;
            lblHEX.Text = "Address: 0x" + Convert.ToString((_sx * 16) + (_sy * 8 * 16 ) + editor.alloc_img, 16).ToUpper().PadLeft(4, '0');
            
        }

        int _x, _y;
        int _sx, _sy;
        int sx, sy;

        private void tbRAM_Scroll(object sender, EventArgs e)
        {
            lblHEX.Text = "Address: 0x" + Convert.ToString((_sx * 16) + (_sy * 8 * 16) + editor.alloc_img, 16).ToUpper().PadLeft(4, '0');
            lblPosicion.Text = "Posición en RAM: 0x" + Convert.ToString(tbRAM.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbRAM.Value + 0x0200 - 1, 16).PadLeft(4, '0').ToUpper();
            editor.alloc_img = (ushort)(tbRAM.Value);
        }

        private void EditarImagenes_Load(object sender, EventArgs e)
        {
            tbRAM.Value = editor.alloc_img;
            lblPosicion.Text = "RAM Address: 0x" + Convert.ToString(tbRAM.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbRAM.Value + 0x0200 - 1, 16).PadLeft(4, '0').ToUpper();

        }

        private void graficador_Tick(object sender, EventArgs e)
        {
            Graphics sprites = pbSprites.CreateGraphics();
            Graphics imagenes = pbSelected.CreateGraphics();
            //Graphics output = Salida.CreateGraphics();

            BufferedGraphicsContext bfcSPR = BufferedGraphicsManager.Current;
            BufferedGraphics bfSPR = bfcSPR.Allocate(sprites, pbSprites.ClientRectangle);

            BufferedGraphicsContext bfcIMG = BufferedGraphicsManager.Current;
            BufferedGraphics bfIMG = bfcIMG.Allocate(imagenes, pbSelected.ClientRectangle);

            editor.ObtenerSprite(bfSPR.Graphics, sx, sy);
            editor.ObtenerImagenes(bfIMG.Graphics);

            bfSPR.Render(sprites);
            bfIMG.Render(imagenes);
        }


        private void pbSprites_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                editor.DefinirImagenes(sx, sy, _x, _y, 1);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                editor.DefinirImagenes(sx, sy, _x, _y, 0);
        }
        private void pbSprites_MouseMove(object sender, MouseEventArgs e)
        {
            int ancho = pbSprites.Width / 16;
            int alto = pbSprites.Height / 16;

            _x = (e.X / ancho);
            _y = (e.Y / alto);

            lblX.Text = "X:" + _x;
            lblY.Text = "Y:" + _y;
        }

    }
}
