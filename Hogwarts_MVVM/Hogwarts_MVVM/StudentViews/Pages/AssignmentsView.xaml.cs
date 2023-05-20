using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.StudentViews.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for AssignmentsView.xaml
    /// </summary>
    public partial class AssignmentsView : Page
    {
        private static Guid CurrentStudentId => SessionManager.CurrentSession.User.Id;
        private static ObservableCollection<StudentAssignment> StudentAssignments =>
            StaticServiceProvidor.dbContext.GetList<StudentAssignment>(orderBy: sa => sa.Assignment.DueDate,
                                                                       whereClause: sa => sa.StudentId == CurrentStudentId,
                                                                       sa => sa.Assignment, sa => sa.Assignment.Professor);

        public AssignmentsView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            assignmentsDataGrid.ItemsSource = StudentAssignments;
            assignmentsDataGrid.Items.Refresh();
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            StudentAssignment? studentAssignment = button.DataContext as StudentAssignment;

            UploadAssignmentAnswerPopup popup = new(studentAssignment);
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }

        private void ViewDescription_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            StudentAssignment? studentAssignment = button.DataContext as StudentAssignment;

            ViewAssignmentDescriptionPopup popup = new(studentAssignment);
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }

        private void ViewScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                StudentAssignment? studentAssignment = button.DataContext as StudentAssignment;

                GradeType grade = StaticServiceProvidor.assignmentService.GetStudentAssignmentScore(studentAssignment.Id);
                MessageBox.Show($"You'r grade is {grade}",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                if (ex is GradeNotRegisteredException)
                {
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (ex is ArgumentException ||
                         ex is CourseException)
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
