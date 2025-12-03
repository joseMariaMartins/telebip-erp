using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.SubSubForms
{
    public partial class FormAddProdutoVendas : FormLoad
    {
        private readonly Dictionary<string, string> campoMap = new Dictionary<string, string>
        {
            { "ID", "ID_PRODUTO" },
            { "Nome", "NOME" },
            { "Marca", "MARCA" },
            { "Preço", "PRECO" },
            { "Qtd do estoque", "QTD_ESTOQUE" },
            { "Qtd de aviso", "QTD_AVISO" },
            { "Observação", "OBSERVACAO" }
        };

        public FormAddProdutoVendas()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            // Torna o form apropriado para uso como diálogo modal
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Adicionar Produto";

            ConfigurarComboboxes();

            // Eventos
            btnPesquisarMini.Click += BtnPesquisar_Click;
            btnLimparMini.Click += BtnLimpar_Click;
            dgvProdutosMini.CellDoubleClick += DgvProdutosMini_CellDoubleClick;

            CarregarProdutosInicial();

            this.Shown += (s, e) =>
            {
                dgvProdutosMini.ClearSelection();
                dgvProdutosMini.CurrentCell = null;
            };
        }

        private void ConfigurarComboboxes()
        {
            // Segurança: garante que comboboxes existem (evita NRE se Designer mudar)
            if (cbPesquisaCampoMini != null)
            {
                cbPesquisaCampoMini.DropDownStyle = ComboBoxStyle.DropDownList;
                cbPesquisaCampoMini.DrawMode = DrawMode.Normal;
                cbPesquisaCampoMini.FlatStyle = FlatStyle.Flat;
                cbPesquisaCampoMini.BackColor = Color.FromArgb(40, 41, 52);
                cbPesquisaCampoMini.ForeColor = Color.White;
                cbPesquisaCampoMini.Items.Clear();
                cbPesquisaCampoMini.Items.AddRange(new object[]
                {
                    "ID",
                    "Nome",
                    "Marca",
                    "Preço",
                    "Qtd do estoque",
                    "Qtd de aviso",
                    "Observação"
                });
                cbPesquisaCampoMini.SelectedIndex = 0;
            }

            if (cbCondicaoMini != null)
            {
                cbCondicaoMini.DropDownStyle = ComboBoxStyle.DropDownList;
                cbCondicaoMini.DrawMode = DrawMode.Normal;
                cbCondicaoMini.FlatStyle = FlatStyle.Flat;
                cbCondicaoMini.BackColor = Color.FromArgb(40, 41, 52);
                cbCondicaoMini.ForeColor = Color.White;
                cbCondicaoMini.Items.Clear();
                // <-- incluí "Idêntico a" aqui (renderizado a partir do código)
                cbCondicaoMini.Items.AddRange(new object[]
                {
                    "Idêntico a",
                    "Inicia com",
                    "Contendo",
                    "Diferente de"
                });
                cbCondicaoMini.SelectedIndex = 0;
            }

            // Se quiser também forçar visibilidade/z-order dos combos dentro de wrappers:
            cbPesquisaCampoMini?.BringToFront();
            cbCondicaoMini?.BringToFront();
        }

        public void CarregarProdutos(string filtroSql = "", SQLiteParameter[]? parametros = null, bool limitar20 = false)
        {
            try
            {
                string whereNotIn = "WHERE ID_PRODUTO NOT IN (SELECT ID_PRODUTO FROM PRODUTOS_TEMPORARIOS)";
                string complemento = string.IsNullOrEmpty(filtroSql) ? "" : " AND " + filtroSql;

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
                    {whereNotIn}
                    {complemento}
                    ORDER BY ID_PRODUTO DESC
                    {(limitar20 ? "LIMIT 20" : "")};
                ";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                dgvProdutosMini.DataSource = dt;

                // Aplica o tema zebrado igual ao dgvEstoque de referência
                AplicarTemaZebradoDataGridView();

                // Ajusta as colunas
                ConfigurarColunasDataGridViewMini();

                dgvProdutosMini.ClearSelection();
                dgvProdutosMini.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Configuração e Estilo do DataGridView (Tema Zebrado)
        private void AplicarTemaZebradoDataGridView()
        {
            dgvProdutosMini.SuspendLayout();

            // Cores idênticas ao tema de referência
            Color background = Color.FromArgb(32, 33, 39);
            Color backgroundAlt = Color.FromArgb(38, 39, 46);
            Color headerBack = Color.FromArgb(40, 41, 52);
            Color gridColor = Color.FromArgb(50, 52, 67);
            Color selectionBack = Color.FromArgb(50, 90, 130);
            Color fore = Color.White;

            // Configurações gerais
            dgvProdutosMini.BackgroundColor = background;
            dgvProdutosMini.BorderStyle = BorderStyle.None;
            dgvProdutosMini.GridColor = gridColor;
            dgvProdutosMini.EnableHeadersVisualStyles = false;

            // Cabeçalho
            var headerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = headerBack,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = fore,
                SelectionBackColor = headerBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.True
            };
            dgvProdutosMini.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvProdutosMini.ColumnHeadersHeight = 40;
            dgvProdutosMini.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProdutosMini.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Linhas (agora centralizadas)
            var cellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = background,
                Font = new Font("Segoe UI", 9F),
                ForeColor = fore,
                SelectionBackColor = selectionBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.False
            };
            var altCellStyle = new DataGridViewCellStyle(cellStyle) { BackColor = backgroundAlt };

            dgvProdutosMini.DefaultCellStyle = cellStyle;
            dgvProdutosMini.RowsDefaultCellStyle = cellStyle;
            dgvProdutosMini.AlternatingRowsDefaultCellStyle = altCellStyle; // Isso cria o efeito zebrado
            dgvProdutosMini.RowTemplate.Height = 35;

            // Garante alinhamento central das colunas e dos cabeçalhos
            foreach (DataGridViewColumn coluna in dgvProdutosMini.Columns)
            {
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvProdutosMini.AllowUserToAddRows = false;
            dgvProdutosMini.AllowUserToDeleteRows = false;
            dgvProdutosMini.AllowUserToResizeRows = false;
            dgvProdutosMini.MultiSelect = false;
            dgvProdutosMini.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutosMini.ReadOnly = true;
            dgvProdutosMini.RowHeadersVisible = false;
            dgvProdutosMini.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvProdutosMini.ResumeLayout();
        }

        private void ConfigurarColunasDataGridViewMini()
        {
            if (dgvProdutosMini.Columns.Count == 0) return;

            // Remove o auto-size das colunas
            dgvProdutosMini.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Configura todas as colunas como fixas, exceto a última
            for (int i = 0; i < dgvProdutosMini.Columns.Count; i++)
            {
                var coluna = dgvProdutosMini.Columns[i];

                // Define propriedades comuns - centralizadas
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Se for a última coluna, configura como fill
                if (i == dgvProdutosMini.Columns.Count - 1)
                {
                    coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    coluna.MinimumWidth = 100;
                }
                else
                {
                    // Colunas fixas
                    coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    coluna.Resizable = DataGridViewTriState.False;
                }
            }

            // Configura cabeçalhos específicos
            ConfigurarCabecalhosColunasMini();
        }

        private void ConfigurarCabecalhosColunasMini()
        {
            // Configura os textos dos cabeçalhos e garante alinhamento central
            if (dgvProdutosMini.Columns.Contains("ID_PRODUTO"))
            {
                var c = dgvProdutosMini.Columns["ID_PRODUTO"];
                c.HeaderText = "ID";
                c.Width = 60;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvProdutosMini.Columns.Contains("NOME"))
            {
                var c = dgvProdutosMini.Columns["NOME"];
                c.HeaderText = "Nome do Produto";
                c.MinimumWidth = 150;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvProdutosMini.Columns.Contains("MARCA"))
            {
                var c = dgvProdutosMini.Columns["MARCA"];
                c.HeaderText = "Marca";
                c.MinimumWidth = 120;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvProdutosMini.Columns.Contains("PRECO"))
            {
                var c = dgvProdutosMini.Columns["PRECO"];
                c.HeaderText = "Preço";
                c.DefaultCellStyle.Format = "C2";
                c.Width = 90;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvProdutosMini.Columns.Contains("QTD_ESTOQUE"))
            {
                var c = dgvProdutosMini.Columns["QTD_ESTOQUE"];
                c.HeaderText = "Estoque Atual";
                c.Width = 100;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvProdutosMini.Columns.Contains("QTD_AVISO"))
            {
                var c = dgvProdutosMini.Columns["QTD_AVISO"];
                c.HeaderText = "Estoque Mínimo";
                c.Width = 110;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvProdutosMini.Columns.Contains("OBSERVACAO"))
            {
                var c = dgvProdutosMini.Columns["OBSERVACAO"];
                c.HeaderText = "Observações";
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        private void CarregarProdutosInicial()
        {
            CarregarProdutos(limitar20: true);
        }

        // tenta encontrar correspondência exata primeiro; retorna true se encontrou e já colocou no grid
        private bool TentarBuscaExata(string campoBanco, string valor)
        {
            try
            {
                string whereNotIn = "WHERE ID_PRODUTO NOT IN (SELECT ID_PRODUTO FROM PRODUTOS_TEMPORARIOS)";

                string sql;
                SQLiteParameter[] parametros;

                // Se o campo for ID_PRODUTO e valor for numérico, busca por igualdade numérica
                if (campoBanco.Equals("ID_PRODUTO", StringComparison.OrdinalIgnoreCase) && int.TryParse(valor, out int idVal))
                {
                    sql = $@"
                        SELECT ID_PRODUTO, NOME, MARCA, PRECO, QTD_ESTOQUE, QTD_AVISO, OBSERVACAO
                        FROM PRODUTO
                        {whereNotIn} AND ID_PRODUTO = @valor
                        ORDER BY ID_PRODUTO DESC;
                    ";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", idVal) };
                }
                else
                {
                    // comparação case-insensitive de igualdade
                    sql = $@"
                        SELECT ID_PRODUTO, NOME, MARCA, PRECO, QTD_ESTOQUE, QTD_AVISO, OBSERVACAO
                        FROM PRODUTO
                        {whereNotIn} AND UPPER({campoBanco}) = UPPER(@valor)
                        ORDER BY ID_PRODUTO DESC;
                    ";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                }

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvProdutosMini.DataSource = dt;

                    // Aplica o tema zebrado novamente após trocar o DataSource
                    AplicarTemaZebradoDataGridView();
                    ConfigurarColunasDataGridViewMini();

                    dgvProdutosMini.ClearSelection();
                    dgvProdutosMini.CurrentCell = null;

                    return true;
                }
            }
            catch
            {
                // falhar silenciosamente para fallback
            }

            return false;
        }

        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            if (cbPesquisaCampoMini.SelectedItem == null || cbCondicaoMini.SelectedItem == null)
            {
                MessageBox.Show("Selecione o campo e a condição de pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campoExibicao = cbPesquisaCampoMini.SelectedItem.ToString()!;
            string campoBanco = campoMap.ContainsKey(campoExibicao) ? campoMap[campoExibicao] : campoExibicao;
            string condicao = cbCondicaoMini.SelectedItem.ToString()!;
            string valorOriginal = tbPesquisaMini.Text.Trim();
            string valor = valorOriginal.ToUpper();

            if (string.IsNullOrEmpty(valorOriginal))
            {
                MessageBox.Show("Digite um termo para pesquisar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se a condição for "Idêntico a", apenas tenta a busca exata e informa se não encontrar
            if (condicao.Equals("Idêntico a", StringComparison.OrdinalIgnoreCase))
            {
                bool achouExato = TentarBuscaExata(campoBanco, valorOriginal);
                if (!achouExato)
                    MessageBox.Show("Nenhum produto encontrado com correspondência exata.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1) tenta busca exata primeiro (==) para os demais casos — se achar, exibe e retorna
            bool achouExatoFallback = TentarBuscaExata(campoBanco, valorOriginal);
            if (achouExatoFallback) return;

            // 2) fallback para comportamentos antigos (LIKE / <>)
            string filtroSql = "";
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Inicia com":
                    filtroSql = $"UPPER({campoBanco}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor + "%") };
                    break;
                case "Contendo":
                    filtroSql = $"UPPER({campoBanco}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", "%" + valor + "%") };
                    break;
                case "Diferente de":
                    // Diferente: usa <> com UPPER para case-insensitive
                    filtroSql = $"UPPER({campoBanco}) <> UPPER(@valor)";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    break;
                default:
                    MessageBox.Show("Condição de pesquisa inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Carrega com o filtro (não limitar)
            CarregarProdutos(filtroSql, parametros, limitar20: false);
        }

        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            tbPesquisaMini.Text = "";
            if (cbPesquisaCampoMini.Items.Count > 0) cbPesquisaCampoMini.SelectedIndex = 0;
            if (cbCondicaoMini.Items.Count > 0) cbCondicaoMini.SelectedIndex = 0;

            CarregarProdutos(limitar20: true);

            dgvProdutosMini.ClearSelection();
            dgvProdutosMini.CurrentCell = null;
        }

        private void DgvProdutosMini_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora cabeçalho
            if (dgvProdutosMini.Rows.Count == 0) return;

            var linha = dgvProdutosMini.Rows[e.RowIndex];
            string nomeProduto = linha.Cells["NOME"].Value?.ToString() ?? "";
            if (!int.TryParse(linha.Cells["ID_PRODUTO"].Value?.ToString(), out int idProduto))
            {
                MessageBox.Show("ID do produto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(nomeProduto))
            {
                // tenta obter o form dono corretamente
                var formVendas = this.Owner as FormAddVendas;
                if (formVendas == null)
                {
                    // caso não tenha Owner (aberto sem owner), tenta procurar na Parent/TopLevelOwner
                    var top = this.Owner ?? this.TopLevelControl;
                    formVendas = top as FormAddVendas;
                }

                if (formVendas != null)
                {
                    formVendas.PreencherProduto(nomeProduto, idProduto);
                    this.Close();
                }
                else
                {
                    // fallback: usa DialogResult para retornar dados (se você quiser)
                    MessageBox.Show("Formulário de vendas não encontrado como Owner.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}