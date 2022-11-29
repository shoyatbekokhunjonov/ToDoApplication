using okhunjonov_shoyatbek_todolist.Enums;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;
using System.Linq;

namespace okhunjonov_shoyatbek_todolist.Repostories
{
    public class ToDoEntryRepo : IToDoEntryRepo
    {
        private ToDoListDbContext dbContext;
        public ToDoEntryRepo(ToDoListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ToDoEntry Create(ToDoEntry todoentry)
        {
            dbContext.ToDoEntries.Add(todoentry);
            dbContext.SaveChanges();
            return todoentry;
        }

        public ToDoEntry Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public ToDoEntry Get(int id)
        {
            return dbContext.ToDoEntries.Find(id);
        }

        public List<ToDoEntry> GetAllEntriesDueToday()
        {
            return dbContext.ToDoEntries.Where(x => x.DueDate == System.DateTime.Today).ToList();
        }

        public ToDoEntry Update(ToDoEntry updatedtodoentry)
        {
            var todoentry = dbContext.ToDoEntries.Attach(updatedtodoentry);
            todoentry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updatedtodoentry;
        }

        public ToDoEntry Hide(ToDoEntry hiddenToDoEntry)
        {
            var todoentry = dbContext.ToDoEntries.Find(hiddenToDoEntry.Id);
            todoentry.ShowStatus = (ToDoEntryShowHidden)0;
            dbContext.SaveChanges();
            return hiddenToDoEntry;
        }

        public ToDoEntry Show(ToDoEntry showToDoEntry)
        {
            var todoentry = dbContext.ToDoEntries.Find(showToDoEntry.Id);
            todoentry.ShowStatus = (ToDoEntryShowHidden)1;
            dbContext.SaveChanges();
            return showToDoEntry;
        }
    }
}
