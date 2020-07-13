using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmProcurarValidadeProdutos : Form
    {
        public FrmProcurarValidadeProdutos()
        {
            InitializeComponent();
            cb_Opcao.Text = "TODAS AS DATAS";
        }

        private void lbl_Fechar_MouseEnter(object sender, EventArgs e)
        {
            lbl_Fechar.BackColor = Color.Red;
        }

        private void lbl_Fechar_MouseLeave(object sender, EventArgs e)
        {
            lbl_Fechar.BackColor = Color.Transparent;
        }

        private void lbl_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            FrmValidadeProduto VP = new FrmValidadeProduto(cb_Opcao.Text);
            VP.ShowDialog();
        }
    }
}
