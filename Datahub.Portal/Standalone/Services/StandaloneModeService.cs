using Datahub.Portal.Standalone.Models;

namespace Datahub.Portal.Standalone.Services;

/// <summary>
/// No-op implementation used when external sibling projects are not available.
/// </summary>
internal sealed class StandaloneModeService : IStandaloneModeService
{
    public StandaloneStatusDto GetStatus() => new(
        IsEnabled: true,
        Mode: "standalone",
        StubbedDependencies:
        [
            "Datahub.Application",
            "Datahub.CatalogSearch",
            "Datahub.Core",
            "Datahub.Infrastructure",
            "Datahub.Infrastructure.Offline",
            "Datahub.Metadata",
            "Datahub.Portal.Metadata"
        ]);
}
