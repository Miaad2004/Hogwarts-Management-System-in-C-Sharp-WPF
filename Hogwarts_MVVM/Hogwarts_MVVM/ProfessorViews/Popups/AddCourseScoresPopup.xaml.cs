using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts_MVVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hogwarts.Views.ProfessorViews.Popups
{
    /// <summary>
    /// Interaction logic for AddCourseScoresPopup.xaml
    /// </summary>
    public class GradeTypeValues
    {
        public static Array Values => Enum.GetValues(typeof(GradeType));
    }

    public partial class AddCourseScoresPopup : Window, IPopup
    {
        private readonly HogwartsDbContext dbContext;

        private readonly Course Course;

        public AddCourseScoresPopup(Course course)
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();

            Course = course;

            Loaded += OnLoaded;
        }

        private async void SubmitScores_Click(object sender, RoutedEventArgs e)
        {
            await dbContext.SaveChangesAsync();
            MessageBox.Show("Scores submitted successfully.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            ObservableCollection<Grade> grades = new(await dbContext.Grades.Include(g => g.Student)
                                                                           .Where(g => g.CourseId == this.Course.Id)
                                                                           .ToListAsync());
            gradesDataGrid.ItemsSource = grades;
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
