using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp
{
    public partial class FormBase : Form
    {
        // Variáveis de controle da animação
        bool menuExpandVendas = false;
        bool menuExpandEstoque = false;
        bool sidebarExpand = true;

        public FormBase()
        {
            InitializeComponent();

            // Inicializar os containers com altura mínima
            vendasContainer.Height = 50;
            estoqueContainer.Height = 50;
        }

        // Estilo da sidebar
        protected void HerdarEstilo()
        {
            panel1.BackColor = Color.White;

            pnlSidebar.BackColor = Color.FromArgb(23, 24, 29);

            vendasContainer.BackColor = Color.FromArgb(23, 24, 29);
            estoqueContainer.BackColor = Color.FromArgb(23, 24, 29);
            relatoriosContainer.BackColor = Color.FromArgb(23, 24, 29);
            containerFuncionarios.BackColor = Color.FromArgb(23, 24, 29);
            configuracoesContainer.BackColor = Color.FromArgb(23, 24, 29);
        }

        // -------------------- EVENTOS --------------------

        private void menuTransitionVendas_Tick(object sender, EventArgs e)
        {
            if (menuExpandVendas == false)
            {
                vendasContainer.Height += 10;
                if (vendasContainer.Height >= 150)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = true;
                }
            }
            else
            {
                vendasContainer.Height -= 10;
                if (vendasContainer.Height <= 50)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = false;
                }
            }
        }


        private void btnVendas_Click(object sender, EventArgs e)
        {
            menuTransitionVendas.Start();
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnlSidebar.Width -= 10;
                if (pnlSidebar.Width <= 44)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                pnlSidebar.Width += 10;
                if (pnlSidebar.Width >= 260)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            MenuTransitionEstoque.Start();
        }

        private void MenuTransitionEstoque_Tick(object sender, EventArgs e)
        {
            if (menuExpandEstoque == false)
            {
                estoqueContainer.Height += 10;
                if (estoqueContainer.Height >= 150)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = true;
                }
            }
            else
            {
                estoqueContainer.Height -= 10;
                if (estoqueContainer.Height <= 50)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = false;
                }
            }

        }
    }
}
