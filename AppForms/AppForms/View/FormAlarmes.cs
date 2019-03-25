using AppForms.Control;
using AppForms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AppForms.View
{
    public partial class FormAlarmes : Form
    {
        public FormAlarmes()
        {
            InitializeComponent();
        }

        private bool ModoEdicao = false;
        private bool ModoNovo = false;

        #region Form Load
        private void FormAlarmes_Load(object sender, EventArgs e)
        {
            AlarmeControl control = new AlarmeControl();

            List<TipoAlarme> TipoAlarme = control.GetTipoAlarmes();
            cbTipo.DataSource = TipoAlarme;
            cbTipo.DisplayMember = "Tipo";
            cbTipo.ValueMember = "ID";

            cbStatus.DataSource = GetStatus();
            cbStatus.ValueMember = "Status";
            cbStatus.DisplayMember = "Valor";

            mtbDataCadastro.Text = DateTime.Now.ToShortDateString();

            btnSalvar.Enabled = false;
            AtualizaDataGridAlarmes();
        }
        #endregion

        #region Evento DataGridView
        private void dgvAlarmes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ModoEdicao == false)
            {
                tbID.Text = dgvAlarmes.CurrentRow.Cells[0].Value.ToString();
            }
        }
        #endregion

        #region Atualiza DataGridView
        private void AtualizaDataGridAlarmes()
        {
            AlarmeControl control = new AlarmeControl();

            DataTable dt = new DataTable();
            dt = control.GetAlarmes();

            if (dgvAlarmes.Rows.Count > 0)
            {
                dgvAlarmes.Rows.Clear();
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row[5].ToString() != string.Empty)
                {
                    dgvAlarmes.Rows.Add(row[0], row[1], row[2], row[3], Convert.ToDateTime(row[4]).ToShortDateString(), Convert.ToDateTime(row[5]).ToShortDateString());
                }
                else
                {
                    dgvAlarmes.Rows.Add(row[0], row[1], row[2], row[3], Convert.ToDateTime(row[4]).ToShortDateString(), string.Empty);
                }
            }
        }
        #endregion

        #region Limpar Formulario
        private void LimpaForm()
        {
            tbID.Text = string.Empty;
            tbDescricao.Text = string.Empty;
            cbStatus.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
            mtbDataCadastro.Text = DateTime.Today.ToShortDateString();
            mtbDataInativacao.Text = string.Empty;
        }
        #endregion

        #region ComboBox Status
        private List<StatusAlarme> GetStatus()
        {
            List<StatusAlarme> Lista = new List<StatusAlarme>();

            StatusAlarme on = new StatusAlarme()
            {
                Status = 1,
                Valor = "ON"
            };

            StatusAlarme off = new StatusAlarme()
            {
                Status = 0,
                Valor = "OFF"
            };

            Lista.Add(on);
            Lista.Add(off);

            return Lista;
        }
        #endregion

        #region Botão Novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbID.Enabled = false;
            tbDescricao.Enabled = true;
            cbTipo.Enabled = true;
            cbStatus.Enabled = true;

            btnPesquisar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnFechar.Text = "Cancelar";
            ModoNovo = true;

            tbDescricao.Focus();

            LimpaForm();
        }
        #endregion

        #region Botão Fechar
        //Botão Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (btnFechar.Text.Equals("Cancelar"))
            {
                Cancelar();
            }
            else
            {
                this.Close();
            }
        }

        //Evento Cancelar
        private void Cancelar()
        {
            btnFechar.Text = "Fechar";
            ModoEdicao = false;
            ModoNovo = false;
            LimpaForm();
            tbID.Focus();
            tbID.Enabled = true;
            tbDescricao.Enabled = false;
            cbStatus.Enabled = false;
            cbTipo.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            tbID.Focus();
        }
        #endregion

        #region Botão Salvar
        //Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AlarmeControl control = new AlarmeControl();
            Alarmes alarmes = new Alarmes();

            if (String.IsNullOrWhiteSpace(tbDescricao.Text))
            {
                MessageBox.Show("Nome do Alarme é obrigatório", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ModoEdicao)
                {
                    alarmes.ID = Convert.ToInt32(tbID.Text);
                    alarmes.Descricao = tbDescricao.Text;
                    alarmes.TipoAlarme = Convert.ToInt32(cbTipo.SelectedValue);
                    alarmes.Status = Convert.ToInt32(cbStatus.SelectedValue);

                    if (control.EditarAlarme(alarmes))
                    {
                        Salvar();
                        AtualizaDataGridAlarmes();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao editar Alarme!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cancelar();
                    }
                }
                else
                {
                    alarmes.Descricao = tbDescricao.Text;
                    alarmes.TipoAlarme = Convert.ToInt32(cbTipo.SelectedValue);
                    alarmes.Status = Convert.ToInt32(cbStatus.SelectedValue);

                    if (control.InserirAlarme(alarmes))
                    {
                        Salvar();
                        AtualizaDataGridAlarmes();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao inserir Equipamento!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Evento Salvar
        private void Salvar()
        {
            tbID.Enabled = true;
            tbDescricao.Enabled = false;
            cbStatus.Enabled = false;
            cbTipo.Enabled = false;

            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            btnFechar.Text = "Fechar";
            ModoEdicao = false;

            LimpaForm();

            tbID.Focus();
        }
        #endregion

        #region Botão Editar
        //Botão Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();

            if (String.IsNullOrWhiteSpace(tbID.Text))
            {
                if(dgvAlarmes.Rows.Count > 0)
                {
                    tbID.Text = dgvAlarmes.CurrentRow.Cells[0].Value.ToString();
                    tbDescricao.Text = dgvAlarmes.CurrentRow.Cells[1].Value.ToString();
                    cbTipo.Text = dgvAlarmes.CurrentRow.Cells[2].Value.ToString();
                    cbStatus.Text = dgvAlarmes.CurrentRow.Cells[3].Value.ToString();
                    mtbDataCadastro.Text = dgvAlarmes.CurrentRow.Cells[4].Value.ToString();
                    mtbDataInativacao.Text = dgvAlarmes.CurrentRow.Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Não existe Alarmes disponivéis!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                foreach (DataGridViewRow row in dgvAlarmes.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(tbID.Text))
                    {
                        tbID.Text = row.Cells[0].Value.ToString();
                        tbDescricao.Text = row.Cells[1].Value.ToString();
                        cbTipo.Text = row.Cells[2].Value.ToString();
                        cbStatus.Text = row.Cells[3].Value.ToString();
                        mtbDataCadastro.Text = row.Cells[4].Value.ToString();
                        mtbDataInativacao.Text = row.Cells[5].Value.ToString();
                        break;
                    }
                }
            }
        }

        //Evento Editar
        private void Editar()
        {
            tbDescricao.Focus();
            tbID.Enabled = false;
            tbDescricao.Enabled = true;
            cbStatus.Enabled = true;
            cbTipo.Enabled = true;
            ModoEdicao = true;
            btnFechar.Text = "Cancelar";

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
        }
        #endregion

        #region Evento ComboBox Status
        private void cbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbStatus.Enabled == true)
            {
                if (Convert.ToInt32(cbStatus.SelectedValue) == 0)
                {
                    mtbDataInativacao.Text = DateTime.Today.ToShortDateString();
                }
                else
                {
                    mtbDataInativacao.Text = string.Empty;
                }
            }
        }
        #endregion

        #region Botão Excluír
        //Botão Excluír
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbID.Text))
            {
                if (MessageBox.Show("Excluír Alarme: " + dgvAlarmes.CurrentRow.Cells[1].Value.ToString() + "?", "Dúvida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirAlarme();
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvAlarmes.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(tbID.Text))
                    {
                        if (MessageBox.Show("Excluír Alarme: " + row.Cells[1].Value.ToString() + "?", "Dúvida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ExcluirAlarme();
                        }

                        break;
                    }
                }
            }
        }

        //Funcão Excluír
        private void ExcluirAlarme()
        {
            AlarmeControl control = new AlarmeControl();
            Alarmes alarmes = new Alarmes
            {
                ID = Convert.ToInt32(dgvAlarmes.CurrentRow.Cells[0].Value)
            };

            if (control.ExcluirAlarme(alarmes))
            {
                AtualizaDataGridAlarmes();
                LimpaForm();
            }
            else
            {
                MessageBox.Show("Falha ao excluír Alarme!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Botão Pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbID.Text))
            {
                MessageBox.Show("ID inválido!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (DataGridViewRow row in dgvAlarmes.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(tbID.Text))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
