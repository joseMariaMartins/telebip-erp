using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using telebip_erp.Forms.Main;
using telebip_erp.Forms.Modules;
using telebip_erp.Forms.SubForms;

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

        FormAddVendas? adicionarVendaForm;
        FormAddEstoque? adicionarEstoqueForm;

        bool menuExpandVendas = false;
        bool menuExpandEstoque = false;
        bool sidebarExpand = false;

        // Variáveis para controle de callback
        private Action? callbackAposFecharDropdown = null;
        private bool aguardandoFechamentoDropdown = false;

        // ========== CONSTRUTOR ==========
        public FormBase()
        {
            InitializeComponent();
            ThemeManager.ApplyDarkTheme();

            this.Width = 1250;
            this.Height = 650;
            pnlSidebar.Width = 47;
            pnlVendas.Height = 50;
            pnlEstoque.Height = 50;

            // Configurar timers quase na mesma velocidade
            menuTransitionVendas.Interval = 12; // Só um tiquinho mais lento (era 10)
            MenuTransitionEstoque.Interval = 12; // Só um tiquinho mais lento (era 10)
            sidebarTransition.Interval = 12; // Só um tiquinho mais lento (era 10)

            RegistrarBotoesSelecionaveis();
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

        // ========== MÉTODO PARA FECHAR DROPDOWNS COM CALLBACK ==========
        private void FecharDropdownComCallback(Action callback)
        {
            callbackAposFecharDropdown = callback;
            aguardandoFechamentoDropdown = true;

            // Fecha dropdown de Vendas se estiver aberto
            if (menuExpandVendas)
            {
                menuTransitionVendas.Start();
            }
            // Fecha dropdown de Estoque se estiver aberto
            else if (menuExpandEstoque)
            {
                MenuTransitionEstoque.Start();
            }
            else
            {
                // Se nenhum dropdown estiver aberto, executa o callback imediatamente
                callbackAposFecharDropdown?.Invoke();
                callbackAposFecharDropdown = null;
                aguardandoFechamentoDropdown = false;
            }
        }

        // ========== MÉTODO PARA FECHAR DROPDOWNS ==========
        private void FecharTodosDropdowns()
        {
            // Fecha dropdown de Vendas se estiver aberto
            if (menuExpandVendas)
            {
                menuTransitionVendas.Start();
            }

            // Fecha dropdown de Estoque se estiver aberto
            if (menuExpandEstoque)
            {
                MenuTransitionEstoque.Start();
            }
        }

        // ========== MÉTODO BASE PARA ABRIR FORMULÁRIOS ==========
        private void AbrirFormNoPanel(Form form)
        {
            // Fecha dropdowns antes de abrir novo formulário
            FecharTodosDropdowns();

            pnlContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(form);
            form.Show();
        }

        // ========== EVENTOS DE TRANSIÇÃO ==========
        private void menuTransitionVendas_Tick(object sender, EventArgs e)
        {
            if (!menuExpandVendas)
            {
                pnlVendas.Height += 8; // Quase igual (era 10)
                if (pnlVendas.Height >= 150)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = true;

                    // Executa callback se estiver aguardando
                    if (aguardandoFechamentoDropdown)
                    {
                        callbackAposFecharDropdown?.Invoke();
                        callbackAposFecharDropdown = null;
                        aguardandoFechamentoDropdown = false;
                    }
                }
            }
            else
            {
                pnlVendas.Height -= 8; // Quase igual (era 10)
                if (pnlVendas.Height <= 50)
                {
                    menuTransitionVendas.Stop();
                    menuExpandVendas = false;

                    // Executa callback se estiver aguardando
                    if (aguardandoFechamentoDropdown)
                    {
                        callbackAposFecharDropdown?.Invoke();
                        callbackAposFecharDropdown = null;
                        aguardandoFechamentoDropdown = false;
                    }
                }
            }
        }

        private void MenuTransitionEstoque_Tick(object sender, EventArgs e)
        {
            if (!menuExpandEstoque)
            {
                pnlEstoque.Height += 8; // Quase igual (era 10)
                if (pnlEstoque.Height >= 150)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = true;

                    // Executa callback se estiver aguardando
                    if (aguardandoFechamentoDropdown)
                    {
                        callbackAposFecharDropdown?.Invoke();
                        callbackAposFecharDropdown = null;
                        aguardandoFechamentoDropdown = false;
                    }
                }
            }
            else
            {
                pnlEstoque.Height -= 8; // Quase igual (era 10)
                if (pnlEstoque.Height <= 50)
                {
                    MenuTransitionEstoque.Stop();
                    menuExpandEstoque = false;

                    // Executa callback se estiver aguardando
                    if (aguardandoFechamentoDropdown)
                    {
                        callbackAposFecharDropdown?.Invoke();
                        callbackAposFecharDropdown = null;
                        aguardandoFechamentoDropdown = false;
                    }
                }
            }
        }

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnlSidebar.Width -= 12; // Quase igual (era 15)
                if (pnlSidebar.Width <= 47)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    // Fecha dropdowns quando sidebar fecha
                    FecharTodosDropdowns();
                }
            }
            else
            {
                pnlSidebar.Width += 12; // Quase igual (era 15)
                if (pnlSidebar.Width >= 260)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        // ========== EVENTOS DOS BOTÕES ==========
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
            if (!sidebarExpand) sidebarTransition.Start();

            // Se outro dropdown estiver aberto, fecha primeiro e depois abre Vendas
            if (menuExpandEstoque)
            {
                FecharDropdownComCallback(() =>
                {
                    // Callback: quando Estoque fechar completamente, abre Vendas
                    menuTransitionVendas.Start();

                    // Abre o formulário de Vendas
                    if (vendas == null || vendas.IsDisposed)
                    {
                        vendas = new FormVendas();
                        vendas.FormClosed += (s, e2) => { vendas = null; };
                        AbrirFormNoPanel(vendas);
                    }
                    else if (!pnlContainer.Controls.Contains(vendas))
                        AbrirFormNoPanel(vendas);
                    else
                        vendas.BringToFront();
                });
            }
            else
            {
                // Se nenhum dropdown estiver aberto, comportamento normal
                menuTransitionVendas.Start();

                if (vendas == null || vendas.IsDisposed)
                {
                    vendas = new FormVendas();
                    vendas.FormClosed += (s, e2) => { vendas = null; };
                    AbrirFormNoPanel(vendas);
                }
                else if (!pnlContainer.Controls.Contains(vendas))
                    AbrirFormNoPanel(vendas);
                else
                    vendas.BringToFront();
            }
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            if (!sidebarExpand) sidebarTransition.Start();

            // Se outro dropdown estiver aberto, fecha primeiro e depois abre Estoque
            if (menuExpandVendas)
            {
                FecharDropdownComCallback(() =>
                {
                    // Callback: quando Vendas fechar completamente, abre Estoque
                    MenuTransitionEstoque.Start();

                    // Abre o formulário de Estoque
                    if (estoque == null || estoque.IsDisposed)
                    {
                        estoque = new FormEstoque();
                        estoque.FormClosed += (s, e2) => { estoque = null; };
                        AbrirFormNoPanel(estoque);
                    }
                    else if (!pnlContainer.Controls.Contains(estoque))
                        AbrirFormNoPanel(estoque);
                    else
                        estoque.BringToFront();
                });
            }
            else
            {
                // Se nenhum dropdown estiver aberto, comportamento normal
                MenuTransitionEstoque.Start();

                if (estoque == null || estoque.IsDisposed)
                {
                    estoque = new FormEstoque();
                    estoque.FormClosed += (s, e2) => { estoque = null; };
                    AbrirFormNoPanel(estoque);
                }
                else if (!pnlContainer.Controls.Contains(estoque))
                    AbrirFormNoPanel(estoque);
                else
                    estoque.BringToFront();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Fecha dropdowns ao ir para Home
            FecharTodosDropdowns();

            if (inicial == null || inicial.IsDisposed)
            {
                inicial = new FormInicial();
                inicial.FormClosed += (s, e) => { inicial = null; };
                AbrirFormNoPanel(inicial);
            }
            else if (!pnlContainer.Controls.Contains(inicial))
                AbrirFormNoPanel(inicial);
            else
                inicial.BringToFront();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            // Fecha dropdowns ao ir para Relatórios
            FecharTodosDropdowns();

            if (relatorios == null || relatorios.IsDisposed)
            {
                relatorios = new FormRelatorios();
                relatorios.FormClosed += (s, e2) => { relatorios = null; };
                AbrirFormNoPanel(relatorios);
            }
            else if (!pnlContainer.Controls.Contains(relatorios))
                AbrirFormNoPanel(relatorios);
            else
                relatorios.BringToFront();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            // Fecha dropdowns ao ir para Funcionários
            FecharTodosDropdowns();

            if (funcionarios == null || funcionarios.IsDisposed)
            {
                funcionarios = new FormFuncionarios();
                funcionarios.FormClosed += (s, e2) => { funcionarios = null; };
                AbrirFormNoPanel(funcionarios);
            }
            else if (!pnlContainer.Controls.Contains(funcionarios))
                AbrirFormNoPanel(funcionarios);
            else
                funcionarios.BringToFront();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            // Fecha dropdowns ao ir para Configurações
            FecharTodosDropdowns();

            if (configuracoes == null || configuracoes.IsDisposed)
            {
                configuracoes = new FormConfiguracoes();
                configuracoes.FormClosed += (s, e2) => { configuracoes = null; };
                AbrirFormNoPanel(configuracoes);
            }
            else if (!pnlContainer.Controls.Contains(configuracoes))
                AbrirFormNoPanel(configuracoes);
            else
                configuracoes.BringToFront();
        }

        // ========== BOTÕES ADICIONAR ==========
        private void addVenda_Click(object sender, EventArgs e)
        {
            if (adicionarVendaForm == null || adicionarVendaForm.IsDisposed)
            {
                adicionarVendaForm = new FormAddVendas();

                // 🔹 Callback para atualizar o DataGridView após confirmar venda
                adicionarVendaForm.VendaConfirmadaCallback = () =>
                {
                    if (vendas != null && !vendas.IsDisposed)
                        vendas.AtualizarTabela();
                };

                adicionarVendaForm.FormClosed += (s, args) => { adicionarVendaForm = null; };
                adicionarVendaForm.ShowDialog(this);
            }
            else
            {
                adicionarVendaForm.BringToFront();
            }
        }


        private void addEstoque_Click(object sender, EventArgs e)
        {
            AbrirFormAddEstoque();
        }

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

            using (var formRmv = new FormRmvEstoque(id, nome, quantidade))
            {
                // Atualiza apenas o DataGridView depois de fechar
                formRmv.FormClosed += (s, args) =>
                {
                    if (estoque != null && !estoque.IsDisposed)
                        estoque.CarregarEstoque(limitar20: false);
                };

                formRmv.ShowDialog(this);
            }
        }

        // ========== MÉTODO CENTRALIZADO PARA ABRIR FORMADD_ESTOQUE ==========
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
                adicionarEstoqueForm.FormClosed += (s, args) => { adicionarEstoqueForm = null; };

                // Callback apenas para atualizar DataGridView
                adicionarEstoqueForm.AtualizarEstoqueCallback = () =>
                {
                    if (estoque != null && !estoque.IsDisposed)
                        estoque.CarregarEstoque(limitar20: false);
                };
            }

            adicionarEstoqueForm.LimparCampos();

            var linhaSelecionada = estoque.ObterLinhaSelecionada();

            if (linhaSelecionada != null)
            {
                // Produto existente
                adicionarEstoqueForm.ProdutoSelecionado = (
                    Convert.ToInt32(linhaSelecionada.Cells["ID_PRODUTO"].Value),
                    linhaSelecionada.Cells["NOME"].Value?.ToString() ?? "",
                    Convert.ToInt32(linhaSelecionada.Cells["QTD_ESTOQUE"].Value)
                );

                // Preenche campos
                adicionarEstoqueForm.tbNome.Text = linhaSelecionada.Cells["NOME"].Value?.ToString() ?? "";
                adicionarEstoqueForm.tbMarca.Text = linhaSelecionada.Cells["MARCA"].Value?.ToString() ?? "";
                adicionarEstoqueForm.tbPreco.Text = "R$ " + Convert.ToDecimal(linhaSelecionada.Cells["PRECO"].Value).ToString("N2");
                adicionarEstoqueForm.tbQEstoque.Text = ""; // sempre vazio
                adicionarEstoqueForm.tbQAviso.Text = linhaSelecionada.Cells["QTD_AVISO"].Value?.ToString() ?? "";
                adicionarEstoqueForm.tbObservacao.Text = linhaSelecionada.Cells["OBSERVACAO"].Value?.ToString() ?? "";

                // Campos somente leitura
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
                // Produto novo
                adicionarEstoqueForm.ProdutoSelecionado = null;
                adicionarEstoqueForm.LimparCampos();
            }

            adicionarEstoqueForm.ShowDialog(this);
        }

        private void rmvVenda_Click(object sender, EventArgs e)
        {
            if (vendas == null || vendas.IsDisposed)
            {
                MessageBox.Show("Abra a tela de Vendas para remover uma venda.");
                return;
            }

            if (vendas.dgvVendas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma venda para remover.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja realmente remover a venda selecionada?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            int idVenda = Convert.ToInt32(vendas.dgvVendas.CurrentRow.Cells["ID_VENDA"].Value);

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var transaction = conn.BeginTransaction();
            try
            {
                // 1️⃣ Obter itens da venda
                string sqlItens = "SELECT ID_PRODUTO, QUANTIDADE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using var cmdItens = new SQLiteCommand(sqlItens, conn);
                cmdItens.Parameters.AddWithValue("@id", idVenda);

                var itens = new List<(int idProduto, int quantidade)>();
                using (var reader = cmdItens.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itens.Add((reader.GetInt32(0), reader.GetInt32(1)));
                    }
                }

                // 2️⃣ Remover itens da venda
                string sqlDelItens = "DELETE FROM ITEM_VENDA WHERE ID_VENDA = @id;";
                using var cmdDelItens = new SQLiteCommand(sqlDelItens, conn);
                cmdDelItens.Parameters.AddWithValue("@id", idVenda);
                cmdDelItens.ExecuteNonQuery();

                // 3️⃣ Remover a venda
                string sqlDelVenda = "DELETE FROM VENDA WHERE ID_VENDA = @id;";
                using var cmdDelVenda = new SQLiteCommand(sqlDelVenda, conn);
                cmdDelVenda.Parameters.AddWithValue("@id", idVenda);
                cmdDelVenda.ExecuteNonQuery();

                // 4️⃣ Registrar saída manual na MOVIMENTACAO_ESTOQUE
                foreach (var item in itens)
                {
                    string sqlMov = @"
                INSERT INTO MOVIMENTACAO_ESTOQUE
                (ID_PRODUTO, ID_VENDA, NOME_FUNCIONARIO, TIPO_MOVIMENTACAO, QUANTIDADE, DATA_HORA)
                VALUES (@idProduto, @idVenda, @nome, @tipo, @quantidade, @data);
            ";

                    using var cmdMov = new SQLiteCommand(sqlMov, conn);
                    cmdMov.Parameters.AddWithValue("@idProduto", item.idProduto);
                    cmdMov.Parameters.AddWithValue("@idVenda", idVenda);
                    cmdMov.Parameters.AddWithValue("@nome", "GERENTE");
                    cmdMov.Parameters.AddWithValue("@tipo", "SAIDA"); // porque é remoção
                    cmdMov.Parameters.AddWithValue("@quantidade", item.quantidade);
                    cmdMov.Parameters.AddWithValue("@data", DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
                    cmdMov.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Venda removida e movimentação registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza DataGridView
                vendas.AtualizarTabela();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Erro ao remover a venda: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}