using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hogwarts_Management_System.Models;

namespace Hogwarts_Management_System.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private string RenteredPassword { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private string ActivationCode { get; set; }
        public SignUpView()
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

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            // Update properties
            Username = txtUsername.Text;
            Password = txtPassword.Password;
            RenteredPassword = txtPasswordRepeat.Password;
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            Email = txtEmail.Text;
            ActivationCode = txtActivationCode.Text;

            // Sign up
            try
            {
                Authenticator.SignUp(Username, Password, RenteredPassword,
                    FirstName, LastName, Email, ActivationCode);

                MessageBox.Show("Welcome to Hogwarts! Please login.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                // Switch to login page
                this.Hide();
                LoginView loginView = new LoginView();
                loginView.Show();
                this.Close();
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLogIn_Click(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            LoginView logInView  = new LoginView();
            logInView.Show();
            this.Close();
        }
    }
}
