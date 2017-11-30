using System;
using System.ComponentModel;
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

        #endregion Atributos

        #region Construtores

        private FrmPrincipal()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        private void iniciarIntervalo(EnmTipo enmTipo)
        {
            this.dttInicio = DateTime.Now;

            this.nti.Icon = Properties
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

        private void tsmPomodoro_Click(object sender, EventArgs e)
        {
            this.iniciarIntervalo(EnmTipo.POMODORO);
        }

        #endregion Eventos
    }
}