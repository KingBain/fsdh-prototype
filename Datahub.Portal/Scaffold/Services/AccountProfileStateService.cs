using System.Collections.Concurrent;

namespace Datahub.Portal.Scaffold.Services;

public sealed class AccountProfileStateService
{
    private readonly ConcurrentDictionary<string, AccountProfileState> _profiles = new(StringComparer.OrdinalIgnoreCase);

    public AccountProfileState GetOrCreate(string email, string fallbackDisplayName)
    {
        return _profiles.GetOrAdd(email, _ => CreateDefault(email, fallbackDisplayName));
    }

    public void Save(AccountProfileState state)
    {
        _profiles[state.Email] = Clone(state);
    }

    private static AccountProfileState CreateDefault(string email, string fallbackDisplayName)
    {
        var shortName = fallbackDisplayName.Trim();
        if (string.IsNullOrWhiteSpace(shortName))
        {
            shortName = email.Split('@')[0];
        }

        return new AccountProfileState
        {
            Email = email,
            DisplayName = shortName,
            Headline = "Federal Science DataHub member",
            Bio = "This local scaffold stores profile preferences in memory so the account area is interactive again without depending on the old mono-repo services.",
            Theme = "Light mode",
            Language = "en-CA",
            ShowAchievements = true,
            ShowAlertsAndTutorials = true,
            NotificationLevel = "all"
        };
    }

    private static AccountProfileState Clone(AccountProfileState state)
    {
        return new AccountProfileState
        {
            Email = state.Email,
            DisplayName = state.DisplayName,
            Headline = state.Headline,
            Bio = state.Bio,
            Theme = state.Theme,
            Language = state.Language,
            ShowAchievements = state.ShowAchievements,
            ShowAlertsAndTutorials = state.ShowAlertsAndTutorials,
            NotificationLevel = state.NotificationLevel,
            ProfileImagePath = state.ProfileImagePath,
            BannerImagePath = state.BannerImagePath
        };
    }
}
