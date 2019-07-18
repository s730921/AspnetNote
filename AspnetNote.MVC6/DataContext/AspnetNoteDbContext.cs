using AspnetNote.MVC6.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetNote.MVC6.DataContext
{
    public class AspnetNoteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Standard Security
            optionsBuilder.UseSqlServer(@"Server=61.100.185.241;Database=AspnetNoteDB;User Id=AspNetTest; Password = @djtptmxkitxla@241; ");
        }
    }
}
