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
            cbMaxRows.SelectedIndex = 1;
        }

        private string FilterRows()
        {
            string filter = "";

            if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
                filter = "TOP " + cbMaxRows.Text;

            return filter;
        }


        private void FrmListavenda_Load(object sender, EventArgs e)
        {
            LoadData();
            txtValorItensDevolvidos.Text = "R$ " + getValorItensDevolvidos();
        }

        private void LoadData()
        {
            dgvListaItensDevolvidos.DataSource = ListaItensDevolvidos();
        }

        private decimal getValorItensDevolvidos()
        {
            decimal valorItensDevolvidos = 0;

            foreach (DataGridViewRow row in dgvListaItensDevolvidos.Rows)
            {
                valorItensDevolvidos += decimal.Parse(row.Cells["ColValor"].Value.ToString());
            }
            return valorItensDevolvidos;
        }

        private DataTable ListaItensDevolvidos()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            if (FormaPagamento.ToUpper() == "PARCIAL")
                _sql = "Select " + FilterRows() + " Produto.Id_Produto, Produto.Descricao, HistoricoDevolucao.ValorProduto, HistoricoDevolucao.qtdItens, HistoricoDevolucao.DataDevolucao from HistoricoDevolucao inner join Produto on Produto.Id_Produto = HistoricoDevolucao.Id_Produto where HistoricoDevolucao.Id_PagamentoParcial = @IdPagamento";
            else if (FormaPagamento.ToUpper() == "MISTO")
                _sql = "Select " + FilterRows() + " Produto.Id_Produto, Produto.Descricao, HistoricoDevolucao.ValorProduto, HistoricoDevolucao.qtdItens, HistoricoDevolucao.DataDevolucao from HistoricoDevolucao inner join Produto on Produto.Id_Produto = HistoricoDevolucao.Id_Produto where HistoricoDevolucao.Id_PagamentoMisto = @IdPagamento";

            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.Parameters.AddWithValue("@IdPagamento", IdPagamento);
            DataTable Tabela = new DataTable();
            adapter.Fill(Tabela);
            return Tabela;
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

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbMaxRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void cbMaxRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

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