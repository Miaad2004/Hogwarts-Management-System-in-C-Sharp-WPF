using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.SharedServices;

namespace Hogwarts.Views.AdminViews.Popups
{
    /// <summary>
    /// Interaction logic for AddTeacherPopup.xaml
    /// </summary>
    public partial class AddTeacherPopup : Window
    {
        private string SelectedProfileImagePath;

        public AddTeacherPopup()
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

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            ProfessorRegistrationDTO DTO = new ()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                PasswordRepeat = txtPasswordRepeat.Password,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                BirthDate = DateOnly.FromDateTime((DateTime)birthdayPicker.SelectedDate),
                BloodType = (BloodType)comboBloodStatus.SelectedIndex,
                AccessLevel = AccessLevels.Professor,
                Major = (ProfessorMajors)comboMajor.SelectedIndex,
                ProfileImagePath = SelectedProfileImagePath,
                HasTimeTurner = (bool)radioTimeTurnerYes.IsChecked,
            };

            try
            {
                StaticServiceProvidor.authenticationService.SignUpProfessor(DTO);
                MessageBox.Show("Professor registered successfully.", "Signup Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Signup error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
