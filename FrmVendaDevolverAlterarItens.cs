using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVendaDevolverAlterarItens : Form
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql, descricao, idFluxoCaixa, codCliente, dataVenda;

        int MaxCodVenda, IdPagamentoParcial, qtdItens, qtdItensDevolvido = 1;

        decimal lucroItens, ValorPago, valorRestante, valorAbatido, ValorTotalPagamentoParcial, valorVenda, valorEntrada, sumValorParcelado, valorSubTotal, ValorCaixaInicial, valorReceber, ValorRecebidoDebito, desconto;

        bool devolucaoItensTudo = false;

        public FrmVendaDevolverAlterarItens(string CodVenda, string Cliente, string FormaPagamento, string ValorVenda, string codCliente, string dataVenda, string desconto)
        {
            InitializeComponent();
            this.dataVenda = dataVenda;
            this.desconto = decimal.Parse(desconto);
            this.valorVenda = decimal.Parse(ValorVenda) + this.desconto;
            lblCodigoVenda.Text = CodVenda;
            lblCliente.Text = Cliente;
            lblValorTotalComDesconto.Text = "R$ " + ValorVenda;
            lblDesconto.Text = "R$ " + desconto;
            this.CodVenda = CodVenda;
            this.FormaPagamento = FormaPagamento;
            this.codCliente = codCliente;
            lblValorTotalSemDesconto.Text = "R$ " + (decimal.Parse(ValorVenda) + decimal.Parse(desconto));

            if (FormaPagamento == "VISTA")
            {
                ValorPago = decimal.Parse(ValorVenda);
            }
            else if (FormaPagamento == "PAGAMENTO PARCIAL")
            {
                getValorReceber();
            }
            else if (FormaPagamento == "PARCELADO")
            {
                InformarValoresPagos();
                VerificarParcelas_E_ValorEntrada();
                valorEntrada = this.valorVenda - sumValorParcelado;
                ValorPago += valorEntrada;
            }
            else if((FormaPagamento == "PRAZO"))
            {
                InformarValoresPagos();
            }
        }

        private void getValorReceber()
        {
            receberValor_e_IdPagamentoParcial();
            ValorTotalPagamentoParcial = valorRestante + ReceberValorAbatido();
        }

        private void BuscarValorReceberFluxCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select ValorReceber from FluxoCaixa where DataSaida = '' and HoraSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", CodVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    valorReceber = decimal.Parse(comando.ExecuteScalar().ToString());
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

        private void VerificarParcelas_E_ValorEntrada()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT SUM(ParcelaVenda.ValorParcelado) as ValorPago FROM ParcelaVenda INNER JOIN FormaPagamento ON ParcelaVenda.Id_Venda = FormaPagamento.Id_Venda WHERE ParcelaVenda.Id_Venda = @IdVenda AND FormaPagamento.Descricao = 'PARCELADO'";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", CodVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    sumValorParcelado = decimal.Parse(comando.ExecuteScalar().ToString());
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

        // trechos de códigos para excluir todos os itens

        private void InformarValoresPagos()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            if (FormaPagamento == "PARCELADO")
            {
                _sql = "SELECT SUM(ParcelaVenda.ValorParcelado) as ValorPago FROM ParcelaVenda INNER JOIN FormaPagamento ON ParcelaVenda.Id_Venda = FormaPagamento.Id_Venda WHERE ParcelaVenda.Id_Venda = @IdVenda AND ParcelaVenda.DataPagamento <> '' AND FormaPagamento.Descricao = 'PARCELADO'";
            }
            else if (FormaPagamento == "PRAZO")
            {
                _sql = "SELECT SUM(ParcelaVenda.ValorParcelado) as ValorPago FROM ParcelaVenda INNER JOIN FormaPagamento ON ParcelaVenda.Id_Venda = FormaPagamento.Id_Venda WHERE ParcelaVenda.Id_Venda = @IdVenda AND ParcelaVenda.DataPagamento <> '' AND FormaPagamento.Descricao = 'PRAZO'";
            }
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", CodVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    ValorPago = decimal.Parse(comando.ExecuteScalar().ToString());
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

        private void receberValor_e_IdPagamentoParcial()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select PagamentoParcial.ValorRestante, PagamentoParcial.Id_PagamentoParcial from PagamentoParcial inner join Venda on Venda.Id_Venda = PagamentoParcial.Id_Venda where Venda.Id_Cliente = @IdCliente and PagamentoParcial.ValorRestante > 0";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    IdPagamentoParcial = int.Parse(dr["Id_PagamentoParcial"].ToString());
                    valorRestante = decimal.Parse(dr["ValorRestante"].ToString());
                }
                else
                    valorRestante = 0.00m;
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

        private decimal ReceberValorAbatido()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select Sum(ValorTotalAbatimento) as ValorTotalAbatimento from ValorAbatido where Id_PagamentoParcial = @IdPagamentoParcial";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamentoParcial", IdPagamentoParcial);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    valorAbatido = decimal.Parse(dr["ValorTotalAbatimento"].ToString());
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
            return valorAbatido;
        }

        private void InformarIdVendaMaximo()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            for (int i = 0; i <= 1; i++)
            {
                if (MaxCodVenda == 0)
                {
                    _sql = "Select Max(Venda.Id_Venda) as MaxCodVenda from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda where Venda.Id_Venda <> " + CodVenda + " and Venda.Id_Cliente = " + codCliente + " and FormaPagamento.Descricao = 'PAGAMENTO PARCIAL'";
                }
                else if (MaxCodVenda > 0)
                {
                    _sql = "update PagamentoParcial set Id_Venda = " + MaxCodVenda + "where id_PagamentoParcial = " + IdPagamentoParcial;
                }
                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.CommandText = _sql;
                try
                {
                    conexao.Open();
                    if (MaxCodVenda == 0)
                    {
                        if (comando.ExecuteScalar() != DBNull.Value)
                        {
                            MaxCodVenda = int.Parse(comando.ExecuteScalar().ToString());
                        }
                    }
                    else
                    {
                        comando.ExecuteNonQuery();
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
        }

        bool CodVendaIgual = false;

        private void VerificarIdVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select * from PagamentoParcial where Id_Venda = @IdVenda";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", CodVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    CodVendaIgual = true;
                }
                else
                {
                    CodVendaIgual = false;
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

        private void FrmListavenda_Load(object sender, EventArgs e)
        {
            IdentificarFluxoCaixa();
            VerificarValorCaixa();
            VerificarSaidaCaixa();
            valorCaixa = (valorCaixa + ValorCaixaInicial) - ValorSaida;
            dgv_ListaVenda.ClearSelection();
            ListaTodasVendas();
            BuscarValorReceberFluxCaixa();
        }

        private void IdentificarFluxoCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select max(Id_Fluxo) from FluxoCaixa";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
               if(comando.ExecuteScalar() != DBNull.Value)                
                {
                    idFluxoCaixa = comando.ExecuteScalar().ToString();
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

        private void ListaTodasVendas()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "select ItensVenda.id_ItensVenda, ItensVenda.Id_Produto, produto.Descricao, ItensVenda.Valor, ItensVenda.Quantidade, ItensVenda.lucroItens, Venda.DataVenda from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join ItensVenda on ItensVenda.Id_Venda = Venda.Id_Venda inner join Produto on Produto.Id_Produto = ItensVenda.Id_Produto where Venda.Id_Venda = " + CodVenda;
                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                dgv_ListaVenda.DataSource = Tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string CodVenda = "", FormaPagamento;

        private void btnDevolverTudo_Click(object sender, EventArgs e)
        {
            devolucaoItensTudo = true;
            DialogResult dr = MessageBox.Show("Deseja mesmo aceitar a devolução do(s) produto(s)?", "Caixa Fácil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                bool retirarValorCaixa = true;

                if (valorCaixa > 0)
                {
                    if (valorCaixa < ValorPago)
                    {
                        dr = MessageBox.Show("O Valor a devolver para o cliente é maior que o valor que está em caixa no momento. Você deseja que retire o valor do caixa?", "Caixa Fácil", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                        if (dr == DialogResult.No)
                        {
                            retirarValorCaixa = false;
                        }
                    }
                }
                else
                {
                    retirarValorCaixa = false;
                    dr = MessageBox.Show("Informamos que não existe valores no caixa no momento. Os valores da venda não irá afetar o fluxo do caixa. Deseja continuar?", "Caixa Fácil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }

                AlterarValoresPagamentoParcial_Parcelado();
                verificarDataPagamento_E_AtualizarValoresFluxoCaixa();
                ExcluirTodosItensVenda();

                if (retirarValorCaixa)
                    GerenciarFluxoCaixa();

                AtualizarTodoEstoque();
                this.Close();
            }
        }

        private void AtualizarTodoEstoque()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            for (int i = 0; i < dgv_ListaVenda.Rows.Count; i++)
            {
                _sql = "update Produto set EstoqueAtual = EstoqueAtual + @Quantidade where id_Produto = @IdProduto";

                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@Quantidade", dgv_ListaVenda.Rows[i].Cells["ColQuantidade"].Value.ToString());
                comando.Parameters.AddWithValue("@IdProduto", dgv_ListaVenda.Rows[i].Cells["ColCodProduto"].Value.ToString());
                comando.CommandText = _sql;
                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
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
        }

        decimal subValorVendaValorAbatido, subValorReceber;
        private void AlterarValoresPagamentoParcial_Parcelado()
        {
            if (FormaPagamento == "PAGAMENTO PARCIAL")
            {
                if (ValorTotalPagamentoParcial > valorVenda)
                {
                    // primeiro Verifica se o idVenda informado é igual ao idVenda da tabela Pagamento Parcial

                    VerificarIdVenda();

                    if (CodVendaIgual)
                    {
                        InformarIdVendaMaximo();
                    }

                    subValorVendaValorAbatido = ValorTotalPagamentoParcial - valorVenda - ReceberValorAbatido();
                    AlterarValorRestantePagamentoParcial();

                }
                else
                {
                    ValorPago = valorAbatido;
                }
            }
        }

        private void verificarDataPagamento_E_AtualizarValoresFluxoCaixa()
        {
            if (FormaPagamento == "PAGAMENTO PARCIAL")
            {
                VerificarDataAbatimentoDataVenda();
                subValorReceber = valorReceber - (valorVenda - valorAbatido);
                if (valorReceber >= subValorReceber)
                    AtualizarValorReceberPagamentoParcial();
            }
            else if (FormaPagamento == "PRAZO")
            {
                subValorReceber = valorVenda;
            }
            else if (FormaPagamento == "Cartão de Débito")
            {
                ValorRecebidoDebito = valorVenda;
                AtualizarValorRecebidoDebito();
            }
            else
            {
                subValorReceber = valorVenda - ValorPago;
            }
            if (valorReceber >= subValorReceber)
                AtualizarValorReceberPagamentoPrazoParcela();
        }

        private void AtualizarValorRecebidoDebito()
        {
            if (dataVenda == DateTime.Now.ToShortDateString())
            {
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "update FluxoCaixa set valorRecebidoDebito =  valorRecebidoDebito - @Valor where DataSaida = '' and HoraSaida = ''";

                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@Valor", ValorRecebidoDebito);
                comando.CommandText = _sql;
                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
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
        }

        private void AtualizarValorReceberPagamentoPrazoParcela()
        {
            if (FormaPagamento == "PARCELADO" || FormaPagamento == "PRAZO")
            {
                if (dataVenda == DateTime.Now.ToShortDateString())
                {
                    SqlConnection conexao = new SqlConnection(stringConn);

                    _sql = "update fluxoCaixa set ValorReceber = ValorReceber - @ValorReceber where DataSaida = '' and HoraSaida = ''";

                    SqlCommand comando = new SqlCommand(_sql, conexao);
                    comando.Parameters.AddWithValue("@ValorReceber", ((valorSubTotal / qtdItens) * qtdItensDevolvido));
                    comando.CommandText = _sql;
                    try
                    {
                        conexao.Open();
                        comando.ExecuteNonQuery();
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
            }
        }

        private void AtualizarValorReceberPagamentoParcial()
        {
            if (dataVenda == DateTime.Now.ToShortDateString() && DataAbatimento == DateTime.Now.ToShortDateString())
            {
                SqlConnection conexao = new SqlConnection(stringConn);

                _sql = "update fluxoCaixa set ValorReceber = @ValorReceber where DataSaida = '' and HoraSaida = ''";

                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@ValorReceber", subValorReceber);
                comando.CommandText = _sql;
                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
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
        }

        string DataAbatimento;
        decimal ValorPagamento;
        private void VerificarDataAbatimentoDataVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            _sql = "Select ValorTotalAbatimento, DataPagamento from ValorAbatido where Id_PagamentoParcial = @IdPagamentoParcial";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamentoParcial", IdPagamentoParcial);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    ValorPagamento = decimal.Parse(dr["ValorTotalAbatimento"].ToString());
                    DataAbatimento = dr["DataPagamento"].ToString();

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

        private void AlterarValorRestantePagamentoParcial()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            _sql = "update PagamentoParcial set ValorRestante = @ValorRestante where Id_PagamentoParcial = @IdPagamentoParcial";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorRestante", subValorVendaValorAbatido);
            comando.Parameters.AddWithValue("@IdPagamentoParcial", IdPagamentoParcial);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void GerenciarFluxoCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            _sql = "insert into SaidaCaixa values (@Valor, 'Devolução de Itens vendidos', @IdFluxo)";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            if (valorCaixa >= ValorPago)
            {
                if(devolucaoItensTudo)
                comando.Parameters.AddWithValue("@Valor", ValorPago);
                else
                    comando.Parameters.AddWithValue("@Valor", (valorSubTotal / qtdItens) * qtdItensDevolvido);
            }
            else
            {
                comando.Parameters.AddWithValue("@Valor", valorCaixa);
            }
            comando.Parameters.AddWithValue("@IdFluxo", idFluxoCaixa);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        decimal valorCaixa, ValorSaida;
        private void VerificarValorCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select ValorCaixa, valorEntrada from FluxoCaixa  where DataSaida = '' and HoraSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    valorCaixa = decimal.Parse(dr["ValorCaixa"].ToString());
                    ValorCaixaInicial = decimal.Parse(dr["ValorEntrada"].ToString());
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

        private void VerificarSaidaCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select sum(ValorSaida) as ValorSaida from SaidaCaixa  where Id_Fluxo = @IdFluxo";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdFluxo", idFluxoCaixa);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    ValorSaida = decimal.Parse(comando.ExecuteScalar().ToString());
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

        private void ExcluirTodosItensVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "delete from Venda where id_Venda = @IdVenda";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", CodVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                if (FormaPagamento != "PAGAMENTO PARCIAL" || ValorTotalPagamentoParcial == valorVenda)
                {

                    string messagem = "";
                    if (ValorPago > 0)
                    {
                        messagem = " O valor já foi pago pelo cliente está no valor de " + ValorPago;
                    }

                    MessageBox.Show("Itens devolvidos!" + messagem, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Excluir Item

        private void btnDevolverItem_Click(object sender, EventArgs e)
        {
            devolucaoItensTudo = false;

            if (qtdItens >= 2)
            {
                MessageBox.Show("Informe a quantidade de itens que vai ser devolvida.", "Aviso do sistema Gerenciamento Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmDevolverQuantidadeItens devolverQuantidadeItens = new FrmDevolverQuantidadeItens(qtdItens);
                devolverQuantidadeItens.ShowDialog();
                if (devolverQuantidadeItens.qtdItens > 0)
                {
                    qtdItensDevolvido = devolverQuantidadeItens.qtdItens;
                }
                else
                {
                    MessageBox.Show("É necessário informar a quantidade de itens que vai ser devolvida.", "Aviso do sistema Gerenciamento Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (FormaPagamento == "VISTA")
            {
                ValorPago = decimal.Parse(dgv_ListaVenda.CurrentRow.Cells["ColvalorSubTotal"].Value.ToString());
            }

            if (dgv_ListaVenda.Rows.Count > 1)
            {
                if (dgv_ListaVenda.CurrentRow.Selected == true)
                {
                    DialogResult dr = MessageBox.Show("Deseja mesmo aceitar a devolução do(a) " + descricao + "?", "Caixa Fácil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o item para excluir!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (qtdItensDevolvido == 0 || qtdItens == qtdItensDevolvido)
                {
                    btnDevolverTudo_Click(sender, e);
                    return;
                }
            }

            DevolverItens();
        }

        private void DevolverItens()
        {
            verificarFormaPagamentos();
            deleteUpdateItensVenda();

            subValorReceber = valorSubTotal;
            if (FormaPagamento == "PARCELADO" || FormaPagamento == "PRAZO")
            {
                AtualizarValorReceberPagamentoPrazoParcela();
            }
            else if (FormaPagamento == "Cartão de Débito")
            {
                ValorRecebidoDebito = ((valorSubTotal / qtdItens) * qtdItensDevolvido);
                AtualizarValorRecebidoDebito();
            }
            else if (FormaPagamento == "PAGAMENTO PARCIAL")
            {
                subValorReceber = (valorReceber + valorAbatido) - ((valorSubTotal / qtdItens) * qtdItensDevolvido) - valorAbatido;
                VerificarDataAbatimentoDataVenda();
                if (valorReceber >= subValorReceber)
                    AtualizarValorReceberPagamentoParcial();
            }
            else if (FormaPagamento == "VISTA")
            {
                GerenciarFluxoCaixa();
            }

            AtualizarEstoque();
            dgv_ListaVenda.Rows.Remove(dgv_ListaVenda.CurrentRow);
            ListaTodasVendas();

            lblValorTotalComDesconto.Text = "R$ " + (valorVenda - desconto);
            lblValorTotalSemDesconto.Text = "R$ " + valorVenda;

            if (dgv_ListaVenda.Rows.Count == 0)
            {
                this.Close();
            }
        }

        private void AtualizarEstoque()
        {
            if(qtdItensDevolvido > 0 && qtdItensDevolvido < qtdItens)
            {
                qtdItens = qtdItensDevolvido;
            }

            SqlConnection conexao = new SqlConnection(stringConn);

            _sql = "update Produto set EstoqueAtual = EstoqueAtual + @Quantidade where id_Produto = @IdProduto";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@Quantidade", qtdItens);
            comando.Parameters.AddWithValue("@IdProduto", dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString());
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        decimal subValoresTotalUnitario, valorParcela;
        int qtdParcela;
       
        private void verificarFormaPagamentos()
        {

            if (qtdItensDevolvido == 0 || qtdItens == qtdItensDevolvido || qtdItens == 1)
            {
                valorVenda -= valorSubTotal;
                subValoresTotalUnitario = valorSubTotal;
            }
            else
            {
                subValoresTotalUnitario = valorSubTotal - ((valorSubTotal / qtdItens) * qtdItensDevolvido);
                valorVenda =(valorVenda - ((valorSubTotal / qtdItens) * qtdItensDevolvido));
            }

            if (FormaPagamento == "PARCELADO")
            {
                if ((ValorPago) < valorVenda)
                {
                    verificarNumeroParcelas();
                    valorParcela = (valorVenda - (ValorPago)) / qtdParcela;
                    AlterarValoresParcelas();
                }
                else
                {
                    decimal subValorPagoValorVenda = ValorPago - valorVenda;
                    MessageBox.Show("Informamos que o cliente pagou R$ " + Math.Ceiling(ValorPago).ToString("0.00") + " reais, e com devolução do{s} produto(s) pela contabilização dos valores da venda com tudo que já foi pago, fica constatado que o cliente tem o direito de receber R$" + Math.Ceiling(subValorPagoValorVenda).ToString("0.00") + ". A partir deste momento a conta do cliente zera.", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExcluirParcelas();
                }
            }
            else if (FormaPagamento == "PRAZO")
            {
                valorParcela = subValoresTotalUnitario;               
            }
            else if (FormaPagamento == "VISTA")
            {
                ValorPago = subValoresTotalUnitario;
            }
            else if (FormaPagamento == "PAGAMENTO PARCIAL")
            {
                getValorReceber();
                subValorVendaValorAbatido = ((valorRestante + valorAbatido) - (valorSubTotal / qtdItens * qtdItensDevolvido) - valorAbatido);

                if (subValorVendaValorAbatido < 0)
                {
                    if ((valorVenda - desconto) < valorAbatido && valorRestante > 0)
                    {
                        subValorVendaValorAbatido = (valorVenda - desconto) - valorAbatido;
                        if(subValorVendaValorAbatido < 0 && valorAbatido > 0)
                        {
                            decimal valorDevolver = valorAbatido - (valorVenda - desconto);
                           
                            MessageBox.Show("Deverá ser devolvido o valor de R$ " + valorDevolver + "! Por conta que o cliente tinha em sua conta uma pendência de R$ " + valorRestante + " e abateu R$ " + valorAbatido + ", com a devolução do item selecionado que está no valor de R$ " + valorSubTotal + " o cliente passa a não ter dívidas e terá o direito de receber o valor de R$ " + valorDevolver, "Aviso do sistema Gerenciamento Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                            AlterarValorAbatidoPagamentoParcial();
                            subValorVendaValorAbatido = 0;
                        }
                        else
                            MessageBox.Show("Com a devolução do(a) " + dgv_ListaVenda.CurrentRow.Cells["ColDescricao"].Value.ToString() + " o cliente passa a dever R$ " + subValorVendaValorAbatido, "Aviso do sistema Gerenciamento Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (valorVenda == valorAbatido)
                    {
                        MessageBox.Show("Com o valor da venda se igualando com o valor que já foi abatido pelo cliente, o cliente passa a não ter dívidas com o estabelicimento.", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        subValorVendaValorAbatido = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Com a devolução do(a) " + dgv_ListaVenda.CurrentRow.Cells["ColDescricao"].Value.ToString() + " o cliente passa a dever R$ " + subValorVendaValorAbatido, "Aviso do sistema Gerenciamento Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
                if(subValorVendaValorAbatido >= 0)
                    AlterarValorRestantePagamentoParcial();
            }

            AlterarLucroItens();
            AlterarValorDesconto();
            AlterarValor_E_LucroVenda();
        }

        private void AlterarValorAbatidoPagamentoParcial()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update ValorAbatido set ValorTotalAbatimento = @Valor where Id_PagamentoParcial = @idPagamentoParcial";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@idPagamentoParcial", IdPagamentoParcial);
            comando.Parameters.AddWithValue("@Valor", (valorVenda - desconto));
            comando.CommandText = _sql;

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void AlterarValorDesconto()
        {
            if (valorVenda < desconto)
            {
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "update Venda set Desconto = 0.00 where id_Venda = @idVenda";
                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@idVenda", CodVenda);
                comando.CommandText = _sql;

                try
                {
                    conexao.Open();
                    comando.ExecuteNonQuery();
                    desconto = 0.00m;
                    lblDesconto.Text = "R$ 0,00";
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
        }

        private void AlterarLucroItens()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update ItensVenda set lucroItens = lucroItens - @LucroItens where id_ItensVenda = @idItensVenda";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@idItensVenda", dgv_ListaVenda.CurrentRow.Cells["ColIdItensVenda"].Value);
            comando.Parameters.AddWithValue("@LucroItens", ((lucroItens / qtdItens) * qtdItensDevolvido));
            comando.CommandText = _sql;

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void ExcluirParcelas()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update ParcelaVenda set DataPagamento = @DataPagamento, HoraPagamento = @HoraPagamento where id_Venda = @idVenda and DataPagamento = '' and HoraPagamento = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@idVenda", CodVenda);
            comando.Parameters.AddWithValue("@DataPagamento", DateTime.Now.ToShortDateString());
            comando.Parameters.AddWithValue("@HoraPagamento", DateTime.Now.ToShortTimeString());
            comando.CommandText = _sql;

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void AlterarValor_E_LucroVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update Venda set ValorTotal = @ValorTotal, Lucro = Lucro - @Lucro where id_Venda = @idVenda";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@idVenda", CodVenda);
            comando.Parameters.AddWithValue("@ValorTotal", (valorVenda - desconto));
            comando.Parameters.AddWithValue("@Lucro", ((lucroItens / qtdItens) * qtdItensDevolvido));
            comando.CommandText = _sql;

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void AlterarValoresParcelas()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update ParcelaVenda set valorParcelado = @ValorParcela where id_Venda = @idVenda and DataPagamento = '' and HoraPagamento = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@idVenda", CodVenda);
            comando.Parameters.AddWithValue("@ValorParcela", valorParcela);
            comando.CommandText = _sql;

            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
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

        private void verificarNumeroParcelas()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select count(Parcela) from ParcelaVenda where id_Venda = @idVenda and DataPagamento = '' and HoraPagamento = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@idVenda", CodVenda);
            comando.CommandText = _sql;

            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    qtdParcela = int.Parse(comando.ExecuteScalar().ToString());
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

        private void deleteUpdateItensVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            if (qtdItens >= 2)
            {
                if (qtdItensDevolvido == qtdItens)
                {
                    _sql = "delete from ItensVenda where id_Produto = " + dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString() + "and id_Venda = " + CodVenda;
                }
                else
                {
                    _sql = "update ItensVenda set Quantidade = Quantidade - " + qtdItensDevolvido + ", Valor = Valor - ((Valor / " + qtdItens + ") * " + qtdItensDevolvido + ") where id_Produto = " + dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString() + "and id_Venda = " + CodVenda;
                }
            }
            else
            {
                _sql = "delete from ItensVenda where id_Produto = " + dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString() + "and id_Venda = " + CodVenda;
            }
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Item(ns) devolvido!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        int X = 0, Y = 0;
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

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Transparent;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_ListaVenda_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }

        private void Menu_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_ListaVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int contLinhas = e.RowIndex;
            if (contLinhas > -1)
            {
                DataGridViewRow linhas = dgv_ListaVenda.Rows[contLinhas];
                descricao = linhas.Cells["ColDescricao"].Value.ToString();
                qtdItens = int.Parse(linhas.Cells["ColQuantidade"].Value.ToString());
                valorSubTotal = decimal.Parse(linhas.Cells["ColValorSubTotal"].Value.ToString());
                lucroItens = decimal.Parse(linhas.Cells["ColLucroItens"].Value.ToString());
            }
        }
    }
}
