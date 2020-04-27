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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Finalizar = new System.Windows.Forms.Button();
            this.btn_CancelarVendaVista = new System.Windows.Forms.Button();
            this.txtValorDinheiro = new System.Windows.Forms.TextBox();
            this.txtValorCreditoAndDebito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblValorVenda = new System.Windows.Forms.Label();
            this.lblFechar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 293;
            this.label1.Text = "Valor Dinheiro (R$)";
            // 
            // btn_Finalizar
            // 
            this.btn_Finalizar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Finalizar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Finalizar.Image = global::CaixaFacil.Properties.Resources.Ok_icon;
            this.btn_Finalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Finalizar.Location = new System.Drawing.Point(324, 219);
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
            this.btn_CancelarVendaVista.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_CancelarVendaVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelarVendaVista.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarVendaVista.Image = global::CaixaFacil.Properties.Resources.Button_Cancel_icon__1_;
            this.btn_CancelarVendaVista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelarVendaVista.Location = new System.Drawing.Point(145, 219);
            this.btn_CancelarVendaVista.Name = "btn_CancelarVendaVista";
            this.btn_CancelarVendaVista.Size = new System.Drawing.Size(173, 60);
            this.btn_CancelarVendaVista.TabIndex = 294;
            this.btn_CancelarVendaVista.Text = "Cancelar - [ESC]";
            this.btn_CancelarVendaVista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CancelarVendaVista.UseVisualStyleBackColor = true;
            this.btn_CancelarVendaVista.Click += new System.EventHandler(this.btn_CancelarVendaVista_Click);
            // 
            // txtValorDinheiro
            // 
            this.txtValorDinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorDinheiro.Location = new System.Drawing.Point(55, 108);
            this.txtValorDinheiro.Name = "txtValorDinheiro";
            this.txtValorDinheiro.Size = new System.Drawing.Size(154, 26);
            this.txtValorDinheiro.TabIndex = 296;
            this.txtValorDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorCreditoAndDebito
            // 
            this.txtValorCreditoAndDebito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorCreditoAndDebito.Location = new System.Drawing.Point(55, 165);
            this.txtValorCreditoAndDebito.Name = "txtValorCreditoAndDebito";
            this.txtValorCreditoAndDebito.Size = new System.Drawing.Size(154, 26);
            this.txtValorCreditoAndDebito.TabIndex = 298;
            this.txtValorCreditoAndDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 19);
            this.label2.TabIndex = 297;
            this.label2.Text = "Valor Crédito | Débito";
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
            this.cbFormaPagamento.Location = new System.Drawing.Point(228, 164);
            this.cbFormaPagamento.Name = "cbFormaPagamento";
            this.cbFormaPagamento.Size = new System.Drawing.Size(185, 27);
            this.cbFormaPagamento.TabIndex = 299;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 19);
            this.label3.TabIndex = 300;
            this.label3.Text = "Forma de pagamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 24);
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
            this.lblValorVenda.Location = new System.Drawing.Point(55, 43);
            this.lblValorVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorVenda.Name = "lblValorVenda";
            this.lblValorVenda.Size = new System.Drawing.Size(154, 26);
            this.lblValorVenda.TabIndex = 302;
            this.lblValorVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechar
            // 
            this.lblFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechar.AutoSize = true;
            this.lblFechar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechar.Location = new System.Drawing.Point(474, 2);
            this.lblFechar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechar.Name = "lblFechar";
            this.lblFechar.Size = new System.Drawing.Size(24, 23);
            this.lblFechar.TabIndex = 303;
            this.lblFechar.Text = "X";
            this.lblFechar.Click += new System.EventHandler(this.lblFechar_Click);
            this.lblFechar.MouseEnter += new System.EventHandler(this.lblFechar_MouseEnter);
            this.lblFechar.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
            // 
            // FrmVendaMista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(500, 291);
            this.Controls.Add(this.lblFechar);
            this.Controls.Add(this.lblValorVenda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFormaPagamento);
            this.Controls.Add(this.txtValorCreditoAndDebito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValorDinheiro);
            this.Controls.Add(this.btn_Finalizar);
            this.Controls.Add(this.btn_CancelarVendaVista);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVendaMista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venda Mista";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Finalizar;
        private System.Windows.Forms.Button btn_CancelarVendaVista;
        private System.Windows.Forms.TextBox txtValorDinheiro;
        private System.Windows.Forms.TextBox txtValorCreditoAndDebito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFormaPagamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblValorVenda;
        private System.Windows.Forms.Label lblFechar;
    }
}