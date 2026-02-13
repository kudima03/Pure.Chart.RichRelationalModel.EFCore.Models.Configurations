using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pure.Primitives.Abstractions.EFCore.Converters;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Configurations;

public sealed record AxisConfiguration : IEntityTypeConfiguration<AxisEFCoreModel>
{
    public void Configure(EntityTypeBuilder<AxisEFCoreModel> builder)
    {
        _ = builder.HasKey(x => x.Id);

        _ = builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasConversion(new GuidTypeConverter());

        _ = builder
            .Property(x => x.Legend)
            .IsRequired()
            .HasConversion(new StringTypeConverter())
            .HasMaxLength(64);

        _ = builder.HasIndex(x => x.Legend).IsUnique();
    }
}
