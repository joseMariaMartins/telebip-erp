using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SQLite;
using System.Drawing;

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

            // Eventos de tecla para melhor navegação
            txtNome.KeyDown += Txt_KeyDown;
            txtCargo.KeyDown += Txt_KeyDown;
            mtxtDataNasc.KeyDown += Txt_KeyDown;

            // Eventos para limitar caracteres em tempo real
            txtNome.TextChanged += TxtNome_TextChanged;
            txtCargo.TextChanged += TxtCargo_TextChanged;

            // Eventos para melhor experiência de edição
            txtNome.MouseDown += Txt_MouseDown;
            txtCargo.MouseDown += Txt_MouseDown;
            mtxtDataNasc.MouseDown += MtxtDataNasc_MouseDown;

            // ✅ ADICIONADO: Eventos de teclado para botões
            btnSalvar.KeyDown += BtnSalvar_KeyDown;
            btnCancelar.KeyDown += BtnCancelar_KeyDown;

            // ✅ ADICIONADO: Evento de teclado para o formulário
            this.KeyPreview = true;
            this.KeyDown += FormAddFuncionario_KeyDown;
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
            mtxtDataNasc.Mask = "00/00/0000";
        }

        private void FormAddFuncionario_Load(object sender, EventArgs e)
        {
            // Focar no primeiro campo ao abrir o formulário
            txtNome.Focus();
            txtNome.Select(txtNome.Text.Length, 0); // Cursor no final
        }

        // Evento genérico para campos de texto - cursor vai para onde clicou
        private void Txt_MouseDown(object sender, MouseEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                // Permite que o usuário clique onde quiser no texto
                textBox.Select(textBox.GetCharIndexFromPosition(e.Location), 0);
            }
        }

        // Evento específico para o MaskedTextBox - comportamento inteligente
        private void MtxtDataNasc_MouseDown(object sender, MouseEventArgs e)
        {
            var maskedTextBox = sender as MaskedTextBox;
            if (maskedTextBox != null)
            {
                if (maskedTextBox.MaskCompleted)
                {
                    // Se já tem data completa, vai para onde o usuário clicou
                    int charIndex = maskedTextBox.GetCharIndexFromPosition(e.Location);
                    maskedTextBox.Select(charIndex, 0);
                }
                else
                {
                    // Se não tem data completa, vai para o primeiro espaço vazio
                    for (int i = 0; i < maskedTextBox.Text.Length; i++)
                    {
                        if (maskedTextBox.Text[i] == '_' || maskedTextBox.Text[i] == ' ')
                        {
                            maskedTextBox.Select(i, 0);
                            return;
                        }
                    }
                    // Se tudo preenchido, vai para o final
                    maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                }
            }
        }

        // Quando o campo de data ganha foco, vai para a posição mais inteligente
        private void MtxtDataNasc_Enter(object sender, EventArgs e)
        {
            var maskedTextBox = sender as MaskedTextBox;
            if (maskedTextBox != null)
            {
                if (maskedTextBox.MaskCompleted)
                {
                    // Se já tem data completa, cursor no FINAL
                    maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                }
                else
                {
                    // Se não tem data completa, vai para o primeiro espaço vazio
                    for (int i = 0; i < maskedTextBox.Text.Length; i++)
                    {
                        if (maskedTextBox.Text[i] == '_' || maskedTextBox.Text[i] == ' ')
                        {
                            maskedTextBox.Select(i, 0);
                            return;
                        }
                    }
                    // Se tudo preenchido, vai para o final
                    maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                }
            }
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

                // Verifica se estamos no último campo
                if (sender == mtxtDataNasc)
                {
                    // ✅ MODIFICADO: Em vez de focar no botão, executa a ação de salvar diretamente
                    BtnSalvar_Click(btnSalvar, EventArgs.Empty);
                }
                else
                {
                    // Vai para o próximo campo
                    SelectNextControl((Control)sender, true, true, true, true);

                    // Se foi para o campo de data, ajusta o cursor
                    if (ActiveControl == mtxtDataNasc)
                    {
                        var maskedTextBox = ActiveControl as MaskedTextBox;
                        if (maskedTextBox != null)
                        {
                            if (maskedTextBox.MaskCompleted)
                            {
                                // Se já tem data, cursor no FINAL
                                maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                            }
                            else
                            {
                                // Procura primeiro espaço vazio
                                for (int i = 0; i < maskedTextBox.Text.Length; i++)
                                {
                                    if (maskedTextBox.Text[i] == '_' || maskedTextBox.Text[i] == ' ')
                                    {
                                        maskedTextBox.Select(i, 0);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // ✅ ADICIONADO: Evento de teclado para o botão Salvar
        private void BtnSalvar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                BtnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        // ✅ ADICIONADO: Evento de teclado para o botão Cancelar
        private void BtnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                BtnCancelar_Click(sender, e);
            }
        }

        // ✅ ADICIONADO: Evento de teclado para o formulário
        private void FormAddFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter && ActiveControl is Button)
            {
                // Se estiver em um botão e pressionar Enter, executa o clique
                var button = ActiveControl as Button;
                if (button != null)
                {
                    e.SuppressKeyPress = true;
                    button.PerformClick();
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
            bool dadosValidos = true;

            // Validação do Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MostrarErroCampo("Digite o nome do funcionário", txtNome);
                dadosValidos = false;
            }
            else if (txtNome.Text.Trim().Length < 3)
            {
                MostrarErroCampo("O nome deve ter pelo menos 3 caracteres", txtNome);
                dadosValidos = false;
            }
            else if (txtNome.Text.Trim().Length > 100)
            {
                MostrarErroCampo("O nome deve ter no máximo 100 caracteres", txtNome);
                dadosValidos = false;
            }

            // Validação do Cargo
            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MostrarErroCampo("Digite o cargo do funcionário", txtCargo);
                dadosValidos = false;
            }
            else if (txtCargo.Text.Trim().Length < 2)
            {
                MostrarErroCampo("O cargo deve ter pelo menos 2 caracteres", txtCargo);
                dadosValidos = false;
            }
            else if (txtCargo.Text.Trim().Length > 50)
            {
                MostrarErroCampo("O cargo deve ter no máximo 50 caracteres", txtCargo);
                dadosValidos = false;
            }

            // Validação da Data
            if (!mtxtDataNasc.MaskCompleted)
            {
                MostrarErroCampo("Preencha a data de nascimento no formato dd/mm/aaaa", mtxtDataNasc);
                dadosValidos = false;
            }
            else if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
            {
                MostrarErroCampo("Data de nascimento inválida. Use o formato dd/mm/aaaa", mtxtDataNasc);
                dadosValidos = false;
            }
            else
            {
                // Validação se a data não é futura
                if (dataNasc > DateTime.Today)
                {
                    MostrarErroCampo("A data de nascimento não pode ser futura", mtxtDataNasc);
                    dadosValidos = false;
                }
                else
                {
                    // Validação se a pessoa tem pelo menos 1 ano (mínimo)
                    if (dataNasc > DateTime.Today.AddYears(-1))
                    {
                        MostrarErroCampo("O funcionário deve ter pelo menos 1 ano de idade", mtxtDataNasc);
                        dadosValidos = false;
                    }

                    // Validação se a pessoa tem no máximo 110 anos (máximo)
                    if (dataNasc < DateTime.Today.AddYears(-110))
                    {
                        MostrarErroCampo("A data de nascimento não pode ser de mais de 110 anos atrás", mtxtDataNasc);
                        dadosValidos = false;
                    }

                    // Verificação adicional: idade deve estar entre 1 e 110 anos
                    int idade = CalcularIdade(dataNasc);
                    if (idade < 1)
                    {
                        MostrarErroCampo("O funcionário deve ter pelo menos 1 ano completo", mtxtDataNasc);
                        dadosValidos = false;
                    }

                    if (idade > 110)
                    {
                        MostrarErroCampo("O funcionário não pode ter mais de 110 anos", mtxtDataNasc);
                        dadosValidos = false;
                    }
                }
            }

            return dadosValidos;
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - dataNascimento.Year;

            // Subtrai um ano se ainda não fez aniversário este ano
            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

        // ✅ MODIFICADO: Método para mostrar erro SEM pintar o fundo
        private void MostrarErroCampo(string mensagem, Control controle)
        {
            // Foca no campo
            controle.Focus();

            // Para campos de texto, seleciona tudo para facilitar correção
            if (controle is TextBox textBox)
            {
                textBox.SelectAll();
            }
            else if (controle is MaskedTextBox maskedTextBox)
            {
                // Para data, vai para o final para facilitar edição
                maskedTextBox.Select(maskedTextBox.Text.Length, 0);
            }

            // Mostra mensagem de erro
            MessageBox.Show(mensagem, "Validação",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // 3) Verificar se já existe funcionário com mesmo nome (opcional)
                string verificarDuplicadoSql = "SELECT COUNT(*) FROM FUNCIONARIO WHERE UPPER(NOME) = @nome;";
                var duplicadoParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@nome", nomeFormatado)
                };

                int existe = Convert.ToInt32(DatabaseHelper.ExecuteScalar(verificarDuplicadoSql, duplicadoParams));
                if (existe > 0)
                {
                    var result = MessageBox.Show($"Já existe um funcionário com o nome '{nomeFormatado}'.\n\nDeseja continuar mesmo assim?",
                        "Funcionário Duplicado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                    {
                        txtNome.Focus();
                        txtNome.SelectAll();
                        return;
                    }
                }

                // 4) Fazer INSERT
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

        // Eventos para quando entra nos campos
        private void txtNome_Enter(object sender, EventArgs e)
        {
            // Quando entra no campo, cursor vai para o FINAL
            txtNome.Select(txtNome.Text.Length, 0);
        }

        private void txtCargo_Enter(object sender, EventArgs e)
        {
            // Quando entra no campo, cursor vai para o FINAL
            txtCargo.Select(txtCargo.Text.Length, 0);
        }

        private void mtxtDataNasc_Enter(object sender, EventArgs e)
        {
            // Não fazemos nada aqui, o evento MtxtDataNasc_Enter já cuida disso
        }
    }
}