using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement;
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
    /// Interaction logic for HogwartsExpress.xaml
    /// </summary>
    public partial class HogwartsExpressView : Page
    {
        private readonly HogwartsDbContext dbContext;

        public HogwartsExpressView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();

            Loaded += OnLoaded;
        }

        private async void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddTrainPopup popup = new();
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
            ObservableCollection<Train> trains = await dbContext.GetListAsync<Train>(orderBy: t => t.DepartureTime);
            trainsDataGrid.ItemsSource = trains;
        }
    }
}
