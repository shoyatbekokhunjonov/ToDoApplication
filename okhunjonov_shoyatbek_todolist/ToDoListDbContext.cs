using Microsoft.EntityFrameworkCore;
using okhunjonov_shoyatbek_todolist.Models;

namespace okhunjonov_shoyatbek_todolist
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoEntry>()
                .HasOne<ToDoList>(s => s.ToDoList)
                .WithMany(t => t.ToDoEntries)
                .HasForeignKey(s => s.ToDoListId);
        }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoEntry> ToDoEntries { get; set; }
    }
}
