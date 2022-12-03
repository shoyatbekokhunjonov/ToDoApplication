using Microsoft.EntityFrameworkCore;
using okhunjonov_shoyatbek_todolist;
using okhunjonov_shoyatbek_todolist.IRepositories;
using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;
using System.Linq;

namespace okhunjonov_shoyatbek_todolist.Repostories
{
    /// <summary>
    /// This is class that inherits from IToDoListRepo interface and implements all signature methods of it.
    /// </summary>
    public class ToDoListRepo : IToDoListRepo
    {
        private readonly ToDoListDbContext dbContext;
        /// <summary>
        /// Injecting DI using constructor.
        /// </summary>
        /// <param name="dbContext"></param>
        public ToDoListRepo(ToDoListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// This method firs assigns specific ToDoEntry according to passed id and if it is not null finds it from database and deletes, at the end returns.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ToDoList</returns>
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
        /// <summary>
        /// This method gets specific ToDoList according to given Id and returns.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ToDoList</returns>
        public ToDoList Get(int id)
        {
            return dbContext.ToDoLists.Include(s => s.ToDoEntries).Where(x => x.Id == id).FirstOrDefault();
        }
        /// <summary>
        /// This method gets all ToDoLists and return them as a list.
        /// </summary>
        /// <returns>IEnumerableToDoList</returns>
        public IEnumerable<ToDoList> GetAll()
        {
            return dbContext.ToDoLists.Include(x => x.ToDoEntries);
        }
        /// <summary>
        /// This method receives as parameter ToDoList and updates its values and returns
        /// </summary>
        /// <param name="updatedtodolist"></param>
        /// <returns>ToDoList</returns>
        public ToDoList Update(ToDoList updatedtodolist)
        {
            var toDoList = dbContext.ToDoLists.Attach(updatedtodolist);     
            toDoList.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updatedtodolist;
        }
        /// <summary>
        /// This method receives as a parameter ToDoList and adds it to database and returns.
        /// </summary>
        /// <param name="todolist"></param>
        /// <returns></returns>
        public ToDoList Create(ToDoList todolist)
        {
            dbContext.ToDoLists.Add(todolist);
            dbContext.SaveChanges();
            return todolist;
        }
        /// <summary>
        /// This method receives as a parameter ToDoList and changes its enum status from show to hide and returns.
        /// </summary>
        /// <param name="toDoList"></param>
        /// <returns></returns>
        public ToDoList Hide(ToDoList toDoList)
        {
            var todolist = dbContext.ToDoLists.Find(toDoList.Id);
            todolist.ToDoListShow = Enums.ToDoListShowHidden.Hidden;
            dbContext.SaveChanges();
            return toDoList;
        }
        /// <summary>
        /// This method receives as parameter ToDoList and changes its enum status from hidden to show and returns.
        /// </summary>
        /// <param name="toDoList"></param>
        /// <returns></returns>
        public ToDoList Show(ToDoList toDoList)
        {
            var todolist = dbContext.ToDoLists.Find(toDoList.Id);
            todolist.ToDoListShow = Enums.ToDoListShowHidden.Show;
            dbContext.SaveChanges();
            return toDoList;
        }
    }
}

