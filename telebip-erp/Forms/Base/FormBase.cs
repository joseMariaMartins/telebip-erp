using System;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.Main;
using telebip_erp.Forms.Modules;
using System.Linq;
using telebip_erp.Forms.Base;
using System.Runtime.InteropServices;

namespace telebip_erp
{
    public partial class FormBase : Form
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

            // Conectar evento de arrasto
            pnlControlBox.MouseDown += pnlControlBox_MouseDown;
        }

        // ========== MDI E ESTILO ==========
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        protected void HerdarEstilo()
        {
            pnlControlBox.BackColor = Color.White;
            pnlSidebar.BackColor = Color.FromArgb(23, 24, 29);
            pnlVendas.BackColor = Color.FromArgb(23, 24, 29);
            pnlEstoque.BackColor = Color.FromArgb(23, 24, 29);
            pnlRelatorios.BackColor = Color.FromArgb(23, 24, 29);
            pnlFuncionarios.BackColor = Color.FromArgb(23, 24, 29);
            pnlConfiguracoes.BackColor = Color.FromArgb(23, 24, 29);
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
            menuTransitionVendas.Start();
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

        private void Inicial_FormClosed(object? sender, FormClosedEventArgs e)
        {
            inicial = null;
        }
    }
}