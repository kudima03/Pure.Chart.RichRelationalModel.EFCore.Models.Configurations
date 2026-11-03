using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations.Tests;

public sealed record ChartModelTests
{
    private readonly IModel _model;

    public ChartModelTests()
    {
        using ChartDbContext context = new ChartDbContext(
            new DbContextOptionsBuilder<ChartDbContext>()
                .UseInMemoryDatabase(nameof(ChartModelTests))
                .Options
        );
        _model = context.Model;
    }

    [Fact]
    public void SeriesHaveNoShadowProperties()
    {
        IEntityType entityType = _model.FindEntityType(typeof(ChartSeriesEFCoreModel))!;
        Assert.DoesNotContain(entityType.GetProperties(), p => p.IsShadowProperty());
    }

    [Fact]
    public void SeriesHaveSingleForeignKeyToChartOnChartId()
    {
        IEntityType entityType = _model.FindEntityType(typeof(ChartSeriesEFCoreModel))!;
        IForeignKey fk = Assert.Single(entityType.GetForeignKeys());
        Assert.Equal(typeof(ChartEFCoreModel), fk.PrincipalEntityType.ClrType);
        _ = Assert.Single(fk.Properties);
        Assert.Equal(nameof(ChartSeriesEFCoreModel.ChartId), fk.Properties[0].Name);
    }

    [Fact]
    public void SeriesAreCascadeDeletedWithChart()
    {
        IEntityType entityType = _model.FindEntityType(typeof(ChartSeriesEFCoreModel))!;
        IForeignKey fk = Assert.Single(entityType.GetForeignKeys());
        Assert.True(fk.IsRequired);
        Assert.Equal(DeleteBehavior.Cascade, fk.DeleteBehavior);
    }

    private sealed class ChartDbContext(DbContextOptions<ChartDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new ChartTypeConfiguration());
            _ = modelBuilder.ApplyConfiguration(new AxisConfiguration());
            _ = modelBuilder.ApplyConfiguration(new ChartSeriesConfiguration());
            _ = modelBuilder.ApplyConfiguration(new ChartConfiguration());
        }
    }
}
