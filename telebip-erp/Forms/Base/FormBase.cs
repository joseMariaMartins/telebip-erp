using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using telebip_erp.Forms.Auth;
using telebip_erp.Forms.Main;
using telebip_erp.Forms.Modules;
using telebip_erp.Forms.SubForms;

namespace telebip_erp
{
    public partial class FormBase : FormLoad
    {
        #region Variáveis
        private FormInicial? inicial = null;
        private FormEstoque? estoque = null;
        private FormVendas? vendas = null;
        private FormRelatorios? relatorios = null;
        private FormFuncionarios? funcionarios = null;
        private FormConfiguracoes? configuracoes = null;

        private FormAddVendas? adicionarVendaForm;
        private FormAddEstoque? adicionarEstoqueForm;

        private bool menuExpandVendas = false;
        private bool menuExpandEstoque = false;
        private bool sidebarExpand = false;

        private readonly string caminhoBanco = Path.Combine(
            Application.StartupPath, "Database", "TeleBipDB.db"
        );

        public string UltimaPastaBackup { get; set; } = ConfigHelper.GetSetting("UltimaPastaBackup") ?? "";
        #endregion

        #region Construtor e Inicialização
        public FormBase()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            // Ativar DoubleBuffered nos painéis
            SetDoubleBuffered(pnlContainer);
            SetDoubleBuffered(pnlSidebar);
            SetDoubleBuffered(pnlVendas);
            SetDoubleBuffered(pnlEstoque);

            this.Width = 1300;
            this.Height = 650;
            pnlSidebar.Width = 43;
            pnlVendas.Height = 50;
            pnlEstoque.Height = 50;

            RegistrarBotoesSelecionaveis();

            CriarOuRecuperarFormInicial();
            AbrirFormNoPanel(inicial!);
            ButtonSelectionManager.SelecionarBotao(btnHome);
        }

