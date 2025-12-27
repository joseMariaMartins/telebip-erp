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
    public partial class FormEditarProduto : MaterialForm
    {
        private bool _ignorarEventoPreco = false;

        private int _idProduto;
        private int _quantidadeAtual;
        public Action? AtualizarEstoqueCallback { get; set; }

        public FormEditarProduto()
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
                if (cbFuncionarios.SelectedItem == null)
                {
                    MessageBox.Show("Selecione o funcionário responsável pela edição.");
                    cbFuncionarios.Focus();
                    return;
                }

                string nome = tbNome.Text.Trim().ToUpper();
                string marca = tbMarca.Text.Trim().ToUpper();
                string observacao = tbObservacao.Text.Trim().ToUpper();
                string funcionario = cbFuncionarios.SelectedItem.ToString()!;

                if (!decimal.TryParse(
                    tbPreco.Text,
                    NumberStyles.Currency,
                    CultureInfo.GetCultureInfo("pt-BR"),
                    out decimal preco
                ))
                {
                    MessageBox.Show("Preço inválido.");
                    return;
                }

                if (!int.TryParse(tbQAviso.Text, out int qtdAviso) || qtdAviso < 0)
                {
                    MessageBox.Show("Quantidade de aviso inválida.");
                    return;
                }

                int qtdAdicionar = 0;
                if (!string.IsNullOrWhiteSpace(tbQEstoque.Text))
                {
                    if (!int.TryParse(tbQEstoque.Text, out qtdAdicionar) || qtdAdicionar < 0)
                    {
                        MessageBox.Show("Quantidade inválida.");
                        return;
                    }
                }

                int novaQuantidade = _quantidadeAtual + qtdAdicionar;

                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                // 🔹 Atualiza o produto
                string sqlUpdate = @"
            UPDATE PRODUTO
            SET 
                NOME = @NOME,
                MARCA = @MARCA,
                PRECO = @PRECO,
                QTD_ESTOQUE = @QTD_ESTOQUE,
                QTD_AVISO = @QTD_AVISO,
                OBSERVACAO = @OBS
            WHERE ID_PRODUTO = @ID;
        ";

                using (var cmd = new SQLiteCommand(sqlUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@NOME", nome);
                    cmd.Parameters.AddWithValue("@MARCA", marca);
                    cmd.Parameters.AddWithValue("@PRECO", preco);
                    cmd.Parameters.AddWithValue("@QTD_ESTOQUE", novaQuantidade);
                    cmd.Parameters.AddWithValue("@QTD_AVISO", qtdAviso);
                    cmd.Parameters.AddWithValue("@OBS", observacao);
                    cmd.Parameters.AddWithValue("@ID", _idProduto);
                    cmd.ExecuteNonQuery();
                }

                // 🔹 Registra movimentação MANUAL (com funcionário)
                if (qtdAdicionar > 0)
                {
                    string sqlMov = @"
                INSERT INTO MOVIMENTACAO_ESTOQUE
                (ID_PRODUTO, ID_VENDA, NOME_FUNCIONARIO, TIPO_MOVIMENTACAO, QUANTIDADE, DATA_HORA)
                VALUES
                (@idProd, NULL, @func, 'ENTRADA', @qtd, strftime('%d-%m-%Y %H:%M','now','localtime'));
            ";

                    DatabaseHelper.ExecuteNonQuery(sqlMov, new SQLiteParameter[]
                    {
                new("@idProd", _idProduto),
                new("@func", funcionario),
                new("@qtd", qtdAdicionar)
                    });
                }

                MessageBox.Show("Produto editado com sucesso!", "Sucesso");

                AtualizarEstoqueCallback?.Invoke();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar produto: " + ex.Message);
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

        public void CarregarProduto(
    int id,
    string nome,
    string marca,
    decimal preco,
    int quantidadeAtual,
    int qtdAviso,
    string observacao
)
        {
            _idProduto = id;
            _quantidadeAtual = quantidadeAtual;

            tbNome.Text = nome;
            tbMarca.Text = marca;
            tbPreco.Text = "R$ " + preco.ToString("N2");
            tbQAviso.Text = qtdAviso.ToString();
            tbObservacao.Text = observacao;

            tbQEstoque.Text = ""; // quantidade a SOMAR

            lbQuantidadeAtual.Text = $"Quantidade atual: {quantidadeAtual}";
            lbQuantidadeAtual.Visible = true;
        }

    }
}