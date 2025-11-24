using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormEstoque : Form
    {
        private string textoPesquisa = "";
        private readonly string placeholder = "Digite para pesquisar...";

        public FormEstoque()
        {
            InitializeComponent();
            ConfigurarFormulario();
            cbPesquisaCampo.SelectedIndex = -1;
            cbPesquisaCampo.Text = "";
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

            this.Shown += FormEstoque_Shown;
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

            // Eventos das Comboboxes (NeoFlatComboBox deriva de ComboBox na maioria dos casos)
            try
            {
                cbPesquisaCampo.DrawItem -= Cb_DrawItem;
                cbPesquisaCampo.DrawItem += Cb_DrawItem;
                cbPesquisaCampo.FlatStyle = FlatStyle.Flat;
            }
            catch { /* controle pode já gerenciar visual */ }

            try
            {
                cbCondicao.DrawItem -= Cb_DrawItem;
                cbCondicao.DrawItem += Cb_DrawItem;
                cbCondicao.FlatStyle = FlatStyle.Flat;
            }
            catch { /* controle pode já gerenciar visual */ }

            // Eventos de clique nos wrappers e pictureboxes (handlers nomeados)
            ConfigurarEventosClique();

            // Evento de double click - com verificação para evitar duplicação
            dgvEstoque.CellDoubleClick -= DgvEstoque_CellDoubleClick;
            dgvEstoque.CellDoubleClick += DgvEstoque_CellDoubleClick;

            // Ajuste de tamanho quando redimensionar
            this.Resize -= DgvEstoque_Resize;
            this.Resize += DgvEstoque_Resize;
            dgvEstoque.Resize -= DgvEstoque_Resize;
            dgvEstoque.Resize += DgvEstoque_Resize;
        }

        private void AplicarEstilosVisuais()
        {
            // Estilo dos wrappers (os wrappers são RoundedPanel no Designer, mas tratamos como Panel)
            StyleComboWrapperPanel(pnlWrapperCampo, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
            StyleComboWrapperPanel(pnlWrapperCondicao, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
            StyleTextboxWrapperPanel(pnlWrapperPesquisa, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);

            // Tema da DataGridView
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
            CarregarEstoqueInicial();
        }
        #endregion

        #region Eventos de Clique nos Controles
        // Substitui lambdas por handlers nomeados para facilitar attach/detach e debugging
        private void ConfigurarEventosClique()
        {
            // Combobox 1 - Campo (wrapper)
            try
            {
                pnlWrapperCampo.Click -= PnlWrapperCampo_Click;
                pnlWrapperCampo.Click += PnlWrapperCampo_Click;
            }
            catch { /* segurança */ }

            // PictureArrow/Chevron do campo (renomeado no Designer para PictureImage2)
            try
            {
                PictureImage2.Click -= PicArrowCampo_Click;
                PictureImage2.Click += PicArrowCampo_Click;
            }
            catch { /* se o controle não existir em runtime */ }

            // Combobox 2 - Condição (wrapper)
            try
            {
                pnlWrapperCondicao.Click -= PnlWrapperCondicao_Click;
                pnlWrapperCondicao.Click += PnlWrapperCondicao_Click;
            }
            catch { /* segurança */ }

            // PictureArrow/Chevron da condição (pictureBox1)
            try
            {
                pictureBox1.Click -= PicArrowCondicao_Click;
                pictureBox1.Click += PicArrowCondicao_Click;
            }
            catch { /* segurança */ }

            // Textbox - pesquisa (wrapper e ícone)
            try
            {
                pnlWrapperPesquisa.Click -= PnlWrapperPesquisa_Click;
                pnlWrapperPesquisa.Click += PnlWrapperPesquisa_Click;
            }
            catch { /* segurança */ }

            try
            {
                picSearch.Click -= PicSearch_Click;
                picSearch.Click += PicSearch_Click;
            }
            catch { /* segurança */ }
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
            catch { /* segurança */ }
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
            catch { /* segurança */ }
        }
        #endregion

        #region Configuração e Estilo da DataGridView
        private void AplicarTemaEscuroDataGridView()
        {
            dgvEstoque.SuspendLayout();

            // Cores
            Color background = Color.FromArgb(32, 33, 39);       // fundo principal
            Color backgroundAlt = Color.FromArgb(38, 39, 46);    // fundo alternado das linhas
            Color headerBack = Color.FromArgb(40, 41, 52);       // cabeçalho
            Color gridColor = Color.FromArgb(50, 52, 67);        // linhas da grade
            Color selectionBack = Color.FromArgb(50, 90, 130);   // seleção azul escuro
            Color fore = Color.White;

            // Configurações gerais
            dgvEstoque.BackgroundColor = background;
            dgvEstoque.BorderStyle = BorderStyle.None;
            dgvEstoque.GridColor = gridColor;
            dgvEstoque.EnableHeadersVisualStyles = false;

            // Cabeçalho
            var headerStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter, // cabeçalho centralizado
                BackColor = headerBack,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = fore,
                SelectionBackColor = headerBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.True
            };
            dgvEstoque.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvEstoque.ColumnHeadersHeight = 40;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Linhas (texto à esquerda)
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

            var altCellStyle = new DataGridViewCellStyle(cellStyle)
            {
                BackColor = backgroundAlt
            };

            dgvEstoque.DefaultCellStyle = cellStyle;
            dgvEstoque.RowsDefaultCellStyle = cellStyle;
            dgvEstoque.AlternatingRowsDefaultCellStyle = altCellStyle;
            dgvEstoque.RowTemplate.Height = 35;

            // Garante alinhamento das colunas à esquerda
            foreach (DataGridViewColumn coluna in dgvEstoque.Columns)
            {
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeRows = false;
            dgvEstoque.MultiSelect = false;
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstoque.ReadOnly = true;
            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;
            dgvEstoque.Refresh();

            dgvEstoque.ResumeLayout();
        }


        private void ConfigurarColunasDataGridView()
        {
            if (dgvEstoque.Columns.Count == 0) return;

            // Remove o auto-size das colunas
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Configura todas as colunas como fixas, exceto a última
            for (int i = 0; i < dgvEstoque.Columns.Count; i++)
            {
                var coluna = dgvEstoque.Columns[i];

                // Define propriedades comuns
                coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Se for a última coluna, configura como fill
                if (i == dgvEstoque.Columns.Count - 1)
                {
                    coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    coluna.MinimumWidth = 100; // Largura mínima para a última coluna
                }
                else
                {
                    // Colunas fixas
                    coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    coluna.Resizable = DataGridViewTriState.False;
                }
            }

            // Configura cabeçalhos específicos
            ConfigurarCabecalhosColunas();

            // Aplica o redimensionamento após carregar os dados
            dgvEstoque.DataBindingComplete -= (s, e) => AjustarLarguraColunasFixas();
            dgvEstoque.DataBindingComplete += (s, e) => AjustarLarguraColunasFixas();
        }

        private void ConfigurarCabecalhosColunas()
        {
            // Configura os textos dos cabeçalhos
            if (dgvEstoque.Columns.Contains("ID_PRODUTO"))
            {
                dgvEstoque.Columns["ID_PRODUTO"].HeaderText = "ID";
                dgvEstoque.Columns["ID_PRODUTO"].Width = 60; // Largura fixa para ID
            }

            if (dgvEstoque.Columns.Contains("NOME"))
            {
                dgvEstoque.Columns["NOME"].HeaderText = "Nome do Produto";
                dgvEstoque.Columns["NOME"].MinimumWidth = 150;
            }

            if (dgvEstoque.Columns.Contains("MARCA"))
            {
                dgvEstoque.Columns["MARCA"].HeaderText = "Marca";
                dgvEstoque.Columns["MARCA"].MinimumWidth = 120;
            }

            if (dgvEstoque.Columns.Contains("PRECO"))
            {
                dgvEstoque.Columns["PRECO"].HeaderText = "Preço";
                dgvEstoque.Columns["PRECO"].DefaultCellStyle.Format = "C2";
                dgvEstoque.Columns["PRECO"].Width = 90;
            }

            if (dgvEstoque.Columns.Contains("QTD_ESTOQUE"))
            {
                dgvEstoque.Columns["QTD_ESTOQUE"].HeaderText = "Estoque Atual";
                dgvEstoque.Columns["QTD_ESTOQUE"].Width = 100;
            }

            if (dgvEstoque.Columns.Contains("QTD_AVISO"))
            {
                dgvEstoque.Columns["QTD_AVISO"].HeaderText = "Estoque Mínimo";
                dgvEstoque.Columns["QTD_AVISO"].Width = 110;
            }

            if (dgvEstoque.Columns.Contains("OBSERVACAO"))
            {
                dgvEstoque.Columns["OBSERVACAO"].HeaderText = "Observações";
                // Esta será a coluna flexível (última)
            }
        }

        private void AjustarLarguraColunasFixas()
        {
            if (dgvEstoque.Columns.Count == 0) return;

            int larguraTotalFixas = 0;

            // Calcula a largura total das colunas fixas
            for (int i = 0; i < dgvEstoque.Columns.Count - 1; i++)
            {
                larguraTotalFixas += dgvEstoque.Columns[i].Width;
            }

            // Adiciona margem para as bordas e scrollbar
            int margem = SystemInformation.VerticalScrollBarWidth + 2;

            // Se a soma das colunas fixas for maior que a área disponível
            if (larguraTotalFixas + margem > dgvEstoque.ClientSize.Width)
            {
                // Habilita a scrollbar horizontal e ajusta a última coluna
                dgvEstoque.Columns[dgvEstoque.Columns.Count - 1].Width = 100; // Largura mínima
            }
            else
            {
                // Ajusta a última coluna para preencher o restante
                int restante = dgvEstoque.ClientSize.Width - larguraTotalFixas - margem;
                if (restante > 100)
                    dgvEstoque.Columns[dgvEstoque.Columns.Count - 1].Width = restante;
                else
                    dgvEstoque.Columns[dgvEstoque.Columns.Count - 1].Width = 100;
            }
        }

        private void DgvEstoque_Resize(object sender, EventArgs e)
        {
            AjustarLarguraColunasFixas();
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
        public void CarregarEstoque(string filtroSql = "", SQLiteParameter[] parametros = null, bool limitar20 = false)
        {
            try
            {
                string sql = $@"
                    SELECT 
                        ID_PRODUTO,
                        NOME,
                        MARCA,
                        PRECO,
                        QTD_ESTOQUE,
                        QTD_AVISO,
                        OBSERVACAO
                    FROM PRODUTO
                    {(string.IsNullOrEmpty(filtroSql) ? "" : "WHERE " + filtroSql)}
                    ORDER BY ID_PRODUTO DESC
                    {(limitar20 ? "LIMIT 20" : "")};
                ";

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                dgvEstoque.DataSource = dt;

                ConfigurarColunasDataGridView();

                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;

                AtualizarTotalItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarEstoqueInicial()
        {
            CarregarEstoque(limitar20: true);
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
                    CarregarEstoqueInicial();
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
                "ID" => "ID_PRODUTO",
                "Nome" => "NOME",
                "Marca" => "MARCA",
                "Preço" => "PRECO",
                "Qtd do estoque" => "QTD_ESTOQUE",
                "Qtd de aviso" => "QTD_AVISO",
                "Observação" => "OBSERVACAO",
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
                    if (campo == "ID_PRODUTO" || campo == "PRECO" || campo == "QTD_ESTOQUE" || campo == "QTD_AVISO")
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

            CarregarEstoque(filtroSql, parametros, limitar20: false);
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                textoPesquisa = "";
                tbPesquisa.Text = "";
                // Reaplica o placeholder (se você ainda usa o placeholder artificial)
                TbPesquisa_LostFocus(tbPesquisa, EventArgs.Empty);

                // Limpa histórico de undo e seleção
                try { tbPesquisa.ClearUndo(); } catch { }
                tbPesquisa.SelectionStart = 0;
                tbPesquisa.SelectionLength = 0;

                // Remove o foco do tbPesquisa para evitar caret visível.
                this.ActiveControl = null;

                SelecionarPrimeiroItem(cbPesquisaCampo);
                SelecionarPrimeiroItem(cbCondicao);

                CarregarEstoque(limitar20: true);

                dgvEstoque.ClearSelection();
                dgvEstoque.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao limpar filtros: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos da Interface
        private void FormEstoque_Shown(object sender, EventArgs e)
        {
            // Garante que as comboboxes iniciem com o primeiro item (se existirem)
            try
            {
                if (cbPesquisaCampo != null && cbPesquisaCampo.Items != null && cbPesquisaCampo.Items.Count > 0)
                    cbPesquisaCampo.SelectedIndex = 0;
            }
            catch { /* segurança */ }

            try
            {
                if (cbCondicao != null && cbCondicao.Items != null && cbCondicao.Items.Count > 0)
                    cbCondicao.SelectedIndex = 0;
            }
            catch { /* segurança */ }

            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;
            AjustarTamanhoDataGridView();
        }

        private void AjustarTamanhoDataGridView()
        {
            if (dgvEstoque.Parent is Panel panelPai)
            {
                // AGORA COM DOCK FILL
                dgvEstoque.Dock = DockStyle.Fill;

                // Remove margens/padding se necessário
                dgvEstoque.Margin = new Padding(0);
            }
        }

        private void DgvEstoque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var linha = dgvEstoque.Rows[e.RowIndex];

            try
            {
                int id = Convert.ToInt32(linha.Cells["ID_PRODUTO"].Value);
                string nome = linha.Cells["NOME"].Value?.ToString() ?? "";
                string marca = linha.Cells["MARCA"].Value?.ToString() ?? "";
                decimal preco = Convert.ToDecimal(linha.Cells["PRECO"].Value);
                int quantidade = Convert.ToInt32(linha.Cells["QTD_ESTOQUE"].Value);
                int quantidadeAviso = Convert.ToInt32(linha.Cells["QTD_AVISO"].Value);
                string observacao = linha.Cells["OBSERVACAO"].Value?.ToString() ?? "";

                using (var formView = new FormViewProduto())
                {
                    formView.CarregarProduto(id, nome, marca, preco, quantidade, quantidadeAviso, observacao);
                    formView.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do produto: " + ex.Message,
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTotalItens()
        {
            lbTotal.Text = $"Total de produtos: {dgvEstoque.Rows.Count}";
        }
        #endregion

        #region Métodos Públicos
        public (int Id, string Nome, int Quantidade)? ObterProdutoSelecionado()
        {
            if (dgvEstoque.CurrentRow == null)
                return null;

            try
            {
                int id = Convert.ToInt32(dgvEstoque.CurrentRow.Cells["ID_PRODUTO"].Value);
                string nome = dgvEstoque.CurrentRow.Cells["NOME"].Value?.ToString() ?? "";
                int quantidade = Convert.ToInt32(dgvEstoque.CurrentRow.Cells["QTD_ESTOQUE"].Value);
                return (id, nome, quantidade);
            }
            catch
            {
                return null;
            }
        }

        public DataGridViewRow ObterLinhaSelecionada()
        {
            return dgvEstoque.CurrentRow;
        }

        public bool RemoverQuantidadeEstoque(int idProduto, int quantidadeRemover)
        {
            try
            {
                string sqlVerificar = "SELECT QTD_ESTOQUE FROM PRODUTO WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametrosVerificar = {
                    new SQLiteParameter("@id", idProduto)
                };

                object resultado = DatabaseHelper.ExecuteScalar(sqlVerificar, parametrosVerificar);

                if (resultado == null)
                {
                    MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                int estoqueAtual = Convert.ToInt32(resultado);

                if (quantidadeRemover > estoqueAtual)
                {
                    MessageBox.Show($"Quantidade insuficiente em estoque!\nEstoque atual: {estoqueAtual}\nTentativa de remover: {quantidadeRemover}",
                                  "Erro de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string sqlRemover = "UPDATE PRODUTO SET QTD_ESTOQUE = QTD_ESTOQUE - @qtd WHERE ID_PRODUTO = @id";
                SQLiteParameter[] parametrosRemover = {
                    new SQLiteParameter("@qtd", quantidadeRemover),
                    new SQLiteParameter("@id", idProduto)
                };

                int linhasAfetadas = DatabaseHelper.ExecuteNonQuery(sqlRemover, parametrosRemover);

                if (linhasAfetadas > 0)
                {
                    AtualizarTabela();
                    MessageBox.Show("Quantidade removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Erro ao remover quantidade do estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover quantidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable ObterEstoqueComoDataTable()
        {
            DataTable dtTemp = new DataTable();
            foreach (DataGridViewColumn col in dgvEstoque.Columns)
                dtTemp.Columns.Add(col.Name);

            foreach (DataGridViewRow row in dgvEstoque.Rows)
            {
                if (row.IsNewRow) continue;
                DataRow dr = dtTemp.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                    dr[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                dtTemp.Rows.Add(dr);
            }

            return dtTemp;
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
