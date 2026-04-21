using MudBlazor;
using MudBlazor.Utilities;

namespace Datahub.Portal.Scaffold;

public static class AppTheme
{
    public static readonly string DrawerBorderStyle = new StyleBuilder()
        .AddStyle("border-right", "1px solid var(--mud-palette-lines-default)")
        .Build();

    public static readonly MudTheme DefaultTheme = new()
    {
        LayoutProperties = new LayoutProperties
        {
            AppbarHeight = "74px",
            DrawerWidthLeft = "280px"
        },
        Typography = new Typography
        {
            Default = new DefaultTypography
            {
                FontFamily = new[] { "Open Sans", "sans-serif" },
                FontSize = "0.95rem",
                LineHeight = "1.65"
            },
            H1 = new H1Typography { FontSize = "2.6rem", FontWeight = "700", LineHeight = "1.1" },
            H2 = new H2Typography { FontSize = "1.85rem", FontWeight = "700", LineHeight = "1.2" },
            H3 = new H3Typography { FontSize = "1.45rem", FontWeight = "700", LineHeight = "1.2" }
        },
        PaletteLight = new PaletteLight
        {
            Primary = "#2460FF",
            Secondary = "#0535D2",
            Tertiary = "#2B4380",
            Info = "#2460FF",
            Warning = "#B3800F",
            Error = "#D3080C",
            AppbarBackground = Colors.Shades.White,
            Background = "#F5F7FB",
            Surface = Colors.Shades.White,
            DrawerBackground = "#FCFDFF"
        }
    };
}
