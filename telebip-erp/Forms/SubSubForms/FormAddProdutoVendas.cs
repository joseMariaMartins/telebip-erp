using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Linq;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.SubSubForms
{
    public partial class FormAddProdutoVendas : MaterialForm
    {
        private readonly Dictionary<string, string> campoMap = new Dictionary<string, string>
        {
            { "ID", "ID_PRODUTO" },
            { "Nome", "NOME" },
            { "Marca", "MARCA" },
            { "Preço", "PRECO" },
            { "Qtd do estoque", "QTD_ESTOQUE" },
            { "Qtd de aviso", "QTD_AVISO" },
            { "Observação", "OBSERVACAO" }
        };

        public FormAddProdutoVendas()
        {
            InitializeComponent();
            ConfigurarComboboxes();
            ThemeManager.ApplyDarkTheme();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Text = "Adicionar Produto";

            // Eventos
            btnPesquisarMini.Click += BtnPesquisar_Click;
            btnLimparMini.Click += BtnLimpar_Click;
            dgvProdutosMini.CellDoubleClick += DgvProdutosMini_CellDoubleClick;

            CarregarProdutosInicial();

            this.Shown += (s, e) =>
            {
                dgvProdutosMini.ClearSelection();
                dgvProdutosMini.CurrentCell = null;
            };
        }

        private void ConfigurarComboboxes()
        {
            cbPesquisaCampoMini.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicaoMini.DropDownStyle = ComboBoxStyle.DropDownList;

            // Itens com nomes amigáveis
            cbPesquisaCampoMini.Items.Clear();
            cbPesquisaCampoMini.Items.AddRange(new object[]
            {
                "ID",
                "Nome",
                "Marca",
                "Preço",
                "Qtd do estoque",
                "Qtd de aviso",
                "Observação"
            });

            cbPesquisaCampoMini.SelectedIndex = 0;
            cbCondicaoMini.SelectedIndex = 0;
        }

        public void CarregarProdutos(string filtroSql = "", SQLiteParameter[]? parametros = null, bool limitar20 = false)
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
                    WHERE ID_PRODUTO NOT IN (SELECT ID_PRODUTO FROM PRODUTOS_TEMPORARIOS)
                    {(string.IsNullOrEmpty(filtroSql) ? "" : "AND " + filtroSql)}
                    ORDER BY ID_PRODUTO DESC
                    {(limitar20 ? "LIMIT 20" : "")};
                ";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                dgvProdutosMini.DataSource = dt;

                // Cabeçalhos personalizados
                dgvProdutosMini.Columns["ID_PRODUTO"].HeaderText = "ID";
                dgvProdutosMini.Columns["NOME"].HeaderText = "Nome";
                dgvProdutosMini.Columns["MARCA"].HeaderText = "Marca";
                dgvProdutosMini.Columns["PRECO"].HeaderText = "Preço";
                dgvProdutosMini.Columns["QTD_ESTOQUE"].HeaderText = "Qtd do estoque";
                dgvProdutosMini.Columns["QTD_AVISO"].HeaderText = "Qtd de aviso";
                dgvProdutosMini.Columns["OBSERVACAO"].HeaderText = "Observação";

                foreach (DataGridViewColumn coluna in dgvProdutosMini.Columns)
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvProdutosMini.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dgvProdutosMini.Columns.Contains("OBSERVACAO"))
                    dgvProdutosMini.Columns["OBSERVACAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvProdutosMini.Columns["ID_PRODUTO"].Width = 100;
                dgvProdutosMini.Columns["NOME"].Width = 150;
                dgvProdutosMini.Columns["MARCA"].Width = 95;
                dgvProdutosMini.Columns["PRECO"].Width = 70;
                dgvProdutosMini.Columns["QTD_ESTOQUE"].Width = 100;
                dgvProdutosMini.Columns["QTD_AVISO"].Width = 100;

                dgvProdutosMini.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutosMini.Columns["PRECO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutosMini.Columns["QTD_ESTOQUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutosMini.Columns["QTD_AVISO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutosMini.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvProdutosMini.Columns["MARCA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutosMini.Columns["OBSERVACAO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (dgvProdutosMini.Columns.Contains("PRECO"))
                    dgvProdutosMini.Columns["PRECO"].DefaultCellStyle.Format = "C2";

                dgvProdutosMini.ClearSelection();
                dgvProdutosMini.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarProdutosInicial()
        {
            CarregarProdutos(limitar20: true);
        }

        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            if (cbPesquisaCampoMini.SelectedItem == null || cbCondicaoMini.SelectedItem == null)
            {
                MessageBox.Show("Selecione o campo e a condição de pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campoExibicao = cbPesquisaCampoMini.SelectedItem.ToString()!;
            string campoBanco = campoMap.ContainsKey(campoExibicao) ? campoMap[campoExibicao] : campoExibicao;
            string condicao = cbCondicaoMini.SelectedItem.ToString()!;
            string valor = tbPesquisaMini.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Digite um termo para pesquisar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtroSql = "";
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Inicia com":
                    filtroSql = $"UPPER({campoBanco}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor + "%") };
                    break;
                case "Contendo":
                    filtroSql = $"UPPER({campoBanco}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", "%" + valor + "%") };
                    break;
                case "Diferente de":
                    filtroSql = $"UPPER({campoBanco}) <> UPPER(@valor)";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    break;
                default:
                    MessageBox.Show("Condição de pesquisa inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            CarregarProdutos(filtroSql, parametros, limitar20: false);
        }

        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            tbPesquisaMini.Text = "";
            cbPesquisaCampoMini.SelectedIndex = 0;
            cbCondicaoMini.SelectedIndex = 0;

            CarregarProdutos(limitar20: true);

            dgvProdutosMini.ClearSelection();
            dgvProdutosMini.CurrentCell = null;
        }

        private void DgvProdutosMini_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora cabeçalho

            var linha = dgvProdutosMini.Rows[e.RowIndex];
            string nomeProduto = linha.Cells["NOME"].Value?.ToString() ?? "";
            int idProduto = Convert.ToInt32(linha.Cells["ID_PRODUTO"].Value);

            if (!string.IsNullOrEmpty(nomeProduto))
            {
                FormAddVendas formVendas = this.Owner as FormAddVendas;
                if (formVendas != null)
                {
                    formVendas.PreencherProduto(nomeProduto, idProduto);
                    this.Close();
                }
            }
        }
    }
}
