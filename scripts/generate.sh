#!/usr/bin/env bash
# Generates src/Affinity and src/Affinity.Test with Fern from spec/affinity.openapi.json, the
# committed Affinity contract. Fern runs locally in Docker; no Fern account or token is used.
# Needs Docker, Node (npx) and jq.
set -euo pipefail
root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$root"

version="0.5.0"
fern_version="$(jq -r .version fern/fern.config.json)"
generator="fernapi/fern-csharp-sdk"
generator_version="$(awk -v g="$generator" '$0 ~ "name: " g {found=1; next} found && /version:/ {print $2; exit}' fern/generators.yml)"
output="$root/.fern-output"
# Hand-written files inside the generated directories. Fern writes empty templates there.
handwritten=(src/Affinity/Affinity.Custom.props src/Affinity.Test/Affinity.Test.Custom.props)

jq -f scripts/prepare-spec.jq spec/affinity.openapi.json > fern/openapi.json
rm -rf "$output"
env -u FERN_TOKEN npx --yes "fern-api@$fern_version" generate --group csharp --local --no-prompt \
  --force --version "$version"
# Fern can exit 0 after its container fails; require the client it writes.
test -f "$output/src/Affinity/AffinityClient.cs" || { echo "Fern wrote no AffinityClient.cs" >&2; exit 1; }

mv "$output/reference.md" docs/reference.md
# Our README, CONTRIBUTING, .gitignore and CI replace Fern's; .fern/metadata.json records the
# local git commit, so it would differ on every run.
rm -rf "$output/README.md" "$output/CONTRIBUTING.md" "$output/.gitignore" "$output/.github" "$output/.fern"
for file in "${handwritten[@]}"; do rm -f "$output/$file"; done

keep="$(mktemp -d)"
trap 'rm -rf "$keep"' EXIT
for file in "${handwritten[@]}"; do mkdir -p "$keep/$(dirname "$file")"; cp "$file" "$keep/$file"; done
rm -rf src/Affinity src/Affinity.Test
cp -R "$output/." "$root/"
cp -R "$keep/." "$root/"
rm -rf "$output" fern/openapi.json

jq -n --arg contractVersion "$(jq -r .info.version spec/affinity.openapi.json)" \
  --arg contractSha256 "$(sha256sum spec/affinity.openapi.json | cut -d' ' -f1)" \
  --arg fernVersion "$fern_version" --arg generator "$generator" \
  --arg generatorVersion "$generator_version" --arg packageVersion "$version" \
  --argjson operations "$(jq '[.paths | to_entries[] | .key as $path | .value | to_entries[]
      | select(.value | type == "object" and has("operationId"))
      | {key: .value.operationId, value: "\(.key | ascii_upcase) \($path)"}] | from_entries' \
      spec/affinity.openapi.json)" \
  '{$contractVersion, $contractSha256, $fernVersion, $generator, $generatorVersion, $packageVersion, $operations}' \
  > generation.json
echo "Generated src/Affinity from API $(jq -r .contractVersion generation.json): $(jq '.operations | length' generation.json) operations."
