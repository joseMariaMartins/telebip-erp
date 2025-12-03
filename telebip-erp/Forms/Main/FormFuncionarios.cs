using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;
using telebip_erp.Forms.SubForms;
using telebip_erp.Forms.SubSubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormFuncionarios : FormLoadForm
    {
        private int? funcionarioSelecionadoId = null;

        public FormFuncionarios()
        {
            InitializeComponent();
            CarregarFuncionarios();
            ConfigurarEventos();
            AtualizarCard(null);
            ConfigurarFiltros();
        }

        private void ConfigurarEventos()
        {
            btnAdicionar.Click += BtnAdicionar_Click;
            btnRemover.Click += BtnRemover_Click;
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;
            btnEditar.Click += btnEditar_Click;

            dgvFuncionarios.SelectionChanged += DgvFuncionarios_SelectionChanged;
            tbSearch.KeyDown += TbSearch_KeyDown;

            // Eventos dos filtros
            cbCondicao.SelectedIndexChanged += Filtro_Changed;
            neoFlatComboBox1.SelectedIndexChanged += Filtro_Changed;
        }

        private void ConfigurarFiltros()
        {
            // Configurar valores padrão
            cbCondicao.SelectedIndex = 0; // "Id"
            neoFlatComboBox1.SelectedIndex = 0; // "Inicia com"
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
                    // Aplicar filtro avançado baseado nas seleções dos combobox
                    string campo = cbCondicao.SelectedItem?.ToString() ?? "Nome";
                    string operador = neoFlatComboBox1.SelectedItem?.ToString() ?? "Contendo";
                    string valor = tbSearch.Text.Trim();

                    if (!string.IsNullOrEmpty(valor))
                    {
                        var condicao = GerarCondicaoFiltro(campo, operador, valor, out parametros);
                        if (!string.IsNullOrEmpty(condicao))
                        {
                            sql += " AND " + condicao;
                        }
                    }
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

        private string GerarCondicaoFiltro(string campo, string operador, string valor, out SQLiteParameter[] parametros)
        {
            parametros = null;

            if (string.IsNullOrEmpty(valor)) return "";

            // Mapear campo para coluna do banco
            string colunaBanco = campo.ToUpper() switch
            {
                "ID" => "ID_FUNCIONARIO",
                "NOME" => "NOME",
                "CARGO" => "CARGO",
                _ => "NOME"
            };

            // Mapear operador para condição SQL com parâmetros
            string condicao = "";
            switch (operador.ToUpper())
            {
                case "INICIA COM":
                    condicao = $"{colunaBanco} LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", $"{valor}%") };
                    break;
                case "CONTENDO":
                    condicao = $"{colunaBanco} LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", $"%{valor}%") };
                    break;
                case "DIFERENTE DE":
                    condicao = $"{colunaBanco} != @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    break;
                case "IDENTICO A":
                    condicao = $"{colunaBanco} = @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    break;
                default:
                    condicao = $"{colunaBanco} LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", $"%{valor}%") };
                    break;
            }

            return condicao;
        }

        private void ConfigurarDataGridView()
        {
            try
            {
                // ✅ CORREÇÃO: Configuração completa da DGV
                dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFuncionarios.MultiSelect = false;
                dgvFuncionarios.ReadOnly = true;
                dgvFuncionarios.AllowUserToAddRows = false;
                dgvFuncionarios.RowHeadersVisible = false;
                dgvFuncionarios.AllowUserToResizeRows = false;

                // ✅ NOVO: Centralização completa
                dgvFuncionarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvFuncionarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

                // ✅ CORREÇÃO: Configurar larguras manualmente com centralização
                foreach (DataGridViewColumn coluna in dgvFuncionarios.Columns)
                {
                    if (coluna == null) continue;

                    // ✅ NOVO: Centralizar todas as colunas
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    switch (coluna.Name.ToUpper())
                    {
                        case "ID":
                            coluna.HeaderText = "ID";
                            coluna.Visible = true;
                            coluna.Width = 80; // ✅ Aumentado para melhor visualização
                            break;
                        case "NOME":
                            coluna.HeaderText = "Nome";
                            coluna.Width = 250;
                            break;
                        case "CARGO":
                            coluna.HeaderText = "Cargo";
                            coluna.Width = 200;
                            break;
                        case "DATA_NASCIMENTO":
                            coluna.HeaderText = "Data de Nascimento";
                            coluna.Width = 150;
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
            // ✅ CORREÇÃO: Contagem precisa usando DataTable
            int total = 0;
            if (dgvFuncionarios.DataSource is DataTable dataTable)
            {
                total = dataTable.Rows.Count;
            }
            else
            {
                total = dgvFuncionarios.Rows.Count;
            }

            lbTotal.Text = $"Total: {total} funcionário(s)";
        }

        #endregion

        #region Eventos da Interface e Seleção

        private void DgvFuncionarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                var linha = dgvFuncionarios.SelectedRows[0];
                // ✅ VERIFICAÇÃO DE SEGURANÇA
                if (linha.Cells["ID"]?.Value != null && linha.Cells["ID"].Value != DBNull.Value)
                {
                    funcionarioSelecionadoId = Convert.ToInt32(linha.Cells["ID"].Value);
                    AtualizarCard(linha);
                }
            }
            else
            {
                funcionarioSelecionadoId = null;
                AtualizarCard(null);
            }
        }

        private void TbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPesquisar_Click(sender, e);
            }
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            // Pesquisa automática quando os filtros mudam (opcional)
            // Se quiser pesquisa automática, descomente a linha abaixo:
            // BtnPesquisar_Click(sender, e);
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

                // ✅ NOVO: Esconder a imagem quando não há seleção
                picCardAvatar.Visible = false;
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

                // ✅ NOVO: Mostrar e configurar a imagem quando há seleção
                picCardAvatar.Visible = true;
                ConfigurarAvatar(linha.Cells["NOME"].Value?.ToString());
            }
        }

        // ✅ NOVO: Método para configurar o avatar baseado no nome
        private void ConfigurarAvatar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                picCardAvatar.Image = null;
                return;
            }

            try
            {
                // Criar uma imagem de avatar com as iniciais
                var iniciais = ObterIniciais(nome);
                var avatarImage = CriarAvatar(iniciais, Color.FromArgb(70, 130, 180), Color.White, 76, 76);
                picCardAvatar.Image = avatarImage;
            }
            catch
            {
                picCardAvatar.Image = null;
            }
        }

        // ✅ NOVO: Obter iniciais do nome
        private string ObterIniciais(string nome)
        {
            if (string.IsNullOrEmpty(nome)) return "?";

            var partes = nome.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length == 0) return "?";

            if (partes.Length == 1)
                return partes[0].Length >= 1 ? partes[0].Substring(0, 1).ToUpper() : "?";

            return (partes[0].Substring(0, 1) + partes[partes.Length - 1].Substring(0, 1)).ToUpper();
        }

        // ✅ NOVO: Criar imagem de avatar
        private Bitmap CriarAvatar(string texto, Color corFundo, Color corTexto, int largura, int altura)
        {
            var bitmap = new Bitmap(largura, altura);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Desenhar fundo circular
                using (var brush = new SolidBrush(corFundo))
                {
                    graphics.FillEllipse(brush, 0, 0, largura, altura);
                }

                // Desenhar texto
                using (var font = new Font("Segoe UI", 18, FontStyle.Bold))
                using (var brush = new SolidBrush(corTexto))
                {
                    var tamanhoTexto = graphics.MeasureString(texto, font);
                    var x = (largura - tamanhoTexto.Width) / 2;
                    var y = (altura - tamanhoTexto.Height) / 2;
                    graphics.DrawString(texto, font, brush, x, y);
                }
            }
            return bitmap;
        }

        #endregion

        #region Botões de Ação - CRUD Completo

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            using (var formAddFuncionario = new FormAddFuncionario())
            {
                var resultado = formAddFuncionario.ShowDialog();

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
            try
            {
                string termoPesquisa = tbSearch.Text.Trim();

                // Se estiver vazio, carrega todos os funcionários
                if (string.IsNullOrEmpty(termoPesquisa))
                {
                    CarregarFuncionarios();
                    return;
                }

                // Validação para filtro por ID
                if (cbCondicao.SelectedItem?.ToString() == "Id")
                {
                    if (!int.TryParse(termoPesquisa, out _))
                    {
                        MessageBox.Show("Para filtrar por ID, digite um número válido.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbSearch.Focus();
                        tbSearch.SelectAll();
                        return;
                    }
                }

                // Aplica o filtro
                CarregarFuncionarios(termoPesquisa);

                // Feedback visual
                if (dgvFuncionarios.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum funcionário encontrado com os critérios de pesquisa.",
                        "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar funcionários: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpa o campo de pesquisa
                tbSearch.Text = "";

                // Reseta os filtros para valores padrão
                cbCondicao.SelectedIndex = 0;
                neoFlatComboBox1.SelectedIndex = 0;

                // Recarrega todos os funcionários
                CarregarFuncionarios();

                // ✅ CORREÇÃO: Não focar em nenhum controle - remover foco de tudo
                this.ActiveControl = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao limpar filtros: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos Públicos

        public void AtualizarDados()
        {
            CarregarFuncionarios();
        }

        #endregion

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!funcionarioSelecionadoId.HasValue)
            {
                MessageBox.Show("Selecione um funcionário para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ✅ CORREÇÃO: Remover mensagem duplicada - a mensagem será exibida apenas no FormEditarFuncionario
                using (var formEditarFuncionario = new FormEditarFuncionario(funcionarioSelecionadoId.Value))
                {
                    var resultado = formEditarFuncionario.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        CarregarFuncionarios();
                        // ✅ CORREÇÃO: Removida mensagem duplicada aqui
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir formulário de edição: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}