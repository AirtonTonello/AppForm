namespace AppForms.View
{
    partial class FormGerenciamento
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
            this.dgvAlarmes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAlarme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipoAlarme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipoEquipamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumeroSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDataInativacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAlarmes
            // 
            this.dgvAlarmes.AllowUserToAddRows = false;
            this.dgvAlarmes.AllowUserToDeleteRows = false;
            this.dgvAlarmes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlarmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnAlarme,
            this.ColumnTipoAlarme,
            this.ColumnEquipamento,
            this.ColumnTipoEquipamento,
            this.ColumnNumeroSerie,
            this.ColumnDataCadastro,
            this.ColumnDataInativacao});
            this.dgvAlarmes.Location = new System.Drawing.Point(12, 124);
            this.dgvAlarmes.MultiSelect = false;
            this.dgvAlarmes.Name = "dgvAlarmes";
            this.dgvAlarmes.ReadOnly = true;
            this.dgvAlarmes.RowHeadersVisible = false;
            this.dgvAlarmes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlarmes.Size = new System.Drawing.Size(822, 337);
            this.dgvAlarmes.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnLimpar);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.tbDescricao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 79);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(541, 30);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(78, 29);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(246, 35);
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(289, 20);
            this.tbDescricao.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Alarme:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(55, 35);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(99, 20);
            this.tbID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID:";
            // 
            // cbFiltro
            // 
            this.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Items.AddRange(new object[] {
            "MAIS RECENTE",
            "ATIVOS",
            "MAIS UTILIZADOS",
            "TODOS"});
            this.cbFiltro.Location = new System.Drawing.Point(12, 97);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(220, 21);
            this.cbFiltro.TabIndex = 10;
            this.cbFiltro.SelectedValueChanged += new System.EventHandler(this.cbFiltro_SelectedValueChanged);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Location = new System.Drawing.Point(625, 30);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(78, 29);
            this.BtnLimpar.TabIndex = 10;
            this.BtnLimpar.Text = "Limpar Filtro";
            this.BtnLimpar.UseVisualStyleBackColor = true;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // ColumnID
            // 
            this.ColumnID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 43;
            // 
            // ColumnAlarme
            // 
            this.ColumnAlarme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAlarme.HeaderText = "Alarme";
            this.ColumnAlarme.Name = "ColumnAlarme";
            this.ColumnAlarme.ReadOnly = true;
            // 
            // ColumnTipoAlarme
            // 
            this.ColumnTipoAlarme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnTipoAlarme.HeaderText = "Tipo Alarme";
            this.ColumnTipoAlarme.Name = "ColumnTipoAlarme";
            this.ColumnTipoAlarme.ReadOnly = true;
            this.ColumnTipoAlarme.Width = 88;
            // 
            // ColumnEquipamento
            // 
            this.ColumnEquipamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEquipamento.HeaderText = "Equipamento";
            this.ColumnEquipamento.Name = "ColumnEquipamento";
            this.ColumnEquipamento.ReadOnly = true;
            // 
            // ColumnTipoEquipamento
            // 
            this.ColumnTipoEquipamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnTipoEquipamento.HeaderText = "Tipo Equipamento";
            this.ColumnTipoEquipamento.Name = "ColumnTipoEquipamento";
            this.ColumnTipoEquipamento.ReadOnly = true;
            this.ColumnTipoEquipamento.Width = 108;
            // 
            // ColumnNumeroSerie
            // 
            this.ColumnNumeroSerie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNumeroSerie.HeaderText = "Status";
            this.ColumnNumeroSerie.Name = "ColumnNumeroSerie";
            this.ColumnNumeroSerie.ReadOnly = true;
            // 
            // ColumnDataCadastro
            // 
            this.ColumnDataCadastro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDataCadastro.HeaderText = "Data Cadastro";
            this.ColumnDataCadastro.Name = "ColumnDataCadastro";
            this.ColumnDataCadastro.ReadOnly = true;
            // 
            // ColumnDataInativacao
            // 
            this.ColumnDataInativacao.HeaderText = "Data Inativação";
            this.ColumnDataInativacao.Name = "ColumnDataInativacao";
            this.ColumnDataInativacao.ReadOnly = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(750, 467);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(84, 28);
            this.btnFechar.TabIndex = 18;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormGerenciamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 507);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAlarmes);
            this.Name = "FormGerenciamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciamento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormGerenciamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlarmes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlarme;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipoAlarme;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEquipamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipoEquipamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumeroSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDataInativacao;
        private System.Windows.Forms.Button btnFechar;
    }
}