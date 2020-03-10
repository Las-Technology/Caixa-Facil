﻿namespace CaixaFacil
{
    partial class FrmVenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_atendente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Hora = new System.Windows.Forms.Label();
            this.lbl_Data = new System.Windows.Forms.Label();
            this.btn_GerarRecibo = new System.Windows.Forms.GroupBox();
            this.btnPagamentoCartao = new System.Windows.Forms.Button();
            this.btn_PagamentoParcial = new System.Windows.Forms.Button();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.btn_VenderParcelado = new System.Windows.Forms.Button();
            this.btn_VendaVista = new System.Windows.Forms.Button();
            this.btn_VenderPrazo = new System.Windows.Forms.Button();
            this.btn_CancelarVenda = new System.Windows.Forms.Button();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbl_NomeEmpresa = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_CodigoVenda = new System.Windows.Forms.TextBox();
            this.cbOpcao = new System.Windows.Forms.CheckBox();
            this.txt_ValorTotal = new System.Windows.Forms.TextBox();
            this.btn_Remover = new System.Windows.Forms.Button();
            this.lblValorTotalVenda = new System.Windows.Forms.Label();
            this.btn_Adcionar = new System.Windows.Forms.Button();
            this.txt_Quantidade = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_BuscarServiço = new System.Windows.Forms.Button();
            this.btn_NovoCadastro = new System.Windows.Forms.Button();
            this.btn_BuscarProdutos = new System.Windows.Forms.Button();
            this.btn_BuscarPreços = new System.Windows.Forms.Button();
            this.btn_ContasClientes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGV_ItensVenda = new System.Windows.Forms.DataGridView();
            this.ColumnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescricaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_Quantidade = new System.Windows.Forms.Label();
            this.lbl_Informacao = new System.Windows.Forms.Label();
            this.txt_Codigo_Barra = new System.Windows.Forms.TextBox();
            this.PanelCabecalho = new System.Windows.Forms.Panel();
            this.Lbl_Titulo = new System.Windows.Forms.Label();
            this.Lbl_Icone = new System.Windows.Forms.Label();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.btn_Minimizar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.btn_GerarRecibo.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ItensVenda)).BeginInit();
            this.PanelCabecalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_atendente);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_Hora);
            this.panel1.Controls.Add(this.lbl_Data);
            this.panel1.Controls.Add(this.btn_GerarRecibo);
            this.panel1.Controls.Add(this.lbl_Usuario);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.PanelCabecalho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1350, 733);
            this.panel1.TabIndex = 0;
            // 
            // lbl_atendente
            // 
            this.lbl_atendente.AutoSize = true;
            this.lbl_atendente.Location = new System.Drawing.Point(1158, 639);
            this.lbl_atendente.Name = "lbl_atendente";
            this.lbl_atendente.Size = new System.Drawing.Size(0, 19);
            this.lbl_atendente.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1056, 666);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1056, 691);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "Hora:";
            // 
            // lbl_Hora
            // 
            this.lbl_Hora.AutoSize = true;
            this.lbl_Hora.Location = new System.Drawing.Point(1110, 691);
            this.lbl_Hora.Name = "lbl_Hora";
            this.lbl_Hora.Size = new System.Drawing.Size(0, 19);
            this.lbl_Hora.TabIndex = 22;
            // 
            // lbl_Data
            // 
            this.lbl_Data.AutoSize = true;
            this.lbl_Data.Location = new System.Drawing.Point(1104, 666);
            this.lbl_Data.Name = "lbl_Data";
            this.lbl_Data.Size = new System.Drawing.Size(0, 19);
            this.lbl_Data.TabIndex = 21;
            // 
            // btn_GerarRecibo
            // 
            this.btn_GerarRecibo.Controls.Add(this.btnPagamentoCartao);
            this.btn_GerarRecibo.Controls.Add(this.btn_PagamentoParcial);
            this.btn_GerarRecibo.Controls.Add(this.btn_Sair);
            this.btn_GerarRecibo.Controls.Add(this.btn_VenderParcelado);
            this.btn_GerarRecibo.Controls.Add(this.btn_VendaVista);
            this.btn_GerarRecibo.Controls.Add(this.btn_VenderPrazo);
            this.btn_GerarRecibo.Controls.Add(this.btn_CancelarVenda);
            this.btn_GerarRecibo.Location = new System.Drawing.Point(1060, 240);
            this.btn_GerarRecibo.Name = "btn_GerarRecibo";
            this.btn_GerarRecibo.Size = new System.Drawing.Size(210, 392);
            this.btn_GerarRecibo.TabIndex = 20;
            this.btn_GerarRecibo.TabStop = false;
            // 
            // btnPagamentoCartao
            // 
            this.btnPagamentoCartao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPagamentoCartao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagamentoCartao.Image = global::CaixaFacil.Properties.Resources.parcelas1;
            this.btnPagamentoCartao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagamentoCartao.Location = new System.Drawing.Point(6, 231);
            this.btnPagamentoCartao.Name = "btnPagamentoCartao";
            this.btnPagamentoCartao.Size = new System.Drawing.Size(186, 45);
            this.btnPagamentoCartao.TabIndex = 25;
            this.btnPagamentoCartao.Text = "Pag. à Cartão- [F8]";
            this.btnPagamentoCartao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagamentoCartao.UseVisualStyleBackColor = true;
            this.btnPagamentoCartao.Click += new System.EventHandler(this.btnPagamentoCartao_Click);
            // 
            // btn_PagamentoParcial
            // 
            this.btn_PagamentoParcial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_PagamentoParcial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PagamentoParcial.Image = global::CaixaFacil.Properties.Resources.Broken_icon;
            this.btn_PagamentoParcial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PagamentoParcial.Location = new System.Drawing.Point(6, 75);
            this.btn_PagamentoParcial.Name = "btn_PagamentoParcial";
            this.btn_PagamentoParcial.Size = new System.Drawing.Size(186, 45);
            this.btn_PagamentoParcial.TabIndex = 24;
            this.btn_PagamentoParcial.Text = "Parcial - [F5]";
            this.btn_PagamentoParcial.UseVisualStyleBackColor = true;
            this.btn_PagamentoParcial.Click += new System.EventHandler(this.btn_PagamentoParcial_Click);
            // 
            // btn_Sair
            // 
            this.btn_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Sair.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sair.Image = global::CaixaFacil.Properties.Resources.Saki_Snowish_Button_exit;
            this.btn_Sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sair.Location = new System.Drawing.Point(6, 332);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(186, 45);
            this.btn_Sair.TabIndex = 23;
            this.btn_Sair.Text = "Sair - [ESC]";
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // btn_VenderParcelado
            // 
            this.btn_VenderParcelado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_VenderParcelado.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VenderParcelado.Image = global::CaixaFacil.Properties.Resources.parcelas1;
            this.btn_VenderParcelado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VenderParcelado.Location = new System.Drawing.Point(6, 179);
            this.btn_VenderParcelado.Name = "btn_VenderParcelado";
            this.btn_VenderParcelado.Size = new System.Drawing.Size(186, 45);
            this.btn_VenderParcelado.TabIndex = 22;
            this.btn_VenderParcelado.Text = "Parcelamento - [F7]";
            this.btn_VenderParcelado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_VenderParcelado.UseVisualStyleBackColor = true;
            this.btn_VenderParcelado.Click += new System.EventHandler(this.btn_VenderParcelado_Click);
            // 
            // btn_VendaVista
            // 
            this.btn_VendaVista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_VendaVista.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VendaVista.Image = global::CaixaFacil.Properties.Resources.eye_icon;
            this.btn_VendaVista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VendaVista.Location = new System.Drawing.Point(6, 24);
            this.btn_VendaVista.Name = "btn_VendaVista";
            this.btn_VendaVista.Size = new System.Drawing.Size(186, 45);
            this.btn_VendaVista.TabIndex = 19;
            this.btn_VendaVista.Text = " Vista - [F4]";
            this.btn_VendaVista.UseVisualStyleBackColor = true;
            this.btn_VendaVista.Click += new System.EventHandler(this.btn_VendaVista_Click);
            // 
            // btn_VenderPrazo
            // 
            this.btn_VenderPrazo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_VenderPrazo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VenderPrazo.Image = global::CaixaFacil.Properties.Resources.prazo11;
            this.btn_VenderPrazo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VenderPrazo.Location = new System.Drawing.Point(6, 126);
            this.btn_VenderPrazo.Name = "btn_VenderPrazo";
            this.btn_VenderPrazo.Size = new System.Drawing.Size(186, 45);
            this.btn_VenderPrazo.TabIndex = 21;
            this.btn_VenderPrazo.Text = "Prazo - [F6]";
            this.btn_VenderPrazo.UseVisualStyleBackColor = true;
            this.btn_VenderPrazo.Click += new System.EventHandler(this.btn_VenderPrazo_Click);
            // 
            // btn_CancelarVenda
            // 
            this.btn_CancelarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CancelarVenda.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarVenda.Image = global::CaixaFacil.Properties.Resources.Button_Cancel_icon__1_;
            this.btn_CancelarVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelarVenda.Location = new System.Drawing.Point(6, 280);
            this.btn_CancelarVenda.Name = "btn_CancelarVenda";
            this.btn_CancelarVenda.Size = new System.Drawing.Size(186, 45);
            this.btn_CancelarVenda.TabIndex = 20;
            this.btn_CancelarVenda.Text = "Cancelar V - [F9]      ";
            this.btn_CancelarVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CancelarVenda.UseVisualStyleBackColor = true;
            this.btn_CancelarVenda.Click += new System.EventHandler(this.btn_CancelarVenda_Click);
            // 
            // lbl_Usuario
            // 
            this.lbl_Usuario.AutoSize = true;
            this.lbl_Usuario.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Usuario.Location = new System.Drawing.Point(1056, 639);
            this.lbl_Usuario.Name = "lbl_Usuario";
            this.lbl_Usuario.Size = new System.Drawing.Size(96, 19);
            this.lbl_Usuario.TabIndex = 19;
            this.lbl_Usuario.Text = "Operador(a):";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbl_NomeEmpresa);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(1055, 96);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(215, 138);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // lbl_NomeEmpresa
            // 
            this.lbl_NomeEmpresa.AutoSize = true;
            this.lbl_NomeEmpresa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomeEmpresa.Location = new System.Drawing.Point(43, 99);
            this.lbl_NomeEmpresa.Name = "lbl_NomeEmpresa";
            this.lbl_NomeEmpresa.Size = new System.Drawing.Size(166, 19);
            this.lbl_NomeEmpresa.TabIndex = 6;
            this.lbl_NomeEmpresa.Text = "NOME DA EMPRESA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(48, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 19);
            this.label9.TabIndex = 5;
            this.label9.Text = "CAIXA LIVRE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "_____________________";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_CodigoVenda);
            this.groupBox1.Controls.Add(this.cbOpcao);
            this.groupBox1.Controls.Add(this.txt_ValorTotal);
            this.groupBox1.Controls.Add(this.btn_Remover);
            this.groupBox1.Controls.Add(this.lblValorTotalVenda);
            this.groupBox1.Controls.Add(this.btn_Adcionar);
            this.groupBox1.Controls.Add(this.txt_Quantidade);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lbl_Quantidade);
            this.groupBox1.Controls.Add(this.lbl_Informacao);
            this.groupBox1.Controls.Add(this.txt_Codigo_Barra);
            this.groupBox1.Location = new System.Drawing.Point(9, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 641);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txt_CodigoVenda
            // 
            this.txt_CodigoVenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_CodigoVenda.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CodigoVenda.Location = new System.Drawing.Point(19, 47);
            this.txt_CodigoVenda.MaxLength = 13;
            this.txt_CodigoVenda.Name = "txt_CodigoVenda";
            this.txt_CodigoVenda.ReadOnly = true;
            this.txt_CodigoVenda.Size = new System.Drawing.Size(127, 62);
            this.txt_CodigoVenda.TabIndex = 21;
            this.txt_CodigoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbOpcao
            // 
            this.cbOpcao.AutoSize = true;
            this.cbOpcao.Location = new System.Drawing.Point(16, 18);
            this.cbOpcao.Name = "cbOpcao";
            this.cbOpcao.Size = new System.Drawing.Size(212, 23);
            this.cbOpcao.TabIndex = 20;
            this.cbOpcao.Text = "Procurar por código de barras";
            this.cbOpcao.UseVisualStyleBackColor = true;
            this.cbOpcao.CheckedChanged += new System.EventHandler(this.cbOpcao_CheckedChanged);
            // 
            // txt_ValorTotal
            // 
            this.txt_ValorTotal.BackColor = System.Drawing.Color.LightGreen;
            this.txt_ValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ValorTotal.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorTotal.Location = new System.Drawing.Point(776, 516);
            this.txt_ValorTotal.Name = "txt_ValorTotal";
            this.txt_ValorTotal.ReadOnly = true;
            this.txt_ValorTotal.Size = new System.Drawing.Size(258, 46);
            this.txt_ValorTotal.TabIndex = 15;
            this.txt_ValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Remover
            // 
            this.btn_Remover.Enabled = false;
            this.btn_Remover.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Remover.Image = global::CaixaFacil.Properties.Resources.Button_Delete_icon;
            this.btn_Remover.Location = new System.Drawing.Point(920, 80);
            this.btn_Remover.Name = "btn_Remover";
            this.btn_Remover.Size = new System.Drawing.Size(111, 38);
            this.btn_Remover.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btn_Remover, "Remover");
            this.btn_Remover.UseVisualStyleBackColor = true;
            this.btn_Remover.Click += new System.EventHandler(this.btn_Remover_Click);
            // 
            // lblValorTotalVenda
            // 
            this.lblValorTotalVenda.AutoSize = true;
            this.lblValorTotalVenda.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalVenda.Location = new System.Drawing.Point(840, 489);
            this.lblValorTotalVenda.Name = "lblValorTotalVenda";
            this.lblValorTotalVenda.Size = new System.Drawing.Size(147, 19);
            this.lblValorTotalVenda.TabIndex = 14;
            this.lblValorTotalVenda.Text = "Valor total da venda ";
            // 
            // btn_Adcionar
            // 
            this.btn_Adcionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Adcionar.Image = global::CaixaFacil.Properties.Resources.Actions_list_add_icon;
            this.btn_Adcionar.Location = new System.Drawing.Point(920, 33);
            this.btn_Adcionar.Name = "btn_Adcionar";
            this.btn_Adcionar.Size = new System.Drawing.Size(111, 38);
            this.btn_Adcionar.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btn_Adcionar, "Adicionar");
            this.btn_Adcionar.UseVisualStyleBackColor = true;
            this.btn_Adcionar.Click += new System.EventHandler(this.btn_Adcionar_Click);
            // 
            // txt_Quantidade
            // 
            this.txt_Quantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Quantidade.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantidade.Location = new System.Drawing.Point(661, 44);
            this.txt_Quantidade.MaxLength = 5;
            this.txt_Quantidade.Name = "txt_Quantidade";
            this.txt_Quantidade.Size = new System.Drawing.Size(228, 69);
            this.txt_Quantidade.TabIndex = 2;
            this.txt_Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Quantidade.TextChanged += new System.EventHandler(this.txt_Quantidade_TextChanged);
            this.txt_Quantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Quantidade_KeyDown);
            this.txt_Quantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Quantidade_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_BuscarServiço);
            this.groupBox4.Controls.Add(this.btn_NovoCadastro);
            this.groupBox4.Controls.Add(this.btn_BuscarProdutos);
            this.groupBox4.Controls.Add(this.btn_BuscarPreços);
            this.groupBox4.Controls.Add(this.btn_ContasClientes);
            this.groupBox4.Location = new System.Drawing.Point(12, 481);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(756, 152);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // btn_BuscarServiço
            // 
            this.btn_BuscarServiço.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_BuscarServiço.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarServiço.Image = global::CaixaFacil.Properties.Resources.Very_Basic_Services_icon;
            this.btn_BuscarServiço.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuscarServiço.Location = new System.Drawing.Point(224, 86);
            this.btn_BuscarServiço.Name = "btn_BuscarServiço";
            this.btn_BuscarServiço.Size = new System.Drawing.Size(406, 60);
            this.btn_BuscarServiço.TabIndex = 14;
            this.btn_BuscarServiço.Text = "Serviços - [F10]";
            this.btn_BuscarServiço.UseVisualStyleBackColor = true;
            this.btn_BuscarServiço.Click += new System.EventHandler(this.btn_BuscarServiço_Click);
            // 
            // btn_NovoCadastro
            // 
            this.btn_NovoCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_NovoCadastro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NovoCadastro.Image = global::CaixaFacil.Properties.Resources.Files_New_File_icon;
            this.btn_NovoCadastro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NovoCadastro.Location = new System.Drawing.Point(9, 20);
            this.btn_NovoCadastro.Name = "btn_NovoCadastro";
            this.btn_NovoCadastro.Size = new System.Drawing.Size(179, 60);
            this.btn_NovoCadastro.TabIndex = 13;
            this.btn_NovoCadastro.Text = "Novo Cadastro - [F]";
            this.btn_NovoCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_NovoCadastro.UseVisualStyleBackColor = true;
            this.btn_NovoCadastro.Click += new System.EventHandler(this.btn_NovoCadastro_Click);
            // 
            // btn_BuscarProdutos
            // 
            this.btn_BuscarProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_BuscarProdutos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarProdutos.Image = global::CaixaFacil.Properties.Resources.product_icon__1_;
            this.btn_BuscarProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuscarProdutos.Location = new System.Drawing.Point(412, 20);
            this.btn_BuscarProdutos.Name = "btn_BuscarProdutos";
            this.btn_BuscarProdutos.Size = new System.Drawing.Size(164, 60);
            this.btn_BuscarProdutos.TabIndex = 12;
            this.btn_BuscarProdutos.Text = "Produtos - [F2]";
            this.btn_BuscarProdutos.UseVisualStyleBackColor = true;
            this.btn_BuscarProdutos.Click += new System.EventHandler(this.btn_BuscarProdutos_Click);
            // 
            // btn_BuscarPreços
            // 
            this.btn_BuscarPreços.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_BuscarPreços.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarPreços.Image = global::CaixaFacil.Properties.Resources.Ecommerce_Price_Tag_icon__1_;
            this.btn_BuscarPreços.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BuscarPreços.Location = new System.Drawing.Point(582, 21);
            this.btn_BuscarPreços.Name = "btn_BuscarPreços";
            this.btn_BuscarPreços.Size = new System.Drawing.Size(156, 60);
            this.btn_BuscarPreços.TabIndex = 11;
            this.btn_BuscarPreços.Text = "Preços - [F3]";
            this.btn_BuscarPreços.UseVisualStyleBackColor = true;
            this.btn_BuscarPreços.Click += new System.EventHandler(this.btn_BuscarPreços_Click);
            // 
            // btn_ContasClientes
            // 
            this.btn_ContasClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ContasClientes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ContasClientes.Image = global::CaixaFacil.Properties.Resources.client_account_template_icon;
            this.btn_ContasClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ContasClientes.Location = new System.Drawing.Point(194, 20);
            this.btn_ContasClientes.Name = "btn_ContasClientes";
            this.btn_ContasClientes.Size = new System.Drawing.Size(212, 60);
            this.btn_ContasClientes.TabIndex = 10;
            this.btn_ContasClientes.Text = " Contas de Clientes - [F1]";
            this.btn_ContasClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ContasClientes.UseVisualStyleBackColor = true;
            this.btn_ContasClientes.Click += new System.EventHandler(this.btn_ContasClientes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_ItensVenda);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1019, 360);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // DGV_ItensVenda
            // 
            this.DGV_ItensVenda.AllowUserToAddRows = false;
            this.DGV_ItensVenda.AllowUserToDeleteRows = false;
            this.DGV_ItensVenda.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_ItensVenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.DGV_ItensVenda.ColumnHeadersHeight = 30;
            this.DGV_ItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_ItensVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCodigo,
            this.ColumnDescricaoProduto,
            this.ColumnQuantidade,
            this.ColumnUnidade,
            this.ColumnValorUnitario,
            this.ColumnSubTotal});
            this.DGV_ItensVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ItensVenda.Location = new System.Drawing.Point(3, 22);
            this.DGV_ItensVenda.Name = "DGV_ItensVenda";
            this.DGV_ItensVenda.ReadOnly = true;
            this.DGV_ItensVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_ItensVenda.Size = new System.Drawing.Size(1013, 335);
            this.DGV_ItensVenda.TabIndex = 0;
            this.DGV_ItensVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ItensVenda_CellClick);
            // 
            // ColumnCodigo
            // 
            this.ColumnCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ColumnCodigo.DefaultCellStyle = dataGridViewCellStyle23;
            this.ColumnCodigo.HeaderText = "Código";
            this.ColumnCodigo.Name = "ColumnCodigo";
            this.ColumnCodigo.ReadOnly = true;
            this.ColumnCodigo.Width = 79;
            // 
            // ColumnDescricaoProduto
            // 
            this.ColumnDescricaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ColumnDescricaoProduto.DefaultCellStyle = dataGridViewCellStyle24;
            this.ColumnDescricaoProduto.HeaderText = "Descrição";
            this.ColumnDescricaoProduto.Name = "ColumnDescricaoProduto";
            this.ColumnDescricaoProduto.ReadOnly = true;
            // 
            // ColumnQuantidade
            // 
            this.ColumnQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ColumnQuantidade.DefaultCellStyle = dataGridViewCellStyle25;
            this.ColumnQuantidade.HeaderText = "Quantidade";
            this.ColumnQuantidade.Name = "ColumnQuantidade";
            this.ColumnQuantidade.ReadOnly = true;
            this.ColumnQuantidade.Width = 104;
            // 
            // ColumnUnidade
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ColumnUnidade.DefaultCellStyle = dataGridViewCellStyle26;
            this.ColumnUnidade.HeaderText = "Unidade";
            this.ColumnUnidade.Name = "ColumnUnidade";
            this.ColumnUnidade.ReadOnly = true;
            // 
            // ColumnValorUnitario
            // 
            this.ColumnValorUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle27.Format = "C2";
            dataGridViewCellStyle27.NullValue = null;
            this.ColumnValorUnitario.DefaultCellStyle = dataGridViewCellStyle27;
            this.ColumnValorUnitario.HeaderText = "Valor Unitário";
            this.ColumnValorUnitario.Name = "ColumnValorUnitario";
            this.ColumnValorUnitario.ReadOnly = true;
            this.ColumnValorUnitario.Width = 118;
            // 
            // ColumnSubTotal
            // 
            this.ColumnSubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle28.Format = "C2";
            dataGridViewCellStyle28.NullValue = null;
            this.ColumnSubTotal.DefaultCellStyle = dataGridViewCellStyle28;
            this.ColumnSubTotal.HeaderText = "Valor SubTotal";
            this.ColumnSubTotal.Name = "ColumnSubTotal";
            this.ColumnSubTotal.ReadOnly = true;
            this.ColumnSubTotal.Width = 124;
            // 
            // lbl_Quantidade
            // 
            this.lbl_Quantidade.AutoSize = true;
            this.lbl_Quantidade.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Quantidade.Location = new System.Drawing.Point(712, 22);
            this.lbl_Quantidade.Name = "lbl_Quantidade";
            this.lbl_Quantidade.Size = new System.Drawing.Size(86, 19);
            this.lbl_Quantidade.TabIndex = 3;
            this.lbl_Quantidade.Text = "Quantidade";
            // 
            // lbl_Informacao
            // 
            this.lbl_Informacao.AutoSize = true;
            this.lbl_Informacao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Informacao.Location = new System.Drawing.Point(247, 19);
            this.lbl_Informacao.Name = "lbl_Informacao";
            this.lbl_Informacao.Size = new System.Drawing.Size(249, 19);
            this.lbl_Informacao.TabIndex = 2;
            this.lbl_Informacao.Text = "Código do produto/ Código de Barra";
            // 
            // txt_Codigo_Barra
            // 
            this.txt_Codigo_Barra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Codigo_Barra.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Codigo_Barra.Location = new System.Drawing.Point(150, 44);
            this.txt_Codigo_Barra.MaxLength = 13;
            this.txt_Codigo_Barra.Name = "txt_Codigo_Barra";
            this.txt_Codigo_Barra.Size = new System.Drawing.Size(505, 69);
            this.txt_Codigo_Barra.TabIndex = 0;
            this.txt_Codigo_Barra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Codigo_Barra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Codigo_Barra_KeyDown);
            this.txt_Codigo_Barra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Codigo_Barra_KeyPress);
            // 
            // PanelCabecalho
            // 
            this.PanelCabecalho.BackColor = System.Drawing.Color.Green;
            this.PanelCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCabecalho.Controls.Add(this.Lbl_Titulo);
            this.PanelCabecalho.Controls.Add(this.Lbl_Icone);
            this.PanelCabecalho.Controls.Add(this.btn_Fechar);
            this.PanelCabecalho.Controls.Add(this.btn_Minimizar);
            this.PanelCabecalho.Location = new System.Drawing.Point(-1, -1);
            this.PanelCabecalho.Margin = new System.Windows.Forms.Padding(4);
            this.PanelCabecalho.Name = "PanelCabecalho";
            this.PanelCabecalho.Size = new System.Drawing.Size(1350, 90);
            this.PanelCabecalho.TabIndex = 0;
            this.PanelCabecalho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelCabecalho_MouseDown);
            this.PanelCabecalho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelCabecalho_MouseMove);
            // 
            // Lbl_Titulo
            // 
            this.Lbl_Titulo.AutoSize = true;
            this.Lbl_Titulo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.Lbl_Titulo.Location = new System.Drawing.Point(107, 36);
            this.Lbl_Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Titulo.Name = "Lbl_Titulo";
            this.Lbl_Titulo.Size = new System.Drawing.Size(128, 19);
            this.Lbl_Titulo.TabIndex = 65;
            this.Lbl_Titulo.Text = "Sistema de Venda";
            // 
            // Lbl_Icone
            // 
            this.Lbl_Icone.Image = global::CaixaFacil.Properties.Resources.Carrinho_de_compra;
            this.Lbl_Icone.Location = new System.Drawing.Point(20, 7);
            this.Lbl_Icone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Icone.Name = "Lbl_Icone";
            this.Lbl_Icone.Size = new System.Drawing.Size(88, 67);
            this.Lbl_Icone.TabIndex = 64;
            this.Lbl_Icone.Text = "    ";
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Fechar.BackColor = System.Drawing.Color.Green;
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fechar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fechar.ForeColor = System.Drawing.Color.White;
            this.btn_Fechar.Location = new System.Drawing.Point(1249, 7);
            this.btn_Fechar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(38, 41);
            this.btn_Fechar.TabIndex = 62;
            this.btn_Fechar.Text = "X";
            this.toolTip1.SetToolTip(this.btn_Fechar, "Fechar");
            this.btn_Fechar.UseVisualStyleBackColor = false;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            this.btn_Fechar.MouseEnter += new System.EventHandler(this.btn_Fechar_MouseEnter);
            this.btn_Fechar.MouseLeave += new System.EventHandler(this.btn_Fechar_MouseLeave);
            // 
            // btn_Minimizar
            // 
            this.btn_Minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Minimizar.BackColor = System.Drawing.Color.Green;
            this.btn_Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Minimizar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimizar.ForeColor = System.Drawing.Color.White;
            this.btn_Minimizar.Location = new System.Drawing.Point(1203, 7);
            this.btn_Minimizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Minimizar.Name = "btn_Minimizar";
            this.btn_Minimizar.Size = new System.Drawing.Size(38, 41);
            this.btn_Minimizar.TabIndex = 61;
            this.btn_Minimizar.Text = "__";
            this.toolTip1.SetToolTip(this.btn_Minimizar, "Minimizar");
            this.btn_Minimizar.UseVisualStyleBackColor = false;
            this.btn_Minimizar.Click += new System.EventHandler(this.btn_Minimizar_Click);
            this.btn_Minimizar.MouseEnter += new System.EventHandler(this.btn_Minimizar_MouseEnter);
            this.btn_Minimizar.MouseLeave += new System.EventHandler(this.btn_Minimizar_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 733);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar Venda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVenda_FormClosing);
            this.Load += new System.EventHandler(this.FrmVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVenda_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.btn_GerarRecibo.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ItensVenda)).EndInit();
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
        private System.Windows.Forms.Button btn_Minimizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_BuscarProdutos;
        private System.Windows.Forms.Button btn_BuscarPreços;
        private System.Windows.Forms.Button btn_ContasClientes;
        private System.Windows.Forms.TextBox txt_ValorTotal;
        private System.Windows.Forms.Label lblValorTotalVenda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_Quantidade;
        private System.Windows.Forms.Label lbl_Informacao;
        private System.Windows.Forms.TextBox txt_Codigo_Barra;
        private System.Windows.Forms.TextBox txt_Quantidade;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbl_NomeEmpresa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Remover;
        private System.Windows.Forms.Button btn_Adcionar;
        private System.Windows.Forms.Label lbl_Hora;
        private System.Windows.Forms.Label lbl_Data;
        private System.Windows.Forms.GroupBox btn_GerarRecibo;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.Button btn_VenderParcelado;
        private System.Windows.Forms.Button btn_VendaVista;
        private System.Windows.Forms.Button btn_VenderPrazo;
        private System.Windows.Forms.Button btn_CancelarVenda;
        private System.Windows.Forms.CheckBox cbOpcao;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_NovoCadastro;
        private System.Windows.Forms.Button btn_PagamentoParcial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_atendente;
        private System.Windows.Forms.TextBox txt_CodigoVenda;
        private System.Windows.Forms.DataGridView DGV_ItensVenda;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescricaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubTotal;
        private System.Windows.Forms.Label lbl_Usuario;
        private System.Windows.Forms.Button btn_BuscarServiço;
        private System.Windows.Forms.Button btnPagamentoCartao;
    }
}