using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmHistoricoPagamentoDetalhado : Form
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql, FormaPagamento;
        int IdPagamento;

        public FrmHistoricoPagamentoDetalhado(string NVenda, string Cliente, string dateTime, decimal ValorVenda, string FormaPagamento, decimal ValorAbatido, decimal ValorRestante, int IdPagamento)
        {
            InitializeComponent();
            txtCodigoVenda.Text = NVenda;
            txtCliente.Text = Cliente;
            txtDateTime.Text = dateTime;
            txtValorVenda.Text = "R$ " + ValorVenda.ToString();
            this.FormaPagamento = FormaPagamento;
            txtFormaPagamento.Text = FormaPagamento;
            txtValorRestante.Text = "R$ " + ValorRestante.ToString();
            txtValorPago.Text = "R$ " + ValorAbatido.ToString();
            this.IdPagamento = IdPagamento;
        }

        private void FrmListavenda_Load(object sender, EventArgs e)
        {
            if (VisualizarItensDevolvidos())
            {
                lblInfo.Visible = true;
                button1.Visible = true;
                return;
            }

            this.Size = new Size(611, 518);
            btnVisualizar.Location = new Point(209, 461);
            btnFechar.Location = new Point(455, 461);
        }

        private bool VisualizarItensDevolvidos()
        {
            SqlConnection conexao = new SqlConnection(stringConn);

            if (FormaPagamento.ToUpper() == "PAGAMENTO PARCIAL")
                _sql = "Select * from HistoricoDevolucao where Id_PagamentoParcial = @IdPagamentoParcial";
            else if (FormaPagamento.ToUpper() == "MISTO")
                _sql = "Select * from HistoricoDevolucao where Id_PagamentoMisto = @IdPagamento";

            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamento", IdPagamento);
            conexao.Open();
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.Read())
            {
                conexao.Close();
                return true;
            }
            else
            {
                conexao.Close();
                return false;
            }
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

        private void FrmHistoricoPagamentoDetalhado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnFechar_Click(sender, e);
            }
            if (e.KeyCode == Keys.F3)
            {
                btnVisualizar_Click(sender, e);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (txtValorPago.Text == "R$ 0,00")
            {
                MessageBox.Show("Não constamos pagamentos realizados por estes clientes!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmHistoricoPagamentoVisualizarDataPagamento historicoPagamentoVisualizarDataPagamento = new FrmHistoricoPagamentoVisualizarDataPagamento(txtCodigoVenda.Text, txtFormaPagamento.Text, IdPagamento);
                historicoPagamentoVisualizarDataPagamento.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmListaDevolucao listaDevolucao = new FrmListaDevolucao(IdPagamento, FormaPagamento);
            listaDevolucao.ShowDialog();
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