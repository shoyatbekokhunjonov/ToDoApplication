using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.Models.ViewModels
{
    /// <summary>
    /// This class is used to pass List of ToDoLists to a View.
    /// </summary>
    public class HomeIndexViewModel
    {
        /// <summary>
        /// List of ToDoLists.
        /// </summary>
        public IEnumerable<ToDoList> ToDoLists { get; set; }
    }
}
