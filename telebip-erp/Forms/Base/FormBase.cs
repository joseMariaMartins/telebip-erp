using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
            // Inicializar os containers com altura mínima
            vendasContainer.Height = 58;
            estoqueContainer.Height = 58;
        }

        bool menuExpand = false;
        bool estoqueExpand = false;
        bool sidebarExpand = true;

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                vendasContainer.Height += 10;
                if (vendasContainer.Height >= 153)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                vendasContainer.Height -= 10;
                if (vendasContainer.Height <= 58)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void menuTransitionEstoque_Tick(object sender, EventArgs e)
        {
            if (estoqueExpand == false)
            {
                estoqueContainer.Height += 10;
                if (estoqueContainer.Height >= 153)
                {
                    menuTransitionEstoque.Stop();
                    estoqueExpand = true;
                }
            }
            else
            {
                estoqueContainer.Height -= 10;
                if (estoqueContainer.Height <= 58)
                {
                    menuTransitionEstoque.Stop();
                    estoqueExpand = false;
                }
            }
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnlSidebar.Width -= 10;
                if (pnlSidebar.Width <= 57)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop(); // CORREÇÃO AQUI: era menuTransition.Stop()
                }
            }
            else
            {
                pnlSidebar.Width += 10;
                if (pnlSidebar.Width >= 265)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop(); // CORREÇÃO AQUI: era menuTransition.Stop()
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            menuTransitionEstoque.Start();
        }
    }
}