namespace CaixaFacil
{
    partial class FrmVendaMista
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
            this.btn_Finalizar = new System.Windows.Forms.Button();
            this.btn_CancelarVendaVista = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblValorVenda = new System.Windows.Forms.Label();
            this.lblFechar = new System.Windows.Forms.Label();
            this.txt_DescontoPorcento = new System.Windows.Forms.TextBox();
            this.lbl_DescontoPorcento = new System.Windows.Forms.Label();
            this.txt_DescontoDinheiro = new System.Windows.Forms.TextBox();
            this.txt_ValorTotalDesconto = new System.Windows.Forms.TextBox();
            this.lbl_ValorDesconto = new System.Windows.Forms.Label();
            this.lbl_DescontoDinheiro = new System.Windows.Forms.Label();
            this.btn_Descontar = new System.Windows.Forms.Button();
            this.gbPagamento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.txtValorCreditoAndDebito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorDinheiro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbPagamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Finalizar
            // 
            this.btn_Finalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Finalizar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Finalizar.Image = global::CaixaFacil.Properties.Resources.Ok_icon;
            this.btn_Finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Finalizar.Location = new System.Drawing.Point(366, 307);
            this.btn_Finalizar.Name = "btn_Finalizar";
            this.btn_Finalizar.Size = new System.Drawing.Size(164, 60);
            this.btn_Finalizar.TabIndex = 295;
            this.btn_Finalizar.Text = "Finalizar - [F10]";
            this.btn_Finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Finalizar.UseVisualStyleBackColor = true;
            this.btn_Finalizar.Click += new System.EventHandler(this.btn_Finalizar_Click);
            // 
            // btn_CancelarVendaVista
            // 
            this.btn_CancelarVendaVista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CancelarVendaVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarVendaVista.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarVendaVista.Image = global::CaixaFacil.Properties.Resources.Button_Cancel_icon__1_;
            this.btn_CancelarVendaVista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelarVendaVista.Location = new System.Drawing.Point(187, 307);
            this.btn_CancelarVendaVista.Name = "btn_CancelarVendaVista";
            this.btn_CancelarVendaVista.Size = new System.Drawing.Size(173, 60);
            this.btn_CancelarVendaVista.TabIndex = 294;
            this.btn_CancelarVendaVista.Text = "Cancelar - [ESC]";
            this.btn_CancelarVendaVista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CancelarVendaVista.UseVisualStyleBackColor = true;
            this.btn_CancelarVendaVista.Click += new System.EventHandler(this.btn_CancelarVendaVista_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 301;
            this.label4.Text = "Valor da venda (R$)";
            // 
            // lblValorVenda
            // 
            this.lblValorVenda.BackColor = System.Drawing.Color.White;
            this.lblValorVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorVenda.ForeColor = System.Drawing.Color.Black;
            this.lblValorVenda.Location = new System.Drawing.Point(28, 43);
            this.lblValorVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorVenda.Name = "lblValorVenda";
            this.lblValorVenda.Size = new System.Drawing.Size(154, 26);
            this.lblValorVenda.TabIndex = 302;
            this.lblValorVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechar
            // 
            this.lblFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechar.AutoSize = true;
            this.lblFechar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechar.Location = new System.Drawing.Point(516, 2);
            this.lblFechar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechar.Name = "lblFechar";
            this.lblFechar.Size = new System.Drawing.Size(24, 23);
            this.lblFechar.TabIndex = 303;
            this.lblFechar.Text = "X";
            this.lblFechar.Click += new System.EventHandler(this.lblFechar_Click);
            this.lblFechar.MouseEnter += new System.EventHandler(this.lblFechar_MouseEnter);
            this.lblFechar.MouseLeave += new System.EventHandler(this.lblFechar_MouseLeave);
            // 
            // txt_DescontoPorcento
            // 
            this.txt_DescontoPorcento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescontoPorcento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescontoPorcento.Location = new System.Drawing.Point(26, 105);
            this.txt_DescontoPorcento.Name = "txt_DescontoPorcento";
            this.txt_DescontoPorcento.Size = new System.Drawing.Size(147, 26);
            this.txt_DescontoPorcento.TabIndex = 317;
            this.txt_DescontoPorcento.Text = "0,00";
            this.txt_DescontoPorcento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_DescontoPorcento.Visible = false;
            // 
            // lbl_DescontoPorcento
            // 
            this.lbl_DescontoPorcento.AutoSize = true;
            this.lbl_DescontoPorcento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DescontoPorcento.ForeColor = System.Drawing.Color.White;
            this.lbl_DescontoPorcento.Location = new System.Drawing.Point(27, 80);
            this.lbl_DescontoPorcento.Name = "lbl_DescontoPorcento";
            this.lbl_DescontoPorcento.Size = new System.Drawing.Size(101, 19);
            this.lbl_DescontoPorcento.TabIndex = 319;
            this.lbl_DescontoPorcento.Text = "Desconto - %";
            this.lbl_DescontoPorcento.Visible = false;
            // 
            // txt_DescontoDinheiro
            // 
            this.txt_DescontoDinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescontoDinheiro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescontoDinheiro.Location = new System.Drawing.Point(182, 105);
            this.txt_DescontoDinheiro.Name = "txt_DescontoDinheiro";
            this.txt_DescontoDinheiro.Size = new System.Drawing.Size(147, 26);
            this.txt_DescontoDinheiro.TabIndex = 318;
            this.txt_DescontoDinheiro.Text = "0,00";
            this.txt_DescontoDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_DescontoDinheiro.Visible = false;
            // 
            // txt_ValorTotalDesconto
            // 
            this.txt_ValorTotalDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ValorTotalDesconto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorTotalDesconto.Location = new System.Drawing.Point(335, 105);
            this.txt_ValorTotalDesconto.Name = "txt_ValorTotalDesconto";
            this.txt_ValorTotalDesconto.ReadOnly = true;
            this.txt_ValorTotalDesconto.Size = new System.Drawing.Size(144, 26);
            this.txt_ValorTotalDesconto.TabIndex = 320;
            this.txt_ValorTotalDesconto.Text = "0,00";
            this.txt_ValorTotalDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ValorTotalDesconto.Visible = false;
            // 
            // lbl_ValorDesconto
            // 
            this.lbl_ValorDesconto.AutoSize = true;
            this.lbl_ValorDesconto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorDesconto.ForeColor = System.Drawing.Color.White;
            this.lbl_ValorDesconto.Location = new System.Drawing.Point(330, 83);
            this.lbl_ValorDesconto.Name = "lbl_ValorDesconto";
            this.lbl_ValorDesconto.Size = new System.Drawing.Size(172, 19);
            this.lbl_ValorDesconto.TabIndex = 316;
            this.lbl_ValorDesconto.Text = "Valor com desconto - R$";
            this.lbl_ValorDesconto.Visible = false;
            // 
            // lbl_DescontoDinheiro
            // 
            this.lbl_DescontoDinheiro.AutoSize = true;
            this.lbl_DescontoDinheiro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DescontoDinheiro.ForeColor = System.Drawing.Color.White;
            this.lbl_DescontoDinheiro.Location = new System.Drawing.Point(183, 80);
            this.lbl_DescontoDinheiro.Name = "lbl_DescontoDinheiro";
            this.lbl_DescontoDinheiro.Size = new System.Drawing.Size(105, 19);
            this.lbl_DescontoDinheiro.TabIndex = 315;
            this.lbl_DescontoDinheiro.Text = "Desconto - R$";
            this.lbl_DescontoDinheiro.Visible = false;
            // 
            // btn_Descontar
            // 
            this.btn_Descontar.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Descontar.ForeColor = System.Drawing.Color.Black;
            this.btn_Descontar.Image = global::CaixaFacil.Properties.Resources.Ecommerce_Discount_icon1;
            this.btn_Descontar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Descontar.Location = new System.Drawing.Point(188, 39);
            this.btn_Descontar.Name = "btn_Descontar";
            this.btn_Descontar.Size = new System.Drawing.Size(144, 35);
            this.btn_Descontar.TabIndex = 314;
            this.btn_Descontar.Text = "      Desconto - [F4]";
            this.btn_Descontar.UseVisualStyleBackColor = true;
            this.btn_Descontar.Click += new System.EventHandler(this.btn_Descontar_Click);
            // 
            // gbPagamento
            // 
            this.gbPagamento.Controls.Add(this.label3);
            this.gbPagamento.Controls.Add(this.cbFormaPagamento);
            this.gbPagamento.Controls.Add(this.txtValorCreditoAndDebito);
            this.gbPagamento.Controls.Add(this.label2);
            this.gbPagamento.Controls.Add(this.txtValorDinheiro);
            this.gbPagamento.Controls.Add(this.label1);
            this.gbPagamento.Location = new System.Drawing.Point(28, 137);
            this.gbPagamento.Name = "gbPagamento";
            this.gbPagamento.Size = new System.Drawing.Size(501, 159);
            this.gbPagamento.TabIndex = 321;
            this.gbPagamento.TabStop = false;
            this.gbPagamento.Text = "Pagamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 19);
            this.label3.TabIndex = 306;
            this.label3.Text = "Forma de pagamento";
            // 
            // cbFormaPagamento
            // 
            this.cbFormaPagamento.BackColor = System.Drawing.Color.White;
            this.cbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFormaPagamento.FormattingEnabled = true;
            this.cbFormaPagamento.Items.AddRange(new object[] {
            "Cartão de Crédito",
            "Cartão de Débito"});
            this.cbFormaPagamento.Location = new System.Drawing.Point(191, 107);
            this.cbFormaPagamento.Name = "cbFormaPagamento";
            this.cbFormaPagamento.Size = new System.Drawing.Size(185, 27);
            this.cbFormaPagamento.TabIndex = 305;
            // 
            // txtValorCreditoAndDebito
            // 
            this.txtValorCreditoAndDebito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorCreditoAndDebito.Location = new System.Drawing.Point(18, 108);
            this.txtValorCreditoAndDebito.Name = "txtValorCreditoAndDebito";
            this.txtValorCreditoAndDebito.ReadOnly = true;
            this.txtValorCreditoAndDebito.Size = new System.Drawing.Size(154, 26);
            this.txtValorCreditoAndDebito.TabIndex = 304;
            this.txtValorCreditoAndDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 19);
            this.label2.TabIndex = 303;
            this.label2.Text = "Valor Crédito | Débito";
            // 
            // txtValorDinheiro
            // 
            this.txtValorDinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorDinheiro.Location = new System.Drawing.Point(15, 45);
            this.txtValorDinheiro.Name = "txtValorDinheiro";
            this.txtValorDinheiro.Size = new System.Drawing.Size(154, 26);
            this.txtValorDinheiro.TabIndex = 302;
            this.txtValorDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorDinheiro.TextChanged += new System.EventHandler(this.txtValorDinheiro_TextChanged);
            this.txtValorDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDinheiro_KeyPress);
            this.txtValorDinheiro.Leave += new System.EventHandler(this.txtValorDinheiro_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 301;
            this.label1.Text = "Valor Dinheiro (R$)";
            // 
            // FrmVendaMista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(542, 379);
            this.Controls.Add(this.gbPagamento);
            this.Controls.Add(this.txt_DescontoPorcento);
            this.Controls.Add(this.lbl_DescontoPorcento);
            this.Controls.Add(this.txt_DescontoDinheiro);
            this.Controls.Add(this.txt_ValorTotalDesconto);
            this.Controls.Add(this.lbl_ValorDesconto);
            this.Controls.Add(this.lbl_DescontoDinheiro);
            this.Controls.Add(this.btn_Descontar);
            this.Controls.Add(this.lblFechar);
            this.Controls.Add(this.lblValorVenda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Finalizar);
            this.Controls.Add(this.btn_CancelarVendaVista);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVendaMista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venda Mista";
            this.Load += new System.EventHandler(this.FrmVendaMista_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVendaMista_KeyDown);
            this.gbPagamento.ResumeLayout(false);
            this.gbPagamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Finalizar;
        private System.Windows.Forms.Button btn_CancelarVendaVista;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblValorVenda;
        private System.Windows.Forms.Label lblFechar;
        private System.Windows.Forms.TextBox txt_DescontoPorcento;
        private System.Windows.Forms.Label lbl_DescontoPorcento;
        private System.Windows.Forms.TextBox txt_DescontoDinheiro;
        private System.Windows.Forms.TextBox txt_ValorTotalDesconto;
        private System.Windows.Forms.Label lbl_ValorDesconto;
        private System.Windows.Forms.Label lbl_DescontoDinheiro;
        private System.Windows.Forms.Button btn_Descontar;
        private System.Windows.Forms.GroupBox gbPagamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFormaPagamento;
        private System.Windows.Forms.TextBox txtValorCreditoAndDebito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorDinheiro;
        private System.Windows.Forms.Label label1;
    }
}