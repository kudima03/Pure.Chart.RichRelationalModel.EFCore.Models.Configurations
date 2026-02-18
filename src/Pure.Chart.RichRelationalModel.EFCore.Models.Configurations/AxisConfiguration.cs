using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pure.Primitives.Abstractions.EFCore.Converters;
using Pure.Primitives.Abstractions.EFCore.ValueComparers;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations;

public sealed record AxisConfiguration : IEntityTypeConfiguration<AxisEFCoreModel>
{
    public void Configure(EntityTypeBuilder<AxisEFCoreModel> builder)
    {
        _ = builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasConversion(new GuidTypeConverter())
            .Metadata.SetValueComparer(new GuidValueComparer());

        builder
            .Property(x => x.ChartId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasConversion(new GuidTypeConverter())
            .Metadata.SetValueComparer(new GuidValueComparer());

        builder
            .Property(x => x.Legend)
            .IsRequired()
            .HasConversion(new StringTypeConverter())
            .HasMaxLength(64)
            .Metadata.SetValueComparer(new StringValueComparer());

        _ = builder.HasIndex(x => x.Legend).IsUnique();
    }
}
