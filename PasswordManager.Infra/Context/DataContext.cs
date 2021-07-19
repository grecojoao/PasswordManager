using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) =>
            Database.EnsureCreated();

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<User>().HasData(
                new User(userName: "Leo", password: "jN-_#X-EfAm#@eW_MsB") { Id = 1 });
    }
}