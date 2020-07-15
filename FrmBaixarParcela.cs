using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmBaixarParcela : Form
    {
        public FrmBaixarParcela(int id_Venda, string Vencimento, string ValorParcela, string NumeroParcela, int CodigoCliente, string NomeCliente, int NumeroTotalParcelas)
        {
            InitializeComponent();
            txt_CodigoCliente.Text = CodigoCliente.ToString();
            this.CodigoCliente = CodigoCliente;
            txt_Vencimento.Text = Vencimento;
            this.Vencimento = Vencimento;
            this.NumeroParcela = int.Parse(NumeroParcela);
            txt_valorParcela.Text = "R$ " + ValorParcela;
            txt_NParcelas.Text = NumeroParcela + "/" + NumeroTotalParcelas;
            txt_CodigoCliente.Text = CodigoCliente.ToString();
            txt_Nome.Text = NomeCliente;
            txt_CodigoVenda.Text = id_Venda.ToString();
            this.ValorParcela = decimal.Parse(ValorParcela);
        }
        int CodigoCliente, NumeroParcela;
        string Vencimento;
        private void txt_ValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (((int)e.KeyChar) != ((int)Keys.Back))
                    if (e.KeyChar != ',')
                        e.Handled = true;
                    else if (txt_ValorPago.Text.IndexOf(',') > 0)
                        e.Handled = true;
            }
        }

        private void lbl_Fechar_Click(object sender, EventArgs e)
        {
            btn_Cancelar_Click(sender, e);
        }
        public string Limpar { get; set; }
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Limpar = "sim";
            Close();
        }

        private void lbl_Fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_Fechar.BackColor = Color.Red;
        }

        private void lbl_Fechar_MouseLeave(object sender, EventArgs e)
        {
            lbl_Fechar.BackColor = Color.MediumSlateBlue;
        }

        private void FrmBaixarParcela_Load(object sender, EventArgs e)
        {
            cbTipoPagamento.Text = "Dinheiro";
            CodigoCaixa();
            ValoresCaixa();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;

        private void BaixarParcela()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update ParcelaVenda set DataPagamento = @DataPagamento, HoraPagamento = @HoraPagamento from ParcelaVenda inner join Venda on ParcelaVenda.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = venda.Id_Cliente inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda where Cliente.Id_Cliente = @id and FormaPagamento.Descricao = 'PARCELADO' and ParcelaVenda.DataPagamento = '' AND ParcelaVenda.Parcela = @Parcela and DataVencimento = @Vencimento AND ParcelaVenda.Id_Venda = @Id_Venda";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@id", CodigoCliente);
            comando.Parameters.AddWithValue("@DataPagamento", DateTime.Now.ToShortDateString());
            comando.Parameters.AddWithValue("@HoraPagamento", DateTime.Now.ToLongTimeString());
            comando.Parameters.AddWithValue("@Id_Venda", txt_CodigoVenda.Text);
            comando.Parameters.AddWithValue("@Parcela", NumeroParcela);
            comando.Parameters.AddWithValue("@Vencimento", Vencimento);
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

        int Id_FluxoCaixa, Id_Usuario;
        string DataEntrada, HoraEntrada;

        public void CodigoCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select Max(Id_Fluxo) from FluxoCaixa where DataSaida = '' and horaSaida = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                Id_FluxoCaixa = int.Parse(comando.ExecuteScalar().ToString());
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

        private void btn_Baixa_Click(object sender, EventArgs e)
        {
            if (txt_ValorPago.Text != "")
            {
                txt_ValorPago_Leave(sender, e);
                if (ValorPago >= ValorParcela)
                {
                    CaixaDia();
                    GerenciarCaixa();
                    InserirTipoPagamento();
                    BaixarParcela();

                    MessageBox.Show("Pagamento realizado com sucesso!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Backup.GerarBackup();
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Valor pago menor que o valor da conta!", "Menssagem do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ValorPago.Focus();
                }

            }
            else
            {
                MessageBox.Show("Informe o valor pago!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ValorPago.Focus();
            }
        }

        TipoPagamento tipoPagamento = new TipoPagamento();

        private void InserirTipoPagamento()
        {
            tipoPagamento.idParcela = getIdParcelaVenda();
            tipoPagamento.descricao = cbTipoPagamento.Text;
            tipoPagamento.InformarFormaPagamento();
        }

        private int getIdParcelaVenda()
        {

            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT ParcelaVenda.Id_Parcela FROM ParcelaVenda inner join Venda ON Venda.Id_Venda = ParcelaVenda.Id_Venda INNER JOIN Cliente ON Venda.Id_Cliente = Cliente.Id_Cliente INNER JOIN FormaPagamento ON FormaPagamento.Id_Venda = Venda.Id_Venda WHERE(ParcelaVenda.DataPagamento = '') AND(FormaPagamento.Descricao = 'PARCELADO') AND(Venda.Id_Cliente = @IdCliente) AND ParcelaVenda.Parcela = @NParcela and ParcelaVenda.Id_Venda = @IdVenda";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdCliente", txt_CodigoCliente.Text);
            comando.Parameters.AddWithValue("@NParcela", NumeroParcela);
            comando.Parameters.AddWithValue("@IdVenda", txt_CodigoVenda.Text);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                    return int.Parse(dr["Id_Parcela"].ToString());
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conexao.Close();
            }
        }

        public void ValoresCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select * from FluxoCaixa inner join Usuario on Usuario.Id_Usuario = FluxoCaixa.Id_Usuario where FluxoCaixa.Id_Fluxo = @ID";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.Parameters.AddWithValue("@ID", Id_FluxoCaixa);
            comando.SelectCommand.CommandText = _sql;
            try
            {
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                {
                    DataEntrada = Tabela.Rows[0]["DataEntrada"].ToString();
                    HoraEntrada = Tabela.Rows[0]["HoraEntrada"].ToString();
                    Id_Usuario = int.Parse(Tabela.Rows[0]["Id_Usuario"].ToString());
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
        decimal ValorCaixa;
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
            if (cbTipoPagamento.Text == "Dinheiro")
            {
                _sql = "Update FluxoCaixa set ValorCaixa = @ValorCaixa, ValorRecebidoParcela = ValorRecebidoParcela + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            }
            else if (cbTipoPagamento.Text == "Cartão de Crédito")
            {
                _sql = "Update FluxoCaixa set ValorRecebidoCredito = ValorRecebidoCredito + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            }
            else if (cbTipoPagamento.Text == "Cartão de Débito")
            {
                _sql = "Update FluxoCaixa set ValorRecebidoDebito = ValorRecebidoDebito + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            }

            ValorCaixa += ValorParcela;
            SqlConnection conexao = new SqlConnection(stringConn);
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorCaixa", ValorCaixa);
            comando.Parameters.AddWithValue("@ValorRecebido", ValorParcela);
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

        private void FrmBaixarParcela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                btn_Baixa_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_Cancelar_Click(sender, e);
            }
        }

        decimal ValorPago, Troco, ValorParcela;

        int X = 0, Y = 0;
        private void panelPagamentoParcela_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panelPagamentoParcela_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void txt_ValorPago_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_ValorPago.Text != "")
                {
                    txt_ValorPago.Text = Convert.ToDecimal(txt_ValorPago.Text.Trim()).ToString("0.00");
                    ValorPago = decimal.Parse(txt_ValorPago.Text);
                    Troco = ValorPago - ValorParcela;
                    txt_Troco.Text = "R$ " + Troco.ToString();
                }
                else
                {
                    txt_Troco.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ValorPago.Clear();
            }
        }
    }
}
