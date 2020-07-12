using CaixaFacil.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVendaVista : Form
    {
        public string id_Cliente, stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;
        public bool vendaConfirmada = false;
        public bool CupomPedido = false;
        public bool promissoriaPedido = false;
        public bool relatorioPedido = false;
        public string Vencimento { get; set; }
        public string nomeCliente { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal troco { get; set; }
        public decimal descontoDinheiro { get; set; }
        decimal ValorDescontoPorcento, DescontoPorcento;
        const int Porcento = 100;
        bool goDescontar = false;

        public FrmVendaVista(decimal ValorTotal)
        {
            InitializeComponent();
            this.ValorTotal = ValorTotal;
            lbl_ValorTotal.Text = "R$ " + ValorTotal;
        }        

        private void lbl_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_Fechar_MouseLeave(object sender, EventArgs e)
        {
            this.lbl_Fechar.BackColor = Color.Transparent;
        }

        private void lbl_Fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_Fechar.BackColor = Color.Red;
        }

        private void txt_ValorPago_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_ValorPago.Text != "")
                {
                    ValorPago = decimal.Parse(txt_ValorPago.Text.Trim());
                    troco = ValorPago - decimal.Parse(txt_ValorDesconto.Text);
                    txt_Troco.Text = troco.ToString();
                    txt_ValorPago.Text = ValorPago.ToString();
                    txt_ValorPago.Text = Convert.ToDouble(txt_ValorPago.Text.Trim()).ToString("0.00");
                    if (txt_ValorDesconto.Text != "0,00")
                    {
                        txt_Troco.Text = (decimal.Parse(txt_ValorPago.Text) - decimal.Parse(txt_ValorDesconto.Text)).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ValorPago.Clear();
            }
        }

        private void txt_DescontoDinheiro_Leave(object sender, EventArgs e)
        {
            if (txt_DescontoDinheiro.Text != "")
            {
                try
                {
                    descontoDinheiro = decimal.Parse(txt_DescontoDinheiro.Text);
                    if (descontoDinheiro <= ValorTotal)
                    {
                        txt_ValorDesconto.Text = (ValorTotal - descontoDinheiro).ToString();
                        txt_Troco.Text = (ValorPago - decimal.Parse(txt_ValorDesconto.Text)).ToString();
                        txt_DescontoDinheiro.Text = Convert.ToDouble(txt_DescontoDinheiro.Text.Trim()).ToString("0.00");
                        ValorDesconto = decimal.Parse(txt_ValorDesconto.Text);
                        DescontoPorcento = (Porcento * descontoDinheiro) / ValorTotal;
                        DescontoPorcento = Math.Round(DescontoPorcento, 2);
                        txt_DescontoPorcento.Text = Math.Round(DescontoPorcento, 2).ToString();
                        txt_DescontoPorcento.Text = decimal.Parse(txt_DescontoPorcento.Text.Trim()).ToString("0.00");
                    }
                    else
                    {
                        txt_DescontoPorcento.Text = "0,00";
                        txt_DescontoDinheiro.Text = "0,00";
                        DescontoPorcento = 0.00M;
                        descontoDinheiro = 0.00M;
                        txt_ValorDesconto.Text = ValorTotal.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_DescontoDinheiro.Text = "0,00";
                }
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

        private void txt_ValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txt_ValorDesconto.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
                if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(txt_ValorDesconto.Text, @"\,\d\d"))
                        e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Finalizar_Click(object sender, EventArgs e)
        {        
            Finalizar();
            if (vendaConfirmada)
                this.Close();
        }

        private void Finalizar()
        {
            if (string.IsNullOrWhiteSpace(txt_ValorPago.Text))
            {
                MessageBox.Show("Informe o valor pago!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            troco = decimal.Parse(txt_Troco.Text);
            if (ValorDesconto == 0.00M && descontoDinheiro < ValorTotal)
                ValorDesconto = ValorTotal;

            if (decimal.Parse(txt_ValorPago.Text) < ValorDesconto)
            {
                MessageBox.Show("Valor em dinheiro menor do que o valor total da venda!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            vendaConfirmada = true;           
        }

        private void txt_Troco_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (((int)e.KeyChar) != ((int)Keys.Back))
                        if (e.KeyChar != ',')
                            e.Handled = true;
                        else if (txt_Troco.Text.IndexOf(',') > 0)
                            e.Handled = true;
                }
                if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(txt_Troco.Text, @"\,\d\d"))
                        e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_VincularCliente_Click(object sender, EventArgs e)
        {
            string VincularCliente = btn_VincularCliente.Text;
            switch (VincularCliente)
            {
                case "Vincular Cliente - F5":
                    FrmPesquisarCliente pesquisarCliente = new FrmPesquisarCliente();
                    pesquisarCliente.ShowDialog();
                    if (pesquisarCliente.Codigo != null && pesquisarCliente.Codigo != "1")
                    {
                        lbl_ApresentacaoCliente.Visible = true;
                        lbl_Cliente.Visible = true;
                        id_Cliente = pesquisarCliente.Codigo;
                        lbl_Cliente.Text = pesquisarCliente.Nome;
                        VincularCliente = "Não";
                        btn_VincularCliente.Text = "Desvincular Cliente - F5";
                        btn_VincularCliente.TextAlign = ContentAlignment.MiddleRight;
                    }
                    break;
                case "Desvincular Cliente - F5":
                    lbl_ApresentacaoCliente.Visible = false;
                    lbl_Cliente.Visible = false;
                    lbl_Cliente.Text = string.Empty;
                    id_Cliente = string.Empty;
                    VincularCliente = "Sim";
                    btn_VincularCliente.Text = "Vincular Cliente - F5";
                    btn_VincularCliente.TextAlign = ContentAlignment.MiddleCenter;
                    break;
            }
        }

        private void txt_ValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ImprimiCupom_Click(object sender, EventArgs e)
        {
            Finalizar();

            if (!vendaConfirmada)
                return;

            CupomPedido = true;
            this.Close();
        }

        private void btn_Recibo_Click(object sender, EventArgs e)
        {
            Finalizar();
         
            if (!vendaConfirmada)
                return;

            nomeCliente = lbl_Cliente.Text;
            promissoriaPedido = true;
            this.Close();
        }

        private void btn_Descontar_Click(object sender, EventArgs e)
        {
            goDescontar = !goDescontar;
            txt_ValorDesconto.Text = ValorTotal.ToString();

            switch (goDescontar)
            {
                case false:

                    lbl_DescontoDinheiro.Visible = false;
                    txt_DescontoDinheiro.Visible = false;
                    lbl_ValorDesconto.Visible = false;
                    txt_ValorDesconto.Visible = false;
                    lbl_DescontoPorcento.Visible = false;
                    txt_DescontoPorcento.Visible = false;
                    txt_DescontoDinheiro.Text = "0,00";
                    txt_DescontoPorcento.Text = "0,00";
                    ValorDesconto = decimal.Parse(txt_ValorDesconto.Text);
                    txt_Troco.Text = (ValorPago - ValorTotal).ToString();
                    descontoDinheiro = 0.00m;
                    txt_DescontoDinheiro.Focus();
                    break;
                case true:

                    lbl_DescontoDinheiro.Visible = true;
                    txt_DescontoDinheiro.Visible = true;
                    lbl_ValorDesconto.Visible = true;
                    lbl_DescontoPorcento.Visible = true;
                    txt_DescontoPorcento.Visible = true;
                    txt_ValorDesconto.Visible = true;
                    ValorDesconto = decimal.Parse(txt_ValorDesconto.Text);
                    break;
            }
        }

        private void FrmVendaVista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btn_Cancelar_Click(sender, e);
            else if (e.KeyCode == Keys.F4)
                btn_Descontar_Click(sender, e);
            else if (e.KeyCode == Keys.F5)
                btn_VincularCliente_Click(sender, e);
            else if (e.KeyCode == Keys.F11)
                btn_Recibo_Click(sender, e);
            else if (e.KeyCode == Keys.F12)
                btn_ImprimiCupom_Click(sender, e);
            else if (e.KeyCode == Keys.F10)
                btn_Finalizar_Click(sender, e);
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

        private void txt_DescontoPorcento_Leave(object sender, EventArgs e)
        {
            if (txt_DescontoPorcento.Text != "")
            {
                try
                {
                    ValorDescontoPorcento = decimal.Parse(txt_DescontoPorcento.Text);
                    if (ValorDescontoPorcento <= 100)
                    {
                        DescontoPorcento = (ValorTotal * ValorDescontoPorcento) / Porcento;
                        DescontoPorcento = Math.Round(DescontoPorcento, 2);
                        txt_DescontoDinheiro.Text = DescontoPorcento.ToString();
                        ValorDesconto = ValorTotal - DescontoPorcento;
                        txt_ValorDesconto.Text = ValorDesconto.ToString();
                        txt_DescontoDinheiro_Leave(sender, e);
                        txt_DescontoPorcento.Text = Convert.ToDecimal(txt_DescontoPorcento.Text.Trim()).ToString("0.00");
                    }
                    else
                    {
                        txt_DescontoPorcento.Text = "0,00";
                        txt_DescontoDinheiro.Text = "0,00";
                        DescontoPorcento = 0.00M;
                        descontoDinheiro = 0.00M;
                        txt_ValorDesconto.Text = ValorTotal.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_DescontoPorcento.Text = "0";
                }
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
