using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ToDoList> ToDoLists { get; set; }
    }
}
