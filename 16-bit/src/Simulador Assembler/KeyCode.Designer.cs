namespace Simulador_Assembler
{
    partial class KeyCode
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 84;
            this.label2.Text = "KeyTest:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTestKey
            // 
            this.txtTestKey.AcceptsReturn = true;
            this.txtTestKey.AcceptsTab = true;
            this.txtTestKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestKey.BackColor = System.Drawing.Color.White;
            this.txtTestKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTestKey.ForeColor = System.Drawing.Color.Black;
            this.txtTestKey.Location = new System.Drawing.Point(100, 15);
            this.txtTestKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtTestKey.Name = "txtTestKey";
            this.txtTestKey.ReadOnly = true;
            this.txtTestKey.Size = new System.Drawing.Size(116, 19);
            this.txtTestKey.TabIndex = 85;
            this.txtTestKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTestKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTestKey_KeyDown);
            // 
            // KeyCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(229, 47);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTestKey);
            this.Font = new System.Drawing.Font("Consolas", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(245, 86);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(245, 86);
            this.Name = "KeyCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Code";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestKey;
    }
}