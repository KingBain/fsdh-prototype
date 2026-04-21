using MudBlazor;

namespace Datahub.Portal.Scaffold.Pages.Account;

public static class AccountSectionCatalog
{
    public static readonly AccountSectionOption[] Sections =
    [
        new("profile", "Profile", Icons.Material.Outlined.Person),
        new("customization", "Customization", Icons.Material.Outlined.Badge),
        new("appearance", "Appearance", Icons.Material.Outlined.Palette),
        new("notifications", "Notifications", Icons.Material.Outlined.Notifications),
        new("achievements", "Achievements", Icons.Material.Outlined.EmojiEvents)
    ];

    public static string Normalize(string? section)
    {
        var candidate = section?.Trim().ToLowerInvariant();
        return candidate switch
        {
            null or "" => "profile",
            "profil" => "profile",
            "personnalisation" => "customization",
            "apparence" => "appearance",
            "notifications" => "notifications",
            "realisations" => "achievements",
            "achievements" => "achievements",
            "customization" => "customization",
            "appearance" => "appearance",
            "profile" => "profile",
            _ => "profile"
        };
    }

    public static AccountSectionOption Current(string? section)
    {
        var normalized = Normalize(section);
        return Sections.First(s => s.Slug == normalized);
    }
}
