using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmListaDevolucao : Form
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql, FormaPagamento;
        int IdPagamento;

        public FrmListaDevolucao(int IdPagamento, string FormaPagamento)
        {
            InitializeComponent();
            this.IdPagamento = IdPagamento;
            this.FormaPagamento = FormaPagamento;
        }

        private void FrmListavenda_Load(object sender, EventArgs e)
        {
            dgvListaItensDevolvidos.DataSource = ListaItensDevolvidos();
            txtValorContaInicial.Text = "R$ " + (getValorContaInicial() + getValorItensDevolvidos());
            txtValorItensDevolvidos.Text = "R$ " + getValorItensDevolvidos();
            txtValorContaAtual.Text = "R$ " + getValorContaInicial();
        }

        private decimal getValorItensDevolvidos()
        {
            decimal valorItensDevolvidos = 0;

            foreach(DataGridViewRow row in dgvListaItensDevolvidos.Rows)
            {
                valorItensDevolvidos += decimal.Parse(row.Cells["ColValor"].Value.ToString());
            }
            return valorItensDevolvidos;
        }

        private DataTable ListaItensDevolvidos()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            if (FormaPagamento.ToUpper() == "PAGAMENTO PARCIAL")
                _sql = "Select Produto.Id_Produto, Produto.Descricao, HistoricoDevolucao.ValorProduto, HistoricoDevolucao.qtdItens, HistoricoDevolucao.DataDevolucao from HistoricoDevolucao inner join Produto on Produto.Id_Produto = HistoricoDevolucao.Id_Produto where HistoricoDevolucao.Id_PagamentoParcial = @IdPagamento";
            else if (FormaPagamento.ToUpper() == "MISTO")
                _sql = "Select Produto.Id_Produto, Produto.Descricao, HistoricoDevolucao.ValorProduto, HistoricoDevolucao.qtdItens, HistoricoDevolucao.DataDevolucao from HistoricoDevolucao inner join Produto on Produto.Id_Produto = HistoricoDevolucao.Id_Produto where HistoricoDevolucao.Id_PagamentoMisto = @IdPagamento";

            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.Parameters.AddWithValue("@IdPagamento", IdPagamento);
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            return Tabela;
        }

        private decimal getValorContaInicial()
        {
            decimal valorContaInicial = 0;

            SqlConnection conexao = new SqlConnection(stringConn);
            if (FormaPagamento.ToUpper() == "PAGAMENTO PARCIAL")
                _sql = "select sum(ItensVenda.Valor) as ValorItens, Venda.Desconto from Venda inner join PagamentoParcial on PagamentoParcial.Id_Venda = Venda.Id_Venda inner join ItensVenda on ItensVenda.Id_Venda = PagamentoParcial.Id_Venda  where PagamentoParcial.Id_PagamentoParcial = @IdPagamento group by Venda.Desconto"; 
            if (FormaPagamento.ToUpper() == "MISTO")
                _sql = "select sum(ItensVenda.Valor) as ValorItens, Venda.Desconto from Venda inner join PagamentoMisto on PagamentoMisto.Id_Venda = Venda.Id_Venda inner join ItensVenda on ItensVenda.Id_Venda = PagamentoMisto.Id_Venda where PagamentoMisto.Id_PagamentoMisto = @IdPagamento group by Venda.Desconto"; 
            SqlCommand comando=new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamento", IdPagamento);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    valorContaInicial = decimal.Parse(dr["ValorItens"].ToString()) - decimal.Parse(dr["Desconto"].ToString());
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

            return valorContaInicial;
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

        int X = 0, Y = 0;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}