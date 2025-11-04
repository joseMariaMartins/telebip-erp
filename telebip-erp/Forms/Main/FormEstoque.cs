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
        }

        private void ConfigurarFormulario()
        {
            // Form
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Eventos botoes
            btnPesquisar.Click -= BtnPesquisar_Click;
            btnPesquisar.Click += BtnPesquisar_Click;

            btnLimpar.Click -= BtnLimpar_Click;
            btnLimpar.Click += BtnLimpar_Click;

            // TextBox eventos (placeholder manual + texto)
            tbPesquisa.GotFocus -= TbPesquisa_GotFocus;
            tbPesquisa.GotFocus += TbPesquisa_GotFocus;
            tbPesquisa.LostFocus -= TbPesquisa_LostFocus;
            tbPesquisa.LostFocus += TbPesquisa_LostFocus;
            tbPesquisa.KeyPress -= TbPesquisa_KeyPress;
            tbPesquisa.KeyPress += TbPesquisa_KeyPress;
            tbPesquisa.TextChanged -= TbPesquisa_TextChanged;
            tbPesquisa.TextChanged += TbPesquisa_TextChanged;

            // Owner draw combos: handlers nomeados (removíveis)
            cbPesquisaCampo.DrawItem -= Cb_DrawItem;
            cbPesquisaCampo.DrawItem += Cb_DrawItem;
            cbPesquisaCampo.FlatStyle = FlatStyle.Flat;

            cbCondicao.DrawItem -= Cb_DrawItem;
            cbCondicao.DrawItem += Cb_DrawItem;
            cbCondicao.FlatStyle = FlatStyle.Flat;

            // make the picture arrows clickable to open dropdown
            picArrowCampo.Click -= PicArrowCampo_Click;
            picArrowCampo.Click += PicArrowCampo_Click;
            picArrowCondicao.Click -= PicArrowCondicao_Click;
            picArrowCondicao.Click += PicArrowCondicao_Click;

            // put default icons if available (optional)
            try
            {
                // se você tiver recursos, descomente e ajuste
                // picArrowCampo.Image = Properties.Resources.arrow_down;
                // picArrowCondicao.Image = Properties.Resources.arrow_down;
                // picSearch.Image = Properties.Resources.icon_search;
            }
            catch { }

            // aplica estilo visual (borda arredondada simples)
            StyleComboWrapperPanel(pnlWrapperCampo, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
            StyleComboWrapperPanel(pnlWrapperCondicao, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);
            StyleTextboxWrapperPanel(pnlWrapperPesquisa, Color.FromArgb(40, 41, 52), Color.FromArgb(60, 62, 80), 8);

            // placeholder inicial
            tbPesquisa.Text = placeholder;
            tbPesquisa.ForeColor = Color.FromArgb(160, 160, 160);

            // Aplica tema no DataGridView
            AplicarTemaEscuroDataGridView();

            // APLICA OS AJUSTES DAS COMBOBOXES - CHAMADA NOVA
            AdjustComboInWrapper(pnlWrapperCampo, cbPesquisaCampo, picArrowCampo);
            AdjustComboInWrapper(pnlWrapperCondicao, cbCondicao, picArrowCondicao);

            ConfigurarComboBoxInicial();
            CarregarEstoqueInicial();

            this.Shown -= FormEstoque_Shown;
            this.Shown += FormEstoque_Shown;
        }

        // ========== Ajustes para posicionamento e desenho correto das Combos ==========
        private void AdjustComboInWrapper(Panel wrapper, ComboBox combo, PictureBox arrow, int rightExtra = 6)
        {
            // propriedades visuais
            combo.FlatStyle = FlatStyle.Flat;
            combo.BackColor = wrapper.BackColor;
            combo.ForeColor = Color.White;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.IntegralHeight = false;           // evita auto-resize do dropdown
            combo.DropDownHeight = 200;
            combo.DropDownWidth = Math.Max(200, wrapper.Width); // evita dropdown muito estreito
            combo.ItemHeight = Math.Max(26, wrapper.Height - 4);

            // remover handlers antigos para segurança
            wrapper.Resize -= (s, e) => Align();
            // adicionar handler nomeado para permitir remoção futura
            wrapper.Resize += (s, e) => Align();

            // alinhamento inicial
            Align();

            void Align()
            {
                // calcula espaços (padding já definido no wrapper)
                int left = wrapper.Padding.Left;
                int top = wrapper.Padding.Top;
                int arrowWidth = (arrow != null && arrow.Visible) ? arrow.Width + rightExtra : rightExtra;
                int innerHeight = wrapper.Height - wrapper.Padding.Top - wrapper.Padding.Bottom;
                int comboHeight = innerHeight; // altura da combobox para preencher verticalmente

                // position combo
                combo.Location = new Point(left, top);
                combo.Size = new Size(Math.Max(40, wrapper.Width - left - wrapper.Padding.Right - arrowWidth), comboHeight);

                // center arrow verticalmente e posicione à direita
                if (arrow != null)
                {
                    arrow.Width = 24;
                    arrow.Height = Math.Max(16, innerHeight - 4);
                    arrow.Visible = true;
                    arrow.Location = new Point(wrapper.Width - wrapper.Padding.Right - arrow.Width, wrapper.Padding.Top + (innerHeight - arrow.Height) / 2);
                    arrow.BringToFront();
                }

                // garante que o texto selecionado do combo fique centralizado verticalmente (quando owner-draw)
                combo.ItemHeight = Math.Max(20, innerHeight - 6);
            }
        }

        // Substitui o Cb_DrawItem para também desenhar o texto quando e.Index < 0
        private void Cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.DrawBackground();

            Color back = Color.FromArgb(40, 41, 52);
            Color fore = Color.White;
            Color selBack = Color.FromArgb(80, 88, 255);

            Rectangle bounds = e.Bounds;

            // Se um item do dropdown está sendo desenhado
            if (e.Index >= 0)
            {
                bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                using (SolidBrush b = new SolidBrush(selected ? selBack : back))
                    e.Graphics.FillRectangle(b, bounds);

                string text = cb.GetItemText(cb.Items[e.Index]);
                Rectangle textRect = new Rectangle(bounds.X + 8, bounds.Y, bounds.Width - 8, bounds.Height);
                TextRenderer.DrawText(e.Graphics, text, cb.Font, textRect, fore, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

                if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                    e.DrawFocusRectangle();
            }
            else
            {
                // Quando a combobox está fechada: desenhar o texto selecionado/atual adequadamente
                using (SolidBrush b = new SolidBrush(back))
                    e.Graphics.FillRectangle(b, bounds);

                string text = cb.Text;
                Rectangle textRect = new Rectangle(bounds.X + 8, bounds.Y, bounds.Width - 8, bounds.Height);
                TextRenderer.DrawText(e.Graphics, text, cb.Font, textRect, fore, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }

        private void FormEstoque_Shown(object sender, EventArgs e)
        {
            dgvEstoque.ClearSelection();
            dgvEstoque.CurrentCell = null;

            // CORREÇÃO DO BUG DO TAMANHO DA DATAGRIDVIEW
            // Força o redimensionamento correto após o form ser mostrado
            AjustarTamanhoDataGridView();
        }

        // NOVO MÉTODO PARA CORRIGIR O TAMANHO DA DATAGRIDVIEW
        private void AjustarTamanhoDataGridView()
        {
            if (dgvEstoque.Parent is Panel panelPai)
            {
                // Calcula o tamanho correto considerando o padding do panel
                int novaLargura = panelPai.ClientSize.Width - panelPai.Padding.Left - panelPai.Padding.Right;
                int novaAltura = panelPai.ClientSize.Height - panelPai.Padding.Top - panelPai.Padding.Bottom;

                dgvEstoque.Size = new Size(novaLargura, novaAltura);
                dgvEstoque.Location = new Point(panelPai.Padding.Left, panelPai.Padding.Top);
            }
        }

        #region UI helpers (rounded wrappers)

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
            // pintura de borda arredondada
            wrapper.BackColor = fill;
            wrapper.Paint -= Wrapper_Paint;
            wrapper.Paint += Wrapper_Paint;
            wrapper.Resize -= Wrapper_Resize;
            wrapper.Resize += Wrapper_Resize;

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

            void Wrapper_Resize(object s, EventArgs e)
            {
                wrapper.Invalidate();
            }
        }

        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            // same as combo wrapper, but keep padding for text
            wrapper.BackColor = fill;
            wrapper.Paint -= Wrapper_Paint;
            wrapper.Paint += Wrapper_Paint;
            wrapper.Resize -= Wrapper_Resize;
            wrapper.Resize += Wrapper_Resize;

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

            void Wrapper_Resize(object s, EventArgs e) => wrapper.Invalidate();
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
            // Atualiza a variável com o texto atual + nova tecla
            // Não concatena se o placeholder estiver ativo
            if (tbPesquisa.Text == placeholder)
                textoPesquisa = e.KeyChar.ToString();
            else
                textoPesquisa = tbPesquisa.Text + e.KeyChar;
        }

        private void TbPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (tbPesquisa.Text == placeholder) textoPesquisa = "";
            else textoPesquisa = tbPesquisa.Text;
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

        private void ConfigurarComboBoxInicial()
        {
            try
            {
                SelecionarPrimeiroItem(cbPesquisaCampo);
                SelecionarPrimeiroItem(cbCondicao);

                // Placeholder inicial já setado
                tbPesquisa.Text = placeholder;
                tbPesquisa.ForeColor = Color.FromArgb(160, 160, 160);
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

        private void AplicarTemaEscuroDataGridView()
        {
            // Configuração geral
            dgvEstoque.BackgroundColor = Color.FromArgb(32, 33, 39);
            dgvEstoque.BorderStyle = BorderStyle.None;
            dgvEstoque.GridColor = Color.FromArgb(50, 52, 67);

            // Remove seleção vertical - LINHAS IMPORTANTES
            dgvEstoque.RowHeadersVisible = false;
            dgvEstoque.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Estilo para linhas alternadas
            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            alternatingStyle.BackColor = Color.FromArgb(32, 33, 39);
            alternatingStyle.ForeColor = Color.White;
            alternatingStyle.SelectionBackColor = Color.FromArgb(50, 90, 130); // Azul mais suave
            alternatingStyle.SelectionForeColor = Color.White;
            dgvEstoque.AlternatingRowsDefaultCellStyle = alternatingStyle;

            // Estilo para cabeçalhos das colunas
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(40, 41, 52);
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.SelectionBackColor = Color.FromArgb(40, 41, 52);
            headerStyle.SelectionForeColor = SystemColors.HighlightText;
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvEstoque.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvEstoque.ColumnHeadersHeight = 40;
            dgvEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstoque.EnableHeadersVisualStyles = false;

            // Estilo padrão para células
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            defaultStyle.BackColor = Color.FromArgb(32, 33, 39);
            defaultStyle.Font = new Font("Segoe UI", 9F);
            defaultStyle.ForeColor = Color.White;
            defaultStyle.SelectionBackColor = Color.FromArgb(50, 90, 130); // Azul mais suave
            defaultStyle.SelectionForeColor = Color.White;
            defaultStyle.WrapMode = DataGridViewTriState.False;
            dgvEstoque.DefaultCellStyle = defaultStyle;

            // Configurações de comportamento
            dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstoque.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEstoque.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEstoque.ReadOnly = true;
            dgvEstoque.AllowUserToAddRows = false;
            dgvEstoque.AllowUserToDeleteRows = false;
            dgvEstoque.AllowUserToResizeRows = false;
            dgvEstoque.MultiSelect = false; // Apenas uma seleção por vez
            dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleção horizontal completa

            // Altura das linhas
            dgvEstoque.RowTemplate.Height = 35;
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

        private void AtualizarTotalItens()
        {
            lbTotal.Text = $"Total de produtos: {dgvEstoque.Rows.Count}";
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

                // 🔹 CONFIGURA AS COLUNAS APÓS CARREGAR OS DADOS
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

        private void ConfigurarColunasDataGridView()
        {
            // 🔹 APELIDOS PARA AS COLUNAS - Nomes mais amigáveis
            if (dgvEstoque.Columns.Contains("ID_PRODUTO"))
            {
                dgvEstoque.Columns["ID_PRODUTO"].HeaderText = "ID";
                dgvEstoque.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("NOME"))
            {
                dgvEstoque.Columns["NOME"].HeaderText = "Nome do Produto";
                dgvEstoque.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvEstoque.Columns.Contains("MARCA"))
            {
                dgvEstoque.Columns["MARCA"].HeaderText = "Marca";
                dgvEstoque.Columns["MARCA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvEstoque.Columns.Contains("PRECO"))
            {
                dgvEstoque.Columns["PRECO"].HeaderText = "Preço";
                dgvEstoque.Columns["PRECO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvEstoque.Columns["PRECO"].DefaultCellStyle.Format = "C2";
            }

            if (dgvEstoque.Columns.Contains("QTD_ESTOQUE"))
            {
                dgvEstoque.Columns["QTD_ESTOQUE"].HeaderText = "Estoque Atual";
                dgvEstoque.Columns["QTD_ESTOQUE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("QTD_AVISO"))
            {
                dgvEstoque.Columns["QTD_AVISO"].HeaderText = "Estoque Mínimo";
                dgvEstoque.Columns["QTD_AVISO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvEstoque.Columns.Contains("OBSERVACAO"))
            {
                dgvEstoque.Columns["OBSERVACAO"].HeaderText = "Observações";
                dgvEstoque.Columns["OBSERVACAO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // 🔹 PESOS DAS COLUNAS PARA PREENCHER MELHOR O ESPAÇO
            if (dgvEstoque.Columns.Contains("ID_PRODUTO"))
                dgvEstoque.Columns["ID_PRODUTO"].FillWeight = 8;
            if (dgvEstoque.Columns.Contains("NOME"))
                dgvEstoque.Columns["NOME"].FillWeight = 25;
            if (dgvEstoque.Columns.Contains("MARCA"))
                dgvEstoque.Columns["MARCA"].FillWeight = 15;
            if (dgvEstoque.Columns.Contains("PRECO"))
                dgvEstoque.Columns["PRECO"].FillWeight = 12;
            if (dgvEstoque.Columns.Contains("QTD_ESTOQUE"))
                dgvEstoque.Columns["QTD_ESTOQUE"].FillWeight = 12;
            if (dgvEstoque.Columns.Contains("QTD_AVISO"))
                dgvEstoque.Columns["QTD_AVISO"].FillWeight = 13;
            if (dgvEstoque.Columns.Contains("OBSERVACAO"))
                dgvEstoque.Columns["OBSERVACAO"].FillWeight = 15;

            // Centraliza todos os cabeçalhos
            foreach (DataGridViewColumn coluna in dgvEstoque.Columns)
                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CarregarEstoqueInicial()
        {
            CarregarEstoque(limitar20: true);
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

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string campoSelecionado = ObterValorSelecionado(cbPesquisaCampo);
            string condicao = ObterValorSelecionado(cbCondicao);
            string valor = ObterTextoPesquisa().Trim().ToUpper();

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
                tbPesquisa.Focus(); // limpa placeholder logic
                TbPesquisa_LostFocus(tbPesquisa, EventArgs.Empty);

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

        // arrow picturebox opens dropdown
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
    }
}