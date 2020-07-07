using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVendaDevolucaoItens : Form
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql, descricao, idFluxoCaixa, codCliente, dataVenda, cliente;

        int MaxCodVenda, idPagamentoParcial, qtdItens, qtdItensDevolvido = 1;
        int idPagamentoMisto;
        decimal lucroItens, valorPago, valorRestante, valorAbatido, ValorTotalPagamentoParcial, valorVenda, valorEntrada, sumValorParcelado, valorSubTotal, ValorCaixaInicial, valorReceber, ValorRecebidoDebito, desconto, descontoVendaAtual;

        bool devolucaoItensTudo = false;

        public FrmVendaDevolucaoItens(string codVenda, string cliente, string formaPagamento, string valorVenda, string codCliente, string dataVenda, string desconto)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.dataVenda = dataVenda;
            this.desconto = decimal.Parse(desconto);
            descontoVendaAtual = this.desconto;
            this.valorVenda = decimal.Parse(valorVenda) + this.desconto;
            lblCodigoVenda.Text = codVenda;
            lblCliente.Text = cliente;
            lblValorTotalComDesconto.Text = "R$ " + valorVenda;
            lblDesconto.Text = "R$ " + desconto;
            this.codVenda = codVenda;
            this.formaPagamento = formaPagamento;
            this.codCliente = codCliente;
            lblValorTotalSemDesconto.Text = "R$ " + (decimal.Parse(valorVenda) + decimal.Parse(desconto));

            getIdVendaComValorRestante();

            if (formaPagamento == "VISTA")
            {
                valorPago = decimal.Parse(valorVenda);
            }
            else if (formaPagamento == "PAGAMENTO PARCIAL")
            {
                getValorReceberPagamentoParcial();
            }
            else if(formaPagamento == "MISTO")
            {
                getValorReceberPagamentoMisto();
            }
            else if (formaPagamento == "PARCELADO")
            {
                InformarValoresPagos();
                VerificarParcelas_E_ValorEntrada();
                valorEntrada = this.valorVenda - sumValorParcelado;
                valorPago += valorEntrada;
            }
            else if((formaPagamento == "PRAZO"))
            {
                InformarValoresPagos();
            }
        }

        private void getValorReceberPagamentoMisto()
        {
            receberValor_e_IdPagamentoMisto();
            ValorTotalPagamentoMisto = valorRestante + ReceberValorAbatidoMisto();
        }

        private decimal ReceberValorAbatidoMisto()
        {
            if(valorRestante == 0.00m)
            {
                valorAbatido = valorVenda - desconto;
                return valorAbatido;
            }
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select Sum(ValorTotalAbatimento) as ValorTotalAbatimento from ValorMistoAbatido where Id_PagamentoMisto = @IdPagamentoMisto";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamentoMisto", idPagamentoMisto);
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

        private void receberValor_e_IdPagamentoMisto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select PagamentoMisto.ValorRestante, PagamentoMisto.Id_PagamentoMisto from PagamentoMisto inner join Venda on Venda.Id_Venda = PagamentoMisto.Id_Venda where Venda.Id_Cliente = @IdCliente and PagamentoMisto.ValorRestante > 0";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    idPagamentoMisto = int.Parse(dr["Id_PagamentoMisto"].ToString());
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

        private void getValorReceberPagamentoParcial()
        {
            receberValor_e_IdPagamentoParcial();
            ValorTotalPagamentoParcial = valorRestante + ReceberValorAbatido();
        }

        private void BuscarValorReceberFluxCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select ValorReceber from FluxoCaixa where DataSaida = '' and HoraSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
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
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
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
            if (formaPagamento == "PARCELADO")
            {
                _sql = "SELECT SUM(ParcelaVenda.ValorParcelado) as ValorPago FROM ParcelaVenda INNER JOIN FormaPagamento ON ParcelaVenda.Id_Venda = FormaPagamento.Id_Venda WHERE ParcelaVenda.Id_Venda = @IdVenda AND ParcelaVenda.DataPagamento <> '' AND FormaPagamento.Descricao = 'PARCELADO'";
            }
            else if (formaPagamento == "PRAZO")
            {
                _sql = "SELECT SUM(ParcelaVenda.ValorParcelado) as ValorPago FROM ParcelaVenda INNER JOIN FormaPagamento ON ParcelaVenda.Id_Venda = FormaPagamento.Id_Venda WHERE ParcelaVenda.Id_Venda = @IdVenda AND ParcelaVenda.DataPagamento <> '' AND FormaPagamento.Descricao = 'PRAZO'";
            }
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    valorPago = decimal.Parse(comando.ExecuteScalar().ToString());
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
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    idPagamentoParcial = int.Parse(dr["Id_PagamentoParcial"].ToString());
                    valorRestante = decimal.Parse(dr["ValorRestante"].ToString());
                }
                else
                {
                    valorRestante = 0.00m;
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

        private decimal ReceberValorAbatido()
        {
            if(valorRestante == 0.00m)
            {
                valorAbatido = valorVenda - desconto;
                return valorAbatido;
            }

            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select Sum(ValorTotalAbatimento) as ValorTotalAbatimento from ValorAbatido where Id_PagamentoParcial = @IdPagamentoParcial";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamentoParcial", idPagamentoParcial);
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
                    if (formaPagamento == "PAGAMENTO PARCIAL")
                        _sql = "Select Min(Venda.Id_Venda) as MaxCodVenda from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda where Venda.Id_Venda > " + codVenda + " and Venda.Id_Cliente = " + codCliente + " and FormaPagamento.Descricao = 'PAGAMENTO PARCIAL'";
                    else
                        _sql = "Select Min(Venda.Id_Venda) as MaxCodVenda from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda where Venda.Id_Venda > " + codVenda + " and Venda.Id_Cliente = " + codCliente + " and FormaPagamento.Descricao = 'MISTO'";
                }
                else if (MaxCodVenda > 0 && formaPagamento == "PAGAMENTO PARCIAL")
                {
                    _sql = "update PagamentoParcial set Id_Venda = " + MaxCodVenda + " where id_PagamentoParcial = " + getIdPagamentoParcialOrMisto();
                }
                else if (MaxCodVenda > 0 && formaPagamento == "MISTO")
                {
                    _sql = "update PagamentoMisto set Id_Venda = " + MaxCodVenda + "where id_PagamentoMisto = " + idPagamentoMisto;
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

        bool codVendaIgual = false;

        private void VerificarIdVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "select * from PagamentoParcial where Id_Venda = @IdVenda";
            else
                _sql = "select * from PagamentoMisto where Id_Venda = @IdVenda";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codVendaIgual = true;
                }
                else
                {
                    codVendaIgual = false;
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
                _sql = "select ItensVenda.id_ItensVenda, ItensVenda.Id_Produto, produto.Descricao, ItensVenda.Valor, ItensVenda.Quantidade, ItensVenda.lucroItens, Venda.DataVenda from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join ItensVenda on ItensVenda.Id_Venda = Venda.Id_Venda inner join Produto on Produto.Id_Produto = ItensVenda.Id_Produto where Venda.Id_Venda = " + codVenda;
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

        string codVenda = "", formaPagamento;

        private void btnDevolverTudo_Click(object sender, EventArgs e)
        {
            devolucaoItensTudo = true;
            DialogResult dr = MessageBox.Show("Deseja mesmo aceitar a devolução do(s) produto(s)?", "Caixa Fácil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                bool retirarValorCaixa = true;

                if (valorCaixa > 0)
                {
                    if (valorCaixa < valorPago)
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

                if (formaPagamento == "PAGAMENTO PARCIAL" || formaPagamento == "MISTO")
                {
                    IdPagamento = getIdPagamentoParcialOrMisto();
                    if (GetQtdRegistroVenda() > 1)
                    {
                        GravarTudoHistoricoDevolucao();
                    }
                    else
                    {
                        RemoverHistoricoDevolucao();
                        RemoverTipoPagamento();
                    }
                }
                else if(formaPagamento == "PRAZO" || formaPagamento == "PARCELADO")
                {
                    RemoverTipoPagamento();
                }

                AlterarValoresPagamentoParcialOrMisto_Parcelado();
                verificarDataPagamento_E_AtualizarValoresFluxoCaixa();
                ExcluirTodosItensVenda();
                Backup.GerarBackup();

                if (retirarValorCaixa)
                    GerenciarFluxoCaixa();

                AtualizarTodoEstoque();
                this.Close();
            }
        }

        private void RemoverTipoPagamento()
        {
            int id;
            if (formaPagamento == "PAGAMENTO PARCIAL" || formaPagamento == "MISTO")
            {
                id = IdPagamento;

                if (formaPagamento == "PAGAMENTO PARCIAL")
                    _sql = "delete from TipoPagamento where Id_PagamentoParcial = @Id";
                else if (formaPagamento == "MISTO")
                    _sql = "delete from TipoPagamento where Id_PagamentoMisto = @Id";

                RemoverRowsTipoPagamento(id, _sql);
            }

            else if (formaPagamento == "PARCELADO" || formaPagamento == "PRAZO")
            {
                foreach(DataRow dr in getIdsParcela().Rows)
                {
                    _sql = "delete from TipoPagamento where Id_Parcela = @Id";
                    id = int.Parse(dr["Id_Parcela"].ToString());
                    RemoverRowsTipoPagamento(id, _sql);
                }
            }            
        }

        private DataTable getIdsParcela()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select Id_Parcela from ParcelaVenda where Id_Venda = @idVenda and DataPagamento <> ''";
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.Parameters.AddWithValue("@idVenda", codVenda);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }

        private void RemoverRowsTipoPagamento(int id, string sql)
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            SqlCommand comando = new SqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@id", id);
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

        int IdPagamento;

        private int GetQtdRegistroVenda()
        {
            PegarRegistrosIdVendaAndIdPagamentoParcialOrMisto();

            return getQuantidadeRegistroVenda();
        }

        private int getQuantidadeRegistroVenda()
        {
            int qtdRegistro = 0;

            SqlConnection conexao = new SqlConnection(stringConn);
            if (formaPagamento == "PAGAMENTO PARCIAL")
            {
                if (existsOutraConta)
                {
                    _sql = "select count(Venda.Id_Venda) as Id_Venda from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'PAGAMENTO PARCIAL' and Venda.Id_Venda between @IdVendaPagamento and @GetVenda";
                }
                else
                {
                    _sql = "select count(Venda.Id_Venda) as Id_Venda from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'PAGAMENTO PARCIAL' and Venda.Id_Venda >= @IdVendaPagamento";
                }
            }
            else
            {
                if (existsOutraConta)
                {
                    _sql = "select count(Venda.Id_Venda) as Id_Venda from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'MISTO' and Venda.Id_Venda between @IdVendaPagamento and @GetVenda";
                }
                else
                {
                    _sql = "select count(Venda.Id_Venda) as Id_Venda from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'MISTO' and Venda.Id_Venda >= @IdVendaPagamento";
                }
            }

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@CodVenda", codVenda);
            comando.Parameters.AddWithValue("@IdVendaPagamento", idVendaPagamentoParcialOrMisto);
            comando.Parameters.AddWithValue("@GetVenda", (getIdVenda - 1));
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    qtdRegistro = int.Parse(dr["Id_Venda"].ToString());
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

            return qtdRegistro;
        }

        private int getCodVendaPagamentoParcialOrMisto()
        {
            int codVenda_PagamentoOrMisto = 0;

            SqlConnection conexao = new SqlConnection(stringConn);
            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "select Max(venda.Id_Venda) as Id_Venda from PagamentoParcial inner join Venda on venda.Id_Venda = PagamentoParcial.Id_Venda inner join Cliente on cliente.Id_Cliente = Venda.Id_Cliente where Venda.id_Venda <= @IdVenda and Venda.Id_Cliente = @IdCliente";
            else
                _sql = "select Max(venda.Id_Venda) as Id_Venda from PagamentoMisto inner join Venda on venda.Id_Venda = PagamentoMisto.Id_Venda inner join Cliente on cliente.Id_Cliente = Venda.Id_Cliente where Venda.id_Venda <= @IdVenda and Venda.Id_Cliente = @IdCliente";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codVenda_PagamentoOrMisto = int.Parse(dr["Id_Venda"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fàcil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return codVenda_PagamentoOrMisto;
        }

        private void GravarTudoHistoricoDevolucao()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            
            foreach (DataGridViewRow row in dgv_ListaVenda.Rows)
            {
                if (formaPagamento == "PAGAMENTO PARCIAL")
                    _sql = "insert into HistoricoDevolucao (Id_Produto, ValorProduto, qtdItens, Id_PagamentoParcial, DataDevolucao) values (@IdProduto, @ValorProduto, @qtdItens, @IdPagamento, @DataDevolucao)";
                else if (formaPagamento == "MISTO")
                    _sql = "insert into HistoricoDevolucao (Id_Produto, ValorProduto, qtdItens, Id_PagamentoMisto, DataDevolucao) values (@IdProduto, @ValorProduto, @qtdItens, @IdPagamento, @DataDevolucao)";

                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@IdProduto", int.Parse(row.Cells["ColCodProduto"].Value.ToString()));
                comando.Parameters.AddWithValue("@ValorProduto", decimal.Parse(row.Cells["ColValorSubTotal"].Value.ToString()));
                comando.Parameters.AddWithValue("@qtdItens", int.Parse(row.Cells["ColQuantidade"].Value.ToString()));
                comando.Parameters.AddWithValue("@IdPagamento", getIdPagamentoParcialOrMisto());
                comando.Parameters.AddWithValue("@DataDevolucao", DateTime.Now.ToShortDateString());
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

        private void RemoverHistoricoDevolucao()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            foreach (DataGridViewRow row in dgv_ListaVenda.Rows)
            {
                if (formaPagamento == "PAGAMENTO PARCIAL")
                    _sql = "delete from HistoricoDevolucao where Id_PagamentoParcial = @IdPagamento";
                else if (formaPagamento == "MISTO")
                    _sql = "delete from HistoricoDevolucao where Id_PagamentoMisto = @IdPagamento";

                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@IdPagamento", getIdPagamentoParcialOrMisto());
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

        decimal subValorVendaValorAbatido, subValorReceber, valorContaTotal, valorContaFinal;

        private void AlterarValoresPagamentoParcialOrMisto_Parcelado()
        {           
            // primeiro Verifica se o idVenda informado é igual ao idVenda da tabela Pagamento Parcial

            if (formaPagamento == "PAGAMENTO PARCIAL" || formaPagamento == "MISTO")
            {
                VerificarIdVenda();

                getValorDescontoConta();

                getValorAbatido();

                valorContaTotal = valorAbatido + valorRestante + desconto;

                valorContaFinal = ((valorContaTotal - valorVenda) - (desconto - descontoVendaAtual));
                if (valorRestante > 0)
                {
                    subValorVendaValorAbatido = valorAbatido - valorContaFinal;
                    if (subValorVendaValorAbatido > 0)
                    {
                        decimal valorDevolver = subValorVendaValorAbatido;

                        if (GetQtdRegistroVenda() == 1)
                        {
                            valorDevolver = valorAbatido;
                            MessageBox.Show("O(A) cliente  " + cliente + " abateu R$ "+ valorAbatido + " em uma conta que está no valor de " + lblValorTotalComDesconto.Text + ". Com a devolução o valor a ser devolvido ao cliente é de R$ " + valorDevolver + " reais.", "Aviso do sistema Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Contabilizando a conta do(a) cliente  " + cliente + ", o valor total da conta é R$ " + (valorContaTotal - desconto) + ". O(A) cliente abateu R$ " + valorAbatido + " e com a devolução do(s) item(ns) selecionado(s) que está no valor de " + lblValorTotalComDesconto.Text + " o(a) cliente passa a não ter dívidas e receberá o valor de R$ " + valorDevolver + ".", "Aviso do sistema Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        valorPago = valorDevolver;
                        subValorVendaValorAbatido = 0;
                    }
                    else if (subValorVendaValorAbatido == 0)
                    {
                        MessageBox.Show("O valor da conta de " + cliente + " é R$ " + (valorContaTotal - desconto) + " e abateu R$ " + valorAbatido + ". Com a devolução do(s) produto(s) envolvido(s) nesta operação que bate o valor de " + lblValorTotalComDesconto.Text + " o valor abatido iguala com o valor do(s) item(s) restantes que bate no valor de R$ " + valorContaFinal + " e o(a) cliente passa a não ter mais dívidas com o estabelecimento até o presente momento.", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (subValorVendaValorAbatido < 0)
                    {
                        subValorVendaValorAbatido = ((valorContaTotal - valorVenda) - (desconto - descontoVendaAtual) - valorAbatido);
                        MessageBox.Show("Com a devolução do(s) produto(s) o(a) cliente passa a dever R$ " + subValorVendaValorAbatido + ".", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (int.Parse(codVenda) >= IdVendaComValorRestante)
                        AlterarValorRestantePagamentoParcialOrMisto();
                }
                else
                {
                    MessageBox.Show("Itens devolvidos! O valor já foi pago pelo cliente está no valor de R$ " + lblValorTotalComDesconto.Text, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    valorPago = valorVenda - desconto;
                }

                if (codVendaIgual)
                {
                    if (GetQtdRegistroVenda() > 1)
                    {
                        InformarIdVendaMaximo();
                    }
                }
            }
        }

        bool existsOutraConta = false;

        private void getValorDescontoConta()
        {
            PegarRegistrosIdVendaAndIdPagamentoParcialOrMisto();

            desconto = getDesconto();
        }

        private void PegarRegistrosIdVendaAndIdPagamentoParcialOrMisto()
        {
            // Primeira coisa é pegar o id_Venda da tabela PagamentoParcial

            GetIdVendaPagamentoParcialOrMisto();

            // Agora deve verificar se existe outra compra neste formato pelo mesmo cliente

            if (VerificarOutrasContas())
            {
                existsOutraConta = true;
                GetIdPagamentoParcialOrMistoAndIdVenda();
            }
        }

        private decimal getDesconto()
        {
            decimal desconto = 0;

            SqlConnection conexao = new SqlConnection(stringConn);
            if (formaPagamento == "PAGAMENTO PARCIAL")
            {
                if (existsOutraConta)
                {
                    _sql = "select sum(Venda.desconto) as desconto from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'PAGAMENTO PARCIAL' and Venda.Id_Venda between @IdVendaPagamento and @GetVenda";
                }
                else
                {
                    _sql = "select sum(Venda.desconto) as desconto from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'PAGAMENTO PARCIAL' and Venda.Id_Venda >= @IdVendaPagamento";
                }
            }
            else
            {
                if (existsOutraConta)
                {
                    _sql = "select sum(Venda.desconto) as desconto from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'MISTO' and Venda.Id_Venda between @IdVendaPagamento and @GetVenda";
                }
                else
                {
                    _sql = "select sum(Venda.desconto) as desconto from Venda inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and FormaPagamento.Descricao = 'MISTO' and Venda.Id_Venda >= @IdVendaPagamento";
                }
            }

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@CodVenda", codVenda);
            comando.Parameters.AddWithValue("@IdVendaPagamento", idVendaPagamentoParcialOrMisto);
            comando.Parameters.AddWithValue("@GetVenda", (getIdVenda - 1));
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    desconto = decimal.Parse(dr["desconto"].ToString());
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

            return desconto;
        }

        int getIdVenda;
        
        private void GetIdPagamentoParcialOrMistoAndIdVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            
            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "select min(PagamentoParcial.Id_PagamentoParcial) as Id_PagamentoParcial, Venda.Id_Venda from PagamentoParcial inner join Venda on Venda.id_Venda = PagamentoParcial.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and PagamentoParcial.Id_Venda > @IdVenda group by Venda.Id_Venda";
            else
                _sql = "select min(PagamentoMisto.Id_PagamentoMisto) as Id_PagamentoMisto, Venda.Id_Venda from PagamentoMisto inner join Venda on Venda.id_Venda = PagamentoMisto.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and PagamentoMisto.Id_Venda > @IdVenda group by Venda.Id_Venda";
            
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    getIdVenda = int.Parse(dr["Id_Venda"].ToString());
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

        int idVendaPagamentoParcialOrMisto;

        private void GetIdVendaPagamentoParcialOrMisto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "select Venda.Id_Venda from PagamentoParcial inner join Venda on Venda.id_Venda = PagamentoParcial.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and PagamentoParcial.Id_PagamentoParcial = @IdPagamento";
            else
            {
                _sql = "select Venda.Id_Venda from PagamentoMisto inner join Venda on Venda.id_Venda = PagamentoMisto.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and PagamentoMisto.Id_PagamentoMisto = @IdPagamento";
            }

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamento", IdPagamento);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    idVendaPagamentoParcialOrMisto = int.Parse(dr["Id_Venda"].ToString());
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
        
        private bool VerificarOutrasContas()
        {
            bool existsConta = false;

            SqlConnection conexao = new SqlConnection(stringConn);

            if (formaPagamento == "PAGAMENTO PARCIAL")
            {
                _sql = "select PagamentoParcial.Id_PagamentoParcial from PagamentoParcial inner join Venda on Venda.id_Venda = PagamentoParcial.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and PagamentoParcial.Id_PagamentoParcial > @IdPagamento";
            }
            else
            {
                _sql = "select PagamentoMisto.Id_PagamentoMisto from PagamentoMisto inner join Venda on Venda.id_Venda = PagamentoMisto.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where Venda.Id_Cliente = @IdCliente and PagamentoMisto.Id_PagamentoMisto > @IdPagamento";
            }

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamento", IdPagamento);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if(dr.Read())
                {
                    valorRestante = 0.00m;
                    existsConta = true;
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

            return existsConta;
        }

        private decimal getValorAbatido()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "select sum(ValorTotalAbatimento) from ValorAbatido where Id_PagamentoParcial = @IdPagamento";
            else
            {
                _sql = "select sum(ValorTotalAbatimento) from ValorMistoAbatido where Id_PagamentoMisto = @IdPagamento";
            }

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamento", IdPagamento);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    valorAbatido = decimal.Parse(comando.ExecuteScalar().ToString());
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

        int IdVendaComValorRestante;

        private void getIdVendaComValorRestante()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "select MIN(PagamentoParcial.Id_Venda) as Id_Venda from PagamentoParcial inner join Venda on Venda.Id_Venda = PagamentoParcial.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where ValorRestante > 0 and Venda.Id_Cliente = @IdCliente";
            else
                _sql = "select MIN(PagamentoMisto.Id_Venda) as Id_Venda from PagamentoMisto inner join Venda on Venda.Id_Venda = PagamentoMisto.Id_Venda inner join Cliente on Cliente.Id_Cliente = Venda.Id_Cliente where ValorRestante > 0 and Venda.Id_Cliente = @IdCliente";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();                
                if (comando.ExecuteScalar() != DBNull.Value)
                {
                    IdVendaComValorRestante = int.Parse(comando.ExecuteScalar().ToString());
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

        private void AlterarValorRestantePagamentoMisto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            _sql = "update PagamentoMisto set ValorRestante = @ValorRestante where Id_PagamentoMisto = @IdPagamentoMisto";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorRestante", subValorVendaValorAbatido);
            comando.Parameters.AddWithValue("@IdPagamentoMisto", idPagamentoMisto);
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

        private void verificarDataPagamento_E_AtualizarValoresFluxoCaixa()
        {
            if (formaPagamento == "PAGAMENTO PARCIAL" || formaPagamento == "MISTO")
            {
                VerificarDataAbatimentoDataVenda();
                subValorReceber = valorReceber - (valorVenda - valorAbatido);
                if (valorReceber >= subValorReceber)
                    AtualizarValorReceberPagamentoParcialOrMisto();
            }
            else if (formaPagamento == "PRAZO")
            {
                subValorReceber = valorVenda;
            }
            else if (formaPagamento == "Cartão de Débito")
            {
                ValorRecebidoDebito = valorVenda;
                AtualizarValorRecebidoDebito();
            }
            else
            {
                subValorReceber = valorVenda - valorPago;
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
            if(qtdItens == 0)
            {
                qtdItens = 1;
            }

            if (formaPagamento == "PARCELADO" || formaPagamento == "PRAZO")
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

        private void AtualizarValorReceberPagamentoParcialOrMisto()
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

            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "Select ValorTotalAbatimento, DataPagamento from ValorAbatido where Id_PagamentoParcial = @IdPagamentoParcial";
            else
                _sql = "Select ValorTotalAbatimento, DataPagamento from ValorMistoAbatido where Id_PagamentoMisto = @IdPagamentoMisto";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamentoParcial", idPagamentoParcial);
            comando.Parameters.AddWithValue("@IdPagamentoMisto", idPagamentoMisto);
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

        private void AlterarValorRestantePagamentoParcialOrMisto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "update PagamentoParcial set ValorRestante = @ValorRestante where Id_PagamentoParcial = @IdPagamentoParcial";
            else
                _sql = "update PagamentoMisto set ValorRestante = @ValorRestante where Id_PagamentoMisto = @IdPagamentoMisto";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorRestante", subValorVendaValorAbatido);
            comando.Parameters.AddWithValue("@IdPagamentoParcial", idPagamentoParcial);
            comando.Parameters.AddWithValue("@IdPagamentoMisto", idPagamentoMisto);
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
            if (valorCaixa >= valorPago)
            {
                if(devolucaoItensTudo)
                comando.Parameters.AddWithValue("@Valor", valorPago);
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
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                string messagem = "";
                if (formaPagamento == "VISTA")
                {
                    if ((valorVenda - desconto) > 0)
                    {
                        messagem = " O valor já foi pago pelo cliente está no valor de R$ " + (valorVenda - desconto);
                    }

                    MessageBox.Show("Itens devolvidos!" + messagem, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (formaPagamento == "PARCELADO")
                {
                    if (valorPago > 0)
                    {
                        messagem = " O valor já foi pago pelo cliente está no valor de R$ " + valorPago;
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
                MessageBox.Show("Informe a quantidade de itens que vai ser devolvida.", "Aviso do sistema Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmDevolverQuantidadeItens devolverQuantidadeItens = new FrmDevolverQuantidadeItens(qtdItens);
                devolverQuantidadeItens.ShowDialog();
                if (devolverQuantidadeItens.qtdItens > 0)
                {
                    qtdItensDevolvido = devolverQuantidadeItens.qtdItens;
                }
                else
                {
                    MessageBox.Show("É necessário informar a quantidade de itens que vai ser devolvida.", "Aviso do sistema Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (formaPagamento == "VISTA")
            {
                valorPago = decimal.Parse(dgv_ListaVenda.CurrentRow.Cells["ColvalorSubTotal"].Value.ToString());
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
                if (qtdItens == 0)
                    qtdItens = 1;

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
            if (formaPagamento == "PARCELADO" || formaPagamento == "PRAZO")
            {
                AtualizarValorReceberPagamentoPrazoParcela();
            }
            else if (formaPagamento == "Cartão de Débito")
            {
                ValorRecebidoDebito = ((valorSubTotal / qtdItens) * qtdItensDevolvido);
                AtualizarValorRecebidoDebito();
            }
            else if (formaPagamento == "PAGAMENTO PARCIAL" || formaPagamento == "MISTO")
            {
                subValorReceber = (valorReceber + valorAbatido) - ((valorSubTotal / qtdItens) * qtdItensDevolvido) - valorAbatido;
                VerificarDataAbatimentoDataVenda();
                if (valorReceber >= subValorReceber)
                    AtualizarValorReceberPagamentoParcialOrMisto();
            }
            else if (formaPagamento == "VISTA")
            {
                GerenciarFluxoCaixa();
            }

            AtualizarEstoque();
            dgv_ListaVenda.Rows.Remove(dgv_ListaVenda.CurrentRow);
            ListaTodasVendas();

            lblValorTotalComDesconto.Text = "R$ " + (valorVenda - desconto);
            lblValorTotalSemDesconto.Text = "R$ " + valorVenda;
            Backup.GerarBackup();
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
                if (qtdItens == 0)
                    qtdItens = 1;

                subValoresTotalUnitario = valorSubTotal - ((valorSubTotal / qtdItens) * qtdItensDevolvido);
                valorVenda = (valorVenda - ((valorSubTotal / qtdItens) * qtdItensDevolvido));
            }

            if (formaPagamento == "PARCELADO")
            {
                if ((valorPago) < valorVenda)
                {
                    verificarNumeroParcelas();
                    valorParcela = (valorVenda - (valorPago)) / qtdParcela;
                    AlterarValoresParcelas();
                }
                else
                {
                    decimal subValorPagoValorVenda = valorPago - valorVenda;
                    MessageBox.Show("Informamos que o cliente pagou R$ " + Math.Ceiling(valorPago).ToString("0.00") + " reais, e com devolução do{s} produto(s) pela contabilização dos valores da venda com tudo que já foi pago, fica constatado que o cliente tem o direito de receber R$" + Math.Ceiling(subValorPagoValorVenda).ToString("0.00") + ". A partir deste momento a conta do cliente zera.", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExcluirParcelas();
                }
            }
            else if (formaPagamento == "PRAZO")
            {
                valorParcela = subValoresTotalUnitario;               
            }
            else if (formaPagamento == "VISTA")
            {
                valorPago = subValoresTotalUnitario;
            }
            else if (formaPagamento == "PAGAMENTO PARCIAL" || formaPagamento == "MISTO")
            {
                if (formaPagamento == "PAGAMENTO PARCIAL")
                    getValorReceberPagamentoParcial();
                else
                    getValorReceberPagamentoMisto();

                subValorVendaValorAbatido = ((valorRestante + valorAbatido) - (valorSubTotal / qtdItens * qtdItensDevolvido) - valorAbatido);

                if (subValorVendaValorAbatido < 0)
                {
                    if ((valorVenda - desconto) < valorAbatido && valorRestante > 0)
                    {
                        subValorVendaValorAbatido = (valorVenda - desconto) - valorAbatido;
                        if(subValorVendaValorAbatido < 0 && valorAbatido > 0)
                        {
                            valorContaTotal = valorAbatido + valorRestante + desconto;

                            decimal valorDevolver = valorAbatido - ((valorContaTotal - valorSubTotal) - desconto);

                            MessageBox.Show("Contabilizando a conta do(a) cliente  " + cliente + ", o valor total da conta é R$ " + (valorContaTotal - desconto) + ". O(A) cliente abateu R$ " + valorAbatido + " e com a devolução do(s) item selecionado(s) que está no valor de R$ " + valorSubTotal + " o(a) cliente passa a não ter dívidas e  receberá o valor de R$ " + valorDevolver + ".", "Aviso do sistema Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            subValorVendaValorAbatido = 0;
                        }
                        else
                            MessageBox.Show("Com a devolução do(a) " + dgv_ListaVenda.CurrentRow.Cells["ColDescricao"].Value.ToString() + " o cliente passa a dever R$ " + subValorVendaValorAbatido, "Aviso do sistema Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (valorVenda == valorAbatido && valorRestante > 0)
                    {
                        MessageBox.Show("Com o valor da venda se igualando com o valor que já foi abatido pelo cliente, o cliente passa a não ter dívidas com o estabelicimento.", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        subValorVendaValorAbatido = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Com a devolução do(a) " + dgv_ListaVenda.CurrentRow.Cells["ColDescricao"].Value.ToString() + " o cliente passa a dever R$ " + subValorVendaValorAbatido, "Aviso do sistema Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (subValorVendaValorAbatido >= 0)
                    if (int.Parse(codVenda) >= IdVendaComValorRestante)
                        AlterarValorRestantePagamentoParcialOrMisto();
            }

            GravarItensHistoricoDevolucao();
            AlterarLucroItens();
            AlterarValorDesconto();
            AlterarValor_E_LucroVenda();
        }

        private void GravarItensHistoricoDevolucao()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            if (formaPagamento == "PAGAMENTO PARCIAL")
                _sql = "insert into HistoricoDevolucao (Id_Produto, ValorProduto, qtdItens, Id_PagamentoParcial, DataDevolucao) values (@IdProduto, @ValorProduto, @qtdItens, @IdPagamento, @DataDevolucao)";
            else if (formaPagamento == "MISTO")
                _sql = "insert into HistoricoDevolucao (Id_Produto, ValorProduto, qtdItens, Id_PagamentoMisto, DataDevolucao) values (@IdProduto, @ValorProduto, @qtdItens, @IdPagamento, @DataDevolucao)";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdProduto", dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString());
            comando.Parameters.AddWithValue("@ValorProduto", subValoresTotalUnitario);
            comando.Parameters.AddWithValue("@qtdItens", qtdItensDevolvido);
            comando.Parameters.AddWithValue("@DataDevolucao", DateTime.Now.ToShortDateString());
            comando.Parameters.AddWithValue("@IdPagamento", getIdPagamentoParcialOrMisto());
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private int getIdPagamentoParcialOrMisto()
        {
            int IdPagamento = 0;
            string column;

            SqlConnection conexao = new SqlConnection(stringConn);
            if (formaPagamento == "PAGAMENTO PARCIAL")
            {
                _sql = "select Max(PagamentoParcial.Id_PagamentoParcial) as Id_PagamentoParcial from PagamentoParcial inner join Venda on venda.Id_Venda = PagamentoParcial.Id_Venda inner join Cliente on cliente.Id_Cliente = Venda.Id_Cliente where Venda.id_Venda <= @IdVenda and Venda.Id_Cliente = @IdCliente";
                column = "Id_PagamentoParcial";
            }
            else
            {
                _sql = "select Max(PagamentoMisto.Id_PagamentoMisto) as Id_PagamentoMisto from PagamentoMisto inner join Venda on venda.Id_Venda = PagamentoMisto.Id_Venda inner join Cliente on cliente.Id_Cliente = Venda.Id_Cliente where Venda.id_Venda <= @IdVenda and Venda.Id_Cliente = @IdCliente";
                column = "Id_PagamentoMisto";
            }
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdVenda", codVenda);
            comando.Parameters.AddWithValue("@IdCliente", codCliente);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    IdPagamento = int.Parse(dr[column].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fàcil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return IdPagamento;
        }       

        private void AlterarValorDesconto()
        {
            if (valorVenda < desconto)
            {
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "update Venda set Desconto = 0.00 where id_Venda = @idVenda";
                SqlCommand comando = new SqlCommand(_sql, conexao);
                comando.Parameters.AddWithValue("@idVenda", codVenda);
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
            comando.Parameters.AddWithValue("@idVenda", codVenda);
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
            comando.Parameters.AddWithValue("@idVenda", codVenda);
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
            comando.Parameters.AddWithValue("@idVenda", codVenda);
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
            comando.Parameters.AddWithValue("@idVenda", codVenda);
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
                    _sql = "delete from ItensVenda where id_Produto = " + dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString() + "and id_Venda = " + codVenda;
                }
                else
                {
                    _sql = "update ItensVenda set Quantidade = Quantidade - " + qtdItensDevolvido + ", Valor = Valor - ((Valor / " + qtdItens + ") * " + qtdItensDevolvido + ") where id_Produto = " + dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString() + "and id_Venda = " + codVenda;
                }
            }
            else
            {
                _sql = "delete from ItensVenda where id_Produto = " + dgv_ListaVenda.CurrentRow.Cells["ColCodProduto"].Value.ToString() + "and id_Venda = " + codVenda;
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
        decimal ValorTotalPagamentoMisto;

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
