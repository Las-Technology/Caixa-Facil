using CaixaFacil.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVendaPrazo : Form
    {
        public string id_Cliente, stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;
        public bool vendaConfirmada = false;
        public bool relatorioPedido = false;
        public string Vencimento { get; set; }
        public decimal ValorTotal { get; set; }

        public FrmVendaPrazo(decimal ValorTotal)
        {
            InitializeComponent();
            this.ValorTotal = ValorTotal;
            txt_ValorVendaPrazo.Text = "R$ " + ValorTotal;
            mask_Data.Text = SomarDataAtualcomPrazoPagamento();
        }

        private string SomarDataAtualcomPrazoPagamento()
        {
            DateTime dataAtual = DateTime.Now;
            DateTime Vencimento = dataAtual.AddDays(int.Parse(Settings.Default["TempoPrazo"].ToString()));
            return Vencimento.ToShortDateString();
        }

        private void btn_Finalizar_Click(object sender, EventArgs e)
        {
            Finalizar();
        }

        private void Finalizar()
        {
            try
            {
                if (!string.IsNullOrEmpty(lbl_CodigoCliente.Text))
                {
                    //SituacaoCliente();
                    //caso a condição abaixo for verdadeira irá realizar a venda, caso contário, o sistema não permitirá a Confirmação da venda
                    //if (situacaoClienteParcela == 0 && situacaoClientePrazo == 0)
                    vendaConfirmada = true;

                    id_Cliente = lbl_CodigoCliente.Text;
                    Vencimento = mask_Data.Text;
                    this.Close();
                 //else
                 //{
                 //    MessageBox.Show("Venda não permitida. O cliente tem conta(s) vencida(s) com a empresa!", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 //}
                }
                    else
                        MessageBox.Show("Informe o cliente!", "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_Fechar_MouseLeave(object sender, EventArgs e)
        {
            this.lbl_Fechar.BackColor = Color.Transparent;
        }

        private void btn_PesquisarCliente_Click(object sender, EventArgs e)
        {
            FrmPesquisarCliente pesquisarCliente = new FrmPesquisarCliente();
            pesquisarCliente.ShowDialog();
            if (pesquisarCliente.Codigo != null && pesquisarCliente.Codigo != "1")
            {
                lbl_separadorInformacao.Visible = true;
                lbl_NomeCliente.Text = pesquisarCliente.Nome;
                lbl_CodigoCliente.Text = pesquisarCliente.Codigo;
                txt_NomeCliente.Text = pesquisarCliente.Nome;
                VerificarSituacao();
            }
        }

        private void VerificarSituacao()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            try
            {
                conexao.Open();
                _sql = "SELECT  venda.DataVenda, ParcelaVenda.DataVencimento FROM Produto INNER JOIN ItensVenda ON Produto.Id_Produto = ItensVenda.Id_Produto INNER JOIN Venda ON ItensVenda.Id_Venda = Venda.Id_Venda INNER JOIN Cliente ON Venda.Id_Cliente = Cliente.Id_Cliente INNER JOIN ParcelaVenda ON ParcelaVenda.Id_Venda = Venda.Id_Venda INNER JOIN FormaPagamento ON FormaPagamento.Id_Venda = Venda.Id_Venda WHERE(ParcelaVenda.DataPagamento = '') AND(FormaPagamento.Descricao = 'PRAZO') AND(Venda.Id_Cliente = @id)";
                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.Parameters.AddWithValue("@id", lbl_CodigoCliente.Text);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                {
                    string dataVenda = Tabela.Rows[0]["DataVenda"].ToString();
                    string vencimento = Tabela.Rows[0]["DataVencimento"].ToString();
                    MessageBox.Show("O cliente selecionado tem uma conta pendente realizada no dia: " + dataVenda + " que vence(u) no dia: " + vencimento, "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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

        private void btn_GerarRelatorio_Click(object sender, EventArgs e)
        {
            relatorioPedido = true;
            Finalizar();
        }

        private void lbl_Fechar_MouseEnter(object sender, EventArgs e)
        {
            this.lbl_Fechar.BackColor = Color.Red;
        }

       private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
