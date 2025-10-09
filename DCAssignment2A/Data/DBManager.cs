using DCAssignment2A.Models;
using Microsoft.EntityFrameworkCore;

namespace DCAssignment2A.Data
{
    public class DBManager : DbContext
    {
        //sets up connecton with db so don't need to do it manually in program.cs
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database.db;");
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        //this method will let us seed the database with initial data
        //not gonna bother putting anything data inside yet tho
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
