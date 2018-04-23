using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class FrmPrincipal : Form
    {
        #region Constantes

        private enum EnmTipo
        {
            INTERVALO_CURTO,
            INTERVALO_LONGO,
            POMODORO,
        }

        #endregion Constantes

        #region Atributos

        private DateTime _dttInicio;
        private EnmTipo _enmTipo;
        private List<Thread> _lstTrdCancelada;
        private StringBuilder _stbHistorico;
        private Thread _trdAtual;

        private DateTime dttInicio
        {
            get
            {
                return _dttInicio;
            }

            set
            {
                _dttInicio = value;
            }
        }

        private EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
            }
        }

        private List<Thread> lstTrdCancelada
        {
            get
            {
                if (_lstTrdCancelada != null)
                {
                    return _lstTrdCancelada;
                }

                _lstTrdCancelada = new List<Thread>();

                return _lstTrdCancelada;
            }
        }

        private StringBuilder stbHistorico
        {
            get
            {
                if (_stbHistorico != null)
                {
                    return _stbHistorico;
                }

                _stbHistorico = new StringBuilder("Histórico de intervalos:" + Environment.NewLine + Environment.NewLine);

                return _stbHistorico;
            }
        }

        private Thread trdAtual
        {
            get
            {
                return _trdAtual;
            }

            set
            {
                _trdAtual = value;
            }
        }

        #endregion Atributos

        #region Construtores

        private FrmPrincipal()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void abrirHistorico()
        {
            Clipboard.SetText(this.stbHistorico.ToString());

            this.nti.ShowBalloonTip(250, "Histórico", "Histórico copiado para área de transferência.", ToolTipIcon.None);
        }

        private void addHistorico(string strEvento)
        {
            this.stbHistorico.AppendLine(DateTime.Now.ToString("HH:mm: ") + strEvento);
        }

        private void atualizar()
        {
            if (this.lstTrdCancelada.Contains(Thread.CurrentThread))
            {
                this.lstTrdCancelada.Remove(Thread.CurrentThread);
                return;
            }

            var tmsRestante = this.getTmsTempoRestante();

            this.atualizarIcon(tmsRestante);
            this.atualizarTitulo(tmsRestante);

            if (tmsRestante.TotalMilliseconds < 0)
            {
                this.atualizarConcluir();
                return;
            }

            Thread.Sleep(15 * 1000);

            this.atualizar();
        }

        private void atualizarConcluir()
        {
            var strDescricao = string.Empty;
            var strTitulo = string.Empty;

            switch (this.enmTipo)
            {
                case EnmTipo.INTERVALO_CURTO:
                    strDescricao = "O intervalo curto acabou.";
                    strTitulo = "Intervalo concluído";
                    this.addHistorico("Intervalo curto concluído");
                    break;

                case EnmTipo.INTERVALO_LONGO:
                    strDescricao = "O intervalo longo acabou.";
                    strTitulo = "Intervalo concluído";
                    this.addHistorico("Intervalo longo concluído;");
                    break;

                default:
                    strDescricao = "O pomodoro acabou.";
                    strTitulo = "Pomodoro";
                    this.addHistorico("Pomodoro concluído;");
                    break;
            }

            this.nti.ShowBalloonTip(250, strTitulo, strDescricao, ToolTipIcon.None);
        }

        private void atualizarIcon(TimeSpan tmsRestante)
        {
            if (tmsRestante.TotalMilliseconds < 0)
            {
                this.atualizarIconFinished();
                return;
            }

            var intDuracao = this.getIntMinutoDuracao();

            var decPercentualConcluido = ((intDuracao - tmsRestante.TotalMinutes) / intDuracao * 100);

            if (decPercentualConcluido < (100 / 7 * .5))
            {
                this.nti.Icon = Properties.Resources.icon_empty;
                return;
            }

            if (decPercentualConcluido < (100 / 7 * 1))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_1;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_1;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_1;
                        return;
                }
            }

            if (decPercentualConcluido < (100 / 7 * 2))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_2;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_2;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_2;
                        return;
                }
            }

            if (decPercentualConcluido < (100 / 7 * 3))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_3;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_3;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_3;
                        return;
                }
            }

            if (decPercentualConcluido < (100 / 7 * 4))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_4;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_4;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_4;
                        return;
                }
            }

            if (decPercentualConcluido < (100 / 7 * 5))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_5;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_5;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_5;
                        return;
                }
            }

            if (decPercentualConcluido < (100 / 7 * 6))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_6;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_6;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_6;
                        return;
                }
            }

            if (decPercentualConcluido < (100 / 7 * 7))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_7;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_7;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_7;
                        return;
                }
            }
        }

        private void atualizarIconFinished()
        {
            switch (this.enmTipo)
            {
                case EnmTipo.INTERVALO_CURTO:
                    this.nti.Icon = Properties.Resources.icon_intervalo_curto_finished;
                    return;

                case EnmTipo.INTERVALO_LONGO:
                    this.nti.Icon = Properties.Resources.icon_intervalo_longo_finished;
                    return;

                default:
                    this.nti.Icon = Properties.Resources.icon_pomodoro_finished;
                    return;
            }
        }

        private void atualizarTitulo(TimeSpan tmsRestante)
        {
            var strTitulo = this.getStrTitulo(tmsRestante);

            strTitulo = string.Format(strTitulo, Math.Round(tmsRestante.TotalMinutes));

            this.Invoke(new Action(() => this.nti.Text = strTitulo));
        }

        private int getIntMinutoDuracao()
        {
            switch (this.enmTipo)
            {
                case EnmTipo.INTERVALO_CURTO:
                    return 3;

                case EnmTipo.INTERVALO_LONGO:
                    return 15;

                default:
                    return 25;
            }
        }

        private string getStrTitulo(TimeSpan tmsRestante)
        {
            switch (this.enmTipo)
            {
                case EnmTipo.INTERVALO_CURTO:

                    if (tmsRestante.TotalMinutes < 2)
                    {
                        return "Intervalo curto (1 minuto restante)";
                    }
                    else
                    {
                        return "Intervalo curto ({0} minutos restantes)";
                    }

                case EnmTipo.INTERVALO_LONGO:

                    if (tmsRestante.TotalMinutes < 2)
                    {
                        return "Intervalo longo (1 minuto restante)";
                    }
                    else
                    {
                        return "Intervalo longo ({0} minutos restantes)";
                    }

                default:

                    if (tmsRestante.TotalMinutes < 2)
                    {
                        return "Pomodoro (1 minuto restante)";
                    }
                    else
                    {
                        return "Pomodoro ({0} minutos restantes)";
                    }
            }
        }

        private TimeSpan getTmsTempoRestante()
        {
            return (this.dttInicio.AddMinutes(this.getIntMinutoDuracao()) - DateTime.Now);
        }

        private void iniciar()
        {
            this.nti.Visible = true;
            this.Visible = false;

            this.iniciarIniciarJuntoWindows();
        }

        private void iniciarIniciarJuntoWindows()
        {
#if DEBUG
            return;
#endif

            using (var objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                objRegistryKey.SetValue(Application.CompanyName, Application.ExecutablePath);
            }
        }

        private void iniciarIntervalo(EnmTipo enmTipo)
        {
            if (this.trdAtual != null)
            {
                this.lstTrdCancelada.Add(this.trdAtual);
            }

            this.dttInicio = DateTime.Now;
            this.enmTipo = enmTipo;

            this.trdAtual = new Thread(this.atualizar);

            this.trdAtual.IsBackground = true;
            this.trdAtual.Priority = ThreadPriority.Lowest;

            this.trdAtual.Start();

            this.iniciarIntervaloHistorico(enmTipo);
        }

        private void iniciarIntervaloHistorico(EnmTipo enmTipo)
        {
            switch (enmTipo)
            {
                case EnmTipo.INTERVALO_CURTO:
                    this.addHistorico("Intervalo curto iniciado;");
                    return;

                case EnmTipo.INTERVALO_LONGO:
                    this.addHistorico("Intervalo longo iniciado;");
                    return;

                default:
                    this.addHistorico("Pomodoro iniciado;");
                    return;
            }
        }

        #endregion Métodos

        #region Eventos

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.nti.Visible = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.iniciar();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmPrincipal());
        }

        private void tsmHistorico_Click(object sender, EventArgs e)
        {
            this.abrirHistorico();
        }

        private void tsmIntervaloCurto_Click(object sender, EventArgs e)
        {
            this.iniciarIntervalo(EnmTipo.INTERVALO_CURTO);
        }

        private void tsmIntervaloLongo_Click(object sender, EventArgs e)
        {
            this.iniciarIntervalo(EnmTipo.INTERVALO_LONGO);
        }

        private void tsmPomodoro_Click(object sender, EventArgs e)
        {
            this.iniciarIntervalo(EnmTipo.POMODORO);
        }

        #endregion Eventos
    }
}