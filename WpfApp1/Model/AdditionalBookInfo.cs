using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindleReader.Model
{
    [Serializable]
    public class AdditionalBookInfo : BookInfo
    {
        private string description;
        private int rate;
        private int currentPage;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public int Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }
        public AdditionalBookInfo(BookInfo book): base(book.Title,book.Author,book.NumberOfPages)
        {
           
        }

    }
}
