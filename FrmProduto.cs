using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmProduto : Form
    {

        public FrmProduto()
        {
            InitializeComponent();            
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            CodigoProduto();
        }

        string IdProduto;
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

                    IdProduto = "1";
                    txt_Codigo.Text = IdProduto;
                }
                else
                {
                    Int32 ra = Convert.ToInt32(comando.ExecuteScalar()) + 1;
                    IdProduto = ra.ToString();
                    txt_Codigo.Text = IdProduto;
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

        string Id_Categoria;
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;
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
                    Id_Categoria = "1";
                }
                else
                {
                    Int32 ra = Convert.ToInt32(comando.ExecuteScalar()) + 1;
                    Id_Categoria = ra.ToString();
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

        private void btn_LimparExclusao_Click(object sender, EventArgs e)
        {
            txt_Codigo.Clear();
            txt_Categoria.Clear();
            txt_CodigoBarra.Clear();
            txt_Marca.Clear();
            txt_NomeProduto.Clear();
            txt_EstoqueAtual.Clear();
            txt_Unidade.Clear();
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
            txt_Lucro.Clear();
            txt_NomeFornecedor.Clear();
            txt_Categoria.Clear();
            txt_CodigoBarra.Clear();
            txt_DataValidade.Text = "00000000";
            txt_Marca.Clear();
            txt_NomeProduto.Clear();
            txt_PrecoVenda.Clear();
            txt_PrecoCusto.Clear();
            txt_EstoqueAtual.Clear();
            txt_EstoqueMinimo.Clear();
            txt_Unidade.Clear();
            idFornecedor = 0;
            Id_Categoria = "";
            Id_Produto = 0;

        }
        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }
        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Plum;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Minimizar_MouseEnter(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Blue;
        }

        private void btn_Minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_Minimizar.BackColor = Color.Plum;
        }
        ClassCategoria categoria = new ClassCategoria();
        ClassProduto produto = new ClassProduto();

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            CodigoProduto();

            if (txt_NomeProduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Nome do produto'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                errorProvider.Clear();
                errorProvider.SetError(txt_NomeProduto, "Campo obrigatório!");
                txt_NomeProduto.Focus();
                return;
            }
            else if (txt_NomeFornecedor.Text == string.Empty)
            {
                MessageBox.Show("Tecle o botão buscar e selecione o fornecedor do produto a ser inserido no sistema!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_NomeFornecedor, "Campo obrigatório!");
                txt_NomeFornecedor.Focus();
                return;
            }           
            else if (txt_Marca.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Marca'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_Marca, "Campo obrigatório!");
                txt_Marca.Focus();
                return;
            }
            else if (txt_Categoria.Text == string.Empty)
            {
                MessageBox.Show("Indique a categoria do produto!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_Categoria, "Campo obrigatório!");
                txt_Categoria.Focus();
                return;
            }
            else if (!txt_DataValidade.MaskCompleted)
            {
                MessageBox.Show("Coloque a data da validade do produto. Se a validade é indeterminada preencha 00/00/0000!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_DataValidade, "Campo obrigatório!");
                txt_DataValidade.Focus();
                return;
            }
            else if (txt_PrecoCusto.Text == string.Empty)
            {
                MessageBox.Show("Coloque o preço custo do produto", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_PrecoCusto, "Campo obrigatório!");
                txt_PrecoCusto.Focus();
                return;
            }
            else if (txt_PrecoVenda.Text == string.Empty)
            {
                MessageBox.Show("Coloque o valor da venda!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_PrecoVenda, "Campo obrigatório!");
                txt_PrecoVenda.Focus();
                return;
            }
            else if (txt_EstoqueMinimo.Text == string.Empty)
            {
                MessageBox.Show("Coloque a quantidade mínima que o estoque deve ter. Ex: 2.", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_EstoqueMinimo, "Campo obrigatório!");
                txt_EstoqueMinimo.Focus();
                return;
            }
            else if (txt_EstoqueAtual.Text == string.Empty)
            {
                MessageBox.Show("Coloque a quantidade atual no estoque!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear();
                errorProvider.SetError(txt_EstoqueAtual, "Campo obrigatório!");
                txt_EstoqueAtual.Focus();
                return;
            }
           
            else if (txt_Unidade.Text == string.Empty)
            {
                MessageBox.Show("Coloque a unidade. Ex: unidade. Kg. etc...", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear();
                errorProvider.SetError(txt_Unidade, "Campo obrigatório!");
                txt_Unidade.Focus();
                return;
            }
            else
            {
                try
                {

                    Codigocategoria();
                    categoria.id = int.Parse(Id_Categoria);
                    categoria.Descricao = txt_Categoria.Text.Trim();                    
                    categoria.Cadastrar();
                    produto.id = int.Parse(txt_Codigo.Text);
                    produto.descricao = txt_NomeProduto.Text.Trim();
                    produto.codigoBarra = txt_CodigoBarra.Text;
                    produto.marca = txt_Marca.Text.Trim();
                    produto.datavalidade = txt_DataValidade.Text;
                    produto.valorVenda = decimal.Parse(txt_PrecoVenda.Text.Trim());
                    produto.valorCusto = decimal.Parse(txt_PrecoCusto.Text.Trim());
                    produto.lucro = decimal.Parse(txt_Lucro.Text);
                    produto.estoqueAtual = int.Parse(txt_EstoqueAtual.Text.Trim());
                    produto.estoqueMinimo = int.Parse(txt_EstoqueMinimo.Text.Trim());
                    produto.unidade = txt_Unidade.Text.Trim();
                    produto.id_categoria = int.Parse(Id_Categoria);
                    produto.id_fornecedor = idFornecedor;
                    produto.numeroNotaFiscal = txtNumeroContaFiscal.Text;
                    produto.dataCadastro = dtDataCadastro.Text;
                    produto.Cadastrar();
                    MessageBox.Show("Produto cadastrado com sucesso!", "Informação do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CodigoProduto();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int Id_Produto;
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            FrmPesquisarProdutos pesquisarProdutos = new FrmPesquisarProdutos();
            pesquisarProdutos.ShowDialog();
            if (pesquisarProdutos.ID_PRODUTO != null)
            {
                Id_Produto = int.Parse(pesquisarProdutos.ID_PRODUTO);
                txt_Codigo.Text = pesquisarProdutos.ID_PRODUTO;
                txt_NomeFornecedor.Text = pesquisarProdutos.Fornecedor;
                BuscarProduto();
                BuscarCategoria();
            }
        }

        private void BuscarProduto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select * from Produto where id_Produto = " + txt_Codigo.Text;
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            try
            {
                conexao.Open();
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                {
                    
                    txt_CodigoBarra.Text = Tabela.Rows[0]["CodigoBarra"].ToString();
                    txt_NomeProduto.Text = Tabela.Rows[0]["Descricao"].ToString();
                    txt_Marca.Text = Tabela.Rows[0]["Marca"].ToString();
                    txt_EstoqueAtual.Text = Tabela.Rows[0]["EstoqueAtual"].ToString();
                    txt_EstoqueMinimo.Text = Tabela.Rows[0]["EstoqueAtual"].ToString();
                    txt_Unidade.Text = Tabela.Rows[0]["Unidade"].ToString();
                    txt_PrecoVenda.Text = Tabela.Rows[0]["ValorVenda"].ToString();
                    txt_PrecoCusto.Text = Tabela.Rows[0]["ValorCusto"].ToString();
                    txt_Lucro.Text = Tabela.Rows[0]["Lucro"].ToString();
                    Id_Categoria = Tabela.Rows[0]["Id_Categoria"].ToString();
                    idFornecedor = int.Parse( Tabela.Rows[0]["Id_Fornecedor"].ToString());
                    dtDataCadastro.Text = Tabela.Rows[0]["DataCadastro"].ToString();
                    txtNumeroContaFiscal.Text = Tabela.Rows[0]["NumeroNotaFiscal"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarCategoria()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select * from Categoria where id_Categoria = " + Id_Categoria;
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.CommandText = _sql;
            try
            {
                conexao.Open();
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                {
                    txt_Categoria.Text = Tabela.Rows[0]["Descricao"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (Id_Produto > 0)
            {
                try
                {
                    categoria.id = int.Parse(Id_Categoria);
                    produto.id = Id_Produto;
                    if (MessageBox.Show("Deseja mesmo excluir este produto?", "Pergunta do sistema.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Codigocategoria();
                        produto.Deletar();
                        categoria.Deletar();
                        MessageBox.Show("Produto excluido com sucesso", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CodigoProduto();
                    }
                }
                catch 
                {
                    MessageBox.Show("Não é permitido a exclusão! Existe registros de venda(s) do produto selecionado", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Informe os dados do produto para excluir!", "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_Quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_NomeProduto_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Marca_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Categoria_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Descricao_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_DataValidade_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Preço_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Quantidade_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_Unidade_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_PrecoCusto_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_PrecoCusto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Salvar_Click(sender, e);
            }
        }
        int idFornecedor;
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            FrmPesquisarFornecedor pesquisarFornecedor = new FrmPesquisarFornecedor();
            pesquisarFornecedor.ShowDialog();
            if (pesquisarFornecedor.Codigo != null)
            {
                idFornecedor = int.Parse(pesquisarFornecedor.Codigo);
                txt_NomeFornecedor.Text = pesquisarFornecedor.Fornecedor;
            }
        }

        private void txt_PrecoCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (((int)e.KeyChar) != ((int)Keys.Back))
                    if (e.KeyChar != ',')
                        e.Handled = true;
                    else if (txt_PrecoCusto.Text.IndexOf(',') > 0)
                        e.Handled = true;
            }
        }

        private void txt_PrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (((int)e.KeyChar) != ((int)Keys.Back))
                    if (e.KeyChar != ',')
                        e.Handled = true;
                    else if (txt_PrecoVenda.Text.IndexOf(',') > 0)
                        e.Handled = true;
            }
        }

        private void txt_EstoqueMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txt_DataValidade_Leave(object sender, EventArgs e)
        {
            if ((txt_DataValidade.MaskCompleted) && txt_DataValidade.Text != "00/00/0000")
            {
                DateTime resultado = DateTime.MinValue;
                if (!DateTime.TryParse(this.txt_DataValidade.Text.Trim(), out resultado))
                {
                    MessageBox.Show("Data Inválida!", "Informação do sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_DataValidade.Clear();
                    txt_DataValidade.Focus();
                }
            }
        }

        private void txt_NomeFornecedor_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        decimal PrecoCusto, PrecoVenda, Lucro;
        private void txt_PrecoCusto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_PrecoCusto.Text != "")
                {
                    txt_PrecoCusto.Text = Convert.ToDecimal(txt_PrecoCusto.Text.Trim()).ToString("0.00");
                    if (txt_PrecoVenda.Text != "" && txt_PrecoCusto.Text != "")
                    {
                        PrecoCusto = decimal.Parse(txt_PrecoCusto.Text);
                        PrecoVenda = decimal.Parse(txt_PrecoVenda.Text);
                        Lucro = PrecoVenda - PrecoCusto;
                        txt_Lucro.Text = Lucro.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PrecoCusto.Clear();
            }
        }

        private void btn_PesquisarCodigoProduto_Click(object sender, EventArgs e)
        {
            FrmPesquisarProdutos pesquisarProdutos = new FrmPesquisarProdutos();
            pesquisarProdutos.ShowDialog();
            if (pesquisarProdutos.ID_PRODUTO != null)
            {
                txt_Codigo.Text = pesquisarProdutos.ID_PRODUTO;
                AtualizarCategoria();
                produto.id = int.Parse(pesquisarProdutos.ID_PRODUTO);
                produto.ConsultarCodigoProduto();
                txt_CodigoBarra.Text = produto.codigoBarra;
                txt_NomeProduto.Text = produto.descricao;
                txt_Marca.Text = produto.marca;
                txt_DataValidade.Text = produto.datavalidade;
                txt_PrecoCusto.Text = produto.valorCusto.ToString();
                txt_PrecoVenda.Text = produto.valorVenda.ToString();
                txt_Lucro.Text = produto.lucro.ToString();
                txt_EstoqueAtual.Text = produto.estoqueAtual.ToString();
                txt_EstoqueMinimo.Text = produto.estoqueMinimo.ToString();
                txt_Unidade.Text = produto.unidade;
                txt_Categoria.Text = pesquisarProdutos.Descricao;               
                txt_NomeFornecedor.Text = pesquisarProdutos.Fornecedor;
                btn_Buscar.Enabled = true;
            }
            btn_AdicionarQuantidade.Enabled = true;
        }

        public void AtualizarCategoria()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Select Produto.Id_Fornecedor,Produto.Id_Categoria from Produto inner join Categoria on categoria.Id_Categoria=Produto.Id_Categoria inner join Fornecedor on Fornecedor.Id_Fornecedor=Produto.Id_Fornecedor where Produto.Id_Produto = @Id";
            SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
            comando.SelectCommand.Parameters.AddWithValue("@Id", txt_Codigo.Text);
            comando.SelectCommand.CommandText = _sql;
            try
            {
                conexao.Open();
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                Id_Categoria = Tabela.Rows[0]["Id_Categoria"].ToString();
                idFornecedor = int.Parse(Tabela.Rows[0]["Id_Fornecedor"].ToString());
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
        private void btn_PesquisarFornecedor_Click(object sender, EventArgs e)
        {
            FrmPesquisarFornecedor pesquisarFornecedor = new FrmPesquisarFornecedor();
            pesquisarFornecedor.ShowDialog();
            if (pesquisarFornecedor.Codigo != null)
            {
                idFornecedor = int.Parse(pesquisarFornecedor.Codigo);
                txt_NomeFornecedor.Text = pesquisarFornecedor.Fornecedor;
            }
        }

        private void btn_AdicionarQuantidade_Click(object sender, EventArgs e)
        {
            FrmAdicionarQuantidade adicionarQuantidade = new FrmAdicionarQuantidade(txt_EstoqueAtual.Text);
            adicionarQuantidade.ShowDialog();
            long quantidade = adicionarQuantidade.Quantidade;

            if (!string.IsNullOrWhiteSpace(txt_EstoqueAtual.Text))
            {
                long EstoqueAtual = long.Parse(txt_EstoqueAtual.Text);
                txt_EstoqueAtual.Text = (EstoqueAtual + quantidade).ToString();
            }
            else
                txt_EstoqueAtual.Text = quantidade.ToString();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (txt_NomeProduto.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Nome do produto'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                errorProvider.Clear();
                errorProvider.SetError(txt_NomeProduto, "Campo obrigatório!");
                txt_NomeProduto.Focus();
                return;
            }
            else if (txt_NomeFornecedor.Text == string.Empty)
            {
                MessageBox.Show("Clique no botão buscar e selecione o fornecedor do produto a ser inserido no sistema!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                errorProvider.Clear();
                errorProvider.SetError(txt_NomeFornecedor, "Campo obrigatório!");
                txt_NomeFornecedor.Focus();
                return;
            }
            else if (txt_Marca.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo 'Marca'!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_Marca, "Campo obrigatório!");
                txt_Marca.Focus();
                return;
            }
            else if (txt_Categoria.Text == string.Empty)
            {
                MessageBox.Show("Indique a categoria do produto!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                errorProvider.Clear();
                errorProvider.SetError(txt_Categoria, "Campo obrigatório!");
                txt_Categoria.Focus();
                return;
            }
            else if (!txt_DataValidade.MaskCompleted)
            {
                MessageBox.Show("Coloque a data da validade do produto. Se a validade é indeterminada preencha 00/00/0000!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                errorProvider.Clear();
                errorProvider.SetError(txt_DataValidade, "Campo obrigatório!");
                txt_DataValidade.Focus();
                return;
            }
            else if (txt_PrecoCusto.Text == string.Empty)
            {
                MessageBox.Show("Coloque o preço custo do produto", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                errorProvider.SetError(txt_PrecoCusto, "Campo obrigatório!");
                txt_PrecoCusto.Focus();
                return;
            }
            else if (txt_PrecoVenda.Text == string.Empty)
            {
                MessageBox.Show("Coloque o valor da venda!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorProvider.Clear();
                errorProvider.SetError(txt_PrecoVenda, "Campo obrigatório!");
                txt_PrecoVenda.Focus();
                return;
            }
            else if (txt_EstoqueMinimo.Text == string.Empty)
            {
                MessageBox.Show("Coloque a quantidade mínima que o estoque deve ter. Ex: 2.", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear();
                errorProvider.SetError(txt_EstoqueMinimo, "Campo obrigatório!");
                txt_EstoqueMinimo.Focus();
                return;
            }
            else if (txt_EstoqueAtual.Text == string.Empty)
            {
                MessageBox.Show("Coloque a quantidade atual no estoque!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); errorProvider.Clear();
                errorProvider.SetError(txt_EstoqueAtual, "Campo obrigatório!");
                txt_EstoqueAtual.Focus();
                return;
            }

            else if (txt_Unidade.Text == string.Empty)
            {
                MessageBox.Show("Coloque a unidade. Ex: unidade. Kg. etc...", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                errorProvider.Clear();
                errorProvider.SetError(txt_Unidade, "Campo obrigatório!");
                txt_Unidade.Focus();
                return;
            }
            else
            {
                try
                {
                    if (Id_Produto > 0)
                        EditarProduto();
                    else
                        MessageBox.Show("Informe os dados do produto para concluir as alterações dos dados", "Validação CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditarProduto()
        {
            categoria.id = int.Parse(Id_Categoria);
            categoria.Descricao = txt_Categoria.Text.Trim();
            categoria.Atualizar();
            produto.id = int.Parse(txt_Codigo.Text);
            produto.descricao = txt_NomeProduto.Text.Trim();
            produto.codigoBarra = txt_CodigoBarra.Text;
            produto.marca = txt_Marca.Text.Trim();
            produto.datavalidade = txt_DataValidade.Text;
            produto.valorVenda = decimal.Parse(txt_PrecoVenda.Text.Trim());
            produto.valorCusto = decimal.Parse(txt_PrecoCusto.Text.Trim());
            produto.lucro = decimal.Parse(txt_Lucro.Text);
            produto.estoqueAtual = int.Parse(txt_EstoqueAtual.Text.Trim());
            produto.estoqueMinimo = int.Parse(txt_EstoqueMinimo.Text.Trim());
            produto.unidade = txt_Unidade.Text.Trim();
            produto.id_fornecedor = idFornecedor;
            produto.numeroNotaFiscal = txtNumeroContaFiscal.Text;
            produto.dataCadastro = dtDataCadastro.Text;
            produto.Atualizar();

            MessageBox.Show("Produto atualizado com sucesso!", "Informação do sistema...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCampos();
            CodigoProduto();
        }

        ClassFornecedor Fornecedor = new ClassFornecedor();
        private void btn_Adicionar_Click(object sender, EventArgs e)
        {
            FrmFornecedor fornecedor = new FrmFornecedor("Adicionar Fornecedor");
            fornecedor.ShowDialog();
            if (fornecedor.IdFornecedor != null)
            {
                Fornecedor.id = int.Parse(fornecedor.IdFornecedor);
                Fornecedor.Consultar();
                txt_NomeFornecedor.Text = Fornecedor.nome;
                idFornecedor = int.Parse(fornecedor.IdFornecedor);

            }
            
        }

        private void txt_EstoqueAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtNumeroContaFiscal_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_PrecoVenda_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_EstoqueMinimo_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txt_EstoqueAtual_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void FrmProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btn_Salvar_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
                btn_Pesquisar_Click(sender, e);
            else if (e.KeyCode == Keys.F3)
                btn_Editar_Click(sender, e);
            else if (e.KeyCode == Keys.F4)
                btn_Excluir_Click(sender, e);
        }

        private void txt_EstoqueAtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_AdicionarQuantidade_Click(sender, e);
        }

        private void txt_CodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtNumeroContaFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void txt_PrecoVenda_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_PrecoVenda.Text != "")
                {
                    txt_PrecoVenda.Text = Convert.ToDecimal(txt_PrecoVenda.Text.Trim()).ToString("0.00");
                    if (txt_PrecoVenda.Text != "" && txt_PrecoCusto.Text != "")
                    {
                        PrecoCusto = decimal.Parse(txt_PrecoCusto.Text);
                        PrecoVenda = decimal.Parse(txt_PrecoVenda.Text);
                        Lucro = PrecoVenda - PrecoCusto;
                        txt_Lucro.Text = Lucro.ToString();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PrecoVenda.Clear();
            }
        }

        private void txt_NomeFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Buscar_Click(sender, e);
            }
        }
    }    
}
