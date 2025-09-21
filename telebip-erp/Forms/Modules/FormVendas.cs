using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace telebip_erp.Forms.Modules
{
    public partial class FormVendas : Form
    {
        public FormVendas()
        {
            InitializeComponent();
            CarregarFuncionarios();
        }
        private void CarregarFuncionarios()
        {
            try
            {
                // SQL para selecionar todos os dados da tabela FUNCIONARIO
                string sql = "SELECT * FROM FUNCIONARIO";

                // Chama o DatabaseHelper para executar o SELECT
                DataTable dt = DatabaseHelper.ExecuteQuery(sql);

                // Passa o DataTable para o DataGridView
                dgvVendas.DataSource = dt;

                // Ajusta as colunas automaticamente
                dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

    }
}
