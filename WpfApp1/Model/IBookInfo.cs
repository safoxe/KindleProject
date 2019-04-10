using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindleReader.Model
{
    public interface IBookInfo
    {
        string Title { get;}
        string Author { get;}
        int NumberOfPages { get; set; }

    }
}
