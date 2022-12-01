using okhunjonov_shoyatbek_todolist.Enums;
using okhunjonov_shoyatbek_todolist.Models;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.Models.ViewModels
{
    /// <summary>
    /// View that is used for ToDoEntry with along List of ToDoEntries property.
    /// </summary>
    public class HomeDetailsViewModel
    {
        /// <summary>
        /// ToDoList Id value.
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// ToDoList value.
        /// </summary>
        public ToDoList ToDoList { get; set; }  
        /// <summary>
        /// List of ToDoEntries property.
        /// </summary>
        public List<ToDoEntry> ToDoEntries { get; set; }
    }
}
