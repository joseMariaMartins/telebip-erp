using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using telebip_erp.Forms.Auth;
using telebip_erp.Forms.SubSubForms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddVendasConsulta : FormLoad
    {
        // Flags de controle
        private bool _ignorarEventoPrecoProduto = false;
        private bool _ignorarEventoDesconto = false;

        public int VendaID { get; set; }
        public string NomeFuncionario { get; set; }
        public double ValorTotal { get; set; }
        public double Desconto { get; set; }
        public string DataHora { get; set; }

        public FormAddVendasConsulta()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();
            InicializarComponentes();

            // Bloqueia Delete/Backspace no DataGridView
            if (dgvProdutoTemporarios != null)
            {
                dgvProdutoTemporarios.KeyDown -= DgvProdutoTemporarios_KeyDown;
                dgvProdutoTemporarios.KeyDown += DgvProdutoTemporarios_KeyDown;
            }
        }

        #region Inicialização

        private void InicializarComponentes()
        {
            ConfigurarMonetarios();
            CriarTabelaTemporaria();

            // altera apenas a cor da letra (ForeColor) para cinza — NÃO altera BackColor das TextBox
            AplicarCorCinzaAControles();

            // trava as TextBoxes/MaskedTextBoxes para impedir edição pelo usuário
            TravarTextBoxesParaConsulta();

            // aplica bordas arredondadas nos panels que contenham textboxes (usando FormViewProduto como referência)
            AplicarBordasArredondadasEmWrappers();

            // Adicionado: Chama o método para aplicar o tema zebrado no DataGridView
            AplicarTemaEscuroDataGridViewProdutos();
        }

        /// <summary>
        /// Pinta apenas a cor do texto (ForeColor) dos controles relevantes como cinza.
        /// Não altera BackColor de nada.
        /// </summary>
        private void AplicarCorCinzaAControles()
        {
            Color corCinza = Color.Gray;

            try
            {
                // Labels/controles informativos — proteções caso não existam no designer
                if (tbFuncionario != null) tbFuncionario.ForeColor = corCinza;
                if (tbDesconto != null) tbDesconto.ForeColor = corCinza;
                if (mkDataHora != null) mkDataHora.ForeColor = corCinza;
                if (tbEstado != null) tbEstado.ForeColor = corCinza;
                if (tbForma != null) tbForma.ForeColor = corCinza;
            }
            catch
            {
                // não lançar — é apenas um ajuste visual
            }
        }

        /// <summary>
        /// Percorre recursivamente os controles do formulário e trava TextBox/MaskedTextBox para leitura:
        /// - ReadOnly = true
        /// - TabStop = false
        /// - ShortcutsEnabled = false (quando disponível)
        /// - remove menu de contexto (evita colar pelo botão direito) usando ContextMenuStrip
        /// Não altera BackColor para preservar o visual.
        /// </summary>
        private void TravarTextBoxesParaConsulta()
        {
            try
            {
                void Ajustar(Control parent)
                {
                    foreach (Control c in parent.Controls)
                    {
                        if (c is TextBox tb)
                        {
                            tb.ReadOnly = true;
                            tb.TabStop = false;
                            try { tb.ShortcutsEnabled = false; } catch { } // segurança
                            try { tb.ContextMenuStrip = new ContextMenuStrip(); } catch { }
                            tb.ForeColor = Color.Gray; // garante cor do texto
                        }
                        else if (c is MaskedTextBox mtb)
                        {
                            mtb.ReadOnly = true;
                            mtb.TabStop = false;
                            try { mtb.ContextMenuStrip = new ContextMenuStrip(); } catch { }
                            mtb.ForeColor = Color.Gray;
                        }

                        // recursão para containers (Panels, GroupBoxes, etc.)
                        if (c.HasChildren) Ajustar(c);
                    }
                }

                Ajustar(this);
            }
            catch
            {
                // falhar silenciosamente — não crítico
            }
        }

        #endregion

        private void AplicarTemaEscuroDataGridViewProdutos()
        {
            if (dgvProdutoTemporarios == null) return;

            dgvProdutoTemporarios.SuspendLayout();

            // Cores
            Color background = Color.FromArgb(32, 33, 39);
            Color backgroundAlt = Color.FromArgb(38, 39, 46);
            Color headerBack = Color.FromArgb(40, 41, 52);
            Color gridColor = Color.FromArgb(50, 52, 67);
            Color selectionBack = Color.FromArgb(50, 90, 130);
            Color fore = Color.White;

            // Configurações gerais
            dgvProdutoTemporarios.BackgroundColor = background;
            dgvProdutoTemporarios.BorderStyle = BorderStyle.None;
            dgvProdutoTemporarios.GridColor = gridColor;
            dgvProdutoTemporarios.EnableHeadersVisualStyles = false;

            // Cabeçalho
            var headerStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = headerBack,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = fore,
                SelectionBackColor = headerBack,
                SelectionForeColor = fore,
                WrapMode = DataGridViewTriState.True
            };
            dgvProdutoTemporarios.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvProdutoTemporarios.ColumnHeadersHeight = 40;
            dgvProdutoTemporarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProdutoTemporarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Linhas - ZEBRADO ATIVADO
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

            dgvProdutoTemporarios.DefaultCellStyle = cellStyle;
            dgvProdutoTemporarios.RowsDefaultCellStyle = cellStyle;
            dgvProdutoTemporarios.AlternatingRowsDefaultCellStyle = altCellStyle; // LINHA QUE ATIVA O ZEBRADO
            dgvProdutoTemporarios.RowTemplate.Height = 35;

            // Alinha colunas (ID, preço e quantidade centralizados; nome à esquerda)
            foreach (DataGridViewColumn coluna in dgvProdutoTemporarios.Columns)
            {
                if (coluna.Name == "ID_PRODUTO" || coluna.Name == "PRECO_UNITARIO" || coluna.Name == "QUANTIDADE" || coluna.Name == "SUBTOTAL")
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                else
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvProdutoTemporarios.AllowUserToAddRows = false;
            dgvProdutoTemporarios.AllowUserToDeleteRows = false;
            dgvProdutoTemporarios.AllowUserToResizeRows = false;
            dgvProdutoTemporarios.MultiSelect = false;
            dgvProdutoTemporarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutoTemporarios.ReadOnly = true;
            dgvProdutoTemporarios.RowHeadersVisible = false;
            dgvProdutoTemporarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvProdutoTemporarios.ClearSelection();
            dgvProdutoTemporarios.CurrentCell = null;
            dgvProdutoTemporarios.Refresh();

            dgvProdutoTemporarios.ResumeLayout();
        }

        #region Bordas arredondadas (inspirado em FormViewProduto)

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

        private void StyleTextboxWrapperPanel(Panel wrapper, Color fill, Color border, int radius = 8)
        {
            if (wrapper == null) return;

            // mantém o BackColor do panel (não altera as TextBox)
            wrapper.BackColor = fill;
            // remove event handlers existentes para evitar múltiplos attachments
            wrapper.Paint -= Wrapper_Paint;
            wrapper.Paint += Wrapper_Paint;
            wrapper.Tag = new Tuple<Color, Color, int>(fill, border, radius);

            void Wrapper_Paint(object s, PaintEventArgs e)
            {
                try
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = new Rectangle(0, 0, wrapper.Width - 1, wrapper.Height - 1);
                    using (var path = GetRoundedRect(rect, radius))
                    using (var pen = new Pen(border, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
                catch { /* seguro */ }
            }

            // Força redraw no resize
            wrapper.Resize -= (s, e) => wrapper.Invalidate();
            wrapper.Resize += (s, e) => wrapper.Invalidate();
        }

        /// <summary>
        /// Encontra panels que contenham TextBox/MaskedTextBox e aplica o estilo
        /// (versão genérica para não depender de nomes de designer específicos).
        /// </summary>
        private void AplicarBordasArredondadasEmWrappers()
        {
            try
            {
                Color borderColor = Color.FromArgb(60, 62, 80);
                Color fillColor = Color.FromArgb(40, 41, 52);
                int radius = 8;

                void Ajustar(Control parent)
                {
                    foreach (Control c in parent.Controls)
                    {
                        if (c is Panel pnl)
                        {
                            bool contemTextBox =
                                pnl.Controls.OfType<TextBox>().Any() ||
                                pnl.Controls.OfType<MaskedTextBox>().Any();

                            if (contemTextBox)
                            {
                                StyleTextboxWrapperPanel(pnl, fillColor, borderColor, radius);
                            }
                        }

                        if (c.HasChildren) Ajustar(c);
                    }
                }

                Ajustar(this);
            }
            catch
            {
                // seguro — se algo falhar não é crítico
            }
        }

        #endregion

        private void DgvProdutoTemporarios_KeyDown(object? sender, KeyEventArgs e)
        {
            // Bloqueia Delete e Backspace no grid (evita remoção via tecla)
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void FormAddVendas_Load_1(object sender, EventArgs e)
        {
            lbidVendaSelecionada.Text = $"ID {VendaID}";
            if (tbFuncionario != null) tbFuncionario.Text = NomeFuncionario;
            // tbDesconto assumed to be a standard TextBox
            if (tbDesconto != null)
                tbDesconto.Text = Desconto.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            if (lbValorSuper != null)
                lbValorSuper.Text = ValorTotal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            if (mkDataHora != null) mkDataHora.Text = DataHora;

            PreencherPagamento(); // chama método para pegar estado e forma
            PreencherProdutosVenda();
            AtualizarGridProdutos();

            // Adicionado: Reaplica o tema zebrado após carregar os dados
            AplicarTemaEscuroDataGridViewProdutos();
        }

        private void PreencherPagamento()
        {
            try
            {
                string sql = "SELECT ESTADO, FORMA FROM PAGAMENTO WHERE ID_VENDA = @idVenda LIMIT 1";
                var parametros = new SQLiteParameter[] { new SQLiteParameter("@idVenda", VendaID) };

                var dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                if (dt.Rows.Count > 0)
                {
                    if (tbEstado != null) tbEstado.Text = dt.Rows[0]["ESTADO"].ToString();
                    if (tbForma != null) tbForma.Text = dt.Rows[0]["FORMA"].ToString();
                }
                else
                {
                    if (tbEstado != null) tbEstado.Text = "";
                    if (tbForma != null) tbForma.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar pagamento: " + ex.Message);
            }
        }

        #region Monetários

        private void ConfigurarMonetarios()
        {
            // tbDesconto deve ser System.Windows.Forms.TextBox no Designer
            try
            {
                if (tbDesconto != null)
                    ConfigurarTextBoxMonetario(tbDesconto, TbDesconto_TextChanged);
            }
            catch { }
        }

        // Atualizado para System.Windows.Forms.TextBox
        private void ConfigurarTextBoxMonetario(TextBox tb, EventHandler textChanged)
        {
            if (tb == null) return;

            tb.TextChanged -= textChanged;
            tb.TextChanged += textChanged;

            // garante que o KeyPress bloqueador de não-dígitos esteja ativo
            tb.KeyPress -= TbPreco_KeyPress;
            tb.KeyPress += TbPreco_KeyPress;
        }

        private void TbDesconto_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoDesconto) return;

            _ignorarEventoDesconto = true;
            FormatarMonetario(sender as TextBox);
            AtualizarLbValorSuper();
            _ignorarEventoDesconto = false;
        }

        // Atualizado para aceitar System.Windows.Forms.TextBox
        private void FormatarMonetario(TextBox tb)
        {
            if (tb == null) return;

            string numeros = "";
            foreach (char c in tb.Text)
                if (char.IsDigit(c)) numeros += c;

            if (numeros == "") numeros = "0";

            decimal valor = decimal.Parse(numeros) / 100m;
            if (valor > 1000000m) valor = 1000000m;

            tb.Text = "R$ " + valor.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
            tb.SelectionStart = tb.Text.Length;
        }

        private void TbPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        #endregion

        #region Grid Temporário

        private void CriarTabelaTemporaria()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string sql = @"
            CREATE TABLE IF NOT EXISTS PRODUTOS_TEMPORARIOS (
                ID_TEMP INTEGER PRIMARY KEY AUTOINCREMENT,
                ID_PRODUTO INTEGER NOT NULL,
                NOME TEXT NOT NULL CHECK(length(NOME) <= 100),
                MARCA TEXT CHECK(length(MARCA) <= 50),
                PRECO_UNITARIO REAL NOT NULL CHECK(PRECO_UNITARIO = ROUND(PRECO_UNITARIO,2) AND PRECO_UNITARIO >=0),
                QUANTIDADE INTEGER NOT NULL CHECK(QUANTIDADE>0),
                SUBTOTAL REAL GENERATED ALWAYS AS (ROUND(PRECO_UNITARIO*QUANTIDADE,2)) VIRTUAL
            );
        ";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar/limpar tabela de produtos temporários: " + ex.Message);
            }
        }

        private void AtualizarGridProdutos()
        {
            try
            {
                // Pega todos os dados da tabela temporária
                string sql = "SELECT ID_TEMP, ID_PRODUTO, NOME, PRECO_UNITARIO, QUANTIDADE, SUBTOTAL FROM PRODUTOS_TEMPORARIOS;";
                var dt = DatabaseHelper.ExecuteQuery(sql);
                dgvProdutoTemporarios.DataSource = dt;

                // Segurança: impede edição pelo usuário
                dgvProdutoTemporarios.AllowUserToAddRows = false;
                dgvProdutoTemporarios.AllowUserToDeleteRows = false;
                dgvProdutoTemporarios.AllowUserToResizeColumns = false;
                dgvProdutoTemporarios.RowHeadersVisible = false;
                dgvProdutoTemporarios.ReadOnly = true;
                dgvProdutoTemporarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProdutoTemporarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Configura visibilidade e títulos
                if (dgvProdutoTemporarios.Columns.Contains("ID_TEMP"))
                    dgvProdutoTemporarios.Columns["ID_TEMP"].Visible = false;
                if (dgvProdutoTemporarios.Columns.Contains("ID_PRODUTO"))
                    dgvProdutoTemporarios.Columns["ID_PRODUTO"].HeaderText = "ID";
                if (dgvProdutoTemporarios.Columns.Contains("NOME"))
                    dgvProdutoTemporarios.Columns["NOME"].HeaderText = "Produto";
                if (dgvProdutoTemporarios.Columns.Contains("PRECO_UNITARIO"))
                    dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].HeaderText = "Preço Unitário";
                if (dgvProdutoTemporarios.Columns.Contains("QUANTIDADE"))
                    dgvProdutoTemporarios.Columns["QUANTIDADE"].HeaderText = "Qtd";
                if (dgvProdutoTemporarios.Columns.Contains("SUBTOTAL"))
                    dgvProdutoTemporarios.Columns["SUBTOTAL"].HeaderText = "Total";

                // Configura largura fixa das colunas (só se existirem)
                if (dgvProdutoTemporarios.Columns.Contains("ID_PRODUTO")) dgvProdutoTemporarios.Columns["ID_PRODUTO"].Width = 70;
                if (dgvProdutoTemporarios.Columns.Contains("PRECO_UNITARIO")) dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].Width = 150;
                if (dgvProdutoTemporarios.Columns.Contains("QUANTIDADE")) dgvProdutoTemporarios.Columns["QUANTIDADE"].Width = 70;
                if (dgvProdutoTemporarios.Columns.Contains("SUBTOTAL")) dgvProdutoTemporarios.Columns["SUBTOTAL"].Width = 100;

                // Coluna NOME ocupa o restante do espaço
                if (dgvProdutoTemporarios.Columns.Contains("NOME"))
                    dgvProdutoTemporarios.Columns["NOME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Alinhamento do texto
                if (dgvProdutoTemporarios.Columns.Contains("ID_PRODUTO"))
                    dgvProdutoTemporarios.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgvProdutoTemporarios.Columns.Contains("PRECO_UNITARIO"))
                    dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgvProdutoTemporarios.Columns.Contains("QUANTIDADE"))
                    dgvProdutoTemporarios.Columns["QUANTIDADE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (dgvProdutoTemporarios.Columns.Contains("SUBTOTAL"))
                    dgvProdutoTemporarios.Columns["SUBTOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (dgvProdutoTemporarios.Columns.Contains("NOME"))
                    dgvProdutoTemporarios.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Formato monetário para PRECO_UNITARIO e SUBTOTAL
                if (dgvProdutoTemporarios.Columns.Contains("PRECO_UNITARIO"))
                    dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].DefaultCellStyle.Format = "C2";
                if (dgvProdutoTemporarios.Columns.Contains("SUBTOTAL"))
                    dgvProdutoTemporarios.Columns["SUBTOTAL"].DefaultCellStyle.Format = "C2";

                // Seleção limpa
                dgvProdutoTemporarios.ClearSelection();
                dgvProdutoTemporarios.CurrentCell = null;

                // Adicionado: Reaplica o tema zebrado após configurar as colunas
                AplicarTemaEscuroDataGridViewProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos temporários: " + ex.Message);
            }
        }

        private void AtualizarLbValorSuper()
        {
            decimal valorBruto = 0;
            foreach (DataGridViewRow row in dgvProdutoTemporarios.Rows)
                valorBruto += Convert.ToDecimal(row.Cells["SUBTOTAL"].Value);

            decimal desconto = 0;
            decimal.TryParse(tbDesconto.Text.Replace("R$", "").Trim(), NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out desconto);

            decimal valorFinal = Math.Max(0, valorBruto - desconto);
            if (lbValorSuper != null)
                lbValorSuper.Text = "R$ " + valorFinal.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));
        }

        #endregion

        #region Botões

        private void btnCancelarVendas_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparTabelaTemporaria(SQLiteConnection conn, SQLiteTransaction transaction)
        {
            string sqlLimpar = "DELETE FROM PRODUTOS_TEMPORARIOS;";
            using var cmdLimpar = new SQLiteCommand(sqlLimpar, conn, transaction);
            cmdLimpar.ExecuteNonQuery();
        }

        #endregion

        private void PreencherProdutosVenda()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                using var transaction = conn.BeginTransaction();

                // Limpa a tabela temporária antes de inserir
                string sqlLimpar = "DELETE FROM PRODUTOS_TEMPORARIOS;";
                using (var cmdLimpar = new SQLiteCommand(sqlLimpar, conn, transaction))
                {
                    cmdLimpar.ExecuteNonQuery();
                }

                // Seleciona os produtos da venda
                string sqlItens = @"
            SELECT i.ID_PRODUTO, p.NOME, p.MARCA, i.PRECO_UNITARIO, i.QUANTIDADE
            FROM ITEM_VENDA i
            INNER JOIN PRODUTO p ON i.ID_PRODUTO = p.ID_PRODUTO
            WHERE i.ID_VENDA = @idVenda;
        ";

                using (var cmd = new SQLiteCommand(sqlItens, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@idVenda", VendaID);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string sqlInserirTemp = @"
                    INSERT INTO PRODUTOS_TEMPORARIOS (ID_PRODUTO, NOME, MARCA, PRECO_UNITARIO, QUANTIDADE)
                    VALUES (@idProduto, @nome, @marca, @preco, @quantidade);
                ";
                        using var cmdInserir = new SQLiteCommand(sqlInserirTemp, conn, transaction);
                        cmdInserir.Parameters.AddWithValue("@idProduto", reader["ID_PRODUTO"]);
                        cmdInserir.Parameters.AddWithValue("@nome", reader["NOME"]);
                        cmdInserir.Parameters.AddWithValue("@marca", reader["MARCA"]);
                        cmdInserir.Parameters.AddWithValue("@preco", reader["PRECO_UNITARIO"]);
                        cmdInserir.Parameters.AddWithValue("@quantidade", reader["QUANTIDADE"]);
                        cmdInserir.ExecuteNonQuery();
                    }
                }

                transaction.Commit();

                // Atualiza o DataGridView
                AtualizarGridProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher produtos da venda: " + ex.Message);
            }
        }
    }
}