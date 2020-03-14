using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaixaFacil.Properties;

namespace CaixaFacil
{
    public partial class FrmVenda : Form
    {
	string AreaAtuacao, opcao = "true", CodigoBarra, Descontar = "Sim";
        string HoraVenda, NomeFantasia, Cidade, Numero, Endereco, CNPJ, Telefone, Estado, Bairro;
	int Id_Usuario, X = 0, Y = 0, EstoqueMinimo, Quantidade, Parcela, Nparcelas = 1;
	decimal ValorPago, ValorCaixa,valorNCaixa, descontoDinheiro, DescontoPorcento, ValorDescontoPorcento, ValorDesconto;
	decimal valorParcelas, ValorRestante, ValorAbatido = 0.00m, Valor;
	bool Fechar = false;
        const int Porcento = 100;

        public FrmVenda(int Id_Usuario, string Usuario)
        {
            InitializeComponent();
            lbl_atendente.Text = Usuario;
            this.Id_Usuario = Id_Usuario;
            txt_Quantidade.Text = "1";
            lbl_Data.Text = DateTime.Now.ToLongDateString();
            lbl_Hora.Text = DateTime.Now.ToLongTimeString();
            txt_ValorTotal.Text = "R$ 0,00";
            CodigoVenda();
            txt_CodigoVenda.Text = codigoVenda;
            txt_Codigo_Barra.Focus();           
        }
       
