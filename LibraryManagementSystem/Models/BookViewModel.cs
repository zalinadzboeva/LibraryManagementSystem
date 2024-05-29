using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;

namespace LibraryManagementSystem.Models
{
    public class BookViewModel
    {
        private static int counter = 0;
        public  int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }

        //public BookViewModel() {
        //    BookId = counter;
        //    counter++;
        //}

        ////public BookViewModel(string title, string description, string author, bool isAvailable)
        ////{
        ////    Title = title;
        ////    Description = description;
        ////    Author = author;
        ////    IsAvailable = isAvailable;
        ////    BookId = counter;
        ////    counter++;

        ////}
    }
}
