using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Helpers
{
    public static class TemaTabelas
    {
        // Cores do tema escuro minimalista
        public static Color CorFundo = Color.FromArgb(15, 15, 20);
        public static Color CorFundoEscuro = Color.FromArgb(20, 20, 25);
        public static Color CorFundoClaro = Color.FromArgb(25, 25, 30);
        public static Color CorTexto = Color.White;
        public static Color CorBorda = Color.FromArgb(40, 42, 54);
        public static Color CorSelecao = Color.FromArgb(60, 62, 80);
        public static Color CorCabecalho = Color.FromArgb(20, 20, 25);

        // Configurações de fonte
        public static Font FonteNormal = new Font("Segoe UI", 9F);
        public static Font FonteCabecalho = new Font("Segoe UI", 9F, FontStyle.Bold);

        /// <summary>
        /// Aplica o tema escuro minimalista a um DataGridView
        /// </summary>
        public static void AplicarTemaEscuro(DataGridView dataGridView, bool readOnly = true)
        {
            if (dataGridView == null) return;

            // Configuração básica
            dataGridView.BackgroundColor = CorFundo;
            dataGridView.GridColor = CorBorda;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Cabeçalhos
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = CorCabecalho;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = CorTexto;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = FonteCabecalho;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersHeight = 40;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.EnableHeadersVisualStyles = false;

            // Linhas normais
            dataGridView.DefaultCellStyle.BackColor = CorFundoClaro;
            dataGridView.DefaultCellStyle.ForeColor = CorTexto;
            dataGridView.DefaultCellStyle.Font = FonteNormal;
            dataGridView.DefaultCellStyle.SelectionBackColor = CorSelecao;
            dataGridView.DefaultCellStyle.SelectionForeColor = CorTexto;
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Linhas alternadas
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = CorFundoEscuro;
            dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = CorTexto;
            dataGridView.AlternatingRowsDefaultCellStyle.SelectionBackColor = CorSelecao;
            dataGridView.AlternatingRowsDefaultCellStyle.SelectionForeColor = CorTexto;

            // Configuração de linhas
            dataGridView.RowTemplate.Height = 35;
            dataGridView.RowTemplate.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            // Configuração geral
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = readOnly;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ScrollBars = ScrollBars.Both;
        }

        /// <summary>
        /// Aplica tema escuro para tabelas editáveis
        /// </summary>
        public static void AplicarTemaEscuroEditavel(DataGridView dataGridView)
        {
            AplicarTemaEscuro(dataGridView, false);
            
            // Configurações específicas para tabelas editáveis
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 35);
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(25, 25, 30);
        }

        /// <summary>
        /// Aplica tema escuro para tabelas compactas (menos padding)
        /// </summary>
        public static void AplicarTemaEscuroCompacto(DataGridView dataGridView, bool readOnly = true)
        {
            AplicarTemaEscuro(dataGridView, readOnly);
            
            dataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(3);
            dataGridView.RowTemplate.Height = 30;
            dataGridView.RowTemplate.DefaultCellStyle.Padding = new Padding(3, 0, 3, 0);
        }

        /// <summary>
        /// Atualiza as cores do tema (útil para mudança de tema em runtime)
        /// </summary>
        public static void AtualizarCoresTema(Color fundo, Color fundoEscuro, Color fundoClaro, Color texto, Color borda, Color selecao, Color cabecalho)
        {
            CorFundo = fundo;
            CorFundoEscuro = fundoEscuro;
            CorFundoClaro = fundoClaro;
            CorTexto = texto;
            CorBorda = borda;
            CorSelecao = selecao;
            CorCabecalho = cabecalho;
        }

        /// <summary>
        /// Configura colunas específicas com alinhamento diferente
        /// </summary>
        public static void ConfigurarColuna(DataGridViewColumn coluna, DataGridViewContentAlignment alinhamento = DataGridViewContentAlignment.MiddleLeft, int largura = -1)
        {
            coluna.DefaultCellStyle.Alignment = alinhamento;
            
            if (largura > 0)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                coluna.Width = largura;
            }
        }

        /// <summary>
        /// Configura coluna numérica (alinhamento à direita)
        /// </summary>
        public static void ConfigurarColunaNumerica(DataGridViewColumn coluna, string formato = "N2", int largura = 100)
        {
            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            coluna.DefaultCellStyle.Format = formato;
            
            if (largura > 0)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                coluna.Width = largura;
            }
        }

        /// <summary>
        /// Configura coluna de data
        /// </summary>
        public static void ConfigurarColunaData(DataGridViewColumn coluna, string formato = "dd/MM/yyyy", int largura = 120)
        {
            coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            coluna.DefaultCellStyle.Format = formato;
            
            if (largura > 0)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                coluna.Width = largura;
            }
        }
    }
}