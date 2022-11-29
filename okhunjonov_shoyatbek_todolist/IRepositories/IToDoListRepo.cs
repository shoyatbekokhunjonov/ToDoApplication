using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.IRepositories
{
    public interface IToDoListRepo
    {
        ToDoList Create(ToDoList todolist);
        IEnumerable<ToDoList> GetAll();
        ToDoList Get(int id);
        ToDoList Update(ToDoList updatedtodolist);
        ToDoList Delete(int id);
    }
}
