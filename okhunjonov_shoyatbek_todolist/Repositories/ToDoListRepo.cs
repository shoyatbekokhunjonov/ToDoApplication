using Microsoft.EntityFrameworkCore;
using okhunjonov_shoyatbek_todolist;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;
using System.Linq;

namespace okhunjonov_shoyatbek_todolist.Repostories
{
    public class ToDoListRepo : IToDoListRepo
    {
        private readonly ToDoListDbContext dbContext;
        public ToDoListRepo(ToDoListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ToDoList Delete(int id)
        {
            var toDoList = dbContext.ToDoLists.Find(id);
            if(toDoList != null)
            {
                dbContext.ToDoLists.Remove(toDoList);
                dbContext.SaveChanges();
            }
            return toDoList;
        }

        public ToDoList Get(int id)
        {
            return dbContext.ToDoLists.Include(s => s.ToDoEntries).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<ToDoList> GetAll()
        {
            return dbContext.ToDoLists.Include(x => x.ToDoEntries);
        }
        
        public ToDoList Update(ToDoList updatedtodolist)
        {
            var toDoList = dbContext.ToDoLists.Attach(updatedtodolist);     
            toDoList.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updatedtodolist;
        }

        public ToDoList Create(ToDoList todolist)
        {
            dbContext.ToDoLists.Add(todolist);
            dbContext.SaveChanges();
            return todolist;
        }
    }
}
