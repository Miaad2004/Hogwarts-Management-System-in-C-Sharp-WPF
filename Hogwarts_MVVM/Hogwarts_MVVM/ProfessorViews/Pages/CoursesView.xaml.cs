using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.HouseManagement.Exceptions;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
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

namespace Hogwarts.Views.ProfessorViews.Pages
{
    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    public partial class CoursesView : Page
    {
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

        public CoursesView()
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
            // Deactivate this window
            IsEnabled = false;

            AddCoursePopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }

        private void SubmitScores_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddCourseScoresPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }

        private void AddAssignment_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            Course? course = button.DataContext as Course;
            AddAssignmentPopup popup = new(course);
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
