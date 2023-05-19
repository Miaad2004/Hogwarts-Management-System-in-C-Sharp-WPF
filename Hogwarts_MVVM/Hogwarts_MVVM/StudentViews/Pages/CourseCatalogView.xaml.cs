using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.TrainManagement.Exceptions;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Core.SharedServices.Exceptions;
using Hogwarts.Views.ProfessorViews.Popups;
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
using Hogwarts.Core.Models.CourseManagement.Exceptions;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class CourseCatalogView : Page
    {
        private static Guid CurrentStudentId => SessionManager.CurrentSession.User.Id;
        private static ObservableCollection<Course> Courses
        {
            get
            {
                var courses = StaticServiceProvidor.dbContext.GetList<Course>(
                    orderBy: c => c.Title,
                    includeProperties: c => c.Professor
                ).ToList().Where(c => !c.HasFinished);

                return new ObservableCollection<Course>(courses);
            }
        }

        public CourseCatalogView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            coursessDataGrid.ItemsSource = Courses;
            coursessDataGrid.Items.Refresh();
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                Course selectedCourse = button.DataContext as Course;

                MessageBoxResult choice = MessageBox.Show("Are you certain about enrolling in the course?",
                                                          "Question!",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Question);
                if (choice == MessageBoxResult.Yes)
                {
                    StaticServiceProvidor.courseService.EnrollStudentInCourse(CurrentStudentId, selectedCourse.Id);
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
                    throw ex;
                }
            }

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());
        }
    }
}
