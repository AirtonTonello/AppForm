using AppForms.Model;
using AppForms.View;
using System;
using System.Windows.Forms;

namespace AppForms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormEquipamentos fEquip = new FormEquipamentos()
            {
                TopLevel = false,
                AutoScroll = true
            };
            PainelPrincipal.Controls.Add(fEquip);
            fEquip.Show();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlarmes fAlarme = new FormAlarmes()
            {
                TopLevel = false,
                AutoScroll = true
            };
            PainelPrincipal.Controls.Add(fAlarme);
            fAlarme.Show();
        }

        private void gerenciamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGerenciamento fGeren = new FormGerenciamento()
            {
                TopLevel = false,
                AutoScroll = true
            };
            PainelPrincipal.Controls.Add(fGeren);
            fGeren.Show();
            
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log log = new Log();
            log.RegistrarLog("Encerrando...");
        }
    }
}
