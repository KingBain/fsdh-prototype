namespace Datahub.Portal.Scaffold.Services;

public sealed class AccountProfileState
{
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Headline { get; set; } = "Federal Science DataHub member";
    public string Bio { get; set; } = "This is a scaffolded profile. Real profile data will be restored when the original user services return.";
    public string Theme { get; set; } = "Light mode";
    public string Language { get; set; } = "en-CA";
    public bool ShowAchievements { get; set; } = true;
    public bool ShowAlertsAndTutorials { get; set; } = true;
    public string NotificationLevel { get; set; } = "all";
    public string ProfileImagePath { get; set; } = "/img/scientist.png";
    public string BannerImagePath { get; set; } = "/img/signup-bg.jpg";
}
