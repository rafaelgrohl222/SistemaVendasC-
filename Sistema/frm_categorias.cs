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
    public partial class frm_categorias : Form
    {
        public frm_categorias()
        {
            InitializeComponent();
        }

        private void frm_categorias_Load(object sender, EventArgs e)
        {
            this.categoriaBindingSource.DataSource = DataContextFactory.DataContext.Categoria;
        }

        //Botão Novo
        private void btn_novo_Click(object sender, EventArgs e)
        {
            this.categoriaBindingSource.AddNew();
        }

        //Botão Cadastrar
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            //Teste se o campo está vazio
            if(this.valida()) 
            {
                this.categoriaBindingSource.EndEdit();//Sair modo edição
                DataContextFactory.DataContext.SubmitChanges(); //Inserir e alterar na BD
                MessageBox.Show("Categoria CADASTRADO com Sucesso!");//Mensagem ao usuário
            }
        }
        //Validação Botão Cadastrar
        private bool valida()
        {
            //.Trim: Retira espaço vazio, string.Empty=vazio ou ""
            if (txt_categoria.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campo é categoria OBRIGATÓRIO");
                txt_categoria.Focus();
                return false;
            }
            return true;
        }

        //Botão Excluir
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Tem certeza", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(this.CategoriaPossuiProduto(this.categoriaAtual))
                { 
                    MessageBox.Show("Não pode excluir a categoria, existe produtos vinculadas!");
                }
                else
                {
                    this.categoriaBindingSource.RemoveCurrent();//Sair modo edição
                    DataContextFactory.DataContext.SubmitChanges();//Realizar alteração na BD
                    MessageBox.Show("Categoria EXCLUIDA com Sucesso!");
                }
            }
        }

        //Botão Cancelar
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.categoriaBindingSource.CancelEdit();
        }

        //Método Evitar de excluir categoria se estiver atrelada a outro item
        public Categoria categoriaAtual
        {
            get
            {
                //Verificar categoria atual
                return (Categoria)this.categoriaBindingSource.Current;
            }
        }

        //Método Categoria possui produto
        private bool CategoriaPossuiProduto(Categoria categoria)
        {
            var produtos = DataContextFactory.DataContext.Produto.Where(x => x.id_categoria == categoria.id_categoria);
            if (produtos.Count() > 0) { return true; }

            else { return false; }
        }
    }
}
