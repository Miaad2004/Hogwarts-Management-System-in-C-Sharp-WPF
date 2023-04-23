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
using Hogwarts_Management_System.Models;

namespace Hogwarts_Management_System.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Update properties
            Username = txtUsername.Text;
            Password = txtPassword.Password;

            AccessLevel accessLevel = AccessLevel.Student;
            if (Username.StartsWith("s"))
                accessLevel = AccessLevel.Student;

            else if (Username.StartsWith("t"))
                accessLevel = AccessLevel.Teacher;

            else if (Username.StartsWith("a"))
                accessLevel = AccessLevel.Admin;

            // Login
            Authenticator.Login(Username, Password, accessLevel);
            if (Globals.HasLoggedIn)
                MessageBox.Show("Logged in successfully.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Wrong username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnSignUp_Click(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            SignUpView signUpView = new SignUpView();
            signUpView.Show();
            this.Close();

        }
    }
}
