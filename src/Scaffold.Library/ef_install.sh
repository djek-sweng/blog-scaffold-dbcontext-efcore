#!/bin/bash

dotnet tool install --global dotnet-ef
dotnet tool update  --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Relational
dotnet add package Pomelo.EntityFrameworkCore.MySql
