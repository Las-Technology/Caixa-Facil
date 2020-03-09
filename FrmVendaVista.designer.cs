using System;

namespace CaixaFacil
{
    partial class FrmVendaVista
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
            this.lbl_Fechar = new System.Windows.Forms.Label();
            this.btn_ImprimiCupom = new System.Windows.Forms.Button();
            this.txt_DescontoPorcento = new System.Windows.Forms.TextBox();
            this.lbl_DescontoPorcento = new System.Windows.Forms.Label();
            this.btn_Recibo = new System.Windows.Forms.Button();
            this.txt_DescontoDinheiro = new System.Windows.Forms.TextBox();
            this.txt_ValorDesconto = new System.Windows.Forms.TextBox();
            this.lbl_ValorDesconto = new System.Windows.Forms.Label();
            this.lbl_Cliente = new System.Windows.Forms.Label();
            this.lbl_ApresentacaoCliente = new System.Windows.Forms.Label();
            this.btn_VincularCliente = new System.Windows.Forms.Button();
            this.txt_Troco = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_DescontoDinheiro = new System.Windows.Forms.Label();
            this.btn_Desconto = new System.Windows.Forms.Button();
            this.lbl_ValorTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ValorPago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Finalizar = new System.Windows.Forms.Button();
            this.btn_CancelarVendaVista = new System.Windows.Forms.Button();
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
            // lbl_Fechar
            // 
            this.lbl_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Fechar.AutoSize = true;
            this.lbl_Fechar.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fechar.ForeColor = System.Drawing.Color.White;
            this.lbl_Fechar.Location = new System.Drawing.Point(814, 5);
            this.lbl_Fechar.Name = "lbl_Fechar";
            this.lbl_Fechar.Size = new System.Drawing.Size(33, 31);
            this.lbl_Fechar.TabIndex = 17;
            this.lbl_Fechar.Text = "X";
            this.lbl_Fechar.Click += new System.EventHandler(this.lbl_Fechar_Click);
            this.lbl_Fechar.MouseEnter += new System.EventHandler(this.lbl_Fechar_MouseEnter);
            this.lbl_Fechar.MouseLeave += new System.EventHandler(this.lbl_Fechar_MouseLeave);
            // 
            // btn_ImprimiCupom
            // 
            this.btn_ImprimiCupom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_ImprimiCupom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ImprimiCupom.Image = global::CaixaFacil.Properties.Resources.printer_icon;
            this.btn_ImprimiCupom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ImprimiCupom.Location = new System.Drawing.Point(448, 266);
            this.btn_ImprimiCupom.Name = "btn_ImprimiCupom";
            this.btn_ImprimiCupom.Size = new System.Drawing.Size(235, 60);
            this.btn_ImprimiCupom.TabIndex = 308;
            this.btn_ImprimiCupom.Text = "Imprimir Cupom N.F- [F12]";
            this.btn_ImprimiCupom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ImprimiCupom.UseVisualStyleBackColor = true;
            // 
            // txt_DescontoPorcento
            // 
            this.txt_DescontoPorcento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescontoPorcento.Location = new System.Drawing.Point(186, 118);
            this.txt_DescontoPorcento.Name = "txt_DescontoPorcento";
            this.txt_DescontoPorcento.Size = new System.Drawing.Size(147, 26);
            this.txt_DescontoPorcento.TabIndex = 303;
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
            this.lbl_DescontoPorcento.Location = new System.Drawing.Point(187, 93);
            this.lbl_DescontoPorcento.Name = "lbl_DescontoPorcento";
            this.lbl_DescontoPorcento.Size = new System.Drawing.Size(97, 19);
            this.lbl_DescontoPorcento.TabIndex = 306;
            this.lbl_DescontoPorcento.Text = "Desconto -%";
            this.lbl_DescontoPorcento.Visible = false;
            // 
            // btn_Recibo
            // 
            this.btn_Recibo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Recibo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Recibo.Image = global::CaixaFacil.Properties.Resources.printer_icon;
            this.btn_Recibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Recibo.Location = new System.Drawing.Point(179, 267);
            this.btn_Recibo.Name = "btn_Recibo";
            this.btn_Recibo.Size = new System.Drawing.Size(269, 60);
            this.btn_Recibo.TabIndex = 305;
            this.btn_Recibo.Text = "Imprimir N. Promissória- [F11]";
            this.btn_Recibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Recibo.UseVisualStyleBackColor = true;
            // 
            // txt_DescontoDinheiro
            // 
            this.txt_DescontoDinheiro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DescontoDinheiro.Location = new System.Drawing.Point(342, 118);
            this.txt_DescontoDinheiro.Name = "txt_DescontoDinheiro";
            this.txt_DescontoDinheiro.Size = new System.Drawing.Size(147, 26);
            this.txt_DescontoDinheiro.TabIndex = 304;
            this.txt_DescontoDinheiro.Text = "0,00";
            this.txt_DescontoDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_DescontoDinheiro.Visible = false;
            this.txt_DescontoDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DescontoDinheiro_KeyPress);
            this.txt_DescontoDinheiro.Leave += new System.EventHandler(this.txt_DescontoDinheiro_Leave);
            // 
            // txt_ValorDesconto
            // 
            this.txt_ValorDesconto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorDesconto.Location = new System.Drawing.Point(507, 118);
            this.txt_ValorDesconto.Name = "txt_ValorDesconto";
            this.txt_ValorDesconto.ReadOnly = true;
            this.txt_ValorDesconto.Size = new System.Drawing.Size(144, 26);
            this.txt_ValorDesconto.TabIndex = 307;
            this.txt_ValorDesconto.Text = "0,00";
            this.txt_ValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ValorDesconto.Visible = false;
            this.txt_ValorDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ValorDesconto_KeyPress);
            // 
            // lbl_ValorDesconto
            // 
            this.lbl_ValorDesconto.AutoSize = true;
            this.lbl_ValorDesconto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorDesconto.ForeColor = System.Drawing.Color.White;
            this.lbl_ValorDesconto.Location = new System.Drawing.Point(491, 96);
            this.lbl_ValorDesconto.Name = "lbl_ValorDesconto";
            this.lbl_ValorDesconto.Size = new System.Drawing.Size(172, 19);
            this.lbl_ValorDesconto.TabIndex = 302;
            this.lbl_ValorDesconto.Text = "Valor com desconto - R$";
            this.lbl_ValorDesconto.Visible = false;
            // 
            // lbl_Cliente
            // 
            this.lbl_Cliente.AutoSize = true;
            this.lbl_Cliente.ForeColor = System.Drawing.Color.White;
            this.lbl_Cliente.Location = new System.Drawing.Point(233, 235);
            this.lbl_Cliente.Name = "lbl_Cliente";
            this.lbl_Cliente.Size = new System.Drawing.Size(0, 19);
            this.lbl_Cliente.TabIndex = 301;
            this.lbl_Cliente.Visible = false;
            // 
            // lbl_ApresentacaoCliente
            // 
            this.lbl_ApresentacaoCliente.AutoSize = true;
            this.lbl_ApresentacaoCliente.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ApresentacaoCliente.ForeColor = System.Drawing.Color.White;
            this.lbl_ApresentacaoCliente.Location = new System.Drawing.Point(230, 214);
            this.lbl_ApresentacaoCliente.Name = "lbl_ApresentacaoCliente";
            this.lbl_ApresentacaoCliente.Size = new System.Drawing.Size(62, 19);
            this.lbl_ApresentacaoCliente.TabIndex = 300;
            this.lbl_ApresentacaoCliente.Text = "Cliente:";
            this.lbl_ApresentacaoCliente.Visible = false;
            // 
            // btn_VincularCliente
            // 
            this.btn_VincularCliente.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VincularCliente.Image = global::CaixaFacil.Properties.Resources.User_Group_icon__1_1;
            this.btn_VincularCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VincularCliente.Location = new System.Drawing.Point(25, 206);
            this.btn_VincularCliente.Name = "btn_VincularCliente";
            this.btn_VincularCliente.Size = new System.Drawing.Size(199, 48);
            this.btn_VincularCliente.TabIndex = 299;
            this.btn_VincularCliente.Text = "Vincular Cliente - F5";
            this.btn_VincularCliente.UseVisualStyleBackColor = true;
            this.btn_VincularCliente.Click += new System.EventHandler(this.btn_VincularCliente_Click);
            // 
            // txt_Troco
            // 
            this.txt_Troco.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Troco.Location = new System.Drawing.Point(25, 174);
            this.txt_Troco.Name = "txt_Troco";
            this.txt_Troco.ReadOnly = true;
            this.txt_Troco.Size = new System.Drawing.Size(144, 26);
            this.txt_Troco.TabIndex = 298;
            this.txt_Troco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Troco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Troco_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(21, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 19);
            this.label12.TabIndex = 297;
            this.label12.Text = "Troco ao Cliente:";
            // 
            // lbl_DescontoDinheiro
            // 
            this.lbl_DescontoDinheiro.AutoSize = true;
            this.lbl_DescontoDinheiro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DescontoDinheiro.ForeColor = System.Drawing.Color.White;
            this.lbl_DescontoDinheiro.Location = new System.Drawing.Point(343, 93);
            this.lbl_DescontoDinheiro.Name = "lbl_DescontoDinheiro";
            this.lbl_DescontoDinheiro.Size = new System.Drawing.Size(105, 19);
            this.lbl_DescontoDinheiro.TabIndex = 296;
            this.lbl_DescontoDinheiro.Text = "Desconto - R$";
            this.lbl_DescontoDinheiro.Visible = false;
            // 
            // btn_Desconto
            // 
            this.btn_Desconto.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Desconto.Image = global::CaixaFacil.Properties.Resources.Ecommerce_Discount_icon1;
            this.btn_Desconto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Desconto.Location = new System.Drawing.Point(25, 99);
            this.btn_Desconto.Name = "btn_Desconto";
            this.btn_Desconto.Size = new System.Drawing.Size(144, 48);
            this.btn_Desconto.TabIndex = 295;
            this.btn_Desconto.Text = "      Desconto - [F4]";
            this.btn_Desconto.UseVisualStyleBackColor = true;
            this.btn_Desconto.Click += new System.EventHandler(this.btn_Desconto_Click);
            // 
            // lbl_ValorTotal
            // 
            this.lbl_ValorTotal.AutoSize = true;
            this.lbl_ValorTotal.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorTotal.ForeColor = System.Drawing.Color.White;
            this.lbl_ValorTotal.Location = new System.Drawing.Point(231, 62);
            this.lbl_ValorTotal.Name = "lbl_ValorTotal";
            this.lbl_ValorTotal.Size = new System.Drawing.Size(0, 31);
            this.lbl_ValorTotal.TabIndex = 294;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(222, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 19);
            this.label10.TabIndex = 293;
            this.label10.Text = "Valor Total da Venda:";
            // 
            // txt_ValorPago
            // 
            this.txt_ValorPago.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ValorPago.Location = new System.Drawing.Point(25, 67);
            this.txt_ValorPago.Name = "txt_ValorPago";
            this.txt_ValorPago.Size = new System.Drawing.Size(144, 26);
            this.txt_ValorPago.TabIndex = 292;
            this.txt_ValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ValorPago_KeyPress);
            this.txt_ValorPago.Leave += new System.EventHandler(this.txt_ValorPago_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(21, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 19);
            this.label8.TabIndex = 291;
            this.label8.Text = "Valor pago - R$ [F]";
            // 
            // btn_Finalizar
            // 
            this.btn_Finalizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Finalizar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Finalizar.Image = global::CaixaFacil.Properties.Resources.Ok_icon;
            this.btn_Finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Finalizar.Location = new System.Drawing.Point(683, 266);
            this.btn_Finalizar.Name = "btn_Finalizar";
            this.btn_Finalizar.Size = new System.Drawing.Size(164, 60);
            this.btn_Finalizar.TabIndex = 290;
            this.btn_Finalizar.Text = "Finalizar - [F10]";
            this.btn_Finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Finalizar.UseVisualStyleBackColor = true;
            this.btn_Finalizar.Click += new System.EventHandler(this.btn_Finalizar_Click);
            // 
            // btn_CancelarVendaVista
            // 
            this.btn_CancelarVendaVista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_CancelarVendaVista.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarVendaVista.Image = global::CaixaFacil.Properties.Resources.Button_Cancel_icon__1_;
            this.btn_CancelarVendaVista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelarVendaVista.Location = new System.Drawing.Point(15, 266);
            this.btn_CancelarVendaVista.Name = "btn_CancelarVendaVista";
            this.btn_CancelarVendaVista.Size = new System.Drawing.Size(162, 60);
            this.btn_CancelarVendaVista.TabIndex = 289;
            this.btn_CancelarVendaVista.Text = "Cancelar - [ESC]";
            this.btn_CancelarVendaVista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CancelarVendaVista.UseVisualStyleBackColor = true;
            this.btn_CancelarVendaVista.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // FrmVendaVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(857, 338);
            this.Controls.Add(this.btn_ImprimiCupom);
            this.Controls.Add(this.txt_DescontoPorcento);
            this.Controls.Add(this.lbl_DescontoPorcento);
            this.Controls.Add(this.btn_Recibo);
            this.Controls.Add(this.txt_DescontoDinheiro);
            this.Controls.Add(this.txt_ValorDesconto);
            this.Controls.Add(this.lbl_ValorDesconto);
            this.Controls.Add(this.lbl_Cliente);
            this.Controls.Add(this.lbl_ApresentacaoCliente);
            this.Controls.Add(this.btn_VincularCliente);
            this.Controls.Add(this.txt_Troco);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_DescontoDinheiro);
            this.Controls.Add(this.btn_Desconto);
            this.Controls.Add(this.lbl_ValorTotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_ValorPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_Finalizar);
            this.Controls.Add(this.btn_CancelarVendaVista);
            this.Controls.Add(this.lbl_Fechar);
            this.Controls.Add(this.lbl_FecharParcelamento);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVendaVista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVendaParcelas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_FecharParcelamento;
        private System.Windows.Forms.Label lbl_Fechar;
        private System.Windows.Forms.Button btn_ImprimiCupom;
        private System.Windows.Forms.TextBox txt_DescontoPorcento;
        private System.Windows.Forms.Label lbl_DescontoPorcento;
        private System.Windows.Forms.Button btn_Recibo;
        private System.Windows.Forms.TextBox txt_DescontoDinheiro;
        private System.Windows.Forms.TextBox txt_ValorDesconto;
        private System.Windows.Forms.Label lbl_ValorDesconto;
        private System.Windows.Forms.Label lbl_Cliente;
        private System.Windows.Forms.Label lbl_ApresentacaoCliente;
        private System.Windows.Forms.Button btn_VincularCliente;
        private System.Windows.Forms.TextBox txt_Troco;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_DescontoDinheiro;
        private System.Windows.Forms.Button btn_Desconto;
        private System.Windows.Forms.Label lbl_ValorTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ValorPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Finalizar;
        private System.Windows.Forms.Button btn_CancelarVendaVista;
    }
}