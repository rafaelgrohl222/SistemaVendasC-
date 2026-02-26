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
    public partial class frm_consultaProdutos : Form
    {
        public frm_consultaProdutos()
        {
            InitializeComponent();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();// Fecha o formulário atual
        }

        private void frm_consultaProdutos_Load(object sender, EventArgs e)
        {
           this.categoriaBindingSource.DataSource = DataContextFactory.DataContext.Categoria;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Pesquisar((int)CB_categoria.SelectedValue);
        }

        //Método - Buscar (void Solicita retorono)
        public void Pesquisar(int codigoCategoria) 
        {//DataSource = BD, verificando se id_categoria recebe o mesmo codigo, trazer esses produtos
            this.produtoBindingSource.DataSource = DataContextFactory.DataContext.Produto.Where(x => x.id_categoria == codigoCategoria);
        }
    }
}
