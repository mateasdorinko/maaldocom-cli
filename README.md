<img src="/assets/logo.svg" width="100" />

# MaaldoCom Cli

[![CI/CD Pipeline](https://github.com/mateasdorinko/maaldocom-cli/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/mateasdorinko/maaldocom-cli/actions/workflows/ci-cd.yml)

![Code Coverage](https://raw.githubusercontent.com/mateasdorinko/maaldocom-cli/badges/badges/badge_linecoverage.svg)

A .NET 10 CLI tool for interacting with the maaldo.com API and managing media album assets locally.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [ffmpeg](https://ffmpeg.org/) (required for the `create-mediaalbum-metafiles` command)

## Build & Run

```bash
# Build
dotnet build

# Run
dotnet run --project src/MaaldoCom.Cli -- <command> [options]

# Run tests
dotnet test
```

## Commands

All API commands require an `<environment>` argument: `local`, `dev`, `test`, or `prod`.

| Command | Description |
|---|---|
| `knowledge <env>` | Lists knowledge items from the API. Use `-r`/`--random` for a single random item. |
| `tags <env>` | Lists all tags. Use `-n`/`--name <name>` to filter by name with associated media details. |
| `cache-refresh <env>` | Triggers a cache refresh on the API. |
| `create-mediaalbum-metafiles <path>` | Prepares a local media album directory for upload (see below). |

### `create-mediaalbum-metafiles`

Given a directory of images/videos, this command:

1. Sanitizes filenames (spaces and underscores → hyphens, lowercased).
2. Uses `ffmpeg` to generate thumbnail and viewer-resolution variants into `thumbnail/` and `viewer/` subdirectories.
3. Moves originals into an `original/` subdirectory.
4. Writes a `post-mediaalbum-request.json` file ready for API submission.

```bash
dotnet run --project src/MaaldoCom.Cli -- create-mediaalbum-metafiles "C:\path\to\my-album"
```

## OpenAPI Client Generation

The API client (`IMaaldoApiClient`) is auto-generated at build time from the live OpenAPI spec via `Refitter.SourceGenerator`. The generator is configured in `src/MaaldoCom.Cli.Infrastructure/MaaldoComApi/maaldo-api.refitter`. Rebuilding the solution regenerates the client.
