using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace telebip_erp.Forms.SubForms
{
    public partial class FormAddFuncionario : Form
    {
        private string connectionString = "Data Source=database.db;Version=3;";

        public FormAddFuncionario()
        {
            InitializeComponent();
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MessageBox.Show("Preencha o nome e cargo.");
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand("INSERT INTO USUARIO (LOGIN, SENHA) VALUES (@login, @senha)", conn);

                    // Para simplificação, usar LOGIN = nome, SENHA = data de nascimento ou algo genérico
                    cmd.Parameters.AddWithValue("@login", txtNome.Text.Substring(0, Math.Min(6, txtNome.Text.Length)));
                    cmd.Parameters.AddWithValue("@senha", mtxtDataNasc.Text.Replace("-", ""));

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Funcionário adicionado com sucesso.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar funcionário: " + ex.Message);
            }
        }
    }
}
