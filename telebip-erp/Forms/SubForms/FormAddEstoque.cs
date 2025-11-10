using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin;
using System.Drawing;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddEstoque : MaterialSkin.Controls.MaterialForm
    {
        private bool _ignorarEventoPreco = false;
        public (int Id, string Nome, int Quantidade)? ProdutoSelecionado { get; set; }
        public Action? AtualizarEstoqueCallback { get; set; }

        public FormAddEstoque()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

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

            this.Load += (s, e) => CarregarFuncionarios();
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
                // opcional: se quiser preencher com ADMIN apenas se der erro de conexão
                // cbFuncionarios.Items.Add("ADMINISTRADOR");
                cbFuncionarios.SelectedIndex = -1; // Começa vazio mesmo
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text.Trim().ToUpper();
                string marca = tbMarca.Text.Trim().ToUpper();
                string observacao = tbObservacao.Text.Trim().ToUpper();

                string precoTexto = tbPreco.Text.Replace("R$", "").Replace(".", "").Replace(",", ".");
                if (!decimal.TryParse(precoTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco))
                {
                    MessageBox.Show("Preço inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(tbQEstoque.Text, out int qtdAdicional) || qtdAdicional <= 0)
                {
                    MessageBox.Show("Informe uma quantidade válida para adicionar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(tbQAviso.Text, out int qtdAviso))
                {
                    MessageBox.Show("Quantidade de aviso inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbFuncionarios.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um funcionário!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                string nomeFuncionario = cbFuncionarios.SelectedItem!.ToString()!;
                int idProdutoAfetado;

                if (ProdutoSelecionado != null)
                {
                    using var cmdSelect = new SQLiteCommand("SELECT QTD_ESTOQUE FROM PRODUTO WHERE ID_PRODUTO = @ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", ProdutoSelecionado.Value.Id);
                    int estoqueAtual = Convert.ToInt32(cmdSelect.ExecuteScalar());
                    int novaQuantidade = estoqueAtual + qtdAdicional;

                    string sqlUpdate = "UPDATE PRODUTO SET QTD_ESTOQUE = @QTD_ESTOQUE WHERE ID_PRODUTO = @ID;";
                    using var cmd = new SQLiteCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@QTD_ESTOQUE", novaQuantidade);
                    cmd.Parameters.AddWithValue("@ID", ProdutoSelecionado.Value.Id);
                    cmd.ExecuteNonQuery();

                    idProdutoAfetado = ProdutoSelecionado.Value.Id;
                }
                else
                {
                    string sqlCheck = @"
                        SELECT COUNT(*) FROM PRODUTO
                        WHERE UPPER(NOME) = @NOME AND UPPER(MARCA) = @MARCA
                        AND PRECO = @PRECO AND QTD_ESTOQUE = @QTD_ESTOQUE
                        AND QTD_AVISO = @QTD_AVISO AND UPPER(COALESCE(OBSERVACAO, '')) = UPPER(COALESCE(@OBSERVACAO, ''));
                    ";
                    using var cmdCheck = new SQLiteCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@NOME", nome);
                    cmdCheck.Parameters.AddWithValue("@MARCA", marca);
                    cmdCheck.Parameters.AddWithValue("@PRECO", preco);
                    cmdCheck.Parameters.AddWithValue("@QTD_ESTOQUE", qtdAdicional);
                    cmdCheck.Parameters.AddWithValue("@QTD_AVISO", qtdAviso);
                    cmdCheck.Parameters.AddWithValue("@OBSERVACAO", observacao);

                    long existe = (long)cmdCheck.ExecuteScalar();
                    if (existe > 0)
                    {
                        MessageBox.Show("Esse produto já está cadastrado!", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (tb.Text.Length >= 4 && e.KeyChar != (char)Keys.Back) e.Handled = true;
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
