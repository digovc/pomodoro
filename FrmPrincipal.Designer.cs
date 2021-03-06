﻿namespace Pomodoro
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
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmHistorico = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsmIntervaloLongo,
            this.tss1,
            this.tsmHistorico});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(155, 98);
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
            this.tsmIntervaloCurto.Click += new System.EventHandler(this.tsmIntervaloCurto_Click);
            // 
            // tsmIntervaloLongo
            // 
            this.tsmIntervaloLongo.Name = "tsmIntervaloLongo";
            this.tsmIntervaloLongo.Size = new System.Drawing.Size(154, 22);
            this.tsmIntervaloLongo.Text = "Intervalo longo";
            this.tsmIntervaloLongo.Click += new System.EventHandler(this.tsmIntervaloLongo_Click);
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(151, 6);
            // 
            // tsmHistorico
            // 
            this.tsmHistorico.Name = "tsmHistorico";
            this.tsmHistorico.Size = new System.Drawing.Size(154, 22);
            this.tsmHistorico.Text = "Histórico";
            this.tsmHistorico.Click += new System.EventHandler(this.tsmHistorico_Click);
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
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ToolStripMenuItem tsmHistorico;
    }
}