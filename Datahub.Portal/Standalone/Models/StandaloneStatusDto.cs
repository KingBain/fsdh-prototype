namespace Datahub.Portal.Standalone.Models;

/// <summary>
/// Lightweight status object used by the standalone host to expose runtime state in
/// pages and layout components without depending on shared Datahub libraries.
/// </summary>
internal sealed record StandaloneStatusDto(
    bool IsEnabled,
    string Mode,
    IReadOnlyList<string> StubbedDependencies);
