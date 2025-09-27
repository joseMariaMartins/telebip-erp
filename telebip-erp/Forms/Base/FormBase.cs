using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using telebip_erp.Forms.Main;
using telebip_erp.Forms.Modules;

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

        // ========== CONSTRUTOR ==========
        public FormBase()
        {
            InitializeComponent();

            ThemeManager.ApplyDarkTheme();

            pnlSidebar.Width = 47;
            pnlVendas.Height = 50;
            pnlEstoque.Height = 50;
        }

        // ========== ESTILO ==========


        // ========== MÉTODO BASE PARA ABRIR FORMULÁRIOS ==========
        private void AbrirFormNoPanel(Form form)
        {
            // Limpa o panel antes de adicionar novo form
            pnlContainer.Controls.Clear();

            // Configura o form para abrir dentro do panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Adiciona o form ao panel e mostra
            pnlContainer.Controls.Add(form);
            form.Show();
        }

        // ========== EVENTOS DE TRANSIÇÃO ==========
        private void menuTransitionVendas_Tick(object sender, EventArgs e)
        {
            if (!menuExpandVendas)
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

        private void MenuTransitionEstoque_Tick(object sender, EventArgs e)
        {
            if (!menuExpandEstoque)
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

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnlSidebar.Width -= 15;
                if (pnlSidebar.Width <= 47)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                pnlSidebar.Width += 15;
                if (pnlSidebar.Width >= 260)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        // ========== EVENTOS DOS BOTÕES - INDIVIDUAL PARA CADA UM ==========
        private void btnHam_Click(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                if (menuExpandVendas) menuTransitionVendas.Start();
                if (menuExpandEstoque) MenuTransitionEstoque.Start();
            }
            sidebarTransition.Start();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            // Expande menu se sidebar estiver expandida
            if (sidebarExpand)
                menuTransitionVendas.Start();

            // Lógica individual para Vendas
            if (vendas == null || vendas.IsDisposed)
            {
                vendas = new FormVendas();
                vendas.FormClosed += (s, e) => { vendas = null; };
                AbrirFormNoPanel(vendas);
            }
            else
            {
                // Se o form já existe, traz para frente
                if (!pnlContainer.Controls.Contains(vendas))
                {
                    AbrirFormNoPanel(vendas);
                }
                else
                {
                    vendas.BringToFront();
                }
            }
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            // Expande menu se sidebar estiver expandida
            if (sidebarExpand)
                MenuTransitionEstoque.Start();

            // Lógica individual para Estoque
            if (estoque == null || estoque.IsDisposed)
            {
                estoque = new FormEstoque();
                estoque.FormClosed += (s, e) => { estoque = null; };
                AbrirFormNoPanel(estoque);
            }
            else
            {
                if (!pnlContainer.Controls.Contains(estoque))
                {
                    AbrirFormNoPanel(estoque);
                }
                else
                {
                    estoque.BringToFront();
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Lógica individual para Home
            if (inicial == null || inicial.IsDisposed)
            {
                inicial = new FormInicial();
                inicial.FormClosed += (s, e) => { inicial = null; };
                AbrirFormNoPanel(inicial);
            }
            else
            {
                if (!pnlContainer.Controls.Contains(inicial))
                {
                    AbrirFormNoPanel(inicial);
                }
                else
                {
                    inicial.BringToFront();
                }
            }
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            // Lógica individual para Relatórios
            if (relatorios == null || relatorios.IsDisposed)
            {
                relatorios = new FormRelatorios();
                relatorios.FormClosed += (s, e) => { relatorios = null; };
                AbrirFormNoPanel(relatorios);
            }
            else
            {
                if (!pnlContainer.Controls.Contains(relatorios))
                {
                    AbrirFormNoPanel(relatorios);
                }
                else
                {
                    relatorios.BringToFront();
                }
            }
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            // Lógica individual para Funcionários
            if (funcionarios == null || funcionarios.IsDisposed)
            {
                funcionarios = new FormFuncionarios();
                funcionarios.FormClosed += (s, e) => { funcionarios = null; };
                AbrirFormNoPanel(funcionarios);
            }
            else
            {
                if (!pnlContainer.Controls.Contains(funcionarios))
                {
                    AbrirFormNoPanel(funcionarios);
                }
                else
                {
                    funcionarios.BringToFront();
                }
            }
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            // Lógica individual para Configurações
            if (configuracoes == null || configuracoes.IsDisposed)
            {
                configuracoes = new FormConfiguracoes();
                configuracoes.FormClosed += (s, e) => { configuracoes = null; };
                AbrirFormNoPanel(configuracoes);
            }
            else
            {
                if (!pnlContainer.Controls.Contains(configuracoes))
                {
                    AbrirFormNoPanel(configuracoes);
                }
                else
                {
                    configuracoes.BringToFront();
                }
            }
        }

        // ========== MÉTODOS PARA BOTÕES DUPLICADOS ==========
        private void btnRelatorios_Click_1(object sender, EventArgs e)
        {
            btnRelatorios_Click(sender, e);
        }

        private void btnFuncionarios_Click_1(object sender, EventArgs e)
        {
            btnFuncionarios_Click(sender, e);
        }

        private void btnConfiguracoes_Click_1(object sender, EventArgs e)
        {
            btnConfiguracoes_Click(sender, e);
        }

        // ========== EVENTOS FORM CLOSED ==========
        private void Vendas_FormClosed(object? sender, FormClosedEventArgs e)
        {
            vendas = null;
        }

        private void Estoque_FormClosed(object? sender, FormClosedEventArgs e)
        {
            estoque = null;
        }

        private void Inicial_FormClosed(object? sender, FormClosedEventArgs e)
        {
            inicial = null;
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
    }
}