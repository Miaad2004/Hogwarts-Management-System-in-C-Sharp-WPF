using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.ForestManagement.Services;
using Hogwarts.Core.Models.HouseManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.ProfessorViews.Pages
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private readonly IHouseService houseService;
        private readonly IForestService forestService;

        public HomeView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            houseService = serviceProvider.GetRequiredService<IHouseService>();
            forestService = serviceProvider.GetRequiredService<IForestService>();

            Loaded += HomeView_Loaded;
        }

        private async void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            await SetTextValues();
        }

        private async Task SetTextValues()
        {
            var currentUser = SessionManager.CurrentSession?.User ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));

            txtUsername.Text = currentUser.Username;
            txtFullName.Text = currentUser.FullName;
            txtAge.Text = currentUser.Age.ToString();
            txtBloodType.Text = currentUser.BloodType.ToString();
            txtEmail.Text = currentUser.Email.ToString();
            txtMajor.Text = (currentUser as Professor ?? throw new ArgumentNullException()).Major.ToString();

            txtAvgHousePoints.Text = (await houseService.GetAvgHousePointsAsync()).ToString();
            txtForestPlantsCount.Text = (await forestService.GetCollectablePlantCountAsync()).ToString();
        }
    }
}
