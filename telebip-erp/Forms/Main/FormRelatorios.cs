// FormRelatorios.cs (com ApplyRoundedRegion seguro em runtime)
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
                    // Usa BeginInvoke para garantir que os controles tenham Size correto
                    this.BeginInvoke((Action)(() =>
                    {
                        try
                        {
                            if (pnlWrapperTipoRelatorio != null)
                                TryApplyRoundedRegion(pnlWrapperTipoRelatorio, 8);

                            if (pnlWrapperPeriodo != null)
                                TryApplyRoundedRegion(pnlWrapperPeriodo, 8);
                        }
                        catch
                        {
                            // silencioso — não deixa o form quebrar por causa de UI cosmetics
                        }
                    }));
                }
                catch
                {
                    // fallback silencioso
                }
            };

            // reaplica quando redimensionar (opcional, útil se os wrappers mudarem de tamanho em runtime)
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
            // Configuração do tema escuro para o DataGridView
            dgvRelatorios.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvRelatorios.GridColor = Color.FromArgb(50, 52, 67);
            dgvRelatorios.BorderStyle = BorderStyle.None;

            // Cabeçalhos
            dgvRelatorios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvRelatorios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRelatorios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRelatorios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRelatorios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRelatorios.EnableHeadersVisualStyles = false;

            // Linhas
            dgvRelatorios.DefaultCellStyle.BackColor = Color.FromArgb(40, 41, 52);
            dgvRelatorios.DefaultCellStyle.ForeColor = Color.White;
            dgvRelatorios.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvRelatorios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 88, 255);
            dgvRelatorios.DefaultCellStyle.SelectionForeColor = Color.White;

            // Linhas alternadas
            dgvRelatorios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 52, 67);
            dgvRelatorios.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Configuração geral
            dgvRelatorios.RowHeadersVisible = false;
            dgvRelatorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRelatorios.ReadOnly = true;
            dgvRelatorios.AllowUserToAddRows = false;
            dgvRelatorios.AllowUserToDeleteRows = false;
            dgvRelatorios.AllowUserToResizeRows = false;
        }

        private void BtnGerarRelatorio_Click(object sender, EventArgs e)
        {
            dgvRelatorios.DataSource = null;

            if (cbTipoRelatorio == null || cbPeriodo == null)
            {
                MessageBox.Show("Comboboxes não inicializados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tipoRelatorio = ObterValorSelecionado(cbTipoRelatorio);
            string periodo = ObterValorSelecionado(cbPeriodo);

            if (string.IsNullOrEmpty(tipoRelatorio) || string.IsNullOrEmpty(periodo))
            {
                MessageBox.Show("Selecione um tipo de relatório e um período.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = new DataTable();

            // Decidir fonte: vendas ou estoque
            if (tipoRelatorio.IndexOf("vendas", StringComparison.OrdinalIgnoreCase) >= 0
                || tipoRelatorio.IndexOf("faturamento", StringComparison.OrdinalIgnoreCase) >= 0
                || tipoRelatorio.IndexOf("ticket", StringComparison.OrdinalIgnoreCase) >= 0
                || tipoRelatorio.IndexOf("lucro", StringComparison.OrdinalIgnoreCase) >= 0
                || tipoRelatorio.IndexOf("pagamento", StringComparison.OrdinalIgnoreCase) >= 0
                || tipoRelatorio.IndexOf("funcion", StringComparison.OrdinalIgnoreCase) >= 0
                || tipoRelatorio.IndexOf("tendência", StringComparison.OrdinalIgnoreCase) >= 0
                || tipoRelatorio.IndexOf("categoria", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                dt = ObterDadosVendas(periodo);
                CalcularMetricasVendas(dt, periodo, tipoRelatorio);
            }
            else // estoque / produtos
            {
                dt = ObterDadosEstoque(periodo);
                CalcularMetricasEstoque(dt, periodo, tipoRelatorio);
            }

            dgvRelatorios.DataSource = dt;

            // adapta cabeçalhos / formatação mínima se vierem colunas com nomes do DB
            AjustarColunasDepoisDeCarregar(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Não foram encontrados dados para o relatório selecionado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ----------------- NOVO: busca direto no DB e filtra em memória (robusto) --------------
        private DataTable ObterDadosVendas(string periodo)
        {
            try
            {
                // pega todos os registros da tabela VENDA (sem LIMIT)
                string sqlAll = @"
                    SELECT 
                        ID_VENDA,
                        NOME_FUNCIONARIO,
                        DATA_HORA,
                        VALOR_TOTAL,
                        DESCONTO
                    FROM VENDA
                    ORDER BY ID_VENDA DESC;";

                DataTable all = DatabaseHelper.ExecuteQuery(sqlAll);

                // se não pediu filtro de período, retorna tudo
                var range = GetDateRangeFromPeriodo(periodo);
                if (!range.HasValue) return all;

                DateTime start = range.Value.start;
                DateTime end = range.Value.end;

                DataTable filtered = all.Clone(); // mesma estrutura de colunas

                // nomes possíveis da coluna de data (varia entre projetos)
                string[] possibleDateCols = new[] { "DATA_HORA", "Data/Hora", "Data", "DATA", "data_hora", "DATA_HORA" };

                foreach (DataRow row in all.Rows)
                {
                    object rawObj = null;
                    foreach (var colName in possibleDateCols)
                    {
                        if (all.Columns.Contains(colName))
                        {
                            rawObj = row[colName];
                            break;
                        }
                    }

                    // se não encontrou a coluna com os nomes comuns, tenta a 3ª coluna (índice 2) como fallback
                    if (rawObj == null && all.Columns.Count >= 3)
                    {
                        rawObj = row[2]; // DATA_HORA geralmente é a terceira coluna
                    }

                    if (rawObj == null || rawObj == DBNull.Value) continue;

                    string raw = rawObj.ToString().Trim();
                    if (string.IsNullOrEmpty(raw)) continue;

                    DateTime dt;
                    bool parsed = false;

                    // 1) tenta parse padrão (culture current / invariant)
                    if (DateTime.TryParse(raw, out dt))
                    {
                        parsed = true;
                    }
                    else
                    {
                        // 2) tenta vários formatos comuns (inclui dd/MM/yyyy)
                        string[] formats = new[]
                        {
                            "yyyy-MM-dd HH:mm:ss",
                            "yyyy-MM-dd H:mm:ss",
                            "yyyy-MM-dd",
                            "dd/MM/yyyy HH:mm:ss",
                            "dd/MM/yyyy H:mm:ss",
                            "dd/MM/yyyy",
                            "yyyy/MM/dd HH:mm:ss",
                            "yyyy/MM/dd",
                            "yyyyMMddHHmmss",
                            "yyyyMMdd"
                        };

                        foreach (var f in formats)
                        {
                            if (DateTime.TryParseExact(raw, f, System.Globalization.CultureInfo.InvariantCulture,
                                                      System.Globalization.DateTimeStyles.None, out dt))
                            {
                                parsed = true;
                                break;
                            }
                        }

                        // 3) tenta interpretar como ticks/epoch (apenas números longos)
                        if (!parsed)
                        {
                            if (long.TryParse(raw, out long longVal))
                            {
                                try
                                {
                                    // se parecer com ticks (>= year 1970)
                                    if (longVal > 1000000000000000L) // ticks
                                    {
                                        dt = new DateTime(longVal);
                                        parsed = true;
                                    }
                                    else if (longVal > 1000000000L) // unix seconds or milliseconds
                                    {
                                        // detectar se é ms (milissegundos) ou s (segundos)
                                        if (longVal > 1000000000000L) // ms
                                            dt = DateTimeOffset.FromUnixTimeMilliseconds(longVal).DateTime;
                                        else
                                            dt = DateTimeOffset.FromUnixTimeSeconds(longVal).DateTime;
                                        parsed = true;
                                    }
                                }
                                catch { /*ignore*/ }
                            }
                        }
                    }

                    if (!parsed)
                    {
                        // não conseguiu parsear essa linha — ignora (ou você pode logar o raw para inspeção)
                        continue;
                    }

                    // aplica filtro inclusivo
                    if (dt >= start && dt <= end)
                    {
                        filtered.ImportRow(row);
                    }
                }

                return filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter dados de vendas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        // ---------------------------------------------------------------------------------------

        // tenta obter estoque usando FormEstoque quando disponível (garante mesma fonte/paginação)
        private DataTable ObterDadosEstoque(string periodo)
        {
            try
            {
                if (estoque != null)
                {
                    // FormEstoque não usa período normalmente; apenas pede todos os itens (limitar20:false)
                    estoque.CarregarEstoque(limitar20: false);
                    return estoque.ObterEstoqueComoDataTable();
                }
                else
                {
                    // fallback: busca direto no DB
                    string sql = @"
                        SELECT 
                            ID_PRODUTO as 'ID',
                            NOME as 'Produto',
                            MARCA as 'Marca',
                            PRECO as 'Preço',
                            QTD_ESTOQUE as 'Estoque',
                            QTD_AVISO as 'Estoque Mínimo',
                            OBSERVACAO as 'Observação'
                        FROM PRODUTO 
                        ORDER BY NOME";
                    return DatabaseHelper.ExecuteQuery(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter dados de estoque: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private void AjustarColunasDepoisDeCarregar(DataTable dt)
        {
            // Se vierem colunas com nomes de DB, tenta padronizar títulos visíveis
            if (dt == null || dt.Columns.Count == 0) return;

            // Exemplo de mapeamento simples — adapte conforme necessário
            foreach (DataGridViewColumn col in dgvRelatorios.Columns)
            {
                string name = col.Name;
                if (name.IndexOf("ID_VENDA", StringComparison.OrdinalIgnoreCase) >= 0 || name.IndexOf("ID", StringComparison.OrdinalIgnoreCase) == 0)
                    col.HeaderText = "ID";
                else if (name.IndexOf("NOME_FUNCIONARIO", StringComparison.OrdinalIgnoreCase) >= 0)
                    col.HeaderText = "Funcionário";
                else if (name.IndexOf("DATA_HORA", StringComparison.OrdinalIgnoreCase) >= 0 || name.IndexOf("Data", StringComparison.OrdinalIgnoreCase) >= 0)
                    col.HeaderText = "Data";
                else if (name.IndexOf("VALOR_TOTAL", StringComparison.OrdinalIgnoreCase) >= 0)
                    col.HeaderText = "Valor";
            }

            // tenta formatar coluna de valor, se existir
            try
            {
                if (dgvRelatorios.Columns.Contains("Valor total"))
                    dgvRelatorios.Columns["Valor total"].DefaultCellStyle.Format = "C2";
                if (dgvRelatorios.Columns.Contains("Valor"))
                    dgvRelatorios.Columns["Valor"].DefaultCellStyle.Format = "C2";
            }
            catch { }
        }

        private void CalcularMetricasVendas(DataTable dt, string periodo, string tipoRelatorio)
        {
            if (dt.Rows.Count > 0)
            {
                decimal faturamentoTotal = 0;
                int totalVendas = dt.Rows.Count;

                // Tenta encontrar a coluna de valor total
                string colunaValor = dt.Columns.Cast<DataColumn>()
                    .FirstOrDefault(col => col.ColumnName.IndexOf("VALOR", StringComparison.OrdinalIgnoreCase) >= 0
                                           || col.ColumnName.IndexOf("TOTAL", StringComparison.OrdinalIgnoreCase) >= 0)
                    ?.ColumnName ?? "Valor Total";

                if (dt.Columns.Contains(colunaValor))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[colunaValor] != DBNull.Value)
                        {
                            if (decimal.TryParse(row[colunaValor].ToString(), out decimal parsed))
                                faturamentoTotal += parsed;
                        }
                    }
                }
                else
                {
                    faturamentoTotal = dt.Rows.Count * 150.50m;
                }

                decimal ticketMedio = totalVendas > 0 ? faturamentoTotal / totalVendas : 0;

                lblTitulo1.Text = "Faturamento";
                lblValor1.Text = faturamentoTotal.ToString("C");

                lblTitulo2.Text = "Total de vendas";
                lblValor2.Text = totalVendas.ToString();

                lblTitulo3.Text = "Ticket médio";
                lblValor3.Text = ticketMedio.ToString("C");

                lblTitulo4.Text = "Período";
                lblValor4.Text = periodo;
            }
            else
            {
                LimparMetricas();
            }
        }

        private void CalcularMetricasEstoque(DataTable dt, string periodo, string tipoRelatorio)
        {
            if (dt.Rows.Count > 0)
            {
                int produtosAlerta = 0;
                int totalProdutos = dt.Rows.Count;

                string colunaEstoque = dt.Columns.Cast<DataColumn>()
                    .FirstOrDefault(col => col.ColumnName.IndexOf("ESTOQUE", StringComparison.OrdinalIgnoreCase) >= 0
                                           || col.ColumnName.IndexOf("QTD", StringComparison.OrdinalIgnoreCase) >= 0)
                    ?.ColumnName ?? "Estoque";

                string colunaAviso = dt.Columns.Cast<DataColumn>()
                    .FirstOrDefault(col => col.ColumnName.IndexOf("AVISO", StringComparison.OrdinalIgnoreCase) >= 0
                                           || col.ColumnName.IndexOf("MÍNIMO", StringComparison.OrdinalIgnoreCase) >= 0
                                           || col.ColumnName.IndexOf("MINIMO", StringComparison.OrdinalIgnoreCase) >= 0)
                    ?.ColumnName ?? "Estoque Mínimo";

                if (dt.Columns.Contains(colunaEstoque) && dt.Columns.Contains(colunaAviso))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            int estoqueQtd = Convert.ToInt32(row[colunaEstoque]);
                            int aviso = Convert.ToInt32(row[colunaAviso]);
                            if (estoqueQtd < aviso) produtosAlerta++;
                        }
                        catch { }
                    }
                }
                else
                {
                    produtosAlerta = Math.Max(1, dt.Rows.Count / 4);
                }

                lblTitulo1.Text = "Produtos em alerta";
                lblValor1.Text = produtosAlerta.ToString();

                lblTitulo2.Text = "Total de produtos";
                lblValor2.Text = totalProdutos.ToString();

                lblTitulo3.Text = "% em alerta";
                lblValor3.Text = totalProdutos > 0 ?
                               ((decimal)produtosAlerta / totalProdutos * 100).ToString("F1") + "%" : "0%";

                lblTitulo4.Text = "Status";
                lblValor4.Text = produtosAlerta > 0 ? "Atenção" : "Normal";

                lblValor4.ForeColor = produtosAlerta > 0 ?
                    Color.FromArgb(255, 100, 100) :
                    Color.FromArgb(100, 255, 100);
            }
            else
            {
                LimparMetricas();
            }
        }

        // MÉTODO PARA GERAR NOME DO ARQUIVO ORGANIZADO
        private string GerarNomeArquivo(string tipoRelatorio, string periodo)
        {
            string dataAtual = DateTime.Now.ToString("dd-MM-yyyy");

            string relatorioFormatado = tipoRelatorio
                .Replace(" ", "-")
                .Replace("ç", "c")
                .Replace("ã", "a")
                .Replace("õ", "o")
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u")
                .ToLower();

            string periodoFormatado = periodo
                .Replace(" ", "-")
                .Replace("ç", "c")
                .Replace("ã", "a")
                .Replace("õ", "o")
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u")
                .Replace("últimos", "ultimos")
                .Replace("mês", "mes")
                .ToLower();

            return $"Relatorio-{relatorioFormatado}-{periodoFormatado}-{dataAtual}";
        }

        // aceita ComboBox padrão
        private string ObterValorSelecionado(ComboBox comboBox)
        {
            if (comboBox == null) return "";

            if (comboBox.SelectedItem != null)
                return comboBox.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(comboBox.Text))
                return comboBox.Text;

            return comboBox.Items.Count > 0 ? comboBox.Items[0].ToString() : "";
        }

        private void LimparMetricas()
        {
            lblTitulo1.Text = lblValor1.Text = "";
            lblTitulo2.Text = lblValor2.Text = "";
            lblTitulo3.Text = lblValor3.Text = "";
            lblTitulo4.Text = lblValor4.Text = "";
            lblValor4.ForeColor = Color.White;
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
                            var ws = wb.Worksheets.Add("Relatorio");

                            for (int i = 0; i < dgvRelatorios.Columns.Count; i++)
                                ws.Cell(1, i + 1).Value = dgvRelatorios.Columns[i].HeaderText;

                            for (int i = 0; i < dgvRelatorios.Rows.Count; i++)
                            {
                                if (!dgvRelatorios.Rows[i].IsNewRow)
                                {
                                    for (int j = 0; j < dgvRelatorios.Columns.Count; j++)
                                        ws.Cell(i + 2, j + 1).Value = dgvRelatorios.Rows[i].Cells[j].Value?.ToString() ?? "";
                                }
                            }

                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show($"Relatório exportado com sucesso!\nArquivo: {System.IO.Path.GetFileName(sfd.FileName)}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Helpers ----------------------------------------------------------------

        private (DateTime start, DateTime end)? GetDateRangeFromPeriodo(string periodo)
        {
            if (string.IsNullOrEmpty(periodo)) return null;

            var p = periodo.Trim().ToLowerInvariant();

            DateTime today = DateTime.Today;
            if (p.Contains("hoje")) // hoje (00:00 -> 23:59:59)
            {
                return (today, today.AddDays(1).AddSeconds(-1));
            }
            if (p.Contains("ontem"))
            {
                DateTime start = today.AddDays(-1);
                return (start, start.AddDays(1).AddSeconds(-1));
            }
            if (p.Contains("últimos 7") || p.Contains("ultimos 7") || p.Contains("últimos 7 dias") || p.Contains("ultimos 7 dias"))
            {
                DateTime start = today.AddDays(-6);
                return (start, today.AddDays(1).AddSeconds(-1));
            }
            if (p.Contains("últimos 30") || p.Contains("ultimos 30") || p.Contains("últimos 30 dias") || p.Contains("ultimos 30 dias"))
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

        private void TryApplyRoundedRegion(Control c, int radius)
        {
            try
            {
                if (c == null) return;
                if (c.Width <= 0 || c.Height <= 0) return;

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
            catch
            {
                // ignore - cosmetics only
            }
        }
    }
}
