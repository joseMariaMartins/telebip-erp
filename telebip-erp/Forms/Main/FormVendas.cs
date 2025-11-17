using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormVendas : Form
    {
        private string textoPesquisa = "";
        private readonly string placeholder = "Digite para pesquisar...";

        // Mapeamento entre os nomes exibidos e os nomes no banco
        private readonly Dictionary<string, string> campoMap = new Dictionary<string, string>
        {
            { "ID", "ID_VENDA" },
            { "Funcionário", "NOME_FUNCIONARIO" },
            { "Data", "DATA_HORA" },
            { "Valor total", "VALOR_TOTAL" },
            { "Desconto", "DESCONTO" }
        };

        public FormVendas()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        #region Configuração Inicial do Formulário
        private void ConfigurarFormulario()
        {
            // Configurações básicas do Form
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Configura eventos
            ConfigurarEventos();

            // Aplica estilos visuais
            AplicarEstilosVisuais();

            // Configurações iniciais
            ConfiguracoesIniciais();

            this.Shown += FormVendas_Shown;
        }

        private void ConfigurarEventos()
        {
            // Eventos dos botões
            btnPesquisar.Click += BtnPesquisar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            // Eventos do TextBox (placeholder)
            tbPesquisa.GotFocus += TbPesquisa_GotFocus;
            tbPesquisa.LostFocus += TbPesquisa_LostFocus;
            tbPesquisa.KeyPress += TbPesquisa_KeyPress;
            tbPesquisa.TextChanged += TbPesquisa_TextChanged;

            // Eventos das Comboboxes
            try
            {
                cbPesquisaCampo.DrawItem -= Cb_DrawItem;
                cbPesquisaCampo.DrawItem += Cb_DrawItem;
                cbPesquisaCampo.FlatStyle = FlatStyle.Flat;
            }
            catch { }

            try
            {
                cbCondicao.DrawItem -= Cb_DrawItem;
                cbCondicao.DrawItem += Cb_DrawItem;
                cbCondicao.FlatStyle = FlatStyle.Flat;
            }
            catch { }

            // Eventos de clique nos wrappers e pictureboxes
            ConfigurarEventosClique();

            // Evento de double click
            dgvVendas.CellDoubleClick -= dgvVendas_CellDoubleClick;
            dgvVendas.CellDoubleClick += dgvVendas_CellDoubleClick;

            // Ajuste de tamanho quando redimensionar
            this.Resize -= DgvVendas_Resize;
            this.Resize += DgvVendas_Resize;
            dgvVendas.Resize -= DgvVendas_Resize;
            dgvVendas.Resize += DgvVendas_Resize;
        }

        private void AplicarEstilosVisuais()
        {
            // Estilo dos wrappers - CORES IDÊNTICAS AO FORM ESTOQUE
            StyleComboWrapperPanel(pnlWrapperCampo, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
            StyleComboWrapperPanel(pnlWrapperCondicao, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
            StyleTextboxWrapperPanel(pnlWrapperPesquisa, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);

            // Tema da DataGridView - CORES IDÊNTICAS AO FORM ESTOQUE
            AplicarTemaEscuroDataGridView();
        }

        private void ConfiguracoesIniciais()
        {
            // Placeholder inicial
            tbPesquisa.Text = placeholder;
            tbPesquisa.ForeColor = Color.FromArgb(160, 160, 160);

            // Comboboxes
            ConfigurarComboBoxInicial();

            // Carrega dados iniciais
            CarregarVendasInicial();
        }
        #endregion

        #region Eventos de Clique nos Controles
        private void ConfigurarEventosClique()
        {
            // Combobox 1 - Campo (wrapper)
            try
            {
                pnlWrapperCampo.Click -= PnlWrapperCampo_Click;
                pnlWrapperCampo.Click += PnlWrapperCampo_Click;
            }
            catch { }

            // PictureArrow/Chevron do campo
            try
            {
                pictureBox2.Click -= PicArrowCampo_Click;
                pictureBox2.Click += PicArrowCampo_Click;
            }
            catch { }

            // Combobox 2 - Condição (wrapper)
            try
            {
                pnlWrapperCondicao.Click -= PnlWrapperCondicao_Click;
                pnlWrapperCondicao.Click += PnlWrapperCondicao_Click;
            }
            catch { }

            // PictureArrow/Chevron da condição
            try
            {
                pictureBox1.Click -= PicArrowCondicao_Click;
                pictureBox1.Click += PicArrowCondicao_Click;
            }
            catch { }

            // Textbox - pesquisa (wrapper e ícone)
            try
            {
                pnlWrapperPesquisa.Click -= PnlWrapperPesquisa_Click;
                pnlWrapperPesquisa.Click += PnlWrapperPesquisa_Click;
            }
            catch { }

            try
            {
                picSearch.Click -= PicSearch_Click;
                picSearch.Click += PicSearch_Click;
            }
            catch { }
        }

        private void PnlWrapperCampo_Click(object sender, EventArgs e)
        {
            try
            {
                cbPesquisaCampo.Focus();
                cbPesquisaCampo.DroppedDown = true;
            }
            catch { }
        }

        private void PnlWrapperCondicao_Click(object sender, EventArgs e)
        {
            try
            {
                cbCondicao.Focus();
                cbCondicao.DroppedDown = true;
            }
            catch { }
        }

        private void PnlWrapperPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                tbPesquisa.Focus();
            }
            catch { }
        }

        private void PicSearch_Click(object sender, EventArgs e)
        {
            try
            {
                tbPesquisa.Focus();
            }
            catch { }
        }
        #endregion

        #region Estilização de Controles
        // DrawItem customizado para Comboboxes - remove hover padrão
        private void Cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // CORES IDÊNTICAS AO FORM ESTOQUE
            Color back = Color.FromArgb(40, 41, 52);
            Color fore = Color.White;
            Color selBack = Color.FromArgb(60, 62, 80);

            using (SolidBrush b = new SolidBrush(back))
                e.Graphics.FillRectangle(b, e.Bounds);

            if (e.Index >= 0)
            {
                string text = cb.GetItemText(cb.Items[e.Index]);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    using (SolidBrush selBrush = new SolidBrush(selBack))
                        e.Graphics.FillRectangle(selBrush, e.Bounds);
                }

                Rectangle textRect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height);
                TextRenderer.DrawText(e.Graphics, text, cb.Font, textRect, fore, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e.DrawFocusRectangle();
        }

        // Helpers para bordas arredondadas
        private GraphicsPath GetRoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = Math.Max(0, radius * 2);
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void StyleComboWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            try
            {
                wrapper.BackColor = fill;
                wrapper.Paint -= Wrapper_Paint;
                wrapper.Paint += Wrapper_Paint;
                void Wrapper_Paint(object s, PaintEventArgs e)
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);
                    using (var path = GetRoundedRect(rect, radius))
                    using (var pen = new Pen(border, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
                wrapper.Resize -= Wrapper_Resize;
                wrapper.Resize += Wrapper_Resize;
                void Wrapper_Resize(object s, EventArgs e) => wrapper.Invalidate();
            }
            catch { }
        }

        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            try
            {
                wrapper.BackColor = fill;
                wrapper.Paint -= Wrapper_Paint;
                wrapper.Paint += Wrapper_Paint;
                void Wrapper_Paint(object s, PaintEventArgs e)
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);
                    using (var path = GetRoundedRect(rect, radius))
                    using (var pen = new Pen(border, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
                wrapper.Resize -= Wrapper_Resize;
                wrapper.Resize += Wrapper_Resize;
                void Wrapper_Resize(object s, EventArgs e) => wrapper.Invalidate();
            }
            catch { }
        }
        #endregion

        #region Configuração e Estilo da DataGridView
        private void AplicarTemaEscuroDataGridView()
        {
            dgvVendas.SuspendLayout();

            // CORES IDÊNTICAS À TELA DE ESTOQUE
            Color background = Color.FromArgb(32, 33, 39);
            Color headerBack = Color.FromArgb(40, 41, 52); // Cabeçalho preto igual ao estoque
            Color gridColor = Color.FromArgb(50, 52, 67);
            Color selectionBack = Color.FromArgb(50, 90, 130); // Azul de seleção igual ao estoque
            Color fore = Color.White;

            // Configurações gerais
            dgvVendas.BackgroundColor = background;
            dgvVendas.BorderStyle = BorderStyle.None;
            dgvVendas.GridColor = gridColor;
            dgvVendas.EnableHeadersVisualStyles = false;

            // Cabeçalho - IDÊNTICO AO ESTOQUE
            var headerStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = headerBack,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = fore,
                SelectionBackColor = headerBack,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True
            };
            dgvVendas.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvVendas.ColumnHeadersHeight = 40;
            dgvVendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVendas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Linhas - IDÊNTICO AO ESTOQUE
            var cellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = background,
                Font = new Font("Segoe UI", 9F),
                ForeColor = fore,
                SelectionBackColor = selectionBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.False
            };
            dgvVendas.DefaultCellStyle = cellStyle;
            dgvVendas.RowsDefaultCellStyle = cellStyle;
            dgvVendas.AlternatingRowsDefaultCellStyle = cellStyle;
            dgvVendas.RowTemplate.Height = 35;
            dgvVendas.RowTemplate.DefaultCellStyle = cellStyle;

            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.AllowUserToDeleteRows = false;
            dgvVendas.AllowUserToResizeRows = false;
            dgvVendas.MultiSelect = false;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.ReadOnly = true;
            dgvVendas.RowHeadersVisible = false;
            dgvVendas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvVendas.ClearSelection();
            dgvVendas.CurrentCell = null;

            dgvVendas.ResumeLayout();
        }

        private void ConfigurarColunasDataGridView()
        {
            if (dgvVendas.Columns.Count == 0) return;

            // CONFIGURAÇÃO ORIGINAL: Dock Fill + textos centralizados
            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configura todas as colunas com alinhamento centralizado
            foreach (DataGridViewColumn coluna in dgvVendas.Columns)
            {
                // CABEÇALHOS E CONTEÚDO CENTRALIZADOS
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                coluna.Resizable = DataGridViewTriState.True;
                coluna.MinimumWidth = 80;
            }

            // Configura cabeçalhos específicos
            ConfigurarCabecalhosColunas();
        }

        private void ConfigurarCabecalhosColunas()
        {
            // Configura os textos dos cabeçalhos mantendo alinhamento centralizado
            if (dgvVendas.Columns.Contains("ID_VENDA"))
            {
                dgvVendas.Columns["ID_VENDA"].HeaderText = "ID";
                dgvVendas.Columns["ID_VENDA"].FillWeight = 10;
            }

            if (dgvVendas.Columns.Contains("NOME_FUNCIONARIO"))
            {
                dgvVendas.Columns["NOME_FUNCIONARIO"].HeaderText = "Funcionário";
                dgvVendas.Columns["NOME_FUNCIONARIO"].FillWeight = 30;
            }

            if (dgvVendas.Columns.Contains("DATA_HORA"))
            {
                dgvVendas.Columns["DATA_HORA"].HeaderText = "Data";
                dgvVendas.Columns["DATA_HORA"].FillWeight = 20;
            }

            if (dgvVendas.Columns.Contains("VALOR_TOTAL"))
            {
                dgvVendas.Columns["VALOR_TOTAL"].HeaderText = "Valor Total";
                dgvVendas.Columns["VALOR_TOTAL"].DefaultCellStyle.Format = "C2";
                dgvVendas.Columns["VALOR_TOTAL"].FillWeight = 20;
            }

            if (dgvVendas.Columns.Contains("DESCONTO"))
            {
                dgvVendas.Columns["DESCONTO"].HeaderText = "Desconto";
                dgvVendas.Columns["DESCONTO"].DefaultCellStyle.Format = "C2";
                dgvVendas.Columns["DESCONTO"].FillWeight = 20;
            }
        }

        private void DgvVendas_Resize(object sender, EventArgs e)
        {
            // Mantém o comportamento original com Dock Fill
            // O Fill mode já cuida do redimensionamento automático
        }
        #endregion

        #region Placeholder TextBox
        private void TbPesquisa_GotFocus(object sender, EventArgs e)
        {
            if (tbPesquisa.Text == placeholder)
            {
                tbPesquisa.Text = "";
                tbPesquisa.ForeColor = Color.White;
            }
        }

        private void TbPesquisa_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPesquisa.Text))
            {
                tbPesquisa.Text = placeholder;
                tbPesquisa.ForeColor = Color.FromArgb(160, 160, 160);
            }
        }

        private void TbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tbPesquisa.Text == placeholder)
            {
                tbPesquisa.Text = "";
                tbPesquisa.ForeColor = Color.White;
            }

            textoPesquisa = tbPesquisa.Text + e.KeyChar;
        }

        private void TbPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (tbPesquisa.Text != placeholder)
            {
                textoPesquisa = tbPesquisa.Text;
            }
            else
            {
                textoPesquisa = "";
            }
        }

        private string ObterTextoPesquisa()
        {
            try
            {
                if (!string.IsNullOrEmpty(tbPesquisa.Text) && tbPesquisa.Text != placeholder)
                    return tbPesquisa.Text;
            }
            catch { }

            return textoPesquisa;
        }
        #endregion

        #region Comboboxes e Filtros
        private void ConfigurarComboBoxInicial()
        {
            try
            {
                cbCondicao.Items.Clear();
                cbCondicao.Items.AddRange(new object[] { "Idêntico a", "Inicia com", "Contendo", "Diferente de" });

                SelecionarPrimeiroItem(cbPesquisaCampo);
                SelecionarPrimeiroItem(cbCondicao);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao configurar combobox: " + ex.Message);
            }
        }

        private void SelecionarPrimeiroItem(ComboBox comboBox)
        {
            try
            {
                if (comboBox == null || comboBox.Items == null || comboBox.Items.Count == 0)
                    return;

                comboBox.SelectedIndex = 0;
                comboBox.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao selecionar primeiro item: " + ex.Message);
            }
        }

        private string ObterValorSelecionado(ComboBox comboBox)
        {
            try
            {
                if (comboBox.SelectedItem != null)
                    return comboBox.SelectedItem.ToString() ?? "";

                return comboBox.Text ?? "";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region Operações de Banco de Dados
        public void CarregarVendas(string filtroSql = "", SQLiteParameter[] parametros = null, bool limitar20 = false)
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

                // Aplica o tema escuro antes de carregar os dados
                AplicarTemaEscuroDataGridView();

                dgvVendas.DataSource = dt;

                ConfigurarColunasDataGridView();

                dgvVendas.ClearSelection();
                dgvVendas.CurrentCell = null;

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar vendas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarVendasInicial()
        {
            CarregarVendas(limitar20: true);
        }

        public void AtualizarTabela()
        {
            try
            {
                string texto = ObterTextoPesquisa();

                if (!string.IsNullOrEmpty(texto.Trim()))
                {
                    BtnPesquisar_Click(null, EventArgs.Empty);
                }
                else
                {
                    CarregarVendasInicial();
                }
                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar tabela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos dos Botões
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string campoSelecionado = ObterValorSelecionado(cbPesquisaCampo);
            string condicao = ObterValorSelecionado(cbCondicao);
            string valor = ObterTextoPesquisa().Trim();

            if (!string.IsNullOrEmpty(valor))
                valor = valor.ToUpper();

            string campo = campoSelecionado switch
            {
                "ID" => "ID_VENDA",
                "Funcionário" => "NOME_FUNCIONARIO",
                "Data" => "DATA_HORA",
                "Valor total" => "VALOR_TOTAL",
                "Desconto" => "DESCONTO",
                _ => ""
            };

            if (string.IsNullOrEmpty(campo) || string.IsNullOrEmpty(condicao))
            {
                MessageBox.Show("Selecione o campo e a condição de pesquisa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Digite um termo para pesquisar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtroSql = "";
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Idêntico a":
                    if (campo == "ID_VENDA" || campo == "VALOR_TOTAL" || campo == "DESCONTO")
                    {
                        if (decimal.TryParse(valor, out decimal numero))
                        {
                            filtroSql = $"{campo} = @valor";
                            parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", numero) };
                        }
                        else
                        {
                            MessageBox.Show("Para este campo, digite um valor numérico válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        filtroSql = $"UPPER({campo}) = UPPER(@valor)";
                        parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    }
                    break;

                case "Inicia com":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor + "%") };
                    break;

                case "Contendo":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", "%" + valor + "%") };
                    break;

                case "Diferente de":
                    filtroSql = $"UPPER({campo}) <> UPPER(@valor)";
                    parametros = new SQLiteParameter[] { new SQLiteParameter("@valor", valor) };
                    break;

                default:
                    MessageBox.Show("Condição de pesquisa inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            CarregarVendas(filtroSql, parametros, limitar20: false);
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                textoPesquisa = "";
                tbPesquisa.Text = "";
                // Reaplica o placeholder
                TbPesquisa_LostFocus(tbPesquisa, EventArgs.Empty);

                // Limpa histórico de undo e seleção
                try { tbPesquisa.ClearUndo(); } catch { }
                tbPesquisa.SelectionStart = 0;
                tbPesquisa.SelectionLength = 0;

                // Remove o foco do tbPesquisa para evitar caret visível.
                this.ActiveControl = null;

                SelecionarPrimeiroItem(cbPesquisaCampo);
                SelecionarPrimeiroItem(cbCondicao);

                CarregarVendas(limitar20: true);

                dgvVendas.ClearSelection();
                dgvVendas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao limpar filtros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos da Interface
        private void FormVendas_Shown(object sender, EventArgs e)
        {
            // Garante que as comboboxes iniciem com o primeiro item
            try
            {
                if (cbPesquisaCampo != null && cbPesquisaCampo.Items != null && cbPesquisaCampo.Items.Count > 0)
                    cbPesquisaCampo.SelectedIndex = 0;
            }
            catch { }

            try
            {
                if (cbCondicao != null && cbCondicao.Items != null && cbCondicao.Items.Count > 0)
                    cbCondicao.SelectedIndex = 0;
            }
            catch { }

            dgvVendas.ClearSelection();
            dgvVendas.CurrentCell = null;
            AjustarTamanhoDataGridView();
        }

        private void AjustarTamanhoDataGridView()
        {
            if (dgvVendas.Parent is Panel panelPai)
            {
                // DOCK FILL ORIGINAL
                dgvVendas.Dock = DockStyle.Fill;
                dgvVendas.Margin = new Padding(0);
            }
        }

        private void dgvVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var linha = dgvVendas.Rows[e.RowIndex];

            try
            {
                int idVendaSelecionada = Convert.ToInt32(linha.Cells["ID_VENDA"].Value);
                string nomeFuncionario = linha.Cells["NOME_FUNCIONARIO"].Value?.ToString() ?? "";
                double desconto = Convert.ToDouble(linha.Cells["DESCONTO"].Value ?? 0);
                double valorTotal = Convert.ToDouble(linha.Cells["VALOR_TOTAL"].Value ?? 0);
                string dataHora = linha.Cells["DATA_HORA"].Value?.ToString() ?? "";

                var formConsulta = new FormAddVendasConsulta();
                formConsulta.VendaID = idVendaSelecionada;
                formConsulta.NomeFuncionario = nomeFuncionario;
                formConsulta.Desconto = desconto;
                formConsulta.ValorTotal = valorTotal;
                formConsulta.DataHora = dataHora;
                formConsulta.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados da venda: " + ex.Message,
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTotalItens()
        {
            lbTotal.Text = $"Total de vendas: {dgvVendas.Rows.Count}";
        }
        #endregion

        #region Métodos Públicos
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

                string sqlDeleteVenda = "DELETE FROM VENDA WHERE ID_VENDA = @id;";
                using var cmdVenda = new SQLiteCommand(sqlDeleteVenda, conn);
                cmdVenda.Parameters.AddWithValue("@id", idVenda);
                cmdVenda.ExecuteNonQuery();

                string sqlDeleteItens = "DELETE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using var cmdItens = new SQLiteCommand(sqlDeleteItens, conn);
                cmdItens.Parameters.AddWithValue("@id", idVenda);
                cmdItens.ExecuteNonQuery();

                string sqlDeletePagamento = "DELETE FROM PAGAMENTO WHERE ID_VENDA = @id;";
                using var cmdPagamento = new SQLiteCommand(sqlDeletePagamento, conn);
                cmdPagamento.Parameters.AddWithValue("@id", idVenda);
                cmdPagamento.ExecuteNonQuery();

                AtualizarTabela();
                MessageBox.Show("Venda removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover a venda: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos das PictureBox (setas)
        private void PicArrowCampo_Click(object sender, EventArgs e)
        {
            try
            {
                cbPesquisaCampo.Focus();
                cbPesquisaCampo.DroppedDown = true;
            }
            catch { }
        }

        private void PicArrowCondicao_Click(object sender, EventArgs e)
        {
            try
            {
                cbCondicao.Focus();
                cbCondicao.DroppedDown = true;
            }
            catch { }
        }
        #endregion
    }
}