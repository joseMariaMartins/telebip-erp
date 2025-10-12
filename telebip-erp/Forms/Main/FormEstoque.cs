using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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

            // Eventos
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            CarregarEstoqueInicial();

            // 🔹 Garantir que nada fique selecionado ao abrir
            this.Shown += (s, e) =>
            {
                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;
            };
        }

        private void ConfiguracoesCombobox()
        {
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;

            cbPesquisaCampo.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;
        }

        private void AtualizarTotalItens()
        {
            lbTotal.Text = $"Total de itens: {dgvEstoque.Rows.Count}";
        }

        public void CarregarEstoque(string filtroSql = "", SQLiteParameter[]? parametros = null, bool limitar20 = false)
        {
            try
            {
                string sql = $@"
                    SELECT 
                        ID_PRODUTO,
                        NOME,
                        MARCA,
                        PRECO,
                        QTD_ESTOQUE,
                        QTD_AVISO,
                        OBSERVACAO
                    FROM PRODUTO
                    {(string.IsNullOrEmpty(filtroSql) ? "" : "WHERE " + filtroSql)}
                    ORDER BY ID_PRODUTO
                    {(limitar20 ? "LIMIT 20" : "")};
                ";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                dgvEstoque.DataSource = dt;

                // Cabeçalhos centralizados
                foreach (DataGridViewColumn coluna in dgvEstoque.Columns)
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvEstoque.Columns["OBSERVACAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvEstoque.Columns["ID_PRODUTO"].Width = 85;
                dgvEstoque.Columns["NOME"].Width = 150;
                dgvEstoque.Columns["MARCA"].Width = 95;
                dgvEstoque.Columns["PRECO"].Width = 70;
                dgvEstoque.Columns["QTD_ESTOQUE"].Width = 100;
                dgvEstoque.Columns["QTD_AVISO"].Width = 80;

                dgvEstoque.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["PRECO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvEstoque.Columns["QTD_ESTOQUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEstoque.Columns["QTD_AVISO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvEstoque.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvEstoque.Columns["MARCA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvEstoque.Columns["OBSERVACAO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvEstoque.RowsDefaultCellStyle.BackColor = Color.White;
                dgvEstoque.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

                dgvEstoque.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEstoque.MultiSelect = false;
                dgvEstoque.ReadOnly = true;

                // 🔹 Remove seleção automática da primeira linha
                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message);
            }
        }

        private void CarregarEstoqueInicial()
        {
            CarregarEstoque(limitar20: true);
        }

        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            string campo = cbPesquisaCampo.SelectedItem.ToString();
            string condicao = cbCondicao.SelectedItem.ToString();
            string valor = tbPesquisa.Text.ToUpper();

            string filtroSql = "";
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Inicia com":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor + "%") };
                    break;
                case "Contendo":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", "%" + valor + "%") };
                    break;
                case "Diferente de":
                    filtroSql = $"UPPER({campo}) <> @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    break;
                default:
                    MessageBox.Show("Condição de pesquisa inválida.");
                    return;
            }

            CarregarEstoque(filtroSql, parametros, limitar20: false);
        }

        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            tbPesquisa.Text = "";
            cbPesquisaCampo.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;

            CarregarEstoque(limitar20: true);

            // 🔹 Limpa seleção ao clicar em limpar
            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;
        }

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

        public DataGridViewRow? ObterLinhaSelecionada()
        {
            return dgvEstoque.CurrentRow;
        }

    }
}
