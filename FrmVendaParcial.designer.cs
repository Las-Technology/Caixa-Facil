namespace CaixaFacil
{
    partial class FrmVendaParcial
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
            this.lbl_FecharParcelamento = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.lbl_Situacao = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.lbl_SeparadorDados = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lblCodigo_Cliente = new System.Windows.Forms.Label();
            this.lblNome_Cliente = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.btn_FinalizarParcial = new System.Windows.Forms.Button();
            this.btn_CancelaVendaMisto = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ValorRestante = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txt_TotalAbatido = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txt_ValorVenda = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txt_DescontoPorcento = new System.Windows.Forms.TextBox();
            this.lbl_DescontoPorcento = new System.Windows.Forms.Label();
            this.txt_DescontoDinheiro = new System.Windows.Forms.TextBox();
            this.txt_ValorDesconto = new System.Windows.Forms.TextBox();
            this.lbl_ValorDesconto = new System.Windows.Forms.Label();
            this.lbl_DescontoDinheiro = new System.Windows.Forms.Label();
            this.btn_Descontar = new System.Windows.Forms.Button();
            this.txt_ValorAbatido = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.lbl_FecharVendaMisto = new System.Windows.Forms.Label();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_FecharParcelamento
            // 
            this.lbl_FecharParcelamento.AutoSize = true;
            this.lbl_FecharParcelamento.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FecharParcelamento.ForeColor = System.Drawing.Color.White;
            this.lbl_FecharParcelamento.Location = new System.Drawing.Point(1030, 3);
            this.lbl_FecharParcelamento.Name = "lbl_FecharParcelamento";
            this.lbl_FecharParcelamento.Size = new System.Drawing.Size(33, 31);
            this.lbl_FecharParcelamento.TabIndex = 10;
            this.lbl_FecharParcelamento.Text = "X";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.lbl_Situacao);
            this.groupBox13.Controls.Add(this.btn_Buscar);
            this.groupBox13.Controls.Add(this.lbl_SeparadorDados);
            this.groupBox13.Controls.Add(this.label36);
            this.groupBox13.Controls.Add(this.label37);
            this.groupBox13.Controls.Add(this.label38);
            this.groupBox13.Controls.Add(this.lblCodigo_Cliente);
            this.groupBox13.Controls.Add(this.lblNome_Cliente);
            this.groupBox13.Controls.Add(this.label29);
            this.groupBox13.Controls.Add(this.txt_nome);
            this.groupBox13.ForeColor = System.Drawing.Color.White;
            this.groupBox13.Location = new System.Drawing.Point(6, 176);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(496, 153);
            this.groupBox13.TabIndex = 20;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Pagamento";
            // 
            // lbl_Situacao
            // 
            this.lbl_Situacao.AutoSize = true;
            this.lbl_Situacao.Location = new System.Drawing.Point(10, 126);
            this.lbl_Situacao.Name = "lbl_Situacao";
            this.lbl_Situacao.Size = new System.Drawing.Size(0, 19);
            this.lbl_Situacao.TabIndex = 21;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::CaixaFacil.Properties.Resources.magnifying_glass_icon;
            this.btn_Buscar.Location = new System.Drawing.Point(407, 44);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(83, 38);
            this.btn_Buscar.TabIndex = 20;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // lbl_SeparadorDados
            // 
            this.lbl_SeparadorDados.AutoSize = true;
            this.lbl_SeparadorDados.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SeparadorDados.ForeColor = System.Drawing.Color.White;
            this.lbl_SeparadorDados.Location = new System.Drawing.Point(65, 104);
            this.lbl_SeparadorDados.Name = "lbl_SeparadorDados";
            this.lbl_SeparadorDados.Size = new System.Drawing.Size(12, 19);
            this.lbl_SeparadorDados.TabIndex = 19;
            this.lbl_SeparadorDados.Text = "|";
            this.lbl_SeparadorDados.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(65, 81);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(12, 19);
            this.label36.TabIndex = 18;
            this.label36.Text = "|";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(12, 81);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(56, 19);
            this.label37.TabIndex = 17;
            this.label37.Text = "Código";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(77, 81);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 19);
            this.label38.TabIndex = 16;
            this.label38.Text = "Nome";
            // 
            // lblCodigo_Cliente
            // 
            this.lblCodigo_Cliente.AutoSize = true;
            this.lblCodigo_Cliente.ForeColor = System.Drawing.Color.White;
            this.lblCodigo_Cliente.Location = new System.Drawing.Point(12, 104);
            this.lblCodigo_Cliente.Name = "lblCodigo_Cliente";
            this.lblCodigo_Cliente.Size = new System.Drawing.Size(0, 19);
            this.lblCodigo_Cliente.TabIndex = 15;
            // 
            // lblNome_Cliente
            // 
            this.lblNome_Cliente.AutoSize = true;
            this.lblNome_Cliente.ForeColor = System.Drawing.Color.White;
            this.lblNome_Cliente.Location = new System.Drawing.Point(80, 104);
            this.lblNome_Cliente.Name = "lblNome_Cliente";
            this.lblNome_Cliente.Size = new System.Drawing.Size(0, 19);
            this.lblNome_Cliente.TabIndex = 14;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(12, 23);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(117, 19);
            this.label29.TabIndex = 7;
            this.label29.Text = "Nome do cliente";
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(15, 51);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.ReadOnly = true;
            this.txt_nome.Size = new System.Drawing.Size(386, 26);
            this.txt_nome.TabIndex = 6;
            // 
            // btn_FinalizarParcial
            // 
            this.btn_FinalizarParcial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FinalizarParcial.ForeColor = System.Drawing.Color.Black;
            this.btn_FinalizarParcial.Image = global::CaixaFacil.Properties.Resources.Ok_icon;
            this.btn_FinalizarParcial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FinalizarParcial.Location = new System.Drawing.Point(670, 283);
            this.btn_FinalizarParcial.Name = "btn_FinalizarParcial";
            this.btn_FinalizarParcial.Size = new System.Drawing.Size(164, 46);
            this.btn_FinalizarParcial.TabIndex = 21;
            this.btn_FinalizarParcial.Text = "Finalizar - [F10]";
            this.btn_FinalizarParcial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FinalizarParcial.UseVisualStyleBackColor = true;
            this.btn_FinalizarParcial.Click += new System.EventHandler(this.btn_FinalizarParcial_Click);
            // 
            // btn_CancelaVendaMisto
            // 
            this.btn_CancelaVendaMisto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelaVendaMisto.ForeColor = System.Drawing.Color.Black;
            this.btn_CancelaVendaMisto.Image = global::CaixaFacil.Properties.Resources.Button_Cancel_icon__1_;
            this.btn_CancelaVendaMisto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelaVendaMisto.Location = new System.Drawing.Point(508, 283);
            this.btn_CancelaVendaMisto.Name = "btn_CancelaVendaMisto";
            this.btn_CancelaVendaMisto.Size = new System.Drawing.Size(162, 46);
            this.btn_CancelaVendaMisto.TabIndex = 22;
            this.btn_CancelaVendaMisto.Text = "Cancelar - [ESC]";
            this.btn_CancelaVendaMisto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CancelaVendaMisto.UseVisualStyleBackColor = true;
            this.btn_CancelaVendaMisto.Click += new System.EventHandler(this.btn_CancelaVendaMisto_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtValorTotal);
            this.groupBox12.Controls.Add(this.label1);
            this.groupBox12.Controls.Add(this.txt_ValorRestante);
            this.groupBox12.Controls.Add(this.label34);
            this.groupBox12.Controls.Add(this.txt_TotalAbatido);
            this.groupBox12.Controls.Add(this.label33);
            this.groupBox12.Controls.Add(this.txt_ValorVenda);
            this.groupBox12.Controls.Add(this.label32);
            this.groupBox12.Location = new System.Drawing.Point(509, 14);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(257, 261);
            this.groupBox12.TabIndex = 19;
            this.groupBox12.TabStop = false;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(39, 104);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(129, 26);
            this.txtValorTotal.TabIndex = 13;
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Valor total com desconto:";
            // 
            // txt_ValorRestante
            // 
            this.txt_ValorRestante.Location = new System.Drawing.Point(39, 206);
            this.txt_ValorRestante.Name = "txt_ValorRestante";
            this.txt_ValorRestante.ReadOnly = true;
            this.txt_ValorRestante.Size = new System.Drawing.Size(129, 26);
            this.txt_ValorRestante.TabIndex = 11;
            this.txt_ValorRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(35, 184);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(109, 19);
            this.label34.TabIndex = 10;
            this.label34.Text = "Valor restante:";
            // 
            // txt_TotalAbatido
            // 
            this.txt_TotalAbatido.Location = new System.Drawing.Point(39, 155);
            this.txt_TotalAbatido.Name = "txt_TotalAbatido";
            this.txt_TotalAbatido.ReadOnly = true;
            this.txt_TotalAbatido.Size = new System.Drawing.Size(129, 26);
            this.txt_TotalAbatido.TabIndex = 9;
            this.txt_TotalAbatido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(35, 133);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(101, 19);
            this.label33.TabIndex = 8;
            this.label33.Text = "Total abatido:";
            // 
            // txt_ValorVenda
            // 
            this.txt_ValorVenda.Location = new System.Drawing.Point(39, 52);
            this.txt_ValorVenda.Name = "txt_ValorVenda";
            this.txt_ValorVenda.ReadOnly = true;
            this.txt_ValorVenda.Size = new System.Drawing.Size(129, 26);
            this.txt_ValorVenda.TabIndex = 7;
            this.txt_ValorVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(35, 26);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(178, 19);
            this.label32.TabIndex = 6;
            this.label32.Text = "Valor venda e/ou serviço:";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txt_DescontoPorcento);
            this.groupBox11.Controls.Add(this.lbl_DescontoPorcento);
            this.groupBox11.Controls.Add(this.txt_DescontoDinheiro);
            this.groupBox11.Controls.Add(this.txt_ValorDesconto);
            this.groupBox11.Controls.Add(this.lbl_ValorDesconto);
            this.groupBox11.Controls.Add(this.lbl_DescontoDinheiro);
            this.groupBox11.Controls.Add(this.btn_Descontar);
            this.groupBox11.Controls.Add(this.txt_ValorAbatido);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.ForeColor = System.Drawing.Color.White;
            this.groupBox11.Location = new System.Drawing.Point(9, 14);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(494, 156);
            this.groupBox11.TabIndex = 18;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Pagamento";
            // 
            // txt_DescontoPorcento
            // 
            this.txt_DescontoPorcento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescontoPorcento.Location = new System.Drawing.Point(11, 108);
            this.txt_DescontoPorcento.Name = "txt_DescontoPorcento";
            this.txt_DescontoPorcento.Size = new System.Drawing.Size(147, 26);
            this.txt_DescontoPorcento.TabIndex = 310;
            this.txt_DescontoPorcento.Text = "0,00";
            this.txt_DescontoPorcento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_DescontoPorcento.Visible = false;
            this.txt_DescontoPorcento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DescontoPorcento_KeyPress);
            this.txt_DescontoPorcento.Leave += new System.EventHandler(this.txt_DescontoPorcento_Leave);
            // 
            // lbl_DescontoPorcento
            // 
            this.lbl_DescontoPorcento.AutoSize = true;
            this.lbl_DescontoPorcento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DescontoPorcento.ForeColor = System.Drawing.Color.White;
            this.lbl_DescontoPorcento.Location = new System.Drawing.Point(12, 83);
            this.lbl_DescontoPorcento.Name = "lbl_DescontoPorcento";
            this.lbl_DescontoPorcento.Size = new System.Drawing.Size(97, 19);
            this.lbl_DescontoPorcento.TabIndex = 312;
            this.lbl_DescontoPorcento.Text = "Desconto -%";
            this.lbl_DescontoPorcento.Visible = false;
            // 
            // txt_DescontoDinheiro
            // 
            this.txt_DescontoDinheiro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescontoDinheiro.Location = new System.Drawing.Point(167, 108);
            this.txt_DescontoDinheiro.Name = "txt_DescontoDinheiro";
            this.txt_DescontoDinheiro.Size = new System.Drawing.Size(147, 26);
            this.txt_DescontoDinheiro.TabIndex = 311;
            this.txt_DescontoDinheiro.Text = "0,00";
            this.txt_DescontoDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_DescontoDinheiro.Visible = false;
            this.txt_DescontoDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DescontoDinheiro_KeyPress);
            this.txt_DescontoDinheiro.Leave += new System.EventHandler(this.txt_DescontoDinheiro_Leave);
            // 
            // txt_ValorDesconto
            // 
            this.txt_ValorDesconto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorDesconto.Location = new System.Drawing.Point(320, 108);
            this.txt_ValorDesconto.Name = "txt_ValorDesconto";
            this.txt_ValorDesconto.ReadOnly = true;
            this.txt_ValorDesconto.Size = new System.Drawing.Size(144, 26);
            this.txt_ValorDesconto.TabIndex = 313;
            this.txt_ValorDesconto.Text = "0,00";
            this.txt_ValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ValorDesconto.Visible = false;
            // 
            // lbl_ValorDesconto
            // 
            this.lbl_ValorDesconto.AutoSize = true;
            this.lbl_ValorDesconto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorDesconto.ForeColor = System.Drawing.Color.White;
            this.lbl_ValorDesconto.Location = new System.Drawing.Point(315, 86);
            this.lbl_ValorDesconto.Name = "lbl_ValorDesconto";
            this.lbl_ValorDesconto.Size = new System.Drawing.Size(172, 19);
            this.lbl_ValorDesconto.TabIndex = 309;
            this.lbl_ValorDesconto.Text = "Valor com desconto - R$";
            this.lbl_ValorDesconto.Visible = false;
            // 
            // lbl_DescontoDinheiro
            // 
            this.lbl_DescontoDinheiro.AutoSize = true;
            this.lbl_DescontoDinheiro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DescontoDinheiro.ForeColor = System.Drawing.Color.White;
            this.lbl_DescontoDinheiro.Location = new System.Drawing.Point(168, 83);
            this.lbl_DescontoDinheiro.Name = "lbl_DescontoDinheiro";
            this.lbl_DescontoDinheiro.Size = new System.Drawing.Size(105, 19);
            this.lbl_DescontoDinheiro.TabIndex = 308;
            this.lbl_DescontoDinheiro.Text = "Desconto - R$";
            this.lbl_DescontoDinheiro.Visible = false;
            // 
            // btn_Descontar
            // 
            this.btn_Descontar.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Descontar.ForeColor = System.Drawing.Color.Black;
            this.btn_Descontar.Image = global::CaixaFacil.Properties.Resources.Ecommerce_Discount_icon1;
            this.btn_Descontar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Descontar.Location = new System.Drawing.Point(167, 40);
            this.btn_Descontar.Name = "btn_Descontar";
            this.btn_Descontar.Size = new System.Drawing.Size(144, 35);
            this.btn_Descontar.TabIndex = 296;
            this.btn_Descontar.Text = "      Desconto - [F4]";
            this.btn_Descontar.UseVisualStyleBackColor = true;
            this.btn_Descontar.Click += new System.EventHandler(this.btn_Descontar_Click);
            // 
            // txt_ValorAbatido
            // 
            this.txt_ValorAbatido.Location = new System.Drawing.Point(11, 45);
            this.txt_ValorAbatido.Name = "txt_ValorAbatido";
            this.txt_ValorAbatido.Size = new System.Drawing.Size(150, 26);
            this.txt_ValorAbatido.TabIndex = 5;
            this.txt_ValorAbatido.Text = "0,00";
            this.txt_ValorAbatido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ValorAbatido.TextChanged += new System.EventHandler(this.txt_ValorAbatido_TextChanged);
            this.txt_ValorAbatido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ValorAbatido_KeyPress);
            this.txt_ValorAbatido.Leave += new System.EventHandler(this.txt_ValorAbatido_Leave);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(7, 23);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(144, 19);
            this.label31.TabIndex = 4;
            this.label31.Text = "Valor p/ abatimento:";
            // 
            // lbl_FecharVendaMisto
            // 
            this.lbl_FecharVendaMisto.AutoSize = true;
            this.lbl_FecharVendaMisto.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FecharVendaMisto.ForeColor = System.Drawing.Color.White;
            this.lbl_FecharVendaMisto.Location = new System.Drawing.Point(814, -2);
            this.lbl_FecharVendaMisto.Name = "lbl_FecharVendaMisto";
            this.lbl_FecharVendaMisto.Size = new System.Drawing.Size(33, 31);
            this.lbl_FecharVendaMisto.TabIndex = 17;
            this.lbl_FecharVendaMisto.Text = "X";
            this.lbl_FecharVendaMisto.Click += new System.EventHandler(this.lbl_FecharVendaMisto_Click);
            this.lbl_FecharVendaMisto.MouseEnter += new System.EventHandler(this.lbl_FecharVendaMisto_MouseEnter);
            this.lbl_FecharVendaMisto.MouseLeave += new System.EventHandler(this.lbl_FecharVendaMisto_MouseLeave);
            // 
            // FrmVendaParcial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(846, 342);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.btn_FinalizarParcial);
            this.Controls.Add(this.btn_CancelaVendaMisto);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.lbl_FecharVendaMisto);
            this.Controls.Add(this.lbl_FecharParcelamento);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVendaParcial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVendaParcelas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVendaParcial_KeyDown);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_FecharParcelamento;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label lbl_Situacao;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label lbl_SeparadorDados;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lblCodigo_Cliente;
        private System.Windows.Forms.Label lblNome_Cliente;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Button btn_FinalizarParcial;
        private System.Windows.Forms.Button btn_CancelaVendaMisto;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox txt_ValorRestante;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txt_TotalAbatido;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txt_ValorVenda;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txt_ValorAbatido;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lbl_FecharVendaMisto;
        private System.Windows.Forms.Button btn_Descontar;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DescontoPorcento;
        private System.Windows.Forms.Label lbl_DescontoPorcento;
        private System.Windows.Forms.TextBox txt_DescontoDinheiro;
        private System.Windows.Forms.TextBox txt_ValorDesconto;
        private System.Windows.Forms.Label lbl_ValorDesconto;
        private System.Windows.Forms.Label lbl_DescontoDinheiro;
    }
}