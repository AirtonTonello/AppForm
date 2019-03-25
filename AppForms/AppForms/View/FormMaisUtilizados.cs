using AppForms.Control;
using System;
using System.Data;
using System.Windows.Forms;

namespace AppForms.View
{
    public partial class FormMaisUtilizados : Form
    {
        public FormMaisUtilizados()
        {
            InitializeComponent();
        }

        #region Form Load
        private void FormMaisUtilizados_Load(object sender, EventArgs e)
        {
            AlarmeControl control = new AlarmeControl();

            DataTable dt = new DataTable();
            dt = control.GetAlarmesMaisUtilizados();

            foreach (DataRow row in dt.Rows)
            {
                dgvMaisUtilizados.Rows.Add(row[0], row[1], row[2]);
            }
        }
        #endregion

        #region Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
