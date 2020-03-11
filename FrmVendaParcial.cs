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
        decimal Valor;
        public bool vendaConfirmada = false;
        public decimal ValorAbatido { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorRestante { get; set; }

        public FrmVendaParcial(decimal ValorTotal)
        {
            InitializeComponent();
            txt_TotalVenda.Text = "R$ " + ValorTotal;
            this.ValorTotal = ValorTotal;
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
                    lbl_Situacao.Text = "O Cliente selecionado está em débito com R$ " + Valor;
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
                Valor = decimal.Parse(Tabela.Rows[0]["ValorRestante"].ToString());
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btn_FinalizarParcial_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblCodigo_Cliente.Text))
                {
                    vendaConfirmada = true;
                    if (ValorAbatido == 0.00m)
                        ValorRestante = ValorTotal;

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
                    ValorAbatido = decimal.Parse(txt_ValorAbatido.Text);
                    if (ValorAbatido <= ValorTotal)
                    {
                        txt_TotalAbatido.Text = "R$ " + txt_ValorAbatido.Text;
                        ValorRestante = ValorTotal - ValorAbatido;
                        txt_ValorRestante.Text = "R$ " + ValorRestante.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Valor de abatimento maior que o valor de venda! Verifique se houve erro de digitação...", "Mensagem do sistema 'Gerenciamento Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ValorAbatido.Text = "0,00";
            }
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
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (e.KeyCode == Keys.F10)
                btn_FinalizarParcial_Click(sender, e);
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
