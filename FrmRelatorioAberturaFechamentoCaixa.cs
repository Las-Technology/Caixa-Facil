using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmRelatorioAberturaFechamentoCaixa : Form
    {
        public FrmRelatorioAberturaFechamentoCaixa()
        {
            InitializeComponent();
        }

        private void FrmRelatorioAberturaFechamentoCaixa_Load(object sender, EventArgs e)
        {
            cbMaxRows.SelectedIndex = 1;
            cb_Opcao.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            if (string.IsNullOrWhiteSpace(txt_Descricao.Text))
                LoadGrid();
            else
                LoadDataOption();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        private string FilterRows()
        {
            string filter = "";

            if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
                filter = "TOP " + cbMaxRows.Text;

            return filter;
        }

        private void LoadGrid()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select " + FilterRows() + " FluxoCaixa.Id_Fluxo, FluxoCaixa.DataEntrada, FluxoCaixa.HoraEntrada, FluxoCaixa.ValorEntrada, FluxoCaixa.ValorCaixa, FluxoCaixa.DataSaida, FluxoCaixa.HoraSaida, Usuario.Nome From FluxoCaixa inner join Usuario on FluxoCaixa.Id_Usuario = Usuario.Id_Usuario where FluxoCaixa.DataSaida <> ''";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            dataGridView1.DataSource = Tabela;
        }

        private void PesquisarDataEntrada()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select " + FilterRows() + " FluxoCaixa.Id_Fluxo, FluxoCaixa.DataEntrada, FluxoCaixa.HoraEntrada, FluxoCaixa.ValorEntrada, FluxoCaixa.ValorCaixa, FluxoCaixa.DataSaida, FluxoCaixa.HoraSaida, Usuario.Nome From FluxoCaixa inner join Usuario on FluxoCaixa.Id_Usuario = Usuario.Id_Usuario where FluxoCaixa.DataEntrada like '" + txt_Descricao.Text + "%' and FluxoCaixa.DataSaida <> ''";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            dataGridView1.DataSource = Tabela;
        }

        private void PesquisarOperador()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select " + FilterRows() + " FluxoCaixa.Id_Fluxo, FluxoCaixa.DataEntrada, FluxoCaixa.HoraEntrada, FluxoCaixa.ValorEntrada, FluxoCaixa.ValorCaixa, FluxoCaixa.DataSaida, FluxoCaixa.HoraSaida, Usuario.Nome From FluxoCaixa inner join Usuario on FluxoCaixa.Id_Usuario = Usuario.Id_Usuario where Usuario.Nome like '" + txt_Descricao.Text + "%' and FluxoCaixa.DataSaida <> ''";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            dataGridView1.DataSource = Tabela;
        }

        private void PesquisarNumeroCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select " + FilterRows() + " FluxoCaixa.Id_Fluxo, FluxoCaixa.DataEntrada, FluxoCaixa.HoraEntrada, FluxoCaixa.ValorEntrada, FluxoCaixa.ValorCaixa, FluxoCaixa.DataSaida, FluxoCaixa.HoraSaida, Usuario.Nome From FluxoCaixa inner join Usuario on FluxoCaixa.Id_Usuario = Usuario.Id_Usuario where FluxoCaixa.Id_Fluxo like '" + txt_Descricao.Text + "%' and FluxoCaixa.DataSaida <> ''";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            dataGridView1.DataSource = Tabela;
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

        int X = 0, Y = 0;
        private void PanelCabecalho_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

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
                LoadData();
        }

        private void PanelCabecalho_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void txt_Descricao_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadDataOption()
        {
            if (cb_Opcao.SelectedIndex == 0)
            {
                PesquisarDataEntrada();
            }
            else if (cb_Opcao.SelectedIndex == 1)
            {
                PesquisarOperador();
            }
            else if (cb_Opcao.SelectedIndex == 2)
            {
                PesquisarNumeroCaixa();
            }
        }
    }
}
