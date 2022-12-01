using okhunjonov_shoyatbek_todolist.Enums;
using System;

namespace okhunjonov_shoyatbek_todolist.Models.ViewModels
{
    /// <summary>
    /// This ViewModel class is used to show and edit ToDoEntry.
    /// </summary>
    public class HomeEntriesViewModel
    {
        /// <summary>
        /// /Id value of ToDoEntry class that is used to pass into View.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title of ToDoEntry ViewModel class that is used to pass into View.
        /// </summary>
        public string Title { get; set; }    
        /// <summary>
        /// Description of ToDoEntry tht is used to pass into View.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// DueDate value of ToDoEntry that is used to pass into View.
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// CreationDate value of ToDoEntry that is used to pass into View.
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Additionalfield value that is used to pass into View.
        /// </summary>
        public string AdditionalField { get; set; }
        /// <summary>
        /// Enum status of ToDoEntry that is used to give into View.
        /// </summary>
        public ToDoEntryStatus EntryStatus { get; set; }
    }
}
