using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for AddTeacherPopup.xaml
    /// </summary>
    public partial class AddTeacherPopup : Window, IPopup
    {
        private readonly IAuthenticationService authenticationService;
        private string SelectedImagePath = "";

        public AddTeacherPopup()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
        }

        private async void Signup_Click(object sender, RoutedEventArgs e)
        {
            ProfessorRegistrationDTO DTO = new()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                PasswordRepeat = txtPasswordRepeat.Password,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                BirthDate = DateOnly.FromDateTime((DateTime)(birthdayPicker?.SelectedDate ?? throw new NullReferenceException(nameof(birthdayPicker)))),
                BloodType = (BloodType)comboBloodStatus.SelectedIndex,
                AccessLevel = AccessLevels.Professor,
                Major = (ProfessorMajors)comboMajor.SelectedIndex,
                ProfileImagePath = SelectedImagePath,
                HasTimeTurner = (bool)(radioTimeTurnerYes?.IsChecked ?? throw new NullReferenceException(nameof(radioTimeTurnerYes))),
            };

            try
            {
                await authenticationService.SignUpProfessorAsync(DTO);
                MessageBox.Show("Professor registered successfully.", "Signup Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Signup error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            SelectedImagePath = openFileDialog.FileName;
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
