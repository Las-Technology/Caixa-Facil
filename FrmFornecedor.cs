using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmFornecedor : Form
    {
        public FrmFornecedor(string Cadastro)
        {
            InitializeComponent();
            this.Cadastro = Cadastro;
        }

        string Cadastro;
        int X = 0;
        int Y = 0;

        private void panelCabecalho_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panelCabecalho_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }
        private void mask_InscricaoEstadual_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Fornecedor_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_CNPJ_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_Cep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Bairro_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Endereco_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Numero_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Cidade_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_Telefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_Celular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_NomeSituacao_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void Mask_DataAnterior_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_DataPosterior_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_Cep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_BuscarCep_Click(sender, e);
            }
        }

        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void btn_BuscarCep_Click(object sender, EventArgs e)
        {
            if (mask_Cep.MaskCompleted)
            {
                try
                {
                    using (var ws = new WsCorreios.AtendeClienteClient())
                    {
                        var consultaCEP = ws.consultaCEP(mask_Cep.Text);
                        txt_Endereco.Text = consultaCEP.end;
                        txt_Bairro.Text = consultaCEP.bairro;
                        txt_Cidade.Text = consultaCEP.cidade;
                        cb_Estado.Text = consultaCEP.uf;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha todo o campo do Cep! Campo Obrigatório!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(mask_Cep, "Campo Incompleto!");
                mask_Cep.Focus();
                return;
            }
        }

        ClassFornecedor Fornecedor = new ClassFornecedor();

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            if (txt_RazaoSocial.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Razão Social'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear();
                errorProvider.SetError(txt_RazaoSocial, "Campo obrigatório!");
                txt_RazaoSocial.Focus();
                return;
            }
            else
            {
                try
                {
                    CodigoFornecedor();
                    Fornecedor.id = int.Parse(txt_Codigo.Text);
                    Fornecedor.nome = txt_RazaoSocial.Text.Trim();
                    Fornecedor.Inscricao = mask_InscricaoEstadual.Text;
                    Fornecedor.Cnpj = mask_CNPJ.Text;
                    Fornecedor.CEP = mask_Cep.Text;
                    Fornecedor.bairro = txt_Bairro.Text.Trim();
                    Fornecedor.endereco = txt_Endereco.Text.Trim();
                    Fornecedor.numero = txt_Numero.Text.Trim();
                    Fornecedor.cidade = txt_Cidade.Text.Trim();
                    Fornecedor.estado = cb_Estado.Text;
                    Fornecedor.telefone = mask_Telefone.Text;
                    Fornecedor.celular = mask_Celular.Text;
                    Fornecedor.email = txt_Email.Text.Trim();

                    if (mask_CNPJ.MaskCompleted)
                    {
                        if (!ValidarCNPJ())
                        {
                            MessageBox.Show("CNPJ inválido!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            errorProvider.Clear();
                            errorProvider.SetError(mask_CNPJ, "Campo inválido!");
                            mask_CNPJ.Clear();
                            return;
                        }

                        if (Fornecedor.VerificarCNPJexists())
                        {
                            MessageBox.Show("CNPJ já cadastrado!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        Fornecedor.Cnpj = "";

                    Fornecedor.Cadastrar();
                    MessageBox.Show("Fornecedor cadastrado com sucesso!", "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (string.IsNullOrEmpty(Cadastro))
                    {
                        LimparCampos();
                        CodigoFornecedor();
                    }
                    else
                    {
                        IdFornecedor = txt_Codigo.Text;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro na conexão com o banco de dados...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string IdFornecedor { get; set; }

        private void LimparCampos()
        {
            txt_RazaoSocial.Clear();
            mask_CNPJ.Clear();
            mask_InscricaoEstadual.Clear();
            mask_Cep.Clear();
            txt_Bairro.Clear();
            txt_Endereco.Clear();
            txt_Numero.Clear();
            txt_Cidade.Clear();
            cb_Estado.Text = " ";
            mask_Telefone.Clear();
            mask_Celular.Clear();
            txt_Email.Clear();
            IdFornecedor = null;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IdFornecedor))
            {
                MessageBox.Show("Busque as informações para alteração dos dados!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txt_RazaoSocial.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Razão Social'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear();
                errorProvider.Clear();
                errorProvider.SetError(txt_RazaoSocial, "Campo obrigatório!");
                txt_RazaoSocial.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(IdFornecedor))
            {
                MessageBox.Show("Informe os dados do fornecedor para alteração!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                return;
            }
            else
            {
                try
                {
                    if (mask_CNPJ.MaskCompleted)
                    {
                        if (!ValidarCNPJ())
                        {
                            MessageBox.Show("CNPJ inválido!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            errorProvider.Clear();
                            errorProvider.SetError(mask_CNPJ, "Campo inválido!");
                            mask_CNPJ.Clear();
                            return;
                        }
                    }

                    Fornecedor.nome = txt_RazaoSocial.Text.Trim();
                    Fornecedor.Cnpj = mask_CNPJ.Text;
                    Fornecedor.Inscricao = mask_InscricaoEstadual.Text;
                    Fornecedor.CEP = mask_Cep.Text;
                    Fornecedor.bairro = txt_Bairro.Text.Trim();
                    Fornecedor.endereco = txt_Endereco.Text.Trim();
                    Fornecedor.numero = txt_Numero.Text.Trim();
                    Fornecedor.cidade = txt_Cidade.Text.Trim();
                    Fornecedor.estado = cb_Estado.Text;
                    Fornecedor.telefone = mask_Telefone.Text;
                    Fornecedor.celular = mask_Celular.Text;
                    Fornecedor.email = txt_Email.Text.Trim();

                    if (mask_CNPJ.MaskCompleted)
                    {
                        if (!ValidarCNPJ())
                        {
                            MessageBox.Show("CNPJ inválido!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            errorProvider.Clear();
                            errorProvider.SetError(mask_CNPJ, "Campo inválido!");
                            mask_CNPJ.Clear();
                            return;
                        }

                        if (Fornecedor.VerificarCNPJexistsUpdate())
                        {
                            MessageBox.Show("Há um fornecedor com o mesmo CNPJ cadastrado!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        Fornecedor.Cnpj = "";



                    Fornecedor.Atualizar();
                    MessageBox.Show("Dados do Fornecedor atualizado com sucesso!", "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CodigoFornecedor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro na conexão com o banco de dados...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Blue;
            btn_Minimizar.ForeColor = Color.White;
        }

        private void btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Moccasin;
            btn_Minimizar.ForeColor = Color.Black;
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
            btn_Fechar.ForeColor = Color.White;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Moccasin;
            btn_Fechar.ForeColor = Color.Black;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            CodigoFornecedor();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        //MÉTODO PARA MOSTRAR AO USUÁRIO DO SISTEMA O CÓDIGO DO CLIENTE QUE SERÁ GERADO AO CADASTRAR O CLIENTE NO SISTEMA

        private void CodigoFornecedor()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT MAX(Id_Fornecedor) from Fornecedor";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() == DBNull.Value)
                {
                    txt_Codigo.Text = "1";
                }
                else
                {
                    Int32 ra = Convert.ToInt32(comando.ExecuteScalar()) + 1;
                    txt_Codigo.Text = ra.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        bool ValidarCNPJ()
        {
            try
            {
                if (!(mask_CNPJ.Text.Length < 18))
                {
                    int n1 = Convert.ToInt16(mask_CNPJ.Text.Substring(0, 1));
                    int n2 = Convert.ToInt16(mask_CNPJ.Text.Substring(1, 1));
                    int n3 = Convert.ToInt16(mask_CNPJ.Text.Substring(3, 1));
                    int n4 = Convert.ToInt16(mask_CNPJ.Text.Substring(4, 1));
                    int n5 = Convert.ToInt16(mask_CNPJ.Text.Substring(5, 1));
                    int n6 = Convert.ToInt16(mask_CNPJ.Text.Substring(7, 1));
                    int n7 = Convert.ToInt16(mask_CNPJ.Text.Substring(8, 1));
                    int n8 = Convert.ToInt16(mask_CNPJ.Text.Substring(9, 1));
                    int n9 = Convert.ToInt16(mask_CNPJ.Text.Substring(11, 1));
                    int n10 = Convert.ToInt16(mask_CNPJ.Text.Substring(12, 1));
                    int n11 = Convert.ToInt16(mask_CNPJ.Text.Substring(13, 1));
                    int n12 = Convert.ToInt16(mask_CNPJ.Text.Substring(14, 1));

                    int digito1 = Convert.ToInt16(mask_CNPJ.Text.Substring(16, 1));
                    int digito2 = Convert.ToInt16(mask_CNPJ.Text.Substring(17, 1));

                    int soma1 = n1 * 5 + n2 * 4 + n3 * 3 + n4 * 2 + n5 * 9 + n6 * 8 + n7 * 7 + n8 * 6 + n9 * 5 + n10 * 4 + n11 * 3 + n12 * 2;

                    int digitoVerificador = soma1 % 11;
                    if (digitoVerificador < 2)
                    {
                        digitoVerificador = 0;
                    }
                    else
                    {
                        digitoVerificador = 11 - digitoVerificador;
                    }

                    int soma2 = n1 * 6 + n2 * 5 + n3 * 4 + n4 * 3 + n5 * 2 + n6 * 9 + n7 * 8 + n8 * 7 + n9 * 6 + n10 * 5 + n11 * 4 + n12 * 3 + digitoVerificador * 2;

                    int digitoVerificador2 = soma2 % 11;

                    if (digitoVerificador2 < 2)
                    {
                        digitoVerificador2 = 0;
                    }
                    else
                    {
                        digitoVerificador2 = 11 - digitoVerificador2;
                    }
                    if (digito1 == digitoVerificador && digito2 == digitoVerificador2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void mask_CNPJ_Leave(object sender, EventArgs e)
        {
            if (mask_CNPJ.MaskCompleted)
            {
                if (ValidarCNPJ() == false)
                {
                    MessageBox.Show("CNPJ inválido!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(mask_CNPJ, "CNPJ inválida!");
                    mask_CNPJ.Clear();
                    return;
                }
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(IdFornecedor))
                {
                    MessageBox.Show("Informe os dados do fornecedor para exclusão!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    return;
                }

                Fornecedor.id = int.Parse(txt_Codigo.Text);
                if (MessageBox.Show("Deseja mesmo excluir os dados do fornecedor?", "Sistema de exclusão...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Fornecedor.Deletar();
                    MessageBox.Show("Dados do fornecedor excluido com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CodigoFornecedor();
                }

            }
            catch
            {
                MessageBox.Show("Não é permitido a exclusão! Existe Produto(s) relacionadas com o fornecedor selecionado", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btn_Salvar_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
                btn_Pesquisar_Click(sender, e);
            else if (e.KeyCode == Keys.F3)
                btn_Editar_Click(sender, e);
            else if (e.KeyCode == Keys.F5)
                btn_Excluir_Click(sender, e);
        }

        private void txt_RazaoSocial_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void cb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            FrmPesquisarFornecedor pesquisarFornecedor = new FrmPesquisarFornecedor();
            pesquisarFornecedor.ShowDialog();
            if (pesquisarFornecedor.Codigo != null)
            {
                txt_Codigo.Text = pesquisarFornecedor.Codigo;
                try
                {
                    IdFornecedor = pesquisarFornecedor.Codigo;
                    Fornecedor.id = int.Parse(pesquisarFornecedor.Codigo);
                    Fornecedor.Consultar();
                    txt_RazaoSocial.Text = Fornecedor.nome;
                    mask_CNPJ.Text = Fornecedor.Cnpj;
                    mask_InscricaoEstadual.Text = Fornecedor.Inscricao;
                    mask_Cep.Text = Fornecedor.CEP;
                    txt_Bairro.Text = Fornecedor.bairro;
                    txt_Endereco.Text = Fornecedor.endereco;
                    txt_Numero.Text = Fornecedor.numero.ToString();
                    txt_Cidade.Text = Fornecedor.cidade;
                    cb_Estado.Text = Fornecedor.estado;
                    mask_Telefone.Text = Fornecedor.telefone;
                    mask_Celular.Text = Fornecedor.celular;
                    txt_Email.Text = Fornecedor.email;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
