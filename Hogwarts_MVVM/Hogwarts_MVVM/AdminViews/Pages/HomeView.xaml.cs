using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.ForestManagement.Services;
using Hogwarts_MVVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly IForestService forestService;

        public HomeView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
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

            txtUsername.Text = currentUser?.Username;
            txtFullName.Text = currentUser?.FullName;
            txtAge.Text = currentUser?.Age.ToString();
            txtBloodType.Text = currentUser?.BloodType.ToString();
            txtEmail.Text = currentUser?.Email;

            txtStudentsCount.Text = dbContext.Students.Count().ToString();
            txtTrainsCount.Text = dbContext.Trains.Count().ToString();
            txtProfessorsCount.Text = dbContext.Professors.Count().ToString();
            txtForestPlantsCount.Text = (await forestService.GetCollectablePlantCountAsync()).ToString();
        }
    }
}
