using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class frm_menuPrincipal : Form
    {
        public frm_menuPrincipal()
        {
            InitializeComponent();
        }

        private void btn_cad_categorias_Click(object sender, EventArgs e)
        {
            frm_categorias frm = new frm_categorias();
            frm.Show();
        }

        private void btn_cad_produtos_Click(object sender, EventArgs e)
        {
            frm_produtos frm = new frm_produtos();
            frm.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_categorias frm = new frm_categorias();
            frm.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_produtos frm = new frm_produtos();
            frm.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();// Fecha o formulário Menu
        }

        private void produtosCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_consultaProdutos frm = new frm_consultaProdutos();
            frm.Show();
        }

        private void btn_consProduto(object sender, EventArgs e)
        {
            frm_consultaProdutos frm = new frm_consultaProdutos();
            frm.Show();//Abrir o form Consulta Produtos
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();// Fecha o formulário atual
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_venda frm = new frm_venda();
            frm.Show();//Abrir o form Vendas
        }

        private void btn_vendas_Click(object sender, EventArgs e)
        {
            frm_venda frm = new frm_venda();
            frm.Show();//Abrir o form Consulta Produtos
        }
    }
}
