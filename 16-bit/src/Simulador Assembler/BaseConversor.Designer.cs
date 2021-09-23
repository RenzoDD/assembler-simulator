namespace Simulador_Assembler
{
    partial class BaseConversor
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
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDEC = new System.Windows.Forms.TextBox();
            this.txtHEX = new System.Windows.Forms.TextBox();
            this.txtBIN = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 19);
            this.label7.TabIndex = 195;
            this.label7.Text = "Bin:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Consolas", 12F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(12, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 19);
            this.label22.TabIndex = 193;
            this.label22.Text = "Dec:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDEC
            // 
            this.txtDEC.AcceptsReturn = true;
            this.txtDEC.AcceptsTab = true;
            this.txtDEC.BackColor = System.Drawing.Color.White;
            this.txtDEC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDEC.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtDEC.ForeColor = System.Drawing.Color.Black;
            this.txtDEC.Location = new System.Drawing.Point(14, 31);
            this.txtDEC.MaxLength = 5;
            this.txtDEC.Name = "txtDEC";
            this.txtDEC.Size = new System.Drawing.Size(77, 19);
            this.txtDEC.TabIndex = 194;
            this.txtDEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDEC.TextChanged += new System.EventHandler(this.txtHEX_TextChanged);
            this.txtDEC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDEC_KeyPress);
            // 
            // txtHEX
            // 
            this.txtHEX.AcceptsTab = true;
            this.txtHEX.BackColor = System.Drawing.Color.White;
            this.txtHEX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHEX.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtHEX.ForeColor = System.Drawing.Color.Black;
            this.txtHEX.Location = new System.Drawing.Point(95, 31);
            this.txtHEX.MaxLength = 4;
            this.txtHEX.Name = "txtHEX";
            this.txtHEX.Size = new System.Drawing.Size(77, 19);
            this.txtHEX.TabIndex = 192;
            this.txtHEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHEX.TextChanged += new System.EventHandler(this.txtHEX_TextChanged);
            this.txtHEX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHEX_KeyPress);
            // 
            // txtBIN
            // 
            this.txtBIN.AcceptsReturn = true;
            this.txtBIN.AcceptsTab = true;
            this.txtBIN.BackColor = System.Drawing.Color.White;
            this.txtBIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBIN.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtBIN.ForeColor = System.Drawing.Color.Black;
            this.txtBIN.Location = new System.Drawing.Point(16, 75);
            this.txtBIN.MaxLength = 16;
            this.txtBIN.Name = "txtBIN";
            this.txtBIN.Size = new System.Drawing.Size(156, 19);
            this.txtBIN.TabIndex = 196;
            this.txtBIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBIN.TextChanged += new System.EventHandler(this.txtHEX_TextChanged);
            this.txtBIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBIN_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Consolas", 12F);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(100, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 19);
            this.label21.TabIndex = 191;
            this.label21.Text = "Hex:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaseConversor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(188, 113);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtDEC);
            this.Controls.Add(this.txtHEX);
            this.Controls.Add(this.txtBIN);
            this.Controls.Add(this.label21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(204, 152);
            this.MinimumSize = new System.Drawing.Size(204, 152);
            this.Name = "BaseConversor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numeric Base";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtDEC;
        private System.Windows.Forms.TextBox txtHEX;
        private System.Windows.Forms.TextBox txtBIN;
        private System.Windows.Forms.Label label21;
    }
}