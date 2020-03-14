﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmContasNaoContabilizadas : Form
    {
        public FrmContasNaoContabilizadas()
        {
            InitializeComponent();
        }

        int X = 0, Y = 0;

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

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;
        bool Validado = false;
        int codigo;

        ClassContasNaoContabilizada contasNaoContabilizada = new ClassContasNaoContabilizada();

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo > 0)
                {
                    ValidarCampos();
                    if (Validado == true)
                    {
                        contasNaoContabilizada.codigo = codigo;
                        contasNaoContabilizada.nome = txt_Nome.Text.Trim();
                        contasNaoContabilizada.bairro = txt_Bairro.Text.Trim();
                        contasNaoContabilizada.endereco = txt_Endereco.Text.Trim();
                        contasNaoContabilizada.numero = txt_Numero.Text.Trim();
                        contasNaoContabilizada.dataConta = dt_DataVenda.Text;
                        if (decimal.Parse(txt_Valor.Text) != ValorConta)
                        {
                            if (MessageBox.Show("Valor é diferente da conta atual, Deseja alterar o valor? " + txt_Valor.Text, "Caixa Fácil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                contasNaoContabilizada.valorConta = decimal.Parse(txt_Valor.Text.Trim());
                            else
                                contasNaoContabilizada.valorConta = ValorConta;
                        }
                        else
                        {
                            contasNaoContabilizada.valorConta = ValorConta;
                        }
                        if (contasNaoContabilizada.valorConta > 0)
                        {
                            contasNaoContabilizada.EditarVendaNaoContabilizada();
                            MessageBox.Show("Conta alterada com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            txt_Nome.Focus();
                            Validado = false;
                            codigo = 0;
                        }
                        else
                        {
                            MessageBox.Show("Informe valor maior que zero!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Busque a conta que deseja alterar!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (codigo == 0)
            {
                MessageBox.Show("Busque a conta para excluir!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Deseja mesmo excluir esta conta? Excluindo a conta, não haverá com recuperá-la.", "Aviso do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    contasNaoContabilizada.codigo = codigo;
                    contasNaoContabilizada.ExcluirVendaNaoContabilizada();
                    MessageBox.Show("Conta excluido com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    txt_Nome.Focus();
                }
            }
        }

        decimal ValorConta;
        private void btn_BuscarVenda_Click(object sender, EventArgs e)
        {
            if (BuscarConta() == true)
            {
                FrmBuscarContasNaoContabilizadas buscarContasNaoContabilizadas = new FrmBuscarContasNaoContabilizadas();
                buscarContasNaoContabilizadas.ShowDialog();
                if (buscarContasNaoContabilizadas.codigo > 0)
                {
                    codigo = buscarContasNaoContabilizadas.codigo;
                    txt_Nome.Text = buscarContasNaoContabilizadas.nome;
                    txt_Bairro.Text = buscarContasNaoContabilizadas.bairro;
                    txt_Endereco.Text = buscarContasNaoContabilizadas.endereco;
                    txt_Numero.Text = buscarContasNaoContabilizadas.numero;
                    txt_Valor.Text = buscarContasNaoContabilizadas.valorConta;
                    dt_DataVenda.Text = buscarContasNaoContabilizadas.DataConta;
                    ValorConta = decimal.Parse(buscarContasNaoContabilizadas.valorConta);
                }
            }
            else
            {
                MessageBox.Show("Não existe contas não contabilizadas registrada no sistema!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool BuscarConta()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select * from ContasNaoContabilizadas where Valor_Conta > 0";

            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            conexao.Open();
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            FrmPesquisarCliente pesquisarCliente = new FrmPesquisarCliente();
            pesquisarCliente.ShowDialog();
            if (!string.IsNullOrEmpty(pesquisarCliente.Nome))
            {
                txt_Nome.Text = pesquisarCliente.Nome;
                txt_Bairro.Text = pesquisarCliente.Bairro;
                txt_Endereco.Text = pesquisarCliente.Endereco;
                txt_Numero.Text = pesquisarCliente.Numero;
                txt_Valor.Focus();
            }
        }

        private void LimparCampos()
        {
            txt_Nome.Clear();
            txt_Endereco.Clear();
            txt_Bairro.Clear();
            txt_Numero.Clear();
            txt_Valor.Clear();
            dt_DataVenda.Text = DateTime.Now.ToShortDateString();
            codigo = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();
               if(Validado == true)
                {
                    contasNaoContabilizada.nome = txt_Nome.Text.Trim();
                    contasNaoContabilizada.bairro = txt_Bairro.Text.Trim();
                    contasNaoContabilizada.endereco = txt_Endereco.Text.Trim();
                    contasNaoContabilizada.numero = txt_Numero.Text.Trim();
                    contasNaoContabilizada.valorConta = decimal.Parse(txt_Valor.Text.Trim());
                    contasNaoContabilizada.dataConta = dt_DataVenda.Text;
                    
                    if (contasNaoContabilizada.valorConta > 0)
                    {
                        contasNaoContabilizada.ConfimarVendaNaoContabilizada();
                        MessageBox.Show("Conta salvo com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Nome.Focus();
                        LimparCampos();
                        txt_Nome.Focus();
                        Validado = false;
                    }
                    else
                    {
                        MessageBox.Show("Informe valor maior que zero!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCampos()
        {
            if (txt_Nome.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Nome'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_Nome, "Campo obrigatório!");
                txt_Nome.Focus();
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
            else if (txt_Valor.Text == string.Empty)
            {
                MessageBox.Show("Informe o valor!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_Valor, "Campo obrigatório!");
                txt_Valor.Focus();
                return;
            }
            else
            {
                Validado = true;
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
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

        private void txt_Nome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }

        private void txt_Endereco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }

        private void txt_Bairro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }

        private void txt_Numero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
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

        private void mask_Telefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }

        private void txt_Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (((int)e.KeyChar) != ((int)Keys.Back))
                    if (e.KeyChar != ',')
                        e.Handled = true;
                    else if (txt_Valor.Text.IndexOf(',') > 0)
                        e.Handled = true;
            }
        }

        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Valor.Text))
            {
                txt_Valor.Text = decimal.Parse(txt_Valor.Text.Trim()).ToString("0.00");
            }
        }

        private void txt_Valor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }

        private void btnBaixarConta_Click(object sender, EventArgs e)
        {
            if(codigo > 0)
            {
                FrmBaixarPagamentoContasNaoContabilizadas baixarPagamentoContasNaoContabilizadas = new FrmBaixarPagamentoContasNaoContabilizadas(ValorConta, codigo.ToString(), txt_Nome.Text.Trim());
                baixarPagamentoContasNaoContabilizadas.ShowDialog();
                if (baixarPagamentoContasNaoContabilizadas.pagamentobaixado)
                {
                    {
                        LimparCampos();
                        txt_Nome.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Busque a conta que irá abater!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dt_DataVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }       
    }
}
