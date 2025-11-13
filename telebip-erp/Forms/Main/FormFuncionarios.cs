// FormFuncionarios.cs (minimal)
using System;
using System.Windows.Forms;

namespace telebip_erp.Forms.Modules
{
    public partial class FormFuncionarios : Form
    {
        public FormFuncionarios()
        {
            InitializeComponent();

            // textos iniciais
            lblNome.Text = "Nome: Não Registrado";
            lblCargo.Text = "Cargo: Não Registrado";
            lblEmail.Text = "E-mail: exemplo@etc";
            lblTelefone.Text = "Telefone: Não Registrado";
        }
    }
}
