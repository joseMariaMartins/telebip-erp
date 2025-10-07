using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormEstoque : Form
    {
        public FormEstoque()
        {
            InitializeComponent();
            ConfiguracoesCombobox();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Evento do botão pesquisar
            btnPesquisar.Click += BtnPesquisar_Click;
        }

        // Configura os combobox
        private void ConfiguracoesCombobox()
        {
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;

            cbPesquisaCampo.SelectedIndex = 0; // Seleciona o primeiro campo
            cbCondicao.SelectedIndex = 0;      // Seleciona a primeira condição
        }

        // Carrega os dados no DataGridView de acordo com o filtro
        private void CarregarEstoque(string filtroSql = "", SQLiteParameter[]? parametros = null)
        {
            try
            {
                // Se não houver filtro, não carrega nada
                if (string.IsNullOrEmpty(filtroSql))
                {
                    dgvEstoque.DataSource = null;
                    return;
                }

                // Especifica as colunas que serão exibidas (exceto QUANTIDADE_AVISO)
                string sql = $@"
            SELECT 
                ID_PRODUTO,
                NOME,
                MARCA,
                PRECO,
                QTD_ESTOQUE,
                OBSERVACAO
            FROM PRODUTO
            WHERE {filtroSql};
        ";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);

                dgvEstoque.DataSource = dt;
                dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message);
            }
        }

        // Evento do botão pesquisar
        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            string campo = cbPesquisaCampo.SelectedItem.ToString();
            string condicao = cbCondicao.SelectedItem.ToString();
            string valor = tbPesquisa.Text.ToUpper(); // deixa sempre em maiúsculo

            string filtroSql = "";
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Inicia com":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@valor", valor + "%")
                    };
                    break;

                case "Contendo":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@valor", "%" + valor + "%")
                    };
                    break;

                case "Diferente de":
                    filtroSql = $"UPPER({campo}) <> @valor";
                    parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@valor", valor)
                    };
                    break;

                default:
                    MessageBox.Show("Condição de pesquisa inválida.");
                    return;
            }

            CarregarEstoque(filtroSql, parametros);
        }

        // Obtém o produto selecionado no DataGridView
        public (int Id, string Nome, int Quantidade)? ObterProdutoSelecionado()
        {
            if (dgvEstoque.CurrentRow == null)
                return null;

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
    }
}
