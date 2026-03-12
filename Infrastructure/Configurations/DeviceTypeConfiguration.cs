using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class DeviceTypeConfiguration : IEntityTypeConfiguration<DeviceType>
    {
        public void Configure(EntityTypeBuilder<DeviceType> builder)
        {
            builder.ToTable("device_types");

            builder.HasKey(dt => dt.Id);

            builder.OwnsOne(dt => dt.Name, n =>
            {
                n.Property(p => p.Value).HasColumnName("Name");
                n.Property(p => p.Value).HasColumnType("varchar(70)");
                n.Property(p => p.Value).IsRequired();
            });

            builder.OwnsOne(dt => dt.Description, d =>
            {
                d.Property(p => p.Value).HasColumnName("Description");
                d.Property(p => p.Value).HasColumnType("varchar(511)");
            });
        }
    }
}
