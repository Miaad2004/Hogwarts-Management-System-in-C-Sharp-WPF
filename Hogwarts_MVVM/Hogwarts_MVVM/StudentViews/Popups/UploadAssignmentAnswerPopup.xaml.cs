using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
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
using System.Windows.Shapes;

namespace Hogwarts.Views.StudentViews.Popups
{
    /// <summary>
    /// Interaction logic for UploadAssignmentAnswerPopup.xaml
    /// </summary>
    public partial class UploadAssignmentAnswerPopup : Window
    {
        private StudentAssignment StudentAssignment { get; set; }
        public UploadAssignmentAnswerPopup(StudentAssignment studentAssignment)
        {
            InitializeComponent();
            StudentAssignment = studentAssignment;
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

        private void UploadAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string assignmentAnswer = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text;
                StaticServiceProvidor.assignmentService.UploadStudentAssignmentAnswer(assignmentAnswer, StudentAssignment.Id);

                MessageBox.Show($"Answer Sent.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                this.Close();
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw ex;
                }
            }
        }
    }
}
