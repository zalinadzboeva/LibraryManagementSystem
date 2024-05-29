using Library.Db.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Db
{
    public class BookDbRepository
    {
        private readonly DatabaseContext databaseContext;

        public BookDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void AddBook(Book book)
        {
            databaseContext.Books.Add(book);
            databaseContext.SaveChanges();// сохраняет изменения 
        }
         public List<Book> GetAllBooks()
        {
            return databaseContext.Books.ToList();
        }

        public Book TryGetById(int id)
        {
            foreach (Book book in databaseContext.Books)
            {
                if (book.BookId == id)
                    return book;
            }
            return null;
        }
    }
}
