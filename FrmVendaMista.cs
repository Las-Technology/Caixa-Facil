﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaFacil
{
    public partial class FrmVendaMista : Form
    {
        public FrmVendaMista(decimal ValorTotal)
        {
            InitializeComponent();
            lblValorVenda.Text = "R$ " + ValorTotal;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            lblFechar.BackColor = Color.Transparent;
        }

        private void lblFechar_MouseEnter(object sender, EventArgs e)
        {
            lblFechar.BackColor = Color.Red;
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CancelarVendaVista_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
