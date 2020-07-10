using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmBaixarPagamentoPrazo : Form
    {
        public FrmBaixarPagamentoPrazo(decimal ValorTotal, string CodigoCliente, string NomeCliente)
        {
            InitializeComponent();
            ValorConta = ValorTotal;
            this.CodigoCliente = int.Parse(CodigoCliente);
            txt_Nome.Text = NomeCliente;
            txt_CodigoCliente.Text = CodigoCliente;
            cbTipoPagamento.Text = "Dinheiro";

        }
        int CodigoCliente;
        decimal ValorPago, ValorConta, Troco;
        

        private void FrmBaixarPagamentoPrazo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_Cancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btn_Baixa_Click(sender, e);
            }
        }

        private void FrmBaixarPagamentoPrazo_Load(object sender, EventArgs e)
        {
            btn_Baixa.Focus();
            Txt_ValorTotal.Text = "R$ " + ValorConta.ToString();
            CodigoCaixa();
            ValoresCaixa();
        }

        private void txt_ValorPago_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_ValorPago.Text != "")
                {
                    ValorPago = decimal.Parse(txt_ValorPago.Text);
                    if (ValorPago >= ValorConta)
                    {
                        Troco = ValorPago - ValorConta;
                        txt_Troco.Text = "R$ " + Troco.ToString();
                    }
                    else
                    {
                        txt_Troco.Clear();
                    }
                    txt_ValorPago.Text = Convert.ToDecimal(txt_ValorPago.Text.Trim()).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ValorPago.Clear();
            }
        }

        private void lbl_Fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_Fechar.BackColor = Color.Red;
        }

        private void lbl_Fechar_MouseLeave(object sender, EventArgs e)
        {
            lbl_Fechar.BackColor = Color.MediumSlateBlue;
        }

        private void lbl_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;

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

        int X = 0, Y = 0;
        private void panelPagamentoPrazo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panelPagamentoPrazo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void BaixarPrazo()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update ParcelaVenda set DataPagamento = @DataPagamento, HoraPagamento = @HoraPagamento from ParcelaVenda inner join Venda on ParcelaVenda.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = venda.Id_Cliente inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda where Cliente.Id_Cliente = @id and FormaPagamento.Descricao = 'PRAZO' and ParcelaVenda.DataPagamento = ''";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@id", CodigoCliente);
            comando.Parameters.AddWithValue("@DataPagamento", DateTime.Now.ToShortDateString());
            comando.Parameters.AddWithValue("@HoraPagamento", DateTime.Now.ToLongTimeString());
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

        private void btn_Baixa_Click(object sender, EventArgs e)
        {
            if (txt_ValorPago.Text == string.Empty)
            {
                MessageBox.Show("Informe o valor pago!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txt_ValorPago_Leave(sender, e);
                if (ValorPago >= ValorConta)
                {                    
                    CaixaDia();
                    GerenciarCaixa();
                    InserirTipoPagamento();
                    BaixarPrazo();
                    MessageBox.Show("Pagamento realizado com sucesso!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Backup.GerarBackup();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Valor pago menor que o valor da conta!", "Menssagem do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        TipoPagamento tipoPagamento = new TipoPagamento();

        private void InserirTipoPagamento()
        {
            tipoPagamento.idParcela = MaxParcelaVenda();
            tipoPagamento.descricao = cbTipoPagamento.Text;
            tipoPagamento.InformarFormaPagamento();
        }

        private int MaxParcelaVenda()
        {

            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT Max(ParcelaVenda.Id_Parcela) as MaxIdParcela FROM ParcelaVenda inner join Venda ON Venda.Id_Venda = ParcelaVenda.Id_Venda INNER JOIN Cliente ON Venda.Id_Cliente = Cliente.Id_Cliente INNER JOIN FormaPagamento ON FormaPagamento.Id_Venda = Venda.Id_Venda WHERE(ParcelaVenda.DataPagamento = '') AND(FormaPagamento.Descricao = 'PRAZO') AND(Venda.Id_Cliente = @IdCliente)";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@IdCliente", txt_CodigoCliente.Text);
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                    return int.Parse(dr["MaxIdParcela"].ToString());
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
                _sql = "Update FluxoCaixa set ValorCaixa = @ValorCaixa, ValorRecebidoPrazo = ValorRecebidoPrazo + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            }
            else if (cbTipoPagamento.Text == "Cartão de Crédito")
            {
                _sql = "Update FluxoCaixa set ValorRecebidoCredito = ValorRecebidoCredito + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            }
            else if (cbTipoPagamento.Text == "Cartão de Débito")
            {
                _sql = "Update FluxoCaixa set ValorRecebidoDebito = ValorRecebidoDebito + @ValorRecebido where HoraSaida = '' and DataSaida = ''";
            }

            ValorCaixa += ValorConta;
            SqlConnection conexao = new SqlConnection(stringConn);            
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorCaixa", ValorCaixa);
            comando.Parameters.AddWithValue("@ValorRecebido", ValorConta);
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
    }
}
