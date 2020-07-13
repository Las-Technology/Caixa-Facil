using CaixaFacil.Properties;
using System;
using System.Data.SqlClient;
using System.IO;

namespace CaixaFacil
{
    static class Backup
    {
        static string directory = Settings.Default["Disco"].ToString() + @"Caixa Fácil/Arquivo-Backup/";
        static string DataTempo;

        private static void createDirectory()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void SetHorarioBackup()
        {
            DateTime DataAtual = DateTime.Now;
            int hr = DataAtual.Hour;
            int min = DataAtual.Minute;
            int sec = DataAtual.Second;
            int dia = DataAtual.Day;
            int mes = DataAtual.Month;
            int ano = DataAtual.Year;


            DataTempo = dia + "-" + mes + "-" + ano + "_" + hr + "_" + min + "_" + sec;
        }

        public static bool GerarBackup()
        {
            createDirectory();
            SetHorarioBackup();
            SqlConnection conexao = new SqlConnection(Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHJjGrOXTsH7b9NW1qcCpVJxD4wsfhTDR6OXOUSfCqDynZ+0PYEaREWQ=="));
            SqlCommand comando = new SqlCommand("", conexao);
            comando.CommandText = "backup database dbControleVenda to disk = '" + directory + "Backup - " + DataTempo + ".bak'"; ;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                return true;
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
