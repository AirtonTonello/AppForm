namespace AppForms.View
{
    partial class FormMaisUtilizados
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
            this.dgvMaisUtilizados = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAlarme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaisUtilizados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMaisUtilizados
            // 
            this.dgvMaisUtilizados.AllowUserToAddRows = false;
            this.dgvMaisUtilizados.AllowUserToDeleteRows = false;
            this.dgvMaisUtilizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaisUtilizados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnAlarme,
            this.ColumnQuantidade});
            this.dgvMaisUtilizados.Location = new System.Drawing.Point(12, 12);
            this.dgvMaisUtilizados.MultiSelect = false;
            this.dgvMaisUtilizados.Name = "dgvMaisUtilizados";
            this.dgvMaisUtilizados.ReadOnly = true;
            this.dgvMaisUtilizados.RowHeadersVisible = false;
            this.dgvMaisUtilizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaisUtilizados.Size = new System.Drawing.Size(398, 256);
            this.dgvMaisUtilizados.TabIndex = 10;
            // 
            // ColumnID
            // 
            this.ColumnID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            // ColumnQuantidade
            // 
            this.ColumnQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnQuantidade.HeaderText = "Quantidade";
            this.ColumnQuantidade.Name = "ColumnQuantidade";
            this.ColumnQuantidade.ReadOnly = true;
            this.ColumnQuantidade.Width = 87;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(326, 274);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(84, 28);
            this.btnFechar.TabIndex = 18;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormMaisUtilizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 314);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvMaisUtilizados);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMaisUtilizados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mais Utilizados";
            this.Load += new System.EventHandler(this.FormMaisUtilizados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaisUtilizados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaisUtilizados;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlarme;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantidade;
        private System.Windows.Forms.Button btnFechar;
    }
}