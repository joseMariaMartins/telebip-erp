using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormEditarFuncionario : MaterialSkin.Controls.MaterialForm
    {
        private readonly int? funcionarioId;

        // Construtor para edição recebendo o ID do funcionário
        public FormEditarFuncionario(int id)
        {
            InitializeComponent();
            funcionarioId = id;
            Inicializar();
        }

        private void Inicializar()
        {
            // eventos
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            // se o designer adicionou botões alternativos (cuiButton1/cuiButton2), mapeie eles também
            if (cuiButton1 != null) cuiButton1.Click += BtnSalvar_Click;
            if (cuiButton2 != null) cuiButton2.Click += BtnCancelar_Click;

            // configuração visual / placeholders
            lblTitulo.Text = funcionarioId.HasValue ? "Editar Funcionário" : "Registrar Funcionário";
            this.Text = lblTitulo.Text;

            // ✅ CORREÇÃO: Carregar os dados quando o formulário for carregado
            this.Load += FormEditarFuncionario_Load;
        }

        private void FormEditarFuncionario_Load(object sender, EventArgs e)
        {
            if (funcionarioId.HasValue)
            {
                CarregarFuncionario(funcionarioId.Value);
            }
        }

        private void CarregarFuncionario(int id)
        {
            try
            {
                // SELECT usando DatabaseHelper (mesmo DB do app)
                string sql = @"SELECT ID_FUNCIONARIO, NOME, CARGO, DATA_NASCIMENTO
                               FROM FUNCIONARIO
                               WHERE ID_FUNCIONARIO = @id LIMIT 1;";
                var parametros = new System.Data.SQLite.SQLiteParameter[]
                {
                    new System.Data.SQLite.SQLiteParameter("@id", id)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Funcionário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                var row = dt.Rows[0];
                txtNome.Text = row["NOME"]?.ToString() ?? "";
                txtCargo.Text = row["CARGO"]?.ToString() ?? "";

                // ✅ CORREÇÃO: Processar a data corretamente
                var dataText = row["DATA_NASCIMENTO"]?.ToString();
                if (!string.IsNullOrEmpty(dataText))
                {
                    // Tenta parse no formato dd-MM-yyyy (formato do banco)
                    if (DateTime.TryParseExact(dataText, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtNasc))
                    {
                        mtxtDataNasc.Text = dtNasc.ToString("dd/MM/yyyy");
                    }
                    // Se não conseguir, tenta parse genérico
                    else if (DateTime.TryParse(dataText, out DateTime dtParse))
                    {
                        mtxtDataNasc.Text = dtParse.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        // Se ainda não conseguir, mostra o texto original
                        mtxtDataNasc.Text = dataText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // ... resto do código permanece igual
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados()) return;

            if (funcionarioId.HasValue)
                AtualizarFuncionario(funcionarioId.Value);
            else
                InserirFuncionario();
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome do funcionário", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MessageBox.Show("Digite o cargo do funcionário", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Focus();
                return false;
            }

            if (!mtxtDataNasc.MaskCompleted)
            {
                MessageBox.Show("Preencha a data de nascimento no formato dd/mm/aaaa", "Data Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtDataNasc.Focus();
                return false;
            }

            if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                MessageBox.Show("Data de nascimento inválida. Use o formato dd/mm/aaaa", "Data Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtDataNasc.Focus();
                return false;
            }

            return true;
        }

        private void AtualizarFuncionario(int id)
        {
            try
            {
                // preparar valores
                string nome = txtNome.Text.Trim().ToUpperInvariant();
                string cargo = txtCargo.Text.Trim().ToUpperInvariant();

                if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
                {
                    MessageBox.Show("Data inválida (parsing).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string dataFormatada = dataNasc.ToString("dd-MM-yyyy");

                string sql = @"UPDATE FUNCIONARIO
                               SET NOME = @nome,
                                   CARGO = @cargo,
                                   DATA_NASCIMENTO = @data
                               WHERE ID_FUNCIONARIO = @id;";

                var parametros = new System.Data.SQLite.SQLiteParameter[]
                {
                    new System.Data.SQLite.SQLiteParameter("@nome", nome),
                    new System.Data.SQLite.SQLiteParameter("@cargo", cargo),
                    new System.Data.SQLite.SQLiteParameter("@data", dataFormatada),
                    new System.Data.SQLite.SQLiteParameter("@id", id)
                };

                int afetadas = DatabaseHelper.ExecuteNonQuery(sql, parametros);
                if (afetadas > 0)
                {
                    MessageBox.Show("Funcionário atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi realizada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                if (ex.Message.IndexOf("no such table", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Erro SQLite: tabela 'FUNCIONARIO' não encontrada. Verifique o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.IndexOf("constraint", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Erro de validação do banco (constraint). Verifique os dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Erro SQLite: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InserirFuncionario()
        {
            try
            {
                string nome = txtNome.Text.Trim().ToUpperInvariant();
                string cargo = txtCargo.Text.Trim().ToUpperInvariant();

                if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
                {
                    MessageBox.Show("Data inválida (parsing).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string dataFormatada = dataNasc.ToString("dd-MM-yyyy");

                string sql = @"INSERT INTO FUNCIONARIO (NOME, CARGO, DATA_NASCIMENTO)
                               VALUES (@nome, @cargo, @data);";

                var parametros = new System.Data.SQLite.SQLiteParameter[]
                {
                    new System.Data.SQLite.SQLiteParameter("@nome", nome),
                    new System.Data.SQLite.SQLiteParameter("@cargo", cargo),
                    new System.Data.SQLite.SQLiteParameter("@data", dataFormatada)
                };

                int linhas = DatabaseHelper.ExecuteNonQuery(sql, parametros);
                if (linhas > 0)
                {
                    MessageBox.Show("Funcionário inserido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi realizada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                MessageBox.Show("Erro SQLite: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}