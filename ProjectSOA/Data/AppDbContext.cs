using Microsoft.EntityFrameworkCore;
using ProjectSOA.Models;

namespace ProjectSOA.Data
{
    public class AppDbContext : DbContext
    {
       
          
          
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Book> Books { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<BookTable> BookTables { get; set; }
     





    }


}
