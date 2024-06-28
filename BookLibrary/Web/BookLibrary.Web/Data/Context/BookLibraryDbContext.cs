using BookLibrary.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookLibrary.Web.Data.Context
{
    public class BookLibraryDbContext : DbContext
    {
        public BookLibraryDbContext(DbContextOptions<BookLibraryDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSA;database=MultipleProjects;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Book> Books { get; set; }
    }
}
