# Changelog

All notable changes to Pure.Chart.RichRelationalModel.EFCore.Models.Configurations are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.4.1.1] — 2026-06-25

- Maintenance release: dependency and build updates.

## [0.1.0-preview.4.1.0] — 2026-06-07

- Maintenance release: dependency and build updates.

## [0.1.0-preview.4.0.0] — 2026-04-26

### Removed

- **`AxisConfiguration`** no longer configures a `ChartId` property. Match
  the removal of that column from the underlying `AxisEFCoreModel` in
  `Pure.Chart.RichRelationalModel.EFCore.Models`.

## [0.1.0-preview.3.0.0] — 2026-04-20

### Changed

- **`SeriesConfiguration`** renamed to **`ChartSeriesConfiguration`**,
  configuring `ChartSeriesEFCoreModel` (renamed from `SeriesEFCoreModel`),
  matching the corresponding rename in
  `Pure.Chart.RichRelationalModel.EFCore.Models`.

## [0.1.0-preview.2.0.0] — 2026-02-27

### Fixed

- **`ChartConfiguration`** — the `XAxisNavigation` and `YAxisNavigation`
  one-to-one relationships now configure their foreign key on
  `ChartEFCoreModel.XAxisId` / `ChartEFCoreModel.YAxisId` respectively,
  instead of both incorrectly pointing at `AxisEFCoreModel.ChartId`.

## [0.1.0-preview.1.0.0] — 2026-02-18

- Maintenance release: dependency and build updates.

## [0.1.0-preview.0.2.1] — 2026-02-18

### Added

- All four configurations (`ChartConfiguration`, `ChartTypeConfiguration`,
  `AxisConfiguration`, `SeriesConfiguration`) now set an explicit EF Core
  value comparer — `GuidValueComparer` or `StringValueComparer` from the
  new `Pure.Primitives.Abstractions.EFCore.ValueComparers` dependency — on
  every converted `IGuid`/`IString` property, alongside the existing value
  converters.

## [0.1.0-preview.0.2.0] — 2026-02-18

- Maintenance release: dependency and build updates.

## [0.1.0-preview.0.1.0] — 2026-02-16

### Added

Initial release. `IEntityTypeConfiguration<T>` implementations for the
Pure.Chart rich relational model, using converters from
`Pure.Primitives.Abstractions.EFCore.Converters`:

- **`ChartConfiguration`** — configures `ChartEFCoreModel`: GUID `Id`
  primary key, `Title` (max length 64) and `Description` string columns,
  a required `TypeId` foreign key to `ChartTypeEFCoreModel`, and one-to-one
  `XAxisNavigation`/`YAxisNavigation` relationships to `AxisEFCoreModel`.
- **`ChartTypeConfiguration`** — configures `ChartTypeEFCoreModel`: GUID
  `Id` primary key and a unique, required `Name` string column (max
  length 64).
- **`AxisConfiguration`** — configures `AxisEFCoreModel`: GUID `Id`
  primary key, a required `ChartId` GUID column, and a unique, required
  `Legend` string column (max length 64).
- **`SeriesConfiguration`** — configures `SeriesEFCoreModel`: GUID `Id`
  primary key, required `Legend` (max length 64), `XAxisSource`, and
  `YAxisSource` string columns, and a required `ChartId` GUID column.
