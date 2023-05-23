using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts.Core.Models.StudentManagement;
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
    /// Interaction logic for MyCoursesView.xaml
    /// </summary>
    public partial class MyCoursesView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly ICourseService courseService;
        private readonly User currentUser = SessionManager.CurrentSession?.User ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));

        public MyCoursesView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
            courseService = serviceProvider.GetRequiredService<ICourseService>();

            Loaded += OnLoaded;
        }

        private async void ViewScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                Course selectedCourse = button?.DataContext as Course ?? throw new ArgumentNullException();

                GradeType grade = await courseService.GetStudentGradeAsync(currentUser.Id, selectedCourse.Id);
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
            await PopulateDataGrid();
        }

        private async Task PopulateDataGrid()
        {

            var student = (await dbContext.GetListAsync<Student>(orderBy: s => s.FullName,
                                                                 includeProperties: s => s.Courses,
                                                                 whereClause: s => s.Id == currentUser.Id)).First();
            ObservableCollection<Course> courses = new ObservableCollection<Course>(student.Courses
                                                                                    .Where(c => !c.HasFinished)
                                                                                    .OrderBy(c => c.Title));

            myCoursesDataGrid.ItemsSource = courses;
        }
    }
}
