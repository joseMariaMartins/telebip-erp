using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using telebip_erp.Forms.SubForms;
using telebip_erp.Controls; // caso precise referenciar RoundedPanel (opcional)

namespace telebip_erp.Forms.Modules
{
    public partial class FormVendas : Form
    {
        // Mapeamento entre os nomes exibidos e os nomes no banco
        private readonly Dictionary<string, string> campoMap = new Dictionary<string, string>
        {
            { "ID", "ID_VENDA" },
            { "Funcionário", "NOME_FUNCIONARIO" },
            { "Data", "DATA_HORA" },
            { "Valor total", "VALOR_TOTAL" },
            { "Desconto", "DESCONTO" }
        };

        public FormVendas()
        {
            InitializeComponent();
            ConfigurarComboboxes();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Eventos dos botões (Cuore)
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            // Eventos dos wrappers para imitar o comportamento do Guna
            ConfigurarWrappers();

            this.Shown += (s, e) =>
            {
                dgvVendas.ClearSelection();
                dgvVendas.CurrentCell = null;
            };

            // Carrega as últimas 20 vendas
            CarregarVendas(limitar20: true);
        }

        private void ConfigurarComboboxes()
        {
            // Os ComboBoxes do designer já possuem itens; garante estilo WinForms
            try
            {
                cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;

                if (cbPesquisaCampo.Items.Count > 0) cbPesquisaCampo.SelectedIndex = 0;
                if (cbCondicao.Items.Count > 0) cbCondicao.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao configurar comboboxes: " + ex.Message);
            }
        }

        private void ConfigurarWrappers()
        {
            // Quando o usuário clicar no wrapper queremos abrir o dropdown / focar o textbox
            try
            {
                // wrapper campo
                pnlWrapperCampo.Click += (s, e) =>
                {
                    cbPesquisaCampo.Focus();
                    cbPesquisaCampo.DroppedDown = true;
                };
                // wrapper condicao
                pnlWrapperCondicao.Click += (s, e) =>
                {
                    cbCondicao.Focus();
                    cbCondicao.DroppedDown = true;
                };
                // wrapper pesquisa
                pnlWrapperPesquisa.Click += (s, e) => tbPesquisa.Focus();

                // caso o usuário clique diretamente no ComboBox, deixa o comportamento normal
                cbPesquisaCampo.Click += (s, e) => cbPesquisaCampo.DroppedDown = true;
                cbCondicao.Click += (s, e) => cbCondicao.DroppedDown = true;
            }
            catch { /* não criticar falhas visuais aqui */ }
        }

        private void AtualizarTotalItens()
        {
            lbTotal.Text = $"Total de vendas: {dgvVendas.Rows.Count}";
        }

