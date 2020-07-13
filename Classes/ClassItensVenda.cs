﻿using System.Data.SqlClient;

namespace CaixaFacil
{
    class ItensVenda
    {
        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3");
        string _sql;

        private int id_ItensVenda;
        private decimal ValorVenda;
        private int Quantidade;
        private decimal Lucro;
        private int Id_Venda;
        private int Id_Produto;

        public int id_Itens
        {
            get { return id_ItensVenda; }
            set { id_ItensVenda = value; }
        }
        public decimal Valor
        {
            get { return ValorVenda; }
            set { ValorVenda = value; }
        }
        public int quantidade
        {
            get { return Quantidade; }
            set { Quantidade = value; }
        }
        public decimal LucroItens
        {
            get { return Lucro; }
            set { Lucro = value; }
        }
        public int id_venda
        {
            get { return Id_Venda; }
            set { Id_Venda = value; }
        }
        public int id_produto
        {
            get { return Id_Produto; }
            set { Id_Produto = value; }
        }

        public void AdicionarItensVenda()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _sql = "Insert into itensVenda values (@Valor, @Quantidade, @Lucro, @Id_Venda, @Id_Produto)";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.Parameters.AddWithValue("@Valor", Valor);
            comando.Parameters.AddWithValue("@Quantidade", quantidade);
            comando.Parameters.AddWithValue("@Lucro", LucroItens);
            comando.Parameters.AddWithValue("@Id_venda", id_venda);
            comando.Parameters.AddWithValue("@Id_Produto", id_produto);
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
