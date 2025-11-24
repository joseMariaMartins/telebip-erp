using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using telebip_erp.Forms.SubForms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormFuncionarios : Form
    {
        private string connectionString = "Data Source=database.db;Version=3;";

        public FormFuncionarios()
        {
            InitializeComponent();
            CarregarFuncionarios();
        }

        private void CarregarFuncionarios()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT ID_USUARIO, LOGIN, SENHA FROM USUARIO", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvFuncionarios.DataSource = dt;

                    // Ajustes visuais
                    dgvFuncionarios.Columns["ID_USUARIO"].HeaderText = "ID";
                    dgvFuncionarios.Columns["LOGIN"].HeaderText = "Login";
                    dgvFuncionarios.Columns["SENHA"].HeaderText = "Senha";

                    dgvFuncionarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvFuncionarios.MultiSelect = false;
                    dgvFuncionarios.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (FormAddFuncionario formAdd = new FormAddFuncionario())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    CarregarFuncionarios();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um funcionário para excluir.");
                return;
            }

            int id = Convert.ToInt32(dgvFuncionarios.SelectedRows[0].Cells["ID_USUARIO"].Value);

            DialogResult result = MessageBox.Show("Deseja realmente excluir este funcionário?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand("DELETE FROM USUARIO WHERE ID_USUARIO=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Funcionário excluído com sucesso.");
                CarregarFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir funcionário: " + ex.Message);
            }
        }
    }
}
