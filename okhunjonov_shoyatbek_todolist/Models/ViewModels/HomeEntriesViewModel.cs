using okhunjonov_shoyatbek_todolist.Enums;
using System;

namespace okhunjonov_shoyatbek_todolist.Models.ViewModels
{
    public class HomeEntriesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string AdditionalField { get; set; }
        public ToDoEntryStatus EntryStatus { get; set; }
    }
}
