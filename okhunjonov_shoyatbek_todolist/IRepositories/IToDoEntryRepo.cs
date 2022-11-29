using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.IRepositories
{
    public interface IToDoEntryRepo
    {
        public ToDoEntry Create(ToDoEntry todoentry);
        public ToDoEntry Get(int id);
        public List<ToDoEntry> GetAllEntriesDueToday();
        public ToDoEntry Update(ToDoEntry updatedtodoentry);
        public ToDoEntry Delete(int id);
        public ToDoEntry Hide(ToDoEntry hiddenToDoEntry);
        public ToDoEntry Show(ToDoEntry showToDoEntry);
    }

}
