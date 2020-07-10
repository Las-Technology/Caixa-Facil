using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;
        //MÉTODO PARA MOSTRAR AO USUÁRIO DO SISTEMA O CÓDIGO DO CLIENTE QUE SERÁ GERADO AO CADASTRAR O CLIENTE NO SISTEMA
        private void codigoCliente()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT MAX(Id_Cliente) from Cliente";
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
        private void btn_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Blue;
        }

        private void btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.DarkTurquoise;
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.DarkTurquoise;
        }

        private void mask_Cpf_Leave(object sender, EventArgs e)
        {
            if (mask_CPF.MaskCompleted)
            {
                string validar = mask_CPF.Text;
                if (!CPF.ValidaCpf(validar))
                {
                    MessageBox.Show("O número do CPF é Inválido!", "Validação CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.SetError(mask_CPF, "CPF inválido!");
                    mask_CPF.Clear();
                    return;
                }
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
                        var consultaCep = ws.consultaCEP(mask_Cep.Text);
                        txt_Endereco.Text = consultaCep.end;
                        txt_Bairro.Text = consultaCep.bairro;
                        txt_Cidade.Text = consultaCep.cidade;
                        cb_Estado.Text = consultaCep.uf;
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

        internal void ShowDialog(string atualizar)
        {
            throw new NotImplementedException();
        }

        private void LimparCampos()
        {
            txt_Codigo.Clear();
            txt_Nome.Clear();
            txt_Endereco.Clear();
            txt_Email.Clear();
            txt_Cidade.Clear();
            txt_Bairro.Clear();
            mask_Celular.Clear();
            mask_Cep.Clear();
            mask_CPF.Clear();
            mask_RG.Clear();
            mask_Telefone.Clear();
            cb_Estado.SelectedIndex = -1;
            txt_Numero.Clear();
            idCliente = 0;
        }

        ClassClientes cliente = new ClassClientes();

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            codigoCliente();

            try
            {
                if (txt_Codigo.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Código'! ", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Codigo, "Campo obrigatório!");
                    txt_Codigo.Focus();
                    return;
                }
                else if (txt_Nome.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Nome'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Nome, "Campo obrigatório!");
                    txt_Nome.Focus();
                    return;
                }
                else if (!mask_Cep.MaskCompleted)
                {
                    MessageBox.Show("Preencha todo o campo do Cep!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(mask_Cep, "Campo Incompleto!");
                    mask_Cep.Focus();
                    return;
                }
                else if (txt_Bairro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Bairro'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Bairro, "Campo obrigatório!");
                    txt_Bairro.Focus();
                    return;
                }

                else if (txt_Endereco.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Endereço'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Endereco, "Campo obrigatório!");
                    txt_Endereco.Focus();
                    return;
                }
                else if (txt_Numero.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Número'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Numero, "Campo obrigatório!");
                    txt_Numero.Focus();
                    return;
                }
                else if (txt_Cidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Cidade'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Cidade, "Campo obrigatório!");
                    txt_Cidade.Focus();
                    return;
                }
                else if (cb_Estado.Text == string.Empty)
                {
                    MessageBox.Show("Selecione o Estado de sua região!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(cb_Estado, "Campo obrigatório!");
                    cb_Estado.Focus();
                    return;
                }
                else if ((txt_Email.Text != string.Empty) && (!ClassValidacaoEmail.validarEmail(txt_Email.Text)))
                {
                    MessageBox.Show("E-mail inválido!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider.SetError(txt_Email, "E-mail inválido!");
                    txt_Email.Focus();
                    return;
                }
                else
                {
                    if (mask_CPF.MaskCompleted)
                    {
                        string validar = mask_CPF.Text;
                        if (CPF.ValidaCpf(validar) == false)
                        {
                            MessageBox.Show("O número do CPF é Inválido!", "Validação CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            errorProvider.Clear();
                            errorProvider.SetError(mask_CPF, "CPF inválido!");
                            return;
                        }
                    }
                    else
                        mask_CPF.Clear();

                 
                    SalvarCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalvarCliente()
        {
            cliente.id = int.Parse(txt_Codigo.Text);
            cliente.nome = txt_Nome.Text.Trim();
            cliente.dataNascimento = dateNascimento.Text;
            cliente.CPF = Security.Cry(mask_CPF.Text);
            cliente.RG = Security.Cry(mask_RG.Text);
            cliente.CEP = mask_Cep.Text;
            cliente.bairro = txt_Bairro.Text.Trim();
            cliente.endereco = txt_Endereco.Text.Trim();
            cliente.numero = txt_Numero.Text.Trim();
            cliente.cidade = txt_Cidade.Text.Trim();
            cliente.estado = cb_Estado.Text;
            cliente.telefone = mask_Telefone.Text;
            cliente.celular = mask_Celular.Text;
            cliente.email = txt_Email.Text.Trim();

            if (mask_CPF.MaskCompleted)
                if (cliente.VerificarCPFexists())
                {
                    MessageBox.Show("CPF já cadastrado!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            cliente.Cadastrar();
            MessageBox.Show("Cliente cadastrado com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCampos();
            codigoCliente();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            codigoCliente();
        }
        int X = 0;
        int Y = 0;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_RG_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void mask_Cpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
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

        private void cb_Estado_SelectedIndexChanged(object sender, EventArgs e)
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

        private void mask_Cep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_BuscarCep_Click(sender, e); 
        }

        private void txt_Codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void txt_Nome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void mask_RG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void mask_Cpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void txt_Endereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void txt_Bairro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void txt_Numero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txt_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txt_Cidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void cb_Estado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void mask_Telefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void mask_Celular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void txt_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            //código para  editar os dados do cliente
            try
            {
                if (txt_Codigo.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Código'! ", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Codigo, "Campo obrigatório!");
                    txt_Codigo.Focus();
                    return;
                }
                else if (txt_Nome.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Nome'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Nome, "Campo obrigatório!");
                    txt_Nome.Focus();
                    return;
                }
                else if (!mask_Cep.MaskCompleted)
                {
                    MessageBox.Show("Preencha todo o campo do Cep!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(mask_Cep, "Campo Incompleto!");
                    mask_Cep.Focus();
                    return;
                }
                else if (txt_Bairro.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Bairro'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Bairro, "Campo obrigatório!");
                    txt_Bairro.Focus();
                    return;
                }

                else if (txt_Endereco.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Endereço'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Endereco, "Campo obrigatório!");
                    txt_Endereco.Focus();
                    return;
                }
                else if (txt_Numero.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Número'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Numero, "Campo obrigatório!");
                    txt_Numero.Focus();
                    return;
                }
                else if (txt_Cidade.Text == string.Empty)
                {
                    MessageBox.Show("Preencha o campo 'Cidade'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(txt_Cidade, "Campo obrigatório!");
                    txt_Cidade.Focus();
                    return;
                }
                else if (cb_Estado.Text == string.Empty)
                {
                    MessageBox.Show("Selecione o Estado de sua região!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(cb_Estado, "Campo obrigatório!");
                    cb_Estado.Focus();
                    return;
                }
                else if ((txt_Email.Text != string.Empty) && (!ClassValidacaoEmail.validarEmail(txt_Email.Text)))
                {
                    MessageBox.Show("E-mail inválido!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider.SetError(txt_Email, "E-mail inválido!");
                    txt_Email.Focus();
                    return;
                }
                else
                {
                    if (mask_CPF.MaskCompleted)
                    {
                        string validar = mask_CPF.Text;
                        if (CPF.ValidaCpf(validar) == false)
                        {
                            MessageBox.Show("O número do CPF é Inválido!", "Validação CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            mask_CPF.Focus();
                            errorProvider.Clear();
                            errorProvider.SetError(mask_CPF, "CPF inválido!");
                            return;
                        }
                    }
                    else
                        mask_CPF.Clear();

                    if (idCliente > 0)
                        EditarCliente();
                    else
                        MessageBox.Show("Informe os dados do cliente para concluir as alterações dos dados", "Validação CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarCliente()
        {
            cliente.id = int.Parse(txt_Codigo.Text.Trim());
            cliente.nome = txt_Nome.Text.Trim();
            cliente.dataNascimento = dateNascimento.Text;
            cliente.CPF = Security.Cry(mask_CPF.Text);
            cliente.RG = Security.Cry(mask_RG.Text);
            cliente.CEP = mask_Cep.Text;
            cliente.bairro = txt_Bairro.Text.Trim();
            cliente.endereco = txt_Endereco.Text.Trim();
            cliente.numero = txt_Numero.Text.Trim();
            cliente.cidade = txt_Cidade.Text.Trim();
            cliente.estado = cb_Estado.Text;
            cliente.telefone = mask_Telefone.Text;
            cliente.celular = mask_Celular.Text;
            cliente.email = txt_Email.Text.Trim();

            cliente.Atualizar();

            MessageBox.Show("Dados do cliente atualizado com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCampos();
        }

        private void mask_CPF_Leave(object sender, EventArgs e)
        {
            //código para validar o CPF

            string validar = mask_CPF.Text;
            if (mask_CPF.MaskCompleted)
            {
                if (!CPF.ValidaCpf(validar))
                {
                    MessageBox.Show("O número do CPF é Inválido!", "Validação CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorProvider.Clear();
                    errorProvider.SetError(mask_CPF, "Campo inválido");
                    mask_CPF.Clear();
                    return;
                }
            }
        }

        private void btn_BuscaCep_Click(object sender, EventArgs e)
        {
            //código para buscar o CEP
            if (mask_Cep.MaskCompleted)
            {
                try
                {
                   using(var ws = new WsCorreios.AtendeClienteClient())
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
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            //código instaciado da classe classCliente
            //função para excluir os dados do cliente
            if (idCliente > 0)
            {
                cliente.id = int.Parse(txt_Codigo.Text);
                if (MessageBox.Show("Deseja mesmo excluir os dados do cliente?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        cliente.Deletar();
                        MessageBox.Show("Dados do cliente deletado com sucesso!", "Informação do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        codigoCliente();
                    }
                    catch
                    {
                        MessageBox.Show("Não é permitido a exclusão! Existe registros de venda(s) do cliente", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
                MessageBox.Show("É necessário preencher os campos para excluir os dados dos banco de dados!", "Mensagem do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }       

        private void dateNascimento_Leave(object sender, EventArgs e)
        {

            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(this.dateNascimento.Text.Trim(), out resultado))
            {
                string DataAtual = DateTime.Now.ToShortDateString();

                DateTime DataNascimento = Convert.ToDateTime(dateNascimento.Text);
                DateTime DataHoje = Convert.ToDateTime(DataAtual);
                TimeSpan time = DataHoje.Subtract(DataNascimento);

                int dias = time.Days;
                int Idade = dias / 365;
                if(string.IsNullOrWhiteSpace(txt_Nome.Text))
                    MessageBox.Show("A idade do cliente é: " + Idade.ToString(), "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("A idade de " + txt_Nome.Text + " é: " + Idade.ToString(), "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        int idCliente; 

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            //abre o formulario frmpesquisarCliente e recebe os valores da propriedade do frmpesquisarcliente   
            FrmPesquisarCliente PC = new FrmPesquisarCliente();
            PC.ShowDialog();


            if (PC.Codigo != null && PC.Codigo != "1")
            {
                txt_Codigo.Text = PC.Codigo;
                try
                {
                    idCliente = int.Parse(PC.Codigo);
                    cliente.id = int.Parse(PC.Codigo);
                    cliente.Consultar();
                    txt_Nome.Text = cliente.nome;
                    dateNascimento.Text = cliente.dataNascimento;
                    mask_CPF.Text = Security.Dry(cliente.CPF);
                    mask_RG.Text = Security.Dry(cliente.RG);
                    mask_Cep.Text = cliente.CEP;
                    txt_Bairro.Text = cliente.bairro;
                    txt_Endereco.Text = cliente.endereco;
                    txt_Numero.Text = cliente.numero.ToString();
                    txt_Cidade.Text = cliente.cidade;
                    cb_Estado.Text = cliente.estado;
                    mask_Telefone.Text = cliente.telefone;
                    mask_Celular.Text = cliente.celular;
                    txt_Email.Text = cliente.email;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mask_CPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void dateNascimento_ValueChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void FrmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btn_Salvar_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
                btn_Pesquisar_Click(sender, e);
            else if (e.KeyCode == Keys.F3)
                btn_Editar_Click(sender, e);
            else if (e.KeyCode == Keys.F4)
                btn_Excluir_Click(sender, e);
        }
    }
}
