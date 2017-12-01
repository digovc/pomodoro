using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                return;
            }

            Thread.Sleep(15 * 1000);

            this.atualizar();
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

            if (decPercentualConcluido < (100 / 8 * 1))
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

            if (decPercentualConcluido < (100 / 8 * 2))
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

            if (decPercentualConcluido < (100 / 8 * 3))
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

            if (decPercentualConcluido < (100 / 8 * 4))
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

            if (decPercentualConcluido < (100 / 8 * 5))
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

            if (decPercentualConcluido < (100 / 8 * 6))
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

            if (decPercentualConcluido < (100 / 8 * 7))
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

            if (decPercentualConcluido < (100 / 8 * 8))
            {
                switch (this.enmTipo)
                {
                    case EnmTipo.INTERVALO_CURTO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_curto_8;
                        return;

                    case EnmTipo.INTERVALO_LONGO:
                        this.nti.Icon = Properties.Resources.icon_intervalo_longo_8;
                        return;

                    default:
                        this.nti.Icon = Properties.Resources.icon_pomodoro_8;
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
            var strTitulo = this.getStrTitulo();

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

        private string getStrTitulo()
        {
            switch (this.enmTipo)
            {
                case EnmTipo.INTERVALO_CURTO:
                    return "Intervalo curto ({0})";

                case EnmTipo.INTERVALO_LONGO:
                    return "Intervalo longo ({0})";

                default:
                    return "Pomodoro ({0})";
            }
        }

        private TimeSpan getTmsTempoRestante()
        {
            return (this.dttInicio.AddMinutes(this.getIntMinutoDuracao()) - DateTime.Now);
        }

        private void iniciarIntervalo(EnmTipo enmTipo)
        {
            this.dttInicio = DateTime.Now;
            this.enmTipo = enmTipo;

            if (this.trdAtual != null)
            {
                this.lstTrdCancelada.Add(this.trdAtual);
            }

            this.trdAtual = new Thread(this.atualizar);

            this.trdAtual.IsBackground = true;
            this.trdAtual.Priority = ThreadPriority.Lowest;

            this.trdAtual.Start();
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

            this.nti.Visible = true;
            this.Visible = false;
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