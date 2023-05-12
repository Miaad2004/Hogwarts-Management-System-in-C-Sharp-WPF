using Hogwarts.Core.SharedServices;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _ = MainFrame.NavigationService.Navigate(new Uri("LoginView.xaml", UriKind.Relative));
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            StaticServiceProvidor.authenticationService.Logout();
            Application.Current.Shutdown();
        }
    }
}
