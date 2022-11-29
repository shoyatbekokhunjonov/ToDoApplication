using okhunjonov_shoyatbek_todolist.Enums;
using System;
using System.Collections.Generic;

namespace okhunjonov_shoyatbek_todolist.Models
{
    public class ToDoEntry
    {
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now;
        public ToDoEntryStatus ToDoEntryStatus { get; set; }
        public ToDoEntryShowHidden ShowStatus { get; set; } = (ToDoEntryShowHidden)1;

        public string AdditionalField { get; set; } = null;

        public static implicit operator List<object>(ToDoEntry v)
        {
            throw new NotImplementedException();
        }
    }
}
