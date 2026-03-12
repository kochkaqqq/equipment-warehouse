using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("manufacturers");

            builder.HasKey(m => m.Id);

            builder.OwnsOne(m => m.Name, n =>
            {
                n.Property(p => p.Value).HasColumnName("Name");
                n.Property(p => p.Value).HasColumnType("varchar(70)");
                n.Property(p => p.Value).IsRequired();
            });

            builder.OwnsOne(m => m.Description, d =>
            {
                d.Property(p => p.Value).HasColumnName("Description");
                d.Property(p => p.Value).HasColumnType("varchar(511)");
            });
        }
    }
}
