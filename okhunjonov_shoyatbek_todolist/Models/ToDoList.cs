using okhunjonov_shoyatbek_todolist.Enums;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public List<ToDoEntry> ToDoEntries { get; set; }
        public ToDoListShowHidden ToDoListShow { get; set; } = (ToDoListShowHidden)1;
    }
}