        private void BuscarAtuacaoEmpresaSalao()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select AreaAtuacao From Empresa";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                AreaAtuacao = Tabela.Rows[0]["AreaAtuacao"].ToString();
            }
        }
       
        private void PanelCabecalho_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void PanelCabecalho_MouseMove(object sender, MouseEventArgs e)
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
            btn_Minimizar.BackColor = Color.Green;
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Green;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {           
            Sair();           
        }       

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            empresa.Consultar();
            lbl_NomeEmpresa.Text = empresa.nomeFantasia; txt_Codigo_Barra.Focus();
            BuscarAtuacaoEmpresaSalao();

            if(AreaAtuacao == "SALÃO DE BELEZA" || AreaAtuacao == "PRESTAÇÃO DE SERVIÇO")
            {
                cbOpcao.Visible = false;
                lbl_Informacao.Text = "Código do serviço";
                btn_BuscarProdutos.Text = "Serviços - [F2]";
                this.btn_BuscarProdutos.Image = global::CaixaFacil.Properties.Resources.Very_Basic_Services_icon__1_;
                btn_BuscarPreços.Visible = false;
                btn_BuscarServiço.Visible = false;
                Lbl_Titulo.Text = "P.D.S";
                cbOpcao.Checked = false;
                this.btn_BuscarProdutos.Size = new System.Drawing.Size(164, 60);
                this.btn_BuscarProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn_BuscarProdutos.TextAlign = ContentAlignment.MiddleCenter;
                this.groupBox4.Size = new System.Drawing.Size(785, 93);
                this.Text = "P.D.S";              
               lblValorTotalVenda.Text = "Valor Total do serviço: ";
            }
        }

       private void FrmVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                btn_NovoCadastro_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F1)
            {
                btn_ContasClientes_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                btn_BuscarProdutos_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btn_BuscarPreços_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btn_VendaVista_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btn_PagamentoParcial_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btn_VenderPrazo_Click(sender, e);
            }
            else if (Keys.F7 == e.KeyCode)
            {
                btn_VenderParcelado_Click(sender, e);
            }
            else if (Keys.F8 == e.KeyCode)
            {
                btnPagamentoCartao_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btn_CancelarVenda_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btn_BuscarServiço_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (txt_Codigo_Barra.Text == "" || txt_Codigo_Barra.Text != "")
                {

                    switch (opcao)
                    {
                        case "true":
                            cbOpcao.Checked = true;
                            opcao = "false";
                            break;
                        case "false":
                            cbOpcao.Checked = false;
                            opcao = "true";
                            break;
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_Sair_Click(sender, e);
            }
            //else if (Control.ModifierKeys == Keys.Alt && e.KeyCode == Keys.F4)
            //{
                
            //}
        }

        private void btn_BuscarProdutos_Click(object sender, EventArgs e)
        {
            btn_Remover.Enabled = false;
            if (AreaAtuacao != "SALÃO DE BELEZA" && AreaAtuacao != "PRESTAÇÃO DE SERVIÇO")
            {
                FrmPesquisarProdutos produtos = new FrmPesquisarProdutos();
                produtos.ShowDialog();
                if (txt_Quantidade.Text != "")
                {
                    CodigoBarra = txt_Codigo_Barra.Text;
                    Quantidade = int.Parse(txt_Quantidade.Text);
                    if (produtos.ID_PRODUTO != null)
                    {
                        produto.id = int.Parse(produtos.ID_PRODUTO);
                        if (produto.ConsultarProduto() == true)
                        {
                            CodigoProduto = produto.id.ToString();
                            Descricao = produto.descricao;
                            Unidade = produto.unidade;
                            EstoqueAtual = produto.estoqueAtual;
                            EstoqueMinimo = produto.estoqueMinimo;
                            ValorVenda = produto.valorVenda;
                            Subtotal = decimal.Parse(txt_Quantidade.Text.Trim()) * ValorVenda;
                            LucroVenda = produto.lucro * Quantidade;
                            LucroTotal += LucroVenda;

                            if (EstoqueAtual == 0)
                            {
                                MessageBox.Show("O produto não possui estoque para esta quantidade!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_Codigo_Barra.Focus();
                            }
                            else if (EstoqueAtual < Quantidade)
                            {
                                MessageBox.Show("A quantidade exigida é maior que o estoque atual gravada no banco de dados. Por favor Atualize o estoque!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                            }
                            else
                            {
                                DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, txt_Quantidade.Text.Trim(), Unidade, ValorVenda, Subtotal);
                                ValorTotal = ValorTotal + Subtotal;
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                                txt_Quantidade.Text = "1";
                                DGV_ItensVenda.CurrentRow.Selected = false;
                                atualizarEstoque_CodigoProduto();
                                produto.ConsultarProduto();
                                EstoqueAtual = produto.estoqueAtual;
                                if (EstoqueAtual == 0)
                                {
                                    MessageBox.Show("Quantidade do produto no estoque esgotou! Atualize o estoque no sistema!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else if (EstoqueAtual <= EstoqueMinimo)
                                {
                                    MessageBox.Show("A quantidade atual do produto está chegando no ponto crítico!Atualize se necessário o estoque no sistema! Quantidade atual: " + EstoqueAtual, "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                    soma = ValorTotal;
                    ValorTotal = soma;
                    txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
                }
                else
                {
                    MessageBox.Show("Insira a quantidade! Campo obrigatório!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_Quantidade.Focus();
                }
            }
            else
            {
                FrmPesquisarServico Servico = new FrmPesquisarServico();
                Servico.ShowDialog();
                if (txt_Quantidade.Text != "")
                {
                    CodigoBarra = txt_Codigo_Barra.Text;
                    Quantidade = int.Parse(txt_Quantidade.Text);
                    if (Servico.Codigo != null)
                    {
                        produto.id = int.Parse(Servico.Codigo);
                        if (produto.ConsultarProduto() == true)
                        {
                            CodigoProduto = produto.id.ToString();
                            Descricao = produto.descricao;
                            Unidade = produto.unidade;
                            EstoqueAtual = produto.estoqueAtual;
                            EstoqueMinimo = produto.estoqueMinimo;
                            ValorVenda = produto.valorVenda;
                            Unidade = produto.unidade;
                            Subtotal = decimal.Parse(txt_Quantidade.Text.Trim()) * ValorVenda;
                            LucroVenda = produto.lucro * Quantidade;
                            LucroTotal += LucroVenda;

                            if (EstoqueAtual == 0 && Unidade != "Serviço")
                            {
                                MessageBox.Show("O produto não possui estoque para esta quantidade!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_Codigo_Barra.Focus();
                            }
                            else if (EstoqueAtual < Quantidade && Unidade != "Serviço")
                            {
                                MessageBox.Show("A quantidade exigida é maior que o estoque atual gravada no banco de dados. Por favor Atualize o estoque!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                            }
                            else
                            {
                                DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, txt_Quantidade.Text.Trim(), Unidade, ValorVenda, Subtotal);
                                ValorTotal = ValorTotal + Subtotal;
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                                txt_Quantidade.Text = "1";
                                DGV_ItensVenda.CurrentRow.Selected = false;
                                atualizarEstoque_CodigoProduto();
                                produto.ConsultarProduto();
                                EstoqueAtual = produto.estoqueAtual;
                                if (EstoqueAtual == 0 && Unidade != "Serviço")
                                {
                                    MessageBox.Show("Quantidade do produto no estoque esgotou! Atualize o estoque no sistema!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else if (EstoqueAtual <= EstoqueMinimo && Unidade != "Serviço")
                                {
                                    MessageBox.Show("A quantidade atual do produto está chegando no ponto crítico!Atualize se necessário o estoque no sistema! Quantidade atual: " + EstoqueAtual, "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                    soma = ValorTotal;
                    ValorTotal = soma;
                    txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
                }
                else
                {
                    MessageBox.Show("Insira a quantidade! Campo obrigatório!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_Quantidade.Focus();
                }                
            }
        }
           

        private void btn_BuscarPreços_Click(object sender, EventArgs e)
        {
            FrmPrecosProdutos precosProdutos = new FrmPrecosProdutos();
            precosProdutos.ShowDialog();
            if (txt_Quantidade.Text != "")
            {
                Quantidade = int.Parse(txt_Quantidade.Text);
                if (precosProdutos.Codigo >= 1)
                {
                    produto.id = precosProdutos.Codigo;
                    if (produto.ConsultarProduto() == true)
                    {
                        CodigoProduto = produto.id.ToString();
                        Descricao = produto.descricao;
                        Unidade = produto.unidade;
                        EstoqueAtual = produto.estoqueAtual;
                        EstoqueMinimo = produto.estoqueMinimo;
                        ValorVenda = produto.valorVenda;
                        Subtotal = decimal.Parse(txt_Quantidade.Text.Trim()) * ValorVenda;
                        LucroVenda = produto.lucro * Quantidade;
                        LucroTotal += LucroVenda;

                        if (EstoqueAtual == 0)
                        {
                            MessageBox.Show("O produto não possui estoque para esta quantidade!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_Codigo_Barra.Focus();
                        }
                        else if (EstoqueAtual < Quantidade)
                        {
                            MessageBox.Show("A quantidade exigida é maior que o estoque atual gravada no banco de dados. Por favor Atualize o estoque!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_Codigo_Barra.Clear();
                            txt_Codigo_Barra.Focus();
                        }
                        else
                        {
                            DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, txt_Quantidade.Text.Trim(), Unidade, ValorVenda, Subtotal);
                            ValorTotal = ValorTotal + Subtotal;
                            txt_Codigo_Barra.Clear();
                            txt_Codigo_Barra.Focus();
                            txt_Quantidade.Text = "1";
                            DGV_ItensVenda.CurrentRow.Selected = false;
                            atualizarEstoque_CodigoProduto();
                            produto.ConsultarProduto();
                            EstoqueAtual = produto.estoqueAtual;
                            if (EstoqueAtual == 0)
                            {
                                MessageBox.Show("Quantidade do produto no estoque esgotou! Atualize o estoque no sistema!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (EstoqueAtual <= EstoqueMinimo)
                            {
                                MessageBox.Show("A quantidade atual do produto está chegando no ponto crítico! Atualize se necessário o estoque no sistema! Quantidade atual: " + EstoqueAtual, "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                soma = ValorTotal;
                ValorTotal = soma;
                txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
            }
            else
            {
                MessageBox.Show("Insira a quantidade! Campo obrigatório!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Quantidade.Focus();
            }
            btn_Remover.Enabled = false;
        }
       
        // Instância da classe Produto e categoria
        ClassProduto produto = new ClassProduto();
        ClassCategoria categoria = new ClassCategoria();

        //declarações de vaiáveis
        string Descricao = null;
        decimal ValorVenda = 0.00m;
        decimal Subtotal;
        decimal sub;
        decimal ValorTotal = 0.00m;
        string Unidade;
        decimal soma = 0;
        decimal ValorSubt;
        string CodigoProduto;
        decimal LucroVenda;
        decimal LucroTotal;
        private void btn_Adcionar_Click(object sender, EventArgs e)
        {
            AdicionarItens();
        }
        private void atualizarEstoque_CodigoProduto()
        {
            produto.id = int.Parse(CodigoProduto);
            produto.ConsultarProduto();

            EstoqueAtual = produto.estoqueAtual;
            EstoqueAtualizado = EstoqueAtual - Quantidade;
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update Produto set EstoqueAtual  = " + EstoqueAtualizado + "where id_Produto = @id and Unidade <> 'Serviço'";
            SqlCommand command = new SqlCommand(_sql, conexao);
            command.Parameters.AddWithValue("@id", CodigoProduto);
            command.CommandText = _sql;
            try
            {
                conexao.Open();
                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }
        private void AtualizarEstoque_CodigoBarra()
        {
            produto.codigoBarra =CodigoBarra;
            produto.ConsultarCodigoBarra();

            EstoqueAtual = produto.estoqueAtual;          
            EstoqueAtualizado = EstoqueAtual - Quantidade;
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update Produto set EstoqueAtual  = " + EstoqueAtualizado + "where codigoBarra = @CodigoBarra and Unidade <> 'Serviço'";
            SqlCommand command = new SqlCommand(_sql, conexao);
            command.Parameters.AddWithValue("@CodigoBarra", CodigoBarra);
            command.CommandText = _sql;
            try
            {
                conexao.Open();
                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void AdicionarItens()
        {
            btn_Remover.Enabled = false;
            if (txt_Quantidade.Text != "")
            {
                CodigoBarra = txt_Codigo_Barra.Text;
                Quantidade = int.Parse(txt_Quantidade.Text);

                if (txt_Codigo_Barra.Text != string.Empty)
                {
                    if (cbOpcao.Checked)
                    {
                        produto.codigoBarra = txt_Codigo_Barra.Text.Trim();
                        if (produto.ConsultarCodigoBarra() == true)
                        {
                            CodigoProduto = produto.id.ToString();
                            Descricao = produto.descricao;
                            ValorVenda = produto.valorVenda;
                            EstoqueAtual = produto.estoqueAtual;
                            EstoqueMinimo = produto.estoqueMinimo;
                            Unidade = produto.unidade;
                            int Id_Categoria = produto.id_categoria;
                            categoria.id = Id_Categoria;
                            categoria.Cosultar();
                            string descricaoCategoria = categoria.Descricao;
                            LucroVenda = produto.lucro * Quantidade;
                            LucroTotal += LucroVenda;
                            Subtotal = decimal.Parse(txt_Quantidade.Text.Trim()) * ValorVenda;

                            if (EstoqueAtual == 0 && descricaoCategoria != "Serviço")
                            {
                                MessageBox.Show("O produto não possui estoque para esta quantidade!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                            }
                            else
                            {
                                DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, txt_Quantidade.Text.Trim(), Unidade, ValorVenda, Subtotal);
                                ValorTotal = ValorTotal + Subtotal;
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                                txt_Quantidade.Text = "1";
                                DGV_ItensVenda.CurrentRow.Selected = false;

                                soma = ValorTotal;
                                ValorTotal = soma;
                                txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
                                AtualizarEstoque_CodigoBarra();
                                produto.id = int.Parse(CodigoProduto);
                                produto.ConsultarProduto();
                                EstoqueAtual = produto.estoqueAtual;
                                if (EstoqueAtual == 0 && descricaoCategoria != "Serviço")
                                {
                                    MessageBox.Show("Quantidade do produto no estoque esgotou! Atualize o estoque no sistema!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else if (EstoqueAtual <= EstoqueMinimo && descricaoCategoria != "Serviço")
                                {
                                    MessageBox.Show("A quantidade atual do produto está chegando no ponto crítico! Atualize se necessário o estoque no sistema! Quantidade atual: " + EstoqueAtual, "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado!", "Aviso do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_Codigo_Barra.Clear();
                            txt_Codigo_Barra.Focus();
                        }
                    }
                    else
                    {
                        produto.id = long.Parse(txt_Codigo_Barra.Text.Trim());
                        if (produto.ConsultarProduto() == true)
                        {
                            CodigoProduto = produto.id.ToString();
                            Descricao = produto.descricao;
                            ValorVenda = produto.valorVenda;
                            EstoqueAtual = produto.estoqueAtual;
                            EstoqueMinimo = produto.estoqueMinimo;
                            Unidade = produto.unidade;
                            int Id_Categoria = produto.id_categoria;
                            categoria.id = Id_Categoria;
                            categoria.Cosultar();
                            string descricaoCategoria = categoria.Descricao;

                            LucroVenda = produto.lucro * Quantidade;
                            LucroTotal += LucroVenda;

                            Subtotal = decimal.Parse(txt_Quantidade.Text.Trim()) * ValorVenda;

                            if (EstoqueAtual == 0 && descricaoCategoria != "Serviço")
                            {
                                MessageBox.Show("O produto não possui estoque para esta quantidade!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                            }
                            else if (EstoqueAtual < Quantidade && descricaoCategoria != "Serviço")
                            {
                                MessageBox.Show("A quantidade exigida é maior que o estoque atual gravada no banco de dados. Por favor Atualize o estoque ou verifique se houve erro de digitação!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                            }
                            else
                            {
                                DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, txt_Quantidade.Text.Trim(), Unidade, ValorVenda, Subtotal);
                                ValorTotal = ValorTotal + Subtotal;
                                txt_Codigo_Barra.Clear();
                                txt_Codigo_Barra.Focus();
                                txt_Quantidade.Text = "1";
                                DGV_ItensVenda.CurrentRow.Selected = false;

                                soma = ValorTotal;
                                ValorTotal = soma;
                                txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
                                atualizarEstoque_CodigoProduto();
                                produto.ConsultarProduto();
                                EstoqueAtual = produto.estoqueAtual;
                                if (EstoqueAtual == 0 && descricaoCategoria != "Serviço")
                                {
                                    MessageBox.Show("Quantidade do produto no estoque esgotou! Atualize o estoque no sistema!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else if (EstoqueAtual <= EstoqueMinimo && descricaoCategoria != "Serviço")
                                {
                                    MessageBox.Show("A quantidade atual do produto está chegando no ponto crítico! Atualize se necessário o estoque no sistema! Quantidade atual: " + EstoqueAtual, "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado!", "Aviso do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_Codigo_Barra.Focus();
                            txt_Codigo_Barra.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira a quantidade! Campo obrigatório!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Quantidade.Focus();
            }
        }         
      
        private void AtualizarEstoque_CancelarItem()
        {
            produto.id = int.Parse(CodigoProduto);
            produto.ConsultarProduto();

            EstoqueAtual = produto.estoqueAtual;
            EstoqueAtualizado = EstoqueAtual + QuantidadeItens;
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update Produto set EstoqueAtual  = " + EstoqueAtualizado + "where Id_Produto = @id_Produto and Unidade <> 'Serviço'";
            SqlCommand command = new SqlCommand(_sql, conexao);
            command.Parameters.AddWithValue("@Id_Produto", CodigoProduto);
            command.CommandText = _sql;
            try
            {
                conexao.Open();
                command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }
        private void RemoverItens()
        {
            try
            {
                if (DGV_ItensVenda.Rows.Count >= 0)
                {

                    DGV_ItensVenda.Rows.Remove(DGV_ItensVenda.CurrentRow);
                    ValorSubt = ValorTotal - sub;
                    txt_ValorTotal.Text = "R$ " + ValorSubt.ToString();
                    txt_Codigo_Barra.Focus();
                    btn_Remover.Enabled = false;
                    ValorTotal = ValorSubt;
                    AtualizarEstoque_CancelarItem();
                    DiminuirLucro();
                }

                DGV_ItensVenda.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DiminuirLucro()
        {
            produto.id = int.Parse(CodigoProduto);
            produto.ConsultarProduto();
            LucroVenda = produto.lucro * QuantidadeItens;
            LucroTotal -= LucroVenda;
        }
        private void cbOpcao_CheckedChanged(object sender, EventArgs e)
        {
            txt_Codigo_Barra.Focus();
            txt_Codigo_Barra.Clear();
        }

        private void txt_Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdicionarItens();
            }
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            RemoverItens(); 
        }       

        private void HabilitarFerramentas()
        {
            btn_Adcionar.Enabled = true;
            btn_ContasClientes.Enabled = true;
            btn_BuscarPreços.Enabled = true;
            btn_BuscarProdutos.Enabled = true;
            btn_CancelarVenda.Enabled = true;
            btn_Fechar.Enabled = true;
            btn_VendaVista.Enabled = true;
            btn_Minimizar.Enabled = true;
            btn_NovoCadastro.Enabled = true;
            btn_PagamentoParcial.Enabled = true;            
            btn_Sair.Enabled = true;
            btn_VenderParcelado.Enabled = true;
            btn_VenderPrazo.Enabled = true;
            txt_Codigo_Barra.Enabled = true;
            txt_Quantidade.Enabled = true;
            txt_ValorTotal.Enabled = true;
            btn_BuscarServiço.Enabled = true;
            btnPagamentoCartao.Enabled = true;
            cbOpcao.Enabled = true;
            lbl_Informacao.Enabled = true;
            lbl_Quantidade.Enabled = true;
            DGV_ItensVenda.Enabled = true;
            txt_CodigoVenda.Enabled = true;
            id_Cliente = "1";
            LucroTotal = 0.00m;
            ValorPago = 0.00m;
            ValorCaixa = 0.00m;
            valorNCaixa = 0.00m;
            descontoDinheiro = 0.00m;
            DescontoPorcento = 0.00m;
            ValorDescontoPorcento = 0.00m;
            ValorDesconto = 0.00m;
            valorParcelas = 0.00m;
            ValorRestante = 0.00m;
            ValorAbatido = 0.00m;
            Valor = 0.00m;
        }

        private void Sair()
        {
            if (DGV_ItensVenda.Rows.Count > 0)
            {
                DialogResult dr;

                if(AreaAtuacao == "PRESTAÇÃO DE SERVIÇO" || AreaAtuacao=="SALÃO DE BELEZA")
                {
                    dr = MessageBox.Show("Existe itens de serviços em aberto. Deseja mesmo sair sem concluir?", "Finalizando o sistema...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    dr = MessageBox.Show("Existe itens para venda em aberto. Deseja mesmo sair sem concluir a venda?", "Finalizando o sistema...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (dr == DialogResult.Yes)
                {
                    Fechar = true;
                    atualizarEstoque_VendaCancelado();
                    this.Close();
                }
                else
                {
                    Fechar = false;
                }
            }
            else if (DGV_ItensVenda.Rows.Count == 0)
            {
                Fechar = true;
                this.Close();
            }
        }
        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Sair();
        }
        private void atualizarEstoque_VendaCancelado()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            for (int i = 0; i < DGV_ItensVenda.Rows.Count; i++)
            {
                SqlCommand command = new SqlCommand("Update Produto set EstoqueAtual  = EstoqueAtual + " + DGV_ItensVenda.Rows[i].Cells["ColumnQuantidade"].Value + " where Unidade <> 'Serviço' and id_Produto = " + DGV_ItensVenda.Rows[i].Cells[0].Value, conexao);


                try
                {
                    conexao.Open();
                    command.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexao.Close();
                }
            }
        }
        private void btn_CancelarVenda_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count > 0)
            {
                DialogResult dr;
                if (AreaAtuacao == "PRESTAÇÃO DE SERVIÇO" || AreaAtuacao == "SALÃO DE BELEZA")
                {
                    dr = MessageBox.Show("Deseja mesmo cancelar?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    dr = MessageBox.Show("Deseja mesmo cancelar a venda?", "Cancelamento da venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (dr == DialogResult.Yes)
                {
                    atualizarEstoque_VendaCancelado();
                    DGV_ItensVenda.Rows.Clear();
                    btn_Remover.Enabled = false;
                    txt_Codigo_Barra.Clear();
                    txt_Codigo_Barra.Focus();
                    txt_Quantidade.Text = "1";
                    ValorTotal = 0;
                    ValorVenda = 0;
                    txt_ValorTotal.Text = "R$ 0,00";
                    LucroTotal = 0.00m;
                    LucroVenda = 0.00m;
                    txt_Codigo_Barra.Focus();
                }               
            }
            else
            {
                MessageBox.Show("Não há item(ns) para ser cancelada! Verifique!", "Aviso do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }
        
        private void txt_Quantidade_TextChanged(object sender, EventArgs e)
        {
            if (txt_Quantidade.Text == "0")
                txt_Quantidade.Text = "1";
        }

        private void btn_PagamentoParcial_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count >= 1)
            {
                FrmVendaParcial vendaParcial = new FrmVendaParcial(ValorTotal);
                vendaParcial.ShowDialog();
                if (vendaParcial.vendaConfirmada)
                {
                    id_Cliente = vendaParcial.id_Cliente;
                    ValorRestante = vendaParcial.ValorRestante;
                    ValorAbatido = vendaParcial.ValorAbatido;

                    EfetuarAbatimento();
                    InserirItensvenda();
                    
                    loadTelaInicial();
                }
                
            }
            else
            {
                MessageBox.Show("Não há itens para venda! Verifique...", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }

        private void btn_NovoCadastro_Click(object sender, EventArgs e)
        {
            frmNovoCadastro novoCadastro = new frmNovoCadastro();
            novoCadastro.ShowDialog();          
        }

        private void txt_Quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ContasClientes_Click(object sender, EventArgs e)
        {
            FrmContasClientes contasClientes = new FrmContasClientes();
            contasClientes.ShowDialog();
        }

        FrmVendaParcelas vendaParcelas;
        private void btn_VenderParcelado_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count >= 1)
            {
                vendaParcelas = new FrmVendaParcelas(ValorTotal);
                vendaParcelas.ShowDialog();
                if (vendaParcelas.vendaConfirmada)
                {
                    id_Cliente = vendaParcelas.idCliente.ToString();
                    BuscarInformacaoEmpresa();
                    GerarParcelas();
                    if (vendaParcelas.repasseGerada)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        FrmRelatorioParcelas relatorioParcelas = new FrmRelatorioParcelas(txt_CodigoVenda.Text, NomeFantasia, Endereco, Numero, Cidade, Estado, Telefone, CNPJ);
                        relatorioParcelas.ShowDialog();
                        this.Cursor = Cursors.Default;

                    }
                   
                    InserirItensvenda();

                    loadTelaInicial();
                }
            }
            else
            {
                MessageBox.Show("Não há itens para a venda! Verifique...", "Aviso do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }

        private void btn_VenderPrazo_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count >= 1)
            {
                FrmVendaPrazo vendaPrazo = new FrmVendaPrazo(ValorTotal);
                vendaPrazo.ShowDialog();
                if (vendaPrazo.vendaConfirmada)
                {
                    id_Cliente = vendaPrazo.id_Cliente;
                    DataVencimento = vendaPrazo.Vencimento;
                    EfetuarVendaPrazo();
                    InserirItensvenda();
                    if (vendaPrazo.relatorioPedido)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        BuscarInformacaoEmpresa();                     
                        FrmRelatorioPrazo relatorioPrazo = new FrmRelatorioPrazo(txt_CodigoVenda.Text, NomeFantasia, Endereco, Numero, Cidade, Estado, Telefone, CNPJ, Settings.Default["TempoPrazo"].ToString(), Bairro);
                        relatorioPrazo.ShowDialog();
                        this.Cursor = Cursors.Default;
                    }

                    loadTelaInicial();
                }
            }
            else
            {
                MessageBox.Show("Não há itens para venda! Verifique...", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }

        private void dataGridView_ItensVenda_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = DGV_ItensVenda.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                return;
            }
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql, codigoVenda, id_Cliente = "1";

        int EstoqueAtual, EstoqueAtualizado,QuantidadeItens;
        private void ConfirmarVenda()
        {
            EfetuarVendaVista();
            InserirItensvenda();            
        }

        Empresa empresa = new Empresa();
        
        private void BuscarInformacaoEmpresa()
        {
            empresa.Consultar();
            NomeFantasia = empresa.nomeFantasia;
            Cidade = empresa.cidade;
            Bairro = empresa.bairro;
            Endereco = empresa.endereco;
            Numero = Convert.ToString(empresa.numero);
            CNPJ = empresa.CNPJ;
            Estado = empresa.estado;
            Telefone = empresa.telefone;
            venda.Consultar();
            HoraVenda = venda.horaVenda;            
        }

        string cliente;

        private void btn_VendaVista_Click(object sender, EventArgs e)
        {           
            if (DGV_ItensVenda.Rows.Count > 0)
            {
                FrmVendaVista vendaVista = new FrmVendaVista(ValorTotal);
                vendaVista.ShowDialog();
                if (vendaVista.vendaConfirmada)
                {
                    ValorDesconto = vendaVista.ValorDesconto;
                    descontoDinheiro = vendaVista.descontoDinheiro;
                   
                    if (!string.IsNullOrEmpty(vendaVista.id_Cliente))
                        id_Cliente = vendaVista.id_Cliente; 
                    
                    ConfirmarVenda();
                  
                    if (vendaVista.CupomPedido || vendaVista.promissoriaPedido)
                    {
                        BuscarInformacaoEmpresa();
                        Cursor = Cursors.WaitCursor;
                        
                       
                        if(vendaVista.promissoriaPedido)
                        {
                            if (!string.IsNullOrEmpty(vendaVista.nomeCliente))
                            {
                                cliente = vendaVista.nomeCliente;
                            }

                            FrmReciboPagamento reciboPagamento = new FrmReciboPagamento(lbl_Hora.Text, ValorDesconto, NomeFantasia, Cidade, Endereco, Numero, CNPJ, cliente, lbl_Data.Text, lbl_atendente.Text, txt_CodigoVenda.Text);
                            reciboPagamento.ShowDialog();
                        }
                        else
                        {
                            FrmCupom cupom = new FrmCupom(int.Parse(txt_CodigoVenda.Text), lbl_Hora.Text, NomeFantasia, Cidade, Estado, Endereco, Numero, CNPJ, cliente, lbl_Data.Text, lbl_atendente.Text, txt_CodigoVenda.Text, vendaVista.ValorPago, vendaVista.troco, Bairro);
                            cupom.ShowDialog();
                        }

                        Cursor = Cursors.Default;
                    }

                    loadTelaInicial();
                }
            }
            else
            {
                MessageBox.Show("Não há itens para a venda! Verifique...", "Aviso do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }

       
             
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToLongTimeString();
        }
        
        private void GerarParcelas()
        {
            try
            {
                venda.Id = int.Parse(txt_CodigoVenda.Text.Trim());
                venda.parcelas = vendaParcelas.Parcelas.Rows.Count;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorTotal;
                venda.desconto = 0.00m;
                venda.id_cliente = vendaParcelas.idCliente;
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();

                foreach(DataRow dr in vendaParcelas.Parcelas.Rows)
                {
                    ParcelaVenda.vencimento = dr[1].ToString();
                    ParcelaVenda.valorParcelado = decimal.Parse(dr[2].ToString());
                    ParcelaVenda.id_Venda = int.Parse(txt_CodigoVenda.Text);
                    ParcelaVenda.dataPagamento = "";
                    ParcelaVenda.horaPagamento = "";
                    ParcelaVenda.N_Parcela = int.Parse(dr[0].ToString());
                    ParcelaVenda.inserirParcelas();
                }                

                valorNCaixa = vendaParcelas.valorEntrada;
                CaixaDia();
                GerenciarCaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            formaPagamento.descricao = "PARCELADO";
            formaPagamento.id_Venda = int.Parse(txt_CodigoVenda.Text.Trim());
            formaPagamento.InformarFormaPagamento();
            CaixaDia();
            GerenciarCaixa_V_Parcela();
        }

        private void GerenciarCaixa_V_Parcela()
        {
            decimal EntradaParcela = vendaParcelas.valorEntrada; 
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set ValorReceber = ValorReceber + @ValorReceber, EntradaParcela = EntradaParcela + @EntradaParcela where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorReceber", vendaParcelas.ValorParcelamento);
            comando.Parameters.AddWithValue("@EntradaParcela", EntradaParcela);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void CodigoVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select max(Id_Venda) from Venda";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() == DBNull.Value)
                {
                    codigoVenda = "1";
                }
                else
                {
                    Int32 cod = Convert.ToInt32(comando.ExecuteScalar()) + 1;
                    codigoVenda = cod.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        /*aqui verificamos a situação da compra a prestação do cliente 
      e pegamos a data de vencimento para comparação em otra parte do código*/
        string DataVencimento;

       private void VerificarSituacaoClienteParcela()
        {
           
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT Convert(Date, ParcelaVenda.DataVencimento, 103) as DataVencimento FROM Cliente INNER JOIN Venda ON Cliente.Id_Cliente = Venda.Id_Cliente INNER JOIN ParcelaVenda ON Venda.Id_Venda = ParcelaVenda.Id_Venda INNER JOIN FormaPagamento ON FormaPagamento.Id_Venda = Venda.Id_Venda WHERE (Cliente.Id_Cliente = @Id_Cliente) AND (FormaPagamento.Descricao = 'PARCELADO') AND (ParcelaVenda.DataPagamento = '')";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.Parameters.AddWithValue("@Id_Cliente", id_Cliente);
            comando.SelectCommand .CommandText= _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                DataVencimento = Tabela.Rows[0]["DataVencimento"].ToString();
            }
        }

        /*aqui verificamos a situação da compra a prazo do cliente 
        e pegamos a data de vencimento para comparação em otra parte do código*/
        string DatavencimentoPrazo;
        private void VerificarSituacaoClientePrazo()
        {

            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT Convert(Date, ParcelaVenda.DataVencimento, 103) as DataVencimento FROM Cliente INNER JOIN Venda ON Cliente.Id_Cliente = Venda.Id_Cliente INNER JOIN ParcelaVenda ON Venda.Id_Venda = ParcelaVenda.Id_Venda INNER JOIN FormaPagamento ON FormaPagamento.Id_Venda = Venda.Id_Venda WHERE (Cliente.Id_Cliente = @Id_Cliente) AND (FormaPagamento.Descricao = 'PRAZO') AND (ParcelaVenda.DataPagamento = '')";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.Parameters.AddWithValue("@Id_Cliente", id_Cliente);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                DatavencimentoPrazo = Tabela.Rows[0]["DataVencimento"].ToString();
            }
        }

        private void txt_NumeroParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       Venda venda = new Venda();

      //verifica a situação do cliente antes da conclusão da venda durante o prazo da última compra

        private void EfetuarVendaPrazo()
        {
            try
            {
                venda.Id = int.Parse(txt_CodigoVenda.Text.Trim());
                venda.parcelas = 1;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorTotal;
                venda.desconto = 0.00m;
                venda.id_cliente = int.Parse(id_Cliente);
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();

                ParcelaVenda.vencimento = DataVencimento;
                ParcelaVenda.valorParcelado = ValorTotal;
                ParcelaVenda.id_Venda = int.Parse(txt_CodigoVenda.Text);
                ParcelaVenda.dataPagamento = "";
                ParcelaVenda.horaPagamento = "";
                ParcelaVenda.N_Parcela = 1;
                ParcelaVenda.inserirParcelas();

                formaPagamento.descricao = "PRAZO";
                formaPagamento.id_Venda = int.Parse(txt_CodigoVenda.Text.Trim());
                formaPagamento.InformarFormaPagamento();
                CaixaDia();
                GerenciarCaixa_V_ReceberPrazo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void GerenciarCaixa_V_ReceberPrazo()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set ValorReceber = ValorReceber + @ValorReceber where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorReceber", ValorTotal);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }       
              
       PagamentoParcial PagamentoParcial = new PagamentoParcial();
       
        private void EfetuarAbatimento()
        {
            try
            {
                venda.Id = int.Parse(txt_CodigoVenda.Text.Trim());
                venda.parcelas = 1;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorTotal;
                venda.desconto = 0.00M;
                venda.id_cliente = int.Parse(id_Cliente);
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();

                formaPagamento.descricao = "PAGAMENTO PARCIAL";
                formaPagamento.id_Venda = int.Parse(txt_CodigoVenda.Text.Trim());
                formaPagamento.InformarFormaPagamento();

                PagamentoParcial.dataAbatimento = DateTime.Now.ToShortDateString();
                PagamentoParcial.valorRestante = ValorRestante;
                PagamentoParcial.id_Venda = int.Parse(txt_CodigoVenda.Text);
                PagamentoParcial.id_Cliente = int.Parse(id_Cliente);
                PagamentoParcial.CodigoIdPagamentoParcial();
                int id = PagamentoParcial.Id;
                PagamentoParcial.ConfirmarPagamentoParcial();
               
                PagamentoParcial.Id = id;
                PagamentoParcial.valorTotalAbatido = ValorAbatido;
                PagamentoParcial.dataAbatimento = DateTime.Now.ToShortDateString();
                PagamentoParcial.horaPagamento = DateTime.Now.ToLongTimeString();
                PagamentoParcial.InserirValorAbatido();
                valorNCaixa = ValorAbatido;
                CaixaDia();
                GerenciarCaixa();
                GerenciarCaixa_V_Parcial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem do sistema 'Gerenciamento Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerenciarCaixa_V_Parcial()
        {
            decimal ValorRecebidoParcial = ValorAbatido;
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set ValorReceber = ValorReceber + @ValorReceber, ValorRecebidoParcial = ValorRecebidoParcial + @ValorRecebidoParcial where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorReceber", ValorRestante);
            comando.Parameters.AddWithValue("@ValorRecebidoParcial", ValorRecebidoParcial);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }       
              
        private void FrmVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
           if(Fechar == false)
            {
                e.Cancel = true;
            }            
        }

        private void btn_GerarRepasse_Click(object sender, EventArgs e)
        {
          
                this.Cursor = Cursors.WaitCursor;
                BuscarInformacaoEmpresa();
                GerarParcelas();
                InserirItensvenda();
                FrmRelatorioParcelas relatorioParcelas = new FrmRelatorioParcelas(txt_CodigoVenda.Text, NomeFantasia, Endereco, Numero, Cidade, Estado, Telefone, CNPJ);
                relatorioParcelas.ShowDialog();
                this.Cursor = Cursors.Default;
                ValorTotal = 0.00m;
                DGV_ItensVenda.Rows.Clear();
                HabilitarFerramentas();
                CodigoVenda();
                txt_CodigoVenda.Text = codigoVenda;
                txt_ValorTotal.Text = "R$ 0,00";
        }

        ClassItensVenda itensVenda = new ClassItensVenda();
        ClassFormaPagamento formaPagamento = new ClassFormaPagamento();

       ClassParcelaVenda ParcelaVenda = new ClassParcelaVenda();
        ClassFluxoCaixa FluxoCaixa = new ClassFluxoCaixa();

        private void DGV_ItensVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Remover.Enabled = true;

            int Contlinhas = e.RowIndex;
            if (Contlinhas == -1)
            {
                btn_Remover.Enabled = false;
            }
            else 
            {
                DataGridViewRow linha = DGV_ItensVenda.Rows[e.RowIndex];
                CodigoProduto = linha.Cells[0].Value.ToString();
                sub = decimal.Parse(linha.Cells["ColumnSubTotal"].Value.ToString());
                QuantidadeItens = int.Parse(linha.Cells["ColumnQuantidade"].Value.ToString());
            }
        }

        private void btnPagamentoCartao_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count >= 1)
            {              
                FrmFormaPagamento pagamentoCartao = new FrmFormaPagamento(txt_CodigoVenda.Text, ValorTotal, LucroTotal, Id_Usuario);
                pagamentoCartao.ShowDialog();
                if (pagamentoCartao.Confirmacao == "Venda realizada com sucesso!")
                {
                    InserirItensvenda();
                    if (pagamentoCartao.pedidoNotaPromissoria)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        BuscarInformacaoEmpresa();
                        decimal valorDesconto = pagamentoCartao.Desconto;
                        FrmReciboPagamento reciboPagamento = new FrmReciboPagamento(lbl_Hora.Text, valorDesconto, NomeFantasia, Cidade, Endereco, Numero, CNPJ, cliente, lbl_Data.Text, lbl_atendente.Text, txt_CodigoVenda.Text);
                        reciboPagamento.ShowDialog();
                        this.Cursor = Cursors.Default;
                        ValorTotal = 0.00m;
                        txt_Codigo_Barra.Focus();
                    }

                    loadTelaInicial();
                }
            }
            else
                MessageBox.Show("Não há itens para venda! Verifique...", "Mensagem do sistema 'Gerenciamento Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void loadTelaInicial()
        {
            DGV_ItensVenda.Rows.Clear();
            CodigoVenda();
            txt_CodigoVenda.Text = codigoVenda;
            ValorTotal = 0.00M;
            txt_ValorTotal.Text = "R$ " + ValorTotal;
            txt_Codigo_Barra.Focus();
            LucroTotal = 0.00m;
            ValorCaixa = 0.00m;
        }

        private void txt_Codigo_Barra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbOpcao.Checked == false)
            {
                try
                {
                    if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
                    {
                        e.Handled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_BuscarServiço_Click(object sender, EventArgs e)
        {
            FrmPesquisarServico pesquisarServico = new FrmPesquisarServico();
            pesquisarServico.ShowDialog();
            if (txt_Quantidade.Text != "")
            {
                if (pesquisarServico.Codigo != null)
                {
                    produto.id = int.Parse(pesquisarServico.Codigo);
                    if (produto.ConsultarProduto() == true)
                    {
                        CodigoProduto = produto.id.ToString();
                        Descricao = produto.descricao;
                        Unidade = produto.unidade;
                        EstoqueAtual = produto.estoqueAtual;
                        EstoqueMinimo = produto.estoqueMinimo;
                        ValorVenda = produto.valorVenda;
                        Subtotal = decimal.Parse(txt_Quantidade.Text.Trim()) * ValorVenda;
                        LucroVenda = produto.lucro * Quantidade;
                        LucroTotal += LucroVenda;


                        DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, txt_Quantidade.Text.Trim(), Unidade, ValorVenda, Subtotal);
                        ValorTotal = ValorTotal + Subtotal;
                        txt_Codigo_Barra.Clear();
                        txt_Codigo_Barra.Focus();
                        txt_Quantidade.Text = "1";
                        DGV_ItensVenda.CurrentRow.Selected = false;
                        atualizarEstoque_CodigoProduto();
                        produto.ConsultarProduto();
                        EstoqueAtual = produto.estoqueAtual;
                    }
                }
                soma = ValorTotal;
                ValorTotal = soma;
                txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
            }
            else
            {
                MessageBox.Show("Insira a quantidade! Campo obrigatório!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Quantidade.Focus();
            }
            btn_Remover.Enabled = false;
        }

        private void EfetuarVendaVista()
        {           
            try
            {
                venda.Id = int.Parse(txt_CodigoVenda.Text.Trim());
                venda.parcelas = Parcela;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorDesconto;
                venda.desconto = descontoDinheiro;
                venda.id_cliente = int.Parse(id_Cliente);
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();                              
                formaPagamento.descricao = "VISTA";
                formaPagamento.id_Venda = int.Parse(txt_CodigoVenda.Text.Trim());
                formaPagamento.InformarFormaPagamento();
                valorNCaixa = ValorDesconto;
                CaixaDia();
                GerenciarCaixa();
                AtualizarValorDescontoCaixa();
                InformarValorRecebidoVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AtualizarValorDescontoCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set Desconto = Desconto + @Desconto where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@Desconto", descontoDinheiro);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void CaixaDia()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select ValorCaixa from FluxoCaixa where DataSaida = ''";
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
                ValorCaixa = decimal.Parse(Tabela.Rows[0]["ValorCaixa"].ToString());
        }

        private void GerenciarCaixa()
        {
            ValorCaixa += valorNCaixa;
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set ValorCaixa = @ValorCaixa where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorCaixa", ValorCaixa);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void InformarValorRecebidoVista()
        {
            decimal ValorVista = ValorDesconto;
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set ValorRecebidoVista = ValorRecebidoVista + @ValorRecebidoVista where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorRecebidoVista", ValorVista);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void InserirItensvenda()
        {
           for (int i = 0; i < DGV_ItensVenda.Rows.Count; i++)
            {
                produto.id = int.Parse(DGV_ItensVenda.Rows[i].Cells[0].Value.ToString());
                produto.ConsultarProduto();
                LucroVenda = produto.lucro * int.Parse(DGV_ItensVenda.Rows[i].Cells["ColumnQuantidade"].Value.ToString());
                
                itensVenda.id_venda = int.Parse(txt_CodigoVenda.Text);
                itensVenda.Valor = decimal.Parse(DGV_ItensVenda.Rows[i].Cells["ColumnSubTotal"].Value.ToString());
                itensVenda.id_produto = int.Parse(DGV_ItensVenda.Rows[i].Cells["ColumnCodigo"].Value.ToString());
                itensVenda.quantidade = int.Parse(DGV_ItensVenda.Rows[i].Cells["ColumnQuantidade"].Value.ToString());
                itensVenda.LucroItens = LucroVenda;
                itensVenda.AdicionarItensVenda();
            }
        }
        private void txt_Codigo_Barra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdicionarItens();
            }
        }    
    }
}