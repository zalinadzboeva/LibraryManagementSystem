using Library.Db.Models;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Helpers
{
    public static class Mapping
    {
        public static BookViewModel ToBookViewModel(Book book)
        {
            return new BookViewModel()
            {
                BookId = book.BookId,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                IsAvailable = book.IsAvailable,
            };
        }
        public static Book ToBook(BookViewModel bookViewModel)
        {
            return new Book()
            {
                BookId = bookViewModel.BookId,
                Author = bookViewModel.Author,
                Title = bookViewModel.Title,
                Description = bookViewModel.Description,
                IsAvailable = bookViewModel.IsAvailable,
            };
        }
        public static List<BookViewModel> ToBookViewModels(List<Book> books)
        {
            return books.Select(ToBookViewModel).ToList();
        }

    }
}
