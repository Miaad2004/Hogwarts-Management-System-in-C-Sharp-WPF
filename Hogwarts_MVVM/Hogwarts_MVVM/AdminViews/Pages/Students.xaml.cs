using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        public Students()
        {
            InitializeComponent();

            ObservableCollection<Student> students = StaticServiceProvidor.facultyService.GetList<Student>(s => s.HouseType);
            studentsDataGrid.ItemsSource = students;

        }
        private void InviteStudent_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            InviteStudentPopup popup = new();
            _ = popup.ShowDialog();

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
