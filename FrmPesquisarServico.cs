using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmPesquisarServico : Form
    {
        public FrmPesquisarServico()
        {
            InitializeComponent();
        }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string PrecoServico { get; set; }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;
        private void FrmPesquisarServico_Load(object sender, EventArgs e)
        {
            cbMaxRows.SelectedIndex = 1;
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            string filter = "";

            if(cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
            {
                filter = " TOP " + cbMaxRows.Text;
            }

            if (string.IsNullOrWhiteSpace(txt_Nome.Text))
            {
                _sql = "Select" + filter + " Produto.Id_Produto, Produto.Descricao, Produto.ValorVenda from Produto inner join Categoria on Categoria.Id_Categoria = Produto.Id_Categoria where Categoria.Descricao = 'Serviço'";
            }
            else
            {
                _sql = "Select" + filter + " Produto.Id_Produto, Produto.Descricao, Produto.ValorVenda from Produto inner join Categoria on Categoria.Id_Categoria = Produto.Id_Categoria where Produto.Descricao like '%" + txt_Nome.Text.Trim() + "%' and Categoria.Descricao = 'Serviço'";
            }

            SqlConnection conexao = new SqlConnection(stringConn);
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            dgv_Busca.DataSource = Tabela;
        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

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

        int X = 0, Y = 0;
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

        private void dgv_Busca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ContLinhas = e.RowIndex;
            if (ContLinhas > -1)
            {
                DataGridViewRow linha = dgv_Busca.Rows[e.RowIndex];
                Codigo = linha.Cells["ColumnCodigo"].Value.ToString();
                Descricao = linha.Cells["ColumnDescricao"].Value.ToString();
                PrecoServico = linha.Cells["ColumnPreco"].Value.ToString();
                this.Close();
            }
        }

        private void cbMaxRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void dgv_Busca_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv_Busca.ClearSelection();
        }

        private void cbMaxRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CarregarGrid();
        }
    }
}
