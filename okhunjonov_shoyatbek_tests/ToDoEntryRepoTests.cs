using Microsoft.EntityFrameworkCore;
using okhunjonov_shoyatbek_todolist;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Models;
using okhunjonov_shoyatbek_todolist.Repostories;
using System;
using System.Collections.Generic;
using Xunit;

namespace okhunjonov_shoyatbek_tests
{
    public class ToDoEntryRepoTests
    {
        private readonly DbContextOptions<ToDoListDbContext> dbContextOptions;

        public ToDoEntryRepoTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<ToDoListDbContext>()
                .UseInMemoryDatabase("Test_Database")
                .Options;
            using var _context = new ToDoListDbContext(dbContextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.SaveChanges();
        }

        [Fact]
        public void Create_NewEntryWithNoParentList_ShouldAddItemToDbWithId()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);
            var item = new ToDoEntry
            {
                Title = "new item",
                Description = "desc"
            };

            // Act
            _todoEntryRepo.Create(item);

            // Act
            Assert.NotEqual(0, item.Id);
        }

        [Theory]
        [InlineData(null, "description")]
        [InlineData("title", null)]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("    ", "    ")]
        public void Create_AddEntryWithNoName_ShouldFailAndThrowExceptionWithCorrectMessage(string? _title, string? _description) // or whatever you make to do after it i dont know ;d
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);

            var item = new ToDoEntry
            {
                Title = _title,
                Description = _description
            };

            //Act
            var caughtException = Assert.Throws<Exception>(() => _todoEntryRepo.Create(item));

            //Assert
            Assert.Equal("Title and description canot be null!", caughtException.Message);
            Assert.Equal(0, item.Id);
        }

        [Fact]
        public void Create_AddTwoToDoEntries_ShouldNotFail()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);

            // Act
            var item1 = new ToDoEntry
            {
                Title = "item1",
                Description = "item1"
            };

            var item2 = new ToDoEntry
            {
                Title = "item2",
                Description = "item2"
            };

            _todoEntryRepo.Create(item1);
            _todoEntryRepo.Create(item2);

            // Assert
            Assert.True(item1.Id != 0 && item2.Id != 0);
            Assert.NotSame(item1, item2);
            Assert.True(item1.Id != item2.Id);
        }

        [Fact]
        public void Get_GetToDoEntryWithId_ShouldReturnSpecificToDoEntry()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);
            _context.ToDoEntries.AddRange(GetSeedData());
            _context.SaveChanges();

            //Act
            var item1 = _todoEntryRepo.Get(1);

            // Assert

            Assert.Equal(item1.Description, "Chemistry lesson");

        }

        [Fact]
        public void GetAllEntriesThatAreDueToday_GetAllEntriesWithDateSetToToday()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);
            _context.ToDoEntries.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            List<ToDoEntry> toDoEntriesToday = _todoEntryRepo.GetAllEntriesDueToday();

            // Assert

            Assert.Equal(2, toDoEntriesToday.Count);
        }
        [Fact]
        public void Update_UpdateSpecificToDoEntry()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);
            _context.ToDoEntries.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var item1 = _todoEntryRepo.Get(1);
            item1.Title = "Changed";

            // Assert
            Assert.Equal(item1.Title, "Changed");
        }
        [Fact]
        public void Hide_ChangeEnumFromShowToHide()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);
            _context.ToDoEntries.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var item1 = _todoEntryRepo.Get(1);
            item1.ShowStatus = okhunjonov_shoyatbek_todolist.Enums.ToDoEntryShowHidden.Hidden;

            // Assert
            Assert.Equal(item1.ShowStatus, okhunjonov_shoyatbek_todolist.Enums.ToDoEntryShowHidden.Hidden);
        }
        [Fact]
        public void Show_ChangeEnumFromHideToShow()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoEntryRepo _todoEntryRepo = new ToDoEntryRepo(_context);
            _context.ToDoEntries.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var item1 = _todoEntryRepo.Get(1);
            item1.ShowStatus = okhunjonov_shoyatbek_todolist.Enums.ToDoEntryShowHidden.Show;

            // Assert
            Assert.Equal(item1.ShowStatus, okhunjonov_shoyatbek_todolist.Enums.ToDoEntryShowHidden.Show);
        }
        // Data seed
        public List<ToDoEntry> GetSeedData()
        {
            return new List<ToDoEntry>()
            {
                new ToDoEntry() { Id = 1, Title = "Lessons", Description = "Chemistry lesson", DueDate = new DateTime(2022, 12, 4), ShowStatus = okhunjonov_shoyatbek_todolist.Enums.ToDoEntryShowHidden.Show},
                new ToDoEntry() { Id = 2, Title = "Lessons", Description = "Math lesson", DueDate = new DateTime(2022, 12, 4)},
                new ToDoEntry() { Id = 3, Title = "Lessons", Description = "Physics lesson" },
                new ToDoEntry() { Id = 4, Title = "Lessons", Description = "English lesson" },
            };
        }

   
    }
}

