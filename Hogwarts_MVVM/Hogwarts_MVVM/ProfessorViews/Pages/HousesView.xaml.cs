using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.HouseManagement.Exceptions;
using Hogwarts.Core.Models.HouseManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.ProfessorViews.Pages
{
    /// <summary>
    /// Interaction logic for HousesView.xaml
    /// </summary>
    public partial class HousesView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly IHouseService houseService;

        public HousesView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
            houseService = serviceProvider.GetRequiredService<IHouseService>();

            Loaded += OnLoaded;
        }

        private async void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                House? house = button?.DataContext as House ?? throw new NullReferenceException(nameof(button.DataContext)); ;

                await houseService.UpdatePointsAsync(house.Id, dPoint: +5);
                MessageBox.Show($"5 Points Added To {house.HouseType}.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is HouseException)
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

        private async void DeductPoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                House house = button?.DataContext as House ?? throw new NullReferenceException(nameof(button.DataContext));

                await houseService.UpdatePointsAsync(house.Id, dPoint: -5);
                MessageBox.Show($"5 Points Deducted From {house.HouseType}.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is HouseException)
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

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await PopulateDataGridAsync();
        }

        private async Task PopulateDataGridAsync()
        {
            var houses = new ObservableCollection<House>(await dbContext.GetListAsync<House>(orderBy: h => h.Points));
            housesDataGrid.ItemsSource = houses;
        }
    }
}
