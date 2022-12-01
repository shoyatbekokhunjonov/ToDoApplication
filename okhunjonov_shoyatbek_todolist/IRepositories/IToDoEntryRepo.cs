using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.IRepositories
{
    /// <summary>
    /// ToDoEntry Repository Interface that has methods signatures.
    /// </summary>
    public interface IToDoEntryRepo
    {
        /// <summary>
        /// This method is a signature of method that creates ToDoEntry.
        /// </summary>
        /// <param name="todoentry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Create(ToDoEntry todoentry);
        /// <summary>
        /// This method is a signature of method that takes one ToDoEntry according to given Id and returns.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Get(int id);
        /// <summary>
        /// This is a signature of a method that gets all ToDoEntries that has DateTime value equlas to today of system and returns them as a list.
        /// </summary>
        /// <returns>List ToDoEntry</returns>
        public List<ToDoEntry> GetAllEntriesDueToday();
        /// <summary>
        /// This is a signature of a method that Updates values of given ToDoEntry and returns.
        /// </summary>
        /// <param name="updatedtodoentry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Update(ToDoEntry updatedtodoentry);
        /// <summary>
        /// This is a signature of a method that changes enum value of given ToDoEntryt to Hide and returns.
        /// </summary>
        /// <param name="hiddenToDoEntry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Hide(ToDoEntry hiddenToDoEntry);
        /// <summary>
        /// This is a signature of a method that changes enum value of given ToDoEntry to Show and returns.
        /// </summary>
        /// <param name="showToDoEntry"></param>
        /// <returns>ToDoEntry</returns>
        public ToDoEntry Show(ToDoEntry showToDoEntry);
    }

}
