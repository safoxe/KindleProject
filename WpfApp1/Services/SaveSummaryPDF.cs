using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KindleReader.Model;

namespace KindleReader.Services
{
    public class SaveSummaryPDF : ISaveSummary
    {
        private IBookInfo bookInfo;

        public SaveSummaryPDF(IBookInfo bookInfo)
        {
            this.bookInfo = bookInfo;
        }
        public void SaveSummary()
        {
            using (StreamWriter streamWriter = new StreamWriter(@"d:/summary.pdf"))
            {
                streamWriter.WriteLine(bookInfo.Author);
            }
            
        }

       
    }
}
