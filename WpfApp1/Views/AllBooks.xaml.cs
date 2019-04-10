using System.Windows;
using System.Windows.Controls;
using KindleReader.ViewModel;
using System;
using KindleReader.SerializingTools;
using System.Windows.Input;
using KindleReader.Commands;
using KindleReader.Model;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace KindleReader
{
    /// <summary>
    /// Interaction logic for AllBooks.xaml
    /// </summary>
    public partial class AllBooks : Page
    {
        BookVM bookVM;
        public AllBooks(BookVM bookVM_arg)
        {
            bookVM = new BookVM();
            InitializeComponent();
            bookVM = bookVM_arg;
            DataContext = bookVM;
        }

        private void enterCurrentPage(object sender, RoutedEventArgs e)
        {
            if (allBooks.SelectedItems.Count != 0)
            {
                EnterCurrentPageWindow enterCurrentPageWindow = new EnterCurrentPageWindow(bookVM);
                enterCurrentPageWindow.Show();              
            }
            else
            {
                MessageBox.Show("Choose a book!");
            }
        }
       
        private void SelectedNewRate(object sender, RoutedEventArgs e)
        {
            ListBox ratePanel = sender as ListBox;
            int rate = ratePanel.SelectedIndex;
            if (allBooks.SelectedItem == null)
            {
                MessageBox.Show("Choose a book!");
            }
            else
            {
                for (int i = 0; i < ratePanel.Items.Count; i++)
                {
                    ToggleButton rates = ratePanel.Items[i] as ToggleButton;
                    if (i <= rate)
                    {

                        rates.IsChecked = true;
                    }
                    else
                        rates.IsChecked = false;
                }
                if (allBooks.SelectedItem != null)
                    bookVM.SelectedBook.Rate = rate + 1;
            }
        }
    }
}
