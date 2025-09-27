using MaterialSkin;

public static class ThemeManager
{
    public static void ApplyDarkTheme()
    {
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.EnforceBackcolorOnAllComponents = true;
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(
            Color.Black,
            Color.Black,
            Color.Black,
            Color.Red,
            TextShade.WHITE
        );
    }
}

// Uso: ThemeManager.ApplyDarkTheme();