using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormRelatorios : Form
    {
        private FormVendas vendas;
        private FormEstoque estoque;
        private int _currentPrintRow = 0;

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

            // Configura comboboxes
            ConfigurarComboBoxes();

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
                        }
                        catch (Exception ex) { Console.WriteLine($"Erro ao aplicar região arredondada: {ex.Message}"); }
                    }));
                }
                catch (Exception ex) { Console.WriteLine($"Erro no Load: {ex.Message}"); }
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
                catch (Exception ex) { Console.WriteLine($"Erro no Resize: {ex.Message}"); }
            };
        }

        private void ConfigurarComboBoxes()
        {
            // Configura tipos de relatório
            cbTipoRelatorio.Items.Clear();
            cbTipoRelatorio.Items.AddRange(new object[] {
                "Vendas do período",
                "Produtos mais vendidos",
                "Vendas por funcionário",
                "Produtos com baixo estoque",
                "Formas de pagamento",
                "Vendas por categoria",
                "Movimentação de estoque"
            });

            // Configura períodos com anos dinâmicos
            ConfigurarComboBoxPeriodo();
        }

        private void ConfigurarComboBoxPeriodo()
        {
            cbPeriodo.Items.Clear();

            int anoAtual = DateTime.Today.Year;

            // Itens conforme seu pedido
            cbPeriodo.Items.AddRange(new object[]
            {
                "Hoje",
                "Esta Semana",
                "Este mês",
                "Este Bimestre",
                "Este Semestre",
                "Semestre Passado",
                "Este Ano",
                "Últimos anos"
            });

            // Adiciona alguns anos dinâmicos (últimos 3 anos completos/exemplo)
            for (int i = 0; i < 3; i++)
            {
                int ano = anoAtual - i;
                cbPeriodo.Items.Add($"Ano de {ano}");
            }
        }

        private void AplicarTemaEscuroDataGridView()
        {
            dgvRelatorios.SuspendLayout();

            // Cores
            Color background = Color.FromArgb(32, 33, 39);
            Color backgroundAlt = Color.FromArgb(38, 39, 46);
            Color headerBack = Color.FromArgb(40, 41, 52);
            Color gridColor = Color.FromArgb(50, 52, 67);
            Color selectionBack = Color.FromArgb(50, 90, 130);
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
                Alignment = DataGridViewContentAlignment.MiddleCenter,
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

                // Aplica o tema escuro e formatação
                AplicarTemaEscuroDataGridView();
                AjustarColunasRelatorio(tipoRelatorio);

                // Força o alinhamento centralizado em todas as células
                foreach (DataGridViewColumn col in dgvRelatorios.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                case "formas de pagamento":
                    return ObterRelatorioFormasPagamento(dateRange);
                case "vendas por funcionário":
                    return ObterRelatorioVendasPorFuncionario(dateRange);
                case "produtos com baixo estoque":
                    return ObterRelatorioProdutosBaixoEstoque();
                case "movimentação de estoque":
                    return ObterRelatorioMovimentacaoEstoque(dateRange);
                default:
                    return new DataTable();
            }
        }

        /// <summary>
        /// Constrói a cláusula WHERE para comparar a parte de data (DATA_HORA).
        /// dateColumnExpr deve ser algo como "v.DATA_HORA", "m.DATA_HORA" ou "DATA_HORA".
        /// Se dateColumnExpr for nulo ou vazio, usa apenas "DATA_HORA".
        /// </summary>
        private string BuildDateWhereClause((DateTime start, DateTime end)? dateRange, string dateColumnExpr = "DATA_HORA")
        {
            if (!dateRange.HasValue) return "";

            try
            {
                // Usamos o formato ISO yyyy-MM-dd para comparação correta
                string startDateIso = dateRange.Value.start.ToString("yyyy-MM-dd");
                string endDateIso = dateRange.Value.end.ToString("yyyy-MM-dd");

                if (string.IsNullOrWhiteSpace(dateColumnExpr))
                    dateColumnExpr = "DATA_HORA";

                // Se o usuário passou apenas o alias (ex.: "v") convertemos para "v.DATA_HORA"
                if (!dateColumnExpr.Contains(".") && !dateColumnExpr.Equals("DATA_HORA", StringComparison.OrdinalIgnoreCase))
                    dateColumnExpr = dateColumnExpr + ".DATA_HORA";

                // Garantir que não venha com espaços
                dateColumnExpr = dateColumnExpr.Trim();

                // Monta a cláusula usando o expression correto para a coluna de data
                string where = $@"
                WHERE (
                    CASE
                        WHEN substr(substr({dateColumnExpr},1,10),5,1) = '-' THEN substr({dateColumnExpr},1,10)
                        WHEN substr(substr({dateColumnExpr},1,10),3,1) = '-' THEN
                            substr(substr({dateColumnExpr},1,10),7,4) || '-' || substr(substr({dateColumnExpr},1,10),4,2) || '-' || substr(substr({dateColumnExpr},1,10),1,2)
                        ELSE substr({dateColumnExpr},1,10)
                    END
                ) BETWEEN '{startDateIso}' AND '{endDateIso}'";

                return where;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao construir cláusula WHERE: {ex.Message}");
                return "";
            }
        }



        private DataTable ObterRelatorioVendasPeriodo((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = BuildDateWhereClause(dateRange, "DATA_HORA");


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
                string whereClause = BuildDateWhereClause(dateRange, "v");

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
                    {whereClause}
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
                string whereClause = BuildDateWhereClause(dateRange, "v");

                string sql = $@"
                    SELECT 
                        p.MARCA as 'Categoria',
                        COUNT(DISTINCT v.ID_VENDA) as 'Total de Vendas',
                        SUM(iv.QUANTIDADE) as 'Quantidade Vendida',
                        SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) as 'Faturamento Total'
                    FROM ITEM_VENDA iv
                    JOIN VENDA v ON iv.ID_VENDA = v.ID_VENDA
                    JOIN PRODUTO p ON iv.ID_PRODUTO = p.ID_PRODUTO
                    {whereClause}
                    GROUP BY p.MARCA
                    HAVING SUM(iv.PRECO_UNITARIO * iv.QUANTIDADE) > 0
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

        private DataTable ObterRelatorioFormasPagamento((DateTime start, DateTime end)? dateRange)
        {
            try
            {
                string whereClause = BuildDateWhereClause(dateRange, "v");

                string sql = $@"
                    SELECT 
                        p.FORMA as 'Forma de Pagamento',
                        COUNT(*) as 'Quantidade',
                        SUM(p.VALOR) as 'Valor Total',
                        ROUND(
                            (SUM(p.VALOR) * 100.0) / 
                            NULLIF((
                                SELECT SUM(VALOR_TOTAL) 
                                FROM VENDA 
                                {whereClause.Replace("WHERE", "WHERE")}
                            ), 0), 
                        2) as 'Participação %'
                    FROM PAGAMENTO p
                    JOIN VENDA v ON p.ID_VENDA = v.ID_VENDA
                    {whereClause}
                    AND p.ESTADO = 'PAGO'
                    GROUP BY p.FORMA
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
                string whereClause = BuildDateWhereClause(dateRange, "VENDA");

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
                string whereClause = BuildDateWhereClause(dateRange, "m");

                string sql = $@"
                    SELECT 
                        CASE 
                            WHEN p.NOME IS NULL THEN 'PRODUTO EXCLUÍDO (ID: ' || m.ID_PRODUTO || ')'
                            ELSE p.NOME 
                        END as 'Produto',
                        CASE 
                            WHEN p.MARCA IS NULL THEN 'N/A'
                            ELSE p.MARCA 
                        END as 'Marca',
                        m.TIPO_MOVIMENTACAO as 'Tipo',
                        m.QUANTIDADE as 'Quantidade',
                        m.DATA_HORA as 'Data/Hora',
                        m.NOME_FUNCIONARIO as 'Responsável'
                    FROM MOVIMENTACAO_ESTOQUE m
                    LEFT JOIN PRODUTO p ON m.ID_PRODUTO = p.ID_PRODUTO
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

        private void AjustarColunasRelatorio(string tipoRelatorio)
        {
            foreach (DataGridViewColumn col in dgvRelatorios.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Formatar colunas monetárias
                if (col.HeaderText.Contains("Desconto") ||
                    col.HeaderText.Contains("Maior Venda") ||
                    col.HeaderText.Contains("Valor Total") ||
                    col.HeaderText.Contains("Preço") ||
                    col.HeaderText.Contains("Faturamento") ||
                    col.HeaderText.Contains("Ticket") ||
                    col.HeaderText.ToLower().Contains("valor"))
                {
                    col.DefaultCellStyle.Format = "C2";
                }

                if (col.HeaderText.Contains("%"))
                {
                    col.DefaultCellStyle.Format = "0.00\\%";
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
                    CalcularMetricasVendas(dt, periodo);
                    break;
                case "produtos mais vendidos":
                case "vendas por categoria":
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

            DataColumn valorColumn = dt.Columns.Cast<DataColumn>()
                .FirstOrDefault(col => col.ColumnName.ToLower().Contains("valor") ||
                                      col.ColumnName.ToLower().Contains("total"));

            string colunaValor = valorColumn?.ColumnName ?? "Valor Total";

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    var obj = row[colunaValor];
                    if (obj != DBNull.Value && obj != null)
                    {
                        if (decimal.TryParse(obj.ToString(), NumberStyles.Currency | NumberStyles.Number, CultureInfo.CurrentCulture, out decimal parsed))
                        {
                            faturamento += parsed;
                        }
                        else if (decimal.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out parsed))
                        {
                            faturamento += parsed;
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine($"Erro ao calcular métricas de vendas: {ex.Message}"); }
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
                    // Processar faturamento
                    var objFaturamento = row["Faturamento Total"];
                    if (objFaturamento != DBNull.Value && objFaturamento != null)
                    {
                        if (decimal.TryParse(objFaturamento.ToString(), NumberStyles.Currency | NumberStyles.Number, CultureInfo.CurrentCulture, out decimal faturamento))
                        {
                            faturamentoTotal += faturamento;
                        }
                        else if (decimal.TryParse(objFaturamento.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out faturamento))
                        {
                            faturamentoTotal += faturamento;
                        }
                    }

                    // Processar quantidade
                    if (row["Quantidade Vendida"] != DBNull.Value)
                    {
                        int qtd = Convert.ToInt32(row["Quantidade Vendida"]);
                        quantidadeTotal += qtd;

                        if (qtd > maxVendido)
                        {
                            maxVendido = qtd;
                            produtoMaisVendido = row["Produto"].ToString();
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine($"Erro ao calcular métricas de produtos: {ex.Message}"); }
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
            int maxQuantidade = 0;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    // Processar valor total
                    var objValor = row["Valor Total"];
                    if (objValor != DBNull.Value && objValor != null)
                    {
                        if (decimal.TryParse(objValor.ToString(), NumberStyles.Currency | NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor))
                        {
                            valorTotal += valor;
                        }
                        else if (decimal.TryParse(objValor.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out valor))
                        {
                            valorTotal += valor;
                        }
                    }

                    // Encontrar forma mais usada pela quantidade
                    if (row["Quantidade"] != DBNull.Value)
                    {
                        int quantidade = Convert.ToInt32(row["Quantidade"]);
                        if (quantidade > maxQuantidade)
                        {
                            maxQuantidade = quantidade;
                            formaMaisUsada = row["Forma de Pagamento"].ToString();
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine($"Erro ao calcular métricas de pagamentos: {ex.Message}"); }
            }

            lblTitulo1.Text = "Valor Total";
            lblValor1.Text = valorTotal.ToString("C");

            lblTitulo2.Text = "Forma Mais Usada";
            lblValor2.Text = formaMaisUsada;

            lblTitulo3.Text = "Total de Pagamentos";
            lblValor3.Text = dt.Rows.Count.ToString();

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
                    // Processar faturamento
                    var objFaturamento = row["Faturamento Total"];
                    if (objFaturamento != DBNull.Value && objFaturamento != null)
                    {
                        if (decimal.TryParse(objFaturamento.ToString(), NumberStyles.Currency | NumberStyles.Number, CultureInfo.CurrentCulture, out decimal faturamento))
                        {
                            faturamentoTotal += faturamento;

                            if (faturamento > maxFaturamento)
                            {
                                maxFaturamento = faturamento;
                                funcionarioDestaque = row["Funcionário"].ToString();
                            }
                        }
                        else if (decimal.TryParse(objFaturamento.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out faturamento))
                        {
                            faturamentoTotal += faturamento;

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
                catch (Exception ex) { Console.WriteLine($"Erro ao calcular métricas de funcionários: {ex.Message}"); }
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
                catch (Exception ex) { Console.WriteLine($"Erro ao calcular métricas de estoque: {ex.Message}"); }
            }

            lblTitulo1.Text = "Produtos em Alerta";
            lblValor1.Text = produtosAlerta.ToString();

            lblTitulo2.Text = "Produtos Esgotados";
            lblValor2.Text = produtosEsgotados.ToString();

            lblTitulo3.Text = "Situação";
            lblValor3.Text = produtosEsgotados > 0 ? "CRÍTICA" : "ATENÇÃO";

            lblTitulo4.Text = "Período";
            lblValor4.Text = periodo;

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
                catch (Exception ex) { Console.WriteLine($"Erro ao calcular métricas de movimentação: {ex.Message}"); }
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

        private (DateTime start, DateTime end)? GetDateRangeFromPeriodo(string periodo)
        {
            if (string.IsNullOrEmpty(periodo)) return null;

            var p = periodo.Trim().ToLowerInvariant();
            // normalizações simples
            p = p.Replace('á', 'a').Replace('é', 'e').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u').Replace('ç', 'c');

            DateTime today = DateTime.Today;
            int anoAtual = today.Year;

            // "Ano de YYYY"
            if (p.StartsWith("ano de "))
            {
                string anoStr = p.Replace("ano de ", "").Trim();
                if (int.TryParse(anoStr, out int anoEspecifico) && anoEspecifico >= 1900 && anoEspecifico <= 2100)
                {
                    DateTime start = new DateTime(anoEspecifico, 1, 1);
                    DateTime end = new DateTime(anoEspecifico, 12, 31, 23, 59, 59);
                    return (start, end);
                }
            }

            if (p == "este ano")
            {
                DateTime start = new DateTime(anoAtual, 1, 1);
                DateTime end = today.AddDays(1).AddSeconds(-1);
                return (start, end);
            }

            if (p == "hoje")
                return (today, today.AddDays(1).AddSeconds(-1));

            if (p == "ontem")
            {
                DateTime start = today.AddDays(-1);
                return (start, start.AddDays(1).AddSeconds(-1));
            }

            if (p == "esta semana")
            {
                // Considera semana começando na segunda-feira
                int diff = (7 + (int)today.DayOfWeek - (int)DayOfWeek.Monday) % 7;
                DateTime start = today.AddDays(-diff).Date;
                DateTime end = today.AddDays(1).AddSeconds(-1);
                return (start, end);
            }

            if (p == "este mes" || p == "este mês")
            {
                DateTime start = new DateTime(anoAtual, today.Month, 1);
                DateTime end = start.AddMonths(1).AddSeconds(-1);
                return (start, end);
            }

            if (p == "este bimestre")
            {
                // Bimestres: Jan-Feb, Mar-Apr, May-Jun, Jul-Aug, Sep-Oct, Nov-Dec (2 meses)
                int bimestreIndex = ((today.Month - 1) / 2); // 0..5
                DateTime start = new DateTime(anoAtual, bimestreIndex * 2 + 1, 1);
                DateTime end = start.AddMonths(2).AddSeconds(-1);
                return (start, end);
            }

            if (p == "este semestre")
            {
                int semestre = today.Month <= 6 ? 1 : 2;
                DateTime start = new DateTime(anoAtual, (semestre - 1) * 6 + 1, 1);
                DateTime end = start.AddMonths(6).AddSeconds(-1);
                return (start, end);
            }

            if (p == "semestre passado")
            {
                // se estamos no 1º semestre, semestre passado = 2º semestre do ano anterior
                bool estamosPrimeiroSemestre = today.Month <= 6;
                int ano = estamosPrimeiroSemestre ? anoAtual - 1 : anoAtual;
                int semestre = estamosPrimeiroSemestre ? 2 : 1;
                DateTime start = new DateTime(ano, (semestre - 1) * 6 + 1, 1);
                DateTime end = start.AddMonths(6).AddSeconds(-1);
                return (start, end);
            }

            if (p == "ultimos anos" || p == "ultimos anos" /* sem acento */)
            {
                // Interpretação: pegar o ano anterior completo até hoje.
                // Se quiser outro comportamento (ex.: últimos N anos), me fala.
                int anoAnterior = anoAtual - 1;
                DateTime start = new DateTime(anoAnterior, 1, 1);
                DateTime end = today.AddDays(1).AddSeconds(-1);
                return (start, end);
            }

            if (p == "ultimos 12 meses" || p == "ultimos 12 meses" || p == "ultimos 12 mes")
            {
                DateTime start = today.AddMonths(-12).AddDays(1); // aproximadamente 12 meses atrás
                return (start, today.AddDays(1).AddSeconds(-1));
            }

            // Se não reconheceu, retorna null para não filtrar por data
            return null;
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
                                        var rawVal = dgvRelatorios.Rows[i].Cells[j].Value;

                                        if (rawVal == null)
                                        {
                                            cell.Value = "";
                                        }
                                        else if (rawVal is decimal d)
                                        {
                                            cell.Value = d;
                                            cell.Style.NumberFormat.Format = "R$ #,##0.00";
                                        }
                                        else if (decimal.TryParse(rawVal.ToString(), NumberStyles.Currency | NumberStyles.Number, CultureInfo.CurrentCulture, out decimal parsed))
                                        {
                                            cell.Value = parsed;
                                            cell.Style.NumberFormat.Format = "R$ #,##0.00";
                                        }
                                        else
                                        {
                                            cell.Value = rawVal.ToString();
                                        }
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    }
                                }
                            }

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
                _currentPrintRow = 0; // Reset para nova impressão
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
            int rowsPerPage;
            float y = e.MarginBounds.Top;
            float left = e.MarginBounds.Left;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font cellFont = new Font("Arial", 9);

            // Título
            e.Graphics.DrawString("RELATÓRIO", titleFont, Brushes.Black, left, y);
            y += titleFont.GetHeight(e.Graphics) + 10;

            // Informações do relatório
            string tipoRelatorio = ObterValorSelecionado(cbTipoRelatorio);
            string periodo = ObterValorSelecionado(cbPeriodo);

            Font infoFont = new Font("Arial", 9);
            e.Graphics.DrawString($"Tipo: {tipoRelatorio}", infoFont, Brushes.Black, left, y);
            y += infoFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString($"Período: {periodo}", infoFont, Brushes.Black, left, y);
            y += infoFont.GetHeight(e.Graphics) + 10;

            // Cabeçalhos
            float x = left;
            int[] colWidths = new int[dgvRelatorios.Columns.Count];

            // Calcular larguras das colunas
            for (int i = 0; i < dgvRelatorios.Columns.Count; i++)
            {
                colWidths[i] = Math.Max(100, (int)e.Graphics.MeasureString(dgvRelatorios.Columns[i].HeaderText, headerFont).Width + 20);
            }

            for (int i = 0; i < dgvRelatorios.Columns.Count; i++)
            {
                e.Graphics.DrawString(dgvRelatorios.Columns[i].HeaderText, headerFont, Brushes.Black, x, y);
                x += colWidths[i];
            }
            y += headerFont.GetHeight(e.Graphics) + 5;

            // Quantas linhas cabem na página?
            rowsPerPage = (int)((e.MarginBounds.Bottom - y) / (cellFont.GetHeight(e.Graphics) + 4));

            int rowsPrinted = 0;
            while (_currentPrintRow < dgvRelatorios.Rows.Count && rowsPrinted < rowsPerPage)
            {
                var row = dgvRelatorios.Rows[_currentPrintRow];
                x = left;
                if (!row.IsNewRow)
                {
                    for (int c = 0; c < dgvRelatorios.Columns.Count; c++)
                    {
                        string text = row.Cells[c].Value?.ToString() ?? "";
                        // Truncar texto muito longo
                        if (text.Length > 30) text = text.Substring(0, 27) + "...";
                        e.Graphics.DrawString(text, cellFont, Brushes.Black, x, y);
                        x += colWidths[c];
                    }
                    y += cellFont.GetHeight(e.Graphics) + 4;
                    rowsPrinted++;
                }
                _currentPrintRow++;
            }

            e.HasMorePages = _currentPrintRow < dgvRelatorios.Rows.Count;
            if (!e.HasMorePages)
            {
                _currentPrintRow = 0; // resetar para próxima impressão
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao testar conexão: {ex.Message}");
                return false;
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
            catch (Exception ex) { Console.WriteLine($"Erro ao aplicar região arredondada: {ex.Message}"); }
        }

        private string ObterValorSelecionado(ComboBox comboBox)
        {
            if (comboBox == null) return "";
            if (comboBox.SelectedItem != null) return comboBox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(comboBox.Text)) return comboBox.Text;
            return comboBox.Items.Count > 0 ? comboBox.Items[0].ToString() : "";
        }

        private string SanitizeFileName(string s)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                s = s.Replace(c, '-');
            return s;
        }

        private string GerarNomeArquivo(string tipoRelatorio, string periodo)
        {
            string dataAtual = DateTime.Now.ToString("dd-MM-yyyy");
            string relatorioFormatado = SanitizeFileName(tipoRelatorio)
                .Replace(" ", "-")
                .ToLower();
            string periodoFormatado = SanitizeFileName(periodo)
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

            lblValor3.ForeColor = Color.White;
            lblValor4.ForeColor = Color.White;
        }
    }
}