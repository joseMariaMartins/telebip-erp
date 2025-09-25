using System;
using System.Drawing;
using System.Windows.Forms;
<<<<<<< Updated upstream
=======
using telebip_erp.Forms.Main;
using telebip_erp.Forms.Modules;
using System.Linq;
using telebip_erp.Forms.Base;
using System.Runtime.InteropServices;
using MaterialSkin;
using MaterialSkin.Controls;
>>>>>>> Stashed changes

namespace telebip_erp
{
    public partial class FormBase : MaterialForm
    {
<<<<<<< Updated upstream
        // Vari�veis de controle da anima��o
=======
        // ========== VARIÁVEIS ==========
        FormInicial? inicial = null;
        FormEstoque? estoque = null;
        FormVendas? vendas = null;
        FormRelatorios? relatorios = null;
        FormFuncionarios? funcionarios = null;
        FormConfiguracoes? configuracoes = null;
>>>>>>> Stashed changes
        bool menuExpandVendas = false;
        bool menuExpandEstoque = false;
        bool sidebarExpand = true;

<<<<<<< Updated upstream
=======
        // ========== CONSTRUTOR ==========
>>>>>>> Stashed changes
        public FormBase()
        {
            InitializeComponent();

<<<<<<< Updated upstream
            // Inicializar os containers com altura m�nima
            vendasContainer.Height = 50;
            estoqueContainer.Height = 50;
=======
            // ✅ CONFIGURAÇÃO DO MATERIALSKIN (OPÇÃO 3)
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // 🖤🖤🖤 OPÇÃO 3 - CORES PRETAS DO MATERIALSKIN 🖤🖤🖤
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey900,    // #212121 - Quase preto (ActionBar)
                Primary.Grey800,    // #424242 - Mais escuro  
                Primary.Grey700,    // #616161 - Cinza escuro
                Accent.Blue200,     // Cor de destaque
                TextShade.WHITE     // Texto branco
            );


            mdiProp();
            pnlVendas.Height = 50;
            pnlEstoque.Height = 50;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        // -------------------- EVENTOS --------------------

=======
        // ========== EVENTOS DA SIDEBAR ==========
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            menuTransitionVendas.Start();
=======
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
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            MenuTransitionEstoque.Start();
=======
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
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes

        }

        private void btnHam_Click_1(object sender, EventArgs e)
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
    }
}
