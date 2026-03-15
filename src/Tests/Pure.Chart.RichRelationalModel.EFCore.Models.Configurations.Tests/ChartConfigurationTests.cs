using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pure.Primitives.Abstractions.EFCore.Converters;
using Pure.Primitives.Abstractions.EFCore.ValueComparers;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations.Tests;

public sealed record ChartConfigurationTests
{
    private readonly IMutableEntityType _entityType;

    public ChartConfigurationTests()
    {
        ModelBuilder modelBuilder = new ModelBuilder();
        _ = modelBuilder.Entity<ChartTypeEFCoreModel>();
        _ = modelBuilder.Entity<AxisEFCoreModel>();
        new ChartConfiguration().Configure(modelBuilder.Entity<ChartEFCoreModel>());
        _entityType = modelBuilder.Model.FindEntityType(typeof(ChartEFCoreModel))!;
    }

    [Fact]
    public void HasPrimaryKeyOnId()
    {
        IMutableKey? pk = _entityType.FindPrimaryKey();
        Assert.NotNull(pk);
        _ = Assert.Single(pk!.Properties);
        Assert.Equal(nameof(ChartEFCoreModel.Id), pk.Properties[0].Name);
    }

    [Fact]
    public void IdIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Id)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void IdValueGeneratedNever()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Id)
        )!;
        Assert.Equal(ValueGenerated.Never, property.ValueGenerated);
    }

    [Fact]
    public void IdHasGuidTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Id)
        )!;
        _ = Assert.IsType<GuidTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void IdHasGuidValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Id)
        )!;
        _ = Assert.IsType<GuidValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void TitleIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Title)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void TitleHasMaxLength64()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Title)
        )!;
        Assert.Equal(64, property.GetMaxLength());
    }

    [Fact]
    public void TitleHasStringTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Title)
        )!;
        _ = Assert.IsType<StringTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void TitleHasStringValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Title)
        )!;
        _ = Assert.IsType<StringValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void DescriptionIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Description)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void DescriptionHasStringTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Description)
        )!;
        _ = Assert.IsType<StringTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void DescriptionHasStringValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.Description)
        )!;
        _ = Assert.IsType<StringValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void TypeIdIsRequired()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.TypeId)
        )!;
        Assert.False(property.IsNullable);
    }

    [Fact]
    public void TypeIdHasGuidTypeConverter()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.TypeId)
        )!;
        _ = Assert.IsType<GuidTypeConverter>(property.GetValueConverter());
    }

    [Fact]
    public void TypeIdHasGuidValueComparer()
    {
        IMutableProperty property = _entityType.FindProperty(
            nameof(ChartEFCoreModel.TypeId)
        )!;
        _ = Assert.IsType<GuidValueComparer>(property.GetValueComparer());
    }

    [Fact]
    public void HasForeignKeyToChartType()
    {
        IMutableForeignKey? fk = _entityType
            .GetForeignKeys()
            .FirstOrDefault(fk =>
                fk.PrincipalEntityType.ClrType == typeof(ChartTypeEFCoreModel)
            );
        Assert.NotNull(fk);
        _ = Assert.Single(fk!.Properties);
        Assert.Equal(nameof(ChartEFCoreModel.TypeId), fk.Properties[0].Name);
    }

    [Fact]
    public void HasOneToOneRelationshipWithXAxis()
    {
        IMutableForeignKey? fk = _entityType
            .GetForeignKeys()
            .FirstOrDefault(fk =>
                fk.Properties.Any(p => p.Name == nameof(ChartEFCoreModel.XAxisId))
            );
        Assert.NotNull(fk);
        Assert.True(fk!.IsUnique);
        Assert.Equal(typeof(AxisEFCoreModel), fk.PrincipalEntityType.ClrType);
    }

    [Fact]
    public void HasOneToOneRelationshipWithYAxis()
    {
        IMutableForeignKey? fk = _entityType
            .GetForeignKeys()
            .FirstOrDefault(fk =>
                fk.Properties.Any(p => p.Name == nameof(ChartEFCoreModel.YAxisId))
            );
        Assert.NotNull(fk);
        Assert.True(fk!.IsUnique);
        Assert.Equal(typeof(AxisEFCoreModel), fk.PrincipalEntityType.ClrType);
    }
}
