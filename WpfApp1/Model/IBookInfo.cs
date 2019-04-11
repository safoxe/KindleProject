using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindleReader.Model
{
    public interface IBookInfo
    {
        string Title { get; set; }
        string Author { get; set; }
        int NumberOfPages { get; set; }

    }
}
