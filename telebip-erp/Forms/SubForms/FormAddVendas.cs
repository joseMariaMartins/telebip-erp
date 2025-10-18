using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using telebip_erp.Forms.SubSubForms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddVendas : MaterialForm
    {
        private bool _ignorarEventoPrecoProduto = false;
        private bool _ignorarEventoDesconto = false;

        public FormAddVendas()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            ConfigurarMonetarios();
        }

        private void FormAddVendas_Load_1(object sender, EventArgs e)
        {
            CarregarFuncionarios();

            tbPrecoProduto.Text = "R$ 0,00";
            tbDesconto.Text = "R$ 0,00";

            mkDataHora.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
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

                cbFuncionariosVenda.Items.Clear();
                while (reader.Read())
                {
                    cbFuncionariosVenda.Items.Add(reader["NOME"].ToString());
                }

                cbFuncionariosVenda.SelectedIndex = -1; // Nenhum selecionado por padrão
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        private void ConfigurarMonetarios()
        {
            // tbPrecoProduto
            tbPrecoProduto.KeyPress -= TbPreco_KeyPress;
            tbPrecoProduto.KeyPress += TbPreco_KeyPress;

            tbPrecoProduto.TextChanged -= TbPrecoProduto_TextChanged;
            tbPrecoProduto.TextChanged += TbPrecoProduto_TextChanged;

            // tbDesconto
            tbDesconto.KeyPress -= TbPreco_KeyPress;
            tbDesconto.KeyPress += TbPreco_KeyPress;

            tbDesconto.TextChanged -= TbDesconto_TextChanged;
            tbDesconto.TextChanged += TbDesconto_TextChanged;
        }

        private void TbPrecoProduto_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoPrecoProduto) return;

            _ignorarEventoPrecoProduto = true;
            FormatarMonetario(tbPrecoProduto);
            AtualizarValorTotal();
            _ignorarEventoPrecoProduto = false;
        }

        private void TbDesconto_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoDesconto) return;

            _ignorarEventoDesconto = true;
            FormatarMonetario(tbDesconto);
            AtualizarValorTotal();
            _ignorarEventoDesconto = false;
        }

        private void FormatarMonetario(Guna.UI2.WinForms.Guna2TextBox tb)
        {
            string text = tb.Text;
            string numeros = "";
            foreach (char c in text)
                if (char.IsDigit(c))
                    numeros += c;

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

        private void tbNomeProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita o som padrão de Enter

                string nomeDigitado = tbNomeProduto.Text.ToUpper();
                tbNomeProduto.Text = nomeDigitado;
                tbNomeProduto.SelectionStart = tbNomeProduto.Text.Length;

                if (string.IsNullOrWhiteSpace(nomeDigitado))
                    return; // Nada a fazer se a caixa estiver vazia

                try
                {
                    using var conn = DatabaseHelper.GetConnection();
                    conn.Open();

                    string sql = "SELECT NOME, PRECO, QTD_ESTOQUE FROM PRODUTO WHERE NOME LIKE @nome LIMIT 1";
                    using var cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", nomeDigitado + "%");

                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Produto encontrado → preenche campos
                        tbNomeProduto.Text = reader["NOME"].ToString();
                        tbNomeProduto.SelectionStart = tbNomeProduto.Text.Length;

                        decimal preco = Convert.ToDecimal(reader["PRECO"]);
                        tbPrecoProduto.Text = "R$ " + preco.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));

                        int quantidade = Convert.ToInt32(reader["QTD_ESTOQUE"]);
                        lbQuantidadeAtual.Text = $"Quantidade atual: {quantidade}";

                        // Vai automaticamente para a próxima caixa de texto
                        this.SelectNextControl(tbNomeProduto, true, true, true, true);
                    }
                    else
                    {
                        // Produto não encontrado → mostra mensagem e não altera nada
                        MessageBox.Show("Produto não encontrado no sistema!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar produto: " + ex.Message);
                }
            }
        }

        private void btnMaisInformacao_CheckedChanged(object sender, EventArgs e)
        {
            if (btnMaisInformacao.Checked)
            {
                using var formAddProduto = new FormAddProdutoVendas();
                formAddProduto.Owner = this; // define o FormAddVendas como dono
                formAddProduto.ShowDialog();

                // desmarcar o botão após fechar
                btnMaisInformacao.Checked = false;
            }
        }


        public void PreencherProduto(string nomeProduto)
        {
            tbNomeProduto.Text = nomeProduto;
            // Dispara o evento de busca para preencher preço e quantidade
            tbNomeProduto_KeyDown(this.tbNomeProduto, new KeyEventArgs(Keys.Enter));
        }

        private void AtualizarValorTotal()
        {
            // Remove R$ e converte para decimal
            decimal preco = 0;
            decimal desconto = 0;

            decimal.TryParse(tbPrecoProduto.Text.Replace("R$", "").Trim(),
                             NumberStyles.Currency,
                             CultureInfo.GetCultureInfo("pt-BR"),
                             out preco);

            decimal.TryParse(tbDesconto.Text.Replace("R$", "").Trim(),
                             NumberStyles.Currency,
                             CultureInfo.GetCultureInfo("pt-BR"),
                             out desconto);

            decimal valorTotal = preco - desconto;
            if (valorTotal < 0) valorTotal = 0; // evita valor negativo

            lbValorTotal.Text = "R$ " + valorTotal.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
        }

        private void tbPrecoProduto_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
