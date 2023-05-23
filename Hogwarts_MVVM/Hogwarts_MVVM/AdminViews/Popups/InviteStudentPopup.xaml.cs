using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.TrainManagement.Exceptions;
using Hogwarts.Core.SharedServices.Exceptions;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for InviteStudent.xaml
    /// </summary>
    public partial class InviteStudentPopup : Window, IPopup
    {
        private readonly IAuthenticationService authenticationService;

        public InviteStudentPopup()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
        }

        private async void InviteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                await authenticationService.EnrollStudentAsync(txtFirstName.Text, txtLastName.Text, txtUsername.Text, txtEmail.Text);
                _ = MessageBox.Show("Invitaion Sent.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (Exception ex)
            {
                if (ex is NetworkConnectionException or
                    TrainException or
                    FormatException or
                    ArgumentException)
                {
                    _ = MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    throw;
                }
            }

            this.IsEnabled = true;
        }

        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        public void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
