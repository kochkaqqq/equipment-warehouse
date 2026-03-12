using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class NomenclatureConfiguration : IEntityTypeConfiguration<Nomenclature>
    {
        public void Configure(EntityTypeBuilder<Nomenclature> builder)
        {
            builder.ToTable("nomenclatures");

            builder.HasKey(n => n.Id);

            builder.OwnsOne(n => n.DeviceImage, d =>
            {
                d.Property(p => p.Url).HasColumnName("Url");
                d.Property(p => p.Url).HasColumnType("text");
                d.Property(p => p.Url).IsRequired();
            
                d.Property(p => p.Caption).HasColumnName("Caption");
                d.Property(p => p.Caption).HasColumnType("varchar(200)");
            });

            builder.OwnsOne(n => n.ModelName, m =>
            {
                m.Property(p => p.Value).HasColumnName("ModelName");
                m.Property(p => p.Value).HasColumnType("varchar(100)");
                m.Property(p => p.Value).IsRequired();
            });
    
            builder.OwnsOne(n => n.Price, p =>
            {
                p.Property(p => p.Value).HasColumnName("Price");
                p.Property(p => p.Value).HasColumnType("decimal(18,2)");
                p.Property(p => p.Value).IsRequired();

                p.Property(p => p.Currency).HasColumnName("Currency");
                p.Property(p => p.Currency).HasColumnType("varchar(3)");
            });
    
            builder.HasOne(n => n.DeviceType)
                    .WithMany()
                    .HasForeignKey("DeviceTypeId")
                    .OnDelete(DeleteBehavior.Restrict);
    
            builder.HasOne(n => n.Manufacturer)
                    .WithMany()
                    .HasForeignKey("ManufacturerId")
                    .OnDelete(DeleteBehavior.Restrict);
    
            builder.HasOne(n => n.Country)
                    .WithMany()
                    .HasForeignKey("CountryId")
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
