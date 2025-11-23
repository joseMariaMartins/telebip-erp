// FormFuncionarios.cs
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormFuncionarios : Form
    {
        // Ajuste aqui para o arquivo do seu banco de dados SQLite
        // Ex: "Data Source=C:\\dados\\telebip.db;Version=3;"
        private string connectionString = "Data Source=telebip.db;Version=3;";

        private Button btnAddFuncionario;
        private Button btnRemoveFuncionario;

        public FormFuncionarios()
        {
            InitializeComponent();
            WireEvents();
            LoadFiltrosECargos();
            LoadFuncionarios();
        }

        private void WireEvents()
        {
            // DataGrid selection changed
            dgvFuncionarios.SelectionChanged += DgvFuncionarios_SelectionChanged;

            // Botões do designer
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            // Botões runtime

            // Pesquisa ao digitar ENTER
            tbSearch.KeyDown += TbSearch_KeyDown;
            // filtro cargo
            cbFiltroCargo.SelectedIndexChanged += CbFiltroCargo_SelectedIndexChanged;
        }

        #region Carregamento e preenchimento
        private void LoadFuncionarios(string nomeFiltro = "", string cargoFiltro = "")
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        // Habilita FKs (bom hábito)
                        using (var pragma = conn.CreateCommand())
                        {
                            pragma.CommandText = "PRAGMA foreign_keys = ON;";
                            pragma.ExecuteNonQuery();
                        }

                        // Monta query base — selecionamos colunas presentes no schema que temos
                        cmd.CommandText = @"
                            SELECT ID_FUNCIONARIO, NOME, CARGO, DATA_NASCIMENTO
                            FROM FUNCIONARIO
                            WHERE 1=1
                        ";

                        if (!string.IsNullOrWhiteSpace(nomeFiltro))
                        {
                            cmd.CommandText += " AND (NOME LIKE @nome)";
                            cmd.Parameters.AddWithValue("@nome", "%" + nomeFiltro.Trim() + "%");
                        }

                        if (!string.IsNullOrWhiteSpace(cargoFiltro) && cargoFiltro != "Todos cargos")
                        {
                            cmd.CommandText += " AND CARGO = @cargo";
                            cmd.Parameters.AddWithValue("@cargo", cargoFiltro);
                        }

                        cmd.CommandText += " ORDER BY NOME COLLATE NOCASE;";

                        var dt = new DataTable();
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dgvFuncionarios.DataSource = dt;

                        // Ocultar coluna ID, ajustar títulos/campos
                        if (dgvFuncionarios.Columns.Contains("ID_FUNCIONARIO"))
                        {
                            dgvFuncionarios.Columns["ID_FUNCIONARIO"].Visible = false;
                        }
                        if (dgvFuncionarios.Columns.Contains("NOME"))
                        {
                            dgvFuncionarios.Columns["NOME"].HeaderText = "Nome";
                        }
                        if (dgvFuncionarios.Columns.Contains("CARGO"))
                        {
                            dgvFuncionarios.Columns["CARGO"].HeaderText = "Cargo";
                        }
                        if (dgvFuncionarios.Columns.Contains("DATA_NASCIMENTO"))
                        {
                            dgvFuncionarios.Columns["DATA_NASCIMENTO"].HeaderText = "Data Nasc.";
                        }

                        UpdateTotalLabel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFiltrosECargos()
        {
            // Preenche cbFiltroCargo com os cargos distintos do banco
            try
            {
                cbFiltroCargo.Items.Clear();
                cbFiltroCargo.Items.Add("Todos cargos");

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT DISTINCT CARGO FROM FUNCIONARIO WHERE CARGO IS NOT NULL AND CARGO <> '' ORDER BY CARGO COLLATE NOCASE;";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var cargo = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                if (!string.IsNullOrWhiteSpace(cargo))
                                    cbFiltroCargo.Items.Add(cargo);
                            }
                        }
                    }
                }

                // define seleção padrão
                cbFiltroCargo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // não fatal, apenas loga para o usuário
                Console.WriteLine("Erro ao carregar cargos: " + ex.Message);
            }
        }

        private void UpdateTotalLabel()
        {
            try
            {
                int total = dgvFuncionarios.Rows.Count;
                lbTotal.Text = $"Total: {total} funcionário{(total == 1 ? "" : "s")}";
            }
            catch { /* ignorar */ }
        }
        #endregion

        #region Eventos UI
        private void DgvFuncionarios_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelectedDetails();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            if (cbFiltroCargo.Items.Count > 0) cbFiltroCargo.SelectedIndex = 0;
            LoadFuncionarios();
        }

        private void BtnAddFuncionario_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddFuncionarioForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // Insere no banco (nota: o esquema enviado tem apenas NOME, CARGO, DATA_NASCIMENTO)
                    try
                    {
                        using (var conn = new SQLiteConnection(connectionString))
                        {
                            conn.Open();
                            using (var cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"INSERT INTO FUNCIONARIO (NOME, CARGO, DATA_NASCIMENTO) VALUES (@nome, @cargo, @data);";
                                cmd.Parameters.AddWithValue("@nome", dlg.Nome.Trim());
                                cmd.Parameters.AddWithValue("@cargo", dlg.Cargo.Trim());
                                cmd.Parameters.AddWithValue("@data", dlg.DataNascimento.Trim()); // formato dd-mm-YYYY conforme seu schema
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // atualiza UI
                        LoadFiltrosECargos();
                        LoadFuncionarios(tbSearch.Text, GetSelectedCargoFilter());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao adicionar funcionário:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRemoveFuncionario_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um funcionário para remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvFuncionarios.SelectedRows[0];
            if (!row.Cells.Contains(row.Cells["ID_FUNCIONARIO"]))
            {
                // tenta buscar por índice 0 se coluna custom diferente
            }

            var idObj = row.Cells["ID_FUNCIONARIO"].Value;
            if (idObj == null)
            {
                MessageBox.Show("Não foi possível identificar o funcionário selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(idObj);
            var nome = row.Cells["NOME"].Value?.ToString() ?? "(sem nome)";

            var resp = MessageBox.Show($"Tem certeza que deseja excluir o funcionário '{nome}' (ID {id})?\nEssa ação não pode ser desfeita.", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resp != DialogResult.Yes) return;

            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM FUNCIONARIO WHERE ID_FUNCIONARIO = @id;";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadFiltrosECargos();
                LoadFuncionarios(tbSearch.Text, GetSelectedCargoFilter());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover funcionário:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ApplyFilters();
            }
        }

        private void CbFiltroCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        #endregion

        #region Utilitários e helpers
        private void ApplyFilters()
        {
            var nomeFiltro = tbSearch.Text.Trim();
            var cargoFiltro = GetSelectedCargoFilter();
            LoadFuncionarios(nomeFiltro, cargoFiltro);
        }

        private string GetSelectedCargoFilter()
        {
            try
            {
                if (cbFiltroCargo.SelectedItem == null) return "";
                return cbFiltroCargo.SelectedItem.ToString();
            }
            catch { return ""; }
        }

        private void ShowSelectedDetails()
        {
            if (dgvFuncionarios.SelectedRows.Count == 0)
            {
                lblCardNome.Text = "Nome: (selecione um funcionário)";
                lblCardCargo.Text = "Cargo: -";
                lblCardNomeCompleto.Text = "Nome completo: -";
                lblCardTelefone.Text = "Telefone: -";
                lblCardEmail.Text = "E-mail: -";
                return;
            }

            var row = dgvFuncionarios.SelectedRows[0];
            var nome = row.Cells["NOME"].Value?.ToString() ?? "-";
            var cargo = row.Cells["CARGO"].Value?.ToString() ?? "-";
            var dataNasc = row.Cells["DATA_NASCIMENTO"].Value?.ToString() ?? "-";

            lblCardNome.Text = $"Nome: {nome}";
            lblCardCargo.Text = $"Cargo: {cargo}";
            lblCardNomeCompleto.Text = $"Nome completo: {nome}";
            // No schema que você enviou não há TELEFONE / EMAIL —
            // exibimos a data de nascimento no lugar, se desejar mudo para campos reais.
            lblCardTelefone.Text = $"Data nasc.: {dataNasc}";
            lblCardEmail.Text = "E-mail: -";
        }
        #endregion

        #region Dialogo para adicionar funcionário (simples, embutido)
        // Form modal simples para inserir novo funcionário
        private class AddFuncionarioForm : Form
        {
            public string Nome => tbNome.Text;
            public string Cargo => tbCargo.Text;
            public string DataNascimento => tbDataNasc.Text; // espera formato dd-mm-YYYY conforme seu schema

            private TextBox tbNome;
            private TextBox tbCargo;
            private MaskedTextBox tbDataNasc;
            private Button btnOk;
            private Button btnCancel;

            public AddFuncionarioForm()
            {
                Text = "Adicionar funcionário";
                FormBorderStyle = FormBorderStyle.FixedDialog;
                StartPosition = FormStartPosition.CenterParent;
                ClientSize = new Size(420, 180);
                MaximizeBox = false;
                MinimizeBox = false;

                var lblNome = new Label { Text = "Nome:", Location = new Point(12, 14), AutoSize = true };
                tbNome = new TextBox { Location = new Point(12, 34), Width = 380 };

                var lblCargo = new Label { Text = "Cargo:", Location = new Point(12, 68), AutoSize = true };
                tbCargo = new TextBox { Location = new Point(12, 88), Width = 380 };

                var lblData = new Label { Text = "Data nascimento (dd-mm-YYYY):", Location = new Point(12, 120), AutoSize = true };
                tbDataNasc = new MaskedTextBox("00-00-0000") { Location = new Point(200, 116), Width = 100 };

                btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK, Location = new Point(220, 140), Size = new Size(80, 28) };
                btnCancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(310, 140), Size = new Size(80, 28) };

                Controls.AddRange(new Control[] { lblNome, tbNome, lblCargo, tbCargo, lblData, tbDataNasc, btnOk, btnCancel });

                AcceptButton = btnOk;
                CancelButton = btnCancel;

                btnOk.Click += BtnOk_Click;
            }

            private void BtnOk_Click(object sender, EventArgs e)
            {
                // Validações básicas
                if (string.IsNullOrWhiteSpace(Nome))
                {
                    MessageBox.Show("Preencha o nome.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                if (string.IsNullOrWhiteSpace(Cargo))
                {
                    MessageBox.Show("Preencha o cargo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(DataNascimento, @"^\d{2}-\d{2}-\d{4}$"))
                {
                    MessageBox.Show("Data de nascimento inválida. Use dd-mm-YYYY.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
            }
        }
        #endregion
    }
}
