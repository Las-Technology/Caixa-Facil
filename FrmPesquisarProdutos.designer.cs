namespace CaixaFacil
{
    partial class FrmPesquisarProdutos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMaxRows = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_Busca = new System.Windows.Forms.DataGridView();
            this.tabelaProdutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbControleVendaDataSet = new CaixaFacil.DbControleVendaDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.valorCusto1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorVenda1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lucroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabelaProdutoTableAdapter = new CaixaFacil.DbControleVendaDataSetTableAdapters.TabelaProdutoTableAdapter();
            this.idProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoBarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estoqueAtualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumeroNotaFiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataValidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorCustoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estoqueMinimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaProdutoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbControleVendaDataSet)).BeginInit();
            this.panelCabecalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbMaxRows);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dgv_Busca);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Nome);
            this.panel1.Controls.Add(this.panelCabecalho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 465);
            this.panel1.TabIndex = 0;
            // 
            // cbMaxRows
            // 
            this.cbMaxRows.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.cbMaxRows.Location = new System.Drawing.Point(520, 423);
            this.cbMaxRows.Name = "cbMaxRows";
            this.cbMaxRows.Size = new System.Drawing.Size(132, 27);
            this.cbMaxRows.TabIndex = 30;
            this.cbMaxRows.SelectedIndexChanged += new System.EventHandler(this.cbMaxRows_SelectedIndexChanged);
            this.cbMaxRows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaxRows_KeyDown);
            this.cbMaxRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMaxRows_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(382, 426);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "Máximo de linhas:";
            // 
            // dgv_Busca
            // 
            this.dgv_Busca.AllowUserToAddRows = false;
            this.dgv_Busca.AllowUserToDeleteRows = false;
            this.dgv_Busca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Busca.AutoGenerateColumns = false;
            this.dgv_Busca.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Busca.ColumnHeadersHeight = 30;
            this.dgv_Busca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Busca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProduto,
            this.codigoBarra,
            this.nomeProduto,
            this.marcaDataGridViewTextBoxColumn,
            this.valorVenda,
            this.estoqueAtualDataGridViewTextBoxColumn,
            this.ColumnNumeroNotaFiscal,
            this.ColumnDataCadastro,
            this.dataValidadeDataGridViewTextBoxColumn,
            this.valorCustoDataGridViewTextBoxColumn,
            this.lucro,
            this.estoqueMinimoDataGridViewTextBoxColumn,
            this.unidadeDataGridViewTextBoxColumn,
            this.NomeCategoria,
            this.nomeFornecedor});
            this.dgv_Busca.DataSource = this.tabelaProdutoBindingSource;
            this.dgv_Busca.Location = new System.Drawing.Point(6, 143);
            this.dgv_Busca.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Busca.Name = "dgv_Busca";
            this.dgv_Busca.ReadOnly = true;
            this.dgv_Busca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Busca.Size = new System.Drawing.Size(1060, 265);
            this.dgv_Busca.TabIndex = 12;
            this.dgv_Busca.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Busca_CellClick);
            this.dgv_Busca.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Busca_DataBindingComplete);
            // 
            // tabelaProdutoBindingSource
            // 
            this.tabelaProdutoBindingSource.DataMember = "TabelaProduto";
            this.tabelaProdutoBindingSource.DataSource = this.dbControleVendaDataSet;
            // 
            // dbControleVendaDataSet
            // 
            this.dbControleVendaDataSet.DataSetName = "DbControleVendaDataSet";
            this.dbControleVendaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nome do produto:";
            // 
            // txt_Nome
            // 
            this.txt_Nome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nome.Location = new System.Drawing.Point(375, 95);
            this.txt_Nome.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(408, 26);
            this.txt_Nome.TabIndex = 10;
            this.txt_Nome.TextChanged += new System.EventHandler(this.txt_Nome_TextChanged);
            this.txt_Nome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Nome_KeyDown);
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCabecalho.BackColor = System.Drawing.Color.DarkOrange;
            this.panelCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCabecalho.Controls.Add(this.label2);
            this.panelCabecalho.Controls.Add(this.label3);
            this.panelCabecalho.Controls.Add(this.btn_Fechar);
            this.panelCabecalho.Location = new System.Drawing.Point(0, -1);
            this.panelCabecalho.Margin = new System.Windows.Forms.Padding(2);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(1086, 72);
            this.panelCabecalho.TabIndex = 9;
            this.panelCabecalho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCabecalho_MouseDown);
            this.panelCabecalho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCabecalho_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(61, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 19);
            this.label2.TabIndex = 59;
            this.label2.Text = "Pesquisar Produtos";
            // 
            // label3
            // 
            this.label3.Image = global::CaixaFacil.Properties.Resources.Preppy_icon;
            this.label3.Location = new System.Drawing.Point(6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 63);
            this.label3.TabIndex = 58;
            this.label3.Text = "     ";
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Fechar.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fechar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fechar.ForeColor = System.Drawing.Color.White;
            this.btn_Fechar.Location = new System.Drawing.Point(1024, 6);
            this.btn_Fechar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(40, 42);
            this.btn_Fechar.TabIndex = 57;
            this.btn_Fechar.Text = "X";
            this.toolTip1.SetToolTip(this.btn_Fechar, "Fechar");
            this.btn_Fechar.UseVisualStyleBackColor = false;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            this.btn_Fechar.MouseEnter += new System.EventHandler(this.btn_Fechar_MouseEnter);
            this.btn_Fechar.MouseLeave += new System.EventHandler(this.btn_Fechar_MouseLeave);
            // 
            // valorCusto1DataGridViewTextBoxColumn
            // 
            this.valorCusto1DataGridViewTextBoxColumn.DataPropertyName = "ValorCusto1";
            this.valorCusto1DataGridViewTextBoxColumn.HeaderText = "ValorCusto1";
            this.valorCusto1DataGridViewTextBoxColumn.Name = "valorCusto1DataGridViewTextBoxColumn";
            // 
            // valorVenda1DataGridViewTextBoxColumn
            // 
            this.valorVenda1DataGridViewTextBoxColumn.DataPropertyName = "ValorVenda1";
            this.valorVenda1DataGridViewTextBoxColumn.HeaderText = "ValorVenda1";
            this.valorVenda1DataGridViewTextBoxColumn.Name = "valorVenda1DataGridViewTextBoxColumn";
            // 
            // lucroDataGridViewTextBoxColumn
            // 
            this.lucroDataGridViewTextBoxColumn.DataPropertyName = "Lucro";
            this.lucroDataGridViewTextBoxColumn.HeaderText = "Lucro";
            this.lucroDataGridViewTextBoxColumn.Name = "lucroDataGridViewTextBoxColumn";
            // 
            // tabelaProdutoTableAdapter
            // 
            this.tabelaProdutoTableAdapter.ClearBeforeFill = true;
            // 
            // idProduto
            // 
            this.idProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idProduto.DataPropertyName = "Id_Produto";
            this.idProduto.HeaderText = "Código";
            this.idProduto.Name = "idProduto";
            this.idProduto.ReadOnly = true;
            this.idProduto.Width = 79;
            // 
            // codigoBarra
            // 
            this.codigoBarra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codigoBarra.DataPropertyName = "CodigoBarra";
            this.codigoBarra.HeaderText = "Codigo de Barra";
            this.codigoBarra.Name = "codigoBarra";
            this.codigoBarra.ReadOnly = true;
            this.codigoBarra.Width = 136;
            // 
            // nomeProduto
            // 
            this.nomeProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nomeProduto.DataPropertyName = "DescricaoNome";
            this.nomeProduto.HeaderText = "Descrição";
            this.nomeProduto.Name = "nomeProduto";
            this.nomeProduto.ReadOnly = true;
            this.nomeProduto.Width = 95;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaDataGridViewTextBoxColumn.Width = 74;
            // 
            // valorVenda
            // 
            this.valorVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valorVenda.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.valorVenda.DefaultCellStyle = dataGridViewCellStyle1;
            this.valorVenda.HeaderText = "Valor de Venda";
            this.valorVenda.Name = "valorVenda";
            this.valorVenda.ReadOnly = true;
            this.valorVenda.Width = 127;
            // 
            // estoqueAtualDataGridViewTextBoxColumn
            // 
            this.estoqueAtualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estoqueAtualDataGridViewTextBoxColumn.DataPropertyName = "EstoqueAtual";
            this.estoqueAtualDataGridViewTextBoxColumn.HeaderText = "Estoque Atual";
            this.estoqueAtualDataGridViewTextBoxColumn.Name = "estoqueAtualDataGridViewTextBoxColumn";
            this.estoqueAtualDataGridViewTextBoxColumn.ReadOnly = true;
            this.estoqueAtualDataGridViewTextBoxColumn.Width = 118;
            // 
            // ColumnNumeroNotaFiscal
            // 
            this.ColumnNumeroNotaFiscal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnNumeroNotaFiscal.DataPropertyName = "NumeroNotaFiscal";
            this.ColumnNumeroNotaFiscal.HeaderText = "Número Nota Fiscal";
            this.ColumnNumeroNotaFiscal.Name = "ColumnNumeroNotaFiscal";
            this.ColumnNumeroNotaFiscal.ReadOnly = true;
            this.ColumnNumeroNotaFiscal.Width = 158;
            // 
            // ColumnDataCadastro
            // 
            this.ColumnDataCadastro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDataCadastro.DataPropertyName = "DataCadastro";
            this.ColumnDataCadastro.HeaderText = "Data Cadastro";
            this.ColumnDataCadastro.Name = "ColumnDataCadastro";
            this.ColumnDataCadastro.ReadOnly = true;
            this.ColumnDataCadastro.Width = 123;
            // 
            // dataValidadeDataGridViewTextBoxColumn
            // 
            this.dataValidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataValidadeDataGridViewTextBoxColumn.DataPropertyName = "DataValidade";
            this.dataValidadeDataGridViewTextBoxColumn.HeaderText = "Data da Validade";
            this.dataValidadeDataGridViewTextBoxColumn.Name = "dataValidadeDataGridViewTextBoxColumn";
            this.dataValidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataValidadeDataGridViewTextBoxColumn.Width = 138;
            // 
            // valorCustoDataGridViewTextBoxColumn
            // 
            this.valorCustoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valorCustoDataGridViewTextBoxColumn.DataPropertyName = "ValorCusto";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.valorCustoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.valorCustoDataGridViewTextBoxColumn.HeaderText = "Valor de Custo";
            this.valorCustoDataGridViewTextBoxColumn.Name = "valorCustoDataGridViewTextBoxColumn";
            this.valorCustoDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorCustoDataGridViewTextBoxColumn.Width = 125;
            // 
            // lucro
            // 
            this.lucro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lucro.DataPropertyName = "Lucro";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.lucro.DefaultCellStyle = dataGridViewCellStyle3;
            this.lucro.HeaderText = "Lucro";
            this.lucro.Name = "lucro";
            this.lucro.ReadOnly = true;
            this.lucro.Width = 70;
            // 
            // estoqueMinimoDataGridViewTextBoxColumn
            // 
            this.estoqueMinimoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.estoqueMinimoDataGridViewTextBoxColumn.DataPropertyName = "EstoqueMinimo";
            this.estoqueMinimoDataGridViewTextBoxColumn.HeaderText = "Estoque Mínimo";
            this.estoqueMinimoDataGridViewTextBoxColumn.Name = "estoqueMinimoDataGridViewTextBoxColumn";
            this.estoqueMinimoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estoqueMinimoDataGridViewTextBoxColumn.Width = 133;
            // 
            // unidadeDataGridViewTextBoxColumn
            // 
            this.unidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unidadeDataGridViewTextBoxColumn.DataPropertyName = "Unidade";
            this.unidadeDataGridViewTextBoxColumn.HeaderText = "Unidade";
            this.unidadeDataGridViewTextBoxColumn.Name = "unidadeDataGridViewTextBoxColumn";
            this.unidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.unidadeDataGridViewTextBoxColumn.Width = 85;
            // 
            // NomeCategoria
            // 
            this.NomeCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NomeCategoria.DataPropertyName = "Descricao";
            this.NomeCategoria.HeaderText = "Categoria";
            this.NomeCategoria.Name = "NomeCategoria";
            this.NomeCategoria.ReadOnly = true;
            this.NomeCategoria.Width = 93;
            // 
            // nomeFornecedor
            // 
            this.nomeFornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nomeFornecedor.DataPropertyName = "Nome";
            this.nomeFornecedor.HeaderText = "Fornecedor";
            this.nomeFornecedor.Name = "nomeFornecedor";
            this.nomeFornecedor.ReadOnly = true;
            this.nomeFornecedor.Width = 105;
            // 
            // FrmPesquisarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 465);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPesquisarProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Produtos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPesquisarProdutos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Busca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaProdutoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbControleVendaDataSet)).EndInit();
            this.panelCabecalho.ResumeLayout(false);
            this.panelCabecalho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorCusto1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVenda1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lucroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgv_Busca;
        private DbControleVendaDataSet dbControleVendaDataSet;
        private System.Windows.Forms.BindingSource tabelaProdutoBindingSource;
        private DbControleVendaDataSetTableAdapters.TabelaProdutoTableAdapter tabelaProdutoTableAdapter;
        private System.Windows.Forms.ComboBox cbMaxRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoBarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn estoqueAtualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumeroNotaFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataValidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorCustoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn estoqueMinimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeFornecedor;
    }
}