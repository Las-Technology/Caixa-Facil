﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmRelatorioSaidaCaixa : Form
    {
        public FrmRelatorioSaidaCaixa()
        {
            InitializeComponent();
            cbMaxRows.SelectedIndex = 1;
        }

        private void FrmRelatorioSaidaCaixa_Load(object sender, EventArgs e)
        {
            CarregarValoresSaidaCaixa();
            ValorToTalSaidaCaixa();
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _Sql;

        private string FilterRows()
        {
            string filter = "";
            if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
                filter = "Top " + cbMaxRows.Text;

            return filter;
        }

        private void CarregarValoresSaidaCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _Sql = "Select " + FilterRows() + " FluxoCaixa.Id_Fluxo, FluxoCaixa.DataEntrada, Usuario.Nome, SaidaCaixa.ValorSaida, SaidaCaixa.MotivoRetirada from SaidaCaixa inner join FluxoCaixa on FluxoCaixa.Id_Fluxo = SaidaCaixa.Id_Fluxo inner join Usuario on Usuario.Id_Usuario = FluxoCaixa.Id_Usuario";
            SqlDataAdapter comando = new SqlDataAdapter(_Sql, conexao);
            comando.SelectCommand.CommandText = _Sql;
            DataTable Tabela = new DataTable();
            comando.Fill(Tabela);
            dgv_SaidaCaixa.DataSource = Tabela;
        }

        private void ValorToTalSaidaCaixa()
        {
            SqlConnection conexao = new SqlConnection(stringConn);
            _Sql = "Select  Sum(SaidaCaixa.ValorSaida) as ValorTotalSaida from SaidaCaixa";
            SqlCommand comando = new SqlCommand(_Sql, conexao);
            comando.CommandText = _Sql;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                if (comando.ExecuteScalar() == DBNull.Value)
                {
                    lbl_ValorTotalSaida.Text = "R$ 0,00";
                }
                else
                {
                    lbl_ValorTotalSaida.Text = "R$ " + comando.ExecuteScalar();
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

        private void btn_Fechar_MouseEnter(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Red;
        }

        private void btn_Fechar_MouseLeave(object sender, EventArgs e)
        {
            btn_Fechar.BackColor = Color.Transparent;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int X = 0, Y = 0;

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarValoresSaidaCaixa();
        }

        private void cbMaxRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void cbMaxRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CarregarValoresSaidaCaixa();
        }

        private void PanelCabecalho_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void PanelCabecalho_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }
    }
}
