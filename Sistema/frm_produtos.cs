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
    public partial class frm_produtos : Form
    {
        public frm_produtos()
        {
            InitializeComponent();
        }

        private void frm_produtos_Load(object sender, EventArgs e)
        {
            this.produtoBindingSource.DataSource = DataContextFactory.DataContext.Produto;
            this.categoriaBindingSource.DataSource = DataContextFactory.DataContext.Categoria;
        }

        //Botão Novo
        private void btn_novo_Click(object sender, EventArgs e)
        {
            this.produtoBindingSource.AddNew();
        }

        //Botão Cadastrar Produto
        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            //Teste se o campo está vazio
            if (this.valida())
            {
                this.produtoBindingSource.EndEdit();//Sair modo edição
                DataContextFactory.DataContext.SubmitChanges(); //Inserir e alterar na BD
                dataGridView1.Refresh();//Atualizar o datagridView
                MessageBox.Show("Produto CADASTRADO / Atualizado com Sucesso!");//Mensagem ao usuário
            }
        }

        //Validação Botão Cadastrar
        private bool valida()
        {
            //.Trim: Retira espaço vazio, string.Empty=vazio ou ""
            if (txt_desc_produto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campo é produto OBRIGATÓRIO");
                txt_desc_produto.Focus();
                return false;
            }
            return true;
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    this.produtoBindingSource.RemoveCurrent();//Sair modo edição
                    DataContextFactory.DataContext.SubmitChanges();//Realizar alteração na BD
                    MessageBox.Show("Produto EXCLUIDA com Sucesso!");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.produtoBindingSource.CancelEdit();
        }

        //Exibir a descrição do produto na gridView
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 3)
            {
                e.Value = ((Categoria)e.Value).desc_categoria;
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            // Fecha o formulário atual
            this.Close();
        }
    }
}
