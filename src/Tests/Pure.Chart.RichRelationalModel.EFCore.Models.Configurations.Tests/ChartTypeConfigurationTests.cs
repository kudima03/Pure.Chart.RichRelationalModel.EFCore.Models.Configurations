using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pure.Primitives.Abstractions.EFCore.Converters;
using Pure.Primitives.Abstractions.EFCore.ValueComparers;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations.Tests;

public sealed record ChartTypeConfigurationTests
{
    private readonly IMutableEntityType _entityType;

    public ChartTypeConfigurationTests()
    {
        ModelBuilder modelBuilder = new ModelBuilder();
        new ChartTypeConfiguration().Configure(
            modelBuilder.Entity<ChartTypeEFCoreModel>()
        );
        _entityType = modelBuilder.Model.FindEntityType(typeof(ChartTypeEFCoreModel))!;
    }

    [Fact]
    public void HasPrimaryKeyOnId()
    {
        IMutableKey? pk = _entityType.FindPrimaryKey();
        Assert.NotNull(pk);
        _ = Assert.Single(pk!.Properties);
        Assert.Equal(nameof(ChartTypeEFCoreModel.Id), pk.Properties[0].Name);
    }

    [Fact]
    public void IdIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Id))!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void IdValueGeneratedNever()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Id))!;
        Assert.Equal(ValueGenerated.Never, property.ValueGenerated);
    }

    [Fact]
    public void IdHasGuidTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Id))!;
        _ = Assert.IsType<GuidTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void IdHasGuidValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Id))!;
        _ = Assert.IsType<GuidValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void NameIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Name))!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void NameHasMaxLength64()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Name))!;
        Assert.Equal(64, property.GetMaxLength());
    }

    [Fact]
    public void NameHasStringTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Name))!;
        _ = Assert.IsType<StringTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void NameHasStringValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(nameof(ChartTypeEFCoreModel.Name))!;
        _ = Assert.IsType<StringValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void NameHasUniqueIndex()
    {
        IMutableIndex? index = _entityType
            .GetIndexes()
            .FirstOrDefault(i =>
                i.Properties.Any(p => p.Name == nameof(ChartTypeEFCoreModel.Name))
            );
        Assert.NotNull(index);
        Assert.True(index!.IsUnique);
    }
}
