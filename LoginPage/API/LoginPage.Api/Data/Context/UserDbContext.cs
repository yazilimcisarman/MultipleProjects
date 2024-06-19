using LoginPage.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoginPage.Api.Data.Context
{
    public class UserDbContext: DbContext
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
