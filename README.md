# Pure.Chart.RichRelationalModel.EFCore.Models.Configurations

EF Core `IEntityTypeConfiguration<T>` implementations for the **Pure.Chart** rich relational model.

[![.NET build & test](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models.Configurations/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models.Configurations/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models.Configurations/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models.Configurations/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Chart.RichRelationalModel.EFCore.Models.Configurations)](https://www.nuget.org/packages/Pure.Chart.RichRelationalModel.EFCore.Models.Configurations)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Chart.RichRelationalModel.EFCore.Models.Configurations` provides EF Core type configurations for chart rich relational model entities — charts, axes, chart types, and series — with column mappings, key constraints, max lengths, foreign key relationships, and Pure primitive converters/comparers.

Register all four configurations in `OnModelCreating` to persist the chart domain model via EF Core.

## Configurations

| Type | Entity | Description |
|---|---|---|
| `ChartConfiguration` | `ChartEFCoreModel` | GUID PK, Title and Description columns, TypeId/XAxisId/YAxisId FKs, one-to-many Series navigation |
| `ChartTypeConfiguration` | `ChartTypeEFCoreModel` | GUID PK, Name column (max 128) |
| `AxisConfiguration` | `AxisEFCoreModel` | GUID PK, Legend string column |
| `ChartSeriesConfiguration` | `ChartSeriesEFCoreModel` | GUID PK, ChartId FK, Legend, XAxisSource and YAxisSource columns |

All `IGuid` and `IString` properties use converters from `Pure.Primitives.Abstractions.EFCore.Converters` and comparers from `Pure.Primitives.Abstractions.EFCore.ValueComparers`.

## Dependencies

- [`Pure.Chart.RichRelationalModel.EFCore.Models`](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models) — EF Core entity records
- [`Pure.Primitives.Abstractions.EFCore.Converters`](https://github.com/kudima03/Pure.Primitives.Abstractions.EFCore.Converters) — value converters for Pure primitive types
- [`Pure.Primitives.Abstractions.EFCore.ValueComparers`](https://github.com/kudima03/Pure.Primitives.Abstractions.EFCore.ValueComparers) — value comparers for Pure primitive types
