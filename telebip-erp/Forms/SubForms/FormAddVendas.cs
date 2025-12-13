using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Xml.Linq;
using telebip_erp.Forms.Auth;
using telebip_erp.Forms.SubSubForms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddVendas : MaterialForm
    {
        // Flags de controle
        private bool _ignorarEventoPrecoProduto = false;
        private bool _ignorarEventoDesconto = false;
        private bool _ignorarEventoCombo = false;
        private bool _preenchendoProdutoAutomaticamente = false;


        // Hora "confiável" obtida no load (NTP ou fallback)
        private DateTime _trustedNow = default;
        private bool _trustedNowIsNtp = false;

        public Action? VendaConfirmadaCallback { get; set; }
        public bool ModoConsulta { get; set; } = false;
        public int? VendaID { get; set; } = null;

        public FormAddVendas()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();
            InicializarComponentes();

            // Combos: popular primeiro, depois vincular eventos
            PopularCombosPagamento();
            ConfigurarVinculoCombos();

            // --- chama configuração dos monetários (preço e desconto)
            ConfigurarMonetarios();

            // Configurar DataGridView
            ConfigurarDataGridViewProdutos();

        }

        #region Inicialização

        private void InicializarComponentes()
        {
            // Vincula handlers dos novos botões
            btnAdicionarItem.Click += BtnAdicaoProduto_Click;
            btnRemoverItem.Click += BtnTirarProduto_Click;
            btnMaisInformacao.Click += BtnMaisInformacao_Click;

            // Botões principais
            btnAdicionarVendas.Click += btnAdicionarVendas_Click_1;
            btnCancelarVendas.Click += btnCancelarVendas_Click_1;

            // Combos: popular primeiro, depois vincular eventos
            PopularCombosPagamento();
            ConfigurarVinculoCombos();

            // Handlers de teclado para busca rápida
            tbNomeProduto.KeyDown += tbNomeProduto_KeyDown;

            // Configurar DataGridView
            ConfigurarDataGridViewProdutos();

            // Load do form
            this.Load += FormAddVendas_Load_1;

            cbMetodoPesquisa.SelectedIndex = 0;

            tbNomeProduto.Enter += tbNomeProduto_Enter;

        }

        private void FormAddVendas_Load_1(object sender, EventArgs e)
        {
            // LIMPA a tabela temporária ANTES de carregar tudo
            LimparTabelaTemporaria();

            CarregarFuncionarios();
            InicializarCampos();
            AtualizarGridProdutos();
        }

        private void InicializarCampos()
        {
            tbPrecoProduto.Text = "R$ 0,00";
            tbDesconto.Text = "R$ 0,00";
            mkDataHora.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);

            // Limpa campos de produto
            tbNomeProduto.Clear();
            tbQProduto.Text = "";
            lbQuantidadeAtual.Text = "Quantidade atual: 0";
            lbIdProduto.Text = "0";
            lbMarcaProduto.Text = "";
        }

        #endregion

        #region Configuração DataGridView

        private void ConfigurarDataGridViewProdutos()
        {
            AplicarTemaEscuroDataGridView();
            ConfigurarColunasDataGridView();

            // Evento de resize para ajustar larguras
            dgvProdutoTemporarios.Resize += DgvProdutoTemporarios_Resize;
            dgvProdutoTemporarios.DataBindingComplete += (s, e) => AjustarLarguraColunasFixas();
        }

        private void AplicarTemaEscuroDataGridView()
        {
            dgvProdutoTemporarios.SuspendLayout();

            // Cores
            Color background = Color.FromArgb(32, 33, 39);       // fundo principal
            Color backgroundAlt = Color.FromArgb(38, 39, 46);    // fundo alternado das linhas
            Color headerBack = Color.FromArgb(40, 41, 52);       // cabeçalho
            Color gridColor = Color.FromArgb(50, 52, 67);        // linhas da grade
            Color selectionBack = Color.FromArgb(50, 90, 130);   // seleção azul escuro
            Color fore = Color.White;

            // Configurações gerais
            dgvProdutoTemporarios.BackgroundColor = background;
            dgvProdutoTemporarios.BorderStyle = BorderStyle.None;
            dgvProdutoTemporarios.GridColor = gridColor;
            dgvProdutoTemporarios.EnableHeadersVisualStyles = false;

            // Cabeçalho
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
            dgvProdutoTemporarios.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvProdutoTemporarios.ColumnHeadersHeight = 40;
            dgvProdutoTemporarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProdutoTemporarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Linhas (texto à esquerda)
            var cellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
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

            dgvProdutoTemporarios.DefaultCellStyle = cellStyle;
            dgvProdutoTemporarios.RowsDefaultCellStyle = cellStyle;
            dgvProdutoTemporarios.AlternatingRowsDefaultCellStyle = altCellStyle;
            dgvProdutoTemporarios.RowTemplate.Height = 35;

            // Garante alinhamento das colunas à esquerda
            foreach (DataGridViewColumn coluna in dgvProdutoTemporarios.Columns)
            {
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvProdutoTemporarios.AllowUserToAddRows = false;
            dgvProdutoTemporarios.AllowUserToDeleteRows = false;
            dgvProdutoTemporarios.AllowUserToResizeRows = false;
            dgvProdutoTemporarios.MultiSelect = false;
            dgvProdutoTemporarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutoTemporarios.ReadOnly = true;
            dgvProdutoTemporarios.RowHeadersVisible = false;
            dgvProdutoTemporarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvProdutoTemporarios.ClearSelection();
            dgvProdutoTemporarios.CurrentCell = null;

            dgvProdutoTemporarios.ResumeLayout();
        }

        private void ConfigurarColunasDataGridView()
        {
            // Oculta ID_TEMP, caso exista
            if (dgvProdutoTemporarios.Columns.Contains("ID_TEMP"))
            {
                dgvProdutoTemporarios.Columns["ID_TEMP"].Visible = false;
            }

            if (dgvProdutoTemporarios.Columns.Count == 0) return;

            // Remove o auto-size das colunas
            dgvProdutoTemporarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Configura todas as colunas como fixas, exceto a última
            for (int i = 0; i < dgvProdutoTemporarios.Columns.Count; i++)
            {
                var coluna = dgvProdutoTemporarios.Columns[i];

                // Define propriedades comuns
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Se for a última coluna, configura como fill
                if (i == dgvProdutoTemporarios.Columns.Count - 1)
                {
                    coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    coluna.MinimumWidth = 100; // Largura mínima para a última coluna
                }
                else
                {
                    // Colunas fixas
                    coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    coluna.Resizable = DataGridViewTriState.False;
                }
            }

            // Configura cabeçalhos específicos
            ConfigurarCabecalhosColunas();
        }

        private void ConfigurarCabecalhosColunas()
        {
            // Configura os textos dos cabeçalhos
            if (dgvProdutoTemporarios.Columns.Contains("ID_PRODUTO"))
            {
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].HeaderText = "ID";
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].Width = 60;
            }

            if (dgvProdutoTemporarios.Columns.Contains("NOME"))
            {
                dgvProdutoTemporarios.Columns["NOME"].HeaderText = "Produto";
                dgvProdutoTemporarios.Columns["NOME"].MinimumWidth = 150;
            }

            if (dgvProdutoTemporarios.Columns.Contains("PRECO_UNITARIO"))
            {
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].HeaderText = "Preço Unitário";
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].DefaultCellStyle.Format = "C2";
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].Width = 120;
            }

            if (dgvProdutoTemporarios.Columns.Contains("QUANTIDADE"))
            {
                dgvProdutoTemporarios.Columns["QUANTIDADE"].HeaderText = "Quantidade";
                dgvProdutoTemporarios.Columns["QUANTIDADE"].Width = 90;
            }

            if (dgvProdutoTemporarios.Columns.Contains("SUBTOTAL"))
            {
                dgvProdutoTemporarios.Columns["SUBTOTAL"].HeaderText = "Subtotal";
                dgvProdutoTemporarios.Columns["SUBTOTAL"].DefaultCellStyle.Format = "C2";
                dgvProdutoTemporarios.Columns["SUBTOTAL"].Width = 100;
            }
        }

        private void AjustarLarguraColunasFixas()
        {
            if (dgvProdutoTemporarios.Columns.Count == 0) return;

            int larguraTotalFixas = 0;

            // Calcula a largura total das colunas fixas
            for (int i = 0; i < dgvProdutoTemporarios.Columns.Count - 1; i++)
            {
                larguraTotalFixas += dgvProdutoTemporarios.Columns[i].Width;
            }

            // Adiciona margem para as bordas e scrollbar
            int margem = SystemInformation.VerticalScrollBarWidth + 2;

            // Se a soma das colunas fixas for maior que a área disponível
            if (larguraTotalFixas + margem > dgvProdutoTemporarios.ClientSize.Width)
            {
                // Habilita a scrollbar horizontal e ajusta a última coluna
                dgvProdutoTemporarios.Columns[dgvProdutoTemporarios.Columns.Count - 1].Width = 100; // Largura mínima
            }
            else
            {
                // Ajusta a última coluna para preencher o restante
                int restante = dgvProdutoTemporarios.ClientSize.Width - larguraTotalFixas - margem;
                if (restante > 100)
                    dgvProdutoTemporarios.Columns[dgvProdutoTemporarios.Columns.Count - 1].Width = restante;
                else
                    dgvProdutoTemporarios.Columns[dgvProdutoTemporarios.Columns.Count - 1].Width = 100;
            }
        }

        private void DgvProdutoTemporarios_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunasFixas();
        }

        #endregion

        #region Combos

        private void PopularCombosPagamento()
        {
            _ignorarEventoCombo = true;
            try
            {
                cbForma.Items.Clear();
                cbForma.Items.AddRange(new object[] {
                    "Dinheiro",
                    "Credito",
                    "Debito",
                    "Pix QR",
                    "Pix",
                    "Ausente"
                });

                cbEstado.Items.Clear();
                cbEstado.Items.AddRange(new object[] {
                    "Pago",
                    "Pendente"
                });

                cbForma.SelectedIndex = -1;
                cbEstado.SelectedIndex = -1;
            }
            finally
            {
                _ignorarEventoCombo = false;
            }
        }

        private void ConfigurarVinculoCombos()
        {
            cbEstado.SelectedIndexChanged -= CbEstado_SelectedIndexChanged;
            cbForma.SelectedIndexChanged -= CbForma_SelectedIndexChanged;

            cbEstado.SelectedIndexChanged += CbEstado_SelectedIndexChanged;
            cbForma.SelectedIndexChanged += CbForma_SelectedIndexChanged;
        }

        private void SelecionarItemPorTexto(ComboBox cb, string texto)
        {
            if (cb == null || texto == null) return;

            for (int i = 0; i < cb.Items.Count; i++)
            {
                var itemText = cb.Items[i]?.ToString()?.Trim();
                if (string.Equals(itemText, texto.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }

            cb.SelectedIndex = -1;
        }

        private void CbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoCombo) return;

            try
            {
                _ignorarEventoCombo = true;

                string estado = (cbEstado.SelectedItem?.ToString() ?? cbEstado.Text)?.Trim();

                if (!string.IsNullOrEmpty(estado) && estado.Equals("Pendente", StringComparison.OrdinalIgnoreCase))
                {
                    SelecionarItemPorTexto(cbForma, "Ausente");
                    cbForma.Enabled = false;
                }
                else
                {
                    cbForma.Enabled = true;
                    string formaAtual = (cbForma.SelectedItem?.ToString() ?? cbForma.Text)?.Trim();
                    if (!string.IsNullOrEmpty(formaAtual) && formaAtual.Equals("Ausente", StringComparison.OrdinalIgnoreCase))
                        cbForma.SelectedIndex = -1;
                }
            }
            finally
            {
                _ignorarEventoCombo = false;
            }
        }

        private void CbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoCombo) return;

            try
            {
                _ignorarEventoCombo = true;

                string forma = (cbForma.SelectedItem?.ToString() ?? cbForma.Text)?.Trim();

                if (!string.IsNullOrEmpty(forma) && forma.Equals("Ausente", StringComparison.OrdinalIgnoreCase))
                {
                    SelecionarItemPorTexto(cbEstado, "Pendente");
                    cbEstado.Enabled = false;
                }
                else
                {
                    cbEstado.Enabled = true;
                    string estadoAtual = (cbEstado.SelectedItem?.ToString() ?? cbEstado.Text)?.Trim();
                    if (!string.IsNullOrEmpty(estadoAtual) && estadoAtual.Equals("Pendente", StringComparison.OrdinalIgnoreCase))
                        cbEstado.SelectedIndex = -1;
                }
            }
            finally
            {
                _ignorarEventoCombo = false;
            }
        }

        #endregion

        #region Funcionários

        private void CarregarFuncionarios()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                string sql = "SELECT NOME FROM FUNCIONARIO ORDER BY NOME;";
                using var cmd = new SQLiteCommand(sql, conn);
                using var reader = cmd.ExecuteReader();

                cbFuncionariosVenda.Items.Clear();
                while (reader.Read())
                    cbFuncionariosVenda.Items.Add(reader["NOME"].ToString());

                cbFuncionariosVenda.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        #endregion

        #region Produtos

        private void tbNomeProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;


            if (_preenchendoProdutoAutomaticamente)
                return;

            e.SuppressKeyPress = true;

            if (tbNomeProduto.ForeColor == Color.Gray)
                return;

            BuscarProdutoPorMetodo(tbNomeProduto.Text.Trim());
        }

        private void tbNomeProduto_Enter(object sender, EventArgs e)
        {
            if (tbNomeProduto.ForeColor == Color.Gray)
            {
                tbNomeProduto.Text = "";
                tbNomeProduto.ForeColor = Color.White;
            }
        }


        private void BuscarProdutoPorMetodo(string valor)
        {


            if (string.IsNullOrWhiteSpace(valor))
                return;

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string metodo = cbMetodoPesquisa.SelectedItem?.ToString() ?? "ID";
                SQLiteCommand cmd;

                switch (metodo)
                {
                    case "ID":

                        // Se já existe um produto carregado, só bloqueia se for o MESMO ID
                        if (int.TryParse(lbIdProduto.Text, out int idAtual) &&
                            int.TryParse(valor, out int idDigitado) &&
                            idAtual == idDigitado)
                        {
                            return;
                        }

                        if (!int.TryParse(valor, out int id))
                            return;

                        cmd = new SQLiteCommand(
                            "SELECT ID_PRODUTO, NOME, MARCA, PRECO, QTD_ESTOQUE " +
                            "FROM PRODUTO WHERE ID_PRODUTO = @valor LIMIT 1;", conn);

                        cmd.Parameters.AddWithValue("@valor", id);
                        break;

                    default: // Nome do Produto
                        cmd = new SQLiteCommand(
                            "SELECT ID_PRODUTO, NOME, MARCA, PRECO, QTD_ESTOQUE " +
                            "FROM PRODUTO WHERE NOME LIKE @valor LIMIT 1;", conn);

                        cmd.Parameters.AddWithValue("@valor", valor + "%");
                        break;
                }

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _preenchendoProdutoAutomaticamente = true;

                    PreencherCamposProduto(reader);

                    _preenchendoProdutoAutomaticamente = false;

                    this.SelectNextControl(tbNomeProduto, true, true, true, true);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar produto: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PreencherCamposProduto(SQLiteDataReader reader)
        {
            lbIdProduto.Text = reader["ID_PRODUTO"].ToString();
            tbNomeProduto.Text = reader["NOME"].ToString();
            tbNomeProduto.ForeColor = Color.White;

            lbMarcaProduto.Text = reader["MARCA"].ToString();

            decimal preco = Convert.ToDecimal(reader["PRECO"]);
            tbPrecoProduto.Text = "R$ " + preco.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));

            int quantidade = Convert.ToInt32(reader["QTD_ESTOQUE"]);
            lbQuantidadeAtual.Text = $"Quantidade atual: {quantidade}";
        }


        public void PreencherProduto(string nomeProduto, int idProduto)
        {
            try
            {
                tbNomeProduto.Text = nomeProduto;
                lbIdProduto.Text = idProduto.ToString();

                string sql = "SELECT MARCA, PRECO, QTD_ESTOQUE FROM PRODUTO WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametros = { new SQLiteParameter("@id", idProduto) };
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using var cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idProduto);

                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lbMarcaProduto.Text = reader["MARCA"].ToString();

                        decimal preco = Convert.ToDecimal(reader["PRECO"]);
                        tbPrecoProduto.Text = "R$ " + preco.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));

                        int qtdEstoque = Convert.ToInt32(reader["QTD_ESTOQUE"]);
                        lbQuantidadeAtual.Text = $"Quantidade atual: {qtdEstoque}";
                    }
                    else
                    {
                        lbMarcaProduto.Text = "";
                        tbPrecoProduto.Text = "R$ 0,00";
                        lbQuantidadeAtual.Text = "Quantidade atual: 0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbMarcaProduto.Text = "";
                tbPrecoProduto.Text = "R$ 0,00";
                lbQuantidadeAtual.Text = "Quantidade atual: 0";
            }
        }

        private void BtnAdicaoProduto_Click(object sender, EventArgs e)
        {
            if (!ValidarProduto()) return;
            AdicionarProduto();
        }

        private bool ValidarProduto()
        {
            if (string.IsNullOrWhiteSpace(tbNomeProduto.Text))
            {
                MessageBox.Show("Selecione um produto antes de adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(lbIdProduto.Text, out _))
            {
                MessageBox.Show("ID do produto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!decimal.TryParse(tbPrecoProduto.Text.Replace("R$", ""), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out _))
            {
                MessageBox.Show("Preço do produto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(tbQProduto.Text, out int qtd) || qtd <= 0)
            {
                MessageBox.Show("Quantidade inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(lbQuantidadeAtual.Text.Replace("Quantidade atual: ", ""), out int qtdAtual))
                qtdAtual = 0;

            if (qtd > qtdAtual)
            {
                MessageBox.Show($"A quantidade informada ({qtd}) é maior que a quantidade disponível ({qtdAtual}).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbQProduto.Text = "";
                tbQProduto.Focus();
                return false;
            }

            return true;
        }

        private void AdicionarProduto()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string sql = @"
                    INSERT INTO PRODUTOS_TEMPORARIOS (ID_PRODUTO, NOME, MARCA, PRECO_UNITARIO, QUANTIDADE)
                    VALUES (@id, @nome, @marca, @preco, @qtd);
                ";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", lbIdProduto.Text);
                cmd.Parameters.AddWithValue("@nome", tbNomeProduto.Text);
                cmd.Parameters.AddWithValue("@marca", lbMarcaProduto.Text);
                cmd.Parameters.AddWithValue("@preco", decimal.Parse(tbPrecoProduto.Text.Replace("R$", ""), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR")));
                cmd.Parameters.AddWithValue("@qtd", int.Parse(tbQProduto.Text));
                cmd.ExecuteNonQuery();

                AtualizarGridProdutos();
                AtualizarLbValorSuper();
                LimparCamposProduto();

                MessageBox.Show("Produto adicionado à lista com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTirarProduto_Click(object sender, EventArgs e)
        {
            if (dgvProdutoTemporarios.CurrentRow == null)
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente remover o produto selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            RemoverProduto();
        }

        private void RemoverProduto()
        {
            try
            {
                int idTemp = Convert.ToInt32(dgvProdutoTemporarios.CurrentRow.Cells["ID_TEMP"].Value);

                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string sql = "DELETE FROM PRODUTOS_TEMPORARIOS WHERE ID_TEMP = @id;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idTemp);
                cmd.ExecuteNonQuery();

                AtualizarGridProdutos();
                AtualizarLbValorSuper();

                MessageBox.Show("Produto removido da lista com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCamposProduto()
        {
            tbNomeProduto.Clear();
            tbPrecoProduto.Text = "R$ 0,00";
            tbQProduto.Text = "";
            lbQuantidadeAtual.Text = "Quantidade atual: 0";
            lbIdProduto.Text = "0";
            lbMarcaProduto.Text = "";
        }

        #endregion

        #region Monetários

        private void ConfigurarMonetarios()
        {
            ConfigurarTextBoxMonetario(tbPrecoProduto, TbPrecoProduto_TextChanged);
            ConfigurarTextBoxMonetario(tbDesconto, TbDesconto_TextChanged);
        }

        private void ConfigurarTextBoxMonetario(TextBox tb, EventHandler textChanged)
        {
            tb.KeyPress -= TbPreco_KeyPress;
            tb.KeyPress += TbPreco_KeyPress;

            tb.TextChanged -= textChanged;
            tb.TextChanged += textChanged;
        }

        private void TbPrecoProduto_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoPrecoProduto) return;

            _ignorarEventoPrecoProduto = true;
            FormatarMonetario(sender as TextBox);
            AtualizarLbValorSuper();
            _ignorarEventoPrecoProduto = false;
        }

        private void TbDesconto_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoDesconto) return;

            _ignorarEventoDesconto = true;
            FormatarMonetario(sender as TextBox);
            AtualizarLbValorSuper();
            _ignorarEventoDesconto = false;
        }

        private void FormatarMonetario(TextBox tb)
        {
            if (tb == null) return;

            // Extrai somente dígitos
            string numeros = "";
            foreach (char c in tb.Text)
                if (char.IsDigit(c)) numeros += c;

            if (string.IsNullOrEmpty(numeros)) numeros = "0";

            // interpreta como centavos
            if (!decimal.TryParse(numeros, out decimal inteiro))
                inteiro = 0m;

            decimal valor = inteiro / 100m;

            // Limite de segurança igual ao FormAddEstoque
            if (valor > 1000000m) valor = 1000000m;

            // Formata e coloca caret no fim (comportamento do estoque)
            tb.Text = "R$ " + valor.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
            tb.SelectionStart = tb.Text.Length;
        }


        private void TbPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        #endregion

        #region Grid Temporário

        private void CriarTabelaTemporaria()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string sql = @"
            CREATE TABLE IF NOT EXISTS PRODUTOS_TEMPORARIOS (
                ID_TEMP INTEGER PRIMARY KEY AUTOINCREMENT,
                ID_PRODUTO INTEGER NOT NULL,
                NOME TEXT NOT NULL CHECK(length(NOME) <= 100),
                MARCA TEXT CHECK(length(MARCA) <= 50),
                PRECO_UNITARIO REAL NOT NULL CHECK(PRECO_UNITARIO = ROUND(PRECO_UNITARIO,2) AND PRECO_UNITARIO >=0),
                QUANTIDADE INTEGER NOT NULL CHECK(QUANTIDADE>0),
                SUBTOTAL REAL GENERATED ALWAYS AS (ROUND(PRECO_UNITARIO*QUANTIDADE,2)) VIRTUAL
            );
        ";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar tabela de produtos temporários: " + ex.Message);
            }
        }

        private void LimparTabelaTemporaria()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                // Primeiro cria a tabela se não existir
                CriarTabelaTemporaria();

                // DEPOIS limpa os dados
                string sqlLimpar = "DELETE FROM PRODUTOS_TEMPORARIOS;";
                using var cmdLimpar = new SQLiteCommand(sqlLimpar, conn);
                cmdLimpar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao limpar tabela temporária: " + ex.Message);
            }
        }

        private void AtualizarGridProdutos()
        {
            try
            {
                string sql = "SELECT ID_TEMP, ID_PRODUTO, NOME, PRECO_UNITARIO, QUANTIDADE, SUBTOTAL FROM PRODUTOS_TEMPORARIOS;";
                var dt = DatabaseHelper.ExecuteQuery(sql);
                dgvProdutoTemporarios.DataSource = dt;

                // Aplica as configurações após carregar os dados
                ConfigurarDataGridViewProdutos();

                AtualizarLbValorSuper();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos temporários: " + ex.Message);
            }
        }

        private void AtualizarLbValorSuper()
        {
            decimal valorBruto = 0;
            foreach (DataGridViewRow row in dgvProdutoTemporarios.Rows)
            {
                if (row.Cells["SUBTOTAL"].Value != null)
                    valorBruto += Convert.ToDecimal(row.Cells["SUBTOTAL"].Value);
            }

            decimal desconto = 0;
            decimal.TryParse(tbDesconto.Text.Replace("R$", "").Trim(), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out desconto);

            decimal valorFinal = Math.Max(0, valorBruto - desconto);
            lbValorSuper.Text = "R$ " + valorFinal.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
        }

        #endregion

        #region Botões / imagens

        private void BtnMaisInformacao_Click(object sender, EventArgs e)
        {
            using var formAddProduto = new FormAddProdutoVendas();
            formAddProduto.Owner = this;
            formAddProduto.ShowDialog();
        }

        private void btnCancelarVendas_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a operação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnAdicionarVendas_Click_1(object sender, EventArgs e)
        {
            if (!HasProdutosTemporarios())
            {
                MessageBox.Show("ADICIONE PELO MENOS UM PRODUTO PARA FINALIZAR A VENDA.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EnsureDataHoraValidBeforeCommit())
            {
                return;
            }

            if (!ValidarVenda()) return;

            ProcessarVenda();
        }

        private bool EnsureDataHoraValidBeforeCommit()
        {
            try
            {
                if (_trustedNow == default)
                {
                    _trustedNow = GetTrustedNow(out _trustedNowIsNtp);
                }

                string texto = mkDataHora?.Text ?? "";
                if (string.IsNullOrWhiteSpace(texto))
                {
                    mkDataHora.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                    MessageBox.Show("A data/hora estava vazia. O campo foi ajustado para a hora atual do PC. Verifique e confirme antes de finalizar a venda.", "Ajuste de Data/Hora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mkDataHora.Focus();
                    return false;
                }

                string[] formatos = new[]
                {
                    "dd-MM-yyyy HH:mm",
                    "dd/MM/yyyy HH:mm",
                    "d-MM-yyyy HH:mm",
                    "d/MM/yyyy HH:mm",
                    "yyyy-MM-dd HH:mm"
                };

                if (!DateTime.TryParseExact(texto.Trim(), formatos, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtCampo))
                {
                    mkDataHora.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                    MessageBox.Show("Formato de data/hora inválido. O campo foi ajustado para a hora atual do PC. Corrija se necessário e tente novamente.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mkDataHora.Focus();
                    return false;
                }

                if (dtCampo.Kind == DateTimeKind.Utc)
                    dtCampo = dtCampo.ToLocalTime();
                else if (dtCampo.Kind == DateTimeKind.Unspecified)
                    dtCampo = DateTime.SpecifyKind(dtCampo, DateTimeKind.Local);

                DateTime minimo = _trustedNow.AddDays(-7);
                DateTime maximo = _trustedNow;

                if (dtCampo < minimo || dtCampo > maximo)
                {
                    DateTime agoraPc = DateTime.Now;
                    mkDataHora.Text = agoraPc.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);

                    MessageBox.Show(
                        $"Data/Hora informada ({dtCampo:dd-MM-yyyy HH:mm}) está fora do intervalo permitido (máx = {_trustedNow:dd-MM-yyyy HH:mm}, mín = {_trustedNow.AddDays(-7):dd-MM-yyyy HH:mm}).\n\n" +
                        $"O campo foi reajustado para a hora atual do PC ({agoraPc:dd-MM-yyyy HH:mm}). Por favor, confirme ou corrija a data antes de finalizar a venda.",
                        "Data/Hora fora do permitido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    mkDataHora.Focus();
                    return false;
                }

                return true;
            }
            catch
            {
                try
                {
                    mkDataHora.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
                    MessageBox.Show("Erro ao validar data/hora. O campo foi ajustado para a hora atual do PC. Verifique e tente novamente.", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mkDataHora.Focus();
                }
                catch { }

                return false;
            }
        }

        private bool ValidarVenda()
        {
            if (!HasProdutosTemporarios())
            {
                MessageBox.Show("ADICIONE PELO MENOS UM PRODUTO VALIDO PARA FINALIZAR A VENDA.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbFuncionariosVenda.Text))
            {
                MessageBox.Show("INFORME O NOME DO FUNCIONÁRIO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbFuncionariosVenda.Focus();
                return false;
            }

            if (cbEstado.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cbEstado.Text))
            {
                MessageBox.Show("SELECIONE O ESTADO DO PAGAMENTO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus();
                return false;
            }

            if (cbForma.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cbForma.Text))
            {
                MessageBox.Show("SELECIONE A FORMA DE PAGAMENTO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbForma.Focus();
                return false;
            }

            if (!ValidarDataHora(mkDataHora.Text, out DateTime dt))
            {
                MessageBox.Show("DATA/HORA INVÁLIDA. Use o formato dd-MM-yyyy HH:mm e informe uma data até 7 dias atrás (não futura).", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mkDataHora.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarDataHora(string texto, out DateTime dt)
        {
            dt = DateTime.MinValue;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            string[] formatos = new[]
            {
                "dd-MM-yyyy HH:mm",
                "dd/MM/yyyy HH:mm",
                "d-MM-yyyy HH:mm",
                "d/MM/yyyy HH:mm",
                "yyyy-MM-dd HH:mm"
            };

            if (!DateTime.TryParseExact(texto.Trim(), formatos, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                return false;

            if (dt.Kind == DateTimeKind.Utc)
                dt = dt.ToLocalTime();
            else if (dt.Kind == DateTimeKind.Unspecified)
                dt = DateTime.SpecifyKind(dt, DateTimeKind.Local);

            if (_trustedNow == default)
            {
                _trustedNow = GetTrustedNow(out _trustedNowIsNtp);
            }

            DateTime minimo = _trustedNow.AddDays(-7);
            DateTime maximo = _trustedNow;

            if (dt < minimo || dt > maximo)
                return false;

            return true;
        }

        private DateTime GetTrustedNow(out bool isNtp)
        {
            isNtp = false;
            try
            {
                DateTime? ntpUtc = GetNetworkTimeUtc("pool.ntp.org", 3000);
                if (ntpUtc == null)
                    ntpUtc = GetNetworkTimeUtc("time.google.com", 3000);

                if (ntpUtc != null)
                {
                    isNtp = true;
                    return ntpUtc.Value.ToLocalTime();
                }
            }
            catch
            {
                // ignore and fallback
            }

            return DateTime.Now;
        }

        private DateTime? GetNetworkTimeUtc(string ntpServer, int timeoutMillis = 3000)
        {
            try
            {
                var ntpData = new byte[48];
                ntpData[0] = 0x1B;

                var addresses = Dns.GetHostEntry(ntpServer).AddressList;
                if (addresses == null || addresses.Length == 0) return null;

                var ipEndPoint = new IPEndPoint(addresses[0], 123);

                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    socket.ReceiveTimeout = timeoutMillis;
                    socket.Connect(ipEndPoint);
                    socket.Send(ntpData);

                    int received = socket.Receive(ntpData);
                    if (received < 48) return null;

                    const byte offsetTransmitTime = 40;
                    ulong intPart = (ulong)ntpData[offsetTransmitTime] << 24 |
                                    (ulong)ntpData[offsetTransmitTime + 1] << 16 |
                                    (ulong)ntpData[offsetTransmitTime + 2] << 8 |
                                    (ulong)ntpData[offsetTransmitTime + 3];

                    ulong fractPart = (ulong)ntpData[offsetTransmitTime + 4] << 24 |
                                      (ulong)ntpData[offsetTransmitTime + 5] << 16 |
                                      (ulong)ntpData[offsetTransmitTime + 6] << 8 |
                                      (ulong)ntpData[offsetTransmitTime + 7];

                    var milliseconds = (intPart * 1000) + (fractPart * 1000 / 0x100000000UL);

                    var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);

                    return networkDateTime.ToUniversalTime();
                }
            }
            catch
            {
                return null;
            }
        }

        private bool HasProdutosTemporarios()
        {
            try
            {
                foreach (DataGridViewRow row in dgvProdutoTemporarios.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (dgvProdutoTemporarios.Columns.Contains("ID_TEMP") &&
                        row.Cells["ID_TEMP"].Value != null &&
                        int.TryParse(row.Cells["ID_TEMP"].Value.ToString(), out _))
                        return true;

                    if (dgvProdutoTemporarios.Columns.Contains("SUBTOTAL") &&
                        row.Cells["SUBTOTAL"].Value != null)
                    {
                        if (decimal.TryParse(row.Cells["SUBTOTAL"].Value.ToString(), out decimal st) && st > 0)
                            return true;
                    }
                }
            }
            catch
            {
            }

            return false;
        }

        private void ProcessarVenda()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                using var transaction = conn.BeginTransaction();

                decimal valorBruto = 0;
                foreach (DataGridViewRow row in dgvProdutoTemporarios.Rows)
                    valorBruto += Convert.ToDecimal(row.Cells["SUBTOTAL"].Value);

                decimal desconto = 0;
                decimal.TryParse(tbDesconto.Text.Replace("R$", "").Trim(), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out desconto);

                decimal valorTotal = Math.Max(0, valorBruto - desconto);

                InserirVenda(conn, transaction, valorTotal, desconto, out long idVenda);
                InserirItensVenda(conn, transaction, idVenda);
                InserirPagamento(conn, transaction, idVenda, valorTotal);
                LimparTabelaTemporaria(conn, transaction);

                transaction.Commit();

                MessageBox.Show("VENDA CADASTRADA COM SUCESSO!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VendaConfirmadaCallback?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO CADASTRAR VENDA: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InserirVenda(SQLiteConnection conn, SQLiteTransaction transaction, decimal valorTotal, decimal desconto, out long idVenda)
        {
            string sqlVenda = @"
                INSERT INTO VENDA (NOME_FUNCIONARIO, DATA_HORA, VALOR_TOTAL, DESCONTO)
                VALUES (@nome, @data, @valor, @desconto);
            ";

            using var cmdVenda = new SQLiteCommand(sqlVenda, conn, transaction);
            cmdVenda.Parameters.AddWithValue("@nome", cbFuncionariosVenda.Text.Trim().ToUpper());
            cmdVenda.Parameters.AddWithValue("@data", mkDataHora.Text);
            cmdVenda.Parameters.AddWithValue("@valor", valorTotal);
            cmdVenda.Parameters.AddWithValue("@desconto", desconto);
            cmdVenda.ExecuteNonQuery();

            idVenda = conn.LastInsertRowId;
        }

        private void InserirItensVenda(SQLiteConnection conn, SQLiteTransaction transaction, long idVenda)
        {
            string sqlItens = @"
                INSERT INTO ITEM_VENDA (ID_VENDA, ID_PRODUTO, QUANTIDADE, PRECO_UNITARIO)
                SELECT @idVenda, ID_PRODUTO, QUANTIDADE, PRECO_UNITARIO
                FROM PRODUTOS_TEMPORARIOS;
            ";

            using var cmdItens = new SQLiteCommand(sqlItens, conn, transaction);
            cmdItens.Parameters.AddWithValue("@idVenda", idVenda);
            cmdItens.ExecuteNonQuery();
        }

        private void InserirPagamento(SQLiteConnection conn, SQLiteTransaction transaction, long idVenda, decimal valorTotal)
        {
            string sqlPagamento = @"
                INSERT INTO PAGAMENTO (ID_VENDA, FORMA, VALOR, ESTADO)
                VALUES (@idVenda, @forma, @valor, @estado);
            ";

            using var cmdPagamento = new SQLiteCommand(sqlPagamento, conn, transaction);

            string formaParaBanco = (cbForma.Text ?? "").Trim().ToUpperInvariant();
            string estadoParaBanco = (cbEstado.Text ?? "").Trim().ToUpperInvariant();

            cmdPagamento.Parameters.AddWithValue("@idVenda", idVenda);
            cmdPagamento.Parameters.AddWithValue("@forma", formaParaBanco);
            cmdPagamento.Parameters.AddWithValue("@valor", valorTotal);
            cmdPagamento.Parameters.AddWithValue("@estado", estadoParaBanco);
            cmdPagamento.ExecuteNonQuery();
        }

        private void LimparTabelaTemporaria(SQLiteConnection conn, SQLiteTransaction transaction)
        {
            string sqlLimpar = "DELETE FROM PRODUTOS_TEMPORARIOS;";
            using var cmdLimpar = new SQLiteCommand(sqlLimpar, conn, transaction);
            cmdLimpar.ExecuteNonQuery();
        }

        #endregion

        private void cbMetodoPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarPlaceholderMetodoPesquisa();
        }

        private void AtualizarPlaceholderMetodoPesquisa()
        {
            tbNomeProduto.ForeColor = Color.Gray;

            switch (cbMetodoPesquisa.SelectedItem?.ToString())
            {
                case "ID":
                    tbNomeProduto.Text = "Ex: 31";
                    break;

                case "Nome do Produto":
                    tbNomeProduto.Text = "Ex: Capinha";
                    break;
            }
        }

    }
}