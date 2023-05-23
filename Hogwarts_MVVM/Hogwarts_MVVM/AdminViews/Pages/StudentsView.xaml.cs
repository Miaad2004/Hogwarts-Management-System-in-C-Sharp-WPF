using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Views.AdminViews.Popups;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class StudentsView : Page
    {
        private readonly HogwartsDbContext dbContext;

        public StudentsView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();

            Loaded += OnLoaded;
        }

        private async void InviteStudent_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            InviteStudentPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            await PopulateDataGridAsync();

            // Reactivate this window
            IsEnabled = true;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            ObservableCollection<Student> students = await dbContext.GetListAsync<Student>(orderBy: s => s.HouseType);
            studentsDataGrid.ItemsSource = students;
        }
    }
}
