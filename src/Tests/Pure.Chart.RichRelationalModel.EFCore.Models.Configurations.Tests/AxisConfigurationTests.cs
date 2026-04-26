using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pure.Primitives.Abstractions.EFCore.Converters;
using Pure.Primitives.Abstractions.EFCore.ValueComparers;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations.Tests;

public sealed record AxisConfigurationTests
{
    private readonly IMutableEntityType _entityType;

    public AxisConfigurationTests()
    {
        ModelBuilder modelBuilder = new ModelBuilder();
        new AxisConfiguration().Configure(modelBuilder.Entity<AxisEFCoreModel>());
        _entityType = modelBuilder.Model.FindEntityType(typeof(AxisEFCoreModel))!;
    }

    [Fact]
    public void HasPrimaryKeyOnId()
    {
        IMutableKey? pk = _entityType.FindPrimaryKey();
        Assert.NotNull(pk);
        _ = Assert.Single(pk.Properties);
        Assert.Equal(nameof(AxisEFCoreModel.Id), pk.Properties[0].Name);
    }

    [Fact]
    public void IdIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(AxisEFCoreModel.Id))!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void IdValueGeneratedNever()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(AxisEFCoreModel.Id))!;
        Assert.Equal(ValueGenerated.Never, property.ValueGenerated);
    }

    [Fact]
    public void IdHasGuidTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(AxisEFCoreModel.Id))!;
        _ = Assert.IsType<GuidTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void IdHasGuidValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(AxisEFCoreModel.Id))!;
        _ = Assert.IsType<GuidValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void LegendIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(AxisEFCoreModel.Legend)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void LegendHasMaxLength64()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(AxisEFCoreModel.Legend)
        )!;
        Assert.Equal(64, property.GetMaxLength());
    }

    [Fact]
    public void LegendHasStringTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(AxisEFCoreModel.Legend)
        )!;
        _ = Assert.IsType<StringTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void LegendHasStringValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(AxisEFCoreModel.Legend)
        )!;
        _ = Assert.IsType<StringValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void LegendHasUniqueIndex()
    {
        IMutableIndex? index = _entityType
            .GetIndexes()
            .FirstOrDefault(i =>
                i.Properties.Any(p => p.Name == nameof(AxisEFCoreModel.Legend))
            );
        Assert.NotNull(index);
        Assert.True(index.IsUnique);
    }
}