        public void AtualizarTabela()
        {
            try
            {
                if (!string.IsNullOrEmpty(tbPesquisa.Text.Trim()))
                    BtnPesquisar_Click(null, EventArgs.Empty);
                else
                    CarregarVendas(limitar20: true);

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar tabela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarVendas(string filtroSql = "", SQLiteParameter[]? parametros = null, bool limitar20 = false)
        {
            try
            {
                string sql = $@"
                    SELECT 
                        ID_VENDA,
                        NOME_FUNCIONARIO,
                        DATA_HORA,
                        VALOR_TOTAL,
                        DESCONTO
                    FROM VENDA
                    {(string.IsNullOrEmpty(filtroSql) ? "" : "WHERE " + filtroSql)}
                    ORDER BY ID_VENDA DESC
                    {(limitar20 ? "LIMIT 20" : "")};
                ";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                dgvVendas.DataSource = dt;

                // 🔹 Renomeia cabeçalhos (se existirem)
                if (dgvVendas.Columns.Contains("ID_VENDA"))
                    dgvVendas.Columns["ID_VENDA"].HeaderText = "ID";
                if (dgvVendas.Columns.Contains("NOME_FUNCIONARIO"))
                    dgvVendas.Columns["NOME_FUNCIONARIO"].HeaderText = "Funcionário";
                if (dgvVendas.Columns.Contains("DATA_HORA"))
                    dgvVendas.Columns["DATA_HORA"].HeaderText = "Data";
                if (dgvVendas.Columns.Contains("VALOR_TOTAL"))
                    dgvVendas.Columns["VALOR_TOTAL"].HeaderText = "Valor total";
                if (dgvVendas.Columns.Contains("DESCONTO"))
                    dgvVendas.Columns["DESCONTO"].HeaderText = "Desconto";

                // 🔹 Centraliza cabeçalhos
                foreach (DataGridViewColumn coluna in dgvVendas.Columns)
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 🔹 Ajusta para preencher a tela
                dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 🔹 Pesos das colunas (se existirem)
                if (dgvVendas.Columns.Contains("ID_VENDA")) dgvVendas.Columns["ID_VENDA"].FillWeight = 15;
                if (dgvVendas.Columns.Contains("NOME_FUNCIONARIO")) dgvVendas.Columns["NOME_FUNCIONARIO"].FillWeight = 30;
                if (dgvVendas.Columns.Contains("DATA_HORA")) dgvVendas.Columns["DATA_HORA"].FillWeight = 25;
                if (dgvVendas.Columns.Contains("VALOR_TOTAL")) dgvVendas.Columns["VALOR_TOTAL"].FillWeight = 15;
                if (dgvVendas.Columns.Contains("DESCONTO")) dgvVendas.Columns["DESCONTO"].FillWeight = 15;

                // 🔹 Alinhamento de conteúdo
                if (dgvVendas.Columns.Contains("ID_VENDA")) dgvVendas.Columns["ID_VENDA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgvVendas.Columns.Contains("NOME_FUNCIONARIO")) dgvVendas.Columns["NOME_FUNCIONARIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (dgvVendas.Columns.Contains("DATA_HORA")) dgvVendas.Columns["DATA_HORA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgvVendas.Columns.Contains("VALOR_TOTAL")) dgvVendas.Columns["VALOR_TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgvVendas.Columns.Contains("DESCONTO")) dgvVendas.Columns["DESCONTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 🔹 Formatação monetária
                if (dgvVendas.Columns.Contains("VALOR_TOTAL")) dgvVendas.Columns["VALOR_TOTAL"].DefaultCellStyle.Format = "C2";
                if (dgvVendas.Columns.Contains("DESCONTO")) dgvVendas.Columns["DESCONTO"].DefaultCellStyle.Format = "C2";

                dgvVendas.ClearSelection();
                dgvVendas.CurrentCell = null;

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar vendas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            if (cbPesquisaCampo.SelectedItem == null || cbCondicao.SelectedItem == null)
            {
                MessageBox.Show("Selecione o campo e a condição de pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campoExibicao = cbPesquisaCampo.SelectedItem.ToString()!;
            string campoBanco = campoMap.ContainsKey(campoExibicao) ? campoMap[campoExibicao] : campoExibicao;
            string condicao = cbCondicao.SelectedItem.ToString()!;
            string valor = tbPesquisa.Text.Trim().ToUpper();

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
                    filtroSql = $"UPPER({campoBanco}) NOT LIKE UPPER(@valor)";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor + "%") };
                    break;
                default:
                    MessageBox.Show("Condição de pesquisa inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            CarregarVendas(filtroSql, parametros, limitar20: false);
        }

        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            try
            {
                tbPesquisa.Text = "";
                if (cbPesquisaCampo.Items.Count > 0) cbPesquisaCampo.SelectedIndex = 0;
                if (cbCondicao.Items.Count > 0) cbCondicao.SelectedIndex = 0;

                CarregarVendas(limitar20: true);

                dgvVendas.ClearSelection();
                dgvVendas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao limpar filtros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable ObterVendasComoDataTable()
        {
            DataTable dtTemp = new DataTable();
            foreach (DataGridViewColumn col in dgvVendas.Columns)
                dtTemp.Columns.Add(col.Name);

            foreach (DataGridViewRow row in dgvVendas.Rows)
            {
                if (row.IsNewRow) continue;
                DataRow dr = dtTemp.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                    dr[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                dtTemp.Rows.Add(dr);
            }

            return dtTemp;
        }

        public void RemoverVendaSelecionada()
        {
            if (dgvVendas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma venda para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja realmente remover a venda selecionada?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            try
            {
                int idVenda = Convert.ToInt32(dgvVendas.CurrentRow.Cells["ID_VENDA"].Value);

                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string sqlDeleteVenda = "DELETE FROM VENDA WHERE ID_VENDA = @id;";
                using var cmdVenda = new SQLiteCommand(sqlDeleteVenda, conn);
                cmdVenda.Parameters.AddWithValue("@id", idVenda);
                cmdVenda.ExecuteNonQuery();

                string sqlDeleteItens = "DELETE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using var cmdItens = new SQLiteCommand(sqlDeleteItens, conn);
                cmdItens.Parameters.AddWithValue("@id", idVenda);
                cmdItens.ExecuteNonQuery();

                string sqlDeletePagamento = "DELETE FROM PAGAMENTO WHERE ID_VENDA = @id;";
                using var cmdPagamento = new SQLiteCommand(sqlDeletePagamento, conn);
                cmdPagamento.Parameters.AddWithValue("@id", idVenda);
                cmdPagamento.ExecuteNonQuery();

                AtualizarTabela();
                MessageBox.Show("Venda removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover a venda: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idVendaSelecionada = Convert.ToInt32(dgvVendas.Rows[e.RowIndex].Cells["ID_VENDA"].Value);
            string nomeFuncionario = dgvVendas.Rows[e.RowIndex].Cells["NOME_FUNCIONARIO"].Value?.ToString() ?? "";
            double Desconto = Convert.ToDouble(dgvVendas.Rows[e.RowIndex].Cells["DESCONTO"].Value ?? 0);
            double ValorTotal = Convert.ToDouble(dgvVendas.Rows[e.RowIndex].Cells["VALOR_TOTAL"].Value ?? 0);
            string DataHora = dgvVendas.Rows[e.RowIndex].Cells["DATA_HORA"].Value?.ToString() ?? "";

            var formConsulta = new FormAddVendasConsulta();
            formConsulta.VendaID = idVendaSelecionada;
            formConsulta.NomeFuncionario = nomeFuncionario;
            formConsulta.Desconto = Desconto;
            formConsulta.ValorTotal = ValorTotal;
            formConsulta.DataHora = DataHora;
            formConsulta.ShowDialog(this);
        }
    }
}
