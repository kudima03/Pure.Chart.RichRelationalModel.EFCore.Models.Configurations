using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pure.Primitives.Abstractions.EFCore.Converters;
using Pure.Primitives.Abstractions.EFCore.ValueComparers;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations.Tests;

public sealed record SeriesConfigurationTests
{
    private readonly IMutableEntityType _entityType;

    public SeriesConfigurationTests()
    {
        ModelBuilder modelBuilder = new ModelBuilder();
        new SeriesConfiguration().Configure(modelBuilder.Entity<SeriesEFCoreModel>());
        _entityType = modelBuilder.Model.FindEntityType(typeof(SeriesEFCoreModel))!;
    }

    [Fact]
    public void HasPrimaryKeyOnId()
    {
        IMutableKey? pk = _entityType.FindPrimaryKey();
        Assert.NotNull(pk);
        _ = Assert.Single(pk!.Properties);
        Assert.Equal(nameof(SeriesEFCoreModel.Id), pk.Properties[0].Name);
    }

    [Fact]
    public void IdIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Id)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void IdValueGeneratedNever()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Id)
        )!;
        Assert.Equal(ValueGenerated.Never, property.ValueGenerated);
    }

    [Fact]
    public void IdHasGuidTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Id)
        )!;
        _ = Assert.IsType<GuidTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void IdHasGuidValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Id)
        )!;
        _ = Assert.IsType<GuidValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void LegendIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Legend)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void LegendHasMaxLength64()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Legend)
        )!;
        Assert.Equal(64, property.GetMaxLength());
    }

    [Fact]
    public void LegendHasStringTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Legend)
        )!;
        _ = Assert.IsType<StringTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void LegendHasStringValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.Legend)
        )!;
        _ = Assert.IsType<StringValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void XAxisSourceIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.XAxisSource)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void XAxisSourceHasStringTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.XAxisSource)
        )!;
        _ = Assert.IsType<StringTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void XAxisSourceHasStringValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.XAxisSource)
        )!;
        _ = Assert.IsType<StringValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void YAxisSourceIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.YAxisSource)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void YAxisSourceHasStringTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.YAxisSource)
        )!;
        _ = Assert.IsType<StringTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void YAxisSourceHasStringValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.YAxisSource)
        )!;
        _ = Assert.IsType<StringValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void ChartIdIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.ChartId)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void ChartIdHasGuidTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.ChartId)
        )!;
        _ = Assert.IsType<GuidTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void ChartIdHasGuidValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(SeriesEFCoreModel.ChartId)
        )!;
        _ = Assert.IsType<GuidValueComparer>(property.GetValueComparer());
    }
}
