using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.DormitoryManagement.Exceptions;
using Hogwarts.Core.Models.HouseManagement.Exceptions;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IAuthenticationService authenticationService;
        private string SelectedProfileImagePath = "";

        public SignupView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
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

        private async void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            StudentRegistrationDTO DTO = new()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                PasswordRepeat = txtPasswordRepeat.Password,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                BirthDate = DateOnly.FromDateTime((DateTime)(birthdayPicker.SelectedDate ?? throw new ArgumentNullException())),
                BloodType = (BloodType)comboBloodStatus.SelectedIndex,
                AccessLevel = AccessLevels.Student,
                HasLuggage = (bool)(radioLuggageYes.IsChecked ?? throw new ArgumentNullException(nameof(radioLuggageYes.IsChecked))),
                Pet = (PetType)comboPet.SelectedIndex,
                EnteredActivationCode = txtActivationCode.Text,
                ProfileImagePath = SelectedProfileImagePath
            };

            try
            {
                await authenticationService.SignUpStudentAsync(DTO);
                MessageBox.Show("Welcome to Hogwarts, Please login.", "Signup Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Uri("/LoginView.xaml", UriKind.Relative));
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is DormitoryException ||
                    ex is HouseException)
                {
                    MessageBox.Show(ex.Message, "Signup error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw;
                }
            }
        }

        private void LoginInstead_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/LoginView.xaml", UriKind.Relative));
        }
    }
}
