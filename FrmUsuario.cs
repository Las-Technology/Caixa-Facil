using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;

        private void CodigoUsuario()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT MAX(Id_Usuario) from Usuario";
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
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CodigoUsuario();
        }

        private void btn_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            this.btn_Minimizar.BackColor = Color.Blue; ;
        }

        private void btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            this.btn_Minimizar.BackColor = Color.Orchid;
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            this.btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            this.btn_Fechar.BackColor = Color.Orchid;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int X = 0;
        int Y = 0;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Usuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            int totalValue = 0 + txt_senha.TextLength;
            lbl_Contador.Text = totalValue.ToString() + " Caracter(es).";
            if (txt_senha.Text == string.Empty)
            {
                lbl_Contador.Text = string.Empty;
            }
        }

        private void txt_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txt_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }


        ClassUsuario Usuario = new ClassUsuario();
        private void btn_Salvar_Click(object sender, EventArgs e)
        {

            if (txt_Nome.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Nome'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear(); errorProvider.Clear();
                errorProvider.SetError(txt_Nome, "Campo obrigatório!");
                txt_Nome.Focus();
                return;
            }

            else if ((txt_Email.Text != string.Empty) && (!ClassValidacaoEmail.validarEmail(txt_Email.Text)))
            {
                MessageBox.Show("E-mail inválido!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider.SetError(txt_Email, "E-mail inválido!");
                txt_Email.Focus();
                return;
            }
            else if (txt_Usuario.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'usuário' para logar!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear(); errorProvider.Clear();
                errorProvider.SetError(txt_Usuario, "Campo obrigatório!");
                txt_Usuario.Focus();
                return;
            }
            if (txt_senha.Text == string.Empty)
            {
                MessageBox.Show("Coloque a senha!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear();
                errorProvider.Clear();
                errorProvider.SetError(txt_senha, "Campo obrigatório!");
                txt_senha.Focus();
                return;
            }
            else if (txt_senha.TextLength < 5)
            {
                MessageBox.Show("A senha deve ter de 5 a 15 caracteres!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_senha, "Campo obrigatório!");
                txt_senha.Focus();
                return;
            }
            else if (txt_DicaSenha.Text == string.Empty)
            {
                MessageBox.Show("Digite uma dica de segurança!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_DicaSenha, "Campo obrigatório!");
                txt_DicaSenha.Focus();
                return;
            }
            else if (cb_PerguntaSeguranca.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione ou digite uma pergunta de segurança!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(cb_PerguntaSeguranca, "Campo obrigatório!");
                cb_PerguntaSeguranca.Focus();
                return;
            }
            else if (txt_RespostaSeguranca.Text == string.Empty)
            {
                MessageBox.Show("Digite a sua resposta!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_RespostaSeguranca, "Campo obrigatório!");
                txt_RespostaSeguranca.Focus();
                return;
            }
            else if (cb_Funcao.Text == string.Empty)
            {
                MessageBox.Show("Selecione o campo 'Função'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(cb_Funcao, "Campo obrigatório!");
                cb_Funcao.Focus();
                return;
            }
            else
            {

                try
                {
                    CodigoUsuario();
                    Usuario.nome = txt_Nome.Text.Trim();
                    Usuario.email = txt_Email.Text.Trim();
                    Usuario.funcao = cb_Funcao.Text.Trim().ToUpper();
                    Usuario.usuario = txt_Usuario.Text.Trim();
                    Usuario.senha = Security.Cry(txt_senha.Text.Trim());
                    Usuario.dicaSenha = txt_DicaSenha.Text.Trim();
                    Usuario.perguntaSeguranca = cb_PerguntaSeguranca.Text;
                    Usuario.respostaSeguranca = txt_RespostaSeguranca.Text;
                    Usuario.situacao = "ATIVO";
                    if (Usuario.Cadastrar() == false)
                    {
                        Usuario.Cadastrar();

                        MessageBox.Show("Usuario cadastrado com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CodigoUsuario();
                    }
                    else
                    {
                        MessageBox.Show("O Usuário já existe!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        errorProvider.Clear();
                        errorProvider.SetError(txt_Usuario, "");
                        txt_Usuario.Focus();
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCampos()
        {
            cb_PerguntaSeguranca.SelectedIndex = -1;
            txt_RespostaSeguranca.Clear();
            txt_DicaSenha.Clear();
            txt_Nome.Clear();
            txt_Email.Clear();
            txt_Usuario.Clear();
            txt_senha.Clear();
            cb_Funcao.Text = "";
            lbl_Contador.Text = string.Empty;
            idUsuario = 0;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if(idUsuario == 0)
            {
                MessageBox.Show("Informe os dados para alteração!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txt_Nome.Text == string.Empty)
            {
                errorProvider.Clear();
                errorProvider.SetError(txt_Nome, "Campo obrigatório!");
                txt_Nome.Focus();
                return;
            }
            else if ((txt_Email.Text != string.Empty) && (!ClassValidacaoEmail.validarEmail(txt_Email.Text)))
            {
                MessageBox.Show("E-mail inválido!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider.SetError(txt_Email, "E-mail inválido!");
                txt_Email.Focus();
                return;
            }
            else if (txt_Usuario.Text == string.Empty)
            {
                errorProvider.Clear();
                errorProvider.SetError(txt_Usuario, "Campo obrigatório!");
                txt_Usuario.Focus();
                return;
            }
            if (txt_senha.Text == string.Empty)
            {
                errorProvider.Clear();
                errorProvider.SetError(txt_senha, "Campo obrigatório!");
                txt_senha.Focus();
                return;
            }
            else if (txt_senha.TextLength < 5)
            {
                MessageBox.Show("A senha deve ter de 5 a 15 caracteres!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_senha, "Campo obrigatório!");
                txt_senha.Focus();
                return;
            }
            else if (txt_DicaSenha.Text == string.Empty)
            {
                MessageBox.Show("Digite uma dica de segurança!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_DicaSenha, "Campo obrigatório!");
                txt_DicaSenha.Focus();
                return;
            }
            else if (cb_PerguntaSeguranca.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione ou digite uma pergunta de segurança!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(cb_PerguntaSeguranca, "Campo obrigatório!");
                cb_PerguntaSeguranca.Focus();
                return;
            }
            else if (txt_RespostaSeguranca.Text == string.Empty)
            {
                MessageBox.Show("Digite a sua resposta!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_RespostaSeguranca, "Campo obrigatório!");
                txt_RespostaSeguranca.Focus();
                return;
            }
            else if (cb_Funcao.Text == string.Empty)
            {
                errorProvider.Clear();
                errorProvider.SetError(cb_Funcao, "Campo obrigatório!");
                cb_Funcao.Focus();
                return;
            }
            else
            {

                try
                {
                    string Senha = Security.Cry(txt_senha.Text);
                    Usuario.id = int.Parse(txt_Codigo.Text.Trim());
                    Usuario.nome = txt_Nome.Text.Trim();
                    Usuario.nome = txt_Nome.Text.Trim();
                    Usuario.email = txt_Email.Text.Trim();
                    Usuario.usuario = txt_Usuario.Text.Trim();
                    Usuario.dicaSenha = txt_DicaSenha.Text.Trim();
                    Usuario.senha = Senha;
                    Usuario.funcao = cb_Funcao.Text.Trim().ToUpper();
                    Usuario.perguntaSeguranca = cb_PerguntaSeguranca.Text;
                    Usuario.respostaSeguranca = txt_RespostaSeguranca.Text;
                    if (!Usuario.Atualizar())
                    {
                        MessageBox.Show("Dados do Usuario atualizado com sucesso.", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CodigoUsuario();
                    }
                    else
                    {
                        MessageBox.Show("Dica de Senha inválida! Crie outra dica!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (idUsuario == 0)
                {
                    MessageBox.Show("Informe os dados para Excluir os dados!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
             
                if (MessageBox.Show("Deseja mesmo excluir os dados do usuário?", "Caixa Fácil.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Usuario.id = int.Parse(txt_Codigo.Text);
                    Usuario.usuario = txt_Usuario.Text;
                    Usuario.Deletar();
                    MessageBox.Show("Dados do usuário deletado com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CodigoUsuario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_Funcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_DicaSenha_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void cb_PerguntaSeguranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_RespostaSeguranca_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        int idUsuario;

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            FrmPesquisarUsuario pesquisarUsuario = new FrmPesquisarUsuario();
            pesquisarUsuario.ShowDialog();
            if (pesquisarUsuario.Codigo != null)
            {
                txt_Codigo.Text = pesquisarUsuario.Codigo;

                try
                {
                    idUsuario = int.Parse(pesquisarUsuario.Codigo);
                    Usuario.id = int.Parse(pesquisarUsuario.Codigo);
                    Usuario.Consultar();
                    txt_Nome.Text = Usuario.nome;
                    cb_Funcao.Text = Usuario.funcao;
                    txt_Email.Text = Usuario.email;
                    txt_Usuario.Text = Usuario.usuario;
                    txt_senha.Text = Security.Dry(Usuario.senha);
                    txt_DicaSenha.Text = Usuario.dicaSenha;
                    cb_PerguntaSeguranca.Text = Usuario.perguntaSeguranca;
                    txt_RespostaSeguranca.Text = Usuario.respostaSeguranca;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmUsuario_KeyDown(object sender, KeyEventArgs e)
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
    }
}