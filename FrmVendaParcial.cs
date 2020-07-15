using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVendaParcial : Form
    {
        public string id_Cliente, stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;
        public bool vendaConfirmada = false;
        public decimal valorAbatido { get; set; }
        public decimal valorTotal { get; private set; }
        public decimal valorRestante { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal valorTotalComDesconto { get; set; }
        public decimal descontoDinheiro;
        public string TipoPagamento { get; set; }
        bool goDescontar = false;
        decimal descontoPorcento, valorDescontoPorcento, valorCliente;


        public FrmVendaParcial(decimal valorTotal)
        {
            InitializeComponent();
            this.valorTotal = valorTotal;
            valorTotalComDesconto = valorTotal;
            txt_ValorVenda.Text = "R$ " + valorTotal;
            groupBox13.Location = new Point(7, 122);
            groupBox11.Size = new Size(494, 102);
            txtValorTotalComDesconto.Text = "R$ " + valorTotalComDesconto.ToString();
            txt_ValorRestante.Text = valorTotal.ToString();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            FrmPesquisarCliente pesquisarCliente = new FrmPesquisarCliente();
            pesquisarCliente.ShowDialog();
            if (pesquisarCliente.Codigo != null && pesquisarCliente.Codigo != "1")
            {
                id_Cliente = pesquisarCliente.Codigo;
                lblCodigo_Cliente.Text = id_Cliente;
                txt_nome.Text = pesquisarCliente.Nome;
                lblNome_Cliente.Text = pesquisarCliente.Nome;
                lbl_SeparadorDados.Visible = true;
                if (verificarSituacaoClienteParcial() == true)
                {
                    lbl_Situacao.Text = "O Cliente selecionado está em débito com R$ " + valorCliente;
                }
                else
                {
                    lbl_Situacao.Text = "";
                }
            }
        }

        private bool verificarSituacaoClienteParcial()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "select * from  Venda inner join PagamentoParcial on PagamentoParcial.Id_Venda = Venda.Id_Venda where PagamentoParcial.ValorRestante > 0 and Venda.Id_Cliente = @Id_Cliente";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.Parameters.AddWithValue("@Id_Cliente", lblCodigo_Cliente.Text);
            comando.SelectCommand.CommandText = _sql;

            conexao.Open();
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            if (Tabela.Rows.Count > 0)
            {
                valorCliente = decimal.Parse(Tabela.Rows[0]["ValorRestante"].ToString());
                return true;
            }
            else
            {
                return false;
            }

        }

        ErrorProvider errorProvider = new ErrorProvider();

        private void btn_FinalizarParcial_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblCodigo_Cliente.Text))
                {
                    if (valorAbatido > 0)
                    {
                        if (cbFormaPagamento.SelectedIndex == -1)
                        {
                            MessageBox.Show("Informe qual o tipo de pagamento em espécie!", "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            errorProvider.SetError(cbFormaPagamento, "Selecione O tipo em espécie!");
                            cbFormaPagamento.Focus();
                            return;
                        }

                        TipoPagamento = cbFormaPagamento.Text;
                    }
                    vendaConfirmada = true;
                    if (valorAbatido == 0.00m)
                        valorRestante = valorTotal - descontoDinheiro;

                    id_Cliente = lblCodigo_Cliente.Text;
                    this.Close();
                }
                else
                    MessageBox.Show("Informe o cliente!", "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Biblioteca Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_ValorAbatido_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_ValorAbatido.Text != "")
                {
                    txt_ValorAbatido.Text = Convert.ToDecimal(txt_ValorAbatido.Text.Trim()).ToString("0.00");
                    valorAbatido = decimal.Parse(txt_ValorAbatido.Text);
                    if (valorAbatido <= valorTotal)
                    {
                        txt_TotalAbatido.Text = "R$ " + txt_ValorAbatido.Text;
                        getValorRestante();
                        txt_ValorRestante.Text = "R$ " + valorRestante.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Valor de abatimento maior que o valor de venda! Verifique se houve erro de digitação...", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ValorAbatido.Text = "0,00";
            }
        }

        private void getValorRestante()
        {
            valorRestante = valorTotalComDesconto - valorAbatido;
        }

        private void txt_ValorAbatido_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txt_ValorAbatido.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_FecharVendaMisto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_FecharVendaMisto_MouseLeave(object sender, EventArgs e)
        {
            this.lbl_FecharVendaMisto.BackColor = Color.Transparent;
        }

        private void lbl_FecharVendaMisto_MouseEnter(object sender, EventArgs e)
        {
            this.lbl_FecharVendaMisto.BackColor = Color.Red;
        }

        private void FrmVendaParcial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btn_CancelaVendaMisto_Click(sender, e);
            else if (e.KeyCode == Keys.F4)
                btn_Descontar_Click(sender, e);
            else if (e.KeyCode == Keys.F10)
                btn_FinalizarParcial_Click(sender, e);
        }


        private void btn_Descontar_Click(object sender, EventArgs e)
        {
            goDescontar = !goDescontar;
            switch (goDescontar)
            {
                case true:
                    lbl_DescontoDinheiro.Visible = true;
                    txt_DescontoDinheiro.Visible = true;
                    lbl_ValorDesconto.Visible = true;
                    lbl_DescontoPorcento.Visible = true;
                    txt_DescontoPorcento.Visible = true;
                    txt_ValorTotalDesconto.Visible = true;
                    groupBox13.Location = new Point(6, 176);
                    groupBox11.Size = new Size(494, 156);
                    txt_DescontoDinheiro.Focus();
                    break;
                case false:
                    lbl_DescontoDinheiro.Visible = false;
                    txt_DescontoDinheiro.Visible = false;
                    lbl_ValorDesconto.Visible = false;
                    txt_ValorTotalDesconto.Visible = false;
                    lbl_DescontoPorcento.Visible = false;
                    txt_DescontoPorcento.Visible = false;
                    groupBox13.Location = new Point(7, 122);
                    groupBox11.Size = new Size(494, 102);
                    break;

            }

            txtValorDesconto.Text = " R$ 0,00";
            txt_DescontoDinheiro.Text = "0,00";
            txt_DescontoPorcento.Text = "0,00";
            descontoDinheiro = 0.00m;
            descontoPorcento = 0.00m;
            valorDesconto = valorTotal;
            valorTotalComDesconto = valorTotal;
            txtValorTotalComDesconto.Text = "R$ " + valorTotal.ToString();
            txt_ValorTotalDesconto.Text = txtValorTotalComDesconto.Text;
            getValorRestante();
            txt_ValorRestante.Text = "R$ " + valorRestante;
        }

        private void txt_DescontoPorcento_Leave(object sender, EventArgs e)
        {
            if (txt_DescontoPorcento.Text != "")
            {
                try
                {
                    valorDescontoPorcento = decimal.Parse(txt_DescontoPorcento.Text);
                    if (valorDescontoPorcento <= 100)
                    {
                        descontoPorcento = (valorTotal * valorDescontoPorcento) / 100;
                        descontoPorcento = Math.Round(descontoPorcento, 2);
                        txt_DescontoDinheiro.Text = descontoPorcento.ToString();
                        valorDesconto = valorTotal - descontoPorcento;
                        txt_ValorTotalDesconto.Text = valorDesconto.ToString();
                        txt_DescontoDinheiro_Leave(sender, e);
                        txt_DescontoPorcento.Text = Convert.ToDecimal(txt_DescontoPorcento.Text.Trim()).ToString("0.00");
                    }
                    else
                    {
                        zerarAtibutos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_DescontoPorcento.Text = "0";
                }
            }
        }

        private void txt_DescontoPorcento_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txt_DescontoPorcento.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_DescontoDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txt_DescontoDinheiro.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_DescontoDinheiro_Leave(object sender, EventArgs e)
        {
            if (txt_DescontoDinheiro.Text != "")
            {
                try
                {
                    descontoDinheiro = decimal.Parse(txt_DescontoDinheiro.Text);
                    if (descontoDinheiro <= valorTotal)
                    {
                        txt_ValorTotalDesconto.Text = (valorTotal - descontoDinheiro).ToString();
                        txt_DescontoDinheiro.Text = Convert.ToDouble(txt_DescontoDinheiro.Text.Trim()).ToString("0.00");
                        valorDesconto = decimal.Parse(txt_ValorTotalDesconto.Text);
                        descontoPorcento = (100 * descontoDinheiro) / valorTotal;
                        descontoPorcento = Math.Round(descontoPorcento, 2);
                        txt_DescontoPorcento.Text = Math.Round(descontoPorcento, 2).ToString();
                        txt_DescontoPorcento.Text = decimal.Parse(txt_DescontoPorcento.Text.Trim()).ToString("0.00");
                        txtValorTotalComDesconto.Text = "R$ " + valorDesconto.ToString();
                        valorTotalComDesconto = valorDesconto;
                        getValorRestante();
                        txt_ValorRestante.Text = "R$ " + valorRestante;
                        txtValorDesconto.Text = "R$ " + txt_DescontoDinheiro.Text;
                    }
                    else
                    {
                        zerarAtibutos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_DescontoDinheiro.Text = "0,00";
                }
            }
        }

        private void zerarAtibutos()
        {
            txt_DescontoPorcento.Text = "0,00";
            txt_DescontoDinheiro.Text = "0,00";
            descontoPorcento = 0.00M;
            descontoDinheiro = 0.00M;
            txt_ValorTotalDesconto.Text = valorTotal.ToString();
            valorTotalComDesconto = valorTotal;
        }

        private void txt_ValorAbatido_TextChanged(object sender, EventArgs e)
        {
            if (txt_ValorAbatido.Text == "")
            {
                btn_FinalizarParcial.Enabled = false;
            }
            else
            {
                btn_FinalizarParcial.Enabled = true;
            }
        }

        private void btn_CancelaVendaMisto_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
