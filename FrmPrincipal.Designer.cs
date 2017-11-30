namespace Pomodoro
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.nti = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmPomodoro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIntervaloCurto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIntervaloLongo = new System.Windows.Forms.ToolStripMenuItem();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // nti
            // 
            this.nti.BalloonTipTitle = "Pomodoro";
            this.nti.ContextMenuStrip = this.cms;
            this.nti.Icon = ((System.Drawing.Icon)(resources.GetObject("nti.Icon")));
            this.nti.Text = "Pomodoro";
            this.nti.Visible = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPomodoro,
            this.tsmIntervaloCurto,
            this.tsmIntervaloLongo});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(155, 70);
            // 
            // tsmPomodoro
            // 
            this.tsmPomodoro.Name = "tsmPomodoro";
            this.tsmPomodoro.Size = new System.Drawing.Size(154, 22);
            this.tsmPomodoro.Text = "Pomodoro";
            this.tsmPomodoro.Click += new System.EventHandler(this.tsmPomodoro_Click);
            // 
            // tsmIntervaloCurto
            // 
            this.tsmIntervaloCurto.Name = "tsmIntervaloCurto";
            this.tsmIntervaloCurto.Size = new System.Drawing.Size(154, 22);
            this.tsmIntervaloCurto.Text = "Intervalo curto";
            // 
            // tsmIntervaloLongo
            // 
            this.tsmIntervaloLongo.Name = "tsmIntervaloLongo";
            this.tsmIntervaloLongo.Size = new System.Drawing.Size(154, 22);
            this.tsmIntervaloLongo.Text = "Intervalo longo";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.ShowInTaskbar = false;
            this.Text = "Pomodoro";
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nti;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmPomodoro;
        private System.Windows.Forms.ToolStripMenuItem tsmIntervaloCurto;
        private System.Windows.Forms.ToolStripMenuItem tsmIntervaloLongo;
    }
}