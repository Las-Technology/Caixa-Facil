using System;
using System.Data;
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
        private int idVenda;
        private int idCliente;

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
        public int _idVenda
        {
            get { return idVenda; }
            set { idVenda = value; }
        }
        public int _idCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public void EfetuarPagamentoMisto()
        {
                SqlConnection conexao = new SqlConnection(stringConn);
            try
            {
                conexao.Open();
                _sql = "SELECT PagamentoMisto.ID_Venda, PagamentoMisto.ValorRestante FROM PagamentoMisto INNER JOIN Venda ON  PagamentoMisto.Id_Venda = Venda.Id_Venda INNER JOIN Cliente ON Cliente.Id_Cliente = Venda.Id_Cliente WHERE PagamentoMisto.ValorRestante > 0 AND Cliente.Id_cliente = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexao);
                adapter.SelectCommand.Parameters.AddWithValue("@id", _idCliente);
                adapter.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                adapter.Fill(Tabela);
                if (Tabela.Rows.Count > 0)
                {
                    _sql = "update PagamentoMisto set ValorRestante = ValorRestante + @ValorRestante, ValorCredDeb = ValorCredDeb + @ValorCredDeb, ValorDinheiro = ValorDinheiro + @ValorDinheiro  from PagamentoMisto inner join Venda on PagamentoMisto.Id_Venda = Venda.Id_Venda inner join Cliente on Cliente.Id_Cliente = venda.Id_Cliente  where Cliente.Id_Cliente = @id and PagamentoMisto.ValorRestante > 0";
                    SqlCommand comando = new SqlCommand(_sql, conexao);
                    comando.Parameters.AddWithValue("@id", idCliente);
                    comando.Parameters.AddWithValue("@ValorRestante", valorRestante);
                    comando.Parameters.AddWithValue("@ValorCredDeb", _valorCredDeb);
                    comando.Parameters.AddWithValue("@ValorDinheiro", _valorDinheiro);
                    comando.CommandText = _sql;
                    comando.ExecuteNonQuery();
                }
                else
                {
                    _sql = "INSERT INTO PagamentoMisto VALUES (@ValorDinheiro, @ValorCredDeb, @ValorRestante, @IdVenda)";
                    SqlCommand comando = new SqlCommand(_sql, conexao);
                    comando.Parameters.AddWithValue("@ValorDinheiro", _valorDinheiro);
                    comando.Parameters.AddWithValue("@ValorCredDeb", _valorCredDeb);
                    comando.Parameters.AddWithValue("@ValorRestante", _valorRestante);
                    comando.Parameters.AddWithValue("@IdVenda", _idVenda);
                    comando.CommandText = _sql;
                    comando.ExecuteNonQuery();
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
