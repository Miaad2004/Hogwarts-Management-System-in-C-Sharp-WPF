using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.SharedServices;
using System;
using System.Security.Authentication;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Hogwarts.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        // Dependencies
        private readonly IAuthenticationService _authenticationService;

        public LoginView()
        {
            InitializeComponent();
            _authenticationService = StaticServiceProvidor.authenticationService;
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _authenticationService.Login(txtUsername.Text, txtPassword.Password);
                _ = MessageBox.Show("Logged in Successfully",
                                "Login Successful",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                switch (SessionManager.CurrentSession.User.AccessLevel)
                {
                    case AccessLevels.Admin:
                        _ = NavigationService.Navigate(new Uri("/AdminViews/MainView.xaml", UriKind.Relative));
                        break;

                    case AccessLevels.Professor:
                        _ = NavigationService.Navigate(new Uri("/ProfessorViews/MainView.xaml", UriKind.Relative));
                        break;

                    case AccessLevels.Student:
                        _ = NavigationService.Navigate(new Uri("/StudentViews/MainView.xaml", UriKind.Relative));
                        break;
                }
            }
            catch (InvalidCredentialException ex)
            {
                _ = MessageBox.Show(ex.Message, "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                _ = MessageBox.Show(ex.Message, "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Signup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("/SignupView.xaml", UriKind.Relative));
        }
    }
}
