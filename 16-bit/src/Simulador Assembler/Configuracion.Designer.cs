namespace Simulador_Assembler
{
    partial class Configuracion
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
            this.lblSprites = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.tbScreen = new System.Windows.Forms.TrackBar();
            this.lblText = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.TrackBar();
            this.tbSprites = new System.Windows.Forms.TrackBar();
            this.lblInput = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TrackBar();
            this.lblSP = new System.Windows.Forms.Label();
            this.tbSP = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSprites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSP)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSprites
            // 
            this.lblSprites.AutoSize = true;
            this.lblSprites.ForeColor = System.Drawing.Color.White;
            this.lblSprites.Location = new System.Drawing.Point(13, 9);
            this.lblSprites.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSprites.Name = "lblSprites";
            this.lblSprites.Size = new System.Drawing.Size(297, 19);
            this.lblSprites.TabIndex = 134;
            this.lblSprites.Text = "Posición en RAM: 0xFD00 - 0xFEFF";
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.ForeColor = System.Drawing.Color.White;
            this.lblScreen.Location = new System.Drawing.Point(13, 75);
            this.lblScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(297, 19);
            this.lblScreen.TabIndex = 136;
            this.lblScreen.Text = "Posición en RAM: 0xFD00 - 0xFEFF";
            // 
            // tbScreen
            // 
            this.tbScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.tbScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbScreen.LargeChange = 4096;
            this.tbScreen.Location = new System.Drawing.Point(9, 93);
            this.tbScreen.Maximum = 61440;
            this.tbScreen.Name = "tbScreen";
            this.tbScreen.Size = new System.Drawing.Size(780, 45);
            this.tbScreen.SmallChange = 4096;
            this.tbScreen.TabIndex = 135;
            this.tbScreen.TickFrequency = 4096;
            this.tbScreen.Value = 61440;
            this.tbScreen.Scroll += new System.EventHandler(this.tbScreen_Scroll);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(13, 141);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(297, 19);
            this.lblText.TabIndex = 138;
            this.lblText.Text = "Posición en RAM: 0xFD00 - 0xFEFF";
            // 
            // tbText
            // 
            this.tbText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.tbText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbText.LargeChange = 32;
            this.tbText.Location = new System.Drawing.Point(9, 159);
            this.tbText.Maximum = 65504;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(780, 45);
            this.tbText.SmallChange = 32;
            this.tbText.TabIndex = 137;
            this.tbText.TickFrequency = 32;
            this.tbText.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbText.Value = 64768;
            this.tbText.Scroll += new System.EventHandler(this.tbText_Scroll);
            // 
            // tbSprites
            // 
            this.tbSprites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.tbSprites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbSprites.LargeChange = 512;
            this.tbSprites.Location = new System.Drawing.Point(9, 27);
            this.tbSprites.Maximum = 65024;
            this.tbSprites.Name = "tbSprites";
            this.tbSprites.Size = new System.Drawing.Size(786, 45);
            this.tbSprites.SmallChange = 512;
            this.tbSprites.TabIndex = 139;
            this.tbSprites.TickFrequency = 512;
            this.tbSprites.Value = 64768;
            this.tbSprites.Scroll += new System.EventHandler(this.tbSprites_Scroll);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.ForeColor = System.Drawing.Color.White;
            this.lblInput.Location = new System.Drawing.Point(13, 185);
            this.lblInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(297, 19);
            this.lblInput.TabIndex = 141;
            this.lblInput.Text = "Posición en RAM: 0xFD00 - 0xFEFF";
            // 
            // tbInput
            // 
            this.tbInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.tbInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbInput.LargeChange = 32;
            this.tbInput.Location = new System.Drawing.Point(9, 203);
            this.tbInput.Maximum = 65535;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(780, 45);
            this.tbInput.SmallChange = 32;
            this.tbInput.TabIndex = 140;
            this.tbInput.TickFrequency = 32;
            this.tbInput.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbInput.Value = 64768;
            this.tbInput.Scroll += new System.EventHandler(this.tbInput_Scroll);
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.ForeColor = System.Drawing.Color.White;
            this.lblSP.Location = new System.Drawing.Point(13, 229);
            this.lblSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(297, 19);
            this.lblSP.TabIndex = 143;
            this.lblSP.Text = "Posición en RAM: 0xFD00 - 0xFEFF";
            // 
            // tbSP
            // 
            this.tbSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.tbSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbSP.LargeChange = 32;
            this.tbSP.Location = new System.Drawing.Point(9, 247);
            this.tbSP.Maximum = 65535;
            this.tbSP.Name = "tbSP";
            this.tbSP.Size = new System.Drawing.Size(780, 45);
            this.tbSP.SmallChange = 32;
            this.tbSP.TabIndex = 142;
            this.tbSP.TickFrequency = 32;
            this.tbSP.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSP.Value = 64768;
            this.tbSP.Scroll += new System.EventHandler(this.tbSP_Scroll);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(801, 281);
            this.Controls.Add(this.lblSP);
            this.Controls.Add(this.tbSP);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.tbSprites);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.tbScreen);
            this.Controls.Add(this.lblSprites);
            this.Font = new System.Drawing.Font("Consolas", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(817, 278);
            this.Name = "Configuracion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Configuracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSprites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSprites;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.TrackBar tbScreen;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TrackBar tbText;
        private System.Windows.Forms.TrackBar tbSprites;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TrackBar tbInput;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.TrackBar tbSP;
    }
}