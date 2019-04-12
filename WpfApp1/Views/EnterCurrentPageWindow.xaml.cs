using System;
using System.Windows;
using KindleReader.ViewModel;
namespace KindleReader
{
    /// <summary>
    /// Interaction logic for EnterCurrentPageWindow.xaml
    /// </summary>
    public partial class EnterCurrentPageWindow : Window
    {
        BookVM currentBookVM;
        public EnterCurrentPageWindow(BookVM bookVM)
        {
            InitializeComponent();
            currentBookVM = bookVM;
            currentPageValue.Focus();
        }

        public void saveCurrentPage(object sender, RoutedEventArgs e)
        {
            GetCurrentPage();            
        }
        private void GetCurrentPage()
        {
            
            int currentPage = 0;
            if(Int32.TryParse(currentPageValue.Text, out currentPage))
            {
                if ((currentPage > 0) && (currentPage <= currentBookVM.SelectedBook.NumberOfPages))
                {
                    currentBookVM.SelectedBook.CurrentPage = currentPage;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Number of page is incorrect! Too big or negative.");
                }               
            }          
            else
            {
                MessageBox.Show("Incorrect input");
            }
        }

    }
}
