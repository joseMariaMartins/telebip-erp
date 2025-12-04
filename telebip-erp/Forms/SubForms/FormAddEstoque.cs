using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddEstoque : MaterialForm
    {
        private bool _ignorarEventoPreco = false;
        public (int Id, string Nome, int Quantidade)? ProdutoSelecionado { get; set; }
        public Action? AtualizarEstoqueCallback { get; set; }

        public FormAddEstoque()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            cbFuncionarios.SelectedIndex = -1;
            cbFuncionarios.Text = "";

            this.TopLevel = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            CarregarFuncionarios();

            tbPreco.Text = "R$ 0,00";
            tbPreco.SelectionStart = tbPreco.Text.Length;

            tbPreco.KeyPress += TbPreco_KeyPress;
            tbPreco.TextChanged += TbPreco_TextChanged;

            tbQEstoque.KeyPress += OnlyNumbers_KeyPress;
            tbQAviso.KeyPress += OnlyNumbers_KeyPress;

            btnAdicionar.Click += BtnAdicionar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            // Configurar navegação com Enter
            ConfigurarNavegacaoEnter();

            this.Load += (s, e) =>
            {
                CarregarFuncionarios();
                tbNome.Focus();
                tbNome.SelectAll();
            };

            // Adicionar evento KeyDown para o formulário
            this.KeyPreview = true;
            this.KeyDown += FormAddEstoque_KeyDown;
        }

        private void ConfigurarNavegacaoEnter()
        {
            // Configurar evento KeyDown para cada TextBox
            tbNome.KeyDown += TextBox_KeyDown;
            tbMarca.KeyDown += TextBox_KeyDown;
            tbPreco.KeyDown += TextBox_KeyDown;
            tbQEstoque.KeyDown += TextBox_KeyDown;
            tbQAviso.KeyDown += TextBox_KeyDown;
            tbObservacao.KeyDown += TbObservacao_KeyDown; // Última TextBox

            // Para o ComboBox
            cbFuncionarios.KeyDown += CbFuncionarios_KeyDown;

            // Para os botões
            btnAdicionar.KeyDown += BtnAdicionar_KeyDown;
            btnCancelar.KeyDown += BtnCancelar_KeyDown;
        }

        private void FormAddEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                var currentTextBox = sender as TextBox;
                if (currentTextBox == tbObservacao)
                {
                    // Última TextBox: verificar se ComboBox está preenchido
                    if (cbFuncionarios.SelectedItem != null)
                    {
                        // Se já tem funcionário selecionado, executar ação direto
                        BtnAdicionar_Click(btnAdicionar, EventArgs.Empty);
                    }
                    else
                    {
                        // Se não tem funcionário, focar no ComboBox
                        cbFuncionarios.Focus();
                        cbFuncionarios.DroppedDown = true;
                    }
                }
                else
                {
                    // Outras TextBoxes: ir para próxima
                    this.SelectNextControl(currentTextBox, true, true, true, true);
                    if (this.ActiveControl is TextBox nextTextBox)
                    {
                        nextTextBox.SelectAll();
                    }
                }
            }
        }

        private void TbObservacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Verificar se ComboBox está preenchido
                if (cbFuncionarios.SelectedItem != null)
                {
                    // Se já tem funcionário selecionado, executar ação direto
                    BtnAdicionar_Click(btnAdicionar, EventArgs.Empty);
                }
                else
                {
                    // Se não tem funcionário, focar no ComboBox
                    cbFuncionarios.Focus();
                    cbFuncionarios.DroppedDown = true;
                }
            }
        }

        private void CbFuncionarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (cbFuncionarios.DroppedDown)
                {
                    cbFuncionarios.DroppedDown = false;
                }

                // Do ComboBox, executar ação direto
                BtnAdicionar_Click(btnAdicionar, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Escape && cbFuncionarios.DroppedDown)
            {
                e.SuppressKeyPress = true;
                cbFuncionarios.DroppedDown = false;
            }
        }

        private void BtnAdicionar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnAdicionar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
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
                    string nome = reader["NOME"]?.ToString();
                    if (!string.IsNullOrEmpty(nome))
                        cbFuncionarios.Items.Add(nome);
                }

                // Começa vazio, sem nenhum item selecionado
                cbFuncionarios.SelectedIndex = -1;

                if (cbFuncionarios.Items.Count == 0)
                {
                    MessageBox.Show("Nenhum funcionário cadastrado no sistema!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                cbFuncionarios.Items.Clear();
                cbFuncionarios.SelectedIndex = -1;
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDAÇÕES: todos os campos obrigatórios e tipos corretos
                string nomeRaw = tbNome.Text ?? "";
                string marcaRaw = tbMarca.Text ?? "";
                string observacaoRaw = tbObservacao.Text ?? "";

                string nome = nomeRaw.Trim().ToUpper();
                string marca = marcaRaw.Trim().ToUpper();
                string observacao = observacaoRaw.Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show("Preencha o campo Nome do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbNome.Focus();
                    tbNome.SelectAll();
                    return;
                }

                if (string.IsNullOrWhiteSpace(marca))
                {
                    MessageBox.Show("Preencha o campo Marca do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbMarca.Focus();
                    tbMarca.SelectAll();
                    return;
                }

                // Tenta parse do preço usando o formato brasileiro (aceita "R$ 1.234,56" ou "1234,56")
                decimal preco;
                bool precoParseOk = decimal.TryParse(
                    tbPreco.Text,
                    NumberStyles.Currency,
                    CultureInfo.GetCultureInfo("pt-BR"),
                    out preco
                );

                if (!precoParseOk)
                {
                    // Tenta um fallback removendo "R$" e usando invariant (caso o usuário tenha digitado com . e , trocados)
                    string precoFallback = tbPreco.Text.Replace("R$", "").Replace(" ", "").Replace(".", "").Replace(",", ".");
                    precoParseOk = decimal.TryParse(precoFallback, NumberStyles.Any, CultureInfo.InvariantCulture, out preco);
                }

                if (!precoParseOk || preco < 0m)
                {
                    MessageBox.Show("Preço inválido. Insira um valor válido (ex: R$ 12,34).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPreco.Focus();
                    tbPreco.SelectAll();
                    return;
                }

                // Quantidade a adicionar (obrigatória e > 0)
                if (!int.TryParse(tbQEstoque.Text.Trim(), out int qtdAdicional) || qtdAdicional <= 0)
                {
                    MessageBox.Show("Informe uma quantidade válida para adicionar (inteiro maior que 0).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbQEstoque.Focus();
                    tbQEstoque.SelectAll();
                    return;
                }

                // Quantidade de aviso (obrigatória; pode ser zero)
                if (!int.TryParse(tbQAviso.Text.Trim(), out int qtdAviso) || qtdAviso < 0)
                {
                    MessageBox.Show("Informe uma quantidade de aviso válida (inteiro >= 0).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbQAviso.Focus();
                    tbQAviso.SelectAll();
                    return;
                }

                // Funcionário selecionado
                if (cbFuncionarios.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um funcionário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbFuncionarios.Focus();
                    cbFuncionarios.DroppedDown = true;
                    return;
                }

                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                string nomeFuncionario = cbFuncionarios.SelectedItem!.ToString()!;
                int idProdutoAfetado;

                if (ProdutoSelecionado != null)
                {
                    // Atualiza produto existente: exige que tbNome e tbMarca confiram com o produto selecionado?
                    // Aqui apenas atualiza o estoque mantendo os dados já existentes do produto.
                    using var cmdSelect = new SQLiteCommand("SELECT QTD_ESTOQUE FROM PRODUTO WHERE ID_PRODUTO = @ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", ProdutoSelecionado.Value.Id);
                    object scalar = cmdSelect.ExecuteScalar();
                    int estoqueAtual = 0;
                    if (scalar != null && int.TryParse(scalar.ToString(), out int parsedEst))
                        estoqueAtual = parsedEst;

                    int novaQuantidade = estoqueAtual + qtdAdicional;

                    string sqlUpdate = "UPDATE PRODUTO SET QTD_ESTOQUE = @QTD_ESTOQUE, QTD_AVISO = @QTD_AVISO WHERE ID_PRODUTO = @ID;";
                    using var cmd = new SQLiteCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@QTD_ESTOQUE", novaQuantidade);
                    cmd.Parameters.AddWithValue("@QTD_AVISO", qtdAviso);
                    cmd.Parameters.AddWithValue("@ID", ProdutoSelecionado.Value.Id);
                    cmd.ExecuteNonQuery();

                    idProdutoAfetado = ProdutoSelecionado.Value.Id;
                }
                else
                {
                    // Antes de inserir, checar duplicado similar (comparação com igualdade simples)
                    string sqlCheck = @"
                        SELECT COUNT(*) FROM PRODUTO
                        WHERE UPPER(NOME) = @NOME AND UPPER(MARCA) = @MARCA
                          AND PRECO = @PRECO AND UPPER(COALESCE(OBSERVACAO, '')) = UPPER(COALESCE(@OBSERVACAO, ''))
                    ";
                    using var cmdCheck = new SQLiteCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@NOME", nome);
                    cmdCheck.Parameters.AddWithValue("@MARCA", marca);
                    cmdCheck.Parameters.AddWithValue("@PRECO", preco);
                    cmdCheck.Parameters.AddWithValue("@OBSERVACAO", observacao);
                    long existe = (long)cmdCheck.ExecuteScalar();
                    if (existe > 0)
                    {
                        MessageBox.Show("Esse produto já está cadastrado (verifique nome/marca/preço/observação).", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbNome.Focus();
                        tbNome.SelectAll();
                        return;
                    }

                    string sqlInsert = @"
                        INSERT INTO PRODUTO (NOME, MARCA, PRECO, QTD_ESTOQUE, QTD_AVISO, OBSERVACAO)
                        VALUES (@NOME, @MARCA, @PRECO, @QTD_ESTOQUE, @QTD_AVISO, @OBSERVACAO);
                    ";
                    using var cmd = new SQLiteCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@NOME", nome);
                    cmd.Parameters.AddWithValue("@MARCA", marca);
                    cmd.Parameters.AddWithValue("@PRECO", preco);
                    cmd.Parameters.AddWithValue("@QTD_ESTOQUE", qtdAdicional);
                    cmd.Parameters.AddWithValue("@QTD_AVISO", qtdAviso);
                    cmd.Parameters.AddWithValue("@OBSERVACAO", observacao);
                    cmd.ExecuteNonQuery();

                    idProdutoAfetado = (int)conn.LastInsertRowId;
                }

                string sqlMov = @"
                    INSERT INTO MOVIMENTACAO_ESTOQUE 
                    (ID_PRODUTO, NOME_FUNCIONARIO, TIPO_MOVIMENTACAO, QUANTIDADE, DATA_HORA)
                    VALUES (@idProd, @func, 'ENTRADA', @qtd, strftime('%d-%m-%Y %H:%M','now','localtime'));
                ";
                DatabaseHelper.ExecuteNonQuery(sqlMov, new SQLiteParameter[]
                {
                    new SQLiteParameter("@idProd", idProdutoAfetado),
                    new SQLiteParameter("@func", nomeFuncionario),
                    new SQLiteParameter("@qtd", qtdAdicional)
                });

                MessageBox.Show("Produto adicionado/atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarEstoqueCallback?.Invoke();
                LimparCampos();

                // Volta o foco para o primeiro campo após limpar
                tbNome.Focus();
                tbNome.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        private void TbPreco_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoPreco) return;
            _ignorarEventoPreco = true;

            string numeros = "";
            foreach (char c in tbPreco.Text)
                if (char.IsDigit(c)) numeros += c;

            if (numeros == "") numeros = "0";

            decimal valor = decimal.Parse(numeros) / 100m;
            if (valor > 1000000m) valor = 1000000m;

            tbPreco.Text = "R$ " + valor.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
            tbPreco.SelectionStart = tbPreco.Text.Length;
            _ignorarEventoPreco = false;
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
            if (tb.Text.Length >= 6 && e.KeyChar != (char)Keys.Back) e.Handled = true; // deixa 6 dígitos no máximo
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LimparCampos()
        {
            tbNome.Text = "";
            tbMarca.Text = "";
            tbPreco.Text = "R$ 0,00";
            tbQEstoque.Text = "";
            tbQAviso.Text = "";
            tbObservacao.Text = "";

            lbQuantidadeAtual.Visible = false;

            if (cbFuncionarios.Items.Count > 0)
                cbFuncionarios.SelectedIndex = 0;

            ProdutoSelecionado = null;
        }

        private void CbFuncionarios_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            string texto = cbFuncionarios.Items[e.Index].ToString() ?? "";
            e.DrawBackground();
            using (var brush = new SolidBrush(Color.White))
                e.Graphics.DrawString(texto, e.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}