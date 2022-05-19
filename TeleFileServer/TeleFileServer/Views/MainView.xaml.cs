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
using TeleFileServer.Services;

namespace TeleFileServer.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            if (PublicStaticCode.Jurisdiction!=1)
            {
                btnAccount.IsEnabled = false;
            }
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            btnAccount.Background = Brushes.White;
            btnOrder.Background = Brushes.WhiteSmoke;
            btnBroadcast.Background = Brushes.WhiteSmoke;
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            btnOrder.Background = Brushes.White;
            btnAccount.Background = Brushes.WhiteSmoke;
            btnBroadcast.Background = Brushes.WhiteSmoke;
        }

        private void btnBroadcast_Click(object sender, RoutedEventArgs e)
        {
            btnBroadcast.Background = Brushes.White;
            btnAccount.Background = Brushes.WhiteSmoke;
            btnOrder.Background = Brushes.WhiteSmoke;
        }
    }
}
