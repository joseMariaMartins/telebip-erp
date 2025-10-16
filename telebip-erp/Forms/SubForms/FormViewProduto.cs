using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormViewProduto : MaterialForm
    {
        public FormViewProduto()
        {
            InitializeComponent();
        }

        // Método para carregar os dados do produto
        public void CarregarProduto(int id, string nome, string marca, decimal preco, int quantidade, int quantidadeAviso, string observacao)
        {
            lblID.Text = id.ToString();
            tbNome.Text = nome;
            tbMarca.Text = marca;
            tbPreco.Text = "R$ " + preco.ToString("N2");
            tbQEstoque.Text = quantidade.ToString();
            tbQAviso.Text = quantidadeAviso.ToString();
            tbObservacao.Text = observacao;

            // Atualiza o título
            lblTitulo.Text = $"Visualizar Produto - {nome}";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}