namespace CaixaFacil
{
    partial class FrmServico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_PrecoServico = new System.Windows.Forms.TextBox();
            this.txt_DescricaoServico = new System.Windows.Forms.TextBox();
            this.txt_CodigoServico = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.btn_Minimizar = new System.Windows.Forms.Button();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panelCabecalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_Editar);
            this.panel1.Controls.Add(this.btn_Pesquisar);
            this.panel1.Controls.Add(this.btn_Salvar);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.txt_PrecoServico);
            this.panel1.Controls.Add(this.txt_DescricaoServico);
            this.panel1.Controls.Add(this.txt_CodigoServico);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.panelCabecalho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 315);
            this.panel1.TabIndex = 0;
            // 
            // btn_Editar
            // 
            this.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar.Image = global::CaixaFacil.Properties.Resources.Text_Edit_icon__1_;
            this.btn_Editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Editar.Location = new System.Drawing.Point(406, 228);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(153, 45);
            this.btn_Editar.TabIndex = 161;
            this.btn_Editar.TabStop = false;
            this.btn_Editar.Text = "Editar - F3";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pesquisar.Image = global::CaixaFacil.Properties.Resources.magnifying_glass_icon;
            this.btn_Pesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Pesquisar.Location = new System.Drawing.Point(240, 228);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(160, 45);
            this.btn_Pesquisar.TabIndex = 160;
            this.btn_Pesquisar.TabStop = false;
            this.btn_Pesquisar.Text = "Buscar - F2";
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.btn_Pesquisar_Click);
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salvar.Image = global::CaixaFacil.Properties.Resources.Save_icon__1_1;
            this.btn_Salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Salvar.Location = new System.Drawing.Point(77, 228);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(154, 45);
            this.btn_Salvar.TabIndex = 159;
            this.btn_Salvar.TabStop = false;
            this.btn_Salvar.Text = "Salvar - F1";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label29.Location = new System.Drawing.Point(15, 91);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(115, 19);
            this.label29.TabIndex = 40;
            this.label29.Text = "Código Serviço:";
            // 
            // txt_PrecoServico
            // 
            this.txt_PrecoServico.BackColor = System.Drawing.SystemColors.Window;
            this.txt_PrecoServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PrecoServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PrecoServico.Location = new System.Drawing.Point(138, 157);
            this.txt_PrecoServico.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PrecoServico.Name = "txt_PrecoServico";
            this.txt_PrecoServico.Size = new System.Drawing.Size(91, 26);
            this.txt_PrecoServico.TabIndex = 2;
            this.txt_PrecoServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_PrecoServico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PrecoServico_KeyPress);
            this.txt_PrecoServico.Leave += new System.EventHandler(this.txt_PrecoServico_Leave);
            // 
            // txt_DescricaoServico
            // 
            this.txt_DescricaoServico.BackColor = System.Drawing.SystemColors.Window;
            this.txt_DescricaoServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DescricaoServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_DescricaoServico.Location = new System.Drawing.Point(138, 123);
            this.txt_DescricaoServico.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DescricaoServico.Name = "txt_DescricaoServico";
            this.txt_DescricaoServico.Size = new System.Drawing.Size(364, 26);
            this.txt_DescricaoServico.TabIndex = 1;
            // 
            // txt_CodigoServico
            // 
            this.txt_CodigoServico.BackColor = System.Drawing.Color.White;
            this.txt_CodigoServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CodigoServico.Location = new System.Drawing.Point(138, 89);
            this.txt_CodigoServico.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CodigoServico.Name = "txt_CodigoServico";
            this.txt_CodigoServico.ReadOnly = true;
            this.txt_CodigoServico.Size = new System.Drawing.Size(91, 26);
            this.txt_CodigoServico.TabIndex = 0;
            this.txt_CodigoServico.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(14, 159);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 19);
            this.label13.TabIndex = 39;
            this.label13.Text = "Preço do serviço:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(47, 125);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 19);
            this.label14.TabIndex = 38;
            this.label14.Text = "Descrição:";
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.Color.Plum;
            this.panelCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCabecalho.Controls.Add(this.btn_Minimizar);
            this.panelCabecalho.Controls.Add(this.btn_Fechar);
            this.panelCabecalho.Controls.Add(this.label11);
            this.panelCabecalho.Controls.Add(this.label10);
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Margin = new System.Windows.Forms.Padding(4);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(633, 68);
            this.panelCabecalho.TabIndex = 3;
            this.panelCabecalho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCabecalho_MouseDown);
            this.panelCabecalho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCabecalho_MouseMove);
            // 
            // btn_Minimizar
            // 
            this.btn_Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Minimizar.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimizar.ForeColor = System.Drawing.Color.White;
            this.btn_Minimizar.Location = new System.Drawing.Point(537, 4);
            this.btn_Minimizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Minimizar.Name = "btn_Minimizar";
            this.btn_Minimizar.Size = new System.Drawing.Size(38, 38);
            this.btn_Minimizar.TabIndex = 12;
            this.btn_Minimizar.TabStop = false;
            this.btn_Minimizar.Text = "__";
            this.btn_Minimizar.UseVisualStyleBackColor = true;
            this.btn_Minimizar.Click += new System.EventHandler(this.btn_Minimizar_Click);
            this.btn_Minimizar.MouseEnter += new System.EventHandler(this.btn_Minimizar_MouseEnter);
            this.btn_Minimizar.MouseLeave += new System.EventHandler(this.btn_Minimizar_MouseLeave);
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fechar.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fechar.ForeColor = System.Drawing.Color.White;
            this.btn_Fechar.Location = new System.Drawing.Point(583, 4);
            this.btn_Fechar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(38, 38);
            this.btn_Fechar.TabIndex = 11;
            this.btn_Fechar.TabStop = false;
            this.btn_Fechar.Text = "X";
            this.btn_Fechar.UseVisualStyleBackColor = true;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            this.btn_Fechar.MouseEnter += new System.EventHandler(this.btn_Fechar_MouseEnter);
            this.btn_Fechar.MouseLeave += new System.EventHandler(this.btn_Fechar_MouseLeave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(68, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(310, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Sistema de cadastro de serviços prestados";
            // 
            // label10
            // 
            this.label10.Image = global::CaixaFacil.Properties.Resources.Very_Basic_Services_icon;
            this.label10.Location = new System.Drawing.Point(4, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 50);
            this.label10.TabIndex = 9;
            // 
            // FrmServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 315);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Serviço";
            this.Load += new System.EventHandler(this.FrmServico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmServico_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCabecalho.ResumeLayout(false);
            this.panelCabecalho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Button btn_Minimizar;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_PrecoServico;
        private System.Windows.Forms.TextBox txt_DescricaoServico;
        private System.Windows.Forms.TextBox txt_CodigoServico;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Button btn_Salvar;
    }
}