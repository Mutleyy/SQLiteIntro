using Microsoft.EntityFrameworkCore;
using SQLiteIntro.Models;

namespace SQLiteIntro.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Pet> Pets { get; set; }
    }
}
