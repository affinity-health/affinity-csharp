# C# SDK

- Generated source comes from the Affinity OpenAPI/Forge pipeline. Fix generator configuration or packaging upstream, then regenerate; do not hand-edit models.
- Run `./scripts/check.sh` with Docker before committing.
- Keep transport fixtures synthetic. Never include API keys or patient data.
- Preserve the curated README, scripts, tests, and metadata when regenerating.
- Registry publication is deferred; do not add automatic publishing.
