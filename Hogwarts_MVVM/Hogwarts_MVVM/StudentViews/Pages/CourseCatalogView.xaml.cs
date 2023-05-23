using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class CourseCatalogView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly ICourseService courseService;

        public CourseCatalogView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
            courseService = serviceProvider.GetRequiredService<ICourseService>();

            Loaded += OnLoaded;
        }

        private async void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            var currentSession = SessionManager.CurrentSession ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));

            try
            {
                Button? button = sender as Button;
                Course selectedCourse = button?.DataContext as Course ?? throw new ArgumentNullException();

                MessageBoxResult choice = MessageBox.Show("Are you certain about enrolling in the course?",
                                                          "Question!",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Question);
                if (choice == MessageBoxResult.Yes)
                {
                    await courseService.EnrollStudentInCourseAsync(currentSession.User.Id, selectedCourse.Id);
                    MessageBox.Show("Course added successfully.",
                                    "Success!",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is CourseException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw;
                }
            }

            // Refresh the page
            await PopulateDataGridAsync();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            var courses = new ObservableCollection<Course>(await dbContext.GetListAsync<Course>(orderBy: c => c.Title,
                                                                                                includeProperties: c => c.Professor)).ToList().Where(c => !c.HasFinished);
            coursessDataGrid.ItemsSource = courses;
        }
    }
}
