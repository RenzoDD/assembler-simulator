namespace Simulador_Assembler
{
    partial class Formulario
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario));
            this.RAM = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Registros = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.Salida = new System.Windows.Forms.Panel();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCerrarGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasoAPasoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codigosEjemploToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHolaMundo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInputData = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNumerosPrimos = new System.Windows.Forms.ToolStripMenuItem();
            this.lstVEtiquetas = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.bcBaseNumerica = new System.Windows.Forms.ComboBox();
            this.cbFrecuencia = new System.Windows.Forms.ComboBox();
            this.graficador = new System.Windows.Forms.Timer(this.components);
            this.btnCompilar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnParar = new System.Windows.Forms.Button();
            this.btnPasoAPaso = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestKey = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbInput = new System.Windows.Forms.CheckBox();
            this.cbFullScreen = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbA = new System.Windows.Forms.CheckBox();
            this.cbC = new System.Windows.Forms.CheckBox();
            this.cbInstrucciones = new System.Windows.Forms.CheckBox();
            this.cbB = new System.Windows.Forms.CheckBox();
            this.cbD = new System.Windows.Forms.CheckBox();
            this.documentMap1 = new FastColoredTextBoxNS.DocumentMap();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RAM
            // 
            this.RAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RAM.Location = new System.Drawing.Point(650, 176);
            this.RAM.Margin = new System.Windows.Forms.Padding(4);
            this.RAM.Name = "RAM";
            this.RAM.Size = new System.Drawing.Size(397, 287);
            this.RAM.TabIndex = 1;
            this.help.SetToolTip(this.RAM, "RAM");
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(650, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "RAM:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(650, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Registers / Flags:";
            // 
            // Registros
            // 
            this.Registros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Registros.Location = new System.Drawing.Point(650, 104);
            this.Registros.Margin = new System.Windows.Forms.Padding(4);
            this.Registros.Name = "Registros";
            this.Registros.Size = new System.Drawing.Size(397, 45);
            this.Registros.TabIndex = 11;
            this.help.SetToolTip(this.Registros, "Registros Multipropósito");
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(654, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Output:";
            // 
            // Salida
            // 
            this.Salida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Salida.Location = new System.Drawing.Point(654, 32);
            this.Salida.Margin = new System.Windows.Forms.Padding(4);
            this.Salida.Name = "Salida";
            this.Salida.Size = new System.Drawing.Size(393, 45);
            this.Salida.TabIndex = 13;
            this.help.SetToolTip(this.Salida, "Salida");
            // 
            // clock
            // 
            this.clock.Interval = 62;
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.nuevoToolStripMenuItem,
            this.btnCerrarGuardar,
            this.abrirToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.codigosEjemploToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu.Size = new System.Drawing.Size(124, 136);
            this.Menu.Text = "Hola";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.nuevoToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.nuevoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem1.Image")));
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.nuevoToolStripMenuItem1.Text = "New";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.nuevoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.nuevoToolStripMenuItem.Text = "Guardar";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrarGuardar
            // 
            this.btnCerrarGuardar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarToolStripMenuItem,
            this.ejecutarToolStripMenuItem1,
            this.pararToolStripMenuItem,
            this.pasoAPasoToolStripMenuItem});
            this.btnCerrarGuardar.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarGuardar.ForeColor = System.Drawing.Color.White;
            this.btnCerrarGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarGuardar.Image")));
            this.btnCerrarGuardar.Name = "btnCerrarGuardar";
            this.btnCerrarGuardar.Size = new System.Drawing.Size(123, 22);
            this.btnCerrarGuardar.Text = "Run";
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ejecutarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ejecutarToolStripMenuItem.Image")));
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ejecutarToolStripMenuItem.Text = "Assemble";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // ejecutarToolStripMenuItem1
            // 
            this.ejecutarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ejecutarToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ejecutarToolStripMenuItem1.Image")));
            this.ejecutarToolStripMenuItem1.Name = "ejecutarToolStripMenuItem1";
            this.ejecutarToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.ejecutarToolStripMenuItem1.Text = "Run";
            this.ejecutarToolStripMenuItem1.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // pararToolStripMenuItem
            // 
            this.pararToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pararToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pararToolStripMenuItem.Image")));
            this.pararToolStripMenuItem.Name = "pararToolStripMenuItem";
            this.pararToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.pararToolStripMenuItem.Text = "Stop";
            this.pararToolStripMenuItem.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // pasoAPasoToolStripMenuItem
            // 
            this.pasoAPasoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pasoAPasoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasoAPasoToolStripMenuItem.Image")));
            this.pasoAPasoToolStripMenuItem.Name = "pasoAPasoToolStripMenuItem";
            this.pasoAPasoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.pasoAPasoToolStripMenuItem.Text = "Step";
            this.pasoAPasoToolStripMenuItem.Click += new System.EventHandler(this.btnPasoAPaso_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.abrirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.abrirToolStripMenuItem.Text = "Save";
            this.abrirToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.ayudaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ayudaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ayudaToolStripMenuItem.Image")));
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ayudaToolStripMenuItem.Text = "Help";
            // 
            // codigosEjemploToolStripMenuItem
            // 
            this.codigosEjemploToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHolaMundo,
            this.btnInputData,
            this.btnNumerosPrimos});
            this.codigosEjemploToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.codigosEjemploToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.codigosEjemploToolStripMenuItem.Name = "codigosEjemploToolStripMenuItem";
            this.codigosEjemploToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.codigosEjemploToolStripMenuItem.Text = "Codes";
            // 
            // btnHolaMundo
            // 
            this.btnHolaMundo.Name = "btnHolaMundo";
            this.btnHolaMundo.Size = new System.Drawing.Size(165, 22);
            this.btnHolaMundo.Text = "Hello World";
            this.btnHolaMundo.Click += new System.EventHandler(this.btnHolaMundo_Click);
            // 
            // btnInputData
            // 
            this.btnInputData.Name = "btnInputData";
            this.btnInputData.Size = new System.Drawing.Size(165, 22);
            this.btnInputData.Text = "Input";
            this.btnInputData.Click += new System.EventHandler(this.btnInputData_Click);
            // 
            // btnNumerosPrimos
            // 
            this.btnNumerosPrimos.Name = "btnNumerosPrimos";
            this.btnNumerosPrimos.Size = new System.Drawing.Size(165, 22);
            this.btnNumerosPrimos.Text = "Prime numbers";
            this.btnNumerosPrimos.Click += new System.EventHandler(this.btnNumerosPrimos_Click);
            // 
            // lstVEtiquetas
            // 
            this.lstVEtiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVEtiquetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.lstVEtiquetas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstVEtiquetas.ForeColor = System.Drawing.Color.White;
            this.lstVEtiquetas.GridLines = true;
            this.lstVEtiquetas.HideSelection = false;
            this.lstVEtiquetas.Location = new System.Drawing.Point(650, 489);
            this.lstVEtiquetas.MultiSelect = false;
            this.lstVEtiquetas.Name = "lstVEtiquetas";
            this.lstVEtiquetas.Size = new System.Drawing.Size(397, 139);
            this.lstVEtiquetas.TabIndex = 33;
            this.help.SetToolTip(this.lstVEtiquetas, "Etiquetas");
            this.lstVEtiquetas.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(650, 467);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 34;
            this.label1.Text = "Labels:";
            // 
            // bcBaseNumerica
            // 
            this.bcBaseNumerica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcBaseNumerica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bcBaseNumerica.FormattingEnabled = true;
            this.bcBaseNumerica.Items.AddRange(new object[] {
            "Hexadecimal",
            "Decimal"});
            this.bcBaseNumerica.Location = new System.Drawing.Point(6, 29);
            this.bcBaseNumerica.Name = "bcBaseNumerica";
            this.bcBaseNumerica.Size = new System.Drawing.Size(131, 27);
            this.bcBaseNumerica.TabIndex = 28;
            this.bcBaseNumerica.SelectedIndexChanged += new System.EventHandler(this.bcBaseNumerica_SelectedIndexChanged);
            this.bcBaseNumerica.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            // 
            // cbFrecuencia
            // 
            this.cbFrecuencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrecuencia.FormattingEnabled = true;
            this.cbFrecuencia.Items.AddRange(new object[] {
            "1 Hz",
            "2 Hz",
            "4 Hz",
            "8 Hz",
            "16 Hz",
            "32 Hz",
            "64 Hz"});
            this.cbFrecuencia.Location = new System.Drawing.Point(6, 29);
            this.cbFrecuencia.Name = "cbFrecuencia";
            this.cbFrecuencia.Size = new System.Drawing.Size(102, 27);
            this.cbFrecuencia.TabIndex = 29;
            this.cbFrecuencia.SelectedIndexChanged += new System.EventHandler(this.cbFrecuencia_SelectedIndexChanged);
            // 
            // graficador
            // 
            this.graficador.Enabled = true;
            this.graficador.Interval = 10;
            this.graficador.Tick += new System.EventHandler(this.graficador_Tick);
            // 
            // btnCompilar
            // 
            this.btnCompilar.BackColor = System.Drawing.Color.Transparent;
            this.btnCompilar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompilar.FlatAppearance.BorderSize = 0;
            this.btnCompilar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCompilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompilar.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnCompilar.ForeColor = System.Drawing.Color.White;
            this.btnCompilar.Image = ((System.Drawing.Image)(resources.GetObject("btnCompilar.Image")));
            this.btnCompilar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompilar.Location = new System.Drawing.Point(192, 12);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(114, 28);
            this.btnCompilar.TabIndex = 71;
            this.btnCompilar.Text = "Assemble";
            this.btnCompilar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.help.SetToolTip(this.btnCompilar, "(F6)");
            this.btnCompilar.UseVisualStyleBackColor = false;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackColor = System.Drawing.Color.Transparent;
            this.btnEjecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEjecutar.FlatAppearance.BorderSize = 0;
            this.btnEjecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutar.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnEjecutar.ForeColor = System.Drawing.Color.White;
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEjecutar.Location = new System.Drawing.Point(8, 12);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(85, 28);
            this.btnEjecutar.TabIndex = 72;
            this.btnEjecutar.Text = "Start";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.help.SetToolTip(this.btnEjecutar, "(F5)");
            this.btnEjecutar.UseVisualStyleBackColor = false;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnParar
            // 
            this.btnParar.BackColor = System.Drawing.Color.Transparent;
            this.btnParar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParar.FlatAppearance.BorderSize = 0;
            this.btnParar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnParar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParar.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnParar.ForeColor = System.Drawing.Color.White;
            this.btnParar.Image = ((System.Drawing.Image)(resources.GetObject("btnParar.Image")));
            this.btnParar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParar.Location = new System.Drawing.Point(99, 12);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(87, 28);
            this.btnParar.TabIndex = 73;
            this.btnParar.Text = "Stop";
            this.btnParar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.help.SetToolTip(this.btnParar, "(F4)");
            this.btnParar.UseVisualStyleBackColor = false;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // btnPasoAPaso
            // 
            this.btnPasoAPaso.BackColor = System.Drawing.Color.Transparent;
            this.btnPasoAPaso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasoAPaso.FlatAppearance.BorderSize = 0;
            this.btnPasoAPaso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnPasoAPaso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasoAPaso.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnPasoAPaso.ForeColor = System.Drawing.Color.White;
            this.btnPasoAPaso.Image = ((System.Drawing.Image)(resources.GetObject("btnPasoAPaso.Image")));
            this.btnPasoAPaso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPasoAPaso.Location = new System.Drawing.Point(312, 12);
            this.btnPasoAPaso.Name = "btnPasoAPaso";
            this.btnPasoAPaso.Size = new System.Drawing.Size(91, 28);
            this.btnPasoAPaso.TabIndex = 74;
            this.btnPasoAPaso.Text = "Step";
            this.btnPasoAPaso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.help.SetToolTip(this.btnPasoAPaso, "(F11)");
            this.btnPasoAPaso.UseVisualStyleBackColor = false;
            this.btnPasoAPaso.Click += new System.EventHandler(this.btnPasoAPaso_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(594, 567);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(409, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(89, 28);
            this.btnHelp.TabIndex = 77;
            this.btnHelp.Text = "Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.AutoCompleteBrackets = true;
            this.txtCodigo.AutoCompleteBracketsList = new char[] {
        '\0',
        '\0',
        '\0',
        '\0',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtCodigo.AutoIndentCharsPatterns = "\r\n";
            this.txtCodigo.AutoScrollMinSize = new System.Drawing.Size(0, 462);
            this.txtCodigo.BackBrush = null;
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.txtCodigo.CharHeight = 22;
            this.txtCodigo.CharWidth = 10;
            this.txtCodigo.CommentPrefix = ";";
            this.txtCodigo.ContextMenuStrip = this.Menu;
            this.txtCodigo.CurrentLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigo.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtCodigo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.ForeColor = System.Drawing.Color.White;
            this.txtCodigo.Hotkeys = resources.GetString("txtCodigo.Hotkeys");
            this.txtCodigo.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.txtCodigo.IsReplaceMode = false;
            this.txtCodigo.LineNumberColor = System.Drawing.Color.White;
            this.txtCodigo.Location = new System.Drawing.Point(8, 47);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Paddings = new System.Windows.Forms.Padding(0);
            this.txtCodigo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtCodigo.ServiceColors = null;
            this.txtCodigo.ShowScrollBars = false;
            this.txtCodigo.Size = new System.Drawing.Size(634, 503);
            this.txtCodigo.TabIndex = 75;
            this.txtCodigo.Text = resources.GetString("txtCodigo.Text");
            this.help.SetToolTip(this.txtCodigo, "Click derecho para abrir el menú\r\nCtrl + Espacio (Ayudante)");
            this.txtCodigo.ToolTip = null;
            this.txtCodigo.WordWrap = true;
            this.txtCodigo.Zoom = 100;
            this.txtCodigo.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtCodigo_TextChanged);
            this.txtCodigo.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtCodigo_TextChangedDelayed);
            this.txtCodigo.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtCodigo_DragDrop);
            this.txtCodigo.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtCodigo_DragEnter);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(443, 609);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 82;
            this.label2.Text = "KeyTest:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTestKey
            // 
            this.txtTestKey.AcceptsReturn = true;
            this.txtTestKey.AcceptsTab = true;
            this.txtTestKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTestKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.txtTestKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTestKey.ForeColor = System.Drawing.Color.White;
            this.txtTestKey.Location = new System.Drawing.Point(530, 609);
            this.txtTestKey.Name = "txtTestKey";
            this.txtTestKey.ReadOnly = true;
            this.txtTestKey.Size = new System.Drawing.Size(58, 19);
            this.txtTestKey.TabIndex = 83;
            this.txtTestKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTestKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTestKey_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.bcBaseNumerica);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(132, 559);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 70);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Numeric Base";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cbFrecuencia);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 558);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frecuency";
            // 
            // cbInput
            // 
            this.cbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbInput.AutoSize = true;
            this.cbInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbInput.ForeColor = System.Drawing.Color.White;
            this.cbInput.Location = new System.Drawing.Point(447, 583);
            this.cbInput.Name = "cbInput";
            this.cbInput.Size = new System.Drawing.Size(118, 23);
            this.cbInput.TabIndex = 84;
            this.cbInput.Text = "Input data";
            this.cbInput.UseVisualStyleBackColor = true;
            // 
            // cbFullScreen
            // 
            this.cbFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFullScreen.AutoSize = true;
            this.cbFullScreen.Font = new System.Drawing.Font("Consolas", 12F);
            this.cbFullScreen.ForeColor = System.Drawing.Color.White;
            this.cbFullScreen.Location = new System.Drawing.Point(447, 559);
            this.cbFullScreen.Name = "cbFullScreen";
            this.cbFullScreen.Size = new System.Drawing.Size(127, 23);
            this.cbFullScreen.TabIndex = 0;
            this.cbFullScreen.Text = "Full Screen";
            this.cbFullScreen.UseVisualStyleBackColor = true;
            this.cbFullScreen.CheckedChanged += new System.EventHandler(this.cbFullScreen_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cbA);
            this.groupBox2.Controls.Add(this.cbC);
            this.groupBox2.Controls.Add(this.cbInstrucciones);
            this.groupBox2.Controls.Add(this.cbB);
            this.groupBox2.Controls.Add(this.cbD);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(281, 558);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 70);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Markers";
            // 
            // cbA
            // 
            this.cbA.AutoSize = true;
            this.cbA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbA.Location = new System.Drawing.Point(6, 21);
            this.cbA.Name = "cbA";
            this.cbA.Size = new System.Drawing.Size(37, 23);
            this.cbA.TabIndex = 20;
            this.cbA.Text = "A";
            this.cbA.UseVisualStyleBackColor = true;
            this.cbA.CheckedChanged += new System.EventHandler(this.CheckedChangeds);
            this.cbA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            // 
            // cbC
            // 
            this.cbC.AutoSize = true;
            this.cbC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbC.Location = new System.Drawing.Point(75, 21);
            this.cbC.Name = "cbC";
            this.cbC.Size = new System.Drawing.Size(37, 23);
            this.cbC.TabIndex = 22;
            this.cbC.Text = "C";
            this.cbC.UseVisualStyleBackColor = true;
            this.cbC.CheckedChanged += new System.EventHandler(this.CheckedChangeds);
            this.cbC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            // 
            // cbInstrucciones
            // 
            this.cbInstrucciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbInstrucciones.AutoSize = true;
            this.cbInstrucciones.Checked = true;
            this.cbInstrucciones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInstrucciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbInstrucciones.ForeColor = System.Drawing.Color.White;
            this.cbInstrucciones.Location = new System.Drawing.Point(6, 41);
            this.cbInstrucciones.Name = "cbInstrucciones";
            this.cbInstrucciones.Size = new System.Drawing.Size(136, 23);
            this.cbInstrucciones.TabIndex = 25;
            this.cbInstrucciones.Text = "Instructions";
            this.cbInstrucciones.UseVisualStyleBackColor = true;
            this.cbInstrucciones.CheckedChanged += new System.EventHandler(this.CheckedChangeds);
            this.cbInstrucciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            // 
            // cbB
            // 
            this.cbB.AutoSize = true;
            this.cbB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbB.Location = new System.Drawing.Point(40, 21);
            this.cbB.Name = "cbB";
            this.cbB.Size = new System.Drawing.Size(37, 23);
            this.cbB.TabIndex = 21;
            this.cbB.Text = "B";
            this.cbB.UseVisualStyleBackColor = true;
            this.cbB.CheckedChanged += new System.EventHandler(this.CheckedChangeds);
            this.cbB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            // 
            // cbD
            // 
            this.cbD.AutoSize = true;
            this.cbD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbD.Location = new System.Drawing.Point(112, 21);
            this.cbD.Name = "cbD";
            this.cbD.Size = new System.Drawing.Size(37, 23);
            this.cbD.TabIndex = 23;
            this.cbD.Text = "D";
            this.cbD.UseVisualStyleBackColor = true;
            this.cbD.CheckedChanged += new System.EventHandler(this.CheckedChangeds);
            this.cbD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            // 
            // documentMap1
            // 
            this.documentMap1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.documentMap1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.documentMap1.ForeColor = System.Drawing.Color.White;
            this.documentMap1.Location = new System.Drawing.Point(454, 303);
            this.documentMap1.Name = "documentMap1";
            this.documentMap1.Size = new System.Drawing.Size(189, 247);
            this.documentMap1.TabIndex = 0;
            this.documentMap1.Target = this.txtCodigo;
            this.documentMap1.Text = "documentMap1";
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1059, 642);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnPasoAPaso);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.cbInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.documentMap1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtTestKey);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cbFullScreen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstVEtiquetas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Salida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Registros);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RAM);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1075, 680);
            this.Name = "Formulario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assembler Simulator - V-R1004 - v0.0.1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Formulario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel RAM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel Registros;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel Salida;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem btnCerrarGuardar;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pararToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasoAPasoToolStripMenuItem;
        private System.Windows.Forms.ListView lstVEtiquetas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox bcBaseNumerica;
        private System.Windows.Forms.Timer graficador;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Button btnPasoAPaso;
        private System.Windows.Forms.ComboBox cbFrecuencia;
        private FastColoredTextBoxNS.FastColoredTextBox txtCodigo;
        private FastColoredTextBoxNS.DocumentMap documentMap1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolTip help;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem codigosEjemploToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnHolaMundo;
        private System.Windows.Forms.ToolStripMenuItem btnInputData;
        private System.Windows.Forms.ToolStripMenuItem btnNumerosPrimos;
        private System.Windows.Forms.CheckBox cbInput;
        private System.Windows.Forms.CheckBox cbFullScreen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbA;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.CheckBox cbInstrucciones;
        private System.Windows.Forms.CheckBox cbB;
        private System.Windows.Forms.CheckBox cbD;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
    }
}

