using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Hogwarts.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        private readonly IAuthenticationService authenticationService;

        public MainView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();

            string profileImagePath = SessionManager.CurrentSession?.User.FullProfileImagePath ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));
            brushProfileImage.ImageSource = new BitmapImage(new Uri(profileImagePath));
        }

        private void NavigationBar_Click(object sender, RoutedEventArgs e)
        {
            string targetPage = (sender as Button)?.Tag.ToString() ?? throw new NullReferenceException();
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
                authenticationService.Logout();
                NavigationService.Navigate(new Uri("/LoginView.xaml", UriKind.Relative));
            }
        }
    }
}
