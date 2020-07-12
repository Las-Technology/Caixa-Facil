using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmPesquisarProdutos : Form
    {
        public FrmPesquisarProdutos()
        {
            InitializeComponent();
        }

        private void FrmPesquisarProdutos_Load(object sender, EventArgs e)
        {           
            cbMaxRows.SelectedIndex = 1;
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            try
            {
                string filter = "";
                if(cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
                {
                    filter = " TOP " + cbMaxRows.Text;
                }

                if (string.IsNullOrWhiteSpace(txt_Nome.Text))
                {
                    _sql = "SELECT" + filter + " Produto.Id_Produto, Produto.CodigoBarra, Produto.Descricao as DescricaoNome, Produto.Marca, Produto.DataValidade, Produto.ValorCusto, Produto.ValorVenda, Produto.EstoqueAtual, Produto.EstoqueMinimo, Produto.Unidade, Categoria.Descricao, Fornecedor.Nome, Produto.Lucro, Produto.NumeroNotaFiscal, Produto.DataCadastro FROM Categoria INNER JOIN Produto ON Categoria.Id_Categoria = Produto.Id_Categoria INNER JOIN Fornecedor ON Produto.Id_Fornecedor = Fornecedor.Id_Fornecedor";
                }
                else
                {
                    _sql = "SELECT" + filter + " Produto.Id_Produto, Produto.CodigoBarra, Produto.Descricao as DescricaoNome, Produto.Marca, Produto.DataValidade, Produto.ValorCusto, Produto.ValorVenda, Produto.EstoqueAtual, Produto.EstoqueMinimo, Produto.Unidade, Categoria.Descricao, Fornecedor.Nome, Produto.Lucro, Produto.NumeroNotaFiscal, Produto.DataCadastro FROM Categoria INNER JOIN Produto ON Categoria.Id_Categoria = Produto.Id_Categoria INNER JOIN Fornecedor ON Produto.Id_Fornecedor = Fornecedor.Id_Fornecedor WHERE Produto.Descricao like '%" + txt_Nome.Text.Trim() + "%'";
                }

                SqlConnection conexao = new SqlConnection(stringConn);
                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                dgv_Busca.DataSource = Tabela;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;
        
        public string ID_PRODUTO { get; set; }
        public string CodBarra { get; set; }
        public string Fornecedor { get; set; }
        public string Descricao { get; set; }
        public string Lucro { get; set; }
        public string ValorVenda { get; set; }
        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.DarkOrange;
        }
        int X = 0;
        int Y = 0;
        private void panelCabecalho_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panelCabecalho_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void txt_Nome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Nome_TextChanged(sender, e);
            }
        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgv_Busca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Cont = e.RowIndex;
            if (Cont >= 0)
            {
                DataGridViewRow LINHA = dgv_Busca.Rows[e.RowIndex];
                ID_PRODUTO = LINHA.Cells["idProduto"].Value.ToString();
                CodBarra = LINHA.Cells["codigoBarra"].Value.ToString();
                Fornecedor = LINHA.Cells["nomeFornecedor"].Value.ToString();
                Descricao = LINHA.Cells["nomeProduto"].Value.ToString();
                Lucro = LINHA.Cells["lucro"].Value.ToString();
                ValorVenda = LINHA.Cells["valorVenda"].Value.ToString();
                this.Close();
            }
        }

        private void dgv_Busca_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv_Busca.ClearSelection();
        }

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void cbMaxRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CarregaGrid();
        }

        private void cbMaxRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }
    }
}
