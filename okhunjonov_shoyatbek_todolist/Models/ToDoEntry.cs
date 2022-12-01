using okhunjonov_shoyatbek_todolist.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace okhunjonov_shoyatbek_todolist.Models
{
    /// <summary>
    /// ToDoEntry model class that represents columns in a database.
    /// </summary>
    public class ToDoEntry
    {
        /// <summary>
        /// ToDoList Id FK.
        /// </summary>
        public int ToDoListId { get; set; }
        /// <summary>
        /// ToDoList value.
        /// </summary>
        public ToDoList ToDoList { get; set; }
        /// <summary>
        /// ToDoEntry unique Id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ToDoEntry title.
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// ToDoEntry Description.
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// ToDoEntry DueDate.
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// ToDoEntry Creation Date which has default assigned value of DateTime.Now.
        /// </summary>
        public DateTime CreationDate { get; } = DateTime.Now;
        /// <summary>
        /// ToDoEntry enum status.
        /// </summary>
        public ToDoEntryStatus ToDoEntryStatus { get; set; }
        /// <summary>
        /// ToDoEntry show/hide enum status.
        /// </summary>
        public ToDoEntryShowHidden ShowStatus { get; set; } = (ToDoEntryShowHidden)1;
        /// <summary>
        /// ToDoEntry additonal field which is by default is assigned to null.
        /// </summary>
        public string AdditionalField { get; set; } = null;
    }
}
