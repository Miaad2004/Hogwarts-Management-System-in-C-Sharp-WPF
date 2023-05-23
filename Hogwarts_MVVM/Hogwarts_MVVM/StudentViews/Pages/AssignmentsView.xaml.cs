using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts.Views.StudentViews.Popups;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for AssignmentsView.xaml
    /// </summary>
    public partial class AssignmentsView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly IAssignmentService assignmentService;

        public AssignmentsView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
            assignmentService = serviceProvider.GetRequiredService<IAssignmentService>();

            Loaded += OnLoaded;
        }

        private async void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            StudentAssignment studentAssignment = button?.DataContext as StudentAssignment ?? throw new ArgumentNullException(nameof(button.DataContext));

            UploadAssignmentAnswerPopup popup = new(studentAssignment);
            _ = popup.ShowDialog();

            // Refresh the page
            await PopulateDataGridAsync();

            // Reactivate this window
            IsEnabled = true;
        }

        private async void ViewDescription_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            StudentAssignment studentAssignment = button?.DataContext as StudentAssignment ?? throw new ArgumentNullException(nameof(button.DataContext));

            ViewAssignmentDescriptionPopup popup = new(studentAssignment);
            _ = popup.ShowDialog();

            // Refresh the page
            await PopulateDataGridAsync();

            // Reactivate this window
            IsEnabled = true;
        }

        private async void ViewScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                StudentAssignment studentAssignment = button?.DataContext as StudentAssignment ?? throw new ArgumentNullException(nameof(button.DataContext));

                GradeType grade = await assignmentService.GetAssignmentScoreAsync(studentAssignment.Id);
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
                    throw;
                }
            }
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            var currentUser = SessionManager.CurrentSession?.User ?? throw new ArgumentException(nameof(SessionManager.CurrentSession));
            var studentAssignments = new ObservableCollection<StudentAssignment>(await dbContext.GetListAsync<StudentAssignment>(orderBy: sa => sa.Assignment.DueDate,
                                                                                                                                 whereClause: sa => sa.StudentId == currentUser.Id,
                                                                                                                                 sa => sa.Assignment,
                                                                                                                                 sa => sa.Assignment.Professor));
            assignmentsDataGrid.ItemsSource = studentAssignments;
        }
    }
}
