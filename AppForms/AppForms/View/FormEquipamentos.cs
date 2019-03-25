using AppForms.Control;
using AppForms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AppForms
{
    public partial class FormEquipamentos : Form
    {
        public FormEquipamentos()
        {
            InitializeComponent();
        }

        private bool ModoEdicao = false;
        private bool ModoNovo = false;

        #region Form Load
        private void FormEquipamentos_Load(object sender, EventArgs e)
        {
            EquipamentoControl control = new EquipamentoControl();

            List<TipoEquipamento>  TipoEquipamento = control.GetTipoEquipamentos();
            cbTipo.DataSource = TipoEquipamento;
            cbTipo.DisplayMember = "Tipo";
            cbTipo.ValueMember = "ID";

            List<Alarmes> AlarmesAtivos = control.GetAlarmesAtivos();
            cbAlarmes.DataSource = AlarmesAtivos;
            cbAlarmes.DisplayMember = "Descricao";
            cbAlarmes.ValueMember = "ID";

            mtbDataCadastro.Text = DateTime.Now.ToShortDateString();

            btnSalvar.Enabled = false;
            AtualizaDataGridEquipamentos();
        }
        #endregion

        #region Limpar Formulario
        private void LimpaForm()
        {
            tbID.Text = string.Empty;
            tbNome.Text = string.Empty;
            tbNumeroSerie.Text = string.Empty;
            cbTipo.SelectedIndex = 0;

            if(cbAlarmes.Items.Count > 0)
            {
                cbAlarmes.SelectedIndex = 0;
            }

            mtbDataCadastro.Text = DateTime.Today.ToShortDateString();
        }
        #endregion

        #region Botão Novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbID.Enabled = false;
            tbNome.Enabled = true;
            cbTipo.Enabled = true;
            cbAlarmes.Enabled = true;
            tbNumeroSerie.Enabled = true;

            btnPesquisar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnFechar.Text = "Cancelar";
            ModoNovo = true;

            LimpaForm();
        }
        #endregion

        #region Atualiza DataGridView
        private void AtualizaDataGridEquipamentos()
        {
            EquipamentoControl control = new EquipamentoControl();

            DataTable dt = new DataTable();
            dt = control.GetEquipamentos();

            if (dgvEquipamentos.Rows.Count > 0)
            {
                dgvEquipamentos.Rows.Clear();
            }

            foreach (DataRow row in dt.Rows)
            {
                dgvEquipamentos.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], Convert.ToDateTime(row[6]).ToShortDateString());
            }
        }
        #endregion

        #region Evento DataGridView
        private void dgvEquipamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ModoEdicao == false)
            {
                tbID.Text = dgvEquipamentos.CurrentRow.Cells[0].Value.ToString();
            }
        }
        #endregion

        #region Botão Salvar
        //Clique Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            EquipamentoControl control = new EquipamentoControl();
            Equipamentos equip = new Equipamentos();

            if (String.IsNullOrWhiteSpace(tbNome.Text) || String.IsNullOrWhiteSpace(tbNumeroSerie.Text))
            {
                MessageBox.Show("Nome do Equipamento e Número de Série são itens obrigatório", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ModoEdicao)
                {
                    equip.ID = Convert.ToInt32(tbID.Text);
                    equip.Descricao = tbNome.Text;
                    equip.NumeroSerie = Convert.ToInt32(tbNumeroSerie.Text);
                    equip.TipoEquipamento = Convert.ToInt32(cbTipo.SelectedValue);
                    equip.AlarmeID = Convert.ToInt32(cbAlarmes.SelectedValue);

                    if (control.EditarEquipamento(equip))
                    {
                        Salvar();
                        AtualizaDataGridEquipamentos();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao editar Equipamento!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cancelar();
                    }

                }
                else
                {
                    equip.Descricao = tbNome.Text;
                    equip.NumeroSerie = Convert.ToInt32(tbNumeroSerie.Text);
                    equip.TipoEquipamento = Convert.ToInt32(cbTipo.SelectedValue);
                    equip.AlarmeID = Convert.ToInt32(cbAlarmes.SelectedValue);

                    if (control.InserirEquipamento(equip))
                    {
                        Salvar();
                        AtualizaDataGridEquipamentos();
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
            tbNome.Enabled = false;
            tbNumeroSerie.Enabled = false;
            cbTipo.Enabled = false;
            cbAlarmes.Enabled = false;

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

        #region Botão Pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbID.Text))
            {
                MessageBox.Show("ID inválido!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (DataGridViewRow row in dgvEquipamentos.Rows)
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

        #region Botão Editar
        //Clique Botão Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();

            if (String.IsNullOrWhiteSpace(tbID.Text))
            {
                if(dgvEquipamentos.Rows.Count > 0)
                {
                    tbID.Text = dgvEquipamentos.CurrentRow.Cells[0].Value.ToString();
                    tbNome.Text = dgvEquipamentos.CurrentRow.Cells[1].Value.ToString();
                    tbNumeroSerie.Text = dgvEquipamentos.CurrentRow.Cells[2].Value.ToString();
                    cbTipo.Text = dgvEquipamentos.CurrentRow.Cells[3].Value.ToString();
                    cbAlarmes.Text = dgvEquipamentos.CurrentRow.Cells[4].Value.ToString();
                    mtbDataCadastro.Text = dgvEquipamentos.CurrentRow.Cells[6].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Não existe Equipamentos disponivéis!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvEquipamentos.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(tbID.Text))
                    {
                        tbID.Text = row.Cells[0].Value.ToString();
                        tbNome.Text = row.Cells[1].Value.ToString();
                        tbNumeroSerie.Text = row.Cells[2].Value.ToString();
                        cbTipo.Text = row.Cells[3].Value.ToString();
                        cbAlarmes.Text = row.Cells[4].Value.ToString();
                        mtbDataCadastro.Text = row.Cells[6].Value.ToString();
                        break;
                    }
                }
            }
        }

        //Evento Editar
        private void Editar()
        {
            tbNome.Focus();
            tbID.Enabled = false;
            tbNome.Enabled = true;
            tbNumeroSerie.Enabled = true;
            cbTipo.Enabled = true;
            cbAlarmes.Enabled = true;
            ModoEdicao = true;
            btnFechar.Text = "Cancelar";

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
        }
        #endregion

        #region Botão Excluír
        //Clique Botão Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbID.Text))
            {
                if (MessageBox.Show("Excluír Equipamento: " + dgvEquipamentos.CurrentRow.Cells[1].Value.ToString() + "?", "Dúvida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirEquipamento();
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvEquipamentos.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(tbID.Text))
                    {
                        if (MessageBox.Show("Excluír Equipamento: " + row.Cells[1].Value.ToString() + "?", "Dúvida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ExcluirEquipamento();
                        }

                        break;
                    }
                }
            }
        }

        //Função Excluír
        private void ExcluirEquipamento()
        {
            EquipamentoControl control = new EquipamentoControl();
            Equipamentos equip = new Equipamentos()
            {
                ID = Convert.ToInt32(dgvEquipamentos.CurrentRow.Cells[0].Value)
            };

            if (control.ExcluirEquipamento(equip))
            {
                AtualizaDataGridEquipamentos();
                LimpaForm();
            }
            else
            {
                MessageBox.Show("Falha ao excluír Equipamento!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Botão Fechar
        //Clique Botão Fechar
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
            tbNome.Enabled = false;
            tbNumeroSerie.Enabled = false;
            cbTipo.Enabled = false;
            cbAlarmes.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;

        }
        #endregion

    }
}
