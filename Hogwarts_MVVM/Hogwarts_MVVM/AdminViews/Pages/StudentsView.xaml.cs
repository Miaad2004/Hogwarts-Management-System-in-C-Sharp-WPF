using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.Models.TrainManagement;
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
    public partial class StudentsView : Page
    {
        private ObservableCollection<Student> Students
        {
            get { return StaticServiceProvidor.facultyService.GetList<Student>(t => t.HouseType); }
        }
        public StudentsView()
        {
            InitializeComponent();
            OnDataGridChanged();
        }
        private void InviteStudent_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            InviteStudentPopup popup = new();
            _ = popup.ShowDialog();
            OnDataGridChanged();

            // Reactivate this window
            IsEnabled = true;
        }

        private void OnDataGridChanged()
        {
            studentsDataGrid.ItemsSource = Students;
            studentsDataGrid.Items.Refresh();
        }
    }
}
