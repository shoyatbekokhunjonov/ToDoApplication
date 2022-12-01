using okhunjonov_shoyatbek_todolist.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace okhunjonov_shoyatbek_todolist.Models
{
    /// <summary>
    /// ToDoList model class that represents columns in a database.
    /// </summary>
    public class ToDoList
    {
        /// <summary>
        /// ToDoList unique Id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ToDoList Name.
        /// </summary>
        [Required]
        public string Name { get; set; } 
        /// <summary>
        /// ToDoList property that is list of ToDoEntries.
        /// </summary>
        public List<ToDoEntry> ToDoEntries { get; set; }
        /// <summary>
        /// ToDoListShowHidden enum property of ToDoList.
        /// </summary>
        public ToDoListShowHidden ToDoListShow { get; set; } = (ToDoListShowHidden)1;
    }
}
