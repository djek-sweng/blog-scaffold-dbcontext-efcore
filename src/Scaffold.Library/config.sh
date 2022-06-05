#!/bin/bash

export CONNECTION="Server=localhost; Port=4200; Username=root; Password=pasSworD; Database=db_scaffold_efcore;"
export PROVIDER="Pomelo.EntityFrameworkCore.MySql"
export CONTEXT="DatabaseContext"
export CONTEXT_DIR="./Data/Generated"
export CONTEXT_NAMESPACE="Scaffold.Library.Data"
export OUTPUT_DIR="./Models/Generated"
export NAMESPACE="Scaffold.Library.Models"
