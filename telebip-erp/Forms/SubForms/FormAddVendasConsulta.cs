using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin;
using MaterialSkin.Controls;
using telebip_erp.Forms.SubSubForms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddVendasConsulta : MaterialForm
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
        }

        #region Inicialização

        private void InicializarComponentes()
        {
            ConfigurarMonetarios();
            CriarTabelaTemporaria();

        }

        private void FormAddVendas_Load_1(object sender, EventArgs e)
        {
            lbidVendaSelecionada.Text = $"ID {VendaID}";
            tbFuncionario.Text = NomeFuncionario;
            tbDesconto.Text = Desconto.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            lbValorSuper.Text = ValorTotal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            mkDataHora.Text = DataHora;

            PreencherPagamento(); // chama método para pegar estado e forma
            PreencherProdutosVenda();
            AtualizarGridProdutos();
        }

        private void PreencherPagamento()
        {
            try
            {
                string sql = "SELECT ESTADO, FORMA FROM PAGAMENTO WHERE ID_VENDA = @idVenda LIMIT 1";
                var parametros = new SQLiteParameter[]
                {
            new SQLiteParameter("@idVenda", VendaID)
                };

                var dt = DatabaseHelper.ExecuteQuery(sql, parametros);
                if (dt.Rows.Count > 0)
                {
                    tbEstado.Text = dt.Rows[0]["ESTADO"].ToString();
                    tbForma.Text = dt.Rows[0]["FORMA"].ToString();
                }
                else
                {
                    tbEstado.Text = "";
                    tbForma.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar pagamento: " + ex.Message);
            }
        }


        #endregion

        #region Monetários

        private void ConfigurarMonetarios()
        {
            ConfigurarTextBoxMonetario(tbDesconto, TbDesconto_TextChanged);
        }

        private void ConfigurarTextBoxMonetario(Guna.UI2.WinForms.Guna2TextBox tb, EventHandler textChanged)
        {
            tb.TextChanged -= textChanged;
            tb.TextChanged += textChanged;
        }


        private void TbDesconto_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarEventoDesconto) return;

            _ignorarEventoDesconto = true;
            FormatarMonetario(tbDesconto);
            AtualizarLbValorSuper();
            _ignorarEventoDesconto = false;
        }

        private void FormatarMonetario(Guna.UI2.WinForms.Guna2TextBox tb)
        {
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

                // Configura visibilidade e títulos
                dgvProdutoTemporarios.Columns["ID_TEMP"].Visible = false;
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].HeaderText = "ID";
                dgvProdutoTemporarios.Columns["NOME"].HeaderText = "Produto";
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].HeaderText = "Preço Unitário";
                dgvProdutoTemporarios.Columns["QUANTIDADE"].HeaderText = "Qtd";
                dgvProdutoTemporarios.Columns["SUBTOTAL"].HeaderText = "Total";

                // Configura largura fixa das colunas
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].Width = 70;
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].Width = 150;
                dgvProdutoTemporarios.Columns["QUANTIDADE"].Width = 70;
                dgvProdutoTemporarios.Columns["SUBTOTAL"].Width = 100;

                // Coluna NOME ocupa o restante do espaço
                dgvProdutoTemporarios.Columns["NOME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Alinhamento do texto
                dgvProdutoTemporarios.Columns["ID_PRODUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutoTemporarios.Columns["QUANTIDADE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProdutoTemporarios.Columns["SUBTOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvProdutoTemporarios.Columns["NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // Formato monetário para PRECO_UNITARIO e SUBTOTAL
                dgvProdutoTemporarios.Columns["PRECO_UNITARIO"].DefaultCellStyle.Format = "C2";
                dgvProdutoTemporarios.Columns["SUBTOTAL"].DefaultCellStyle.Format = "C2";

                // Seleção limpa
                dgvProdutoTemporarios.ClearSelection();
                dgvProdutoTemporarios.CurrentCell = null;
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