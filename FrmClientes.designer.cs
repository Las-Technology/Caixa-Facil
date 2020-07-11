namespace CaixaFacil
{
    partial class FrmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.btn_Minimizar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.dateNascimento = new System.Windows.Forms.DateTimePicker();
            this.btn_BuscarCep = new System.Windows.Forms.Button();
            this.mask_RG = new System.Windows.Forms.MaskedTextBox();
            this.txt_Numero = new System.Windows.Forms.TextBox();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.txt_Cidade = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Bairro = new System.Windows.Forms.TextBox();
            this.txt_Endereco = new System.Windows.Forms.TextBox();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.mask_Celular = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.mask_Telefone = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_Estado = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mask_Cep = new System.Windows.Forms.MaskedTextBox();
            this.mask_CPF = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_Fechar);
            this.panel1.Controls.Add(this.btn_Minimizar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 539);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label1
            // 
            this.label1.Image = global::CaixaFacil.Properties.Resources.User_Clients_icon;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 75);
            this.label1.TabIndex = 62;
            this.label1.Text = "     ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(105, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 19);
            this.label2.TabIndex = 61;
            this.label2.Text = "Sistema Controle de Clientes";
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Fechar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Fechar.ForeColor = System.Drawing.Color.White;
            this.btn_Fechar.Location = new System.Drawing.Point(627, 11);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(38, 38);
            this.btn_Fechar.TabIndex = 59;
            this.btn_Fechar.TabStop = false;
            this.btn_Fechar.Text = "X";
            this.toolTip1.SetToolTip(this.btn_Fechar, "Fechar");
            this.btn_Fechar.UseVisualStyleBackColor = false;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            this.btn_Fechar.MouseEnter += new System.EventHandler(this.btn_Fechar_MouseEnter);
            this.btn_Fechar.MouseLeave += new System.EventHandler(this.btn_Fechar_MouseLeave);
            // 
            // btn_Minimizar
            // 
            this.btn_Minimizar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Minimizar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimizar.ForeColor = System.Drawing.Color.White;
            this.btn_Minimizar.Location = new System.Drawing.Point(587, 11);
            this.btn_Minimizar.Name = "btn_Minimizar";
            this.btn_Minimizar.Size = new System.Drawing.Size(38, 38);
            this.btn_Minimizar.TabIndex = 58;
            this.btn_Minimizar.TabStop = false;
            this.btn_Minimizar.Text = "__";
            this.toolTip1.SetToolTip(this.btn_Minimizar, "Minimizar");
            this.btn_Minimizar.UseVisualStyleBackColor = false;
            this.btn_Minimizar.Click += new System.EventHandler(this.btn_Minimizar_Click);
            this.btn_Minimizar.MouseEnter += new System.EventHandler(this.btn_Minimizar_MouseEnter);
            this.btn_Minimizar.MouseLeave += new System.EventHandler(this.btn_Minimizar_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_Excluir);
            this.panel2.Controls.Add(this.btn_Editar);
            this.panel2.Controls.Add(this.btn_Pesquisar);
            this.panel2.Controls.Add(this.btn_Salvar);
            this.panel2.Controls.Add(this.dateNascimento);
            this.panel2.Controls.Add(this.btn_BuscarCep);
            this.panel2.Controls.Add(this.mask_RG);
            this.panel2.Controls.Add(this.txt_Numero);
            this.panel2.Controls.Add(this.txt_Codigo);
            this.panel2.Controls.Add(this.txt_Cidade);
            this.panel2.Controls.Add(this.txt_Email);
            this.panel2.Controls.Add(this.txt_Bairro);
            this.panel2.Controls.Add(this.txt_Endereco);
            this.panel2.Controls.Add(this.txt_Nome);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.mask_Celular);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.mask_Telefone);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cb_Estado);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.mask_Cep);
            this.panel2.Controls.Add(this.mask_CPF);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(-1, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 466);
            this.panel2.TabIndex = 0;
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Excluir.Image = global::CaixaFacil.Properties.Resources.Button_Delete_icon;
            this.btn_Excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Excluir.Location = new System.Drawing.Point(505, 403);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(162, 45);
            this.btn_Excluir.TabIndex = 18;
            this.btn_Excluir.TabStop = false;
            this.btn_Excluir.Text = "Excluir - F5";
            this.btn_Excluir.UseVisualStyleBackColor = true;
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar.Image = global::CaixaFacil.Properties.Resources.Text_Edit_icon__1_;
            this.btn_Editar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Editar.Location = new System.Drawing.Point(346, 403);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(153, 45);
            this.btn_Editar.TabIndex = 17;
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
            this.btn_Pesquisar.Location = new System.Drawing.Point(180, 403);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(160, 45);
            this.btn_Pesquisar.TabIndex = 16;
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
            this.btn_Salvar.Location = new System.Drawing.Point(17, 403);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(154, 45);
            this.btn_Salvar.TabIndex = 15;
            this.btn_Salvar.TabStop = false;
            this.btn_Salvar.Text = "Salvar - F1";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // dateNascimento
            // 
            this.dateNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNascimento.Location = new System.Drawing.Point(523, 112);
            this.dateNascimento.Name = "dateNascimento";
            this.dateNascimento.Size = new System.Drawing.Size(103, 26);
            this.dateNascimento.TabIndex = 4;
            this.dateNascimento.ValueChanged += new System.EventHandler(this.dateNascimento_ValueChanged);
            this.dateNascimento.Leave += new System.EventHandler(this.dateNascimento_Leave);
            // 
            // btn_BuscarCep
            // 
            this.btn_BuscarCep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_BuscarCep.Location = new System.Drawing.Point(167, 154);
            this.btn_BuscarCep.Name = "btn_BuscarCep";
            this.btn_BuscarCep.Size = new System.Drawing.Size(95, 39);
            this.btn_BuscarCep.TabIndex = 6;
            this.btn_BuscarCep.Text = "Buscar CEP";
            this.btn_BuscarCep.UseVisualStyleBackColor = true;
            this.btn_BuscarCep.Click += new System.EventHandler(this.btn_BuscarCep_Click);
            // 
            // mask_RG
            // 
            this.mask_RG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mask_RG.Location = new System.Drawing.Point(128, 116);
            this.mask_RG.Mask = "00,000,000";
            this.mask_RG.Name = "mask_RG";
            this.mask_RG.Size = new System.Drawing.Size(81, 26);
            this.mask_RG.TabIndex = 2;
            this.mask_RG.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_RG_MaskInputRejected);
            // 
            // txt_Numero
            // 
            this.txt_Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Numero.Location = new System.Drawing.Point(540, 209);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(100, 26);
            this.txt_Numero.TabIndex = 9;
            this.txt_Numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Numero.TextChanged += new System.EventHandler(this.txt_Numero_TextChanged);
            this.txt_Numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Numero_KeyPress);
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.BackColor = System.Drawing.Color.White;
            this.txt_Codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Codigo.ForeColor = System.Drawing.Color.Black;
            this.txt_Codigo.Location = new System.Drawing.Point(76, 16);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.ReadOnly = true;
            this.txt_Codigo.Size = new System.Drawing.Size(91, 26);
            this.txt_Codigo.TabIndex = 0;
            this.txt_Codigo.TabStop = false;
            // 
            // txt_Cidade
            // 
            this.txt_Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Cidade.ForeColor = System.Drawing.Color.Black;
            this.txt_Cidade.Location = new System.Drawing.Point(76, 258);
            this.txt_Cidade.MaxLength = 100;
            this.txt_Cidade.Name = "txt_Cidade";
            this.txt_Cidade.Size = new System.Drawing.Size(362, 26);
            this.txt_Cidade.TabIndex = 10;
            this.txt_Cidade.TextChanged += new System.EventHandler(this.txt_Cidade_TextChanged);
            // 
            // txt_Email
            // 
            this.txt_Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Email.ForeColor = System.Drawing.Color.Black;
            this.txt_Email.Location = new System.Drawing.Point(68, 352);
            this.txt_Email.MaxLength = 100;
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(390, 26);
            this.txt_Email.TabIndex = 14;
            this.txt_Email.TextChanged += new System.EventHandler(this.txt_Email_TextChanged);
            // 
            // txt_Bairro
            // 
            this.txt_Bairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Bairro.ForeColor = System.Drawing.Color.Black;
            this.txt_Bairro.Location = new System.Drawing.Point(331, 159);
            this.txt_Bairro.MaxLength = 50;
            this.txt_Bairro.Name = "txt_Bairro";
            this.txt_Bairro.Size = new System.Drawing.Size(282, 26);
            this.txt_Bairro.TabIndex = 7;
            this.txt_Bairro.TextChanged += new System.EventHandler(this.txt_Bairro_TextChanged);
            // 
            // txt_Endereco
            // 
            this.txt_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Endereco.ForeColor = System.Drawing.Color.Black;
            this.txt_Endereco.Location = new System.Drawing.Point(91, 209);
            this.txt_Endereco.Name = "txt_Endereco";
            this.txt_Endereco.Size = new System.Drawing.Size(362, 26);
            this.txt_Endereco.TabIndex = 8;
            this.txt_Endereco.TextChanged += new System.EventHandler(this.txt_Endereco_TextChanged);
            // 
            // txt_Nome
            // 
            this.txt_Nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Nome.ForeColor = System.Drawing.Color.Black;
            this.txt_Nome.Location = new System.Drawing.Point(76, 58);
            this.txt_Nome.MaxLength = 100;
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(564, 26);
            this.txt_Nome.TabIndex = 1;
            this.txt_Nome.TextChanged += new System.EventHandler(this.txt_Nome_TextChanged);
            this.txt_Nome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Nome_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(9, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 19);
            this.label16.TabIndex = 104;
            this.label16.Text = "Código:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(9, 355);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 19);
            this.label15.TabIndex = 103;
            this.label15.Text = "E-mail:";
            // 
            // mask_Celular
            // 
            this.mask_Celular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mask_Celular.ForeColor = System.Drawing.Color.Black;
            this.mask_Celular.Location = new System.Drawing.Point(284, 304);
            this.mask_Celular.Mask = "(00) 00000-0000";
            this.mask_Celular.Name = "mask_Celular";
            this.mask_Celular.Size = new System.Drawing.Size(122, 26);
            this.mask_Celular.TabIndex = 13;
            this.mask_Celular.ValidatingType = typeof(System.DateTime);
            this.mask_Celular.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_Celular_MaskInputRejected);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(215, 306);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 19);
            this.label14.TabIndex = 102;
            this.label14.Text = "Celular:";
            // 
            // mask_Telefone
            // 
            this.mask_Telefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mask_Telefone.ForeColor = System.Drawing.Color.Black;
            this.mask_Telefone.Location = new System.Drawing.Point(84, 304);
            this.mask_Telefone.Mask = "(00) 0000-0000";
            this.mask_Telefone.Name = "mask_Telefone";
            this.mask_Telefone.Size = new System.Drawing.Size(113, 26);
            this.mask_Telefone.TabIndex = 12;
            this.mask_Telefone.ValidatingType = typeof(System.DateTime);
            this.mask_Telefone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_Telefone_MaskInputRejected);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 19);
            this.label13.TabIndex = 101;
            this.label13.Text = "Telefone:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(454, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 19);
            this.label12.TabIndex = 100;
            this.label12.Text = "Estado:";
            // 
            // cb_Estado
            // 
            this.cb_Estado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Estado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_Estado.ForeColor = System.Drawing.Color.Black;
            this.cb_Estado.FormattingEnabled = true;
            this.cb_Estado.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RR",
            "RO",
            "RJ",
            "RN",
            "RS",
            "SC",
            "SP",
            "SE",
            "TO"});
            this.cb_Estado.Location = new System.Drawing.Point(520, 258);
            this.cb_Estado.Name = "cb_Estado";
            this.cb_Estado.Size = new System.Drawing.Size(75, 27);
            this.cb_Estado.TabIndex = 11;
            this.cb_Estado.SelectedIndexChanged += new System.EventHandler(this.cb_Estado_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(14, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 19);
            this.label11.TabIndex = 99;
            this.label11.Text = "Cidade:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(466, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 19);
            this.label10.TabIndex = 98;
            this.label10.Text = "Número:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(8, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 97;
            this.label9.Text = "Endereço:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(268, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 19);
            this.label8.TabIndex = 96;
            this.label8.Text = "Bairro:";
            // 
            // mask_Cep
            // 
            this.mask_Cep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mask_Cep.ForeColor = System.Drawing.Color.Black;
            this.mask_Cep.Location = new System.Drawing.Point(76, 159);
            this.mask_Cep.Mask = "00000-000";
            this.mask_Cep.Name = "mask_Cep";
            this.mask_Cep.Size = new System.Drawing.Size(84, 26);
            this.mask_Cep.TabIndex = 6;
            this.mask_Cep.ValidatingType = typeof(System.DateTime);
            this.mask_Cep.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_Cep_MaskInputRejected);
            this.mask_Cep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mask_Cep_KeyDown);
            // 
            // mask_CPF
            // 
            this.mask_CPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mask_CPF.ForeColor = System.Drawing.Color.Black;
            this.mask_CPF.Location = new System.Drawing.Point(264, 112);
            this.mask_CPF.Mask = "000,000,000-00";
            this.mask_CPF.Name = "mask_CPF";
            this.mask_CPF.Size = new System.Drawing.Size(113, 26);
            this.mask_CPF.TabIndex = 3;
            this.mask_CPF.ValidatingType = typeof(System.DateTime);
            this.mask_CPF.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mask_CPF_MaskInputRejected);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(387, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 19);
            this.label7.TabIndex = 95;
            this.label7.Text = "Data Nascimento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 19);
            this.label6.TabIndex = 94;
            this.label6.Text = "Registro Geral:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(215, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 19);
            this.label5.TabIndex = 93;
            this.label5.Text = "CPF:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(32, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 92;
            this.label4.Text = "CEP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 91;
            this.label3.Text = "Nome:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 539);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Cliente";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmClientes_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.Button btn_Minimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Excluir;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.DateTimePicker dateNascimento;
        private System.Windows.Forms.Button btn_BuscarCep;
        private System.Windows.Forms.MaskedTextBox mask_RG;
        private System.Windows.Forms.TextBox txt_Numero;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.TextBox txt_Cidade;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Bairro;
        private System.Windows.Forms.TextBox txt_Endereco;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox mask_Celular;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox mask_Telefone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_Estado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mask_Cep;
        private System.Windows.Forms.MaskedTextBox mask_CPF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}