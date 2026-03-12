using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Interfaces
{
    public interface IDbContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<DeviceType> DeviceTypes { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<Nomenclature> Nomenclatures { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
