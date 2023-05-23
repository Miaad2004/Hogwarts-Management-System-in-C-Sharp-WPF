using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Hogwarts.Views.StudentViews.Popups
{
    /// <summary>
    /// Interaction logic for UploadAssignmentAnswerPopup.xaml
    /// </summary>
    public partial class UploadAssignmentAnswerPopup : Window, IPopup
    {
        private readonly IAssignmentService assignmentService;
        private StudentAssignment StudentAssignment { get; set; }

        public UploadAssignmentAnswerPopup(StudentAssignment studentAssignment)
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            assignmentService = serviceProvider.GetRequiredService<IAssignmentService>();

            StudentAssignment = studentAssignment;
        }

        private async void UploadAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string assignmentAnswer = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text;
                await assignmentService.SubmitAssignmentAnswerAsync(assignmentAnswer, StudentAssignment.Id);

                MessageBox.Show($"Answer Sent.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                this.Close();
            }

            catch (Exception ex)
            {
                if (ex is AssignmentException)
                {
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (ex is ArgumentException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw;
                }
            }
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
