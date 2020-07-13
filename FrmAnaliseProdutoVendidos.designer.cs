namespace CaixaFacil
{
    partial class FrmAnaliseProdutoVendidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Arquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_GerarRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_AnaliseProdutoVendido = new System.Windows.Forms.DataGridView();
            this.ColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbMaxRows = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelCabecalho.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AnaliseProdutoVendido)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelCabecalho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 450);
            this.panel1.TabIndex = 0;
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.Color.Plum;
            this.panelCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCabecalho.Controls.Add(this.panel2);
            this.panelCabecalho.Controls.Add(this.menuStrip1);
            this.panelCabecalho.Controls.Add(this.dgv_AnaliseProdutoVendido);
            this.panelCabecalho.Controls.Add(this.btn_Fechar);
            this.panelCabecalho.Controls.Add(this.lbl_Titulo);
            this.panelCabecalho.Controls.Add(this.label10);
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Margin = new System.Windows.Forms.Padding(4);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(590, 448);
            this.panelCabecalho.TabIndex = 2;
            this.panelCabecalho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCabecalho_MouseDown);
            this.panelCabecalho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCabecalho_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Arquivo});
            this.menuStrip1.Location = new System.Drawing.Point(7, 58);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(71, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Arquivo
            // 
            this.Menu_Arquivo.BackColor = System.Drawing.Color.Plum;
            this.Menu_Arquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_GerarRelatorio});
            this.Menu_Arquivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Menu_Arquivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Menu_Arquivo.Name = "Menu_Arquivo";
            this.Menu_Arquivo.Size = new System.Drawing.Size(63, 20);
            this.Menu_Arquivo.Text = "Arquivo";
            // 
            // Menu_GerarRelatorio
            // 
            this.Menu_GerarRelatorio.BackColor = System.Drawing.Color.Plum;
            this.Menu_GerarRelatorio.ForeColor = System.Drawing.Color.White;
            this.Menu_GerarRelatorio.Image = global::CaixaFacil.Properties.Resources.Sales_report_icon;
            this.Menu_GerarRelatorio.Name = "Menu_GerarRelatorio";
            this.Menu_GerarRelatorio.Size = new System.Drawing.Size(160, 22);
            this.Menu_GerarRelatorio.Text = "Gerar Relatório";
            this.Menu_GerarRelatorio.Click += new System.EventHandler(this.Menu_GerarRelatorio_Click);
            this.Menu_GerarRelatorio.MouseEnter += new System.EventHandler(this.Menu_GerarRelatorio_MouseEnter);
            this.Menu_GerarRelatorio.MouseLeave += new System.EventHandler(this.Menu_GerarRelatorio_MouseLeave);
            // 
            // dgv_AnaliseProdutoVendido
            // 
            this.dgv_AnaliseProdutoVendido.AllowUserToAddRows = false;
            this.dgv_AnaliseProdutoVendido.AllowUserToDeleteRows = false;
            this.dgv_AnaliseProdutoVendido.BackgroundColor = System.Drawing.Color.White;
            this.dgv_AnaliseProdutoVendido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AnaliseProdutoVendido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_AnaliseProdutoVendido.ColumnHeadersHeight = 30;
            this.dgv_AnaliseProdutoVendido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_AnaliseProdutoVendido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDescricao,
            this.ColumnQuantidade,
            this.Column2,
            this.ColumnPreco,
            this.Column1});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_AnaliseProdutoVendido.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_AnaliseProdutoVendido.Location = new System.Drawing.Point(-1, 85);
            this.dgv_AnaliseProdutoVendido.MultiSelect = false;
            this.dgv_AnaliseProdutoVendido.Name = "dgv_AnaliseProdutoVendido";
            this.dgv_AnaliseProdutoVendido.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AnaliseProdutoVendido.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv_AnaliseProdutoVendido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AnaliseProdutoVendido.Size = new System.Drawing.Size(591, 318);
            this.dgv_AnaliseProdutoVendido.TabIndex = 3;
            // 
            // ColumnDescricao
            // 
            this.ColumnDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDescricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnDescricao.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColumnDescricao.HeaderText = "Descrição";
            this.ColumnDescricao.Name = "ColumnDescricao";
            this.ColumnDescricao.ReadOnly = true;
            // 
            // ColumnQuantidade
            // 
            this.ColumnQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnQuantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnQuantidade.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColumnQuantidade.HeaderText = "Q. Vendidas";
            this.ColumnQuantidade.Name = "ColumnQuantidade";
            this.ColumnQuantidade.ReadOnly = true;
            this.ColumnQuantidade.Width = 115;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NumeroVendas";
            this.Column2.HeaderText = "Nº Vendas";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ColumnPreco
            // 
            this.ColumnPreco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnPreco.DataPropertyName = "Valor";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Format = "C2";
            dataGridViewCellStyle18.NullValue = null;
            this.ColumnPreco.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColumnPreco.HeaderText = "T. Preço";
            this.ColumnPreco.Name = "ColumnPreco";
            this.ColumnPreco.ReadOnly = true;
            this.ColumnPreco.Width = 89;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Lucro";
            dataGridViewCellStyle19.Format = "C2";
            dataGridViewCellStyle19.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column1.HeaderText = "T. Lucro";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fechar.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fechar.ForeColor = System.Drawing.Color.White;
            this.btn_Fechar.Location = new System.Drawing.Point(546, 4);
            this.btn_Fechar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(38, 38);
            this.btn_Fechar.TabIndex = 11;
            this.btn_Fechar.Text = "X";
            this.btn_Fechar.UseVisualStyleBackColor = true;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            this.btn_Fechar.MouseEnter += new System.EventHandler(this.btn_Fechar_MouseEnter);
            this.btn_Fechar.MouseLeave += new System.EventHandler(this.btn_Fechar_MouseLeave);
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_Titulo.Location = new System.Drawing.Point(88, 26);
            this.lbl_Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(167, 16);
            this.lbl_Titulo.TabIndex = 10;
            this.lbl_Titulo.Text = "Produto mais vendidos";
            // 
            // label10
            // 
            this.label10.Image = global::CaixaFacil.Properties.Resources.product_icon;
            this.label10.Location = new System.Drawing.Point(12, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 58);
            this.label10.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.cbMaxRows);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(-1, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 47);
            this.panel2.TabIndex = 21;
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
            this.cbMaxRows.Location = new System.Drawing.Point(252, 8);
            this.cbMaxRows.Name = "cbMaxRows";
            this.cbMaxRows.Size = new System.Drawing.Size(132, 27);
            this.cbMaxRows.TabIndex = 33;
            this.cbMaxRows.SelectedIndexChanged += new System.EventHandler(this.cbMaxRows_SelectedIndexChanged);
            this.cbMaxRows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaxRows_KeyDown);
            this.cbMaxRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbMaxRows_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(134, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "Máx. de linhas:";
            // 
            // FrmAnaliseProdutoVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAnaliseProdutoVendidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analise Produto Vendidos";
            this.Load += new System.EventHandler(this.FrmAnaliseProdutoVendidos_Load);
            this.panel1.ResumeLayout(false);
            this.panelCabecalho.ResumeLayout(false);
            this.panelCabecalho.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AnaliseProdutoVendido)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_AnaliseProdutoVendido;
        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Arquivo;
        private System.Windows.Forms.ToolStripMenuItem Menu_GerarRelatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbMaxRows;
        private System.Windows.Forms.Label label4;
    }
}