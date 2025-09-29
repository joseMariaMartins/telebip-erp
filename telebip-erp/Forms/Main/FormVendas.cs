using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using MaterialSkin.Controls;

namespace telebip_erp.Forms.Modules
{
    public partial class FormVendas : Form
    {
        public FormVendas()
        {
            InitializeComponent();
            ConfigurarComboboxes();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            // Evento do botão pesquisar
            btnPesquisar.Click += BtnPesquisar_Click;
        }

        // Configura as ComboBoxes
        private void ConfigurarComboboxes()
        {
            cbPesquisaCampo.SelectedIndex = 0;
            cbCondicao.SelectedIndex = 0;
        }

        // Carrega os dados no DataGridView usando filtro opcional
        private void CarregarFuncionarios(string filtroSql = "", SQLiteParameter[]? parametros = null)
        {
            try
            {
                if (string.IsNullOrEmpty(filtroSql))
                {
                    dgvVendas.DataSource = null;
                    return;
                }

                string sql = "SELECT * FROM VENDA WHERE " + filtroSql;

                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parametros);

                dgvVendas.DataSource = dt;
                dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar vendas: " + ex.Message);
            }
        }

        // Evento do botão pesquisar
        private void BtnPesquisar_Click(object? sender, EventArgs e)
        {
            string campo = cbPesquisaCampo.SelectedItem.ToString();
            string condicao = cbCondicao.SelectedItem.ToString();
            string valor = tbPesquisa.Text.ToUpper();

            string filtroSql = "";
            SQLiteParameter[] parametros;

            switch (condicao)
            {
                case "Inicia com":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@valor", valor + "%")
                    };
                    break;

                case "Contendo":
                    filtroSql = $"UPPER({campo}) LIKE @valor";
                    parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@valor", "%" + valor + "%")
                    };
                    break;

                case "Diferente de":
                    filtroSql = $"UPPER({campo}) <> @valor";
                    parametros = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@valor", valor)
                    };
                    break;

                default:
                    MessageBox.Show("Condição de pesquisa inválida.");
                    return;
            }

            CarregarFuncionarios(filtroSql, parametros);
        }
    }
}
