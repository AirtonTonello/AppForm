using AppForms.Model;
using System;
using System.Windows.Forms;

namespace AppForms
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Registra Log
            Log log = new Log();
            log.RegistrarLog("Iniciando...");
            #endregion

            Application.Run(new FormPrincipal());
        }
    }
}
