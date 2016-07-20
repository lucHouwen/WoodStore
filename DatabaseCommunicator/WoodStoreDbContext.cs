using DatabaseCommunicator.Classes;
using System.Data.Entity;

namespace DatabaseCommunicator
{
   public class WoodStoreDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<FloorCovering> FloorCoverings { get; set; }

        public DbSet<Parquet> Parquets { get; set; }
        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<Laminate> Laminates { get; set; }
        public DbSet<Plinth> Plinths { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Isolation> Isolations { get; set; }
        public DbSet<Glue> Glues { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.Initialize(true);
        //    modelBuilder.Entity<Parquet>().HasOptional(p => p.).WithOptionalPrincipal(a => a.Parquet);
        //}
    }
}
