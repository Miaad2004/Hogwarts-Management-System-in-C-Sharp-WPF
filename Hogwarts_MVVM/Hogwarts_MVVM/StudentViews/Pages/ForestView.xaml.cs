using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.ForestManagement;
using Hogwarts.Core.Models.ForestManagement.Exceptions;
using Hogwarts.Core.Models.ForestManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for ForestView.xaml
    /// </summary>
    public partial class ForestView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly IForestService forestService;

        public ForestView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
            forestService = serviceProvider.GetRequiredService<IForestService>();

            Loaded += OnLoaded;
        }

        private async void CollectPlant_Click(object sender, RoutedEventArgs e)
        {
            var currentSession = SessionManager.CurrentSession ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));

            try
            {
                Button? button = sender as Button;
                Plant plant = button?.DataContext as Plant ?? throw new ArgumentNullException(nameof(button));

                await forestService.CollectPlantAsync(plant.Id, currentSession.User.Id);
                MessageBox.Show($"Plant collected.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                if (ex is PlantNotCollectableException)
                {
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (ex is ArgumentException ||
                         ex is PlantException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw;
                }
            }

            // Refresh the page
            await PopulateDataGridAsync();
        }

        private async void GetQuantity_Click(object sender, RoutedEventArgs e)
        {
            var currentSession = SessionManager.CurrentSession ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));

            Button? button = sender as Button;
            Plant plant = button?.DataContext as Plant ?? throw new ArgumentException(nameof(button.DataContext));

            int quantity = await forestService.GetStudentPlantQuantityAsync(plant.Id, currentSession.User.Id);
            MessageBox.Show($"You have {quantity} of this plant.",
                            "Success!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            var courses = new ObservableCollection<Plant>(await dbContext.GetListAsync<Plant>(orderBy: p => p.HarvestTime));
            plantsDataGrid.ItemsSource = courses;
        }
    }
}
