using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LogonVistaOrb
{
    //Simple dummy Window that helps start the program to ensure LogonVistaOrb does not get stopped by Windows services
    public partial class Window1 : Window
    {
        public Window1()
        {
            //InitializeComponent();
            this.Width = 10;
            this.Height = 10;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Visibility = Visibility.Hidden;
        }

        private void FinishedInit(object sender, RoutedEventArgs e)
        {
            // Close the dummy window after it's loaded
            Debug.Print("Core initialized");
            this.Close();
        }
    }
}
