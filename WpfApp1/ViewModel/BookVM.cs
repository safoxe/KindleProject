using KindleReader.Model;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.ComponentModel;
using KindleReader.Commands;
using System.Windows; 

namespace KindleReader.ViewModel
{
    public class BookVM: INotifyPropertyChanged
    {
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand((obj) =>
                    {
                        string description = obj as string;
                        if (description != null)
                            SelectedBook.Description = description;
                    }, (obj) => { return (Books.Count<0)||(SelectedBook != null); });
                }
                return saveCommand;
            }
        }

        private RelayCommand deleteBookCommand;

        public RelayCommand DeleteBookCommand
        {
            get
            {
                if(deleteBookCommand == null)
                {
                    deleteBookCommand = new RelayCommand(obj =>
                    {
                        AdditionalBookInfo bookInfo = obj as AdditionalBookInfo;
                        if (bookInfo != null)
                        {
                            Books.Remove(bookInfo);
                        }
                    }, obj => (Books.Count < 0) || (SelectedBook != null));
                }
                return deleteBookCommand;
            }
        }
        public ObservableCollection<IBookInfo> Books { get; set; } //ObservalbleCollection has already implemented INotifyPropertyChanged

        private AdditionalBookInfo selectedBook;

        public AdditionalBookInfo SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        public BookVM()
        {
            Books = new ObservableCollection<IBookInfo>()
            {
                new AdditionalBookInfo(){Title="Title1", Author="Author1", NumberOfPages=200},
                new AdditionalBookInfo(){Title="Title2", Author="Author2", NumberOfPages=300}
            };            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
