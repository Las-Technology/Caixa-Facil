using CaixaFacil.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVenda : Form
    {
        string AreaAtuacao, opcao = "true", CodigoBarra;
        string HoraVenda, NomeFantasia, Cidade, Numero, Endereco, CNPJ, Telefone, Estado, Bairro;
        int Id_Usuario, X = 0, Y = 0, EstoqueMinimo, Quantidade;
        decimal ValorCaixa, valorNCaixa, descontoDinheiro, ValorDesconto;
        decimal ValorRestante, ValorAbatido = 0.00m;
        bool Fechar = false;

        public FrmVenda(int Id_Usuario, string Usuario)
        {
            InitializeComponent();
            lbl_atendente.Text = Usuario;
            this.Id_Usuario = Id_Usuario;
            nd_Quantidade.Value = 1;
            lbl_Data.Text = DateTime.Now.ToLongDateString();
            lbl_Hora.Text = DateTime.Now.ToLongTimeString();
            txt_ValorTotal.Text = "R$ 0,00";
            CodigoVenda();
            lblCodigoVenda.Text = codigoVenda;
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

            if (AreaAtuacao == "SALÃO DE BELEZA" || AreaAtuacao == "PRESTAÇÃO DE SERVIÇO")
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
                this.groupBox4.Size = new System.Drawing.Size(757, 93);
                this.Text = "P.D.S";
                lblValorTotalVenda.Text = "Valor Total do serviço: ";
                btnDevolução.Visible = false;
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
            else if (e.KeyCode == Keys.F7)
            {
                btnVendaMista_Click(sender, e);
            }
            else if (Keys.F8 == e.KeyCode)
            {
                btn_VenderParcelado_Click(sender, e);
            }
            else if (Keys.F9 == e.KeyCode)
            {
                btnPagamentoCartao_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btn_CancelarVenda_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
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
            else if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D)
            {
                btnDevolução_Click(sender, e);
            }
        }

        private void btn_BuscarProdutos_Click(object sender, EventArgs e)
        {
            btn_Remover.Enabled = false;
            Quantidade = int.Parse(nd_Quantidade.Value.ToString());
            if (AreaAtuacao != "SALÃO DE BELEZA" && AreaAtuacao != "PRESTAÇÃO DE SERVIÇO")
            {
                FrmPesquisarProdutos produtos = new FrmPesquisarProdutos();
                produtos.ShowDialog();
                if (produtos.ID_PRODUTO != null)
                {
                    produto.id = int.Parse(produtos.ID_PRODUTO);
                    produto.ConsultarCodigoProduto();
                    AdicionarItensValue();
                }
            }
            else
            {
                FrmPesquisarServico Servico = new FrmPesquisarServico();
                Servico.ShowDialog();
                CodigoBarra = txt_Codigo_Barra.Text;
                Quantidade = int.Parse(nd_Quantidade.Value.ToString());
                if (Servico.Codigo != null)
                {
                    produto.id = int.Parse(Servico.Codigo);
                    if (produto.ConsultarProduto())
                    {
                        CodigoProduto = produto.id.ToString();
                        Descricao = produto.descricao;
                        Unidade = produto.unidade;
                        EstoqueAtual = produto.estoqueAtual;
                        EstoqueMinimo = produto.estoqueMinimo;
                        ValorVenda = produto.valorVenda;
                        Unidade = produto.unidade;
                        Subtotal = nd_Quantidade.Value * ValorVenda;
                        LucroVenda = produto.lucro * Quantidade;
                        LucroTotal += LucroVenda;

                        DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, nd_Quantidade.Value, Unidade, ValorVenda, Subtotal);
                        ValorTotal = ValorTotal + Subtotal;
                        txt_Codigo_Barra.Clear();
                        txt_Codigo_Barra.Focus();
                        nd_Quantidade.Value = 1;
                        DGV_ItensVenda.CurrentRow.Selected = false;
                    }
                }
                soma = ValorTotal;
                ValorTotal = soma;
                txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
            }
        }


        private void btn_BuscarPreços_Click(object sender, EventArgs e)
        {
            FrmPrecosProdutos precosProdutos = new FrmPrecosProdutos();
            precosProdutos.ShowDialog();

            Quantidade = int.Parse(nd_Quantidade.Value.ToString());
            if (precosProdutos.Codigo >= 1)
            {
                produto.id = precosProdutos.Codigo;
                produto.ConsultarCodigoProduto();
                AdicionarItensValue();
            }
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

        Estoque estoque = new Estoque();

        private void atualizarEstoque_CodigoProduto()
        {
            try
            {
                foreach (DataGridViewRow row in DGV_ItensVenda.Rows)
                {
                    estoque.id = int.Parse(row.Cells["ColumnCodigo"].Value.ToString());
                    estoque.quantidade = int.Parse(row.Cells["ColumnQuantidade"].Value.ToString());
                    estoque.AtualizarEstoque();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarEstoque_CodigoBarra()
        {
            produto.codigoBarra = CodigoBarra;
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
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void AdicionarItens()
        {
            btn_Remover.Enabled = false;

            if (txt_Codigo_Barra.Text != string.Empty)
            {
                if (cbOpcao.Checked)
                {
                    produto.codigoBarra = txt_Codigo_Barra.Text.Trim();
                    if (!produto.ConsultarCodigoBarra())
                    {
                        MessageBox.Show("Produto não encontrado!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_Codigo_Barra.Clear();
                        txt_Codigo_Barra.Focus();
                        return;
                    }
                }
                else
                {
                    produto.id = long.Parse(txt_Codigo_Barra.Text.Trim());
                    if (AreaAtuacao != "SALÃO DE BELEZA" && AreaAtuacao != "PRESTAÇÃO DE SERVIÇO")
                    {
                        if (!produto.ConsultarCodigoProduto())
                        {
                            MessageBox.Show("Produto não encontrado!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_Codigo_Barra.Focus();
                            txt_Codigo_Barra.Clear();
                            return;
                        }
                    }
                    else
                    {
                        if (!produto.ConsultarCodigoServico())
                        {
                            MessageBox.Show("Serviço não encontrado!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_Codigo_Barra.Focus();
                            txt_Codigo_Barra.Clear();
                            return;
                        }
                    }
                }

                AdicionarItensValue();
            }
            else if (cbOpcao.Checked)
                MessageBox.Show("Informe o código de barra!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (AreaAtuacao != "SALÃO DE BELEZA" && AreaAtuacao != "PRESTAÇÃO DE SERVIÇO")
                MessageBox.Show("Informe o código do produto!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("Informe o código do Serviço!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void AdicionarItensValue()
        {
            Quantidade = int.Parse(nd_Quantidade.Value.ToString());

            CodigoProduto = produto.id.ToString();
            Descricao = produto.descricao;
            ValorVenda = produto.valorVenda;
            EstoqueAtual = produto.estoqueAtual;
            EstoqueMinimo = produto.estoqueMinimo;
            Unidade = produto.unidade;
            int Id_Categoria = produto.id_categoria;
            categoria.id = Id_Categoria;
            categoria.Consultar();
            string descricaoCategoria = categoria.Descricao;

            LucroVenda = produto.lucro * Quantidade;
            LucroTotal += LucroVenda;

            Subtotal = nd_Quantidade.Value * ValorVenda;


            if (DGV_ItensVenda.Rows.Count > 0)
            {
                ConsultarItens(CodigoProduto);
            }

            if (EstoqueAtual == 0 && descricaoCategoria != "Serviço")
            {
                MessageBox.Show("O produto não possui estoque para esta quantidade!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Clear();
                txt_Codigo_Barra.Focus();
            }
            else if (EstoqueAtual < Quantidade && descricaoCategoria != "Serviço")
            {
                MessageBox.Show("A quantidade exigida é maior que o estoque atual. Atualize o estoque ou verifique se houve erro de digitação!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Clear();
                txt_Codigo_Barra.Focus();
            }
            else
            {
                DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, nd_Quantidade.Value, Unidade, ValorVenda, Subtotal);
                ValorTotal = ValorTotal + Subtotal;
                txt_Codigo_Barra.Clear();
                txt_Codigo_Barra.Focus();
                nd_Quantidade.Value = 1;
                DGV_ItensVenda.CurrentRow.Selected = false;

                soma = ValorTotal;
                ValorTotal = soma;
                txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
                EstoqueAtual -= Quantidade;
                if (EstoqueAtual == 0 && descricaoCategoria != "Serviço")
                {
                    MessageBox.Show("Quantidade do produto no estoque esgotou! Atualize o estoque no sistema!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (EstoqueAtual <= EstoqueMinimo && descricaoCategoria != "Serviço")
                {
                    MessageBox.Show("A quantidade atual do produto está chegando no ponto crítico! Atualize se necessário o estoque no sistema! Quantidade atual: " + EstoqueAtual, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ConsultarItens(string codigoProduto)
        {
            foreach (DataGridViewRow row in DGV_ItensVenda.Rows)
            {
                if (row.Cells["ColumnCodigo"].Value.ToString() == codigoProduto)
                {
                    EstoqueAtual -= int.Parse(row.Cells["ColumnQuantidade"].Value.ToString());
                }
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

        private void nd_Quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AdicionarItens();
        }

        private void btn_Remover_Click(object sender, EventArgs e)
        {
            RemoverItens();
        }

        private void Sair()
        {
            if (DGV_ItensVenda.Rows.Count > 0)
            {
                DialogResult dr;

                if (AreaAtuacao == "PRESTAÇÃO DE SERVIÇO" || AreaAtuacao == "SALÃO DE BELEZA")
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
                    DGV_ItensVenda.Rows.Clear();
                    btn_Remover.Enabled = false;
                    txt_Codigo_Barra.Clear();
                    txt_Codigo_Barra.Focus();
                    nd_Quantidade.Value = 1;
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
                MessageBox.Show("Não há item(ns) para ser cancelada! Verifique!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }

        FrmVendaParcial vendaParcial;
        private void btn_PagamentoParcial_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count >= 1)
            {
                vendaParcial = new FrmVendaParcial(ValorTotal);
                vendaParcial.ShowDialog();
                if (vendaParcial.vendaConfirmada)
                {
                    id_Cliente = vendaParcial.id_Cliente;
                    ValorRestante = vendaParcial.valorRestante;
                    ValorAbatido = vendaParcial.valorAbatido;
                    descontoDinheiro = vendaParcial.descontoDinheiro;
                    ValorTotal = vendaParcial.valorTotalComDesconto;
                    EfetuarAbatimento();
                    InserirItensvenda();

                    loadTelaInicial();
                    Backup.GerarBackup();
                    soundPlayer.Play();
                }

            }
            else
            {
                MessageBox.Show("Não há itens para venda! Verifique...", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }

        private void btn_NovoCadastro_Click(object sender, EventArgs e)
        {
            frmNovoCadastro novoCadastro = new frmNovoCadastro();
            novoCadastro.ShowDialog();
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
                        FrmRelatorioParcelas relatorioParcelas = new FrmRelatorioParcelas(lblCodigoVenda.Text, NomeFantasia, Endereco, Numero, Cidade, Estado, Telefone, CNPJ);
                        relatorioParcelas.ShowDialog();
                        this.Cursor = Cursors.Default;

                    }

                    InserirItensvenda();

                    loadTelaInicial();
                    Backup.GerarBackup();
                    soundPlayer.Play();
                }
            }
            else
            {
                MessageBox.Show("Não há itens para a venda! Verifique...", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        FrmRelatorioPrazo relatorioPrazo = new FrmRelatorioPrazo(lblCodigoVenda.Text, NomeFantasia, Endereco, Numero, Cidade, Estado, Telefone, CNPJ, Settings.Default["TempoPrazo"].ToString(), Bairro);
                        relatorioPrazo.ShowDialog();
                        this.Cursor = Cursors.Default;
                    }

                    loadTelaInicial();
                    Backup.GerarBackup();
                    soundPlayer.Play();
                }
            }
            else
            {
                MessageBox.Show("Não há itens para venda! Verifique...", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        int EstoqueAtual, EstoqueAtualizado, QuantidadeItens;
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


                        if (vendaVista.promissoriaPedido)
                        {
                            if (!string.IsNullOrEmpty(vendaVista.nomeCliente))
                            {
                                cliente = vendaVista.nomeCliente;
                            }

                            FrmReciboPagamento reciboPagamento = new FrmReciboPagamento(lbl_Hora.Text, ValorDesconto, NomeFantasia, Cidade, Endereco, Numero, CNPJ, cliente, lbl_Data.Text, lbl_atendente.Text, lblCodigoVenda.Text);
                            reciboPagamento.ShowDialog();
                        }
                        else
                        {
                            FrmCupom cupom = new FrmCupom(int.Parse(lblCodigoVenda.Text), lbl_Hora.Text, NomeFantasia, Cidade, Estado, Endereco, Numero, CNPJ, cliente, lbl_Data.Text, lbl_atendente.Text, lblCodigoVenda.Text, vendaVista.ValorPago, vendaVista.troco, Bairro);
                            cupom.ShowDialog();
                        }

                        Cursor = Cursors.Default;
                    }

                    loadTelaInicial();
                    Backup.GerarBackup();
                    soundPlayer.Play();
                }
            }
            else
            {
                MessageBox.Show("Não há itens para a venda! Verifique...", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }


        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.computerData);

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Hora.Text = DateTime.Now.ToLongTimeString();
        }

        private void GerarParcelas()
        {
            try
            {
                venda.Id = int.Parse(lblCodigoVenda.Text.Trim());
                venda.parcelas = vendaParcelas.Parcelas.Rows.Count;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorTotal;
                venda.desconto = 0.00m;
                venda.id_cliente = vendaParcelas.idCliente;
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();

                foreach (DataRow dr in vendaParcelas.Parcelas.Rows)
                {
                    ParcelaVenda.vencimento = dr[1].ToString();
                    ParcelaVenda.valorParcelado = decimal.Parse(dr[2].ToString());
                    ParcelaVenda.id_Venda = int.Parse(lblCodigoVenda.Text);
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
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            formaPagamento.descricao = "PARCELADO";
            formaPagamento.id_Venda = int.Parse(lblCodigoVenda.Text.Trim());
            formaPagamento.InformarFormaPagamento();
            CaixaDia();
            GerenciarCaixa_V_Parcela();
        }

        private void GerenciarCaixa_V_Parcela()
        {
            decimal EntradaParcela = vendaParcelas.valorEntrada;
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set EntradaParcela = EntradaParcela + @EntradaParcela where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            comando.SelectCommand.CommandText = _sql;
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
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        FrmVendaMista vendaMista;
        ValorMistoAbatido valorMistoAbatido = new ValorMistoAbatido();
        TipoPagamento tipoPagamento = new TipoPagamento();

        private void btnVendaMista_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count >= 1)
            {
                vendaMista = new FrmVendaMista(ValorTotal);
                vendaMista.ShowDialog();
                if (vendaMista.isFinally)
                {
                    descontoDinheiro = vendaMista.descontoDinheiro;

                    EfetuarVendaMista();
                    InserirItensvenda();

                    loadTelaInicial();
                    Backup.GerarBackup();
                    soundPlayer.Play();
                }
            }
            else
            {
                MessageBox.Show("Não há itens para a venda! Verifique...", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_Codigo_Barra.Focus();
            }
        }

        private void EfetuarVendaMista()
        {
            try
            {
                venda.Id = int.Parse(lblCodigoVenda.Text.Trim());
                venda.parcelas = 1;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorTotal - vendaMista.descontoDinheiro;
                venda.desconto = vendaMista.descontoDinheiro;
                venda.id_cliente = vendaMista.idCliente;
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();

                pagamentoMisto._valorDinheiro = vendaMista.valorDinheiro;
                pagamentoMisto._valorCredDeb = vendaMista.valorCredDeb;
                pagamentoMisto._valorRestante = vendaMista.valorRestante;
                pagamentoMisto._idVenda = int.Parse(lblCodigoVenda.Text);
                pagamentoMisto._idCliente = vendaMista.idCliente;
                pagamentoMisto.EfetuarPagamentoMisto();
                pagamentoMisto.InformarUltimoIdPagamentoMisto();

                tipoPagamento.descricao = "R$ " + vendaMista.valorCredDeb + " em " + vendaMista.tipoPagamento + " e R$ " + vendaMista.valorDinheiro + " em Dinheiro";
                tipoPagamento.idPagamentoMisto = pagamentoMisto._idPagamentoMisto;
                tipoPagamento.idPagamentoParcial = 0;
                tipoPagamento.idParcela = 0;
                tipoPagamento.InformarFormaPagamento();

                valorMistoAbatido._idPagamentoMisto = pagamentoMisto._idPagamentoMisto;
                valorMistoAbatido._valorTotalAbatimento = (vendaMista.valorCredDeb + vendaMista.valorDinheiro);
                valorMistoAbatido._dataPagamento = DateTime.Now.ToShortDateString();
                valorMistoAbatido._horaPagamento = DateTime.Now.ToLongTimeString();
                valorMistoAbatido.InserirValorMistoAbatido();

                formaPagamento.descricao = "MISTO";
                formaPagamento.id_Venda = int.Parse(lblCodigoVenda.Text.Trim());
                formaPagamento.InformarFormaPagamento();
                valorNCaixa = vendaMista.valorDinheiro;
                CaixaDia();
                GerenciarCaixa();
                AtualizarValorDescontoCaixa();
                ValorDesconto = vendaMista.valorDinheiro;
                InformarValorRecebidoMisto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformarValorRecebidoMisto()
        {
            string column = "ValorRecebidoDebito";

            if (vendaMista.tipoPagamento == "Cartão de Crédito")
                column = "ValorRecebidoCredito";

            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Update FluxoCaixa set ValorRecebidoMisto = ValorRecebidoMisto + @ValorRecebidoMisto, " + column + " = " + column + " + @ValorRecebidoCreDeb where HoraSaida = '' and DataSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorRecebidoMisto", vendaMista.valorDinheiro);
            comando.Parameters.AddWithValue("@ValorRecebidoCreDeb", vendaMista.valorCredDeb);
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

        Venda venda = new Venda();
        int index = 0;

        private bool ConsultarEstoque(long id, int estoqueAtual)
        {
            bool estoqueMaior = false;
            int sumEstoque = 0;

            foreach(DataGridViewRow row in DGV_ItensVenda.Rows)
            {
                if (id == int.Parse(row.Cells["ColumnCodigo"].Value.ToString()))
                {
                    sumEstoque += int.Parse(row.Cells["ColumnQuantidade"].Value.ToString());
                }
            }

            if (sumEstoque > estoqueAtual)
                estoqueMaior = true;

            return estoqueMaior;
        }

        private void DGV_ItensVenda_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count > 0)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(DGV_ItensVenda.CurrentRow.Cells["ColumnQuantidade"].Value.ToString()))
                    {
                        DGV_ItensVenda.CurrentRow.Cells["ColumnQuantidade"].Value = QuantidadeItens;
                        return;
                    }
                    int QtdCurrentRow = int.Parse(DGV_ItensVenda.CurrentRow.Cells["ColumnQuantidade"].Value.ToString());

                    if (QtdCurrentRow > 0)
                    {
                        produto.id = int.Parse(CodigoProduto);
                        produto.ConsultarProduto();
                        EstoqueAtual = produto.estoqueAtual;
                        EstoqueMinimo = produto.estoqueMinimo;
                        ConsultarItens(CodigoProduto);

                        if (QtdCurrentRow > produto.estoqueAtual && produto.unidade != "Serviço" || ConsultarEstoque(produto.id, produto.estoqueAtual))
                        {
                            MessageBox.Show("A quantidade exigida é maior que o estoque atual. Atualize o estoque!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            DGV_ItensVenda.CurrentRow.Cells["ColumnQuantidade"].Value = QuantidadeItens;
                            return;
                        }

                        ValorTotal = 0;

                        foreach (DataGridViewRow row in DGV_ItensVenda.Rows)
                        {
                            row.Selected = false;
                            row.Cells["ColumnSubTotal"].Value = (decimal.Parse(row.Cells["ColumnValorUnitario"].Value.ToString()) * decimal.Parse(row.Cells["ColumnQuantidade"].Value.ToString())).ToString();
                            ValorTotal += decimal.Parse(row.Cells["ColumnSubTotal"].Value.ToString());
                            row.Cells["ColumnSubTotal"].DataGridView.DefaultCellStyle.Format = "C2";
                        }

                        txt_ValorTotal.Text = "R$ " + ValorTotal;
                        btn_Remover.Enabled = false;

                        if (EstoqueAtual == 0 && produto.unidade != "Serviço")
                        {
                            MessageBox.Show("Quantidade do produto no estoque esgotou! Atualize o estoque no sistema!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (EstoqueAtual <= EstoqueMinimo && produto.unidade != "Serviço")
                        {
                            MessageBox.Show("A quantidade atual do produto está chegando no ponto crítico! Atualize se necessário o estoque no sistema! Estoque Atual: " + EstoqueAtual, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Informe valor maior que zero!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DGV_ItensVenda.CurrentRow.Cells["ColumnQuantidade"].Value = QuantidadeItens;
                    }
                }
                catch
                {
                    MessageBox.Show("Informe número inteiro", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DGV_ItensVenda.CurrentRow.Cells["ColumnQuantidade"].Value = QuantidadeItens;
                }
                finally
                {
                    txt_Codigo_Barra.Focus();
                }
            }
        }

        private void DGV_ItensVenda_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_ItensVenda.Rows)
            {
                row.Selected = false;
            }
        }

        private void btnDevolução_Click(object sender, EventArgs e)
        {
            if (ListaTodasVendas() == "true")
            {
                FrmBuscarItensVendaDevolucao alterarExcluirVenda = new FrmBuscarItensVendaDevolucao();
                alterarExcluirVenda.ShowDialog();
                CodigoVenda();
                lblCodigoVenda.Text = codigoVenda;
            }
            else if (ListaTodasVendas() == "false")
            {
                MessageBox.Show("Não há vendas realizadas.", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string ListaTodasVendas()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "select Cliente.Id_Cliente, Cliente.Nome as NomeCliente, Venda.Id_Venda, ItensVenda.Quantidade, Produto.ValorVenda, ItensVenda.lucroItens, ItensVenda.Valor, FormaPagamento.Descricao, Venda.DataVenda, Venda.HoraVenda, Usuario.Nome as NomeUsuario, Produto.Descricao as DescricaoProduto from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join ItensVenda on ItensVenda.Id_Venda = Venda.Id_Venda inner join Produto on Produto.Id_Produto = ItensVenda.Id_Produto inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Usuario on Usuario.Id_Usuario = Venda.Id_Usuario where Produto.Unidade <> 'serviço'";
                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                if (Tabela.Rows.Count == 0)
                {
                    return "false";
                }
                else
                {
                    return "true";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "erro";
            }
        }

        PagamentoMisto pagamentoMisto = new PagamentoMisto();

        //verifica a situação do cliente antes da conclusão da venda durante o prazo da última compra

        private void EfetuarVendaPrazo()
        {
            try
            {
                venda.Id = int.Parse(lblCodigoVenda.Text.Trim());
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
                ParcelaVenda.id_Venda = int.Parse(lblCodigoVenda.Text);
                ParcelaVenda.dataPagamento = "";
                ParcelaVenda.horaPagamento = "";
                ParcelaVenda.N_Parcela = 1;
                ParcelaVenda.inserirParcelas();

                formaPagamento.descricao = "PRAZO";
                formaPagamento.id_Venda = int.Parse(lblCodigoVenda.Text.Trim());
                formaPagamento.InformarFormaPagamento();
                CaixaDia();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        PagamentoParcial PagamentoParcial = new PagamentoParcial();

        private void EfetuarAbatimento()
        {
            try
            {
                venda.Id = int.Parse(lblCodigoVenda.Text.Trim());
                venda.parcelas = 1;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorTotal;
                venda.desconto = descontoDinheiro;
                venda.id_cliente = int.Parse(id_Cliente);
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();

                formaPagamento.descricao = "PAGAMENTO PARCIAL";
                formaPagamento.id_Venda = int.Parse(lblCodigoVenda.Text.Trim());
                formaPagamento.InformarFormaPagamento();

                PagamentoParcial.dataAbatimento = DateTime.Now.ToShortDateString();
                PagamentoParcial.valorRestante = ValorRestante;
                PagamentoParcial.id_Venda = int.Parse(lblCodigoVenda.Text);
                PagamentoParcial.id_Cliente = int.Parse(id_Cliente);
                PagamentoParcial.CodigoIdPagamentoParcial();
                int id = PagamentoParcial.Id;
                PagamentoParcial.ConfirmarPagamentoParcial();

                PagamentoParcial.Id = id;
                PagamentoParcial.valorTotalAbatido = ValorAbatido;
                PagamentoParcial.dataAbatimento = DateTime.Now.ToShortDateString();
                PagamentoParcial.horaPagamento = DateTime.Now.ToLongTimeString();
                PagamentoParcial.InserirValorAbatido();

                if (ValorAbatido > 0)
                {
                    tipoPagamento.idPagamentoParcial = id;
                    tipoPagamento.descricao = vendaParcial.TipoPagamento;
                    tipoPagamento.idPagamentoMisto = 0;
                    tipoPagamento.idParcela = 0;
                    tipoPagamento.InformarFormaPagamento();
                }
                if (vendaParcial.TipoPagamento == "Dinheiro" || vendaParcial.TipoPagamento == "")
                    valorNCaixa = ValorAbatido;
                else
                    valorNCaixa = 0.00m;

                CaixaDia();
                GerenciarCaixa();
                GerenciarCaixa_V_Parcial();
                AtualizarValorDescontoCaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem do sistema 'Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerenciarCaixa_V_Parcial()
        {
            decimal ValorRecebido = ValorAbatido;
            SqlConnection conexao = new SqlConnection(stringConn);

            if (vendaParcial.TipoPagamento == "Dinheiro" || string.IsNullOrEmpty(vendaParcial.TipoPagamento))
                _sql = "Update FluxoCaixa set ValorRecebidoParcial = ValorRecebidoParcial + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            else if (vendaParcial.TipoPagamento == "Cartão de Crédito")
                _sql = "Update FluxoCaixa set ValorRecebidoCredito = ValorRecebidoCredito + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            else if (vendaParcial.TipoPagamento == "Cartão de Débito")
                _sql = "Update FluxoCaixa set ValorRecebidoDebito = ValorRecebidoDebito + @ValorRecebido where HoraSaida = '' and DataSaida = ''";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorRecebido", ValorRecebido);
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
            if (Fechar == false)
            {
                e.Cancel = true;
            }
        }

        ItensVenda itensVenda = new ItensVenda();
        ClassFormaPagamento formaPagamento = new ClassFormaPagamento();
        ClassParcelaVenda ParcelaVenda = new ClassParcelaVenda();


        private void DGV_ItensVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Remover.Enabled = true;
            index = 0;
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
                try
                {
                    QuantidadeItens = int.Parse(linha.Cells["ColumnQuantidade"].Value.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnPagamentoCartao_Click(object sender, EventArgs e)
        {
            if (DGV_ItensVenda.Rows.Count >= 1)
            {
                FrmFormaPagamento pagamentoCartao = new FrmFormaPagamento(lblCodigoVenda.Text, ValorTotal, LucroTotal, Id_Usuario);
                pagamentoCartao.ShowDialog();
                if (pagamentoCartao.Confirmacao == "Venda realizada com sucesso!")
                {
                    InserirItensvenda();
                    if (pagamentoCartao.pedidoNotaPromissoria)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        BuscarInformacaoEmpresa();
                        decimal valorDesconto = pagamentoCartao.Desconto;
                        FrmReciboPagamento reciboPagamento = new FrmReciboPagamento(lbl_Hora.Text, valorDesconto, NomeFantasia, Cidade, Endereco, Numero, CNPJ, cliente, lbl_Data.Text, lbl_atendente.Text, lblCodigoVenda.Text);
                        reciboPagamento.ShowDialog();
                        this.Cursor = Cursors.Default;
                        ValorTotal = 0.00m;
                        txt_Codigo_Barra.Focus();
                    }

                    loadTelaInicial();
                    Backup.GerarBackup();
                    soundPlayer.Play();
                }
            }
            else
                MessageBox.Show("Não há itens para venda! Verifique...", "Mensagem do sistema 'Caixa Fácil'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void loadTelaInicial()
        {
            DGV_ItensVenda.Rows.Clear();
            CodigoVenda();
            lblCodigoVenda.Text = codigoVenda;
            ValorTotal = 0.00M;
            txt_ValorTotal.Text = "R$ " + ValorTotal;
            txt_Codigo_Barra.Focus();
            LucroTotal = 0.00m;
            ValorCaixa = 0.00m;
            ValorDesconto = 0.00m;
            descontoDinheiro = 0.00m;
            id_Cliente = "1";
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
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_BuscarServiço_Click(object sender, EventArgs e)
        {
            FrmPesquisarServico pesquisarServico = new FrmPesquisarServico();
            pesquisarServico.ShowDialog();

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
                    Subtotal = nd_Quantidade.Value * ValorVenda;
                    LucroVenda = produto.lucro * Quantidade;
                    LucroTotal += LucroVenda;


                    DGV_ItensVenda.Rows.Add(CodigoProduto, Descricao, nd_Quantidade.Value, Unidade, ValorVenda, Subtotal);
                    ValorTotal = ValorTotal + Subtotal;
                    txt_Codigo_Barra.Clear();
                    txt_Codigo_Barra.Focus();
                    nd_Quantidade.Value = 1;
                    DGV_ItensVenda.CurrentRow.Selected = false;
                }
            }
            soma = ValorTotal;
            ValorTotal = soma;
            txt_ValorTotal.Text = "R$ " + ValorTotal.ToString();
            btn_Remover.Enabled = false;
        }

        private void EfetuarVendaVista()
        {
            try
            {
                venda.Id = int.Parse(lblCodigoVenda.Text.Trim());
                venda.parcelas = 1;
                venda.dataVenda = DateTime.Now.ToShortDateString();
                venda.horaVenda = lbl_Hora.Text;
                venda.valorTotal = ValorDesconto;
                venda.desconto = descontoDinheiro;
                venda.id_cliente = int.Parse(id_Cliente);
                venda.id_usuario = Id_Usuario;
                venda.lucro = LucroTotal;
                venda.EfetuarVenda();
                formaPagamento.descricao = "VISTA";
                formaPagamento.id_Venda = int.Parse(lblCodigoVenda.Text.Trim());
                formaPagamento.InformarFormaPagamento();
                valorNCaixa = ValorDesconto;
                CaixaDia();
                GerenciarCaixa();
                AtualizarValorDescontoCaixa();
                InformarValorRecebidoVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                itensVenda.id_venda = int.Parse(lblCodigoVenda.Text);
                itensVenda.Valor = decimal.Parse(DGV_ItensVenda.Rows[i].Cells["ColumnSubTotal"].Value.ToString());
                itensVenda.id_produto = int.Parse(DGV_ItensVenda.Rows[i].Cells["ColumnCodigo"].Value.ToString());
                itensVenda.quantidade = int.Parse(DGV_ItensVenda.Rows[i].Cells["ColumnQuantidade"].Value.ToString());
                itensVenda.LucroItens = LucroVenda;
                itensVenda.AdicionarItensVenda();
            }

            atualizarEstoque_CodigoProduto();
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