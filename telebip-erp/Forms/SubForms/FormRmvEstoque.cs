using System;
using System.Data.SQLite;
using System.Windows.Forms;
using MaterialSkin.Controls;
using CuoreUI.Controls;
using telebip_erp.Forms.Auth;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormRmvEstoque : FormLoad
    {
        private readonly int idProduto;
        private readonly string nomeProduto;
        private readonly int quantidadeAtual;

        public Action? AtualizarEstoqueCallback { get; set; }

        public FormRmvEstoque(int id, string nome, int quantidade)
        {
            InitializeComponent();

            idProduto = id;
            nomeProduto = nome;
            quantidadeAtual = quantidade;

            lbNomeProduto.Text = $"Produto: {nomeProduto}";
            lbQuantidadeAtual.Text = $"Quantidade atual: {quantidadeAtual}";

            btnConfirmar.Click += btnConfirmar_Click;
            btnCancelar.Click += btnCancelar_Click;

            // Configurar Enter para disparar o Confirmar em qualquer campo
            ConfigurarEnterParaConfirmar();

            CarregarFuncionarios();

            // Focar no primeiro campo
            tbQuantidadeRemover.Focus();
            tbQuantidadeRemover.SelectAll();
        }

        private void ConfigurarEnterParaConfirmar()
        {
            // Configurar todos os controles para Enter disparar o Confirmar
            tbQuantidadeRemover.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnConfirmar_Click(btnConfirmar, EventArgs.Empty);
                }
            };


            cbFuncionarios.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnConfirmar_Click(btnConfirmar, EventArgs.Empty);
                }
            };

            btnConfirmar.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnConfirmar_Click(sender, e);
                }
            };

            // Para o botão Cancelar
            btnCancelar.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                }
            };

            // Habilitar KeyPreview para capturar ESC globalmente
            this.KeyPreview = true;
            this.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            };
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

                cbFuncionarios.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
                RemoverQuantidade();
        }

        private void RemoverQuantidade()
        {
            if (!int.TryParse(tbQuantidadeRemover.Text, out int qtdRemover) || qtdRemover <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida para remover.");
                tbQuantidadeRemover.Focus();
                tbQuantidadeRemover.SelectAll();
                return;
            }

            if (qtdRemover > quantidadeAtual)
            {
                MessageBox.Show("A quantidade a remover não pode ser maior que a disponível.");
                tbQuantidadeRemover.Focus();
                tbQuantidadeRemover.SelectAll();
                return;
            }

            if (cbFuncionarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione o funcionário responsável pela saída.");
                cbFuncionarios.Focus();
                return;
            }

            string nomeFuncionario = cbFuncionarios.SelectedItem.ToString();

            try
            {
                string sqlUpdate = "UPDATE PRODUTO SET QTD_ESTOQUE = QTD_ESTOQUE - @qtd WHERE ID_PRODUTO = @id";
                DatabaseHelper.ExecuteNonQuery(sqlUpdate, new SQLiteParameter[]
                {
                    new SQLiteParameter("@qtd", qtdRemover),
                    new SQLiteParameter("@id", idProduto)
                });

                string sqlMov = @"
                    INSERT INTO MOVIMENTACAO_ESTOQUE 
                    (ID_PRODUTO, NOME_FUNCIONARIO, TIPO_MOVIMENTACAO, QUANTIDADE, DATA_HORA)
                    VALUES (@idProd, @func, 'SAIDA', @qtd, strftime('%d-%m-%Y %H:%M','now','localtime'));
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}