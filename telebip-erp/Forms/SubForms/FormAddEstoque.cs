using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin;
using Guna.UI2.WinForms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddEstoque : MaterialSkin.Controls.MaterialForm
    {
        private bool _ignorarEventoPreco = false;

        public FormAddEstoque()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();
            CarregarFuncionarios();

            // Inicializa o preço com R$ 0,00
            tbPreco.Text = "R$ 0,00";
            tbPreco.SelectionStart = tbPreco.Text.Length;

            // Eventos
            tbPreco.KeyPress += TbPreco_KeyPress;
            tbPreco.TextChanged += TbPreco_TextChanged;

            tbQEstoque.KeyPress += OnlyNumbers_KeyPress;
            tbQAviso.KeyPress += OnlyNumbers_KeyPress;
        }

        private void CarregarFuncionarios()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT NOME FROM FUNCIONARIO ORDER BY NOME;";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cbFuncionarios.Items.Clear();
                        while (reader.Read())
                            cbFuncionarios.Items.Add(reader["NOME"].ToString());
                    }
                }

                if (cbFuncionarios.Items.Count > 0)
                    cbFuncionarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        // ==================== Preço ====================
        private void TbPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Só permite números e backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TbPreco_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoPreco) return;

            _ignorarEventoPreco = true;

            string text = tbPreco.Text;

            // Remove tudo que não é número
            string numeros = "";
            foreach (char c in text)
                if (char.IsDigit(c))
                    numeros += c;

            if (numeros == "") numeros = "0";

            // Converte para decimal, considerando 2 casas decimais
            decimal valor = decimal.Parse(numeros) / 100m;

            if (valor > 1000000m) valor = 1000000m;

            // Atualiza textbox com formato moeda
            tbPreco.Text = "R$ " + valor.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
            tbPreco.SelectionStart = tbPreco.Text.Length;

            _ignorarEventoPreco = false;
        }

        // ==================== Quantidades ====================
        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna2TextBox tb = sender as Guna2TextBox;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            // Limite de 9999
            if (tb.Text.Length >= 4 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
