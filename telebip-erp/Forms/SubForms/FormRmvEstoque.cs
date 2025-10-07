using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SQLite;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormRmvEstoque : Form
    {
        private readonly int idProduto;
        private readonly string nomeProduto;
        private readonly int quantidadeAtual;

        public FormRmvEstoque(int id, string nome, int quantidade)
        {
            InitializeComponent();
            idProduto = id;
            nomeProduto = nome;
            quantidadeAtual = quantidade;

            btnConfirmar.Click += btnConfirmar_Click;


            lbNomeProduto.Text = $"Produto: {nomeProduto}";
            lbQuantidadeAtual.Text = $"Quantidade atual: {quantidadeAtual}";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Se a checkbox estiver marcada → exclui o produto inteiro
            if (cbExcluirProduto.Checked)
            {
                ExcluirProduto();
            }
            else
            {
                RemoverQuantidade();
            }
        }

        private void RemoverQuantidade()
        {
            if (!int.TryParse(tbQuantidadeRemover.Text, out int qtdRemover) || qtdRemover <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida para remover.");
                return;
            }

            if (qtdRemover > quantidadeAtual)
            {
                MessageBox.Show("A quantidade a remover não pode ser maior que a disponível.");
                return;
            }

            try
            {
                string sql = "UPDATE PRODUTO SET QTD_ESTOQUE = QTD_ESTOQUE - @qtd WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametros = {
                    new SQLiteParameter("@qtd", qtdRemover),
                    new SQLiteParameter("@id", idProduto)
                };

                DatabaseHelper.ExecuteNonQuery(sql, parametros);

                MessageBox.Show("Quantidade removida com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover quantidade: " + ex.Message);
            }
        }

        private void ExcluirProduto()
        {
            var confirm = MessageBox.Show(
                "Tem certeza que deseja excluir este produto do sistema?",
                "Confirmação de exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string sql = "DELETE FROM PRODUTO WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametros = {
                    new SQLiteParameter("@id", idProduto)
                };

                DatabaseHelper.ExecuteNonQuery(sql, parametros);

                MessageBox.Show("Produto excluído com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto: " + ex.Message);
            }
        }


    }
}