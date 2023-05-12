using Hogwarts.Core.Models.TrainManagement.Exceptions;
using Hogwarts.Core.SharedServices;
using Hogwarts.Core.SharedServices.Exceptions;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for InviteStudent.xaml
    /// </summary>
    public partial class InviteStudentPopup : Window
    {
        public InviteStudentPopup()
        {
            InitializeComponent();
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
            this.Close();
        }

        private void InviteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StaticServiceProvidor.authenticationService.EnrollStudent(txtFirstName.Text, txtLastName.Text,
                                                                          txtUsername.Text, txtEmail.Text);
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
        }
    }
}
