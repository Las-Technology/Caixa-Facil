﻿using System;
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
    public partial class FrmSerial : Form
    {
        public FrmSerial()
        {
            InitializeComponent();
        }

        public string serialAtivo { get; set; }

        private void lblFechar_MouseEnter(object sender, EventArgs e)
        {
            lblFechar.BackColor = Color.Red;
        }

        private void lblFechar_MouseLeave(object sender, EventArgs e)
        {
            lblFechar.BackColor = Color.Transparent;
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string serial = "MEWLA-RBTWR-FOUNR-JQPZV";
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdHJjGrOXTsH7b9NW1qcCpVJxD4wsfhTDR6OXOUSfCqDynZ+0PYEaREWQ=="));
            string _sql = "insert into autentico values ('Ativo')";
            SqlCommand comando = new SqlCommand(_sql, conexao);
            comando.CommandText = _sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
            serialAtivo = "ok";
            this.Close();
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            if (txtSerial.Text == serial)
            {
                btnConfirmar.Enabled = true; 
            }
            else
            {
                btnConfirmar.Enabled = false;
            }
        }
    }
}
