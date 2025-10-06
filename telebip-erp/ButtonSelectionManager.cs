public static class ButtonSelectionManager
{
    private static List<Control> _botoesSelecionaveis = new List<Control>();
    private static Control _botaoAtualSelecionado = null;

    // Cores (ajuste conforme seu tema)
    private static Color COR_SELECIONADO = Color.FromArgb(33, 34, 49); // Azul Material
    private static Color COR_NORMAL = Color.FromArgb(23, 24, 29); // Cinza escuro Material

    public static void RegistrarBotao(Control botao)
    {
        if (!_botoesSelecionaveis.Contains(botao))
        {
            _botoesSelecionaveis.Add(botao);
            botao.Click += OnBotaoClicado;
        }
    }

    public static void SelecionarBotao(Control botao)
    {
        // Remove seleção anterior
        if (_botaoAtualSelecionado != null)
        {
            ResetarBotao(_botaoAtualSelecionado);
        }

        // Aplica seleção nova
        AplicarSelecao(botao);
        _botaoAtualSelecionado = botao;
    }

    private static void AplicarSelecao(Control botao)
    {
        botao.BackColor = COR_SELECIONADO;

        // Se for MaterialButton, usa a propriedade específica
        if (botao is MaterialSkin.Controls.MaterialButton materialBtn)
        {
            materialBtn.UseAccentColor = true;
        }

        botao.ForeColor = Color.White;
    }

    private static void ResetarBotao(Control botao)
    {
        botao.BackColor = COR_NORMAL;

        // Se for MaterialButton, reseta a propriedade específica
        if (botao is MaterialSkin.Controls.MaterialButton materialBtn)
        {
            materialBtn.UseAccentColor = false;
        }

        botao.ForeColor = Color.Silver;
    }

    private static void OnBotaoClicado(object sender, EventArgs e)
    {
        if (sender is Control botao)
        {
            SelecionarBotao(botao);
        }
    }

    public static void LimparSelecao()
    {
        if (_botaoAtualSelecionado != null)
        {
            ResetarBotao(_botaoAtualSelecionado);
            _botaoAtualSelecionado = null;
        }
    }
}