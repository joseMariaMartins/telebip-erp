using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormEstoque : FormLoadForm
    {
        private string _textoPesquisa = "";
        private readonly string _placeholder = "Digite para pesquisar...";

        // Variáveis para carregamento incremental
        private int _paginaAtual = 0;
        private readonly int _limitePorPagina = 30;
        private bool _carregandoMais = false;
        private bool _temMaisDados = true;
        private string _ultimoFiltroSql = "";
        private SQLiteParameter[]? _ultimosParametros = null;
        private int _totalProdutosGeral = 0;

        public FormEstoque()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        #region Configuração Inicial do Formulário
        private void ConfigurarFormulario()
        {
            // Configurações básicas do Form
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Configura eventos
            ConfigurarEventos();

            // Aplica estilos visuais
            AplicarEstilosVisuais();

            // Configurações iniciais
            ConfiguracoesIniciais();

            this.Shown += FormEstoque_Shown;
        }

        private void ConfigurarEventos()
        {
            // Eventos dos botões
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            // Eventos do TextBox (placeholder)
            tbPesquisa.GotFocus += TbPesquisa_GotFocus;
            tbPesquisa.LostFocus += TbPesquisa_LostFocus;
            tbPesquisa.KeyPress += TbPesquisa_KeyPress;
            tbPesquisa.TextChanged += TbPesquisa_TextChanged;

            // Eventos das Comboboxes
            cbPesquisaCampo.SelectedIndexChanged += CbPesquisaCampo_SelectedIndexChanged;
            cbCondicao.SelectedIndexChanged += CbCondicao_SelectedIndexChanged;

            // Eventos de clique nos wrappers e pictureboxes
            ConfigurarEventosClique();

            // Evento de double click
            dgvEstoque.CellDoubleClick += DgvEstoque_CellDoubleClick;

            // Evento de scroll para carregamento incremental
            dgvEstoque.Scroll += DgvEstoque_Scroll;


        }

        private void AplicarEstilosVisuais()
        {
            // Tema da DataGridView
            AplicarTemaEscuroDataGridView();
        }

        private void ConfiguracoesIniciais()
        {
            // Placeholder inicial para TextBox
            tbPesquisa.Text = _placeholder;
            tbPesquisa.ForeColor = Color.FromArgb(160, 160, 160);

            // Configura comboboxes
            ConfigurarComboBoxPesquisaCampo();
            ConfigurarComboBoxCondicao();

            // Carrega dados iniciais
            CarregarEstoqueInicial();
        }

        private void ConfigurarComboBoxPesquisaCampo()
        {
            cbPesquisaCampo.Items.Clear();
            cbPesquisaCampo.Items.AddRange(new object[]
            {
                "ID",
                "Nome",
                "Marca",
                "Preço",
                "Qtd do estoque",
                "Qtd de aviso",
                "Observação"
            });

            // Configura propriedades do NeoFlatComboBox
            cbPesquisaCampo.Placeholder = "Selecione um campo...";
            cbPesquisaCampo.ShowPlaceholder = true;
            cbPesquisaCampo.AutoSelectFirst = true;
        }

        private void ConfigurarComboBoxCondicao()
        {
            cbCondicao.Items.Clear();
            cbCondicao.Items.AddRange(new object[]
            {
                "Idêntico a",
                "Inicia com",
                "Contendo",
                "Diferente de"
            });

            // Configura propriedades do NeoFlatComboBox
            cbCondicao.Placeholder = "Selecione uma condição...";
            cbCondicao.ShowPlaceholder = true;
            cbCondicao.AutoSelectFirst = true;
        }
        #endregion

        #region Eventos de Clique nos Controles
        private void ConfigurarEventosClique()
        {
            // Combobox 1 - Campo (wrapper)
            pnlWrapperCampo.Click += PnlWrapperCampo_Click;
            PictureImage2.Click += PicArrowCampo_Click;

            // Combobox 2 - Condição (wrapper)
            pnlWrapperCondicao.Click += PnlWrapperCondicao_Click;
            pictureBox1.Click += PicArrowCondicao_Click;

            // Textbox - pesquisa (wrapper e ícone)
            pnlWrapperPesquisa.Click += PnlWrapperPesquisa_Click;
            picSearch.Click += PicSearch_Click;
        }

        private void PnlWrapperCampo_Click(object sender, EventArgs e)
        {
            cbPesquisaCampo.Focus();
            cbPesquisaCampo.DroppedDown = true;
        }

        private void PnlWrapperCondicao_Click(object sender, EventArgs e)
        {
            cbCondicao.Focus();
            cbCondicao.DroppedDown = true;
        }

        private void PnlWrapperPesquisa_Click(object sender, EventArgs e)
        {
            tbPesquisa.Focus();
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            tbPesquisa.Focus();
        }
        #endregion

        #region Eventos dos Comboboxes
        private void CbPesquisaCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica quando o campo de pesquisa muda, se necessário
        }

        private void CbCondicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica quando a condição muda, se necessário
        }
        #endregion

        #region Configuração e Estilo da DataGridView
        private void AplicarTemaEscuroDataGridView()
        {
            dgvEstoque.SuspendLayout();

            // Cores
            Color background = Color.FromArgb(32, 33, 39);
            Color backgroundAlt = Color.FromArgb(38, 39, 46);
            Color headerBack = Color.FromArgb(40, 41, 52);
            Color gridColor = Color.FromArgb(50, 52, 67);
            Color selectionBack = Color.FromArgb(50, 90, 130);
            Color fore = Color.White;

            // Configurações gerais
            dgvEstoque.BackgroundColor = background;
            dgvEstoque.BorderStyle = BorderStyle.None;
            dgvEstoque.GridColor = gridColor;
            dgvEstoque.EnableHeadersVisualStyles = false;

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
            dgvEstoque.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvEstoque.ColumnHeadersHeight = 40;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Linhas (agora centralizadas)
            var cellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter, // <-- centraliza o conteúdo das células
                BackColor = background,
                Font = new Font("Segoe UI", 9F),
                ForeColor = fore,
                SelectionBackColor = selectionBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.False
            };
            var altCellStyle = new DataGridViewCellStyle(cellStyle) { BackColor = backgroundAlt };

            dgvEstoque.DefaultCellStyle = cellStyle;
            dgvEstoque.RowsDefaultCellStyle = cellStyle;
            dgvEstoque.AlternatingRowsDefaultCellStyle = altCellStyle;
            dgvEstoque.RowTemplate.Height = 35;

            // Garante alinhamento central das colunas e dos cabeçalhos
            foreach (DataGridViewColumn coluna in dgvEstoque.Columns)
            {
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeRows = false;
            dgvEstoque.MultiSelect = false;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.ReadOnly = true;
            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;
            dgvEstoque.Refresh();
            dgvEstoque.ResumeLayout();
        }

        private void ConfigurarColunasDataGridView()
        {
            if (dgvEstoque.Columns.Count == 0) return;

            // MESMO COMPORTAMENTO DO FORMVENDAS: preenche o grid e centraliza tudo
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn coluna in dgvEstoque.Columns)
            {
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.Resizable = DataGridViewTriState.True;
                coluna.MinimumWidth = 80;
            }

            // Cabeçalhos e formatos específicos
            if (dgvEstoque.Columns.Contains("ID_PRODUTO"))
            {
                var c = dgvEstoque.Columns["ID_PRODUTO"];
                c.HeaderText = "ID";
                c.FillWeight = 10;
            }

            if (dgvEstoque.Columns.Contains("NOME"))
            {
                var c = dgvEstoque.Columns["NOME"];
                c.HeaderText = "Nome do Produto";
                c.FillWeight = 30;
            }

            if (dgvEstoque.Columns.Contains("MARCA"))
            {
                var c = dgvEstoque.Columns["MARCA"];
                c.HeaderText = "Marca";
                c.FillWeight = 20;
            }

            if (dgvEstoque.Columns.Contains("PRECO"))
            {
                var c = dgvEstoque.Columns["PRECO"];
                c.HeaderText = "Preço";
                c.DefaultCellStyle.Format = "C2";
                c.FillWeight = 15;
            }

            if (dgvEstoque.Columns.Contains("QTD_ESTOQUE"))
            {
                var c = dgvEstoque.Columns["QTD_ESTOQUE"];
                c.HeaderText = "Estoque Atual";
                c.FillWeight = 12;
            }

            if (dgvEstoque.Columns.Contains("QTD_AVISO"))
            {
                var c = dgvEstoque.Columns["QTD_AVISO"];
                c.HeaderText = "Estoque Mínimo";
                c.FillWeight = 12;
            }

            if (dgvEstoque.Columns.Contains("OBSERVACAO"))
            {
                var c = dgvEstoque.Columns["OBSERVACAO"];
                c.HeaderText = "Observações";
                c.FillWeight = 25;
            }
        }

        private void ConfigurarCabecalhosColunas()
        {
            // Configura os textos dos cabeçalhos e garante alinhamento central
            if (dgvEstoque.Columns.Contains("ID_PRODUTO"))
            {
                var c = dgvEstoque.Columns["ID_PRODUTO"];
                c.HeaderText = "ID";
                c.Width = 60;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("NOME"))
            {
                var c = dgvEstoque.Columns["NOME"];
                c.HeaderText = "Nome do Produto";
                c.MinimumWidth = 150;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("MARCA"))
            {
                var c = dgvEstoque.Columns["MARCA"];
                c.HeaderText = "Marca";
                c.MinimumWidth = 120;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("PRECO"))
            {
                var c = dgvEstoque.Columns["PRECO"];
                c.HeaderText = "Preço";
                c.DefaultCellStyle.Format = "C2";
                c.Width = 90;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("QTD_ESTOQUE"))
            {
                var c = dgvEstoque.Columns["QTD_ESTOQUE"];
                c.HeaderText = "Estoque Atual";
                c.Width = 100;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("QTD_AVISO"))
            {
                var c = dgvEstoque.Columns["QTD_AVISO"];
                c.HeaderText = "Estoque Mínimo";
                c.Width = 110;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("OBSERVACAO"))
            {
                var c = dgvEstoque.Columns["OBSERVACAO"];
                c.HeaderText = "Observações";
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region Placeholder TextBox
        private void TbPesquisa_GotFocus(object sender, EventArgs e)
        {
            if (tbPesquisa.Text == _placeholder)
            {
                tbPesquisa.Text = "";
                tbPesquisa.ForeColor = Color.White;
            }
        }

        private void TbPesquisa_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPesquisa.Text))
            {
                tbPesquisa.Text = _placeholder;
                tbPesquisa.ForeColor = Color.FromArgb(160, 160, 160);
            }
        }

        private void TbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbPesquisa.Text == _placeholder)
            {
                tbPesquisa.Text = "";
                tbPesquisa.ForeColor = Color.White;
            }
        }

        private void TbPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (tbPesquisa.Text != _placeholder)
            {
                _textoPesquisa = tbPesquisa.Text;
            }
            else
            {
                _textoPesquisa = "";
            }
        }

        private string ObterTextoPesquisa()
        {
            if (!string.IsNullOrEmpty(tbPesquisa.Text) && tbPesquisa.Text != _placeholder)
                return tbPesquisa.Text;
            return _textoPesquisa;
        }
        #endregion

        #region Métodos para Obter Valores dos Comboboxes
        private string? ObterValorSelecionado(Controls.NeoFlatComboBox comboBox)
        {
            if (comboBox.SelectedItem != null)
                return comboBox.SelectedItem.ToString();
            return comboBox.Text;
        }

        private void SelecionarPrimeiroItem(Controls.NeoFlatComboBox comboBox)
        {
            if (comboBox.Items.Count == 0) return;
            comboBox.SelectedIndex = 0;
        }
        #endregion

        #region Operações de Banco de Dados
        public void CarregarEstoque(string filtroSql = "", SQLiteParameter[]? parametros = null, bool carregarMais = false)
        {
            try
            {
                if (!carregarMais)
                {
                    // Reset da paginação quando é uma nova pesquisa
                    _paginaAtual = 0;
                    _carregandoMais = false;
                    _temMaisDados = true;
                    _ultimoFiltroSql = filtroSql;
                    _ultimosParametros = parametros;
                }

                if (!_temMaisDados && carregarMais) return;

                string sql = $@"
                    SELECT ID_PRODUTO, NOME, MARCA, PRECO, QTD_ESTOQUE, QTD_AVISO, OBSERVACAO 
                    FROM PRODUTO 
                    {(string.IsNullOrEmpty(filtroSql) ? "" : "WHERE " + filtroSql)}
                    ORDER BY ID_PRODUTO DESC 
                    LIMIT {_limitePorPagina} OFFSET {_paginaAtual * _limitePorPagina};";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);

                if (_carregandoMais && dgvEstoque.DataSource is DataTable existingDt)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        existingDt.ImportRow(row);
                    }
                    _carregandoMais = false;
                }
                else
                {
                    dgvEstoque.DataSource = dt;
                }

                _temMaisDados = dt.Rows.Count == _limitePorPagina;

                ConfigurarColunasDataGridView();
                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;

                AtualizarTotalItens(filtroSql, parametros);

                if (dt.Rows.Count > 0)
                {
                    _paginaAtual++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarEstoqueInicial()
        {
            // Carrega apenas os primeiros 30 itens
            CarregarEstoque();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar tabela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTotalItens(string filtroSql = "", SQLiteParameter[]? parametros = null)
        {
            try
            {
                if (string.IsNullOrEmpty(filtroSql))
                {
                    string sqlCount = "SELECT COUNT(*) FROM PRODUTO";
                    _totalProdutosGeral = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCount));
                    lbTotal.Text = $"Mostrando: {dgvEstoque.Rows.Count} de {_totalProdutosGeral} produtos";
                }
                else
                {
                    string sqlCount = $"SELECT COUNT(*) FROM PRODUTO WHERE {filtroSql}";
                    int totalComFiltro = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlCount, parametros));

                    if (_totalProdutosGeral == 0)
                    {
                        string sqlGeral = "SELECT COUNT(*) FROM PRODUTO";
                        _totalProdutosGeral = Convert.ToInt32(DatabaseHelper.ExecuteScalar(sqlGeral));
                    }

                    lbTotal.Text = $"Mostrando: {dgvEstoque.Rows.Count} de {totalComFiltro} produtos (Total: {_totalProdutosGeral})";
                }
            }
            catch (Exception ex)
            {
                lbTotal.Text = $"Total de produtos: {dgvEstoque.Rows.Count}";
            }
        }
        #endregion

        #region Eventos dos Botões
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string? campoSelecionado = ObterValorSelecionado(cbPesquisaCampo);
            string? condicao = ObterValorSelecionado(cbCondicao);
            string valor = ObterTextoPesquisa().Trim();

            if (!string.IsNullOrEmpty(valor))
                valor = valor.ToUpper();

            string campo = campoSelecionado switch
            {
                "ID" => "ID_PRODUTO",
                "Nome" => "NOME",
                "Marca" => "MARCA",
                "Preço" => "PRECO",
                "Qtd do estoque" => "QTD_ESTOQUE",
                "Qtd de aviso" => "QTD_AVISO",
                "Observação" => "OBSERVACAO",
                _ => ""
            };

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

            string filtroSql;
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Idêntico a":
                    if (campo == "ID_PRODUTO" || campo == "PRECO" || campo == "QTD_ESTOQUE" || campo == "QTD_AVISO")
                    {
                        if (decimal.TryParse(valor, out decimal numero))
                        {
                            filtroSql = $"{campo} = @valor";
                            parametros = new SQLiteParameter[] { new("@valor", numero) };
                        }
                        else
                        {
                            MessageBox.Show("Para este campo, digite um valor numérico válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        filtroSql = $"UPPER({campo}) = UPPER(@valor)";
                        parametros = new SQLiteParameter[] { new("@valor", valor) };
                    }
                    break;

                case "Inicia com":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new("@valor", valor + "%") };
                    break;

                case "Contendo":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new("@valor", "%" + valor + "%") };
                    break;

                case "Diferente de":
                    filtroSql = $"UPPER({campo}) <> UPPER(@valor)";
                    parametros = new SQLiteParameter[] { new("@valor", valor) };
                    break;

                default:
                    MessageBox.Show("Condição de pesquisa inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            CarregarEstoque(filtroSql, parametros, carregarMais: false);
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            _textoPesquisa = "";
            tbPesquisa.Text = "";
            TbPesquisa_LostFocus(tbPesquisa, EventArgs.Empty);

            this.ActiveControl = null;
            SelecionarPrimeiroItem(cbPesquisaCampo);
            SelecionarPrimeiroItem(cbCondicao);

            // Reseta a paginação
            _paginaAtual = 0;
            _carregandoMais = false;
            _temMaisDados = true;
            _ultimoFiltroSql = "";
            _ultimosParametros = null;

            CarregarEstoque();
            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;
        }
        #endregion

        #region Eventos da Interface
        private void FormEstoque_Shown(object sender, EventArgs e)
        {
            SelecionarPrimeiroItem(cbPesquisaCampo);
            SelecionarPrimeiroItem(cbCondicao);

            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;
            AjustarTamanhoDataGridView();
        }

        private void AjustarTamanhoDataGridView()
        {
            if (dgvEstoque.Parent is Panel)
            {
                dgvEstoque.Dock = DockStyle.Fill;
                dgvEstoque.Margin = new Padding(0);
            }
        }

        private void DgvEstoque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

                using var formView = new FormViewProduto();
                formView.CarregarProduto(id, nome, marca, preco, quantidade, quantidadeAviso, observacao);
                formView.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Métodos de Carregamento Incremental
        private void DgvEstoque_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll &&
                dgvEstoque.FirstDisplayedScrollingRowIndex >= 0 &&
                dgvEstoque.FirstDisplayedScrollingRowIndex + dgvEstoque.DisplayedRowCount(true) >= dgvEstoque.Rows.Count - 5)
            {
                CarregarMaisDados();
            }
        }

        private void CarregarMaisDados()
        {
            if (_carregandoMais || !_temMaisDados) return;

            _carregandoMais = true;
            CarregarEstoque(_ultimoFiltroSql, _ultimosParametros, carregarMais: true);
        }
        #endregion

        #region Métodos Públicos
        public (int Id, string Nome, int Quantidade)? ObterProdutoSelecionado()
        {
            if (dgvEstoque.CurrentRow == null) return null;

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
                SQLiteParameter[] parametrosVerificar = { new("@id", idProduto) };
                object resultado = DatabaseHelper.ExecuteScalar(sqlVerificar, parametrosVerificar);

                if (resultado == null)
                {
                    MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int estoqueAtual = Convert.ToInt32(resultado);

                if (quantidadeRemover > estoqueAtual)
                {
                    MessageBox.Show($"Quantidade insuficiente em estoque!\nEstoque atual: {estoqueAtual}\nTentativa de remover: {quantidadeRemover}", "Erro de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string sqlRemover = "UPDATE PRODUTO SET QTD_ESTOQUE = QTD_ESTOQUE - @qtd WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametrosRemover = { new("@qtd", quantidadeRemover), new("@id", idProduto) };

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
            DataTable dtTemp = new();
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
        #endregion

        #region Eventos das PictureBox (setas)
        private void PicArrowCampo_Click(object sender, EventArgs e)
        {
            cbPesquisaCampo.Focus();
            cbPesquisaCampo.DroppedDown = true;
        }

        private void PicArrowCondicao_Click(object sender, EventArgs e)
        {
            cbCondicao.Focus();
            cbCondicao.DroppedDown = true;
        }
        #endregion

        private void LblTitulo_Click(object sender, EventArgs e)
        {
            // Implementação se necessário
        }
    }
}