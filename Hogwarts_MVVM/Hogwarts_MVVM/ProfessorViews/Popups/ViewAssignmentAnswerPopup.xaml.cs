using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Hogwarts.Views.ProfessorViews.Popups
{
    /// <summary>
    /// Interaction logic for ViewAssignmentAnswerPopup.xaml
    /// </summary>
    public partial class ViewAssignmentAnswerPopup : Window, IPopup
    {
        private StudentAssignment StudentAssignment { get; set; }

        public ViewAssignmentAnswerPopup(StudentAssignment studentAssignment)
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            StudentAssignment = studentAssignment;

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateTextBox();
        }

        private void UpdateTextBox()
        {
            string? answer = StudentAssignment.Answer;
            if (answer == null || string.IsNullOrEmpty(answer))
            {
                MessageBox.Show("No answer found.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
                return;
            }

            string[] lines = answer?.Split('\n') ?? throw new NullReferenceException(nameof(answer));
            foreach (string line in lines)
            {
                txtAnswer.Document.Blocks.Add(new Paragraph(new Run(line)));
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
