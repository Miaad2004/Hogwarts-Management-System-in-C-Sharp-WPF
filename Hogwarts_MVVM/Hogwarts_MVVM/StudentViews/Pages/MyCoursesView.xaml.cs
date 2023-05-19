using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
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
    /// Interaction logic for MyCoursesView.xaml
    /// </summary>
    public partial class MyCoursesView : Page
    {
        private static Guid StudentId => SessionManager.CurrentSession.User.Id;
        private static ObservableCollection<Course> MyCourses
        {
            get
            {
                var courses = StaticServiceProvidor.dbContext.GetList<Student>(
                    orderBy: s => s.FullName,
                    includeProperties: s => s.Courses,
                    whereClause: s => s.Id == StudentId
                ).First().Courses.Where(c => !c.HasFinished).OrderBy(c => c.Title);

                return new ObservableCollection<Course>(courses);
            }
        }

        public MyCoursesView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            myCoursesDataGrid.ItemsSource = MyCourses;
            myCoursesDataGrid.Items.Refresh();
        }

        private void ViewScore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                Course selectedCourse = button.DataContext as Course;

                GradeType grade = StaticServiceProvidor.courseService.GetStudentGrade(StudentId, selectedCourse.Id);
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
