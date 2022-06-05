#!/bin/bash

source ./config.sh

./clean_project.sh

dotnet ef dbcontext scaffold "$CONNECTION" "$PROVIDER" \
  --context "$CONTEXT" \
  --context-dir "$CONTEXT_DIR" \
  --context-namespace "$CONTEXT_NAMESPACE" \
  --output-dir "$OUTPUT_DIR" \
  --namespace "$NAMESPACE" \
  --force
  
dotnet build

# https://docs.microsoft.com/en-us/ef/core/cli/dotnet
