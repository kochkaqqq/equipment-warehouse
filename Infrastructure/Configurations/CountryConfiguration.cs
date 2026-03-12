using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("countries");

            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Name, n =>
            {
                n.Property(p => p.Value).HasColumnName("Name");
                n.Property(p => p.Value).HasColumnType("varchar(70)");
                n.Property(p => p.Value).IsRequired();
            });

            builder.OwnsOne(c => c.Code, c =>
            {
                c.Property(p => p.Value).HasColumnName("Code");
                c.Property(p => p.Value).HasColumnType("varchar(2)");
                c.Property(p => p.Value).IsRequired();
            });
        }
    }
}
