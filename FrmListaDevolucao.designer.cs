﻿namespace CaixaFacil
{
    partial class FrmListaDevolucao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaDevolucao));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtValorItensDevolvidos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListaItensDevolvidos = new System.Windows.Forms.DataGridView();
            this.ColIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDataDevolucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelCabecalho = new System.Windows.Forms.Panel();
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Lbl_Icone = new System.Windows.Forms.Label();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.cbMaxRows = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaItensDevolvidos)).BeginInit();
            this.PanelCabecalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbMaxRows);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtValorItensDevolvidos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvListaItensDevolvidos);
            this.panel1.Controls.Add(this.PanelCabecalho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 348);
            this.panel1.TabIndex = 0;
            // 
            // txtValorItensDevolvidos
            // 
            this.txtValorItensDevolvidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorItensDevolvidos.Location = new System.Drawing.Point(184, 307);
            this.txtValorItensDevolvidos.Name = "txtValorItensDevolvidos";
            this.txtValorItensDevolvidos.ReadOnly = true;
            this.txtValorItensDevolvidos.Size = new System.Drawing.Size(100, 26);
            this.txtValorItensDevolvidos.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Valor dos itens devolvidos:";
            // 
            // dgvListaItensDevolvidos
            // 
            this.dgvListaItensDevolvidos.AllowUserToAddRows = false;
            this.dgvListaItensDevolvidos.AllowUserToDeleteRows = false;
            this.dgvListaItensDevolvidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaItensDevolvidos.ColumnHeadersHeight = 32;
            this.dgvListaItensDevolvidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListaItensDevolvidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdProduto,
            this.ColDescricao,
            this.ColValor,
            this.Column1,
            this.ColDataDevolucao});
            this.dgvListaItensDevolvidos.Location = new System.Drawing.Point(12, 73);
            this.dgvListaItensDevolvidos.Name = "dgvListaItensDevolvidos";
            this.dgvListaItensDevolvidos.ReadOnly = true;
            this.dgvListaItensDevolvidos.Size = new System.Drawing.Size(658, 218);
            this.dgvListaItensDevolvidos.TabIndex = 4;
            // 
            // ColIdProduto
            // 
            this.ColIdProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColIdProduto.DataPropertyName = "Id_Produto";
            this.ColIdProduto.HeaderText = "Cod. Produto";
            this.ColIdProduto.Name = "ColIdProduto";
            this.ColIdProduto.ReadOnly = true;
            this.ColIdProduto.Width = 118;
            // 
            // ColDescricao
            // 
            this.ColDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDescricao.DataPropertyName = "Descricao";
            this.ColDescricao.HeaderText = "Produto";
            this.ColDescricao.Name = "ColDescricao";
            this.ColDescricao.ReadOnly = true;
            this.ColDescricao.Width = 83;
            // 
            // ColValor
            // 
            this.ColValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColValor.DataPropertyName = "ValorProduto";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.ColValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColValor.HeaderText = "Valor do Produto";
            this.ColValor.Name = "ColValor";
            this.ColValor.ReadOnly = true;
            this.ColValor.Width = 139;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "qtdItens";
            this.Column1.HeaderText = "Quantidade";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 104;
            // 
            // ColDataDevolucao
            // 
            this.ColDataDevolucao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColDataDevolucao.DataPropertyName = "DataDevolucao";
            this.ColDataDevolucao.HeaderText = "Data de Devolução";
            this.ColDataDevolucao.Name = "ColDataDevolucao";
            this.ColDataDevolucao.ReadOnly = true;
            this.ColDataDevolucao.Width = 151;
            // 
            // PanelCabecalho
            // 
            this.PanelCabecalho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelCabecalho.BackColor = System.Drawing.Color.Brown;
            this.PanelCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCabecalho.Controls.Add(this.Lbl_Titulo);
            this.PanelCabecalho.Controls.Add(this.Lbl_Icone);
            this.PanelCabecalho.Controls.Add(this.btn_Fechar);
            this.PanelCabecalho.Location = new System.Drawing.Point(-1, -1);
            this.PanelCabecalho.Margin = new System.Windows.Forms.Padding(4);
            this.PanelCabecalho.Name = "PanelCabecalho";
            this.PanelCabecalho.Size = new System.Drawing.Size(683, 67);
            this.PanelCabecalho.TabIndex = 3;
            this.PanelCabecalho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelCabecalho_MouseDown);
            this.PanelCabecalho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelCabecalho_MouseMove);
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.Lbl_Titulo.Location = new System.Drawing.Point(107, 17);
            this.Lbl_Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(0, 19);
            this.Lbl_Titulo.TabIndex = 65;
            // 
            // Lbl_Icone
            // 
            this.Lbl_Icone.Image = global::CaixaFacil.Properties.Resources.Data_List_icon;
            this.Lbl_Icone.Location = new System.Drawing.Point(4, 4);
            this.Lbl_Icone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Icone.Name = "Lbl_Icone";
            this.Lbl_Icone.Size = new System.Drawing.Size(88, 53);
            this.Lbl_Icone.TabIndex = 64;
            this.Lbl_Icone.Text = "    ";
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Fechar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fechar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fechar.ForeColor = System.Drawing.Color.White;
            this.btn_Fechar.Location = new System.Drawing.Point(639, 4);
            this.btn_Fechar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(38, 41);
            this.btn_Fechar.TabIndex = 62;
            this.btn_Fechar.Text = "X";
            this.btn_Fechar.UseVisualStyleBackColor = false;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            this.btn_Fechar.MouseEnter += new System.EventHandler(this.btn_Fechar_MouseEnter);
            this.btn_Fechar.MouseLeave += new System.EventHandler(this.btn_Fechar_MouseLeave);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 106);
            // 
            // cbMaxRows
            // 
            this.cbMaxRows.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbMaxRows.BackColor = System.Drawing.Color.White;
            this.cbMaxRows.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cbMaxRows.FormattingEnabled = true;
            this.cbMaxRows.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000",
            "Todos"});
            this.cbMaxRows.Location = new System.Drawing.Point(439, 308);
            this.cbMaxRows.Name = "cbMaxRows";
            this.cbMaxRows.Size = new System.Drawing.Size(132, 27);
            this.cbMaxRows.TabIndex = 37;
            this.cbMaxRows.SelectedIndexChanged += new System.EventHandler(this.cbMaxRows_SelectedIndexChanged);
            this.cbMaxRows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaxRows_KeyDown);
            this.cbMaxRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMaxRows_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(321, 311);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "Máx. de linhas:";
            // 
            // FrmListaDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 348);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmListaDevolucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico de pagamento";
            this.Load += new System.EventHandler(this.FrmListavenda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaItensDevolvidos)).EndInit();
            this.PanelCabecalho.ResumeLayout(false);
            this.PanelCabecalho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelCabecalho;
        private System.Windows.Forms.Label Lbl_Titulo;
        private System.Windows.Forms.Label Lbl_Icone;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.DataGridView dgvListaItensDevolvidos;
        private System.Windows.Forms.TextBox txtValorItensDevolvidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDataDevolucao;
        private System.Windows.Forms.ComboBox cbMaxRows;
        private System.Windows.Forms.Label label4;
    }
}