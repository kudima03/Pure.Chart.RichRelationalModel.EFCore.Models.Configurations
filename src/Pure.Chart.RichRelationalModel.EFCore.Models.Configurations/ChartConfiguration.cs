using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pure.Primitives.Abstractions.EFCore.Converters;
using Pure.Primitives.Abstractions.EFCore.ValueComparers;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations;

public sealed record ChartConfiguration : IEntityTypeConfiguration<ChartEFCoreModel>
{
    public void Configure(EntityTypeBuilder<ChartEFCoreModel> builder)
    {
        _ = builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasConversion(new GuidTypeConverter())
            .Metadata.SetValueComparer(new GuidValueComparer());

        builder
            .Property(x => x.Title)
            .IsRequired()
            .HasConversion(new StringTypeConverter())
            .HasMaxLength(64)
            .Metadata.SetValueComparer(new StringValueComparer());

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasConversion(new StringTypeConverter())
            .Metadata.SetValueComparer(new StringValueComparer());

        builder
            .Property(x => x.TypeId)
            .IsRequired()
            .HasConversion(new GuidTypeConverter())
            .Metadata.SetValueComparer(new GuidValueComparer());

        _ = builder.HasOne(x => x.TypeNavigation).WithMany().HasForeignKey(x => x.TypeId);

        _ = builder
            .HasOne(x => x.XAxisNavigation)
            .WithOne()
            .HasForeignKey<AxisEFCoreModel>(x => x.ChartId);

        _ = builder
            .HasOne(x => x.YAxisNavigation)
            .WithOne()
            .HasForeignKey<AxisEFCoreModel>(x => x.ChartId);
    }
}
