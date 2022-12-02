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

        [Fact]
        public Task ToDoEntryCreate()
        {
            // Arrange.
            var toDoEntryContext = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo toDoEntryRepo = new ToDoEntryRepo(dbContextOptions);
            var newToDoEntry = new ToDoEntry()
            {
                Id = 1,
                Title = "Swimming",
                Description = "Going to the pool",
                DueDate = System.DateTime.Today.AddDays(1),
                ToDoEntryStatus = okhunjonov_shoyatbek_todolist.Enums.ToDoEntryStatus.NotStarted,
                ShowStatus = okhunjonov_shoyatbek_todolist.Enums.ToDoEntryShowHidden.Show
            };

            // Act.
            ToDoEntryRepo.Create
        }
    }
}
