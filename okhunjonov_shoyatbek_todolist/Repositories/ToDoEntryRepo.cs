using okhunjonov_shoyatbek_todolist.Enums;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;
using System.Linq;

namespace okhunjonov_shoyatbek_todolist.Repostories
{
    /// <summary>
    /// This is Repository that implements all signature methods of IToDoEntryRepo and interacts with database using DI.
    /// </summary>
    public class ToDoEntryRepo : IToDoEntryRepo
    {
        /// <summary>
        /// Declaration of dbcontext object.
        /// </summary>
        private readonly ToDoListDbContext dbContext;
        /// <summary>
        /// Injecting DI using constructor.
        /// </summary>
        /// <param name="dbContext"></param>
        public ToDoEntryRepo(ToDoListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// This method receives as parameter object of ToDoEntry class and creates it in database and returns.
        /// </summary>
        /// <param name="todoentry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Create(ToDoEntry todoentry)
        {
            dbContext.ToDoEntries.Add(todoentry);
            dbContext.SaveChanges();
            return todoentry;
        }
        /// <summary>
        /// This method gets specific ToDoEntry according to id that is passed as parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Get(int id)
        {
            return dbContext.ToDoEntries.Find(id);
        }
        /// <summary>
        /// This method gets all ToDoEntries from databse that has due date today and returns them as a list.
        /// </summary>
        /// <returns>ToDoEntry</returns>
        public List<ToDoEntry> GetAllEntriesDueToday()
        {
            return dbContext.ToDoEntries.Where(x => x.DueDate == System.DateTime.Today).ToList();
        }
        /// <summary>
        /// This method receives as parameter ToDoEntry class object and updates its values in database and returns.
        /// </summary>
        /// <param name="updatedtodoentry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Update(ToDoEntry updatedtodoentry)
        {
            var todoentry = dbContext.ToDoEntries.Attach(updatedtodoentry);
            todoentry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updatedtodoentry;
        }
        /// <summary>
        /// This method receieves as parameter object of ToDoEntry class and changes enum value from Show to Hidden in database and returns.
        /// </summary>
        /// <param name="hiddenToDoEntry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Hide(ToDoEntry hiddenToDoEntry)
        {
            var todoentry = dbContext.ToDoEntries.Find(hiddenToDoEntry.Id);
            todoentry.ShowStatus = (ToDoEntryShowHidden)0;
            dbContext.SaveChanges();
            return hiddenToDoEntry;
        }
        /// <summary>
        /// This method receieves as parameter object of ToDoEntry class and changes enum value of it from Hidden to Shown and returns.
        /// </summary>
        /// <param name="showToDoEntry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Show(ToDoEntry showToDoEntry)
        {
            var todoentry = dbContext.ToDoEntries.Find(showToDoEntry.Id);
            todoentry.ShowStatus = (ToDoEntryShowHidden)1;
            dbContext.SaveChanges();
            return showToDoEntry;
        }
    }
}
