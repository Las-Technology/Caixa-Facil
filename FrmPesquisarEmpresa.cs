using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmPesquisarEmpresa : Form
    {
        public FrmPesquisarEmpresa()
        {
            InitializeComponent();
        }

        private void FrmPesquisarEmpresa_Load(object sender, EventArgs e)
        {
            cbMaxRows.SelectedIndex = 1;
            CarregarGrid();
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.DarkOrange;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string Codigo { get; set; }
       
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
            CarregarGrid();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        private void CarregarGrid()
        {
            string filter = "";
            if (cbMaxRows.Text != "Todos")
            {
                filter = " TOP " + cbMaxRows.Text;
            }

            if (string.IsNullOrWhiteSpace(txt_Nome.Text))
            {
                _sql = "Select" + filter +" [Id_Empresa], [RazaoSocial], [NomeFantasia], [AreaAtuacao], [CNPJ], [InscricaoEstadual], [Endereco], [CEP], [Numero], [Bairro], [Cidade], [Estado], [Telefone], [Celular], [Email], [LogoEmpresa] from Empresa";
            }
            else
            {
                _sql = "Select" + filter + " [Id_Empresa], [RazaoSocial], [NomeFantasia], [AreaAtuacao], [CNPJ], [InscricaoEstadual], [Endereco], [CEP], [Numero], [Bairro], [Cidade], [Estado], [Telefone], [Celular], [Email], [LogoEmpresa] from Empresa where RazaoSocial like '%" + txt_Nome.Text.Trim() + "%'";
            }

            SqlConnection conexao = new SqlConnection(stringConn);
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            try
            {
                conexao.Open();
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                dgv_Busca.DataSource = Tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_Busca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Cont = e.RowIndex;
            if (Cont >= 0)
            {
                DataGridViewRow linhas = dgv_Busca.Rows[e.RowIndex];
                Codigo = linhas.Cells[0].Value.ToString();
                this.Close();
            }
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

        private void dgv_Busca_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv_Busca.ClearSelection();
        }
    }
}
