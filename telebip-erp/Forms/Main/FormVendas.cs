using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormVendas : Form
    {
        public FormVendas()
        {
            InitializeComponent();
            ConfigurarComboboxes();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Eventos
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            // 🔹 Garante que nada fique selecionado ao abrir
            this.Shown += (s, e) =>
            {
                dgvVendas.ClearSelection();
                dgvVendas.CurrentCell = null;
            };

            // 🔹 Carrega as últimas 20 vendas inicialmente
            CarregarVendas(limitar20: true);
        }

        private void ConfigurarComboboxes()
        {
            cbPesquisaCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCondicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPesquisaCampo.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;
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

                // 🔹 Cabeçalhos centralizados
                foreach (DataGridViewColumn coluna in dgvVendas.Columns)
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 🔹 Ajusta para preencher toda a largura disponível
                dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 🔹 Ajuste de peso relativo das colunas (FillWeight)
                dgvVendas.Columns["ID_VENDA"].FillWeight = 15;
                dgvVendas.Columns["NOME_FUNCIONARIO"].FillWeight = 30;
                dgvVendas.Columns["DATA_HORA"].FillWeight = 25;
                dgvVendas.Columns["VALOR_TOTAL"].FillWeight = 15;
                dgvVendas.Columns["DESCONTO"].FillWeight = 15;

                // 🔹 Alinhamento do conteúdo
                dgvVendas.Columns["ID_VENDA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVendas.Columns["NOME_FUNCIONARIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvVendas.Columns["DATA_HORA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVendas.Columns["VALOR_TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVendas.Columns["DESCONTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 🔹 Formatação monetária
                dgvVendas.Columns["VALOR_TOTAL"].DefaultCellStyle.Format = "C2";
                dgvVendas.Columns["DESCONTO"].DefaultCellStyle.Format = "C2";

                // 🔹 Remove seleção automática
                dgvVendas.ClearSelection();
                dgvVendas.CurrentCell = null;

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar vendas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            if (cbPesquisaCampo.SelectedItem == null || cbCondicao.SelectedItem == null)
            {
                MessageBox.Show("Selecione o campo e a condição de pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campo = cbPesquisaCampo.SelectedItem.ToString();
            string condicao = cbCondicao.SelectedItem.ToString();
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
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor + "%") };
                    break;
                case "Contendo":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", "%" + valor + "%") };
                    break;
                case "Diferente de":
                    filtroSql = $"UPPER({campo}) NOT LIKE UPPER(@valor)";
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
            tbPesquisa.Text = "";
            cbPesquisaCampo.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;

            CarregarVendas(limitar20: true);

            dgvVendas.ClearSelection();
            dgvVendas.CurrentCell = null;
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

                // Exclui a venda
                string sqlDeleteVenda = "DELETE FROM VENDA WHERE ID_VENDA = @id;";
                using var cmdVenda = new SQLiteCommand(sqlDeleteVenda, conn);
                cmdVenda.Parameters.AddWithValue("@id", idVenda);
                cmdVenda.ExecuteNonQuery();

                // Opcional: deletar itens e pagamentos relacionados
                string sqlDeleteItens = "DELETE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using var cmdItens = new SQLiteCommand(sqlDeleteItens, conn);
                cmdItens.Parameters.AddWithValue("@id", idVenda);
                cmdItens.ExecuteNonQuery();

                string sqlDeletePagamento = "DELETE FROM PAGAMENTO WHERE ID_VENDA = @id;";
                using var cmdPagamento = new SQLiteCommand(sqlDeletePagamento, conn);
                cmdPagamento.Parameters.AddWithValue("@id", idVenda);
                cmdPagamento.ExecuteNonQuery();

                // Atualiza DataGridView
                AtualizarTabela(); // Certifique-se de ter esse método para recarregar o dgv
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
            string nomeFuncionario = dgvVendas.Rows[e.RowIndex].Cells["NOME_FUNCIONARIO"].Value.ToString();
            double Desconto = Convert.ToDouble(dgvVendas.Rows[e.RowIndex].Cells["DESCONTO"].Value);
            double ValorTotal = Convert.ToDouble(dgvVendas.Rows[e.RowIndex].Cells["VALOR_TOTAL"].Value);
            string DataHora = dgvVendas.Rows[e.RowIndex].Cells["DATA_HORA"].Value.ToString();   

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
