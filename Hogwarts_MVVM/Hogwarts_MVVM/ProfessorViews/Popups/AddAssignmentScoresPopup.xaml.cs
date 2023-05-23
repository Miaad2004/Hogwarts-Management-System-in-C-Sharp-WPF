using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hogwarts.Views.ProfessorViews.Popups
{
    /// <summary>
    /// Interaction logic for AddAssignmentScoresPopup.xaml
    /// </summary>

    public partial class AddAssignmentScoresPopup : Window, IPopup
    {
        private readonly HogwartsDbContext dbContext;

        private readonly Assignment Assignment;

        public AddAssignmentScoresPopup(Assignment assignment)
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();

            Assignment = assignment;

            Loaded += OnLoaded;
        }

        private async void SubmitScores_Click(object sender, RoutedEventArgs e)
        {
            await dbContext.SaveChangesAsync();
            MessageBox.Show("Scores submitted successfully.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        private void ViewAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            var studentAssignment = button?.DataContext as StudentAssignment ?? throw new NullReferenceException(nameof(button.DataContext));
            ViewAssignmentAnswerPopup popup = new(studentAssignment);
            popup.ShowDialog();

            IsEnabled = true;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            ObservableCollection<StudentAssignment> studentAssignments = await dbContext.GetListAsync<StudentAssignment>(orderBy: sa => sa.Student.FullName,
                                                                                                                         includeProperties: sa => sa.Student,
                                                                                                                         whereClause: sa => sa.AssignmentId == this.Assignment.Id);
            gradesDataGrid.ItemsSource = studentAssignments;
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
