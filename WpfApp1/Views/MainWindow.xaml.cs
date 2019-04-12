using System;
using System.Windows.Navigation;
using KindleReader.SerializingTools;
using KindleReader.ViewModel;
using System.Windows;
using System.Windows.Input;
using KindleReader.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KindleReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        BookVM bookVM;  
        public MainWindow()
        {
            InitializeComponent();
            bookVM = new BookVM();           
            DataContext = bookVM;
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object sender, EventArgs eventArgs)
        {          
            this.NavigationService.Navigate(new AllBooks(bookVM));
        }
        private void MainWindow_Closed(object sender, EventArgs eventArgs)
        {

            MessageBoxResult result = MessageBox.Show("Do you want to save your changes?", "Please choose: ", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
                AdditionalBookInfoSerializer.AdditionalBookInfosSerialize(bookVM);
            
        }

    }
}
