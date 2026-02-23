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
            // Fecha o formulário Menu
            this.Close();
        }

        private void produtosCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_consultaProdutos frm = new frm_consultaProdutos();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_consultaProdutos frm = new frm_consultaProdutos();
            frm.Show();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            // Fecha o formulário atual
            this.Close();
        }
    }
}
