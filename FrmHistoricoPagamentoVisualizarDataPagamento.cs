using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmHistoricoPagamentoVisualizarDataPagamento : Form
    {
        string FormaPagamento, codVenda;
        int IdPagamento;
        public FrmHistoricoPagamentoVisualizarDataPagamento(string NVenda, string FormaPagamento, int idPagamento)
        {
            InitializeComponent();
            cbMaxRows.SelectedIndex = 1;
            codVenda = NVenda;
            this.FormaPagamento = FormaPagamento;
            this.IdPagamento = idPagamento;
        }

        private string FilterRows()
        {
            string filter = "";

            if (cbMaxRows.Text != "Todos" && !string.IsNullOrWhiteSpace(cbMaxRows.Text))
                filter = "TOP " + cbMaxRows.Text;

            return filter;
        }

        private void FrmListavenda_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (FormaPagamento == "Parcela")
            {
                InformarDataEValorPagamentoParcelaPago();
            }
            else if (FormaPagamento == "Prazo")
            {
                InformarDataEValorPagamentoPrazoPago();
            }
            else
            {
                InformarDataEValorPagamentoParcialOrMistoPago();
            }
        }

        string stringConn = Security.Dry("9UUEoK5YaRarR0A3RhJbiLUNDsVR7AWUv3GLXCm6nqT787RW+Zpgc9frlclEXhdH70DIx06R57s6u2h3wX/keyP3k/xHE/swBoHi4WgOI3vX3aocmtwEi2KpDD1I0/s3"), _sql;


        private void InformarDataEValorPagamentoParcelaPago()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "select " + FilterRows() + " ParcelaVenda.Id_Venda as venda, TipoPagamento.Descricao as especie, ParcelaVenda.ValorParcelado as ValorAbatido, ParcelaVenda.DataPagamento as DataAbatimento, ParcelaVenda.HoraPagamento as HoraAbatimento from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join ParcelaVenda on ParcelaVenda.Id_Venda = Venda.Id_Venda inner join Usuario on Usuario.Id_Usuario = Venda.Id_Usuario inner join TipoPagamento on TipoPagamento.id_Parcela = ParcelaVenda.id_Parcela where FormaPagamento.Descricao = 'PARCELADO' and ParcelaVenda.DataPagamento <> ''  and ParcelaVenda.Id_Venda = " + codVenda;
                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                dgvHistoricoPagamento.DataSource = Tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformarDataEValorPagamentoPrazoPago()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(stringConn);
                _sql = "select " + FilterRows() + " ParcelaVenda.Id_Venda as venda, TipoPagamento.Descricao as especie, ParcelaVenda.ValorParcelado as ValorAbatido, ParcelaVenda.DataPagamento as DataAbatimento, ParcelaVenda.HoraPagamento as HoraAbatimento from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join ParcelaVenda on ParcelaVenda.Id_Venda = Venda.Id_Venda inner join Usuario on Usuario.Id_Usuario = Venda.Id_Usuario inner join TipoPagamento on TipoPagamento.id_Parcela = ParcelaVenda.id_Parcela where FormaPagamento.Descricao = 'PRAZO' and ParcelaVenda.DataPagamento <> ''  and ParcelaVenda.Id_Venda = " + codVenda;
                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                dgvHistoricoPagamento.DataSource = Tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InformarDataEValorPagamentoParcialOrMistoPago()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(stringConn);

                if (FormaPagamento.ToUpper() == "PARCIAL")
                    _sql = "select " + FilterRows() + " venda.id_Venda as venda, ValorAbatido.ValorTotalAbatimento as ValorAbatido,  ValorAbatido.DataPagamento as DataAbatimento,  ValorAbatido.HoraPagamento as HoraAbatimento from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join PagamentoParcial on PagamentoParcial.Id_Venda = Venda.Id_Venda inner join ValorAbatido on ValorAbatido.Id_PagamentoParcial = PagamentoParcial.Id_PagamentoParcial inner join Usuario on Usuario.Id_Usuario = Venda.Id_Usuario where FormaPagamento.Descricao = 'PAGAMENTO PARCIAL' and PagamentoParcial.ValorRestante >= 0 and ValorAbatido.ValorTotalAbatimento > 0  and PagamentoParcial.Id_PagamentoParcial = " + IdPagamento;
                else if (FormaPagamento.ToUpper() == "MISTO")
                    _sql = "select " + FilterRows() + " venda.id_Venda as venda,  ValorMistoAbatido.ValorTotalAbatimento as ValorAbatido,  ValorMistoAbatido.DataPagamento as DataAbatimento,  ValorMistoAbatido.HoraPagamento as HoraAbatimento from Cliente inner join venda on Venda.Id_Cliente = Cliente.Id_Cliente inner join FormaPagamento on FormaPagamento.Id_Venda = Venda.Id_Venda inner join PagamentoMisto on PagamentoMisto.Id_Venda = Venda.Id_Venda inner join ValorMistoAbatido on ValorMistoAbatido.Id_PagamentoMisto = PagamentoMisto.Id_PagamentoMisto inner join Usuario on Usuario.Id_Usuario = Venda.Id_Usuario where FormaPagamento.Descricao = 'MISTO' and PagamentoMisto.ValorRestante >= 0 and ValorMistoAbatido.ValorTotalAbatimento > 0  and PagamentoMisto.Id_PagamentoMisto = " + IdPagamento;

                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                dgvHistoricoPagamento.DataSource = Tabela;
                InformarTipoPagamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void InformarTipoPagamento()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(stringConn);

                if (FormaPagamento.ToUpper() == "PARCIAL")
                    _sql = " Select " + FilterRows() + " Descricao as especie from TipoPagamento where Id_PagamentoParcial = " + IdPagamento;
                else if (FormaPagamento.ToUpper() == "MISTO")
                    _sql = "Select " + FilterRows() + " Descricao as especie from TipoPagamento where Id_PagamentoMisto = " + IdPagamento; 

                SqlDataAdapter comando = new SqlDataAdapter(_sql, conexao);
                comando.SelectCommand.CommandText = _sql;
                DataTable Tabela = new DataTable();
                comando.Fill(Tabela);
                int index = 0;
                foreach(DataRow dataRow in Tabela.Rows)
                {
                    dgvHistoricoPagamento.Rows[index].Cells["colTipoPagamento"].Value = dataRow["especie"].ToString();
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caixa Fácil", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHistoricoPagamento_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv;
            dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }

        private void cbMaxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvHistoricoPagamento.Rows.Count > 0)
                LoadData();
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
                LoadData();
        }

        private void FrmHistoricoPagamentoDetalhado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnFechar_Click(sender, e);
            }
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