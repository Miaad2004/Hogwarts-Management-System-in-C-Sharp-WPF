using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Hogwarts.Views
{
    /// <summary>
    /// Interaction logic for SignupView.xaml
    /// </summary>
    public partial class SignupView : Page
    {
        // Dependencies
        private readonly IAuthenticationService _authenticationService;

        private string SelectedProfileImagePath;
        public SignupView()
        {
            InitializeComponent();
            _authenticationService = StaticServiceProvidor.authenticationService;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Multiselect = false,
                Filter = "Image Files(*.JPG; *.JPEG; *.PNG; *.GIF)| *.JPG; *.JPEG; *.PNG; *.GIF",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            _ = openFileDialog.ShowDialog();
            txtOpenFile.Text = openFileDialog.FileName;
            SelectedProfileImagePath = openFileDialog.FileName;
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            StudentRegistrationDTO DTO = new()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                PasswordRepeat = txtPasswordRepeat.Password,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                BirthDate = DateOnly.FromDateTime((DateTime)birthdayPicker.SelectedDate),
                BloodType = (BloodType)comboBloodStatus.SelectedIndex,
                AccessLevel = AccessLevels.Student,
                HasLuggage = (bool)radioLuggageYes.IsChecked,
                Pet = (PetType)comboPet.SelectedIndex,
                EnteredActivationCode = txtActivationCode.Text,
                ProfileImagePath = SelectedProfileImagePath
            };

            try
            {
                _authenticationService.SignUpStudent(DTO);
                _ = MessageBox.Show("Welcome to Hogwarts, Please login.", "Signup Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                _ = NavigationService.Navigate(new Uri("/LoginView.xaml", UriKind.Relative));
            }
            catch (ArgumentException ex)
            {
                _ = MessageBox.Show(ex.Message, "Signup error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoginInstead_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _ = NavigationService.Navigate(new Uri("/LoginView.xaml", UriKind.Relative));
        }
    }
}
