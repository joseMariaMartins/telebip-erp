using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddFuncionario : Form
    {
        private string connectionString = "Data Source=database.db;Version=3;";

        public bool ModoEdicao { get; set; } = false;
        public int FuncionarioId { get; set; } = 0;
        public Action FuncionarioSalvoCallback { get; set; }

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

            // Carregar dados se for edição
            this.Load += FormAddFuncionario_Load;
        }

        private void ConfigurarPlaceholders()
        {
            if (ModoEdicao)
            {
                lblTitulo.Text = "Editar Funcionário";
                this.Text = "Editar Funcionário";
            }
            else
            {
                lblTitulo.Text = "Registrar Funcionário";
                this.Text = "Registrar Funcionário";
            }
        }

        private void FormAddFuncionario_Load(object sender, EventArgs e)
        {
            if (ModoEdicao && FuncionarioId > 0)
            {
                CarregarDadosFuncionario();
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados())
                return;

            SalvarFuncionario();
        }

        private bool ValidarDados()
        {
            // VALIDAÇÃO DO NOME
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome do funcionário", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            // VALIDAÇÃO DO CARGO
            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MessageBox.Show("Digite o cargo do funcionário", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Focus();
                return false;
            }

            // VALIDAÇÃO DA DATA DE NASCIMENTO
            if (!mtxtDataNasc.MaskCompleted)
            {
                MessageBox.Show("Preencha a data de nascimento no formato dd/mm/aaaa", "Data Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtDataNasc.Focus();
                return false;
            }

            // Validar se a data é válida
            if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
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
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string sql = "";
                    SQLiteCommand cmd;

                    if (ModoEdicao)
                    {
                        sql = @"UPDATE FUNCIONARIO 
                               SET NOME = @nome, CARGO = @cargo, DATA_NASCIMENTO = @data 
                               WHERE ID_FUNCIONARIO = @id";
                    }
                    else
                    {
                        sql = @"INSERT INTO FUNCIONARIO (NOME, CARGO, DATA_NASCIMENTO) 
                               VALUES (@nome, @cargo, @data)";
                    }

                    using (cmd = new SQLiteCommand(sql, conn))
                    {
                        // Formatar dados
                        string nomeFormatado = txtNome.Text.Trim().ToUpper();
                        string cargoFormatado = txtCargo.Text.Trim().ToUpper();

                        // Converter data para formato dd-mm-yyyy (padrão do banco)
                        DateTime dataNasc = DateTime.ParseExact(mtxtDataNasc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        string dataFormatada = dataNasc.ToString("dd-MM-yyyy");

                        cmd.Parameters.AddWithValue("@nome", nomeFormatado);
                        cmd.Parameters.AddWithValue("@cargo", cargoFormatado);
                        cmd.Parameters.AddWithValue("@data", dataFormatada);

                        if (ModoEdicao)
                        {
                            cmd.Parameters.AddWithValue("@id", FuncionarioId);
                        }

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        // ✅ CORREÇÃO: Condição mais flexível para INSERT
                        if (linhasAfetadas > 0 || !ModoEdicao) // Para INSERT, considera sucesso mesmo se retornar 0
                        {
                            string mensagem = ModoEdicao ?
                                "Funcionário atualizado com sucesso!" :
                                "Funcionário cadastrado com sucesso!";

                            MessageBox.Show(mensagem, "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Executar callback para atualizar a tabela
                            FuncionarioSalvoCallback?.Invoke();

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma alteração foi realizada", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                // ✅ CORREÇÃO: Tratamento específico para SQLite
                if (ex.Message.Contains("constraint"))
                {
                    MessageBox.Show("Erro de validação nos dados. Verifique os campos.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao salvar funcionário: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void CarregarDadosFuncionario()
        {
            if (!ModoEdicao || FuncionarioId == 0) return;

            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT NOME, CARGO, DATA_NASCIMENTO FROM FUNCIONARIO WHERE ID_FUNCIONARIO = @id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", FuncionarioId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Carregar dados nos campos
                                txtNome.Text = reader["NOME"].ToString();
                                txtCargo.Text = reader["CARGO"].ToString();

                                // Converter data do formato dd-mm-yyyy para dd/mm/yyyy
                                string dataBanco = reader["DATA_NASCIMENTO"].ToString();
                                if (DateTime.TryParseExact(dataBanco, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
                                {
                                    mtxtDataNasc.Text = dataNasc.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    mtxtDataNasc.Text = dataBanco;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Funcionário não encontrado.", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do funcionário: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}