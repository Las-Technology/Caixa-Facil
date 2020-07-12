using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmBuscarItensVendaDevolucao : Form
    {
        public FrmBuscarItensVendaDevolucao()
        {
            InitializeComponent();
        }

        private void FrmListavenda_Load(object sender, EventArgs e)
        {
            cbMaxRows.SelectedIndex = 1;
            ListaTodasVendas();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        private void ListaTodasVendas()
        {
            try
            {
                string filter = "";

                if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
                    filter = "Top " + cbMaxRows.Text;

                SqlConnection conexao = new SqlConnection(stringConn);

                if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
                    _sql = "select distinct " + filter + " Venda.Id_Venda, Cliente.Id_Cliente, Cliente.Nome as NomeCliente, Venda.ValorTotal, Venda.Desconto, Venda.DataVenda, Venda.HoraVenda, Usuario.Nome as NomeUsuario, FormaPagamento.Descricao from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join ItensVenda on ItensVenda.Id_Venda = Venda.Id_Venda inner join Produto on Produto.Id_Produto = ItensVenda.Id_Produto inner join Usuario on Usuario.Id_Usuario = Venda.Id_Usuario inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda where Produto.Unidade <> 'serviço'";
                else 
                    _sql = "select distinct " + filter + " Venda.Id_Venda, Cliente.Id_Cliente, Cliente.Nome as NomeCliente, Venda.ValorTotal, Venda.Desconto, Venda.DataVenda, Venda.HoraVenda, Usuario.Nome as NomeUsuario, FormaPagamento.Descricao from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join ItensVenda on ItensVenda.Id_Venda = Venda.Id_Venda inner join Produto on Produto.Id_Produto = ItensVenda.Id_Produto inner join Usuario on Usuario.Id_Usuario = Venda.Id_Usuario inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda where Cliente.Nome like '%" + txtNomeCliente.Text + "%' and Produto.Unidade <> 'serviço'";

                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                dgv_ListaVenda.DataSource = Tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        string FormaPagamento;

        private void dgv_ListaVenda_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }

        private void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodVenda))
            {
                MessageBox.Show(@"Selecione a Venda que será devolvida\alterada!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmVendaDevolucaoItens vendaAlterarExcluir = new FrmVendaDevolucaoItens(CodVenda, Cliente, FormaPagamento, ValorVenda, codCliente, dataVenda, desconto);
                vendaAlterarExcluir.ShowDialog();
                CodVenda = "";
                if (txtNomeCliente.Text != "")
                {
                    txtNomeCliente_TextChanged(sender, e);
                }
                else
                {
                    ListaTodasVendas();
                }
            }
        }

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            ListaTodasVendas();
        }

        private void dgv_ListaVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int contLinhas = e.RowIndex;
            if (contLinhas > -1)
            {
                DataGridViewRow linhas = dgv_ListaVenda.Rows[contLinhas];
                CodVenda = linhas.Cells["ColCodVenda"].Value.ToString();
                codCliente = linhas.Cells["ColCodCliente"].Value.ToString();
                Cliente = linhas.Cells["ColCliente"].Value.ToString();
                ValorVenda = linhas.Cells["ColValorVenda"].Value.ToString();
                FormaPagamento = linhas.Cells["ColFormaPagamento"].Value.ToString();
                dataVenda = linhas.Cells["ColDataVenda"].Value.ToString();
                horaVenda = linhas.Cells["ColHoraVenda"].Value.ToString();
                atendente = linhas.Cells["ColOperador"].Value.ToString();
                desconto = linhas.Cells["ColDesconto"].Value.ToString();
            }
        }

       string CodVenda = "", Cliente, horaVenda, dataVenda, atendente, ValorVenda, codCliente, desconto;

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
                ListaTodasVendas();
        }

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaTodasVendas();
        }

        private void Menu_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        int X = 0, Y = 0;
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
