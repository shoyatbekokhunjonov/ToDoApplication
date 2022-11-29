using okhunjonov_shoyatbek_todolist.Enums;
using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.Models.ViewModels
{
    public class HomeDetailsViewModel
    {
        public int Id { get; set; } 
        public ToDoList ToDoList { get; set; }  
        public List<ToDoEntry> ToDoEntries { get; set; }
    }
}
