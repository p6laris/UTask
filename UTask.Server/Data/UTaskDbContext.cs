using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace UTask.Server.Data
{
    public class UTaskDbContext : DbContext
    {

        public UTaskDbContext(DbContextOptions<UTaskDbContext> opts) : base(opts)
        {

        }

        public DbSet<Shared.Models.Task>? Tasks { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<CheckedTasks>? CheckedTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "Shopping"
            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 2,
                Name = "Study"
            });

            modelBuilder.Entity<Shared.Models.Task>().HasData(new Shared.Models.Task()
            {
                Id = 1,
                Body = "Dont forget to buy an IPhone",
                CategoryId = 1,
                Priority = Priority.Medium,
                Title = "Have to go to shopping"
            });
        }

    }
}
