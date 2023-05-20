using Hogwarts.Core.Models.DormitoryManagement;
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
        private static ObservableCollection<Professor> Professors =>
            StaticServiceProvidor.dbContext.GetList<Professor>(orderBy: p => p.FullName);

        public StaffView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            teachersDataGrid.ItemsSource = Professors;
            teachersDataGrid.Items.Refresh();
        }
        private void AddProfessor_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddTeacherPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
