using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormFuncionarios : Form
    {
        public FormFuncionarios()
        {
            InitializeComponent();
            CarregarFuncionarios();
        }

        private void CarregarFuncionarios()
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
                    ORDER BY NOME";

                var dt = DatabaseHelper.ExecuteQuery(sql);
                dgvFuncionarios.DataSource = dt;

                // Configurar a DataGridView
                ConfigurarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            try
            {
                // Configurações básicas
                dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFuncionarios.MultiSelect = false;
                dgvFuncionarios.ReadOnly = true;
                dgvFuncionarios.AllowUserToAddRows = false;
                dgvFuncionarios.RowHeadersVisible = false;
                dgvFuncionarios.AllowUserToResizeRows = false;

                // Aplicar tema escuro
                AplicarTemaEscuro();

                // Configurar cabeçalhos de forma segura
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
            // Cores do tema escuro
            Color background = Color.FromArgb(32, 33, 39);
            Color backgroundAlt = Color.FromArgb(38, 39, 46);
            Color headerBack = Color.FromArgb(40, 41, 52);
            Color gridColor = Color.FromArgb(50, 52, 67);
            Color selectionBack = Color.FromArgb(50, 90, 130);
            Color fore = Color.White;

            // Aplicar cores
            dgvFuncionarios.BackgroundColor = background;
            dgvFuncionarios.GridColor = gridColor;
            dgvFuncionarios.BorderStyle = BorderStyle.None;

            // Configurar células
            dgvFuncionarios.DefaultCellStyle.BackColor = background;
            dgvFuncionarios.DefaultCellStyle.ForeColor = fore;
            dgvFuncionarios.DefaultCellStyle.SelectionBackColor = selectionBack;
            dgvFuncionarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFuncionarios.DefaultCellStyle.Font = new Font("Segoe UI", 9f);

            // Linhas alternadas
            dgvFuncionarios.AlternatingRowsDefaultCellStyle.BackColor = backgroundAlt;
            dgvFuncionarios.AlternatingRowsDefaultCellStyle.ForeColor = fore;

            // Cabeçalho
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.BackColor = headerBack;
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvFuncionarios.EnableHeadersVisualStyles = false;

            // Melhorar aparência
            dgvFuncionarios.ColumnHeadersHeight = 35;
            dgvFuncionarios.RowTemplate.Height = 30;
        }

        private void ConfigurarCabecalhos()
        {
            try
            {
                // Verificar se há colunas
                if (dgvFuncionarios.Columns.Count == 0) return;

                // Configurar textos dos cabeçalhos de forma segura
                foreach (DataGridViewColumn coluna in dgvFuncionarios.Columns)
                {
                    // Verificar se a coluna não é nula
                    if (coluna == null) continue;

                    // Configurar alinhamento
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    coluna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    // Configurar cabeçalhos baseado no nome da coluna
                    switch (coluna.Name.ToUpper())
                    {
                        case "ID":
                            coluna.HeaderText = "ID";
                            break;
                        case "NOME":
                            coluna.HeaderText = "Nome";
                            break;
                        case "CARGO":
                            coluna.HeaderText = "Cargo";
                            break;
                        case "DATA_NASCIMENTO":
                            coluna.HeaderText = "Data de Nascimento";
                            break;
                        default:
                            // Manter o nome original se não for uma coluna conhecida
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao configurar cabeçalhos: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para atualizar os dados
        public void AtualizarDados()
        {
            CarregarFuncionarios();
        }

        // Eventos do formulário
        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            // Nada necessário aqui
        }

        private void FormFuncionarios_Resize(object sender, EventArgs e)
        {
            // Redimensionamento automático pela propriedade AutoSizeColumnsMode
        }
    }
}