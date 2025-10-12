using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormEstoque : Form
    {
        public FormEstoque()
        {
            InitializeComponent();
            ConfiguracoesCombobox();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Eventos
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            CarregarEstoqueInicial();

            // 🔹 Garantir que nada fique selecionado ao abrir
            this.Shown += (s, e) =>
            {
                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;
            };
        }

        private void ConfiguracoesCombobox()
        {
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;

            cbPesquisaCampo.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;
        }

        private void AtualizarTotalItens()
        {
            lbTotal.Text = $"Total de itens: {dgvEstoque.Rows.Count}";
        }

        //  MÉTODO PÚBLICO PARA ATUALIZAR AUTOMATICAMENTE
        public void AtualizarTabela()
        {
            try
            {
                // Se houver texto na pesquisa, mantém o filtro atual
                if (!string.IsNullOrEmpty(tbPesquisa.Text.Trim()))
                {
                    BtnPesquisar_Click(null, EventArgs.Empty);
                }
                else
                {
                    // Se não há filtro, carrega os últimos 20
                    CarregarEstoqueInicial();
                }

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar tabela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarEstoque(string filtroSql = "", SQLiteParameter[]? parametros = null, bool limitar20 = false)
        {
            try
            {
                string sql = $@"
            SELECT 
                ID_PRODUTO,
                NOME,
                MARCA,
                PRECO,
                QTD_ESTOQUE,
                QTD_AVISO,
                OBSERVACAO
            FROM PRODUTO
            {(string.IsNullOrEmpty(filtroSql) ? "" : "WHERE " + filtroSql)}
            ORDER BY ID_PRODUTO DESC
            {(limitar20 ? "LIMIT 20" : "")};
        ";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                dgvEstoque.DataSource = dt;

                // 🔹 SÓ O ESSENCIAL - REMOVE TODOS OS ESTILOS DAQUI
                // Cabeçalhos centralizados
                foreach (DataGridViewColumn coluna in dgvEstoque.Columns)
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Configuração das colunas
                dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dgvEstoque.Columns.Contains("OBSERVACAO"))
                    dgvEstoque.Columns["OBSERVACAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Larguras das colunas
                dgvEstoque.Columns["ID_PRODUTO"].Width = 85;
                dgvEstoque.Columns["NOME"].Width = 150;
                dgvEstoque.Columns["MARCA"].Width = 95;
                dgvEstoque.Columns["PRECO"].Width = 70;
                dgvEstoque.Columns["QTD_ESTOQUE"].Width = 100;
                dgvEstoque.Columns["QTD_AVISO"].Width = 80;

                // Alinhamento do conteúdo
                dgvEstoque.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["PRECO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvEstoque.Columns["QTD_ESTOQUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["QTD_AVISO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvEstoque.Columns["MARCA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvEstoque.Columns["OBSERVACAO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Formatação de preço
                if (dgvEstoque.Columns.Contains("PRECO"))
                {
                    dgvEstoque.Columns["PRECO"].DefaultCellStyle.Format = "C2";
                }

                // Remove seleção automática
                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregarEstoqueInicial()
        {
            CarregarEstoque(limitar20: true);
        }

        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            //  VALIDAÇÃO MELHORADA
            if (cbPesquisaCampo.SelectedItem == null || cbCondicao.SelectedItem == null)
            {
                MessageBox.Show("Selecione o campo e a condição de pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campo = cbPesquisaCampo.SelectedItem.ToString();
            string condicao = cbCondicao.SelectedItem.ToString();
            string valor = tbPesquisa.Text.Trim().ToUpper();

            //  VALIDAÇÃO DE CAMPO VAZIO
            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Digite um termo para pesquisar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtroSql = "";
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Inicia com":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor + "%") };
                    break;
                case "Contendo":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", "%" + valor + "%") };
                    break;
                case "Diferente de":
                    filtroSql = $"UPPER({campo}) <> @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    break;
                default:
                    MessageBox.Show("Condição de pesquisa inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            CarregarEstoque(filtroSql, parametros, limitar20: false);
        }

        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            tbPesquisa.Text = "";
            cbPesquisaCampo.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;

            CarregarEstoque(limitar20: true);

            //  Limpa seleção ao clicar em limpar
            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;
        }

        public (int Id, string Nome, int Quantidade)? ObterProdutoSelecionado()
        {
            if (dgvEstoque.CurrentRow == null)
                return null;

            try
            {
                int id = Convert.ToInt32(dgvEstoque.CurrentRow.Cells["ID_PRODUTO"].Value);
                string nome = dgvEstoque.CurrentRow.Cells["NOME"].Value?.ToString() ?? "";
                int quantidade = Convert.ToInt32(dgvEstoque.CurrentRow.Cells["QTD_ESTOQUE"].Value);
                return (id, nome, quantidade);
            }
            catch
            {
                return null;
            }
        }

        public DataGridViewRow? ObterLinhaSelecionada()
        {
            return dgvEstoque.CurrentRow;
        }

        //  MÉTODO PARA REMOVER COM VERIFICAÇÃO DE ESTOQUE
        public bool RemoverQuantidadeEstoque(int idProduto, int quantidadeRemover)
        {
            try
            {
                // Primeiro verifica o estoque atual
                string sqlVerificar = "SELECT QTD_ESTOQUE FROM PRODUTO WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametrosVerificar = {
                    new SQLiteParameter("@id", idProduto)
                };

                object resultado = DatabaseHelper.ExecuteScalar(sqlVerificar, parametrosVerificar);

                if (resultado == null)
                {
                    MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int estoqueAtual = Convert.ToInt32(resultado);

                //  VERIFICA SE A QUANTIDADE É MAIOR QUE O ESTOQUE
                if (quantidadeRemover > estoqueAtual)
                {
                    MessageBox.Show($"Quantidade insuficiente em estoque!\nEstoque atual: {estoqueAtual}\nTentativa de remover: {quantidadeRemover}",
                                  "Erro de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Se chegou aqui, pode remover
                string sqlRemover = "UPDATE PRODUTO SET QTD_ESTOQUE = QTD_ESTOQUE - @qtd WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametrosRemover = {
                    new SQLiteParameter("@qtd", quantidadeRemover),
                    new SQLiteParameter("@id", idProduto)
                };

                int linhasAfetadas = DatabaseHelper.ExecuteNonQuery(sqlRemover, parametrosRemover);

                if (linhasAfetadas > 0)
                {
                    //  ATUALIZA AUTOMATICAMENTE
                    AtualizarTabela();

                    MessageBox.Show("Quantidade removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Erro ao remover quantidade do estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover quantidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}