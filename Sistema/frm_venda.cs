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
            this.vendaBindingSource.DataSource = DataContextFactory.DataContext.Venda;
            this.produtoBindingSource.DataSource = DataContextFactory.DataContext.Produto;

            this.vendaBindingSource.AddNew();
        }

        //Verificar existe alguma venda cadastrada
        public Venda vendaCorrente
        {
            get
            {
                return (Venda)this.vendaBindingSource.Current;
            }
        }
        //Verificar existe itensRecorrente cadastrado
        public ItensVenda ItensCorrente
        {
            get
            {
                return (ItensVenda)this.itensVendaBindingSource.Current;
            }
        }

        //Botão Sair
        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();// Fecha o formulário Menu
        }

        //Botão Nova venda
        private void btn_novaVenda_Click(object sender, EventArgs e)
        {
            this.vendaBindingSource.EndEdit();//Sair modo edição
            DataContextFactory.DataContext.SubmitChanges();//Realizar alterações no BD
            groupBox1.Visible = true;//Deixar visivel o groupBox
            btn_novaVenda.Enabled = false;//Button modo desabilitado

            this.itensVendaBindingSource.DataSource = DataContextFactory.DataContext.ItensVenda.Where (x => x.CodigoProduto == this.vendaCorrente.CodigoVenda);
            NovoItem();//
        }

        //Função - Novo Item
        private void NovoItem()
        {
            this.itensVendaBindingSource.AddNew();//Entrar com um valor
            this.ItensCorrente.CodigoVenda = this.vendaCorrente.CodigoVenda;//Verificar se é igual a venda atual
            this.ItensCorrente.Quantidade = 1;//Quando registrar novo item, incluir um linha

        }

        private void btn_novoItem_Click(object sender, EventArgs e)
        {
            this.itensVendaBindingSource.EndEdit();//Sair modo edição
            DG_vendas.Refresh();//Atualizar o gridView BD
            DataContextFactory.DataContext.SubmitChanges();//Mandar dados BD
            NovoItem();//Criar novo item
        }

        private void DG_vendas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 1)
            {
                e.Value = ((Produto).e.Value).desc_produto;
            }
        }
    }
}
