using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SQLite;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddFuncionario : MaterialForm
    {
        public FormAddFuncionario()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarPlaceholders();
        }

        private void ConfigurarEventos()
        {
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            this.Load += FormAddFuncionario_Load;
        }

        private void ConfigurarPlaceholders()
        {
            lblTitulo.Text = "Registrar Funcionário";
            this.Text = "Registrar Funcionário";
        }

        private void FormAddFuncionario_Load(object sender, EventArgs e)
        {
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados()) return;
            SalvarFuncionario();
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome do funcionário", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MessageBox.Show("Digite o cargo do funcionário", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Focus();
                return false;
            }

            if (!mtxtDataNasc.MaskCompleted)
            {
                MessageBox.Show("Preencha a data de nascimento no formato dd/mm/aaaa", "Data Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtDataNasc.Focus();
                return false;
            }

            if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                MessageBox.Show("Data de nascimento inválida. Use o formato dd/mm/aaaa", "Data Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtDataNasc.Focus();
                return false;
            }

            return true;
        }

        private void SalvarFuncionario()
        {
            try
            {
                // 1) Verifica se a tabela FUNCIONARIO existe no mesmo DB que DatabaseHelper usa
                string checkSql = "SELECT COUNT(1) FROM sqlite_master WHERE type='table' AND name=@name;";
                var checkParams = new System.Data.SQLite.SQLiteParameter[]
                {
                    new System.Data.SQLite.SQLiteParameter("@name", "FUNCIONARIO")
                };

                var dtCheck = DatabaseHelper.ExecuteQuery(checkSql, checkParams);
                if (dtCheck == null || dtCheck.Rows.Count == 0 ||
                    Convert.ToInt32(dtCheck.Rows[0][0]) == 0)
                {
                    MessageBox.Show(
                        "Tabela 'FUNCIONARIO' não encontrada no banco que o aplicativo está usando.\n\n" +
                        "Observações:\n" +
                        "- O aplicativo usa a connection string definida no App.config (verifique 'SQLiteConn').\n" +
                        "- Confirme que você está abrindo o mesmo arquivo de banco que o restante do app.\n\n" +
                        "Não vou criar a tabela automaticamente; execute as migrations/DDL no arquivo correto.",
                        "Tabela ausente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2) Preparar dados
                string nomeFormatado = txtNome.Text.Trim().ToUpperInvariant();
                string cargoFormatado = txtCargo.Text.Trim().ToUpperInvariant();

                if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
                {
                    MessageBox.Show("Data inválida (parsing).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string dataFormatada = dataNasc.ToString("dd-MM-yyyy");

                // 3) Fazer INSERT usando DatabaseHelper (mesmo DB que o resto do app)
                string insertSql = @"INSERT INTO FUNCIONARIO (NOME, CARGO, DATA_NASCIMENTO)
                                     VALUES (@nome, @cargo, @data);";
                var insertParams = new System.Data.SQLite.SQLiteParameter[]
                {
                    new System.Data.SQLite.SQLiteParameter("@nome", nomeFormatado),
                    new System.Data.SQLite.SQLiteParameter("@cargo", cargoFormatado),
                    new System.Data.SQLite.SQLiteParameter("@data", dataFormatada)
                };

                int linhas = DatabaseHelper.ExecuteNonQuery(insertSql, insertParams);

                if (linhas > 0)
                {
                    MessageBox.Show("Funcionário salvo com sucesso.", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi realizada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                // Tratamentos comuns
                if (ex.Message.IndexOf("no such table", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Erro SQLite: tabela não encontrada (no such table). " +
                        "Verifique se o arquivo de banco que o app usa contém a tabela FUNCIONARIO.", "Erro SQLite",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.IndexOf("constraint", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Erro de validação do banco (constraint). Verifique os dados.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
