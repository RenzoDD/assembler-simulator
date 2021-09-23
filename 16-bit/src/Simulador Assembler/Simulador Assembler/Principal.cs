using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador_Assembler
{
    public partial class Formulario : Form
    {
        string extencion_codigo = Properties.Resources.extension_codigo;
        string extencion_imagen = Properties.Resources.extension_imagenes;
        string extencion_rom = Properties.Resources.extension_rom;
        string path = "";
        
        AutocompleteMenu popupMenu;
        TextStyle Instruccion = new TextStyle(new SolidBrush(Color.FromArgb(0, 0, 255)), null, FontStyle.Regular);
        TextStyle String = new TextStyle(new SolidBrush(Color.FromArgb(43, 145, 175)), null, FontStyle.Regular);
        TextStyle Numeros = new TextStyle(new SolidBrush(Color.FromArgb(44, 60, 80)), null, FontStyle.Regular);
        TextStyle Comentario = new TextStyle(new SolidBrush(Color.FromArgb(0, 128, 0)), null, FontStyle.Regular);
        TextStyle Etiqueta = new TextStyle(new SolidBrush(Color.Gray), null, FontStyle.Regular);
        TextStyle Especial = new TextStyle(new SolidBrush(Color.DarkViolet), null, FontStyle.Bold);
        TextStyle boolMrk = new TextStyle(new SolidBrush(Color.FromArgb(43, 145, 175)), null, FontStyle.Regular);

        EditorRD1601 editor;
        Sintaxis validacion = new Sintaxis();

        public Formulario(string[] args)
        {
            if (args.Length > 0)
            {
                path = args[0];
                StreamReader sr = new StreamReader(path);
                txtCodigo.Text = sr.ReadLine();
                sr.Close();
            }

            InitializeComponent();
            cbFrecuencia.SelectedIndex = 4;


            Sintaxis validacion = new Sintaxis();
            popupMenu = new FastColoredTextBoxNS.AutocompleteMenu(txtCodigo);
            var Helps = new List<string>();
            Helps.Add("#region");
            Helps.Add("#endregion");
            foreach (Instruccion i in validacion.instrucciones)
                Helps.Add(i.nombre);
            popupMenu.Items.SetAutocompleteItems(Helps);
            popupMenu.Items.MaximumSize = new System.Drawing.Size(200, 300);
            popupMenu.Items.Width = 200;
        }
        
        bool Compilar()
        {
            bool outs = false;
            try
            {
                clock.Enabled = false;
                txtCodigo.Enabled = true;
                string ans = "";
                outs = editor.Compilar(ref ans);
                if (!outs)
                {
                    panelEstado.BackColor = Color.Red;
                    lblEstado.Text = "Assemble error: " + ans;
                }
                else
                {
                    panelEstado.BackColor = Color.Green;
                    lblEstado.Text = "Assemble succesful";
                }
            }
            catch (Exception ex){
                panelEstado.BackColor = Color.FromArgb(255, 0, 0);
                lblEstado.Text = "Assemble error: " + ex.Message;
                return false;
            }
            return outs;
        }
        void Dibujar()
        {
            Graphics ram = RAM.CreateGraphics();
            Graphics register = Registros.CreateGraphics();

            BufferedGraphicsContext bfcRAM = BufferedGraphicsManager.Current;
            BufferedGraphics bfRAM = bfcRAM.Allocate(ram, RAM.ClientRectangle);

            BufferedGraphicsContext bfcREG = BufferedGraphicsManager.Current;
            BufferedGraphics bfREG = bfcREG.Allocate(register, Registros.ClientRectangle);


            if (editor != null)
              editor.Graficar(bfREG.Graphics, bfRAM.Graphics, null, 255 - tbRAM.Value, textDisplay.Checked);

            bfRAM.Render(ram);
            bfREG.Render(register);
        }

        bool GuardarArchivo()
        {

            SaveFileDialog obj = new SaveFileDialog();
            obj.Filter = "ASM files (*.asm)|*.asm";
            obj.FilterIndex = 1;
            obj.InitialDirectory = Directory.GetCurrentDirectory();
            obj.FileName = "New ASM file";
            obj.FileName = path;
            DialogResult var = (path == "") ? obj.ShowDialog() : DialogResult.OK;

            if (var == DialogResult.OK)
            {
                try
                {
                    var Savefile = new System.IO.StreamWriter(obj.FileName);
                    Savefile.WriteLine(editor.ordenador.limit_SP.ToString().PadLeft(5, '0'));
                    Savefile.WriteLine(editor.alloc_img.ToString().PadLeft(5, '0'));
                    Savefile.WriteLine(editor.ordenador.input_alloc.ToString().PadLeft(5, '0'));
                    Savefile.WriteLine(editor.ordenador.output_alloc_screen.ToString().PadLeft(5, '0'));
                    Savefile.WriteLine(editor.ordenador.output_alloc_text.ToString().PadLeft(5, '0'));

                    foreach (ushort b in editor.IMG)
                        Savefile.Write((char)b);

                    Savefile.Write(txtCodigo.Text);
                    Savefile.Close();
                    path = obj.FileName;
                    return true;
                }
                catch { return false; }
            }
            else
                return false;
        }
        bool AbrirArchivo()
        {
            OpenFileDialog obj = new OpenFileDialog();
            obj.InitialDirectory = Directory.GetCurrentDirectory();
            obj.Filter = "ASM files (*.asm)|*.asm";
            obj.FilterIndex = 1;

            if (obj.ShowDialog() == DialogResult.OK)
            {
                path = obj.FileName;
                StreamReader texto = new StreamReader(path);
                editor.ordenador.limit_SP = ushort.Parse(texto.ReadLine());
                editor.alloc_img = ushort.Parse(texto.ReadLine());
                editor.ordenador.input_alloc = ushort.Parse(texto.ReadLine());
                editor.ordenador.output_alloc_screen = ushort.Parse(texto.ReadLine());
                editor.ordenador.output_alloc_text = ushort.Parse(texto.ReadLine());
                
                for (int i = 0; i < 512; i++)
                    editor.IMG[i] = (ushort)texto.Read();

                txtCodigo.Text = texto.ReadToEnd();
                texto.Close();
                return true;
            }
            else
                return false;

            
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarArchivo();
        }
        private void btnGuardarComo_Click(object sender, EventArgs e)
        {
            string temp = path;
            path = "";
            if (!GuardarArchivo())
                path = temp;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            var  ans = MessageBox.Show("Save the code?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ans == DialogResult.Yes)
                btnGuardar_Click(null, null);


            this.Close();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (textDisplay.Checked)
            {
                panelEstado.BackColor = Color.FromArgb(198, 79, 0);
                lblEstado.Text = "Running";
                clock.Enabled = true;
                (new Display(editor.ordenador)).Show();
            }
            else
            {
                panelEstado.BackColor = Color.DarkViolet;
                lblEstado.Text = "Warning: Runing Over-Clock (Close 'Screen' and stop manualy)";
                (new Pantalla(editor.ordenador)).Show();
            }
        }
        private void btnPasoAPaso_Click(object sender, EventArgs e)
        {
            Dibujar();
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = Properties.Resources.HolaMundo;
            editor = new EditorRD1601(txtCodigo, lstVEtiquetas);

            lstVEtiquetas.GridLines = true;
            lstVEtiquetas.FullRowSelect = true;
            lstVEtiquetas.Sorting = SortOrder.Ascending;
            lstVEtiquetas.View = View.Details;

            lstVEtiquetas.Columns.Add("Name", (int)(2 * lstVEtiquetas.Width / 5 - 1));
            lstVEtiquetas.Columns.Add("Address", (int)(1.5 * lstVEtiquetas.Width / 5 - 1));
            lstVEtiquetas.Columns.Add("Value", (int)(1.5 * lstVEtiquetas.Width / 5 - 1) - 16);
        }
        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)   // Ctrl + N
                btnNuevo_Click(null, null);

            if (e.Control && e.KeyCode == Keys.S)   // Ctrl + S
                btnGuardar_Click(null, null);
            if (e.Control && e.Alt && e.KeyCode == Keys.S)   // Ctrl + Alt + S
                btnGuardarComo_Click(null, null);
            

            if (e.KeyCode == Keys.F5)   //F5
                btnEjecutar_Click(null, null);



            if (e.KeyCode == Keys.F11)   //F11
                btnPasoAPaso_Click(null, null);

            if (e.KeyCode == Keys.Escape)   //ESC
                this.Close();

            if (e.Control && e.KeyCode == Keys.Space)
            {
                popupMenu.Show(true);
                e.Handled = true;
            }
            

        }

        private void graficador_Tick(object sender, EventArgs e)
        {
            Dibujar();
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {


            //clear style of changed range
            e.ChangedRange.ClearStyle(Instruccion, String, Etiqueta, Comentario, Numeros);

            //especial highlighting
            e.ChangedRange.SetStyle(Especial, @"\b(RENZO|DIAZ|renzo|diaz|Renzo|Diaz|ASM-D1004)\b", RegexOptions.Multiline);

            //comment highlighting
            e.ChangedRange.SetStyle(Comentario, @";.*$", RegexOptions.Multiline);

            //string highlighting
            e.ChangedRange.SetStyle(String, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");

            //keyword highlighting
            e.ChangedRange.SetStyle(Instruccion, @"\b(" + validacion.istructionSet + "|" + validacion.istructionSet.ToLower() + @")\b");
            
            //number highlighting
            e.ChangedRange.SetStyle(Numeros, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b|\b0b[a-fA-F\d]+\b|\b0o[a-fA-F\d]+\b");

            //boolean highlighting
            e.ChangedRange.SetStyle(boolMrk, @"\b(true|false|True|False|TRUE|FALSE)\b", RegexOptions.Multiline);


            //find function declarations, highlight all of their entry into the code
            //foreach (Range found in txtCodigo.GetRanges(@"\b(?<range>\w+)+(:)"))
            //  txtCodigo.Range.SetStyle(Etiqueta, @"\b" + found.Text + @"\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("#region", "#endregion");

            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                var ans = MessageBox.Show("Would you like to create a new proyect? The current data will be lost", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (ans == DialogResult.Yes)
                    GuardarArchivo();
                else
                    return;

            }

            path = "";
            editor = new EditorRD1601(txtCodigo, lstVEtiquetas);
            txtCodigo.Clear();
        }

        private void txtCodigo_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                StreamReader sr = new StreamReader(files[0]);
                txtCodigo.Text = sr.ReadToEnd();
                sr.Close();
            }catch { }
        }

        private void txtCodigo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;

        }


        private void tbRAM_Scroll(object sender, EventArgs e)
        {
            lbl0.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "0";
            lbl1.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "1";
            lbl2.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "2";
            lbl3.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "3";
            lbl4.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "4";
            lbl5.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "5";
            lbl6.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "6";
            lbl7.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "7";
            lbl8.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "8";
            lbl9.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "9";
            lbl10.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "A";
            lbl11.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "B";
            lbl12.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "C";
            lbl13.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "D";
            lbl14.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "E";
            lbl15.Text = "0x" + Convert.ToString(255 - tbRAM.Value, 16).ToUpper().PadLeft(2, '0') + "F";
        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            Compilar();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Enabled = !editor.EjecutarInstruccion();
                if (txtCodigo.Enabled == true)
                {
                    clock.Enabled = false;
                    if (editor.ordenador.GetFault() == true)
                    {
                        panelEstado.BackColor = Color.FromArgb(255, 0, 0);
                        lblEstado.Text = "Runtime error";
                    }

                }

                if (clock.Enabled == false && editor.ordenador.GetFault() == false)
                {
                    panelEstado.BackColor = Color.FromArgb(0, 122, 204);
                    lblEstado.Text = "Ready";
                }
            }
            catch (Exception ex)
            {
                panelEstado.BackColor = Color.FromArgb(255, 0, 0);
                lblEstado.Text = "Assemble error: " + ex.Message;
            }
        }

        private void btnPasoAPaso_Click_1(object sender, EventArgs e)
        {
            editor.EjecutarInstruccion();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            clock.Enabled = false;
            txtCodigo.Enabled = true;
            panelEstado.BackColor = Color.FromArgb(0, 122, 204);
            lblEstado.Text = "Ready";
        }

        private void cbFrecuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            clock.Interval = (int)(1000 / Math.Pow(2, cbFrecuencia.SelectedIndex));
        }

        private void btnSprites_Click(object sender, EventArgs e)
        {
            (new EditarImagenes(editor)).ShowDialog();
        }

        private void BTNpantalla128X128_Click(object sender, EventArgs e)
        {
            textDisplay.Checked = !textDisplay.Checked;
            BTNpantalla128X128.Checked = !BTNpantalla128X128.Checked;
        }

        private void btnConversor_Click(object sender, EventArgs e)
        {
            (new BaseConversor()).Show();
        }

        private void keyCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new KeyCode()).Show();
        }

        private void btnConfiguracion(object sender, EventArgs e)
        {
            (new Configuracion(editor)).Show();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void holaMundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = Properties.Resources.HolaMundo;

        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = Properties.Resources.CodigoImput;

        }

        private void númerosPrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = Properties.Resources.NumerosPrimos;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            (new Help()).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCCPOBzJTlf1u-UMRGMyDXVQ");

        }
    }
}