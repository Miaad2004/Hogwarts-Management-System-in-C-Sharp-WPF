using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class StaffView : Page
    {
        private ObservableCollection<Professor> teachers
        {
            get { return StaticServiceProvidor.facultyService.GetList<Professor>(p => p.FullName); }
        }
        public StaffView()
        {
            InitializeComponent();
            OnDataGridChanged();
        }
        private void AddProfessor_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddTeacherPopup popup = new();
            _ = popup.ShowDialog();
            OnDataGridChanged();

            // Reactivate this window
            IsEnabled = true;
        }
        private void OnDataGridChanged()
        {
            teachersDataGrid.ItemsSource = teachers;
            teachersDataGrid.Items.Refresh();
        }
    }
}
