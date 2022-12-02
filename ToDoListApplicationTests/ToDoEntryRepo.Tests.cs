using Microsoft.EntityFrameworkCore;
using okhunjonov_shoyatbek_todolist;
using okhunjonov_shoyatbek_todolist.Models;
using System.Threading.Tasks;
using Xunit;

namespace ToDoListApplicationTests
{
    public class ToDoEntryRepo
    {
        private readonly DbContextOptions<ToDoListDbContext> dbContextOptions;

        public ToDoEntryRepo()
        {
            dbContextOptions = new DbContextOptionsBuilder<ToDoListDbContext>()
                .UseInMemoryDatabase("Test_Database")
                .Options;
        }

    }
}
