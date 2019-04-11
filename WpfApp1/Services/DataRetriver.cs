using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KindleReader.Factories;
using KindleReader.Model;

namespace KindleReader.Services
{
    public class DataRetriver:IDataRetriver
    {
        //maybe it`s reasonable to make this class static and use only functionality, but there is fields

        private ICollection<IBookInfo> books;
        private IBookInfo book;

        public ICollection<IBookInfo> GetAllBooksFromDevice(ICollection<IBookInfo> books)
        {
            this.books = books;
            RetriveBookData();
            return books;
        }


        //there, I suppose, I need dependency injection. It must get IBookInfo as a parameter (?)
        private void RetriveBookData()
        {
            book = BookInfoFactory.GetAdditionalBookInfoObject();
            book.Title = "Title1";
            book.Author = "Author1";
            book.NumberOfPages = 300;
            books.Add(book);
            
            
        }
    }
}
