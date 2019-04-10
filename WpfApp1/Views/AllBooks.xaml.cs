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

        private void RatePanel_MouseEnter(object sender, MouseEventArgs e)
        {
            int bookRate = 0;

            if (allBooks.SelectedItems.Count != 0)
            {
                RatePanel.Cursor = Cursors.Hand;
                foreach (ToggleButton toggleButton in LogicalTreeHelper.GetChildren(RatePanel))
                {
                    if (toggleButton.IsChecked == true)
                        bookRate += 1;
                }
                bookVM.SelectedBook.Rate = bookRate;
            }
            else
            {
                RatePanel.IsEnabled = false;
            }

        }
    }
}
