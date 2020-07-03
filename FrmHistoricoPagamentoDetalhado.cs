using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmHistoricoPagamentoDetalhado : Form
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql, FormaPagamento;
        int idPagamento;
        decimal valorRestante;

        public FrmHistoricoPagamentoDetalhado(string NVenda, string cliente, string dateTime, decimal valorVenda, string formaPagamento, decimal valorAbatido, decimal valorRestante, int idPagamento)
        {
            InitializeComponent();

            txtCodigoVenda.Text = NVenda;
            txtCliente.Text = cliente;
            txtDateTime.Text = dateTime;
            txtValorVenda.Text = "R$ " + valorVenda.ToString();
            this.FormaPagamento = formaPagamento;
            txtFormaPagamento.Text = formaPagamento;
            txtValorRestante.Text = "R$ " + valorRestante.ToString();
            txtValorPago.Text = "R$ " + valorAbatido.ToString();
            this.idPagamento = idPagamento;
            this.valorRestante = valorRestante;
        }

        private void FrmListavenda_Load(object sender, EventArgs e)
        {
            if (VisualizarItensDevolvidos())
            {
                lblInfo.Visible = true;
                btnVisualizarLista.Visible = true;
                if(valorRestante == 0)
                {
                    txtValorPago.Text = txtValorVenda.Text;
                }

                return;
            }

            this.Size = new Size(611, 518);
            btnVisualizar.Location = new Point(209, 461);
            btnFechar.Location = new Point(455, 461);
        }

        private bool VisualizarItensDevolvidos()
        {
            bool existsDate = false;

            SqlConnection conexao = new SqlConnection(stringConn);

            if (FormaPagamento.ToUpper() == "PARCIAL")
                _sql = "Select * from HistoricoDevolucao where Id_PagamentoParcial = @IdPagamento";
            else if (FormaPagamento.ToUpper() == "MISTO")
                _sql = "Select * from HistoricoDevolucao where Id_PagamentoMisto = @IdPagamento";
            else
                return false;


            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdPagamento", idPagamento);

            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    existsDate = true;
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

            return existsDate;
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

        private void txtValorVenda_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmHistoricoPagamentoDetalhado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnFechar_Click(sender, e);
            }
            if(e.KeyCode == Keys.F2)
            {
                btnVisualizarLista_Click(sender, e);
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
                FrmHistoricoPagamentoVisualizarDataPagamento historicoPagamentoVisualizarDataPagamento = new FrmHistoricoPagamentoVisualizarDataPagamento(txtCodigoVenda.Text, txtFormaPagamento.Text, idPagamento);
                historicoPagamentoVisualizarDataPagamento.ShowDialog();
            }
        }

        private void btnVisualizarLista_Click(object sender, EventArgs e)
        {
            FrmListaDevolucao listaDevolucao = new FrmListaDevolucao(idPagamento, FormaPagamento);
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