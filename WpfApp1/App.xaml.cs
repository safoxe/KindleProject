using System;
using System.Windows;
using KindleReader.Services;
using KindleReader.SerializingTools;

namespace KindleReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       public void OnApplicationStartUp(object sender, EventArgs eventArgs)
       {
            var connectedDevices = ConnectedDevices.Instanse;

            if(connectedDevices.HasConnectedKindle() == true)//change to false, if you`re connecting Kindle
            {
                ErrorConnection errorConnectionWindow = new ErrorConnection();
                errorConnectionWindow.Show();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();                
                mainWindow.Show();                
            }
       }
    }
    
}
