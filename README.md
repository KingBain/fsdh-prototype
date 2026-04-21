# fsdh-prototype
## Standalone mode

This repository is currently configured to run `Datahub.Portal` in **standalone mode**.

What this means:
- Sibling project references that are not present in this repo were intentionally removed from `Datahub.Portal/Datahub.Portal.csproj`.
- A local scaffolding layer was added under `Datahub.Portal/Standalone/` for minimal in-host contracts and no-op adapters.
- The standalone scaffolding currently exposes a mode/status service so pages and layout logic can bind to a local, compile-safe source of host metadata.

Intentionally stubbed dependencies include:
`Datahub.Application`, `Datahub.CatalogSearch`, `Datahub.Core`, `Datahub.Infrastructure`, `Datahub.Infrastructure.Offline`, `Datahub.Metadata`, and `Datahub.Portal.Metadata`.

### Dev Container (Linux-friendly)

A `.devcontainer/devcontainer.json` definition is included for local validation on Linux-based laptops.

Quick start:
1. Install Docker + VS Code Dev Containers extension.
2. Open this repository in VS Code.
3. Run **Dev Containers: Reopen in Container**.
4. The container runs `dotnet restore Datahub.Portal/Datahub.Portal.csproj` automatically after creation.
