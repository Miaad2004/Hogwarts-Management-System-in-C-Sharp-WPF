using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Views.ProfessorViews.Popups;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.ProfessorViews.Pages
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class CoursesView : Page
    {
        private readonly HogwartsDbContext dbContext;

        public CoursesView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();

            Loaded += OnLoaded;
        }

        private async void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddCoursePopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            await PopulateDataGridAsync();

            // Reactivate this window
            IsEnabled = true;
        }

        private async void SubmitScores_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            Course course = button?.DataContext as Course ?? throw new NullReferenceException(nameof(button.DataContext));
            AddCourseScoresPopup popup = new(course);
            _ = popup.ShowDialog();

            // Refresh the page
            await PopulateDataGridAsync();

            // Reactivate this window
            IsEnabled = true;
        }

        private async void AddAssignment_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            Course course = button?.DataContext as Course ?? throw new NullReferenceException(nameof(button.DataContext));
            AddAssignmentPopup popup = new(course);
            _ = popup.ShowDialog();

            // Refresh the page
            await PopulateDataGridAsync();

            // Reactivate this window
            IsEnabled = true;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            var currentUser = SessionManager.CurrentSession?.User as Professor ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));
            var courses = new ObservableCollection<Course>(await dbContext.GetListAsync<Course>(orderBy: c => c.Title,
                                                                                                includeProperties: c => c.Professor)).ToList()
                                                                                                                                     .Where(c => !c.HasFinished && c.Professor.Id == currentUser.Id);
            coursessDataGrid.ItemsSource = courses;
        }
    }
}
