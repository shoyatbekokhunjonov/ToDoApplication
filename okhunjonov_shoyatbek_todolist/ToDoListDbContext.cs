using Microsoft.EntityFrameworkCore;
using okhunjonov_shoyatbek_todolist.Models;

namespace okhunjonov_shoyatbek_todolist
{
    /// <summary>
    /// DbXontext that interacts with Database.
    /// </summary>
    public class ToDoListDbContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options"></param>
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoEntry>()
                .HasOne<ToDoList>(s => s.ToDoList)
                .WithMany(t => t.ToDoEntries)
                .HasForeignKey(s => s.ToDoListId);
        }
        /// <summary>
        /// Table.
        /// </summary>
        public DbSet<ToDoList> ToDoLists { get; set; }
        /// <summary>
        /// Table.
        /// </summary>
        public DbSet<ToDoEntry> ToDoEntries { get; set; }
    }
}
