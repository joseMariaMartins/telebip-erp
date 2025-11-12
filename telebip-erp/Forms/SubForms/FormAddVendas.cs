using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin;
using MaterialSkin.Controls;
using telebip_erp.Forms.SubSubForms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddVendas : MaterialForm
    {
        // Flags de controle
        private bool _ignorarEventoPrecoProduto = false;
        private bool _ignorarEventoDesconto = false;
        private bool _ignorarEventoCombo = false;

        public Action? VendaConfirmadaCallback { get; set; }
        public bool ModoConsulta { get; set; } = false;
        public int? VendaID { get; set; } = null;

        public FormAddVendas()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();
            InicializarComponentes();
        }

        #region Inicialização

        private void InicializarComponentes()
        {
            // Vincula handlers de UI
            ConfigurarBotoesImagemRadio();
            ConfigurarMonetarios();
            CriarTabelaTemporaria();

            // Handlers de controles visuais/inputs
            picAdicaoProduto.Click += BtnAdicaoProduto_Click;
            picTirarProduto.Click += BtnTirarProduto_Click;
            btnMaisInformacao.Click += BtnMaisInformacao_Click;

            // Botões principais (agora garantidos no Init)
            btnAdicionarVendas.Click += btnAdicionarVendas_Click_1;
            btnCancelarVendas.Click += btnCancelarVendas_Click_1;

            // Combos: popular primeiro, depois vincular eventos
            PopularCombosPagamento();
            ConfigurarVinculoCombos();

            // Load do form (garante que o método seja executado ao abrir)
            this.Load += FormAddVendas_Load_1;
        }

        private void FormAddVendas_Load_1(object sender, EventArgs e)
        {
            CarregarFuncionarios();
            InicializarCampos();
            AtualizarGridProdutos();
        }

        private void InicializarCampos()
        {
            tbPrecoProduto.Text = "R$ 0,00";
            tbDesconto.Text = "R$ 0,00";
            mkDataHora.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        #endregion

        #region Combos

        private void PopularCombosPagamento()
        {
            // Previne que os handlers reajam durante a população
            _ignorarEventoCombo = true;
            try
            {
                cbForma.Items.Clear();
                cbForma.Items.AddRange(new object[] {
                    "Dinheiro",
                    "Credito",
                    "Pix QR",
                    "Pix",
                    "Ausente"
                });

                cbEstado.Items.Clear();
                cbEstado.Items.AddRange(new object[] {
                    "Pago",
                    "Pendente"
                });

                // não selecionar nada por padrão
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
            // evita dupla inscrição caso o método seja chamado novamente
            cbEstado.SelectedIndexChanged -= CbEstado_SelectedIndexChanged;
            cbForma.SelectedIndexChanged -= CbForma_SelectedIndexChanged;

            cbEstado.SelectedIndexChanged += CbEstado_SelectedIndexChanged;
            cbForma.SelectedIndexChanged += CbForma_SelectedIndexChanged;
        }

        // Helper para selecionar item por texto (case-insensitive, trim)
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
                    // seleciona "Ausente" na forma (usando helper) e desabilita
                    SelecionarItemPorTexto(cbForma, "Ausente");
                    cbForma.Enabled = false;
                }
                else
                {
                    // desbloqueia forma e se estiver "Ausente" limpa (apenas se a seleção textual corresponder)
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
                    // seleciona "Pendente" no estado (usando helper) e desabilita
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

            e.SuppressKeyPress = true;
            BuscarProduto(tbNomeProduto.Text.ToUpper());
        }

        private void BuscarProduto(string nome)
        {
            tbNomeProduto.Text = nome;
            tbNomeProduto.SelectionStart = nome.Length;

            if (string.IsNullOrWhiteSpace(nome)) return;

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                string sql = "SELECT ID_PRODUTO, NOME, MARCA, PRECO, QTD_ESTOQUE FROM PRODUTO WHERE NOME LIKE @nome LIMIT 1";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", nome + "%");

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PreencherCamposProduto(reader);
                    this.SelectNextControl(tbNomeProduto, true, true, true, true);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado no sistema!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar produto: " + ex.Message);
            }
        }

        private void PreencherCamposProduto(SQLiteDataReader reader)
        {
            lbIdProduto.Text = reader["ID_PRODUTO"].ToString();
            tbNomeProduto.Text = reader["NOME"].ToString();
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
                // Preenche o nome do produto
                tbNomeProduto.Text = nomeProduto;
                lbIdProduto.Text = idProduto.ToString();

                // Busca os dados do produto no banco
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
                        // Marca
                        lbMarcaProduto.Text = reader["MARCA"].ToString();

                        // Preço
                        decimal preco = Convert.ToDecimal(reader["PRECO"]);
                        tbPrecoProduto.Text = "R$ " + preco.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));

                        // Quantidade em estoque
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

            // Aqui vamos checar se a quantidade informada é maior que a quantidade atual
            if (!int.TryParse(lbQuantidadeAtual.Text.Replace("Quantidade atual: ", ""), out int qtdAtual))
                qtdAtual = 0;

            if (qtd > qtdAtual)
            {
                MessageBox.Show($"A quantidade informada ({qtd}) é maior que a quantidade disponível ({qtdAtual}).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbQProduto.Text = ""; // limpa a quantidade informada
                tbQProduto.Focus();   // retorna o foco para o usuário corrigir
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
        }

        #endregion

        #region Monetários

        private void ConfigurarMonetarios()
        {
            // agora usa TextBox em vez de Guna2TextBox
            ConfigurarTextBoxMonetario(tbPrecoProduto, TbPrecoProduto_TextChanged);
            ConfigurarTextBoxMonetario(tbDesconto, TbDesconto_TextChanged);
        }

        private void ConfigurarTextBoxMonetario(TextBox tb, EventHandler textChanged)
        {
            // remove/reatacha handlers de KeyPress/TextChanged de TextBox
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

            string numeros = "";
            foreach (char c in tb.Text)
                if (char.IsDigit(c)) numeros += c;

            if (numeros == "") numeros = "0";

            decimal valor = decimal.Parse(numeros) / 100m;
            if (valor > 1000000m) valor = 1000000m;

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

                // 🔹 Só limpar a tabela temporária se NÃO estiver em modo consulta
                if (!ModoConsulta)
                {
                    using var cmdLimpar = new SQLiteCommand("DELETE FROM PRODUTOS_TEMPORARIOS;", conn);
                    cmdLimpar.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar/limpar tabela de produtos temporários: " + ex.Message);
            }
        }

        private void AtualizarGridProdutos()
        {
            try
            {
                // Pega todos os dados da tabela temporária
                string sql = "SELECT ID_TEMP, ID_PRODUTO, NOME, PRECO_UNITARIO, QUANTIDADE, SUBTOTAL FROM PRODUTOS_TEMPORARIOS;";
                var dt = DatabaseHelper.ExecuteQuery(sql);
                dgvProdutoTemporarios.DataSource = dt;

                // Configura visibilidade e títulos
                dgvProdutoTemporarios.Columns["ID_TEMP"].Visible = false;
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].HeaderText = "ID";
                dgvProdutoTemporarios.Columns["NOME"].HeaderText = "Produto";
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].HeaderText = "Preço Unitário";
                dgvProdutoTemporarios.Columns["QUANTIDADE"].HeaderText = "Qtd";
                dgvProdutoTemporarios.Columns["SUBTOTAL"].HeaderText = "Total";

                // Configura largura fixa das colunas
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].Width = 70;
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].Width = 150;
                dgvProdutoTemporarios.Columns["QUANTIDADE"].Width = 70;
                dgvProdutoTemporarios.Columns["SUBTOTAL"].Width = 100;

                // Coluna NOME ocupa o restante do espaço
                dgvProdutoTemporarios.Columns["NOME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Alinhamento do texto
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutoTemporarios.Columns["QUANTIDADE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutoTemporarios.Columns["SUBTOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvProdutoTemporarios.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Formato monetário para PRECO_UNITARIO e SUBTOTAL
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].DefaultCellStyle.Format = "C2";
                dgvProdutoTemporarios.Columns["SUBTOTAL"].DefaultCellStyle.Format = "C2";

                // Seleção limpa
                dgvProdutoTemporarios.ClearSelection();
                dgvProdutoTemporarios.CurrentCell = null;
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

        private void ConfigurarBotoesImagemRadio()
        {
            // Now uses PictureBox/CuiButtons from Designer:
            // - picAdicaoProduto : adiciona produto
            // - picTirarProduto  : remove produto
            // - btnMaisInformacao : abre FormAddProdutoVendas
        }

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
            if (dgvProdutoTemporarios.Rows.Count == 0)
            {
                MessageBox.Show("ADICIONE PELO MENOS UM PRODUTO PARA FINALIZAR A VENDA.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarVenda()) return;

            ProcessarVenda();
        }

        private bool ValidarVenda()
        {
            // Valida funcionário
            if (string.IsNullOrWhiteSpace(cbFuncionariosVenda.Text))
            {
                MessageBox.Show("INFORME O NOME DO FUNCIONÁRIO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbFuncionariosVenda.Focus();
                return false;
            }

            // Valida estado do pagamento
            if (cbEstado.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cbEstado.Text))
            {
                MessageBox.Show("SELECIONE O ESTADO DO PAGAMENTO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus();
                return false;
            }

            // Valida forma de pagamento
            if (cbForma.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cbForma.Text))
            {
                MessageBox.Show("SELECIONE A FORMA DE PAGAMENTO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbForma.Focus();
                return false;
            }

            return true;
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

            // Usa .Text para evitar NullReference e garante trim + uppercase
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
    }
}
