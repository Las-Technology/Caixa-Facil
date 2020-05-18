﻿namespace CaixaFacil
{
    partial class FrmBaixarPagamentoMisto
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
            this.panelPagamentoParcial = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoPagamento = new System.Windows.Forms.ComboBox();
            this.lbl_Fechar = new System.Windows.Forms.Label();
            this.lbl_Restante = new System.Windows.Forms.Label();
            this.txt_ValorRestante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ValorConta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CodigoCliente = new System.Windows.Forms.TextBox();
            this.btn_Baixa = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ValorPago = new System.Windows.Forms.TextBox();
            this.panelPagamentoParcial.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPagamentoParcial
            // 
            this.panelPagamentoParcial.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panelPagamentoParcial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPagamentoParcial.Controls.Add(this.label2);
            this.panelPagamentoParcial.Controls.Add(this.cbTipoPagamento);
            this.panelPagamentoParcial.Controls.Add(this.lbl_Fechar);
            this.panelPagamentoParcial.Controls.Add(this.lbl_Restante);
            this.panelPagamentoParcial.Controls.Add(this.txt_ValorRestante);
            this.panelPagamentoParcial.Controls.Add(this.label7);
            this.panelPagamentoParcial.Controls.Add(this.txt_ValorConta);
            this.panelPagamentoParcial.Controls.Add(this.label5);
            this.panelPagamentoParcial.Controls.Add(this.txt_Nome);
            this.panelPagamentoParcial.Controls.Add(this.label4);
            this.panelPagamentoParcial.Controls.Add(this.txt_CodigoCliente);
            this.panelPagamentoParcial.Controls.Add(this.btn_Baixa);
            this.panelPagamentoParcial.Controls.Add(this.btn_Cancelar);
            this.panelPagamentoParcial.Controls.Add(this.label1);
            this.panelPagamentoParcial.Controls.Add(this.txt_ValorPago);
            this.panelPagamentoParcial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPagamentoParcial.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.panelPagamentoParcial.Location = new System.Drawing.Point(0, 0);
            this.panelPagamentoParcial.Name = "panelPagamentoParcial";
            this.panelPagamentoParcial.Size = new System.Drawing.Size(629, 229);
            this.panelPagamentoParcial.TabIndex = 0;
            this.panelPagamentoParcial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPagamentoParcial_MouseDown);
            this.panelPagamentoParcial.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPagamentoParcial_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(426, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 19);
            this.label2.TabIndex = 70;
            this.label2.Text = "Forma de abatimento:";
            // 
            // cbFormaAbatimento
            // 
            this.cbTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTipoPagamento.FormattingEnabled = true;
            this.cbTipoPagamento.Items.AddRange(new object[] {
            "CRÉDITO",
            "DÉBITO",
            "DINHEIRO"});
            this.cbTipoPagamento.Location = new System.Drawing.Point(430, 100);
            this.cbTipoPagamento.Name = "cbFormaAbatimento";
            this.cbTipoPagamento.Size = new System.Drawing.Size(174, 27);
            this.cbTipoPagamento.TabIndex = 69;
            // 
            // lbl_Fechar
            // 
            this.lbl_Fechar.AutoSize = true;
            this.lbl_Fechar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fechar.ForeColor = System.Drawing.Color.White;
            this.lbl_Fechar.Location = new System.Drawing.Point(604, 0);
            this.lbl_Fechar.Name = "lbl_Fechar";
            this.lbl_Fechar.Size = new System.Drawing.Size(20, 19);
            this.lbl_Fechar.TabIndex = 66;
            this.lbl_Fechar.Text = "X";
            this.lbl_Fechar.Click += new System.EventHandler(this.lbl_Fechar_Click);
            this.lbl_Fechar.MouseEnter += new System.EventHandler(this.lbl_Fechar_MouseEnter);
            this.lbl_Fechar.MouseLeave += new System.EventHandler(this.lbl_Fechar_MouseLeave);
            // 
            // lbl_Restante
            // 
            this.lbl_Restante.AutoSize = true;
            this.lbl_Restante.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Restante.ForeColor = System.Drawing.Color.White;
            this.lbl_Restante.Location = new System.Drawing.Point(297, 77);
            this.lbl_Restante.Name = "lbl_Restante";
            this.lbl_Restante.Size = new System.Drawing.Size(75, 19);
            this.lbl_Restante.TabIndex = 65;
            this.lbl_Restante.Text = "Restante:";
            // 
            // txt_ValorRestante
            // 
            this.txt_ValorRestante.Location = new System.Drawing.Point(301, 100);
            this.txt_ValorRestante.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ValorRestante.Name = "txt_ValorRestante";
            this.txt_ValorRestante.ReadOnly = true;
            this.txt_ValorRestante.Size = new System.Drawing.Size(122, 26);
            this.txt_ValorRestante.TabIndex = 64;
            this.txt_ValorRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(164, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 19);
            this.label7.TabIndex = 58;
            this.label7.Text = "Valor na conta:";
            // 
            // txt_ValorConta
            // 
            this.txt_ValorConta.Location = new System.Drawing.Point(171, 100);
            this.txt_ValorConta.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ValorConta.Name = "txt_ValorConta";
            this.txt_ValorConta.ReadOnly = true;
            this.txt_ValorConta.Size = new System.Drawing.Size(122, 26);
            this.txt_ValorConta.TabIndex = 57;
            this.txt_ValorConta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(145, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 54;
            this.label5.Text = "Nome:";
            // 
            // txt_Nome
            // 
            this.txt_Nome.Location = new System.Drawing.Point(149, 35);
            this.txt_Nome.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.ReadOnly = true;
            this.txt_Nome.Size = new System.Drawing.Size(430, 26);
            this.txt_Nome.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 52;
            this.label4.Text = "Cód Cliente:";
            // 
            // txt_CodigoCliente
            // 
            this.txt_CodigoCliente.Location = new System.Drawing.Point(12, 35);
            this.txt_CodigoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CodigoCliente.Name = "txt_CodigoCliente";
            this.txt_CodigoCliente.ReadOnly = true;
            this.txt_CodigoCliente.Size = new System.Drawing.Size(121, 26);
            this.txt_CodigoCliente.TabIndex = 51;
            this.txt_CodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Baixa
            // 
            this.btn_Baixa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Baixa.ForeColor = System.Drawing.Color.Black;
            this.btn_Baixa.Image = global::CaixaFacil.Properties.Resources.Ok_icon;
            this.btn_Baixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Baixa.Location = new System.Drawing.Point(301, 146);
            this.btn_Baixa.Name = "btn_Baixa";
            this.btn_Baixa.Size = new System.Drawing.Size(164, 60);
            this.btn_Baixa.TabIndex = 49;
            this.btn_Baixa.Text = "Dar Baixa- [F10]";
            this.btn_Baixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Baixa.UseVisualStyleBackColor = true;
            this.btn_Baixa.Click += new System.EventHandler(this.btn_Baixa_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancelar.Image = global::CaixaFacil.Properties.Resources.Button_Cancel_icon__1_;
            this.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancelar.Location = new System.Drawing.Point(139, 146);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(162, 60);
            this.btn_Cancelar.TabIndex = 50;
            this.btn_Cancelar.Text = "Cancelar - [ESC]";
            this.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 19);
            this.label1.TabIndex = 45;
            this.label1.Text = "Valor de abatimento:";
            // 
            // txt_ValorPago
            // 
            this.txt_ValorPago.Location = new System.Drawing.Point(12, 100);
            this.txt_ValorPago.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ValorPago.Name = "txt_ValorPago";
            this.txt_ValorPago.Size = new System.Drawing.Size(148, 26);
            this.txt_ValorPago.TabIndex = 44;
            this.txt_ValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ValorPago_KeyPress);
            this.txt_ValorPago.Leave += new System.EventHandler(this.txt_ValorPago_Leave);
            // 
            // FrmBaixarPagamentoMisto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 229);
            this.Controls.Add(this.panelPagamentoParcial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmBaixarPagamentoMisto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixar Pagamento Misto";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBaixarPagamentoParcial_KeyDown);
            this.panelPagamentoParcial.ResumeLayout(false);
            this.panelPagamentoParcial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPagamentoParcial;
        private System.Windows.Forms.Label lbl_Restante;
        private System.Windows.Forms.TextBox txt_ValorRestante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ValorConta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_CodigoCliente;
        private System.Windows.Forms.Button btn_Baixa;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ValorPago;
        private System.Windows.Forms.Label lbl_Fechar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoPagamento;
    }
}