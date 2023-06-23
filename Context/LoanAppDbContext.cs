using Microsoft.EntityFrameworkCore;

namespace Session4.Context
{
    public class LoanAppDbContext : DbContext
    {
        public LoanAppDbContext(DbContextOptions<LoanAppDbContext> Context) : base(Context)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Loans)
                .WithOne(l => l.Customer)
                .HasForeignKey(l => l.CustomerId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Shubham Khilari",
                    Address = "Sanpada,Navi Mumbai",
                    Email = "shubhamkhilari97@gmail.com",
                    PhoneNumber = "8108182747"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Palash Waghmare",
                    Address = "Kamothe,Navi Mumbai",
                    Email = "palash@gmail.com",
                    PhoneNumber = "7834989342"
                }
                );
        }
    }
}
