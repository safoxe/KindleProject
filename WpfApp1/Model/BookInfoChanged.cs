using System.ComponentModel;

namespace KindleReader.Model
{

    //will be read from device
    public class BookInfoChanged : INotifyPropertyChanged
    {
     //for all clasees which are inherited from this class and need implementation of INotifyPropertyChanged 
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
        {
            //if != null -> Invoke
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
