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
    public partial class Configuracion : Form
    {
        EditorRD1601 editor;
        public Configuracion(EditorRD1601 editor)
        {
            InitializeComponent();
            this.editor = editor;
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            tbSprites.Value = editor.alloc_img;
            lblSprites.Text = "Sprites RAM Address: 0x" + Convert.ToString(tbSprites.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbSprites.Value + 0x0200 - 1, 16).PadLeft(4, '0').ToUpper();

            tbScreen.Value = editor.ordenador.output_alloc_screen;
            lblScreen.Text = "Screen display RAM Address: 0x" + Convert.ToString(tbScreen.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbScreen.Value + 2048 - 1, 16).PadLeft(4, '0').ToUpper();

            tbText.Value = editor.ordenador.output_alloc_text;
            lblText.Text = "Text Display RAM Address: 0x" + Convert.ToString(tbText.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbText.Value + 32 - 1, 16).PadLeft(4, '0').ToUpper();

            tbInput.Value = editor.ordenador.input_alloc;
            lblInput.Text = "Input RAM Address: 0x" + Convert.ToString(tbInput.Value, 16).PadLeft(4, '0').ToUpper();

            tbSP.Value = editor.ordenador.limit_SP;
            lblSP.Text = "Stack RAM Address: 0x" + Convert.ToString(tbSP.Value, 16).PadLeft(4, '0').ToUpper();
        }

        private void tbSprites_Scroll(object sender, EventArgs e)
        {
            lblSprites.Text = "Sprites RAM Address: 0x" + Convert.ToString(tbSprites.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbSprites.Value + 0x0200 - 1, 16).PadLeft(4, '0').ToUpper();
            editor.alloc_img = (ushort)(tbSprites.Value);
        }
        private void tbScreen_Scroll(object sender, EventArgs e)
        {
            lblScreen.Text = "Screen display RAM Address: 0x" + Convert.ToString(tbScreen.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbScreen.Value + 4096 - 1, 16).PadLeft(4, '0').ToUpper();
            editor.ordenador.output_alloc_screen = (ushort)(tbSprites.Value);
        }

        private void tbText_Scroll(object sender, EventArgs e)
        {
            lblText.Text = "Text Display RAM Address: 0x" + Convert.ToString(tbText.Value, 16).PadLeft(4, '0').ToUpper() + " - 0x" + Convert.ToString(tbText.Value + 32 - 1, 16).PadLeft(4, '0').ToUpper();
            editor.ordenador.output_alloc_text = (ushort)(tbText.Value);
        }

        private void tbInput_Scroll(object sender, EventArgs e)
        {
            lblInput.Text = "Input RAM Address: 0x" + Convert.ToString(tbInput.Value, 16).PadLeft(4, '0').ToUpper();
            editor.ordenador.input_alloc = (ushort)tbInput.Value;
        }

        private void tbSP_Scroll(object sender, EventArgs e)
        {
            lblSP.Text = "Stack RAM Address: 0x" + Convert.ToString(tbSP.Value, 16).PadLeft(4, '0').ToUpper();
            editor.ordenador.limit_SP = (ushort)tbSP.Value;
        }
    }
}
