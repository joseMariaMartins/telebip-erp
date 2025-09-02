using System;
using System.Drawing;
using System.Windows.Forms;

namespace telebip_erp
{
    public partial class FormBase : Form
    {
        // Todas as configurações de estilo estão aqui
        protected Color CorFundoCabecalho = Color.FromArgb(30, 30, 30);
        protected Color CorFundoMenu = Color.FromArgb(30, 30, 30);
        protected Color CorFundoConteudo = Color.FromArgb(30, 30, 30);
        protected Color CorTexto = Color.White;
        protected Font FontePadrao = new Font("Segoe UI", 10);

        public FormBase()
        {
            InitializeComponent();
            ConfigurarEstiloBase();
        }

        // ?? MÉTODO QUE CONFIGURA O ESTILO PARA TODAS AS TELAS
        protected virtual void ConfigurarEstiloBase()
        {
            // Configurações básicas do formulário
            this.BackColor = CorFundoConteudo;
            this.ForeColor = CorTexto;
            this.Font = FontePadrao;

            // Configura o estilo dos controles herdados
            ConfigurarEstiloMenu();
            ConfigurarEstiloConteudo();

            // Hook para ações adicionais nas telas filhas
            OnEstiloAplicado();
        }

        // ?? CONFIGURA ESTILO DO MENU
        private void ConfigurarEstiloMenu()
        {
            if (pnlMenu != null)
            {
                pnlMenu.BackColor = CorFundoMenu;
                pnlMenu.ForeColor = CorTexto;
            }

            // Configura botões do menu
            ConfigurarEstiloBotao(btnVendas);
            ConfigurarEstiloBotao(btnEstoque);
            ConfigurarEstiloBotao(btnRelatorios);
            ConfigurarEstiloBotao(btnFuncionarios);
            ConfigurarEstiloBotao(btnConfiguracoes);
            ConfigurarEstiloBotao(btnLogout);
        }

        // ?? CONFIGURA ESTILO DA ÁREA DE CONTEÚDO
        private void ConfigurarEstiloConteudo()
        {
            if (pnlContent != null)
            {
                pnlContent.BackColor = CorFundoConteudo;
                pnlContent.ForeColor = CorTexto;
            }
            ConfigurarEstiloLabel(lblNome);
            ConfigurarEstiloLabel(lblVersao);
            ConfigurarEstiloLabel(lblTelebip);
            ConfigurarEstiloLabel(label4);
        }

        // ?? MÉTODOS AUXILIARES PARA CONFIGURAR ESTILOS
        private void ConfigurarEstiloBotao(Button btn)
        {
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(20, 20, 20);
                btn.ForeColor = CorTexto;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(20, 20, 20);
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
            }
        }

        private void ConfigurarEstiloLabel(Label lbl)
        {
            if (lbl != null)
            {
                lbl.ForeColor = CorTexto;
                lbl.BackColor = Color.Transparent;
            }
        }

        // ?? MÉTODO QUE PODE SER SOBRESCRITO PELAS TELAS FILHAS
        protected virtual void OnEstiloAplicado()
        {
            // Método vazio - pode ser sobrescrito pelas telas filhas
            // para adicionar configurações específicas
        }
    }
}
