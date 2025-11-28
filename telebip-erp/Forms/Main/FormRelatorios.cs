using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormRelatorios : Form
    {
        private FormVendas vendas;
        private FormEstoque estoque;

        public FormRelatorios(FormVendas vendasForm, FormEstoque estoqueForm) : this()
        {
            vendas = vendasForm;
            estoque = estoqueForm;
        }

        public FormRelatorios()
        {
            InitializeComponent();

            btnGerarRelatorio.Click += BtnGerarRelatorio_Click;
            btnExportarExcel.Click += btnExportarExcel_Click;
            btnImprimir.Click += btnImprimir_Click;
            btnLimpar.Click += btnLimpar_Click;

            // Aplica o tema escuro no DataGridView
            AplicarTemaEscuroDataGridView();

            // selecionar valores iniciais (se houver itens)
            if (cbTipoRelatorio != null && cbTipoRelatorio.Items.Count > 0)
                cbTipoRelatorio.SelectedIndex = 0;
            if (cbPeriodo != null && cbPeriodo.Items.Count > 0)
                cbPeriodo.SelectedIndex = 0;

            // aplicar rounded regions após o form ter tamanho real (evita Width = 0)
            this.Load += (s, e) =>
            {
                try
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        try
                        {
                            if (pnlWrapperTipoRelatorio != null)
                                TryApplyRoundedRegion(pnlWrapperTipoRelatorio, 8);

                            if (pnlWrapperPeriodo != null)
                                TryApplyRoundedRegion(pnlWrapperPeriodo, 8);

                            // Testa a estrutura do banco
                            VerificarEstruturaTabelas();
                        }
                        catch { }
                    }));
                }
                catch { }
            };

            this.Resize += (s, e) =>
            {
                try
                {
                    if (pnlWrapperTipoRelatorio != null)
                        TryApplyRoundedRegion(pnlWrapperTipoRelatorio, 8);

                    if (pnlWrapperPeriodo != null)
                        TryApplyRoundedRegion(pnlWrapperPeriodo, 8);
                }
                catch { }
            };
        }

        private void AplicarTemaEscuroDataGridView()
        {
            dgvRelatorios.SuspendLayout();

            // Cores
            Color background = Color.FromArgb(32, 33, 39);       // fundo principal
            Color backgroundAlt = Color.FromArgb(38, 39, 46);    // fundo alternado das linhas
            Color headerBack = Color.FromArgb(40, 41, 52);       // cabeçalho
            Color gridColor = Color.FromArgb(50, 52, 67);        // linhas da grade
            Color selectionBack = Color.FromArgb(50, 90, 130);   // seleção azul escuro
            Color fore = Color.White;

            // Configurações gerais
            dgvRelatorios.BackgroundColor = background;
            dgvRelatorios.BorderStyle = BorderStyle.None;
            dgvRelatorios.GridColor = gridColor;
            dgvRelatorios.EnableHeadersVisualStyles = false;

            // Cabeçalho - CENTRALIZADO
            var headerStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = headerBack,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = fore,
                SelectionBackColor = headerBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.True
            };
            dgvRelatorios.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvRelatorios.ColumnHeadersHeight = 40;
            dgvRelatorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRelatorios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Células - CENTRALIZADAS
            var cellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,  // CENTRALIZADO
                BackColor = background,
                Font = new Font("Segoe UI", 9F),
                ForeColor = fore,
                SelectionBackColor = selectionBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.False
            };

            var altCellStyle = new DataGridViewCellStyle(cellStyle)
            {
                BackColor = backgroundAlt
            };

            dgvRelatorios.DefaultCellStyle = cellStyle;
            dgvRelatorios.RowsDefaultCellStyle = cellStyle;
            dgvRelatorios.AlternatingRowsDefaultCellStyle = altCellStyle;
            dgvRelatorios.RowTemplate.Height = 35;

            // Aplica alinhamento centralizado em todas as colunas
            foreach (DataGridViewColumn coluna in dgvRelatorios.Columns)
            {
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvRelatorios.AllowUserToAddRows = false;
            dgvRelatorios.AllowUserToDeleteRows = false;
            dgvRelatorios.AllowUserToResizeRows = false;
            dgvRelatorios.MultiSelect = false;
            dgvRelatorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRelatorios.ReadOnly = true;
            dgvRelatorios.RowHeadersVisible = false;
            dgvRelatorios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvRelatorios.ClearSelection();
            dgvRelatorios.CurrentCell = null;
            dgvRelatorios.Refresh();

            dgvRelatorios.ResumeLayout();
        }

        private void BtnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dgvRelatorios.DataSource = null;

                if (cbTipoRelatorio == null || cbPeriodo == null)
                {
                    MessageBox.Show("Comboboxes não inicializados.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tipoRelatorio = ObterValorSelecionado(cbTipoRelatorio);
                string periodo = ObterValorSelecionado(cbPeriodo);

                if (string.IsNullOrEmpty(tipoRelatorio) || string.IsNullOrEmpty(periodo))
                {
                    MessageBox.Show("Selecione um tipo de relatório e um período.", "Atenção",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Testa conexão com o banco
                if (!TestarConexaoBanco())
                {
                    MessageBox.Show("Não foi possível conectar ao banco de dados.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = ObterRelatorioEspecifico(tipoRelatorio, periodo);

                if (dt == null)
                {
                    MessageBox.Show("Erro ao carregar dados do relatório.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvRelatorios.DataSource = dt;

                // Aplica o tema escuro e alinhamento centralizado
                AplicarTemaEscuroDataGridView();

                // Ajusta formatação das colunas (mantém centralizado)
                AjustarColunasRelatorio(tipoRelatorio);

                // Força o alinhamento centralizado em todas as células
                foreach (DataGridViewColumn col in dgvRelatorios.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Calcula métricas
                CalcularMetricasRelatorio(dt, tipoRelatorio, periodo);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados dados para o relatório selecionado.",
                                  "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Limpa a tabela
                dgvRelatorios.DataSource = null;
                dgvRelatorios.Rows.Clear();
                dgvRelatorios.Columns.Clear();

                // Limpa as métricas
                LimparMetricas();

                // Reseta os comboboxes para valores padrão
                if (cbTipoRelatorio != null && cbTipoRelatorio.Items.Count > 0)
                    cbTipoRelatorio.SelectedIndex = 0;

                if (cbPeriodo != null && cbPeriodo.Items.Count > 0)
                    cbPeriodo.SelectedIndex = 0;

                // Aplica o tema escuro novamente
                AplicarTemaEscuroDataGridView();

                MessageBox.Show("Relatório limpo com sucesso!", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar relatório: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private DataTable ObterRelatorioEspecifico(string tipoRelatorio, string periodo)
        {
            var dateRange = GetDateRangeFromPeriodo(periodo);

            switch (tipoRelatorio.ToLower())
            {
                case "vendas do período":
                    return ObterRelatorioVendasPeriodo(dateRange);
                case "produtos mais vendidos":
                    return ObterRelatorioProdutosMaisVendidos(dateRange);
                case "vendas por categoria":
                    return ObterRelatorioVendasPorCategoria(dateRange);
                case "lucro bruto por produto":
                    return ObterRelatorioLucroBruto(dateRange);
                case "formas de pagamento":
                    return ObterRelatorioFormasPagamento(dateRange);
                case "vendas por funcionário":
                    return ObterRelatorioVendasPorFuncionario(dateRange);
                case "produtos com baixo estoque":
                    return ObterRelatorioProdutosBaixoEstoque();
                case "movimentação de estoque":
                    return ObterRelatorioMovimentacaoEstoque(dateRange);
                case "tendência de vendas":
                    return ObterRelatorioTendenciaVendas(dateRange);
                default:
                    return new DataTable();
            }
        }

        private string FormatDateForSQL(string dateDDMMYYYY)
        {
            // Converte "DD-MM-YYYY" para "YYYY-MM-DD"
            if (string.IsNullOrEmpty(dateDDMMYYYY) || dateDDMMYYYY.Length < 10)
                return string.Empty;

            try
            {
                string day = dateDDMMYYYY.Substring(0, 2);
                string month = dateDDMMYYYY.Substring(3, 2);
                string year = dateDDMMYYYY.Substring(6, 4);
                return $"{year}-{month}-{day}";
            }
            catch
            {
                return string.Empty;
            }
        }

        private string BuildDateWhereClause((DateTime start, DateTime end)? dateRange)
        {
            if (!dateRange.HasValue) return string.Empty;

            string startDate = FormatDateForSQL(dateRange.Value.start.ToString("dd-MM-yyyy"));
            string endDate = FormatDateForSQL(dateRange.Value.end.ToString("dd-MM-yyyy"));

            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                return string.Empty;

            return $"WHERE DATE(substr(DATA_HORA, 7, 4) || '-' || substr(DATA_HORA, 4, 2) || '-' || substr(DATA_HORA, 1, 2)) " +
                   $"BETWEEN '{startDate}' AND '{endDate}'";
        }

        private DataTable ObterRelatorioVendasPeriodo((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = BuildDateWhereClause(dateRange);

                string sql = $@"
                    SELECT 
                        ID_VENDA as 'ID',
                        NOME_FUNCIONARIO as 'Funcionário',
                        DATA_HORA as 'Data/Hora',
                        VALOR_TOTAL as 'Valor Total',
                        DESCONTO as 'Desconto'
                    FROM VENDA
                    {whereClause}
                    ORDER BY ID_VENDA DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de vendas: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioProdutosMaisVendidos((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = "";
                if (dateRange.HasValue)
                {
                    string dateFilter = BuildDateWhereClause(dateRange).Replace("WHERE", "");
                    whereClause = $"AND {dateFilter}";
                }

                string sql = $@"
                    SELECT 
                        p.NOME as 'Produto',
                        p.MARCA as 'Marca',
                        SUM(iv.QUANTIDADE) as 'Quantidade Vendida',
                        SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) as 'Faturamento Total',
                        ROUND(SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) / SUM(iv.QUANTIDADE), 2) as 'Preço Médio'
                    FROM ITEM_VENDA iv
                    JOIN VENDA v ON iv.ID_VENDA = v.ID_VENDA
                    JOIN PRODUTO p ON iv.ID_PRODUTO = p.ID_PRODUTO
                    WHERE 1=1 {whereClause}
                    GROUP BY p.ID_PRODUTO, p.NOME, p.MARCA
                    ORDER BY SUM(iv.QUANTIDADE) DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de produtos mais vendidos: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioVendasPorCategoria((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = "";
                if (dateRange.HasValue)
                {
                    string dateFilter = BuildDateWhereClause(dateRange).Replace("WHERE", "");
                    whereClause = $"AND {dateFilter}";
                }

                string sql = $@"
                    SELECT 
                        p.MARCA as 'Marca',
                        COUNT(DISTINCT v.ID_VENDA) as 'Total de Vendas',
                        SUM(iv.QUANTIDADE) as 'Quantidade Vendida',
                        SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) as 'Faturamento Total',
                        ROUND(SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) * 100.0 / 
                             (SELECT SUM(VALOR_TOTAL) FROM VENDA v2 WHERE 1=1 {whereClause}), 2) as 'Participação %'
                    FROM ITEM_VENDA iv
                    JOIN VENDA v ON iv.ID_VENDA = v.ID_VENDA
                    JOIN PRODUTO p ON iv.ID_PRODUTO = p.ID_PRODUTO
                    WHERE 1=1 {whereClause}
                    GROUP BY p.MARCA
                    ORDER BY SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de vendas por categoria: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioLucroBruto((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = "";
                if (dateRange.HasValue)
                {
                    string dateFilter = BuildDateWhereClause(dateRange).Replace("WHERE", "");
                    whereClause = $"AND {dateFilter}";
                }

                string sql = $@"
                    SELECT 
                        p.NOME as 'Produto',
                        p.MARCA as 'Marca',
                        SUM(iv.QUANTIDADE) as 'Quantidade Vendida',
                        SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) as 'Faturamento Bruto',
                        ROUND(SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) / SUM(iv.QUANTIDADE), 2) as 'Lucro Unitário Médio'
                    FROM ITEM_VENDA iv
                    JOIN VENDA v ON iv.ID_VENDA = v.ID_VENDA
                    JOIN PRODUTO p ON iv.ID_PRODUTO = p.ID_PRODUTO
                    WHERE 1=1 {whereClause}
                    GROUP BY p.ID_PRODUTO, p.NOME, p.MARCA
                    ORDER BY SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de lucro bruto: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioFormasPagamento((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = "";
                if (dateRange.HasValue)
                {
                    string dateFilter = BuildDateWhereClause(dateRange).Replace("WHERE", "");
                    whereClause = $"AND {dateFilter}";
                }

                string sql = $@"
                    SELECT 
                        p.FORMA as 'Forma de Pagamento',
                        COUNT(*) as 'Quantidade',
                        SUM(p.VALOR) as 'Valor Total',
                        ROUND(SUM(p.VALOR) * 100.0 / (SELECT SUM(VALOR_TOTAL) FROM VENDA v2 WHERE 1=1 {whereClause}), 2) as 'Participação %',
                        p.ESTADO as 'Status'
                    FROM PAGAMENTO p
                    JOIN VENDA v ON p.ID_VENDA = v.ID_VENDA
                    WHERE 1=1 {whereClause}
                    GROUP BY p.FORMA, p.ESTADO
                    ORDER BY SUM(p.VALOR) DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de formas de pagamento: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioVendasPorFuncionario((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = BuildDateWhereClause(dateRange);

                string sql = $@"
                    SELECT 
                        NOME_FUNCIONARIO as 'Funcionário',
                        COUNT(*) as 'Total de Vendas',
                        SUM(VALOR_TOTAL) as 'Faturamento Total',
                        ROUND(AVG(VALOR_TOTAL), 2) as 'Ticket Médio',
                        MAX(VALOR_TOTAL) as 'Maior Venda'
                    FROM VENDA
                    {whereClause}
                    GROUP BY NOME_FUNCIONARIO
                    ORDER BY SUM(VALOR_TOTAL) DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de vendas por funcionário: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioProdutosBaixoEstoque()
        {
            try
            {
                string sql = @"
                    SELECT 
                        ID_PRODUTO as 'ID',
                        NOME as 'Produto',
                        MARCA as 'Marca',
                        PRECO as 'Preço',
                        QTD_ESTOQUE as 'Estoque Atual',
                        QTD_AVISO as 'Estoque Mínimo',
                        (QTD_AVISO - QTD_ESTOQUE) as 'Falta',
                        CASE 
                            WHEN QTD_ESTOQUE = 0 THEN 'ESGOTADO'
                            WHEN QTD_ESTOQUE < QTD_AVISO THEN 'ALERTA'
                            ELSE 'NORMAL'
                        END as 'Status'
                    FROM PRODUTO
                    WHERE QTD_ESTOQUE <= QTD_AVISO
                    ORDER BY (QTD_AVISO - QTD_ESTOQUE) DESC, QTD_ESTOQUE ASC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de produtos com baixo estoque: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioMovimentacaoEstoque((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = BuildDateWhereClause(dateRange);

                string sql = $@"
                    SELECT 
                        p.NOME as 'Produto',
                        p.MARCA as 'Marca',
                        m.TIPO_MOVIMENTACAO as 'Tipo',
                        m.QUANTIDADE as 'Quantidade',
                        m.DATA_HORA as 'Data/Hora',
                        m.NOME_FUNCIONARIO as 'Responsável'
                    FROM MOVIMENTACAO_ESTOQUE m
                    JOIN PRODUTO p ON m.ID_PRODUTO = p.ID_PRODUTO
                    {whereClause}
                    ORDER BY m.DATA_HORA DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de movimentação de estoque: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private DataTable ObterRelatorioTendenciaVendas((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = BuildDateWhereClause(dateRange);

                string sql = $@"
                    SELECT 
                        substr(DATA_HORA, 1, 10) as 'Data',
                        COUNT(*) as 'Quantidade de Vendas',
                        SUM(VALOR_TOTAL) as 'Faturamento Diário',
                        ROUND(AVG(VALOR_TOTAL), 2) as 'Ticket Médio',
                        MAX(VALOR_TOTAL) as 'Maior Venda'
                    FROM VENDA
                    {whereClause}
                    GROUP BY substr(DATA_HORA, 1, 10)
                    ORDER BY substr(DATA_HORA, 1, 10) DESC";

                return DatabaseHelper.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório de tendência de vendas: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private void AjustarColunasRelatorio(string tipoRelatorio)
        {
            foreach (DataGridViewColumn col in dgvRelatorios.Columns)
            {
                // Ajusta largura baseada no tipo de relatório
                switch (tipoRelatorio.ToLower())
                {
                    case "vendas do período":
                        if (col.HeaderText.Contains("Data")) col.Width = 150;
                        else if (col.HeaderText.Contains("Valor")) col.Width = 100;
                        else if (col.HeaderText.Contains("Funcionário")) col.Width = 150;
                        break;
                    case "produtos mais vendidos":
                        if (col.HeaderText.Contains("Produto")) col.Width = 200;
                        else if (col.HeaderText.Contains("Marca")) col.Width = 120;
                        else if (col.HeaderText.Contains("Quantidade")) col.Width = 80;
                        else if (col.HeaderText.Contains("Faturamento")) col.Width = 100;
                        break;
                    case "produtos com baixo estoque":
                        if (col.HeaderText.Contains("Produto")) col.Width = 200;
                        else if (col.HeaderText.Contains("Estoque")) col.Width = 80;
                        else if (col.HeaderText.Contains("Status")) col.Width = 100;
                        break;
                    default:
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        break;
                }

                // Mantém alinhamento centralizado para todas as colunas
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Formata colunas numéricas (mantém centralizado)
                if (col.HeaderText.Contains("Valor") || col.HeaderText.Contains("Preço") || col.HeaderText.Contains("Faturamento") ||
                    col.HeaderText.Contains("Lucro") || col.HeaderText.Contains("Ticket"))
                {
                    col.DefaultCellStyle.Format = "C2";
                    // Mantém centralizado mesmo sendo numérico
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (col.HeaderText.Contains("Quantidade") || col.HeaderText.Contains("ID"))
                {
                    // Mantém centralizado
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (col.HeaderText.Contains("%"))
                {
                    col.DefaultCellStyle.Format = "F2\\%";
                    // Mantém centralizado
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void CalcularMetricasRelatorio(DataTable dt, string tipoRelatorio, string periodo)
        {
            if (dt.Rows.Count == 0)
            {
                LimparMetricas();
                return;
            }

            switch (tipoRelatorio.ToLower())
            {
                case "vendas do período":
                case "tendência de vendas":
                    CalcularMetricasVendas(dt, periodo);
                    break;
                case "produtos mais vendidos":
                case "vendas por categoria":
                case "lucro bruto por produto":
                    CalcularMetricasProdutos(dt, periodo);
                    break;
                case "formas de pagamento":
                    CalcularMetricasPagamentos(dt, periodo);
                    break;
                case "vendas por funcionário":
                    CalcularMetricasFuncionarios(dt, periodo);
                    break;
                case "produtos com baixo estoque":
                    CalcularMetricasEstoque(dt, periodo);
                    break;
                case "movimentação de estoque":
                    CalcularMetricasMovimentacao(dt, periodo);
                    break;
                default:
                    LimparMetricas();
                    break;
            }
        }

        private void CalcularMetricasVendas(DataTable dt, string periodo)
        {
            if (dt.Rows.Count == 0)
            {
                LimparMetricas();
                return;
            }

            decimal faturamento = 0;
            int totalVendas = dt.Rows.Count;

            // Encontra a coluna de valor total de forma mais robusta
            DataColumn valorColumn = dt.Columns.Cast<DataColumn>()
                .FirstOrDefault(col => col.ColumnName.ToLower().Contains("valor") ||
                                      col.ColumnName.ToLower().Contains("total"));

            string colunaValor = valorColumn?.ColumnName ?? "Valor Total";

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    if (row[colunaValor] != DBNull.Value && row[colunaValor] != null)
                    {
                        string valorStr = row[colunaValor].ToString();
                        // Remove formatação de moeda se existir
                        valorStr = valorStr.Replace("R$", "").Replace("$", "").Trim();

                        if (decimal.TryParse(valorStr, out decimal parsed))
                            faturamento += parsed;
                    }
                }
                catch
                {
                    // Continua para a próxima linha em caso de erro
                }
            }

            decimal ticketMedio = totalVendas > 0 ? faturamento / totalVendas : 0;

            lblTitulo1.Text = "Faturamento";
            lblValor1.Text = faturamento.ToString("C");

            lblTitulo2.Text = "Total de Vendas";
            lblValor2.Text = totalVendas.ToString();

            lblTitulo3.Text = "Ticket Médio";
            lblValor3.Text = ticketMedio.ToString("C");

            lblTitulo4.Text = "Período";
            lblValor4.Text = periodo;
        }

        private void CalcularMetricasProdutos(DataTable dt, string periodo)
        {
            if (dt.Rows.Count == 0)
            {
                LimparMetricas();
                return;
            }

            decimal faturamentoTotal = 0;
            int quantidadeTotal = 0;
            string produtoMaisVendido = "";
            int maxVendido = 0;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    // Faturamento
                    if (row["Faturamento Total"] != DBNull.Value)
                    {
                        string valorStr = row["Faturamento Total"].ToString();
                        valorStr = valorStr.Replace("R$", "").Replace("$", "").Trim();
                        if (decimal.TryParse(valorStr, out decimal faturamento))
                            faturamentoTotal += faturamento;
                    }

                    // Quantidade
                    if (row["Quantidade Vendida"] != DBNull.Value)
                    {
                        int qtd = Convert.ToInt32(row["Quantidade Vendida"]);
                        quantidadeTotal += qtd;

                        // Produto mais vendido
                        if (qtd > maxVendido)
                        {
                            maxVendido = qtd;
                            produtoMaisVendido = row["Produto"].ToString();
                        }
                    }
                }
                catch
                {
                    // Continua para a próxima linha
                }
            }

            lblTitulo1.Text = "Faturamento Total";
            lblValor1.Text = faturamentoTotal.ToString("C");

            lblTitulo2.Text = "Quantidade Total";
            lblValor2.Text = quantidadeTotal.ToString();

            lblTitulo3.Text = "Produto Mais Vendido";
            lblValor3.Text = produtoMaisVendido.Length > 15 ?
                produtoMaisVendido.Substring(0, 15) + "..." : produtoMaisVendido;

            lblTitulo4.Text = "Período";
            lblValor4.Text = periodo;
        }

        private void CalcularMetricasPagamentos(DataTable dt, string periodo)
        {
            if (dt.Rows.Count == 0)
            {
                LimparMetricas();
                return;
            }

            decimal valorTotal = 0;
            string formaMaisUsada = "";
            decimal maxValor = 0;
            int pagamentosPendentes = 0;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    if (row["Valor Total"] != DBNull.Value)
                    {
                        string valorStr = row["Valor Total"].ToString();
                        valorStr = valorStr.Replace("R$", "").Replace("$", "").Trim();
                        if (decimal.TryParse(valorStr, out decimal valor))
                        {
                            valorTotal += valor;

                            // Forma mais usada
                            if (valor > maxValor)
                            {
                                maxValor = valor;
                                formaMaisUsada = row["Forma de Pagamento"].ToString();
                            }
                        }
                    }

                    // Pagamentos pendentes
                    if (row["Status"]?.ToString() == "PENDENTE")
                        pagamentosPendentes += Convert.ToInt32(row["Quantidade"]);
                }
                catch
                {
                    // Continua para a próxima linha
                }
            }

            lblTitulo1.Text = "Valor Total";
            lblValor1.Text = valorTotal.ToString("C");

            lblTitulo2.Text = "Forma Mais Usada";
            lblValor2.Text = formaMaisUsada;

            lblTitulo3.Text = "Pendentes";
            lblValor3.Text = pagamentosPendentes.ToString();

            lblTitulo4.Text = "Período";
            lblValor4.Text = periodo;
        }

        private void CalcularMetricasFuncionarios(DataTable dt, string periodo)
        {
            if (dt.Rows.Count == 0)
            {
                LimparMetricas();
                return;
            }

            decimal faturamentoTotal = 0;
            string funcionarioDestaque = "";
            decimal maxFaturamento = 0;
            int totalVendas = 0;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    if (row["Faturamento Total"] != DBNull.Value)
                    {
                        string valorStr = row["Faturamento Total"].ToString();
                        valorStr = valorStr.Replace("R$", "").Replace("$", "").Trim();
                        if (decimal.TryParse(valorStr, out decimal faturamento))
                        {
                            faturamentoTotal += faturamento;

                            // Funcionário destaque
                            if (faturamento > maxFaturamento)
                            {
                                maxFaturamento = faturamento;
                                funcionarioDestaque = row["Funcionário"].ToString();
                            }
                        }
                    }

                    if (row["Total de Vendas"] != DBNull.Value)
                        totalVendas += Convert.ToInt32(row["Total de Vendas"]);
                }
                catch
                {
                    // Continua para a próxima linha
                }
            }

            lblTitulo1.Text = "Faturamento Total";
            lblValor1.Text = faturamentoTotal.ToString("C");

            lblTitulo2.Text = "Total de Vendas";
            lblValor2.Text = totalVendas.ToString();

            lblTitulo3.Text = "Funcionário Destaque";
            lblValor3.Text = funcionarioDestaque.Length > 15 ?
                funcionarioDestaque.Substring(0, 15) + "..." : funcionarioDestaque;

            lblTitulo4.Text = "Período";
            lblValor4.Text = periodo;
        }

        private void CalcularMetricasEstoque(DataTable dt, string periodo)
        {
            if (dt.Rows.Count == 0)
            {
                LimparMetricas();
                return;
            }

            int produtosAlerta = dt.Rows.Count;
            int produtosEsgotados = 0;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    if (row["Status"]?.ToString() == "ESGOTADO")
                        produtosEsgotados++;
                }
                catch
                {
                    // Continua para a próxima linha
                }
            }

            lblTitulo1.Text = "Produtos em Alerta";
            lblValor1.Text = produtosAlerta.ToString();

            lblTitulo2.Text = "Produtos Esgotados";
            lblValor2.Text = produtosEsgotados.ToString();

            lblTitulo3.Text = "Situação";
            lblValor3.Text = produtosEsgotados > 0 ? "CRÍTICA" : "ATENÇÃO";

            lblTitulo4.Text = "Período";
            lblValor4.Text = periodo;

            // Cor vermelha para alertas
            lblValor3.ForeColor = Color.FromArgb(255, 100, 100);
        }

        private void CalcularMetricasMovimentacao(DataTable dt, string periodo)
        {
            if (dt.Rows.Count == 0)
            {
                LimparMetricas();
                return;
            }

            int entradas = 0;
            int saidas = 0;
            string produtoMaisMovimentado = "";
            int maxMovimentacao = 0;

            // Contar movimentações por produto
            var movimentacoes = dt.AsEnumerable()
                .GroupBy(row => row["Produto"].ToString())
                .Select(g => new
                {
                    Produto = g.Key,
                    Total = g.Sum(row => Convert.ToInt32(row["Quantidade"]))
                })
                .OrderByDescending(x => x.Total)
                .FirstOrDefault();

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    string tipo = row["Tipo"].ToString();
                    int quantidade = Convert.ToInt32(row["Quantidade"]);

                    if (tipo == "ENTRADA")
                        entradas += quantidade;
                    else if (tipo == "SAIDA")
                        saidas += quantidade;
                }
                catch
                {
                    // Continua para a próxima linha
                }
            }

            if (movimentacoes != null)
            {
                produtoMaisMovimentado = movimentacoes.Produto;
                maxMovimentacao = movimentacoes.Total;
            }

            lblTitulo1.Text = "Entradas";
            lblValor1.Text = entradas.ToString();

            lblTitulo2.Text = "Saídas";
            lblValor2.Text = saidas.ToString();

            lblTitulo3.Text = "Saldo";
            int saldo = entradas - saidas;
            lblValor3.Text = saldo.ToString();
            lblValor3.ForeColor = saldo >= 0 ? Color.FromArgb(100, 255, 100) : Color.FromArgb(255, 100, 100);

            lblTitulo4.Text = "Período";
            lblValor4.Text = periodo;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvRelatorios.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                string tipoRelatorio = ObterValorSelecionado(cbTipoRelatorio);
                string periodo = ObterValorSelecionado(cbPeriodo);
                string nomeArquivo = GerarNomeArquivo(tipoRelatorio, periodo);

                using (var sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook|*.xlsx",
                    FileName = nomeArquivo
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Relatório");

                            // Cabeçalho do relatório
                            ws.Cell(1, 1).Value = $"Relatório: {tipoRelatorio}";
                            ws.Cell(2, 1).Value = $"Período: {periodo}";
                            ws.Cell(3, 1).Value = $"Data de emissão: {DateTime.Now:dd/MM/yyyy HH:mm}";

                            // Cabeçalhos das colunas
                            int startRow = 5;
                            for (int i = 0; i < dgvRelatorios.Columns.Count; i++)
                            {
                                ws.Cell(startRow, i + 1).Value = dgvRelatorios.Columns[i].HeaderText;
                                ws.Cell(startRow, i + 1).Style.Font.Bold = true;
                                ws.Cell(startRow, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                                ws.Cell(startRow, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }

                            // Dados
                            for (int i = 0; i < dgvRelatorios.Rows.Count; i++)
                            {
                                if (!dgvRelatorios.Rows[i].IsNewRow)
                                {
                                    for (int j = 0; j < dgvRelatorios.Columns.Count; j++)
                                    {
                                        var cell = ws.Cell(i + startRow + 1, j + 1);
                                        cell.Value = dgvRelatorios.Rows[i].Cells[j].Value?.ToString() ?? "";
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                                        // Formata células numéricas
                                        if (dgvRelatorios.Columns[j].HeaderText.Contains("Valor") ||
                                            dgvRelatorios.Columns[j].HeaderText.Contains("Preço"))
                                        {
                                            if (decimal.TryParse(cell.Value.ToString(), out decimal valor))
                                            {
                                                cell.Value = valor;
                                                cell.Style.NumberFormat.Format = "R$ #,##0.00";
                                            }
                                        }
                                    }
                                }
                            }

                            // Ajusta largura das colunas
                            ws.Columns().AdjustToContents();

                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show($"Relatório exportado com sucesso!\nArquivo: {System.IO.Path.GetFileName(sfd.FileName)}",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvRelatorios.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para imprimir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDocument_PrintPage;

                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = printDoc,
                    WindowState = FormWindowState.Maximized
                };
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao imprimir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            e.Graphics.DrawString("RELATÓRIO", titleFont, Brushes.Black, leftMargin, yPos + topMargin);
            yPos += titleFont.GetHeight() + 20;

            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 9);

            float xPos = leftMargin;
            foreach (DataGridViewColumn col in dgvRelatorios.Columns)
            {
                e.Graphics.DrawString(col.HeaderText, headerFont, Brushes.Black, xPos, yPos + topMargin);
                xPos += 100;
            }
            yPos += headerFont.GetHeight() + 10;

            foreach (DataGridViewRow row in dgvRelatorios.Rows)
            {
                if (!row.IsNewRow)
                {
                    xPos = leftMargin;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        e.Graphics.DrawString(cell.Value?.ToString() ?? "", cellFont, Brushes.Black, xPos, yPos + topMargin);
                        xPos += 100;
                    }
                    yPos += cellFont.GetHeight() + 5;
                }
            }
        }

        public void AtualizarDados()
        {
            BtnGerarRelatorio_Click(null, EventArgs.Empty);
        }

        public void LimparDados()
        {
            dgvRelatorios.DataSource = null;
            LimparMetricas();
        }

        private (DateTime start, DateTime end)? GetDateRangeFromPeriodo(string periodo)
        {
            if (string.IsNullOrEmpty(periodo)) return null;

            var p = periodo.Trim().ToLowerInvariant();
            DateTime today = DateTime.Today;

            if (p.Contains("hoje"))
                return (today, today.AddDays(1).AddSeconds(-1));
            if (p.Contains("ontem"))
            {
                DateTime start = today.AddDays(-1);
                return (start, start.AddDays(1).AddSeconds(-1));
            }
            if (p.Contains("últimos 7") || p.Contains("ultimos 7"))
            {
                DateTime start = today.AddDays(-6);
                return (start, today.AddDays(1).AddSeconds(-1));
            }
            if (p.Contains("últimos 30") || p.Contains("ultimos 30"))
            {
                DateTime start = today.AddDays(-29);
                return (start, today.AddDays(1).AddSeconds(-1));
            }
            if (p.Contains("este mês") || p.Contains("este mes"))
            {
                DateTime start = new DateTime(today.Year, today.Month, 1);
                DateTime end = start.AddMonths(1).AddSeconds(-1);
                return (start, end);
            }
            if (p.Contains("mês passado") || p.Contains("mes passado"))
            {
                DateTime start = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
                DateTime end = start.AddMonths(1).AddSeconds(-1);
                return (start, end);
            }
            if (p.Contains("ano atual") || p.Contains("ano"))
            {
                DateTime start = new DateTime(today.Year, 1, 1);
                DateTime end = new DateTime(today.Year, 12, 31).AddHours(23).AddMinutes(59).AddSeconds(59);
                return (start, end);
            }

            return null;
        }

        private bool TestarConexaoBanco()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void VerificarEstruturaTabelas()
        {
            try
            {
                // Verifica se as tabelas existem
                string[] tabelas = { "VENDA", "ITEM_VENDA", "PRODUTO", "PAGAMENTO", "MOVIMENTACAO_ESTOQUE" };

                foreach (string tabela in tabelas)
                {
                    string sql = $"SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='{tabela}'";
                    var result = DatabaseHelper.ExecuteScalar(sql);
                    int existe = Convert.ToInt32(result);

                    if (existe == 0)
                    {
                        MessageBox.Show($"Tabela {tabela} não encontrada no banco!", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar estrutura: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryApplyRoundedRegion(Control c, int radius)
        {
            try
            {
                if (c == null || c.Width <= 0 || c.Height <= 0) return;

                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    gp.AddArc(c.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                    gp.AddArc(c.Width - radius * 2, c.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    gp.AddArc(0, c.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    gp.CloseFigure();
                    c.Region = new Region(gp);
                }
            }
            catch { }
        }

        private string ObterValorSelecionado(ComboBox comboBox)
        {
            if (comboBox == null) return "";
            if (comboBox.SelectedItem != null) return comboBox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(comboBox.Text)) return comboBox.Text;
            return comboBox.Items.Count > 0 ? comboBox.Items[0].ToString() : "";
        }

        private string GerarNomeArquivo(string tipoRelatorio, string periodo)
        {
            string dataAtual = DateTime.Now.ToString("dd-MM-yyyy");
            string relatorioFormatado = tipoRelatorio
                .Replace(" ", "-")
                .ToLower();
            string periodoFormatado = periodo
                .Replace(" ", "-")
                .ToLower();
            return $"relatorio-{relatorioFormatado}-{periodoFormatado}-{dataAtual}";
        }

        private void LimparMetricas()
        {
            lblTitulo1.Text = "Faturamento";
            lblValor1.Text = "R$ 0,00";

            lblTitulo2.Text = "Total de Vendas";
            lblValor2.Text = "0";

            lblTitulo3.Text = "Ticket Médio";
            lblValor3.Text = "R$ 0,00";

            lblTitulo4.Text = "Período";
            lblValor4.Text = "-";

            // Restaura cor padrão
            lblValor3.ForeColor = Color.White;
            lblValor4.ForeColor = Color.White;
        }
    }
}