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

            // ✅ Configurar limites de caracteres
            ConfigurarLimitesCaracteres();

            // ✅ Carregar os dados quando o formulário for carregado
            this.Load += FormEditarFuncionario_Load;

            // ✅ Eventos para limitar caracteres em tempo real
            txtNome.TextChanged += TxtNome_TextChanged;
            txtCargo.TextChanged += TxtCargo_TextChanged;

            // ✅ Eventos para melhor experiência de edição (REPLICA DA TELA DE ADICIONAR)
            ConfigurarEventosEdicao();

            // ✅ Configurar teclas de atalho
            this.KeyPreview = true;
            this.KeyDown += FormEditarFuncionario_KeyDown;

            // ✅ Eventos para teclas nos botões
            btnSalvar.KeyDown += BtnSalvar_KeyDown;
            btnCancelar.KeyDown += BtnCancelar_KeyDown;
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Configurar eventos de edição
        private void ConfigurarEventosEdicao()
        {
            // Eventos para campos de texto
            txtNome.MouseDown += Txt_MouseDown;
            txtCargo.MouseDown += Txt_MouseDown;
            mtxtDataNasc.MouseDown += MtxtDataNasc_MouseDown;

            txtNome.Enter += TxtNome_Enter;
            txtCargo.Enter += TxtCargo_Enter;
            mtxtDataNasc.Enter += MtxtDataNasc_Enter;

            // Eventos de teclado para navegação
            txtNome.KeyDown += Txt_KeyDown;
            txtCargo.KeyDown += Txt_KeyDown;
            mtxtDataNasc.KeyDown += Txt_KeyDown;
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Configurar limites de caracteres
        private void ConfigurarLimitesCaracteres()
        {
            txtNome.MaxLength = 100;
            txtCargo.MaxLength = 50;
            mtxtDataNasc.Mask = "00/00/0000";
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Evento genérico para campos de texto
        private void Txt_MouseDown(object sender, MouseEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Select(textBox.GetCharIndexFromPosition(e.Location), 0);
            }
        }

        private void TxtNome_Enter(object sender, EventArgs e)
        {
            txtNome.Select(txtNome.Text.Length, 0);
        }

        private void TxtCargo_Enter(object sender, EventArgs e)
        {
            txtCargo.Select(txtCargo.Text.Length, 0);
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Evento específico para o MaskedTextBox
        private void MtxtDataNasc_MouseDown(object sender, MouseEventArgs e)
        {
            var maskedTextBox = sender as MaskedTextBox;
            if (maskedTextBox != null)
            {
                if (maskedTextBox.MaskCompleted)
                {
                    int charIndex = maskedTextBox.GetCharIndexFromPosition(e.Location);
                    maskedTextBox.Select(charIndex, 0);
                }
                else
                {
                    for (int i = 0; i < maskedTextBox.Text.Length; i++)
                    {
                        if (maskedTextBox.Text[i] == '_' || maskedTextBox.Text[i] == ' ')
                        {
                            maskedTextBox.Select(i, 0);
                            return;
                        }
                    }
                    maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                }
            }
        }

        private void MtxtDataNasc_Enter(object sender, EventArgs e)
        {
            var maskedTextBox = sender as MaskedTextBox;
            if (maskedTextBox != null)
            {
                if (maskedTextBox.MaskCompleted)
                {
                    maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                }
                else
                {
                    for (int i = 0; i < maskedTextBox.Text.Length; i++)
                    {
                        if (maskedTextBox.Text[i] == '_' || maskedTextBox.Text[i] == ' ')
                        {
                            maskedTextBox.Select(i, 0);
                            return;
                        }
                    }
                    maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                }
            }
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Validação em tempo real para o campo Nome
        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 100)
            {
                txtNome.Text = txtNome.Text.Substring(0, 100);
                txtNome.Select(txtNome.Text.Length, 0);
            }
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Validação em tempo real para o campo Cargo
        private void TxtCargo_TextChanged(object sender, EventArgs e)
        {
            if (txtCargo.Text.Length > 50)
            {
                txtCargo.Text = txtCargo.Text.Substring(0, 50);
                txtCargo.Select(txtCargo.Text.Length, 0);
            }
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Navegação por teclado
        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Verifica se estamos no último campo
                if (sender == mtxtDataNasc)
                {
                    // ✅ MODIFICADO: Em vez de focar no botão, executa a ação de salvar
                    BtnSalvar_Click(btnSalvar, EventArgs.Empty);
                }
                else
                {
                    SelectNextControl((Control)sender, true, true, true, true);

                    if (ActiveControl == mtxtDataNasc)
                    {
                        var maskedTextBox = ActiveControl as MaskedTextBox;
                        if (maskedTextBox != null)
                        {
                            if (maskedTextBox.MaskCompleted)
                            {
                                maskedTextBox.Select(maskedTextBox.Text.Length, 0);
                            }
                            else
                            {
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
        }

        // ✅ Evento de tecla para o botão Salvar
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

        // ✅ Evento de tecla para o botão Cancelar
        private void BtnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                BtnCancelar_Click(sender, e);
            }
        }

        // ✅ REPLICA DA TELA DE ADICIONAR: Tecla Escape para fechar
        private void FormEditarFuncionario_KeyDown(object sender, KeyEventArgs e)
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

        private void FormEditarFuncionario_Load(object sender, EventArgs e)
        {
            if (funcionarioId.HasValue)
            {
                CarregarFuncionario(funcionarioId.Value);
            }

            txtNome.Focus();
            txtNome.Select(txtNome.Text.Length, 0);
        }

        private void CarregarFuncionario(int id)
        {
            try
            {
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

                var dataText = row["DATA_NASCIMENTO"]?.ToString();
                if (!string.IsNullOrEmpty(dataText))
                {
                    if (DateTime.TryParseExact(dataText, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtNasc))
                    {
                        mtxtDataNasc.Text = dtNasc.ToString("dd/MM/yyyy");
                    }
                    else if (DateTime.TryParse(dataText, out DateTime dtParse))
                    {
                        mtxtDataNasc.Text = dtParse.ToString("dd/MM/yyyy");
                    }
                    else
                    {
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

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarDados()) return;

            if (funcionarioId.HasValue)
                AtualizarFuncionario(funcionarioId.Value);
            else
                InserirFuncionario();
        }

        // ✅ REPLICA EXATA DA TELA DE ADICIONAR: Validação de dados (SEM PINTURA DE FUNDO)
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
            else if (!DateTime.TryParseExact(mtxtDataNasc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
            {
                MostrarErroCampo("Data de nascimento inválida. Use o formato dd/mm/aaaa", mtxtDataNasc);
                dadosValidos = false;
            }
            else
            {
                // Validações da data - REPLICA EXATA DA TELA DE ADICIONAR
                if (dataNasc > DateTime.Today)
                {
                    MostrarErroCampo("A data de nascimento não pode ser futura", mtxtDataNasc);
                    dadosValidos = false;
                }
                else
                {
                    // ✅ VALIDAÇÃO DE MÍNIMO 1 ANO (EXATA COMO NA TELA DE ADICIONAR)
                    if (dataNasc > DateTime.Today.AddYears(-1))
                    {
                        MostrarErroCampo("O funcionário deve ter pelo menos 1 ano de idade", mtxtDataNasc);
                        dadosValidos = false;
                    }

                    // ✅ VALIDAÇÃO DE MÁXIMO 110 ANOS (EXATA COMO NA TELA DE ADICIONAR)
                    if (dataNasc < DateTime.Today.AddYears(-110))
                    {
                        MostrarErroCampo("A data de nascimento não pode ser de mais de 110 anos atrás", mtxtDataNasc);
                        dadosValidos = false;
                    }

                    // ✅ VERIFICAÇÃO ADICIONAL POR CÁLCULO DE IDADE (EXATA COMO NA TELA DE ADICIONAR)
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

        // ✅ REPLICA EXATA DA TELA DE ADICIONAR: Método para calcular idade
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

                // ✅ VERIFICAR DUPLICIDADE (EXATA COMO NA TELA DE ADICIONAR)
                string verificarDuplicadoSql = @"SELECT COUNT(*) FROM FUNCIONARIO 
                                                 WHERE UPPER(NOME) = @nome 
                                                 AND ID_FUNCIONARIO != @id;";
                var duplicadoParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@nome", nome),
                    new SQLiteParameter("@id", id)
                };

                int existe = Convert.ToInt32(DatabaseHelper.ExecuteScalar(verificarDuplicadoSql, duplicadoParams));
                if (existe > 0)
                {
                    var result = MessageBox.Show($"Já existe outro funcionário com o nome '{nome}'.\n\nDeseja continuar mesmo assim?",
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

                // ✅ VERIFICAR DUPLICIDADE (EXATA COMO NA TELA DE ADICIONAR)
                string verificarDuplicadoSql = "SELECT COUNT(*) FROM FUNCIONARIO WHERE UPPER(NOME) = @nome;";
                var duplicadoParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@nome", nome)
                };

                int existe = Convert.ToInt32(DatabaseHelper.ExecuteScalar(verificarDuplicadoSql, duplicadoParams));
                if (existe > 0)
                {
                    var result = MessageBox.Show($"Já existe um funcionário com o nome '{nome}'.\n\nDeseja continuar mesmo assim?",
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