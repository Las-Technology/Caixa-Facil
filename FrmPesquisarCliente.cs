using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmPesquisarCliente : Form
    {
        public FrmPesquisarCliente()
        {
            InitializeComponent();
            cbMaxRows.SelectedIndex = 1;
        }

        private void CarregarGrid()
        {
            string filter = "";

            if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
            {
                filter = " TOP " + cbMaxRows.Text;
            }
            if (string.IsNullOrWhiteSpace(txt_Nome.Text))
            {
                _sql = "Select " + filter + " [Id_Cliente] ,[Nome] ,[DataNascimento] ,[CPF] ,[RG] ,[CEP] ,[Bairro] ,[Endereco] ,[Numero] ,[Cidade] ,[Estado] ,[Telefone] ,[Celular] ,[Email] from Cliente where id_Cliente <> 1";
            }
            else
            {
                _sql = "Select" + filter + "  [Id_Cliente] ,[Nome] ,[DataNascimento] ,[CPF] ,[RG] ,[CEP] ,[Bairro] ,[Endereco] ,[Numero] ,[Cidade] ,[Estado] ,[Telefone] ,[Celular] ,[Email] FROM Cliente WHERE  Nome like   '%" + txt_Nome.Text.Trim() + "%' and id_Cliente <> 1";
            }

            SqlConnection conexao = new SqlConnection(stringConn);
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
            adapter.SelectCommand.CommandText = _sql;
            try
            {
                conexao.Open();
                DataTable Tabela = new DataTable();
                adapter.Fill(Tabela);
                dgv_Busca.DataSource = Tabela;
                for (int i = 0; i < dgv_Busca.Rows.Count; i++)
                {
                    dgv_Busca.Rows[i].Cells["ColumnCPF"].Value = Security.Dry(dgv_Busca.Rows[i].Cells["ColumnCPF"].Value.ToString());
                    dgv_Busca.Rows[i].Cells["ColumnRG"].Value = Security.Dry(dgv_Busca.Rows[i].Cells["ColumnRG"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Telefone { get; set; }

        int X = 0;
        int Y = 0;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void FrmPesquisarCliente_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.DarkOrange;
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

        private void dgv_Busca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Cont = e.RowIndex;
            if (Cont >= 0)
            {
                DataGridViewRow LINHA = dgv_Busca.Rows[e.RowIndex];
                Codigo = LINHA.Cells[0].Value.ToString();
                Nome = LINHA.Cells[1].Value.ToString();
                Bairro = LINHA.Cells[6].Value.ToString();
                Endereco = LINHA.Cells[7].Value.ToString();
                Numero = LINHA.Cells[8].Value.ToString();
                Telefone = LINHA.Cells[11].Value.ToString();
                this.Close();
            }
        }

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarGrid();
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
