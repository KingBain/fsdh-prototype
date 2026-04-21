using Datahub.Portal.Standalone.Models;

namespace Datahub.Portal.Standalone.Services;

/// <summary>
/// Represents portal-wide standalone mode metadata required by UI composition.
/// </summary>
internal interface IStandaloneModeService
{
    StandaloneStatusDto GetStatus();
}
