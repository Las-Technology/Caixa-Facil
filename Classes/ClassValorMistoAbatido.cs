using System.Data.SqlClient;

namespace CaixaFacil
{
    class ValorMistoAbatido
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;

        private decimal valorTotalAbatimento;
        private string dataPagamento;
        private string horaPagamento;
        private int idPagamentoMisto;

        public decimal _valorTotalAbatimento
        {
            get { return valorTotalAbatimento; }
            set { valorTotalAbatimento = value; }
        }
        public string _dataPagamento
        {
            get { return dataPagamento; }
            set { dataPagamento = value; }
        }
        public string _horaPagamento
        {
            get { return horaPagamento; }
            set { horaPagamento = value; }
        }
        public int _idPagamentoMisto
        {
            get { return idPagamentoMisto; }
            set { idPagamentoMisto = value; }
        }

        public void InserirValorMistoAbatido()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "INSERT INTO ValorMistoAbatido VALUES(@ValorTotalAbatimento, @DataPagamento, @HoraPagamento, @IdPagamento)";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorTotalAbatimento", _valorTotalAbatimento);
            comando.Parameters.AddWithValue("@DataPagamento", _dataPagamento);
            comando.Parameters.AddWithValue("@HoraPagamento", _horaPagamento);
            comando.Parameters.AddWithValue("@IdPagamento", _idPagamentoMisto);
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
