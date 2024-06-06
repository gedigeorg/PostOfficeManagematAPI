using Microsoft.EntityFrameworkCore;
using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelBag> ParcelBags { get; set; }
        public DbSet<LetterBag> LetterBags { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
    }
}
