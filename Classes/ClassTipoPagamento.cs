using System.Data.SqlClient;

namespace CaixaFacil
{
    class TipoPagamento
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;

        private string Descricao;
        private int IdPagamentoParcial;
        private int IdPagamentoMisto;
        private int IdParcela;

        public string descricao
        {
            get { return Descricao; }
            set { Descricao = value; }
        }
        public int idPagamentoParcial
        {
            get { return IdPagamentoParcial; }
            set { IdPagamentoParcial = value; }
        }
        public int idPagamentoMisto
        {
            get { return IdPagamentoMisto; }
            set { IdPagamentoMisto = value; }
        }
        public int idParcela
        {
            get { return IdParcela; }
            set { IdParcela = value; }
        }

        public void InformarFormaPagamento()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Insert into TipoPagamento values (@Descricao, @IdPagamentoMisto, @IdPagamentoParcial, @IdParcela)";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@Descricao", descricao);
            comando.Parameters.AddWithValue("@IdPagamentoParcial", idPagamentoParcial);
            comando.Parameters.AddWithValue("@IdPagamentoMisto", idPagamentoMisto);
            comando.Parameters.AddWithValue("@IdParcela", idParcela);
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
