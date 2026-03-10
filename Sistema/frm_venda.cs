using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sistema_DAL;

namespace Sistema
{
    public partial class frm_venda : Form
    {
        public frm_venda()
        {
            InitializeComponent();
        }

        private void frm_venda_Load(object sender, EventArgs e)
        {
            this.pessoasBindingSource.DataSource = DataContextFactory.DataContext.Pessoas;
            this.itensVendaBindingSource.DataSource = DataContextFactory.DataContext.ItensVenda;
            this.produtoBindingSource.DataSource = DataContextFactory.DataContext.Produto;
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();// Fecha o formulário Menu
        }
    }
}
