# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All commands run from the solution root unless noted.

```bash
# Build
dotnet build

# Run all tests
dotnet test

# Run a single test project
dotnet test tests/Tests.Unit.Cli/Tests.Unit.Cli.csproj
dotnet test tests/Tests.Unit.Infrastructure/Tests.Unit.Infrastructure.csproj

# Run the CLI
dotnet run --project src/MaaldoCom.Cli -- <command> [options]
```

The API client proxy (`Generated/MaaldoApiClient.cs`) is auto-generated from the OpenAPI spec at build time via `Refitter.SourceGenerator`. Rebuilding regenerates it from `src/MaaldoCom.Cli.Infrastructure/MaaldoComApi/maaldo-api.refitter`.

## Architecture

This is a **.NET 10 console CLI** built with **Spectre.Console.Cli**. It uses a layered clean architecture enforced by `NetArchTest.Rules` in the test projects.

### Layer dependency rules (enforced by tests)
- `Domain` → no dependencies on other layers
- `Contracts` → no dependencies on other layers
- `Infrastructure` → depends on `Contracts` and `Domain`
- `Cli` (entry point) → depends on `Infrastructure`

### Projects

| Project | Role |
|---|---|
| `MaaldoCom.Cli` | Entry point. Wires DI (`Program.cs`), registers commands. |
| `MaaldoCom.Cli.Domain` | Pure domain logic — `MediaAlbumHelper` (file path conventions, sanitization, media type detection). |
| `MaaldoCom.Cli.Contracts` | Shared interfaces and DTOs — `IMediaMetaDataCreator`, request/response models. |
| `MaaldoCom.Cli.Infrastructure` | Implementations — API client via Refit (`MaaldoApiClient`), `FFmpegMediaMetaDataCreator`. |

### Adding a new command

1. Create a `*CommandSettings`, `*Command` (implementing `AsyncCommand<TSettings>`), and a static configurator extension method in `src/MaaldoCom.Cli/Commands/`.
2. Register it in `Program.cs` via the configurator extension.
3. Commands that call the API extend `BaseApiCommandSettings` (which provides the `<environment>` argument: `local`, `dev`, `test`, `prod`).

### API environments

Configured in `appsettings.json`. `ApiClientFactory` reads `apiEnvironments:{env}:maaldoApiBaseUrl`. For `local`, SSL validation is bypassed.

### Media album workflow (`create-mediaalbum-metafiles`)

1. Sanitizes filenames in the target directory (spaces/underscores → hyphens, lowercase).
2. Calls `FFmpegMediaMetaDataCreator` which shells out to `ffmpeg` to produce thumbnail and viewer-resolution versions in `thumbnail/` and `viewer/` subdirectories; originals are moved to `original/`.
3. Writes a `post-mediaalbum-request.json` in the target directory.

### Package management

Central package versioning via `Directory.Packages.props`. Add version entries there; reference packages in `.csproj` files without versions.
