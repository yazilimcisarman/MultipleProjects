using LoginPage.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginPage.Web.Data.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSA;database=MultipleProjects;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<User> Users { get; set; }
    }
}
