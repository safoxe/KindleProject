using KindleReader.Model;
using System.Collections.Generic;

namespace KindleReader.Services
{
    public interface IDataRetriver
    {
        ICollection<IBookInfo> GetAllBooksFromDevice(ICollection<IBookInfo> books);
    }
}
