#!/usr/bin/env bash
# Regenerates the SDK from spec/affinity.openapi.json and fails if anything differs from the
# files before the run: generated code is never edited by hand. Needs Docker, Node and jq.
set -euo pipefail
root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
snapshot="$(mktemp -d)"
trap 'rm -rf "$snapshot"' EXIT
generated=(src/Affinity src/Affinity.Test Affinity.slnx .editorconfig generation.json docs/reference.md)
for path in "${generated[@]}"; do
  mkdir -p "$snapshot/$(dirname "$path")"
  cp -R "$root/$path" "$snapshot/$path"
done
"$root/scripts/generate.sh" >/dev/null
status=0
for path in "${generated[@]}"; do
  diff -ru --exclude=bin --exclude=obj "$snapshot/$path" "$root/$path" || status=1
done
if [ "$status" -ne 0 ]; then
  echo "Generated files differ from the contract. Run scripts/generate.sh and commit the result." >&2
fi
exit "$status"
