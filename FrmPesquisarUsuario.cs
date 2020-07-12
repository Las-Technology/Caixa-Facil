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
    public partial class FrmPesquisarUsuario : Form
    {
        public FrmPesquisarUsuario()
        {
            InitializeComponent();
        }

        public string Codigo { get; set; }


        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        int X = 0;
        int Y = 0;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.DarkOrange;
        }
              
        private void FrmPesquisarUsuario_Load(object sender, EventArgs e)
        {
            cbMaxRows.SelectedIndex = 1;
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                string filter = "";
                if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
                {
                    filter = " TOP " + cbMaxRows.Text;
                }

                if (string.IsNullOrWhiteSpace(txt_Nome.Text))
                {
                    _sql = "Select" + filter + " [Id_Usuario], [Nome], [Funcao], [Email], [Usuario], [Senha], [Situacao], [DicaSenha], [PerguntaSeguranca], [RespostaSeguranca] FROM Usuario where Situacao <> 'BLOQUEADO'";
                }
                else
                {
                    _sql = "Select" + filter + " [Id_Usuario], [Nome], [Funcao], [Email], [Usuario], [Senha], [Situacao], [DicaSenha], [PerguntaSeguranca], [RespostaSeguranca] FROM Usuario WHERE  Nome like  '%" + txt_Nome.Text.Trim() + "%' and Situacao <> 'BLOQUEADO'";
                }

                SqlConnection conexao = new SqlConnection(stringConn);
                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                {
                    dgv_Busca.DataSource = Tabela;
                }
                else
                {
                    MessageBox.Show("Dados não encontrado no banco de dados!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Close();
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
                this.Close();
            }
        }

        private void dgv_Busca_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv_Busca.ClearSelection();
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
                CarregarGrid();
        }

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
