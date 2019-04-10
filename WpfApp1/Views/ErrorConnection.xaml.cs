using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KindleReader
{
    /// <summary>
    /// Interaction logic for ErrorConnection.xaml
    /// </summary>
    public partial class ErrorConnection : Window
    {
        public ErrorConnection()
        {
            InitializeComponent();
        }

        private void detailsErrorMessage_Click(object sender, RoutedEventArgs e)
        {
            ErrorDetails errorDetails = new ErrorDetails();
            errorDetails.Show();
            
        }
        private void closeErrorMessage_Click(object sender, RoutedEventArgs e)
        {        
            this.Close();
        }
    }
}
