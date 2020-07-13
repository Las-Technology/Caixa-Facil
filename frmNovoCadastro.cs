using System;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class frmNovoCadastro : Form
    {
        public frmNovoCadastro()
        {
            InitializeComponent();
        }

        private void btn_CadastroCliente_Click(object sender, EventArgs e)
        {
            FrmClientes clientes = new FrmClientes();
            clientes.ShowDialog();

        }

        private void btnCadastroProduto_Click(object sender, EventArgs e)
        {
            FrmProduto produto = new FrmProduto();
            produto.ShowDialog();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNovoCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_Sair_Click(sender, e);
            }
            else if (e.KeyCode == Keys.C)
            {
                btn_CadastroCliente_Click(sender, e);
            }
            else if (e.KeyCode == Keys.P)
            {
                btnCadastroProduto_Click(sender, e);
            }
        }
    }
}
