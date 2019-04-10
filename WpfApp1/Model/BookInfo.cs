using System.ComponentModel;

namespace KindleReader.Model
{

    //will be read from device
    public class BookInfo : IBookInfo, INotifyPropertyChanged
    {
        public string Title { get; private set; }
        public string Author { get; private set; }

        private int numberOfPages;      
        public int NumberOfPages
        {
            get { return numberOfPages; }
            set
            {
                numberOfPages = value;
                OnPropertyChanged("Progress");
            }
        }

        public BookInfo(string title, string author, int numberOfPages)
        {
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
        {
            //if != null -> Invoke
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
