using System.Data.SqlClient;

namespace CaixaFacil
{
    class PagamentoMisto
    {

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;

        private int idPagamentoMisto;
        private decimal valorDinheiro;
        private decimal valorCredDeb;
        private decimal valorRestante;
        private string formaPagamento;
        private int idVenda;

        public int _idPagamentoMisto
        {
            get { return idPagamentoMisto; }
            set { idPagamentoMisto = value; }
        }
        public decimal _valorDinheiro
        {
            get { return valorDinheiro; }
            set { valorDinheiro = value; }
        }
        public decimal _valorCredDeb
        {
            get { return valorCredDeb; }
            set { valorCredDeb = value; }
        }
        public decimal _valorRestante
        {
            get { return valorRestante; }
            set { valorRestante = value; }
        }
        public string _formaPagamento
        {
            get { return formaPagamento; }
            set { formaPagamento = value; }
        }
        public int _idVenda
        {
            get { return idVenda; }
            set { idVenda = value; }
        }

        public void EfetuarPagamentoMisto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "INSERT INTO PagamentoMisto VALUES (@ValorDinheiro, @ValorCredDeb, @ValorRestante, @FormaPagamento, @IdVenda)";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@ValorDinheiro", _valorDinheiro);
            comando.Parameters.AddWithValue("@ValorCredDeb", _valorCredDeb);
            comando.Parameters.AddWithValue("@ValorRestante", _valorRestante);
            comando.Parameters.AddWithValue("@FormaPagamento", _formaPagamento);
            comando.Parameters.AddWithValue("@IdVenda", _idVenda);
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

        public void InformarUltimoIdPagamentoMisto()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "SELECT MAX(Id_PagamentoMisto) as idPagamentoMisto FROM PagamentoMisto";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    idPagamentoMisto = int.Parse(dr["idPagamentoMisto"].ToString());
                }
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
