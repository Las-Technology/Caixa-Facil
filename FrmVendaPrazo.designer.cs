namespace CaixaFacil
{
    partial class FrmVendaPrazo
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
            this.btn_FinalizarParcial = new System.Windows.Forms.Button();
            this.btn_CancelaVendaMisto = new System.Windows.Forms.Button();
            this.lbl_Fechar = new System.Windows.Forms.Label();
            this.btn_GerarRelatorio = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_ValorVendaPrazo = new System.Windows.Forms.TextBox();
            this.mask_Data = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lbl_separadorInformacao = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbl_CodigoCliente = new System.Windows.Forms.Label();
            this.lbl_NomeCliente = new System.Windows.Forms.Label();
            this.btn_PesquisarCliente = new System.Windows.Forms.Button();
            this.txt_NomeCliente = new System.Windows.Forms.TextBox();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
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
            // btn_FinalizarParcial
            // 
            this.btn_FinalizarParcial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FinalizarParcial.ForeColor = System.Drawing.Color.Black;
            this.btn_FinalizarParcial.Image = global::CaixaFacil.Properties.Resources.Ok_icon;
            this.btn_FinalizarParcial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FinalizarParcial.Location = new System.Drawing.Point(534, 152);
            this.btn_FinalizarParcial.Name = "btn_FinalizarParcial";
            this.btn_FinalizarParcial.Size = new System.Drawing.Size(164, 60);
            this.btn_FinalizarParcial.TabIndex = 21;
            this.btn_FinalizarParcial.Text = "Finalizar - [F10]";
            this.btn_FinalizarParcial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FinalizarParcial.UseVisualStyleBackColor = true;
            this.btn_FinalizarParcial.Click += new System.EventHandler(this.btn_Finalizar_Click);
            // 
            // btn_CancelaVendaMisto
            // 
            this.btn_CancelaVendaMisto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelaVendaMisto.ForeColor = System.Drawing.Color.Black;
            this.btn_CancelaVendaMisto.Image = global::CaixaFacil.Properties.Resources.Button_Cancel_icon__1_;
            this.btn_CancelaVendaMisto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelaVendaMisto.Location = new System.Drawing.Point(534, 284);
            this.btn_CancelaVendaMisto.Name = "btn_CancelaVendaMisto";
            this.btn_CancelaVendaMisto.Size = new System.Drawing.Size(164, 60);
            this.btn_CancelaVendaMisto.TabIndex = 22;
            this.btn_CancelaVendaMisto.Text = "Cancelar - [ESC]";
            this.btn_CancelaVendaMisto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CancelaVendaMisto.UseVisualStyleBackColor = true;
            this.btn_CancelaVendaMisto.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbl_Fechar
            // 
            this.lbl_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Fechar.AutoSize = true;
            this.lbl_Fechar.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fechar.ForeColor = System.Drawing.Color.White;
            this.lbl_Fechar.Location = new System.Drawing.Point(685, 5);
            this.lbl_Fechar.Name = "lbl_Fechar";
            this.lbl_Fechar.Size = new System.Drawing.Size(33, 31);
            this.lbl_Fechar.TabIndex = 17;
            this.lbl_Fechar.Text = "X";
            this.lbl_Fechar.Click += new System.EventHandler(this.lbl_Fechar_Click);
            this.lbl_Fechar.MouseEnter += new System.EventHandler(this.lbl_Fechar_MouseEnter);
            this.lbl_Fechar.MouseLeave += new System.EventHandler(this.lbl_Fechar_MouseLeave);
            // 
            // btn_GerarRelatorio
            // 
            this.btn_GerarRelatorio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GerarRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_GerarRelatorio.Location = new System.Drawing.Point(534, 218);
            this.btn_GerarRelatorio.Name = "btn_GerarRelatorio";
            this.btn_GerarRelatorio.Size = new System.Drawing.Size(164, 60);
            this.btn_GerarRelatorio.TabIndex = 23;
            this.btn_GerarRelatorio.Text = "Gerar Relatório - [F2]";
            this.btn_GerarRelatorio.UseVisualStyleBackColor = true;
            this.btn_GerarRelatorio.Click += new System.EventHandler(this.btn_GerarRelatorio_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Controls.Add(this.txt_ValorVendaPrazo);
            this.groupBox10.Controls.Add(this.mask_Data);
            this.groupBox10.Controls.Add(this.label26);
            this.groupBox10.ForeColor = System.Drawing.Color.White;
            this.groupBox10.Location = new System.Drawing.Point(30, 152);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(486, 183);
            this.groupBox10.TabIndex = 27;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Prazo";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(27, 104);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 19);
            this.label27.TabIndex = 16;
            this.label27.Text = "Valor Venda:";
            // 
            // txt_ValorVendaPrazo
            // 
            this.txt_ValorVendaPrazo.Location = new System.Drawing.Point(30, 132);
            this.txt_ValorVendaPrazo.Name = "txt_ValorVendaPrazo";
            this.txt_ValorVendaPrazo.ReadOnly = true;
            this.txt_ValorVendaPrazo.Size = new System.Drawing.Size(114, 26);
            this.txt_ValorVendaPrazo.TabIndex = 15;
            // 
            // mask_Data
            // 
            this.mask_Data.Location = new System.Drawing.Point(31, 60);
            this.mask_Data.Name = "mask_Data";
            this.mask_Data.ReadOnly = true;
            this.mask_Data.Size = new System.Drawing.Size(89, 26);
            this.mask_Data.TabIndex = 14;
            this.mask_Data.ValidatingType = typeof(System.DateTime);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(22, 35);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(147, 19);
            this.label26.TabIndex = 13;
            this.label26.Text = "Data de vencimento:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lbl_separadorInformacao);
            this.groupBox8.Controls.Add(this.label23);
            this.groupBox8.Controls.Add(this.label24);
            this.groupBox8.Controls.Add(this.label25);
            this.groupBox8.Controls.Add(this.lbl_CodigoCliente);
            this.groupBox8.Controls.Add(this.lbl_NomeCliente);
            this.groupBox8.Location = new System.Drawing.Point(30, 78);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(486, 68);
            this.groupBox8.TabIndex = 26;
            this.groupBox8.TabStop = false;
            // 
            // lbl_separadorInformacao
            // 
            this.lbl_separadorInformacao.AutoSize = true;
            this.lbl_separadorInformacao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_separadorInformacao.ForeColor = System.Drawing.Color.White;
            this.lbl_separadorInformacao.Location = new System.Drawing.Point(59, 37);
            this.lbl_separadorInformacao.Name = "lbl_separadorInformacao";
            this.lbl_separadorInformacao.Size = new System.Drawing.Size(12, 19);
            this.lbl_separadorInformacao.TabIndex = 13;
            this.lbl_separadorInformacao.Text = "|";
            this.lbl_separadorInformacao.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(59, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(12, 19);
            this.label23.TabIndex = 12;
            this.label23.Text = "|";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(6, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 19);
            this.label24.TabIndex = 11;
            this.label24.Text = "Código";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(71, 14);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 19);
            this.label25.TabIndex = 10;
            this.label25.Text = "Nome";
            // 
            // lbl_CodigoCliente
            // 
            this.lbl_CodigoCliente.AutoSize = true;
            this.lbl_CodigoCliente.ForeColor = System.Drawing.Color.White;
            this.lbl_CodigoCliente.Location = new System.Drawing.Point(6, 37);
            this.lbl_CodigoCliente.Name = "lbl_CodigoCliente";
            this.lbl_CodigoCliente.Size = new System.Drawing.Size(0, 19);
            this.lbl_CodigoCliente.TabIndex = 9;
            // 
            // lbl_NomeCliente
            // 
            this.lbl_NomeCliente.AutoSize = true;
            this.lbl_NomeCliente.ForeColor = System.Drawing.Color.White;
            this.lbl_NomeCliente.Location = new System.Drawing.Point(74, 37);
            this.lbl_NomeCliente.Name = "lbl_NomeCliente";
            this.lbl_NomeCliente.Size = new System.Drawing.Size(0, 19);
            this.lbl_NomeCliente.TabIndex = 8;
            // 
            // btn_PesquisarCliente
            // 
            this.btn_PesquisarCliente.Image = global::CaixaFacil.Properties.Resources.magnifying_glass_icon;
            this.btn_PesquisarCliente.Location = new System.Drawing.Point(422, 34);
            this.btn_PesquisarCliente.Name = "btn_PesquisarCliente";
            this.btn_PesquisarCliente.Size = new System.Drawing.Size(105, 43);
            this.btn_PesquisarCliente.TabIndex = 25;
            this.btn_PesquisarCliente.UseVisualStyleBackColor = true;
            this.btn_PesquisarCliente.Click += new System.EventHandler(this.btn_PesquisarCliente_Click);
            // 
            // txt_NomeCliente
            // 
            this.txt_NomeCliente.Location = new System.Drawing.Point(30, 43);
            this.txt_NomeCliente.Name = "txt_NomeCliente";
            this.txt_NomeCliente.ReadOnly = true;
            this.txt_NomeCliente.Size = new System.Drawing.Size(386, 26);
            this.txt_NomeCliente.TabIndex = 24;
            // 
            // FrmVendaPrazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(728, 366);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btn_PesquisarCliente);
            this.Controls.Add(this.txt_NomeCliente);
            this.Controls.Add(this.btn_GerarRelatorio);
            this.Controls.Add(this.btn_FinalizarParcial);
            this.Controls.Add(this.btn_CancelaVendaMisto);
            this.Controls.Add(this.lbl_Fechar);
            this.Controls.Add(this.lbl_FecharParcelamento);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVendaPrazo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVendaParcelas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVendaPrazo_KeyDown);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_FecharParcelamento;
        private System.Windows.Forms.Button btn_FinalizarParcial;
        private System.Windows.Forms.Button btn_CancelaVendaMisto;
        private System.Windows.Forms.Label lbl_Fechar;
        private System.Windows.Forms.Button btn_GerarRelatorio;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_ValorVendaPrazo;
        private System.Windows.Forms.MaskedTextBox mask_Data;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lbl_separadorInformacao;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbl_CodigoCliente;
        private System.Windows.Forms.Label lbl_NomeCliente;
        private System.Windows.Forms.Button btn_PesquisarCliente;
        private System.Windows.Forms.TextBox txt_NomeCliente;
    }
}