using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.SharedServices;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hogwarts.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
            string profileImagePath = SessionManager.CurrentSession.User.FullProfileImagePath;
            brushProfileImage.ImageSource = new BitmapImage(new Uri(profileImagePath));
        }

        private void NavigationBar_Click(object sender, RoutedEventArgs e)
        {
            string targetPage = (sender as Button).Tag.ToString();
            pageFrame.Source = new Uri(targetPage, UriKind.Relative);
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmation = MessageBox.Show("Are you sure you want to log out?",
                                                            caption: "Logout Confirmation",
                                                            button: MessageBoxButton.YesNo,
                                                            icon: MessageBoxImage.Question,
                                                            defaultResult: MessageBoxResult.No);
            if (confirmation == MessageBoxResult.Yes)
            {
                StaticServiceProvidor.authenticationService.Logout();
                _ = NavigationService.Navigate(new Uri("/LoginView.xaml", UriKind.Relative));
            }

        }
    }
}
