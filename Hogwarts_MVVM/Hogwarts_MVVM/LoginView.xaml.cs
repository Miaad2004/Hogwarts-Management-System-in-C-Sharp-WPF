using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IAuthenticationService authenticationService;

        public LoginView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();

        }

        private void BackgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            backgroundVideo.Position = TimeSpan.FromSeconds(9.04);
            backgroundVideo.Play();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await authenticationService.LoginAsync(txtUsername.Text, txtPassword.Password);
                MessageBox.Show("Logged in Successfully",
                                "Login Successful",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                var currentSession = SessionManager.CurrentSession ?? throw new ArgumentException(nameof(SessionManager.CurrentSession));

                switch (currentSession.User.AccessLevel)
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
