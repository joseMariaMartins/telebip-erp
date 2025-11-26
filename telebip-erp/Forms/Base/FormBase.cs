using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.Main;
using telebip_erp.Forms.Modules;
using telebip_erp.Forms.SubForms;
using System.IO;
using System.Collections.Generic;

namespace telebip_erp
{
    public partial class FormBase : MaterialForm
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

        private Action? callbackAposFecharDropdown = null;
        private bool aguardandoFechamentoDropdown = false;

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

            this.Width = 1250;
            this.Height = 650;
            pnlSidebar.Width = 43;
            pnlVendas.Height = 50;
            pnlEstoque.Height = 50;

            // Timers
            sidebarTransition.Interval = 5;
            menuTransitionVendas.Interval = 12;
            MenuTransitionEstoque.Interval = 12;

            RegistrarBotoesSelecionaveis();

            CriarOuRecuperarFormInicial();
            AbrirFormNoPanel(inicial!);
            ButtonSelectionManager.SelecionarBotao(btnHome);
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
        private void FecharDropdownComCallback(Action callback)
        {
            callbackAposFecharDropdown = callback;
            aguardandoFechamentoDropdown = true;

            if (menuExpandVendas)
                menuTransitionVendas.Start();
            else if (menuExpandEstoque)
                MenuTransitionEstoque.Start();
            else
                ExecutarCallback();
        }

        private void FecharTodosDropdowns()
        {
            if (menuExpandVendas) menuTransitionVendas.Start();
            if (menuExpandEstoque) MenuTransitionEstoque.Start();
        }

        private void ExecutarCallback()
        {
            callbackAposFecharDropdown?.Invoke();
            callbackAposFecharDropdown = null;
            aguardandoFechamentoDropdown = false;
        }
        #endregion

        #region Sistema de Forms (DENTRO DO PANEL)
        private void AbrirFormNoPanel(Form form)
        {
            FecharTodosDropdowns();

            pnlContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(form);
            form.Show();

            // ❌ Não forçamos tamanho nem SuspendLayout/ResumeLayout
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

        #region Animações Sidebar e Dropdowns
        private void menuTransitionVendas_Tick(object sender, EventArgs e)
        {
            if (!menuExpandVendas)
            {
                pnlVendas.Height += 8;
                if (pnlVendas.Height >= 150)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = true;
                    if (aguardandoFechamentoDropdown) ExecutarCallback();
                }
            }
            else
            {
                pnlVendas.Height -= 8;
                if (pnlVendas.Height <= 50)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = false;
                    if (aguardandoFechamentoDropdown) ExecutarCallback();
                }
            }
        }

        private void MenuTransitionEstoque_Tick(object sender, EventArgs e)
        {
            if (!menuExpandEstoque)
            {
                pnlEstoque.Height += 8;
                if (pnlEstoque.Height >= 150)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = true;
                    if (aguardandoFechamentoDropdown) ExecutarCallback();
                }
            }
            else
            {
                pnlEstoque.Height -= 8;
                if (pnlEstoque.Height <= 50)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = false;
                    if (aguardandoFechamentoDropdown) ExecutarCallback();
                }
            }
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnlSidebar.Width -= 280;
                if (pnlSidebar.Width <= 43)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    FecharTodosDropdowns();
                }
            }
            else
            {
                pnlSidebar.Width += 280;
                if (pnlSidebar.Width >= 280)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }
        #endregion

        #region Eventos da Sidebar e Botões
        private void btnHam_Click(object sender, EventArgs e) => sidebarTransition.Start();
        private void pnlHam_Click(object sender, EventArgs e) => sidebarTransition.Start();



        private void btnHome_Click(object sender, EventArgs e)
        {
            FecharTodosDropdowns();
            CriarOuRecuperarFormInicial();
            AbrirFormNoPanel(inicial!);
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            if (!sidebarExpand) sidebarTransition.Start();

            if (menuExpandEstoque)
            {
                FecharDropdownComCallback(() =>
                {
                    menuTransitionVendas.Start();
                    AbrirFormVendas();
                });
            }
            else
            {
                menuTransitionVendas.Start();
                AbrirFormVendas();
            }
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            if (!sidebarExpand) sidebarTransition.Start();

            if (menuExpandVendas)
            {
                FecharDropdownComCallback(() =>
                {
                    MenuTransitionEstoque.Start();
                    AbrirFormEstoque();
                });
            }
            else
            {
                MenuTransitionEstoque.Start();
                AbrirFormEstoque();
            }
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            FecharTodosDropdowns();
            CriarOuRecuperarFormRelatorios();
            AbrirFormNoPanel(relatorios!);
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            FecharTodosDropdowns();
            CriarOuRecuperarFormFuncionarios();
            AbrirFormNoPanel(funcionarios!);
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            FecharTodosDropdowns();
            CriarOuRecuperarFormConfiguracoes();
            AbrirFormNoPanel(configuracoes!);
        }

        private void AbrirFormVendas()
        {
            CriarOuRecuperarFormVendas();
            if (!pnlContainer.Controls.Contains(vendas!))
                AbrirFormNoPanel(vendas!);
            else
                vendas!.BringToFront();
        }

        private void AbrirFormEstoque()
        {
            CriarOuRecuperarFormEstoque();
            if (!pnlContainer.Controls.Contains(estoque!))
                AbrirFormNoPanel(estoque!);
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
            formRmv.FormClosed += (s, args) => estoque?.CarregarEstoque(limitar20: false);
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
                adicionarEstoqueForm.AtualizarEstoqueCallback = () => estoque?.CarregarEstoque(limitar20: false);
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
                using var cmdItens = new SQLiteCommand(sqlItens, conn);
                cmdItens.Parameters.AddWithValue("@id", idVenda);
                using var reader = cmdItens.ExecuteReader();
                while (reader.Read()) itens.Add((reader.GetInt32(0), reader.GetInt32(1)));

                string sqlDelItens = "DELETE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using var cmdDelItens = new SQLiteCommand(sqlDelItens, conn);
                cmdDelItens.Parameters.AddWithValue("@id", idVenda);
                cmdDelItens.ExecuteNonQuery();

                string sqlDelVenda = "DELETE FROM VENDA WHERE ID_VENDA = @id;";
                using var cmdDelVenda = new SQLiteCommand(sqlDelVenda, conn);
                cmdDelVenda.Parameters.AddWithValue("@id", idVenda);
                cmdDelVenda.ExecuteNonQuery();

                foreach (var item in itens)
                {
                    string sqlMov = @"
                        INSERT INTO MOVIMENTACAO_ESTOQUE
                        (ID_PRODUTO, ID_VENDA, NOME_FUNCIONARIO, TIPO_MOVIMENTACAO, QUANTIDADE, DATA_HORA)
                        VALUES (@idProduto, @idVenda, @nome, @tipo, @quantidade, @data);";

                    using var cmdMov = new SQLiteCommand(sqlMov, conn);
                    cmdMov.Parameters.AddWithValue("@idProduto", item.idProduto);
                    cmdMov.Parameters.AddWithValue("@idVenda", idVenda);
                    cmdMov.Parameters.AddWithValue("@nome", "GERENTE");
                    cmdMov.Parameters.AddWithValue("@tipo", "SAIDA");
                    cmdMov.Parameters.AddWithValue("@quantidade", item.quantidade);
                    cmdMov.Parameters.AddWithValue("@data", DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
                    cmdMov.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Venda removida e movimentação registrada com sucesso!", "Sucesso");
                vendas.AtualizarTabela();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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
