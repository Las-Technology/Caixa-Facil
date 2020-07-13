using System.Data.SqlClient;

namespace CaixaFacil
{
    class Estoque
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;

        private int EstoqueAtual;
        private int idProduto;
        private int Quantidade;

        public int estoqueAtual
        {
            get { return EstoqueAtual; }
            set { EstoqueAtual = value; }
        }
        public int id
        {
            get { return idProduto; }
            set { idProduto = value; }
        }
        public int quantidade
        {
            get { return Quantidade; }
            set { Quantidade = value; }
        }

        public void AtualizarEstoque()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "update produto set EstoqueAtual = EstoqueAtual - @Quantidade where id_Produto = @id";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@Quantidade", quantidade);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
