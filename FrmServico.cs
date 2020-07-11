using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmServico : Form
    {
        public FrmServico()
        {
            InitializeComponent();
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

        private void LimparCampos()
        {
            txt_CodigoServico.Clear();
            txt_DescricaoServico.Clear();
            txt_PrecoServico.Clear();
            idServico = 0;
        }

        ClassPrestacaoServico prestacaoServico = new ClassPrestacaoServico();
        ErrorProvider errorProvider = new ErrorProvider();

        private void FrmServico_Load(object sender, EventArgs e)
        {
            Codigocategoria();
            CodigoProduto();
        }

        ClassCategoria categoria = new ClassCategoria();
        private void Codigocategoria()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT MAX(Id_categoria) from categoria";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() == DBNull.Value)
                {
                    Id_Categoria = 1;
                }
                else
                {
                    Id_Categoria = Convert.ToInt32(comando.ExecuteScalar()) + 1;
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

        int Id_Produto, Id_Categoria;
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Transparent;
        }

        private void btn_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.White;
            btn_Minimizar.ForeColor = Color.Black;
        }

        private void btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Transparent;
            btn_Minimizar.ForeColor = Color.White;
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_PrecoServico_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_PrecoServico.Text != "")
                {
                    txt_PrecoServico.Text = Convert.ToDecimal(txt_PrecoServico.Text.Trim()).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PrecoServico.Clear();
            }
        }

        private void txt_PrecoServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (((int)e.KeyChar) != ((int)Keys.Back))
                    if (e.KeyChar != ',')
                        e.Handled = true;
                    else if (txt_PrecoServico.Text.IndexOf(',') > 0)
                        e.Handled = true;
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            CodigoProduto();
            if (txt_DescricaoServico.Text == "")
            {
                errorProvider.Clear();
                MessageBox.Show("Informe o nome do seviço para ser cadastrado!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txt_DescricaoServico, "Campo obrigatório!");
                txt_DescricaoServico.Focus();
                return;
            }
            else if (txt_PrecoServico.Text == "")
            {
                errorProvider.Clear();
                MessageBox.Show("Informe o preço do seviço para ser cadastrado!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txt_PrecoServico, "Campo obrigatório!");
                txt_PrecoServico.Focus();
                return;
            }
            else
            {
                try
                {
                    categoria.id = Id_Categoria;
                    categoria.Descricao = "Serviço";
                    categoria.Cadastrar();
                    prestacaoServico.id = int.Parse(txt_CodigoServico.Text);
                    prestacaoServico.descricao = txt_DescricaoServico.Text.Trim();
                    prestacaoServico.precoServico = decimal.Parse(txt_PrecoServico.Text);
                    prestacaoServico.lucro = decimal.Parse(txt_PrecoServico.Text);
                    prestacaoServico.estoqueAtual = 0;
                    prestacaoServico.estoqueMinimo = 0;
                    prestacaoServico.unidade = "Serviço";
                    prestacaoServico.id_Categoria = Id_Categoria;
                    prestacaoServico.Cadastrar();
                    MessageBox.Show("Serviço cadastrado com sucesso!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CodigoProduto();
                    Codigocategoria();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int idServico;
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            FrmPesquisarServico pesquisarServico = new FrmPesquisarServico();
            pesquisarServico.ShowDialog();
            if (pesquisarServico.Codigo != null)
            {
                idServico = int.Parse(pesquisarServico.Codigo);
                txt_CodigoServico.Text = pesquisarServico.Codigo;
                txt_DescricaoServico.Text = pesquisarServico.Descricao;
                txt_PrecoServico.Text = pesquisarServico.PrecoServico;
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (idServico == 0)
            {
                MessageBox.Show("Busque as informações para alteração dos dados!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_DescricaoServico.Text == "")
            {
                errorProvider.Clear();
                MessageBox.Show("Informe o nome do seviço para ser atualizado!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txt_DescricaoServico, "Campo obrigatório!");
                txt_DescricaoServico.Focus();
                return;
            }
            else if (txt_PrecoServico.Text == "")
            {
                errorProvider.Clear();
                MessageBox.Show("Informe o preço do seviço para ser cadastrado!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.SetError(txt_PrecoServico, "Campo obrigatório!");
                txt_PrecoServico.Focus();
                return;
            }
            else
            {
                try
                {
                    prestacaoServico.id = int.Parse(txt_CodigoServico.Text);
                    prestacaoServico.descricao = txt_DescricaoServico.Text.Trim();
                    prestacaoServico.precoServico = decimal.Parse(txt_PrecoServico.Text);
                    prestacaoServico.Atualizar();
                    MessageBox.Show("Dados da prestação de Serviço atualizado com sucesso!", "Mensagem do sistema 'Caixa Fácil'...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btn_Salvar_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
                btn_Pesquisar_Click(sender, e);
            else if (e.KeyCode == Keys.F3)
                btn_Editar_Click(sender, e);
        }

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void CodigoProduto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT MAX(Id_Produto) from Produto";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                if (comando.ExecuteScalar() == DBNull.Value)
                {

                    Id_Produto = 1;
                    txt_CodigoServico.Text = Id_Produto.ToString();
                }
                else
                {
                    Id_Produto = Convert.ToInt32(comando.ExecuteScalar()) + 1;                    
                   txt_CodigoServico.Text = Id_Produto.ToString();
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
    }
}
