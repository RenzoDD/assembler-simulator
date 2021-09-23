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
        string extencion = Properties.Resources.extension;
        string path = "";
        Listas listas;
        Assembler simulador;
        Compilador compilador;
        ValidacionSintactica validacion;
        AutocompleteMenu popupMenu;
        ColorSet colores;


        TextStyle Instruccion;
        TextStyle String;
        TextStyle Numeros;
        TextStyle Comentario;
        TextStyle Etiqueta;
        TextStyle Especial;

        public Formulario(string[] args)
        {
            colores = new ColorSet();
            colores.text_regular = Color.White;
            colores.text_string = Color.FromArgb(214, 157, 125);
            colores.text_commentary = Color.FromArgb(87, 166, 74);
            colores.text_instruccions = Color.FromArgb(0, 122, 204);
            colores.text_number = Color.FromArgb(181, 206, 168);
            colores.text_label = Color.FromArgb(180, 180, 180);

            colores.background = Color.FromArgb(28, 28, 28);
            colores.objects = Color.FromArgb(37, 37, 38);
            colores.sub_objects = Color.FromArgb(15,15,15);

            colores.RAM_INST = Color.FromArgb(135, 104, 39);
            colores.RAM_IP = Color.FromArgb(0, 122, 204);
            colores.RAM_SP = Color.FromArgb(238, 162, 54);
            colores.RAM_SP_REMAIN = Color.FromArgb(241, 188, 107);
            colores.RAM_OUT = Color.Gray;
            colores.RAM_A = Color.FromArgb(87, 150, 53);
            colores.RAM_B = Color.FromArgb(239, 242, 132);
            colores.RAM_C = Color.DarkViolet;
            colores.RAM_D = Color.FromArgb(229, 20, 0);



            Instruccion = new TextStyle(new SolidBrush(colores.text_instruccions), null, FontStyle.Regular);
            String = new TextStyle(new SolidBrush(colores.text_string), null, FontStyle.Regular);
            Numeros = new TextStyle(new SolidBrush(colores.text_number), null, FontStyle.Regular);
            Comentario = new TextStyle(new SolidBrush(colores.text_commentary), null, FontStyle.Regular);
            Etiqueta = new TextStyle(new SolidBrush(colores.text_label), null, FontStyle.Regular);
            Especial = new TextStyle(new SolidBrush(Color.FromArgb(78, 201, 176)), null, FontStyle.Bold);



            if (args.Length > 0)
            {
                path = args[0];
                StreamReader sr = new StreamReader(path);
                txtCodigo.Text = sr.ReadLine();
                sr.Close();
            }

           
            validacion = new ValidacionSintactica();
            InitializeComponent();

            listas = new Listas();
            compilador = new Compilador(listas);
            simulador = new Assembler(listas);
            txtCodigo.Text = Properties.Resources.HolaMundo;

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
        
        void Dibujar()
        {
            Graphics ram = RAM.CreateGraphics();
            Graphics register = Registros.CreateGraphics();
            Graphics output = Salida.CreateGraphics();


            BufferedGraphicsContext bfcRAM = BufferedGraphicsManager.Current;
            BufferedGraphics bfRAM = bfcRAM.Allocate(ram, RAM.ClientRectangle);

            BufferedGraphicsContext bfcREG = BufferedGraphicsManager.Current;
            BufferedGraphics bfREG = bfcREG.Allocate(register, Registros.ClientRectangle);

            BufferedGraphicsContext bfcOUT = BufferedGraphicsManager.Current;
            BufferedGraphics bfOUT = bfcRAM.Allocate(output, Salida.ClientRectangle);

            if (simulador != null)
                simulador.GraficarTodo(bfOUT.Graphics, bfREG.Graphics, bfRAM.Graphics, bcBaseNumerica.SelectedIndex, cbA.Checked, cbB.Checked, cbC.Checked, cbD.Checked, cbInstrucciones.Checked, colores);

            bfRAM.Render(ram);
            bfREG.Render(register);
            bfOUT.Render(output);
        }
        bool Ejecutar()
        {
            int s = 0, l = 0; bool ans;
            try
            { ans = simulador.EjecutarInstruccion(ref s, ref l);}
            catch (Exception e)
            {
                clock.Enabled = false;
                MessageBox.Show(e.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //txtCodigo.Focus();
            txtCodigo.SelectionStart = s;
            txtCodigo.SelectionLength = l;
            txtCodigo.DoSelectionVisible();
            return ans;
        }
        bool Compilar()
        {
            string ans; Bitmap RAM;
            try
            {
                ans = compilador.ComprobarSintaxis(txtCodigo.Text);
                if (ans != "OK")
                {
                    MessageBox.Show(ans, "Error de compilación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                RAM = compilador.CompilarTexto(txtCodigo.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en la compilación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            lstVEtiquetas.Clear();

            lstVEtiquetas.Columns.Add("Name", (int)(2 * lstVEtiquetas.Width / 5 - 1));
            lstVEtiquetas.Columns.Add("Address", (int)(1.5 * lstVEtiquetas.Width / 5 - 1));
            lstVEtiquetas.Columns.Add("Value", (int)(1.5 * lstVEtiquetas.Width / 5 - 1));

            foreach (var a in listas.labels)
            {
                ListViewItem row = new ListViewItem(a.Key);
                row.SubItems.Add(a.Value.ToString());
                byte value = RAM.GetPixel(a.Value % 16, a.Value / 16).R;
                if (value < 32 || value > 126)
                    row.SubItems.Add(RAM.GetPixel(a.Value % 16, a.Value / 16).R.ToString());
                else
                    row.SubItems.Add("\'" + (char)value + "\'");


                lstVEtiquetas.Items.Add(row);
            }
            simulador = new Assembler(listas, RAM);
            return true;
        }
        bool GuardarArchivo()
        {

            SaveFileDialog obj = new SaveFileDialog();
            obj.Filter = "Archivos " + extencion.Substring(1, extencion.Length - 1).ToUpper() + " (*" + extencion + ")" + "|*" + extencion;
            obj.FilterIndex = 1;
            obj.InitialDirectory = (path == "")?  Directory.GetCurrentDirectory() : path;
            obj.FileName = "Nuevo archivo ASM";

            if (obj.ShowDialog() == DialogResult.OK)
            {
                var Savefile = new System.IO.StreamWriter(obj.FileName);
                Savefile.Write(txtCodigo.Text);
                Savefile.Close();

            }
            else
                return false;



            return true;
        }

        #region Menú - Archivo
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog obj = new OpenFileDialog();
            obj.InitialDirectory = Directory.GetCurrentDirectory();
            obj.Filter = "Archivos " + extencion.Substring(1, extencion.Length - 1).ToUpper() + " (*" + extencion + ")" + "|*" + extencion;
            obj.FilterIndex = 1;

            if (obj.ShowDialog() == DialogResult.OK)
            {
                path = obj.FileName;
                StreamReader sr = new StreamReader(path);
                txtCodigo.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarArchivo();
        }
        private void btnGuardarComo_Click(object sender, EventArgs e)
        {
            SaveFileDialog obj = new SaveFileDialog();
            obj.Filter = "Archivos " + extencion.Substring(1, extencion.Length - 1).ToUpper() + " (*" + extencion + ")" + "|*" + extencion;
            obj.FilterIndex = 1;
            obj.InitialDirectory = Directory.GetCurrentDirectory();

            if (obj.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Savefile = new StreamWriter(obj.FileName);
                Savefile.WriteLine(txtCodigo.Text);
                Savefile.Close();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            var  ans = MessageBox.Show("¿Desea guardar el archivo actual?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ans == DialogResult.Yes)
                btnGuardar_Click(null, null);


            this.Close();
        }
        #endregion
        #region Menú - Ajustes
        private void btnCambiarFuente_Click(object sender, EventArgs e)
        {
            FontDialog obj = new FontDialog();
            obj.Font = txtCodigo.Font;
            if (obj.ShowDialog() == DialogResult.OK)
            {
                txtCodigo.Font = obj.Font;
            }

        }
        #endregion
        #region Menú - Compilación
        private void btnCompilar_Click(object sender, EventArgs e)
        {
            Compilar();
            Dibujar();
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            if (Compilar())
            {
                txtCodigo.ReadOnly = true;
                clock.Enabled = true;
            }
        }
        private void btnParar_Click(object sender, EventArgs e)
        {
            clock.Enabled = false;
            txtCodigo.ReadOnly = false;
            txtCodigo.Focus();
        }
        private void btnPasoAPaso_Click(object sender, EventArgs e)
        {
            Ejecutar();
            Dibujar();
        }
        #endregion
        
        #region Componentes

        #region Formulario
        private void Formulario_Load(object sender, EventArgs e)
        {
            cbFrecuencia.SelectedIndex = 4;
            bcBaseNumerica.SelectedIndex = 0;
            
            lstVEtiquetas.GridLines = true;
            lstVEtiquetas.FullRowSelect = true;
            lstVEtiquetas.Sorting = SortOrder.Ascending;
            lstVEtiquetas.View = View.Details;


           // simulador = new Assembler( listas, compilador.CompilarTexto(txtCodigo.Text, txtCodigo) );
        }
        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)   // Ctrl + N
                btnNuevo_Click(null, null);

            if (e.Control && e.KeyCode == Keys.S)   // Ctrl + S
                btnGuardar_Click(null, null);
            if (e.Control && e.Alt && e.KeyCode == Keys.S)   // Ctrl + Alt + S
                btnGuardarComo_Click(null, null);

            if (e.KeyCode == Keys.F6)   //F6
                btnCompilar_Click(null, null);

            if (e.KeyCode == Keys.F5)   //F5
                btnEjecutar_Click(null, null);

            if (e.KeyCode == Keys.F4)   //F4
                btnParar_Click(null, null);

            if (e.KeyCode == Keys.F11)   //F11
                btnPasoAPaso_Click(null, null);

            if (e.KeyCode == Keys.Escape)   //ESC
                this.Close();

            if (e.Control && e.KeyCode == Keys.Space)
            {
                popupMenu.Show(true);
                e.Handled = true;
            }

            if (simulador != null && clock.Enabled == true && cbInput.Checked == true)
                simulador.Input((byte)e.KeyValue);

        }
        #endregion
        #region Timers
        private void clock_Tick(object sender, EventArgs e)
        {
            bool ans = Ejecutar();
            if (ans == false)
                clock.Enabled = false;
            if (!clock.Enabled)
                txtCodigo.ReadOnly = false;
        }
        private void graficador_Tick(object sender, EventArgs e)
        {
            Dibujar();
        }
        #endregion
        #region TextBox
  
        #endregion
        #region ContextMenuStrip

        private void btnCerrarGuardar_Click(object sender, EventArgs e)
        {
            btnGuardarComo_Click(null, null);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("¿Seguro que desea cerrar este documento sin guardarlo?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
        }
        #endregion
        private void CheckedChangeds(object sender, EventArgs e)
        {
            Dibujar();
        }
        private void bcBaseNumerica_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dibujar();
            if (txtTestKey.Text != "")
            {
                txtTestKey.Text = "";
            }
        }
        #endregion
        

        private void cbFrecuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            clock.Interval = 1000 / (int)(Math.Pow(2, cbFrecuencia.SelectedIndex));
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



            
            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("#region", "#endregion");

            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (path != "")
                if (!GuardarArchivo())
                {
                    var ans =  MessageBox.Show("¿Seguro que desea eliminar este archivo?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (ans == DialogResult.No)
                        return;
                }
            path = "";
            txtCodigo.Text = Properties.Resources.HolaMundo;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            (new Help()).Show();
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTestKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (bcBaseNumerica.SelectedIndex == 0)
                txtTestKey.Text = "0x" + Convert.ToString(e.KeyValue, 16).ToUpper();
            else
                txtTestKey.Text = Convert.ToString(e.KeyValue, 10);
        }

        private void btnHolaMundo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = Properties.Resources.HolaMundo;
        }

        private void btnInputData_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = Properties.Resources.LecturaDatos;
        }

        private void btnNumerosPrimos_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = Properties.Resources.NumerosPrimos;
        }

        private void cbFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFullScreen.Checked == true)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void txtCodigo_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            txtCodigo.Range.ClearStyle(Etiqueta);

            //find function declarations, highlight all of their entry into the code
            foreach (Range found in txtCodigo.GetRanges(@"\b(?<range>\w+)+(:)"))
              txtCodigo.Range.SetStyle(Etiqueta, @"\b" + found.Text + @"\b");

           


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCCPOBzJTlf1u-UMRGMyDXVQ");
        }
    }
}