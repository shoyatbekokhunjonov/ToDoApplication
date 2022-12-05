using Microsoft.EntityFrameworkCore;
using okhunjonov_shoyatbek_todolist;
using okhunjonov_shoyatbek_todolist.Models;
using okhunjonov_shoyatbek_todolist.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace okhunjonov_shoyatbek_todolist_tests
{
    public class ToDoListRepoTests
    {
        private readonly DbContextOptions<ToDoListDbContext> dbContextOptions;

        public ToDoListRepoTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<ToDoListDbContext>()
                .UseInMemoryDatabase("Test_Database2")
                .Options;
            using var _context = new ToDoListDbContext(dbContextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.SaveChanges();
        }

        [Fact]
        public void Delete_DeleteToDoListById()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoListRepo _todoListRepo = new ToDoListRepo(_context);
            _context.ToDoLists.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            IEnumerable<ToDoList> toDoLists = _todoListRepo.GetAll();
            var item1 = _todoListRepo.Get(1);
            _todoListRepo.Delete(item1.Id);

            // Assert
            Assert.Equal(1, toDoLists.Count());
        }

        [Fact]
        public void Get_GetToDoListById()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoListRepo _todoListRepo = new ToDoListRepo(_context);
            _context.ToDoLists.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var item2 = _todoListRepo.Get(2);

            // Assert
            Assert.Equal(item2.Name, "School");
        }

        [Fact]
        public void GetAll_GetAllToDoLists()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoListRepo _todoListRepo = new ToDoListRepo(_context);
            _context.ToDoLists.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            IEnumerable<ToDoList> toDoLists = _todoListRepo.GetAll();

            // Arrange
            Assert.Equal(toDoLists.Count(), 2);
        }

        [Fact]
        public void Update_UpdateToDoListById()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoListRepo _todoListRepo = new ToDoListRepo(_context);
            _context.ToDoLists.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var item3 = _todoListRepo.Get(1);
            item3.Name = "ProgSchool";

            // Assert
            Assert.Equal(item3.Name, "ProgSchool");
        }

        [Fact]
        public void Create_CreateToDoList()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoListRepo _todoListRepo = new ToDoListRepo(_context);
            _context.ToDoLists.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var newToDoList = new ToDoList()
            {
                Id = 4,
                Name = "Test1",
                ToDoEntries = new List<ToDoEntry>()
                {
                    new ToDoEntry()
                    {
                        Id = 1,
                        Title = "Title",
                        Description = "Description"
                    }
                }
            };

            // Assert
            Assert.NotEqual(0, newToDoList.Id);
        }

        [Fact]
        public void Hide_HideToDoListById()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoListRepo _todoListRepo = new ToDoListRepo(_context);
            _context.ToDoLists.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var itemTest1 = _todoListRepo.Get(1);
            itemTest1.ToDoListShow = okhunjonov_shoyatbek_todolist.Enums.ToDoListShowHidden.Hidden;

            // Assert
            Assert.Equal(itemTest1.ToDoListShow, okhunjonov_shoyatbek_todolist.Enums.ToDoListShowHidden.Hidden);
        }

        [Fact]
        public void Show_ShowToDoListById()
        {
            // Arrange
            ToDoListDbContext _context = new ToDoListDbContext(dbContextOptions);
            ToDoListRepo _todoListRepo = new ToDoListRepo(_context);
            _context.ToDoLists.AddRange(GetSeedData());
            _context.SaveChanges();

            // Act
            var itemTest1 = _todoListRepo.Get(2);
            itemTest1.ToDoListShow = okhunjonov_shoyatbek_todolist.Enums.ToDoListShowHidden.Show;

            // Assert
            Assert.Equal(itemTest1.ToDoListShow, okhunjonov_shoyatbek_todolist.Enums.ToDoListShowHidden.Show);
        }

        // Data seed.

        public List<ToDoList> GetSeedData()
        {
            return new List<ToDoList>()
           {
               new ToDoList()
               {
                   Id = 1,
                   Name = "University",
                   ToDoListShow = okhunjonov_shoyatbek_todolist.Enums.ToDoListShowHidden.Show,
                   ToDoEntries = new List<ToDoEntry>()
                   {
                       new ToDoEntry()
                       {
                           Id = 7,
                           Title = "Lesson1",
                           Description = "Complete lesson1"
                       },
                       new ToDoEntry()
                       {
                           Id = 8,
                           Title = "Lesson2",
                           Description = "Complete lesson2"
                       }
                   }
               },
               new ToDoList()
               {
                   Id = 2,
                   Name = "School",
                   ToDoListShow = okhunjonov_shoyatbek_todolist.Enums.ToDoListShowHidden.Hidden,
                   ToDoEntries = new List<ToDoEntry>()
                   {
                       new ToDoEntry()
                       {
                           Id = 9,
                           Title = "Lesson3",
                           Description = "Complete lesson3"
                       },
                       new ToDoEntry()
                       {
                           Id = 10,
                           Title = "Lesson4",
                           Description = "Complete lesson4"
                       }
                   }
               }
           }; 
        }
    }
}
