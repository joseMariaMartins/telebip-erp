using System;
using System.Data.SQLite;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Guna.UI2.WinForms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormRmvEstoque : MaterialForm
    {
        private readonly int idProduto;
        private readonly string nomeProduto;
        private readonly int quantidadeAtual;

        // Callback para atualizar o DataGridView no FormEstoque
        public Action? AtualizarEstoqueCallback { get; set; }

        public FormRmvEstoque(int id, string nome, int quantidade)
        {
            InitializeComponent();

            idProduto = id;
            nomeProduto = nome;
            quantidadeAtual = quantidade;

            ThemeManager.ApplyDarkTheme();

            lbNomeProduto.Text = $"Produto: {nomeProduto}";
            lbQuantidadeAtual.Text = $"Quantidade atual: {quantidadeAtual}";

            // Eventos dos botões (sem mudar design)
            btnConfirmar.Click += btnConfirmar_Click;
            btnCancelar.Click += btnCancelar_Click_1;

            // Carrega os nomes dos funcionários na ComboBox
            CarregarFuncionarios();
        }

        private void CarregarFuncionarios()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string sql = "SELECT NOME FROM FUNCIONARIO ORDER BY NOME;";
                using var cmd = new SQLiteCommand(sql, conn);
                using var reader = cmd.ExecuteReader();

                cbFuncionarios.Items.Clear();
                while (reader.Read())
                {
                    cbFuncionarios.Items.Add(reader["NOME"].ToString());
                }

                cbFuncionarios.SelectedIndex = -1; // Nenhum selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbExcluirProduto.Checked)
                ExcluirProduto();
            else
                RemoverQuantidade();
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

            if (cbFuncionarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione o funcionário responsável pela saída.");
                return;
            }

            string nomeFuncionario = cbFuncionarios.SelectedItem.ToString();

            try
            {
                // Atualiza estoque
                string sqlUpdate = "UPDATE PRODUTO SET QTD_ESTOQUE = QTD_ESTOQUE - @qtd WHERE ID_PRODUTO = @id";
                DatabaseHelper.ExecuteNonQuery(sqlUpdate, new SQLiteParameter[]
                {
                    new SQLiteParameter("@qtd", qtdRemover),
                    new SQLiteParameter("@id", idProduto)
                });

                // Registra movimentação (usa o nome do funcionário)
                string sqlMov = @"
                    INSERT INTO MOVIMENTACAO_ESTOQUE 
                    (ID_PRODUTO, NOME_FUNCIONARIO, TIPO_MOVIMENTACAO, QUANTIDADE, DATA_HORA)
                    VALUES (@idProd, @func, 'SAIDA', @qtd, datetime('now','localtime'));
                ";

                DatabaseHelper.ExecuteNonQuery(sqlMov, new SQLiteParameter[]
                {
                    new SQLiteParameter("@idProd", idProduto),
                    new SQLiteParameter("@func", nomeFuncionario),
                    new SQLiteParameter("@qtd", qtdRemover)
                });

                AtualizarEstoqueCallback?.Invoke();
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

            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql = "DELETE FROM PRODUTO WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametros = {
                    new SQLiteParameter("@id", idProduto)
                };

                DatabaseHelper.ExecuteNonQuery(sql, parametros);

                AtualizarEstoqueCallback?.Invoke();
                MessageBox.Show("Produto excluído com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto: " + ex.Message);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
