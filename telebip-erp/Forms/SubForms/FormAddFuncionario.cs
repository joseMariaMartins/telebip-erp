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
            ConfigurarLimitesCaracteres();
        }

        private void ConfigurarEventos()
        {
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            this.Load += FormAddFuncionario_Load;

            // Eventos para focar automaticamente no primeiro caractere da data
            mtxtDataNasc.Enter += MtxtDataNasc_Enter;
            mtxtDataNasc.GotFocus += MtxtDataNasc_GotFocus;
            mtxtDataNasc.MouseDown += MtxtDataNasc_MouseDown; // ✅ NOVO: Evento de mouse

            // Eventos de tecla para melhor navegação
            txtNome.KeyDown += Txt_KeyDown;
            txtCargo.KeyDown += Txt_KeyDown;
            mtxtDataNasc.KeyDown += Txt_KeyDown;

            // Eventos para limitar caracteres em tempo real
            txtNome.TextChanged += TxtNome_TextChanged;
            txtCargo.TextChanged += TxtCargo_TextChanged;
        }

        private void ConfigurarPlaceholders()
        {
            lblTitulo.Text = "Registrar Funcionário";
            this.Text = "Registrar Funcionário";
        }

        private void ConfigurarLimitesCaracteres()
        {
            txtNome.MaxLength = 100;
            txtCargo.MaxLength = 50;
        }

        private void FormAddFuncionario_Load(object sender, EventArgs e)
        {
            // Focar no primeiro campo ao abrir o formulário
            txtNome.Focus();
        }

        private void MtxtDataNasc_Enter(object sender, EventArgs e)
        {
            // Focar no PRIMEIRO caractere para digitação sequencial
            mtxtDataNasc.Select(0, 0);
        }

        private void MtxtDataNasc_GotFocus(object sender, EventArgs e)
        {
            // Pequeno delay para garantir que o foco está totalmente no controle
            BeginInvoke((MethodInvoker)delegate
            {
                mtxtDataNasc.Select(0, 0);
            });
        }

        // ✅ NOVO: Evento MouseDown para garantir que cliques do mouse também funcionem
        private void MtxtDataNasc_MouseDown(object sender, MouseEventArgs e)
        {
            // Impede o cursor de ir para onde foi clicado
            BeginInvoke((MethodInvoker)delegate
            {
                mtxtDataNasc.Select(0, 0);
            });
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 100)
            {
                txtNome.Text = txtNome.Text.Substring(0, 100);
                txtNome.Select(txtNome.Text.Length, 0);
            }
        }

        private void TxtCargo_TextChanged(object sender, EventArgs e)
        {
            if (txtCargo.Text.Length > 50)
            {
                txtCargo.Text = txtCargo.Text.Substring(0, 50);
                txtCargo.Select(txtCargo.Text.Length, 0);
            }
        }

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);

                // Quando navegar para o campo de data, focar no início
                if (ActiveControl == mtxtDataNasc)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        mtxtDataNasc.Select(0, 0);
                    });
                }
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados()) return;
            SalvarFuncionario();
        }

        private bool ValidarDados()
        {
            // Validação do Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MostrarErroCampo("Digite o nome do funcionário", txtNome);
                return false;
            }

            if (txtNome.Text.Trim().Length < 3)
            {
                MostrarErroCampo("O nome deve ter pelo menos 3 caracteres", txtNome);
                return false;
            }

            if (txtNome.Text.Trim().Length > 100)
            {
                MostrarErroCampo("O nome deve ter no máximo 100 caracteres", txtNome);
                return false;
            }

            // Validação do Cargo
            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MostrarErroCampo("Digite o cargo do funcionário", txtCargo);
                return false;
            }

            if (txtCargo.Text.Trim().Length < 2)
            {
                MostrarErroCampo("O cargo deve ter pelo menos 2 caracteres", txtCargo);
                return false;
            }

            if (txtCargo.Text.Trim().Length > 50)
            {
                MostrarErroCampo("O cargo deve ter no máximo 50 caracteres", txtCargo);
                return false;
            }

            // Validação da Data
            if (!mtxtDataNasc.MaskCompleted)
            {
                MostrarErroCampo("Preencha a data de nascimento no formato dd/mm/aaaa", mtxtDataNasc);
                return false;
            }

            if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
            {
                MostrarErroCampo("Data de nascimento inválida. Use o formato dd/mm/aaaa", mtxtDataNasc);
                return false;
            }

            // Validação se a data não é futura
            if (dataNasc > DateTime.Today)
            {
                MostrarErroCampo("A data de nascimento não pode ser futura", mtxtDataNasc);
                return false;
            }

            // Validação se a pessoa tem pelo menos 14 anos
            if (dataNasc > DateTime.Today.AddYears(-14))
            {
                MostrarErroCampo("O funcionário deve ter pelo menos 14 anos", mtxtDataNasc);
                return false;
            }

            return true;
        }

        private void MostrarErroCampo(string mensagem, Control controle)
        {
            MessageBox.Show(mensagem, "Campo Obrigatório",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controle.Focus();

            // Selecionar todo o texto se for TextBox
            if (controle is TextBox textBox)
            {
                textBox.SelectAll();
            }
            else if (controle is MaskedTextBox maskedTextBox)
            {
                // Para MaskedTextBox, focar apenas no início sem selecionar tudo
                maskedTextBox.Select(0, 0);
            }
        }

        private void SalvarFuncionario()
        {
            try
            {
                // 1) Verifica se a tabela FUNCIONARIO existe
                string checkSql = "SELECT COUNT(1) FROM sqlite_master WHERE type='table' AND name=@name;";
                var checkParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@name", "FUNCIONARIO")
                };

                var dtCheck = DatabaseHelper.ExecuteQuery(checkSql, checkParams);
                if (dtCheck == null || dtCheck.Rows.Count == 0 ||
                    Convert.ToInt32(dtCheck.Rows[0][0]) == 0)
                {
                    MessageBox.Show(
                        "Tabela 'FUNCIONARIO' não encontrada no banco de dados.\n\n" +
                        "Verifique se o banco de dados está configurado corretamente.",
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

                // 3) Fazer INSERT
                string insertSql = @"INSERT INTO FUNCIONARIO (NOME, CARGO, DATA_NASCIMENTO)
                                     VALUES (@nome, @cargo, @data);";
                var insertParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@nome", nomeFormatado),
                    new SQLiteParameter("@cargo", cargoFormatado),
                    new SQLiteParameter("@data", dataFormatada)
                };

                int linhas = DatabaseHelper.ExecuteNonQuery(insertSql, insertParams);

                if (linhas > 0)
                {
                    MessageBox.Show("Funcionário salvo com sucesso!", "Sucesso",
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
            catch (SQLiteException ex)
            {
                if (ex.Message.IndexOf("no such table", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Erro SQLite: tabela não encontrada.", "Erro SQLite",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.IndexOf("constraint", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show("Erro de validação do banco. Verifique os dados.", "Erro",
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