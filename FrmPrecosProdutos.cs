using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmPrecosProdutos : Form
    {
        public FrmPrecosProdutos()
        {
            InitializeComponent();
        }

        private void FrmPrecosProdutos_Load(object sender, EventArgs e)
        {
            cbMaxRows.SelectedIndex = 1;
            CarregarGrid();
        }

        string strinConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        private void CarregarGrid()
        {
            string filter = "";
            if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
            {
                filter = " TOP " + cbMaxRows.Text;
            }

            if (string.IsNullOrWhiteSpace(txt_Nome.Text))
            {
                _sql = "Select" + filter + " Produto.Id_Produto, Produto.Descricao, Produto.ValorVenda, Produto.CodigoBarra from produto";
            }
            else
            {
                _sql = "Select" + filter + " Produto.Id_Produto, Produto.Descricao, Produto.ValorVenda, Produto.CodigoBarra from produto where descricao like '%" + txt_Nome.Text.Trim() + "%'";
            }

            SqlConnection conexao = new SqlConnection(strinConn);
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            dgv_Busca.DataSource = Tabela;
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

        private void btn_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Blue;
            btn_Minimizar.ForeColor = Color.White;
        }
        private void btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {

            btn_Minimizar.BackColor = Color.PaleTurquoise;
            btn_Minimizar.ForeColor = Color.Black;
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
            btn_Fechar.ForeColor = Color.White;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.PaleTurquoise;
            btn_Fechar.ForeColor = Color.Black;
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
            CarregarGrid();
        }

        public int Codigo { get; set; }
        public string CodigoBarra { get; set; }

        private void dgv_Busca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Cont = e.RowIndex;
            if (Cont >= 0)
            {
                DataGridViewRow linha = dgv_Busca.Rows[e.RowIndex];
                Codigo = int.Parse(linha.Cells[0].Value.ToString());
                CodigoBarra = linha.Cells[3].Value.ToString();
                this.Close();
            }
        }

        private void dgv_Busca_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }

        private void cbMaxRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CarregarGrid();
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

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
