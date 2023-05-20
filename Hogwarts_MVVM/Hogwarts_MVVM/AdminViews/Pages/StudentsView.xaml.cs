using Hogwarts.Core.Models.DormitoryManagement;
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
        private static ObservableCollection<Student> Students =>
            StaticServiceProvidor.dbContext.GetList<Student>(orderBy: s => s.HouseType);

        public StudentsView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }

        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            studentsDataGrid.ItemsSource = Students;
            studentsDataGrid.Items.Refresh();
        }

        private void InviteStudent_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            InviteStudentPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
