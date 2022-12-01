using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.IRepositories
{
    /// <summary>
    /// ToDoList Repository Interface that has methods signatures.
    /// </summary>
    public interface IToDoListRepo
    {
        /// <summary>
        /// This is a signature of a method that creates ToDoList by given values and returns.
        /// </summary>
        /// <param name="todolist"></param>
        /// <returns>ToDoList</returns>
        ToDoList Create(ToDoList todolist);
        /// <summary>
        /// This is a signature of a method that gets all ToDoLists and returns as IEnumerable.
        /// </summary>
        /// <returns>IEnumerable ToDoList</returns>
        IEnumerable<ToDoList> GetAll();
        /// <summary>
        /// This is a signature of a method that gets ToDoList by given id and returns.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ToDoList</returns>
        ToDoList Get(int id);
        /// <summary>
        /// This is a signature of a method that updates values of given ToDoList and returns.
        /// </summary>
        /// <param name="updatedtodolist"></param>
        /// <returns>ToDoList</returns>
        ToDoList Update(ToDoList updatedtodolist);
        /// <summary>
        /// This is a signature of a method that deletes ToDoList given by Id and returns.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ToDoList</returns>
        ToDoList Delete(int id);
    }
}
