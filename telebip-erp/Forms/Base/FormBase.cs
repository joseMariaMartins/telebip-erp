using System;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.Main;
using telebip_erp.Forms.Modules;
using System.Linq;
using telebip_erp.Forms.Base;
using System.Runtime.InteropServices;
using MaterialSkin;
using MaterialSkin.Controls;

namespace telebip_erp
{
    public partial class FormBase : MaterialForm
    {
        // ========== VARIÁVEIS ==========
        FormInicial? inicial = null;
        FormEstoque? estoque = null;
        FormVendas? vendas = null;
        FormRelatorios? relatorios = null;
        FormFuncionarios? funcionarios = null;
        FormConfiguracoes? configuracoes = null;
        bool menuExpandVendas = false;
        bool menuExpandEstoque = false;
        bool sidebarExpand = false;

        // ========== ARRASTAR JANELA ==========
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // ========== CONSTRUTOR ==========
        public FormBase()
        {
            InitializeComponent();
            mdiProp();
            pnlVendas.Height = 50;
            pnlEstoque.Height = 50;
        }

        // ========== MDI E ESTILO ==========
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        // ========== ARRASTAR JANELA ==========
        private void pnlControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // ========== EVENTOS DA SIDEBAR ==========
        private void menuTransitionVendas_Tick(object sender, EventArgs e)
        {
            if (menuExpandVendas == false)
            {
                pnlVendas.Height += 10;
                if (pnlVendas.Height >= 150)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = true;
                }
            }
            else
            {
                pnlVendas.Height -= 10;
                if (pnlVendas.Height <= 50)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = false;
                }
            }
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            // Só expande o dropdown se a sidebar estiver expandida
            if (sidebarExpand)
            {
                menuTransitionVendas.Start();
            }

            // Sempre abre o formulário, independente do estado da sidebar
            if (vendas == null)
            {
                vendas = new FormVendas();
                vendas.FormClosed += Vendas_FormClosed;
                vendas.MdiParent = this;
                vendas.Dock = DockStyle.Fill;
                vendas.Show();
            }
            else
            {
                vendas.Activate();
            }
        }

        private void Vendas_FormClosed(object? sender, FormClosedEventArgs e)
        {
            vendas = null;
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnlSidebar.Width -= 10;
                if (pnlSidebar.Width <= 46)
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
            // Se a sidebar está expandida, fecha os dropdowns antes de recolher
            if (sidebarExpand)
            {
                if (menuExpandVendas) menuTransitionVendas.Start();
                if (menuExpandEstoque) MenuTransitionEstoque.Start();
            }

            // Recolhe/expande a sidebar normalmente
            sidebarTransition.Start();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            // Só expande o dropdown se a sidebar estiver expandida
            if (sidebarExpand)
            {
                MenuTransitionEstoque.Start();
            }

            if (estoque == null)
            {
                estoque = new FormEstoque();
                estoque.FormClosed += Estoque_FormClosed;
                estoque.MdiParent = this;
                estoque.Dock = DockStyle.Fill;
                estoque.Show();
            }
            else
            {
                estoque.Activate();
            }
        }

        private void MenuTransitionEstoque_Tick(object sender, EventArgs e)
        {
            if (menuExpandEstoque == false)
            {
                pnlEstoque.Height += 10;
                if (pnlEstoque.Height >= 150)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = true;
                }
            }
            else
            {
                pnlEstoque.Height -= 10;
                if (pnlEstoque.Height <= 50)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = false;
                }
            }
        }

        // ========== NAVEGAÇÃO ==========
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (inicial == null)
            {
                inicial = new FormInicial();
                inicial.FormClosed += Inicial_FormClosed;
                inicial.MdiParent = this;
                inicial.WindowState = FormWindowState.Maximized;
                inicial.Dock = DockStyle.Fill;
                inicial.Show();
            }
            else
            {
                inicial.Activate();
            }
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            if (relatorios == null)
            {
                relatorios = new FormRelatorios();
                relatorios.FormClosed += Relatorios_FormClosed;
                relatorios.MdiParent = this;
                relatorios.Dock = DockStyle.Fill;
                relatorios.Show();
            }
            else
            {
                relatorios.Activate();
            }
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            if (funcionarios == null)
            {
                funcionarios = new FormFuncionarios();
                funcionarios.FormClosed += Funcionarios_FormClosed;
                funcionarios.MdiParent = this;
                funcionarios.Dock = DockStyle.Fill;
                funcionarios.Show();
            }
            else
            {
                funcionarios.Activate();
            }
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            if (configuracoes == null)
            {
                configuracoes = new FormConfiguracoes();
                configuracoes.FormClosed += Configuracoes_FormClosed;
                configuracoes.MdiParent = this;
                configuracoes.Dock = DockStyle.Fill;
                configuracoes.Show();
            }
            else
            {
                configuracoes.Activate();
            }
        }

        // ========== EVENTOS FORM CLOSED ==========
        private void Inicial_FormClosed(object? sender, FormClosedEventArgs e)
        {
            inicial = null;
        }

        private void Estoque_FormClosed(object? sender, FormClosedEventArgs e)
        {
            estoque = null;
        }

        private void Relatorios_FormClosed(object? sender, FormClosedEventArgs e)
        {
            relatorios = null;
        }

        private void Funcionarios_FormClosed(object? sender, FormClosedEventArgs e)
        {
            funcionarios = null;
        }

        private void Configuracoes_FormClosed(object? sender, FormClosedEventArgs e)
        {
            configuracoes = null;
        }

        private void btnRelatorios_Click_1(object sender, EventArgs e)
        {
            if (relatorios == null)
            {
                relatorios = new FormRelatorios();
                relatorios.FormClosed += Relatorios_FormClosed;
                relatorios.MdiParent = this;
                relatorios.Dock = DockStyle.Fill;
                relatorios.Show();
            }
            else
            {
                relatorios.Activate();
            }
        }

        private void btnConfiguracoes_Click_1(object sender, EventArgs e)
        {
            if (configuracoes == null)
            {
                configuracoes = new FormConfiguracoes();
                configuracoes.FormClosed += Configuracoes_FormClosed;
                configuracoes.MdiParent = this;
                configuracoes.Dock = DockStyle.Fill;
                configuracoes.Show();
            }
            else
            {
                configuracoes.Activate();
            }
        }

        private void btnFuncionarios_Click_1(object sender, EventArgs e)
        {
            if (funcionarios == null)
            {
                funcionarios = new FormFuncionarios();
                funcionarios.FormClosed += Funcionarios_FormClosed;
                funcionarios.MdiParent = this;
                funcionarios.Dock = DockStyle.Fill;
                funcionarios.Show();
            }
            else
            {
                funcionarios.Activate();
            }

        }
    }
}