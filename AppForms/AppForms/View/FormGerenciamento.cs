using AppForms.Control;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AppForms.View
{
    public partial class FormGerenciamento : Form
    {
        public FormGerenciamento()
        {
            InitializeComponent();
        }

        #region Form Load
        private void FormGerenciamento_Load(object sender, EventArgs e)
        {
            AlarmeControl control = new AlarmeControl();

            DataTable dt = new DataTable();
            dt = control.GetAlarmesPorEquipamento();

            if (dgvAlarmes.Rows.Count > 0)
            {
                dgvAlarmes.Rows.Clear();
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row[7].ToString() != string.Empty)
                {
                    dgvAlarmes.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], Convert.ToDateTime(row[6]).ToShortDateString(), Convert.ToDateTime(row[7]).ToShortDateString());
                }
                else
                {
                    dgvAlarmes.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], Convert.ToDateTime(row[6]).ToShortDateString(), string.Empty);
                }
            }

            cbFiltro.Text = "TODOS";
        }
        #endregion

        #region Botão Pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbID.Text) && String.IsNullOrEmpty(tbDescricao.Text))
            {
                foreach (DataGridViewRow row in dgvAlarmes.Rows)
                {
                    row.Visible = true;
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(tbID.Text))
                {
                    foreach (DataGridViewRow row in dgvAlarmes.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(tbID.Text))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
                else if (!String.IsNullOrEmpty(tbDescricao.Text))
                {
                    foreach (DataGridViewRow row in dgvAlarmes.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Contains(tbDescricao.Text.ToUpper()))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
        }
        #endregion

        #region ComboBox Fltro
        private void cbFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbFiltro.Text)
            {
                case "ATIVOS": OrdenaAtivos(); break;
                case "MAIS RECENTE": OrdenaMaisRecente(); break;
                case "MAIS UTILIZADOS": MaisUtilizado(); break;
                case "TODOS": Todos(); break;
            }
        }

        //Função Todos
        private void Todos()
        {
            foreach (DataGridViewRow row in dgvAlarmes.Rows)
            {
                row.Visible = true;
            }

            dgvAlarmes.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAlarmes.Sort(dgvAlarmes.Columns[0], ListSortDirection.Ascending);
        }

        //Função Ordena Alarmes Ativos
        private void OrdenaAtivos()
        {
            foreach (DataGridViewRow row in dgvAlarmes.Rows)
            {
                if (row.Cells[5].Value.ToString().Equals("ON"))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        //Função Ordena Por Mais Recente
        private void OrdenaMaisRecente()
        {
            dgvAlarmes.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAlarmes.Sort(dgvAlarmes.Columns[6], ListSortDirection.Descending);
        }

        //Função Form Mais Utilizados
        private void MaisUtilizado()
        {
            FormMaisUtilizados fUtil = new FormMaisUtilizados();
            fUtil.ShowDialog();
        }
        #endregion

        #region Botão Limpar Filtros
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            tbID.Text = string.Empty;
            tbDescricao.Text = string.Empty;
            cbFiltro.Text = "TODOS";
            Todos();
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
