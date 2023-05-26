using Microsoft.EntityFrameworkCore;

namespace Contractor.API.DbContext
{
    public class ContractorDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ContractorDbContext(DbContextOptions<ContractorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Contractor> Contractors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dodanie kilku rekordów do bazy danych

            modelBuilder.Entity<Entities.Contractor>().HasData(
                new
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "WSIZ",
                    Nip = "1234567890",
                    PhoneNo = "178660000",
                    Email = "wsiz@wsiz.edu.pl"
                },
                new
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "UR",
                    Nip = "0987654321",
                    PhoneNo = "179999999",
                    Email = "ur@ur.edu.pl"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