        private void SetDoubleBuffered(Control ctrl)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(ctrl, true, null);
        }

        private void RegistrarBotoesSelecionaveis()
        {
            ButtonSelectionManager.RegistrarBotao(btnHome);
            ButtonSelectionManager.RegistrarBotao(btnVendas);
            ButtonSelectionManager.RegistrarBotao(btnEstoque);
            ButtonSelectionManager.RegistrarBotao(btnRelatorios);
            ButtonSelectionManager.RegistrarBotao(btnFuncionarios);
            ButtonSelectionManager.RegistrarBotao(btnConfiguracoes);
        }
        #endregion

        #region Gerenciamento de Dropdowns
        private async Task FecharTodosDropdowns()
        {
            if (menuExpandVendas)
            {
                FecharDropdownVendas();
                await Task.Delay(100);
            }
            if (menuExpandEstoque)
            {
                FecharDropdownEstoque();
                await Task.Delay(100);
            }
        }

        private void AbrirDropdownVendas()
        {
            pnlVendas.Height = 150;
            menuExpandVendas = true;
        }

        private void FecharDropdownVendas()
        {
            pnlVendas.Height = 50;
            menuExpandVendas = false;
        }

        private void AbrirDropdownEstoque()
        {
            pnlEstoque.Height = 150;
            menuExpandEstoque = true;
        }

        private void FecharDropdownEstoque()
        {
            pnlEstoque.Height = 50;
            menuExpandEstoque = false;
        }
        #endregion

        #region Sistema de Forms (DENTRO DO PANEL)
        private async void AbrirFormNoPanel(Form form, bool fecharDropdowns = true)
        {
            if (fecharDropdowns)
            {
                await FecharTodosDropdowns();
            }

            pnlContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(form);
            form.Show();
        }

        private void CriarOuRecuperarFormInicial()
        {
            if (inicial == null || inicial.IsDisposed)
            {
                inicial = new FormInicial();
                inicial.FormClosed += (s, e) => { inicial = null; };
            }
        }

        private void CriarOuRecuperarFormVendas()
        {
            if (vendas == null || vendas.IsDisposed)
            {
                vendas = new FormVendas();
                vendas.FormClosed += (s, e) => { vendas = null; };
            }
        }

        private void CriarOuRecuperarFormEstoque()
        {
            if (estoque == null || estoque.IsDisposed)
            {
                estoque = new FormEstoque();
                estoque.FormClosed += (s, e) => { estoque = null; };
            }
        }

        private void CriarOuRecuperarFormRelatorios()
        {
            if (relatorios == null || relatorios.IsDisposed)
            {
                var vendasTemp = vendas ?? new FormVendas() { TopLevel = false };
                var estoqueTemp = estoque ?? new FormEstoque() { TopLevel = false };

                relatorios = new FormRelatorios(vendasTemp, estoqueTemp);
                relatorios.FormClosed += (s, e) => { relatorios = null; };
            }
        }

        private void CriarOuRecuperarFormFuncionarios()
        {
            if (funcionarios == null || funcionarios.IsDisposed)
            {
                funcionarios = new FormFuncionarios();
                funcionarios.FormClosed += (s, e) => { funcionarios = null; };
            }
        }

        private void CriarOuRecuperarFormConfiguracoes()
        {
            if (configuracoes == null || configuracoes.IsDisposed)
            {
                configuracoes = new FormConfiguracoes();
                configuracoes.FormClosed += (s, e) => { configuracoes = null; };
            }
        }
        #endregion

        #region Sidebar e Dropdowns (COMPORTAMENTOS DINÂMICOS)
        private async Task ToggleSidebarAsync()
        {
            if (sidebarExpand)
            {
                // Fecha dropdowns primeiro com coldawn
                await FecharTodosDropdowns();

                // Sidebar seca
                pnlSidebar.Width = 43;
                sidebarExpand = false;
            }
            else
            {
                // Sidebar seca
                pnlSidebar.Width = 280;
                sidebarExpand = true;

                // Pequeno delay para estabilizar
                await Task.Delay(80);
            }
        }
        #endregion

        #region Eventos da Sidebar e Botões
        private async void btnHam_Click(object sender, EventArgs e) => await ToggleSidebarAsync();
        private async void pnlHam_Click(object sender, EventArgs e) => await ToggleSidebarAsync();

        private void AbrirFormConfiguracoes()
        {
            // Fecha outras forms, mas mantém as configurações se já estiver aberta
            foreach (Form form in this.MdiChildren)
            {
                if (!(form is Forms.Modules.FormConfiguracoes))
                {
                    form.Close();
                }
            }

            // Verifica se já existe uma instância aberta
            FormConfiguracoes formConfig = null;
            foreach (Form form in this.MdiChildren)
            {
                if (form is Forms.Modules.FormConfiguracoes)
                {
                    formConfig = form as Forms.Modules.FormConfiguracoes;
                    break;
                }
            }

            // Se não existe, cria nova
            if (formConfig == null)
            {
                formConfig = new Forms.Modules.FormConfiguracoes();
                formConfig.MdiParent = this;
                formConfig.WindowState = FormWindowState.Maximized;
                formConfig.Show();
            }

            // Traz para frente e foca
            formConfig.BringToFront();
            formConfig.Focus();
        }


        private async void btnHome_Click(object sender, EventArgs e)
        {
            await FecharTodosDropdowns();
            CriarOuRecuperarFormInicial();
            AbrirFormNoPanel(inicial!, false);
            ButtonSelectionManager.SelecionarBotao(btnHome);
        }

        private async void btnVendas_Click(object sender, EventArgs e)
        {
            if (!sidebarExpand) await ToggleSidebarAsync();

            if (menuExpandEstoque)
            {
                // Fecha Estoque com coldawn e depois abre Vendas
                FecharDropdownEstoque();
                await Task.Delay(100);
                AbrirDropdownVendas();
                AbrirFormVendasSemFecharDropdown();
                ButtonSelectionManager.SelecionarBotao(btnVendas);
            }
            else if (menuExpandVendas)
            {
                // Se já está aberto, apenas fecha
                FecharDropdownVendas();
            }
            else
            {
                // Se nenhum está aberto, abre normalmente
                AbrirDropdownVendas();
                AbrirFormVendasSemFecharDropdown();
                ButtonSelectionManager.SelecionarBotao(btnVendas);
            }
        }

        private async void btnEstoque_Click(object sender, EventArgs e)
        {
            if (!sidebarExpand) await ToggleSidebarAsync();

            if (menuExpandVendas)
            {
                // Fecha Vendas com coldawn e depois abre Estoque
                FecharDropdownVendas();
                await Task.Delay(100);
                AbrirDropdownEstoque();
                AbrirFormEstoqueSemFecharDropdown();
                ButtonSelectionManager.SelecionarBotao(btnEstoque);
            }
            else if (menuExpandEstoque)
            {
                // Se já está aberto, apenas fecha
                FecharDropdownEstoque();
            }
            else
            {
                // Se nenhum está aberto, abre normalmente
                AbrirDropdownEstoque();
                AbrirFormEstoqueSemFecharDropdown();
                ButtonSelectionManager.SelecionarBotao(btnEstoque);
            }
        }

        private async void btnRelatorios_Click(object sender, EventArgs e)
        {
            await FecharTodosDropdowns();
            CriarOuRecuperarFormRelatorios();
            AbrirFormNoPanel(relatorios!, false);
            ButtonSelectionManager.SelecionarBotao(btnRelatorios);
        }

        private async void btnFuncionarios_Click(object sender, EventArgs e)
        {
            // ✅ SALVA o botão atual ANTES de qualquer verificação
            var botaoAnterior = ButtonSelectionManager.ObterBotaoSelecionadoAtual();

            if (Session.NivelAcesso == 0)
            {
                MessageBox.Show("Acesso restrito ao gerente.",
                               "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // ✅ RESTAURA o botão anterior
                ButtonSelectionManager.RestaurarSelecaoAnterior(botaoAnterior);
                return;
            }

            await FecharTodosDropdowns();
            CriarOuRecuperarFormFuncionarios();
            AbrirFormNoPanel(funcionarios!, false);
            ButtonSelectionManager.SelecionarBotao(btnFuncionarios);
        }

        private async void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            await FecharTodosDropdowns();
            CriarOuRecuperarFormConfiguracoes();
            AbrirFormNoPanel(configuracoes!, false);
            ButtonSelectionManager.SelecionarBotao(btnConfiguracoes);
        }

        private void AbrirFormVendas()
        {
            CriarOuRecuperarFormVendas();
            if (!pnlContainer.Controls.Contains(vendas!))
                AbrirFormNoPanel(vendas!, false);
            else
                vendas!.BringToFront();
        }

        private void AbrirFormVendasSemFecharDropdown()
        {
            CriarOuRecuperarFormVendas();
            if (!pnlContainer.Controls.Contains(vendas!))
                AbrirFormNoPanel(vendas!, false);
            else
                vendas!.BringToFront();
        }

        private void AbrirFormEstoque()
        {
            CriarOuRecuperarFormEstoque();
            if (!pnlContainer.Controls.Contains(estoque!))
                AbrirFormNoPanel(estoque!, false);
            else
                estoque!.BringToFront();
        }

        private void AbrirFormEstoqueSemFecharDropdown()
        {
            CriarOuRecuperarFormEstoque();
            if (!pnlContainer.Controls.Contains(estoque!))
                AbrirFormNoPanel(estoque!, false);
            else
                estoque!.BringToFront();
        }
        #endregion

        #region Botões de Ação (Modal)
        private void addVenda_Click(object sender, EventArgs e)
        {
            if (adicionarVendaForm == null || adicionarVendaForm.IsDisposed)
            {
                adicionarVendaForm = new FormAddVendas();
                adicionarVendaForm.VendaConfirmadaCallback = () => vendas?.AtualizarTabela();
                adicionarVendaForm.FormClosed += (s, args) => adicionarVendaForm = null;
                adicionarVendaForm.ShowDialog(this);
            }
            else
            {
                adicionarVendaForm.BringToFront();
            }
        }

        private void addEstoque_Click(object sender, EventArgs e) => AbrirFormAddEstoque();

        private void rmvEstoque_Click(object sender, EventArgs e)
        {
            if (estoque == null || estoque.IsDisposed)
            {
                MessageBox.Show("A tela de Estoque precisa estar aberta para remover um item.");
                return;
            }

            var produtoSelecionado = estoque.ObterProdutoSelecionado();
            if (!produtoSelecionado.HasValue)
            {
                MessageBox.Show("Selecione um produto na lista para remover.");
                return;
            }

            var (id, nome, quantidade) = produtoSelecionado.Value;
            using var formRmv = new FormRmvEstoque(id, nome, quantidade);
            formRmv.FormClosed += (s, args) => estoque?.CarregarEstoque();
            formRmv.ShowDialog(this);
        }

        private void AbrirFormAddEstoque()
        {
            if (estoque == null)
            {
                MessageBox.Show("Abra primeiro a tela de Estoque.");
                return;
            }

            if (adicionarEstoqueForm == null || adicionarEstoqueForm.IsDisposed)
            {
                adicionarEstoqueForm = new FormAddEstoque();
                adicionarEstoqueForm.FormClosed += (s, args) => adicionarEstoqueForm = null;
                adicionarEstoqueForm.AtualizarEstoqueCallback = () => estoque?.CarregarEstoque();
            }

            PreencherFormAddEstoque();
            adicionarEstoqueForm.ShowDialog(this);
        }

        private void PreencherFormAddEstoque()
        {
            adicionarEstoqueForm!.LimparCampos();
            var linhaSelecionada = estoque!.ObterLinhaSelecionada();

            if (linhaSelecionada != null)
            {
                adicionarEstoqueForm.ProdutoSelecionado = (
                    Convert.ToInt32(linhaSelecionada.Cells["ID_PRODUTO"].Value),
                    linhaSelecionada.Cells["NOME"].Value?.ToString() ?? "",
                    Convert.ToInt32(linhaSelecionada.Cells["QTD_ESTOQUE"].Value)
                );

                adicionarEstoqueForm.tbNome.Text = linhaSelecionada.Cells["NOME"].Value?.ToString() ?? "";
                adicionarEstoqueForm.tbMarca.Text = linhaSelecionada.Cells["MARCA"].Value?.ToString() ?? "";
                adicionarEstoqueForm.tbPreco.Text = "R$ " + Convert.ToDecimal(linhaSelecionada.Cells["PRECO"].Value).ToString("N2");
                adicionarEstoqueForm.tbQEstoque.Text = "";
                adicionarEstoqueForm.tbQAviso.Text = linhaSelecionada.Cells["QTD_AVISO"].Value?.ToString() ?? "";
                adicionarEstoqueForm.tbObservacao.Text = linhaSelecionada.Cells["OBSERVACAO"].Value?.ToString() ?? "";

                adicionarEstoqueForm.tbNome.ReadOnly = true;
                adicionarEstoqueForm.tbMarca.ReadOnly = true;
                adicionarEstoqueForm.tbPreco.ReadOnly = true;
                adicionarEstoqueForm.tbQAviso.ReadOnly = true;
                adicionarEstoqueForm.tbObservacao.ReadOnly = true;

                adicionarEstoqueForm.lbQuantidadeAtual.Text = $"Quantidade atual: {linhaSelecionada.Cells["QTD_ESTOQUE"].Value}";
                adicionarEstoqueForm.lbQuantidadeAtual.Visible = true;
            }
            else
            {
                adicionarEstoqueForm.ProdutoSelecionado = null;
            }
        }
        #endregion

        #region Remover Venda / Banco
        private void rmvVenda_Click(object sender, EventArgs e)
        {
            if (Session.NivelAcesso == 0)
            {
                MessageBox.Show("O usuário atual não tem permissão para essa operação.", "Acesso Negado");
                return;
            }

            if (vendas?.dgvVendas?.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma venda para remover.");
                return;
            }

            var result = MessageBox.Show("Deseja realmente remover a venda selecionada?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            ExecutarRemocaoVenda();
        }

        private void ExecutarRemocaoVenda()
        {
            int idVenda = Convert.ToInt32(vendas!.dgvVendas.CurrentRow!.Cells["ID_VENDA"].Value);

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                var itens = new List<(int idProduto, int quantidade)>();
                string sqlItens = "SELECT ID_PRODUTO, QUANTIDADE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using (var cmdItens = new SQLiteCommand(sqlItens, conn, transaction))
                {
                    cmdItens.Parameters.AddWithValue("@id", idVenda);
                    using var reader = cmdItens.ExecuteReader();
                    while (reader.Read()) itens.Add((reader.GetInt32(0), reader.GetInt32(1)));
                }

                // Deleta os itens — isso vai disparar a trigger AFTER DELETE ON ITEM_VENDA
                string sqlDelItens = "DELETE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using (var cmdDelItens = new SQLiteCommand(sqlDelItens, conn, transaction))
                {
                    cmdDelItens.Parameters.AddWithValue("@id", idVenda);
                    cmdDelItens.ExecuteNonQuery();
                }

                // Deleta a venda
                string sqlDelVenda = "DELETE FROM VENDA WHERE ID_VENDA = @id;";
                using (var cmdDelVenda = new SQLiteCommand(sqlDelVenda, conn, transaction))
                {
                    cmdDelVenda.Parameters.AddWithValue("@id", idVenda);
                    cmdDelVenda.ExecuteNonQuery();
                }

                // ********** NÃO INSERIR MOVIMENTAÇÃO AQUI **********
                // A trigger deve ser responsável por registrar a ENTRADA com NOME_FUNCIONARIO = 'SISTEMA'

                transaction.Commit();
                MessageBox.Show("Venda removida com sucesso!", "Sucesso");
                vendas.AtualizarTabela();
            }
            catch (Exception ex)
            {
                try { transaction.Rollback(); } catch { /* ignore rollback errors */ }
                MessageBox.Show("Erro ao remover a venda: " + ex.Message, "Erro");
            }
        }

        #endregion

        #region Backup Automático
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                if (!File.Exists(caminhoBanco)) return;

                if (!string.IsNullOrEmpty(UltimaPastaBackup) && Directory.Exists(UltimaPastaBackup))
                {
                    string nomeArquivo = $"TeleBipDB_AutoBackup_{DateTime.Now:yyyyMMdd_HHmmss}.db";
                    string caminhoDestino = Path.Combine(UltimaPastaBackup, nomeArquivo);
                    File.Copy(caminhoBanco, caminhoDestino, true);
                }
            }
            catch
            {
                // Silencioso
            }
        }
        #endregion
    }
}