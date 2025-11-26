using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormFuncionarios : Form
    {
        private int? funcionarioSelecionadoId = null;

        public FormFuncionarios()
        {
            InitializeComponent();
            CarregarFuncionarios();
            ConfigurarEventos();
            AtualizarCard(null);
        }

        private void ConfigurarEventos()
        {
            btnAdicionar.Click += BtnAdicionar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnRemover.Click += BtnRemover_Click;
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            dgvFuncionarios.SelectionChanged += DgvFuncionarios_SelectionChanged;
            dgvFuncionarios.CellDoubleClick += DgvFuncionarios_CellDoubleClick;
            tbSearch.KeyDown += TbSearch_KeyDown;
        }

        #region Operações de Banco de Dados e Configuração da Tabela

        private void CarregarFuncionarios(string filtro = "")
        {
            try
            {
                string sql = @"
                    SELECT 
                        ID_FUNCIONARIO AS ID, 
                        NOME, 
                        CARGO, 
                        DATA_NASCIMENTO
                    FROM FUNCIONARIO 
                    WHERE 1=1";

                SQLiteParameter[] parametros = null;

                if (!string.IsNullOrEmpty(filtro))
                {
                    sql += @" AND (UPPER(NOME) LIKE UPPER(@filtro) 
                             OR UPPER(CARGO) LIKE UPPER(@filtro))";
                    parametros = new SQLiteParameter[] {
                        new SQLiteParameter("@filtro", $"%{filtro}%")
                    };
                }

                // ✅ ORDENAR POR ID (mais recentes primeiro)
                sql += " ORDER BY ID_FUNCIONARIO DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                dgvFuncionarios.DataSource = dt;

                ConfigurarDataGridView();
                AtualizarTotalFuncionarios();
                dgvFuncionarios.ClearSelection();
                funcionarioSelecionadoId = null;
                AtualizarCard(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            try
            {
                // ✅ CORREÇÃO: Mudar para None e configurar manualmente
                dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFuncionarios.MultiSelect = false;
                dgvFuncionarios.ReadOnly = true;
                dgvFuncionarios.AllowUserToAddRows = false;
                dgvFuncionarios.RowHeadersVisible = false;
                dgvFuncionarios.AllowUserToResizeRows = false;

                AplicarTemaEscuro();
                ConfigurarCabecalhos();

                dgvFuncionarios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao configurar a tabela: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarTemaEscuro()
        {
            Color background = Color.FromArgb(32, 33, 39);
            Color backgroundAlt = Color.FromArgb(38, 39, 46);
            Color headerBack = Color.FromArgb(40, 41, 52);
            Color gridColor = Color.FromArgb(50, 52, 67);
            Color selectionBack = Color.FromArgb(50, 90, 130);
            Color fore = Color.White;

            dgvFuncionarios.BackgroundColor = background;
            dgvFuncionarios.GridColor = gridColor;
            dgvFuncionarios.BorderStyle = BorderStyle.None;

            dgvFuncionarios.DefaultCellStyle.BackColor = background;
            dgvFuncionarios.DefaultCellStyle.ForeColor = fore;
            dgvFuncionarios.DefaultCellStyle.SelectionBackColor = selectionBack;
            dgvFuncionarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFuncionarios.DefaultCellStyle.Font = new Font("Segoe UI", 9f);

            dgvFuncionarios.AlternatingRowsDefaultCellStyle.BackColor = backgroundAlt;
            dgvFuncionarios.AlternatingRowsDefaultCellStyle.ForeColor = fore;

            dgvFuncionarios.ColumnHeadersDefaultCellStyle.BackColor = headerBack;
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvFuncionarios.EnableHeadersVisualStyles = false;

            dgvFuncionarios.ColumnHeadersHeight = 35;
            dgvFuncionarios.RowTemplate.Height = 30;
        }

        private void ConfigurarCabecalhos()
        {
            try
            {
                if (dgvFuncionarios.Columns.Count == 0) return;

                // ✅ CORREÇÃO: Configurar larguras manualmente
                foreach (DataGridViewColumn coluna in dgvFuncionarios.Columns)
                {
                    if (coluna == null) continue;

                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    switch (coluna.Name.ToUpper())
                    {
                        case "ID":
                            // ✅ ID visível com largura fixa
                            coluna.HeaderText = "ID";
                            coluna.Visible = true;
                            coluna.Width = 60;
                            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case "NOME":
                            coluna.HeaderText = "Nome";
                            coluna.Width = 250; // Largura fixa
                            break;
                        case "CARGO":
                            coluna.HeaderText = "Cargo";
                            coluna.Width = 200; // Largura fixa
                            break;
                        case "DATA_NASCIMENTO":
                            coluna.HeaderText = "Data de Nascimento";
                            coluna.Width = 150; // Largura fixa
                            break;
                        default:
                            break;
                    }
                }

                // ✅ CORREÇÃO: Ajustar a última coluna para preencher o espaço restante
                if (dgvFuncionarios.Columns.Count > 0)
                {
                    dgvFuncionarios.Columns[dgvFuncionarios.Columns.Count - 1].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao configurar cabeçalhos: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTotalFuncionarios()
        {
            lbTotal.Text = $"Total: {dgvFuncionarios.Rows.Count} funcionário(s)";
        }

        #endregion

        #region Eventos da Interface e Seleção

        private void DgvFuncionarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                var linha = dgvFuncionarios.SelectedRows[0];
                funcionarioSelecionadoId = Convert.ToInt32(linha.Cells["ID"].Value);
                AtualizarCard(linha);
            }
            else
            {
                funcionarioSelecionadoId = null;
                AtualizarCard(null);
            }
        }

        private void DgvFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEditar_Click(sender, e);
            }
        }

        private void TbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPesquisar_Click(sender, e);
            }
        }

        #endregion

        #region Card de Detalhes

        private void AtualizarCard(DataGridViewRow linha)
        {
            if (linha == null)
            {
                lblCardNome.Text = "Nome: (selecione um funcionário)";
                lblCardCargo.Text = "Cargo: -";
                lblCardDataNascimento.Text = "Data de Nascimento: -";

                btnEditar.Enabled = false;
                btnRemover.Enabled = false;
            }
            else
            {
                lblCardNome.Text = $"Nome: {linha.Cells["NOME"].Value}";
                lblCardCargo.Text = $"Cargo: {linha.Cells["CARGO"].Value}";

                var dataNasc = linha.Cells["DATA_NASCIMENTO"].Value?.ToString();
                lblCardDataNascimento.Text = string.IsNullOrEmpty(dataNasc) ?
                    "Data de Nascimento: -" :
                    $"Data de Nascimento: {dataNasc}";

                btnEditar.Enabled = true;
                btnRemover.Enabled = true;
            }
        }

        #endregion

        #region Botões de Ação - CRUD Completo

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            using (var formAddFuncionario = new FormAddFuncionario())
            {
                formAddFuncionario.ModoEdicao = false;
                formAddFuncionario.FuncionarioSalvoCallback = () =>
                {
                    // ✅ CORREÇÃO: Chamar método para recarregar dados
                    CarregarFuncionarios();
                };

                var resultado = formAddFuncionario.ShowDialog();

                // ✅ CORREÇÃO: Recarregar também quando fechar com OK (backup)
                if (resultado == DialogResult.OK)
                {
                    CarregarFuncionarios();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!funcionarioSelecionadoId.HasValue)
            {
                MessageBox.Show("Selecione um funcionário para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formAddFuncionario = new FormAddFuncionario())
            {
                formAddFuncionario.ModoEdicao = true;
                formAddFuncionario.FuncionarioId = funcionarioSelecionadoId.Value;
                formAddFuncionario.FuncionarioSalvoCallback = () =>
                {
                    // ✅ CORREÇÃO: Chamar método para recarregar dados
                    CarregarFuncionarios();
                };

                formAddFuncionario.CarregarDadosFuncionario();

                var resultado = formAddFuncionario.ShowDialog();

                // ✅ CORREÇÃO: Recarregar também quando fechar com OK (backup)
                if (resultado == DialogResult.OK)
                {
                    CarregarFuncionarios();
                }
            }
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            if (!funcionarioSelecionadoId.HasValue)
            {
                MessageBox.Show("Selecione um funcionário para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "Tem certeza que deseja excluir este funcionário?\n\nEsta ação não pode ser desfeita.",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM FUNCIONARIO WHERE ID_FUNCIONARIO = @id";
                    SQLiteParameter[] parametros = {
                        new SQLiteParameter("@id", funcionarioSelecionadoId.Value)
                    };

                    DatabaseHelper.ExecuteNonQuery(sql, parametros);

                    CarregarFuncionarios();
                    MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir funcionário: " + ex.Message, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string termoPesquisa = tbSearch.Text.Trim();
            CarregarFuncionarios(termoPesquisa);
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            CarregarFuncionarios();
        }

        #endregion

        #region Métodos Públicos

        public void AtualizarDados()
        {
            CarregarFuncionarios();
        }

        #endregion

        #region Método de Debug (Temporário)

        private void TestarInsercaoFuncionario()
        {
            try
            {
                using (var conn = new SQLiteConnection("Data Source=database.db;Version=3;"))
                {
                    conn.Open();

                    // Inserir um funcionário de teste
                    string sql = @"INSERT INTO FUNCIONARIO (NOME, CARGO, DATA_NASCIMENTO) 
                                  VALUES (@nome, @cargo, @data)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", "FUNCIONARIO TESTE " + DateTime.Now.ToString("HHmmss"));
                        cmd.Parameters.AddWithValue("@cargo", "CARGO TESTE");
                        cmd.Parameters.AddWithValue("@data", "01-01-1990");

                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Inserção direta no banco: {result} linha(s) afetada(s)");
                    }

                    // Verificar quantos funcionários existem
                    string sqlCount = "SELECT COUNT(*) FROM FUNCIONARIO";
                    using (var cmdCount = new SQLiteCommand(sqlCount, conn))
                    {
                        var total = cmdCount.ExecuteScalar();
                        MessageBox.Show($"Total de funcionários no banco: {total}");
                    }

                    // Recarregar a tabela
                    CarregarFuncionarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no teste: {ex.Message}");
            }
        }

        #endregion
    }
}