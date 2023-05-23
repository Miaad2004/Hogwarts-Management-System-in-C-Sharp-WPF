using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.FacultyManagement;
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
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class StaffView : Page
    {
        private readonly HogwartsDbContext dbContext;

        public StaffView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application.Current))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();

            Loaded += OnLoaded;
        }

        private async void AddProfessor_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddTeacherPopup popup = new();
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
            ObservableCollection<Professor> teachers = await dbContext.GetListAsync<Professor>(orderBy: p => p.FullName);
            teachersDataGrid.ItemsSource = teachers;
        }
    }
}
