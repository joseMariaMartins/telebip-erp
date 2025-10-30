using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormEstoque : Form
    {
        // Variável para armazenar o texto manualmente
        private string textoPesquisa = "";

        public FormEstoque()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // 🔥 CONFIGURA AS COMBOBOX PARA COMEÇAR COM PRIMEIRO ITEM
            ConfigurarComboBoxInicial();

            // Eventos
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            // Eventos para capturar o texto digitado
            tbPesquisa.KeyPress += TbPesquisa_KeyPress;
            tbPesquisa.TextChanged += TbPesquisa_TextChanged;

            // Aplica tema escuro no DataGridView
            AplicarTemaEscuroDataGridView();

            CarregarEstoqueInicial();

            this.Shown += (s, e) =>
            {
                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;
            };
        }

        // 🔥 CONFIGURA AS COMBOBOX PARA PRIMEIRO ITEM
        private void ConfigurarComboBoxInicial()
        {
            try
            {
                // Força a seleção do primeiro item em ambas combobox
                SelecionarPrimeiroItem(cbPesquisaCampo);
                SelecionarPrimeiroItem(cbCondicao);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao configurar combobox: " + ex.Message);
            }
        }

        // 🔥 MÉTODO PARA SELECIONAR PRIMEIRO ITEM
        private void SelecionarPrimeiroItem(CuoreUI.Controls.cuiComboBox comboBox)
        {
            try
            {
                if (comboBox.Items != null && comboBox.Items.Length > 0)
                {
                    // Tenta selecionar o primeiro item por reflection
                    var selectedItemProperty = comboBox.GetType().GetProperty("SelectedItem");
                    if (selectedItemProperty != null)
                    {
                        selectedItemProperty.SetValue(comboBox, comboBox.Items[0]);
                    }

                    // Alternativa: tenta setar o texto
                    var textProperty = comboBox.GetType().GetProperty("Text");
                    if (textProperty != null)
                    {
                        textProperty.SetValue(comboBox, comboBox.Items[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao selecionar primeiro item: " + ex.Message);
            }
        }

        // CAPTURA CADA TECLA PRESSIONADA
        private void TbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Atualiza a variável com o texto atual + nova tecla
            textoPesquisa = tbPesquisa.Text + e.KeyChar;
        }

        // CAPTURA MUDANÇAS NO TEXTO (backspace, delete, etc)
        private void TbPesquisa_TextChanged(object sender, EventArgs e)
        {
            textoPesquisa = tbPesquisa.Text;
        }

        // MÉTODO SIMPLES PARA OBTER O TEXTO
        private string ObterTextoPesquisa()
        {
            // Tenta várias abordagens
            try
            {
                // 1. Tenta pegar diretamente pela propriedade Text
                if (!string.IsNullOrEmpty(tbPesquisa.Text))
                    return tbPesquisa.Text;
            }
            catch { }

            try
            {
                // 2. Tenta por reflection
                var textProperty = tbPesquisa.GetType().GetProperty("Text");
                if (textProperty != null)
                {
                    string texto = textProperty.GetValue(tbPesquisa)?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(texto))
                        return texto;
                }
            }
            catch { }

            // 3. Usa a variável que estamos controlando manualmente
            return textoPesquisa;
        }

        private void AplicarTemaEscuroDataGridView()
        {
            dgvEstoque.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvEstoque.GridColor = Color.FromArgb(50, 52, 67);
            dgvEstoque.BorderStyle = BorderStyle.None;

            dgvEstoque.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvEstoque.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEstoque.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvEstoque.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEstoque.EnableHeadersVisualStyles = false;

            dgvEstoque.DefaultCellStyle.BackColor = Color.FromArgb(40, 41, 52);
            dgvEstoque.DefaultCellStyle.ForeColor = Color.White;
            dgvEstoque.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvEstoque.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 88, 255);
            dgvEstoque.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvEstoque.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 52, 67);
            dgvEstoque.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstoque.ReadOnly = true;
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeRows = false;
        }

        // MÉTODO PARA OBTER VALOR DO COMBOBOX
        private string ObterValorSelecionado(CuoreUI.Controls.cuiComboBox comboBox)
        {
            try
            {
                var selectedItemProperty = comboBox.GetType().GetProperty("SelectedItem");
                if (selectedItemProperty != null)
                {
                    return selectedItemProperty.GetValue(comboBox)?.ToString() ?? "";
                }

                var textProperty = comboBox.GetType().GetProperty("Text");
                if (textProperty != null)
                {
                    return textProperty.GetValue(comboBox)?.ToString() ?? "";
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        private void AtualizarTotalItens()
        {
            lbTotal.Text = $"Total de itens: {dgvEstoque.Rows.Count}";
        }

        public void AtualizarTabela()
        {
            try
            {
                string texto = ObterTextoPesquisa();

                if (!string.IsNullOrEmpty(texto.Trim()))
                {
                    BtnPesquisar_Click(null, EventArgs.Empty);
                }
                else
                {
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

                foreach (DataGridViewColumn coluna in dgvEstoque.Columns)
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dgvEstoque.Columns.Contains("OBSERVACAO"))
                    dgvEstoque.Columns["OBSERVACAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvEstoque.Columns["ID_PRODUTO"].Width = 100;
                dgvEstoque.Columns["NOME"].Width = 150;
                dgvEstoque.Columns["MARCA"].Width = 95;
                dgvEstoque.Columns["PRECO"].Width = 70;
                dgvEstoque.Columns["QTD_ESTOQUE"].Width = 100;
                dgvEstoque.Columns["QTD_AVISO"].Width = 100;

                dgvEstoque.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["PRECO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["QTD_ESTOQUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["QTD_AVISO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvEstoque.Columns["MARCA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["OBSERVACAO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (dgvEstoque.Columns.Contains("PRECO"))
                {
                    dgvEstoque.Columns["PRECO"].DefaultCellStyle.Format = "C2";
                }

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

        private void DgvEstoque_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var linha = dgvEstoque.Rows[e.RowIndex];

            try
            {
                int id = Convert.ToInt32(linha.Cells["ID_PRODUTO"].Value);
                string nome = linha.Cells["NOME"].Value?.ToString() ?? "";
                string marca = linha.Cells["MARCA"].Value?.ToString() ?? "";
                decimal preco = Convert.ToDecimal(linha.Cells["PRECO"].Value);
                int quantidade = Convert.ToInt32(linha.Cells["QTD_ESTOQUE"].Value);
                int quantidadeAviso = Convert.ToInt32(linha.Cells["QTD_AVISO"].Value);
                string observacao = linha.Cells["OBSERVACAO"].Value?.ToString() ?? "";

                using (var formView = new FormViewProduto())
                {
                    formView.CarregarProduto(id, nome, marca, preco, quantidade, quantidadeAviso, observacao);
                    formView.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message,
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            // USA O MÉTODO QUE CAPTURA O TEXTO DE VÁRIAS FORMAS
            string campo = ObterValorSelecionado(cbPesquisaCampo);
            string condicao = ObterValorSelecionado(cbCondicao);
            string valor = ObterTextoPesquisa().Trim().ToUpper();

            // VALIDAÇÃO
            if (string.IsNullOrEmpty(campo) || string.IsNullOrEmpty(condicao))
            {
                MessageBox.Show("Selecione o campo e a condição de pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    filtroSql = $"UPPER({campo}) <> UPPER(@valor)";
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
            // 🔥 LIMPA TUDO: TEXTBOX E VOLTA COMBOBOX PARA PRIMEIRO ITEM
            try
            {
                // Limpa a textbox
                textoPesquisa = "";
                tbPesquisa.Text = "";

                // Volta as combobox para o primeiro item
                SelecionarPrimeiroItem(cbPesquisaCampo);
                SelecionarPrimeiroItem(cbCondicao);
            }
            catch
            {
                // Se der erro, tenta por reflection
                try
                {
                    var textProperty = tbPesquisa.GetType().GetProperty("Text");
                    if (textProperty != null)
                    {
                        textProperty.SetValue(tbPesquisa, "");
                    }
                }
                catch { }
            }

            CarregarEstoque(limitar20: true);
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

        public bool RemoverQuantidadeEstoque(int idProduto, int quantidadeRemover)
        {
            try
            {
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

                if (quantidadeRemover > estoqueAtual)
                {
                    MessageBox.Show($"Quantidade insuficiente em estoque!\nEstoque atual: {estoqueAtual}\nTentativa de remover: {quantidadeRemover}",
                                  "Erro de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string sqlRemover = "UPDATE PRODUTO SET QTD_ESTOQUE = QTD_ESTOQUE - @qtd WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametrosRemover = {
                    new SQLiteParameter("@qtd", quantidadeRemover),
                    new SQLiteParameter("@id", idProduto)
                };

                int linhasAfetadas = DatabaseHelper.ExecuteNonQuery(sqlRemover, parametrosRemover);

                if (linhasAfetadas > 0)
                {
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

        public DataTable ObterEstoqueComoDataTable()
        {
            DataTable dtTemp = new DataTable();
            foreach (DataGridViewColumn col in dgvEstoque.Columns)
                dtTemp.Columns.Add(col.Name);

            foreach (DataGridViewRow row in dgvEstoque.Rows)
            {
                if (row.IsNewRow) continue;
                DataRow dr = dtTemp.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                    dr[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                dtTemp.Rows.Add(dr);
            }

            return dtTemp;
        }
    }
}