namespace Simulador_Assembler
{
    partial class EditarImagenes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbSprites = new System.Windows.Forms.PictureBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblHEX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.pbSelected = new System.Windows.Forms.PictureBox();
            this.graficador = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRAM = new System.Windows.Forms.TrackBar();
            this.lblPosicion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSprites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRAM)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSprites
            // 
            this.pbSprites.BackColor = System.Drawing.Color.White;
            this.pbSprites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSprites.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbSprites.Location = new System.Drawing.Point(537, 32);
            this.pbSprites.Margin = new System.Windows.Forms.Padding(4);
            this.pbSprites.Name = "pbSprites";
            this.pbSprites.Size = new System.Drawing.Size(258, 258);
            this.pbSprites.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSprites.TabIndex = 128;
            this.pbSprites.TabStop = false;
            this.pbSprites.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSprites_MouseDown);
            this.pbSprites.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSprites_MouseMove);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.ForeColor = System.Drawing.Color.White;
            this.lblX.Location = new System.Drawing.Point(533, 9);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(45, 19);
            this.lblX.TabIndex = 92;
            this.lblX.Text = "X: 0";
            // 
            // lblHEX
            // 
            this.lblHEX.AutoSize = true;
            this.lblHEX.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblHEX.ForeColor = System.Drawing.Color.White;
            this.lblHEX.Location = new System.Drawing.Point(13, 9);
            this.lblHEX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEX.Name = "lblHEX";
            this.lblHEX.Size = new System.Drawing.Size(144, 19);
            this.lblHEX.TabIndex = 124;
            this.lblHEX.Text = "Address: 0x0000";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.ForeColor = System.Drawing.Color.White;
            this.lblY.Location = new System.Drawing.Point(609, 9);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(45, 19);
            this.lblY.TabIndex = 93;
            this.lblY.Text = "Y: 0";
            // 
            // pbSelected
            // 
            this.pbSelected.BackColor = System.Drawing.Color.White;
            this.pbSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSelected.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbSelected.Location = new System.Drawing.Point(17, 32);
            this.pbSelected.Margin = new System.Windows.Forms.Padding(4);
            this.pbSelected.Name = "pbSelected";
            this.pbSelected.Size = new System.Drawing.Size(514, 258);
            this.pbSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelected.TabIndex = 90;
            this.pbSelected.TabStop = false;
            this.pbSelected.Click += new System.EventHandler(this.pbSelected_Click);
            this.pbSelected.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSelected_MouseMove);
            // 
            // graficador
            // 
            this.graficador.Enabled = true;
            this.graficador.Interval = 33;
            this.graficador.Tick += new System.EventHandler(this.graficador_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(317, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 129;
            this.label1.Text = "SX:0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(393, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 130;
            this.label2.Text = "SY:0";
            // 
            // tbRAM
            // 
            this.tbRAM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.tbRAM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbRAM.LargeChange = 512;
            this.tbRAM.Location = new System.Drawing.Point(17, 312);
            this.tbRAM.Maximum = 65024;
            this.tbRAM.Name = "tbRAM";
            this.tbRAM.Size = new System.Drawing.Size(778, 45);
            this.tbRAM.SmallChange = 512;
            this.tbRAM.TabIndex = 131;
            this.tbRAM.TickFrequency = 512;
            this.tbRAM.Value = 64768;
            this.tbRAM.Scroll += new System.EventHandler(this.tbRAM_Scroll);
            // 
            // lblPosicion
            // 
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.ForeColor = System.Drawing.Color.White;
            this.lblPosicion.Location = new System.Drawing.Point(21, 294);
            this.lblPosicion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(261, 19);
            this.lblPosicion.TabIndex = 132;
            this.lblPosicion.Text = "RAM Address: 0xFD00 - 0xFEFF";
            // 
            // EditarImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(807, 348);
            this.Controls.Add(this.lblPosicion);
            this.Controls.Add(this.tbRAM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbSprites);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblHEX);
            this.Controls.Add(this.pbSelected);
            this.Controls.Add(this.lblY);
            this.Font = new System.Drawing.Font("Consolas", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditarImagenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphics";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditarImagenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSprites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRAM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbSprites;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblHEX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.PictureBox pbSelected;
        private System.Windows.Forms.Timer graficador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbRAM;
        private System.Windows.Forms.Label lblPosicion;
    }
}