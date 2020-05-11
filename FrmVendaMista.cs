using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVendaMista : Form
    {
        public FrmVendaMista(decimal valorTotal)
        {
            InitializeComponent();
            lblValorVenda.Text = "R$ " + valorTotal;
            this.valorTotal = valorTotal;
        }

        public decimal valorDinheiro { get; set; }
        public decimal valorCredDeb { get; set; }
        public decimal valorRestante { get; set; }
        public string formaPagamento { get; set; }
        public int idCliente = 1; 
        public bool isFinally = false;
        bool vincularCliente = false;
        public decimal descontoDinheiro;
        decimal valorDesconto, valorTotal, descontoPorcento, valorDescontoPorcento;

        private void lblFechar_MouseLeave(object sender, EventArgs e)
        {
            lblFechar.BackColor = Color.Transparent;
        }

        private void lblFechar_MouseEnter(object sender, EventArgs e)
        {
            lblFechar.BackColor = Color.Red;
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CancelarVendaVista_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Finalizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtValorDinheiro.Text))
            {
                if (cbEditarValorCredDeb.Checked && !vincularCliente)
                {
                    MessageBox.Show("Vincule um cliente para efetuar a venda!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
             
                if (cbEditarValorCredDeb.Checked && vincularCliente && valorRestante == 0.00m)
                {
                    MessageBox.Show("O Valor do pagamento pelo crédito|débito não foi alterado!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                valorCredDeb = decimal.Parse(txtValorCreditoAndDebito.Text);
                valorDinheiro = decimal.Parse(txtValorDinheiro.Text);
                formaPagamento = cbFormaPagamento.Text;
                isFinally = true;

                this.Close();
            }
            else
                MessageBox.Show("Informe o valor que o cliente irá pagar em dinheiro!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FrmVendaMista_Load(object sender, EventArgs e)
        {
            cbFormaPagamento.SelectedIndex = 0;
            this.Size = new Size(542, 422);
            gbPagamento.Location = new Point(26, 80);
        }

        private void FrmVendaMista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btn_CancelarVendaVista_Click(sender, e);
            else if (e.KeyCode == Keys.F4)
                btn_Descontar_Click(sender, e);
            else if (e.KeyCode == Keys.F5)
                btn_VincularCliente_Click(sender, e);
            else if (e.KeyCode == Keys.F10)
                btn_Finalizar_Click(sender, e);
        }

        private void txtValorDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txtValorDinheiro.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool goDescontar = false;

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
                    txt_ValorTotalDesconto.Text = valorTotal.ToString();
                    this.Size = new Size(542, 480);
                    gbPagamento.Location = new Point(28, 137);
                    break;
                case false:
                    lbl_DescontoDinheiro.Visible = false;
                    txt_DescontoDinheiro.Visible = false;
                    lbl_ValorDesconto.Visible = false;
                    txt_ValorTotalDesconto.Visible = false;
                    lbl_DescontoPorcento.Visible = false;
                    txt_DescontoPorcento.Visible = false;
                    txt_DescontoDinheiro.Text = "0,00";
                    txt_DescontoPorcento.Text = "0,00";
                    txt_ValorTotalDesconto.Text = "0,00";
                    descontoDinheiro = 0.00M;
                    descontoPorcento = 0.00M;
                    valorRestante = 0.00m;
                    this.Size = new Size(542, 422);
                    gbPagamento.Location = new Point(26, 80);
                    txtValorRestante.Text = "0,00";
                    break;
            }

            if (!string.IsNullOrEmpty(txtValorDinheiro.Text) && !goDescontar)
            {
                txtValorCreditoAndDebito.Text = ((valorTotal - descontoDinheiro) - valorDinheiro).ToString();
                valorRestante = 0.00M;
                txtValorRestante.Text = "0,00";
            }
        }

        private void btn_VincularCliente_Click(object sender, EventArgs e)
        {
            vincularCliente = !vincularCliente;
            if (vincularCliente)
            {
                FrmPesquisarCliente pesquisarCliente = new FrmPesquisarCliente();
                pesquisarCliente.ShowDialog();
                if (!string.IsNullOrEmpty(pesquisarCliente.Codigo))
                {
                    idCliente = int.Parse(pesquisarCliente.Codigo);
                    lbl_Cliente.Text = pesquisarCliente.Nome.ToUpper();
                    btn_VincularCliente.Text = "Desvincular Cliente - F5";
                    lbl_ApresentacaoCliente.Visible = true;
                    lbl_Cliente.Visible = true;
                }
                else
                    vincularCliente = false;
            }
            else
            {
                btn_VincularCliente.Text = "Vincular Cliente - F5";
                idCliente = 1;
                lbl_ApresentacaoCliente.Visible = false;
                lbl_Cliente.Visible = false;
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
                        txt_DescontoPorcento.Text = "0,00";
                        txt_DescontoDinheiro.Text = "0,00";
                        descontoPorcento = 0.00M;
                        descontoDinheiro = 0.00M;
                        txt_ValorTotalDesconto.Text = valorTotal.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_DescontoPorcento.Text = "0";
                }
            }
        }

        private void txtValorCreditoAndDebito_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbEditarValorCredDeb.Checked)
                {
                    valorRestante =  (valorTotal - descontoDinheiro) - valorDinheiro - decimal.Parse(txtValorCreditoAndDebito.Text);
                    if(valorRestante < 0)
                    {
                        MessageBox.Show("Informe um valor menor. O valor informado ultrapassa o valor total da venda!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtValorCreditoAndDebito.Text = ((valorTotal - descontoDinheiro) - valorDinheiro).ToString();
                        valorRestante = 0.00m;
                        return;
                    }
                    txtValorRestante.Text = valorRestante.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValorCreditoAndDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txtValorCreditoAndDebito.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValorDinheiro_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtValorDinheiro.Text))
                    txtValorDinheiro.Text = decimal.Parse(txtValorDinheiro.Text).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValorCreditoAndDebito_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtValorCreditoAndDebito.Text))
                    txtValorCreditoAndDebito.Text = decimal.Parse(txtValorCreditoAndDebito.Text).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        descontoPorcento = (100 * descontoDinheiro) / valorTotal;
                        descontoPorcento = Math.Round(descontoPorcento, 2);
                        txt_DescontoPorcento.Text = Math.Round(descontoPorcento, 2).ToString();
                        txt_DescontoPorcento.Text = decimal.Parse(txt_DescontoPorcento.Text.Trim()).ToString("0.00");

                        if (!string.IsNullOrEmpty(txtValorDinheiro.Text))
                            txtValorCreditoAndDebito.Text = ((valorTotal - descontoDinheiro) - valorDinheiro).ToString();
                    }
                    else
                    {
                        txt_DescontoPorcento.Text = "0,00";
                        txt_DescontoDinheiro.Text = "0,00";
                        descontoPorcento = 0.00M;
                        descontoDinheiro = 0.00M;
                        txt_ValorTotalDesconto.Text = valorTotal.ToString();
                        valorRestante = 0.00m;
                        txtValorRestante.Text = "0,00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_DescontoDinheiro.Text = "0,00";
                }
            }
        }

        private void txtValorDinheiro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtValorDinheiro.Text))
                {
                    valorDinheiro = decimal.Parse(txtValorDinheiro.Text);

                    if (valorDinheiro >= (valorTotal - descontoDinheiro) || valorDinheiro == 0.00m)
                    {
                        MessageBox.Show("O Valor em dinheiro não pode ser maior ou igual ao valor total da venda ou igual a zero!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtValorDinheiro.Focus();
                        txtValorDinheiro.Clear();
                        txtValorCreditoAndDebito.Clear();
                        return;
                    }

                    txtValorCreditoAndDebito.Text = ((valorTotal - descontoDinheiro) - valorDinheiro).ToString();

                    if (cbEditarValorCredDeb.Checked)
                    {
                        if(!string.IsNullOrEmpty(txtValorDinheiro.Text))
                        valorRestante = (valorTotal - descontoDinheiro) - valorDinheiro - decimal.Parse(txtValorCreditoAndDebito.Text);
                        txtValorRestante.Text = valorRestante.ToString("0.00");
                    }

                }
                else
                {
                    valorDinheiro = 0.00m;
                    txtValorCreditoAndDebito.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbEditarValorCredDeb_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEditarValorCredDeb.Checked)
            {
                txtValorCreditoAndDebito.ReadOnly = false;
                txtValorRestante.Enabled = true;
            }
            else
            {
                txtValorCreditoAndDebito.ReadOnly = true;
                txtValorRestante.Enabled = false;
                txtValorRestante.Text = "0,00";
                valorRestante = 0.00m;
                txtValorCreditoAndDebito.Text = ((valorTotal - descontoDinheiro) - valorDinheiro).ToString();
            }
        }
    }
}
