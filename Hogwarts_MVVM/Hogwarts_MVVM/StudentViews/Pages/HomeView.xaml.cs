using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts.Core.Models.HouseManagement.Services;
using Hogwarts_MVVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private readonly IHouseService houseService;
        private readonly ICourseService courseService;
        private readonly IAssignmentService assignmentService;

        public HomeView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();
            houseService = serviceProvider.GetRequiredService<IHouseService>();
            courseService = serviceProvider.GetRequiredService<ICourseService>();
            assignmentService = serviceProvider.GetRequiredService<IAssignmentService>();

            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await SetTextValues();
        }

        private async Task SetTextValues()
        {
            var currentUser = SessionManager.CurrentSession?.User ?? throw new ArgumentNullException(nameof(SessionManager.CurrentSession));
            var dormitoryRoom = (await dbContext.Students
                                                .Include(s => s.DormitoryRoom)
                                                .Include(s => s.DormitoryRoom.Dormitory)
                                                .Where(s => s.Id == currentUser.Id)
                                                .SingleOrDefaultAsync())?.DormitoryRoom
                                                ?? throw new ArgumentException("Invalid student Id");

            txtUsername.Text = currentUser.Username;
            txtFullName.Text = currentUser.FullName;
            txtAge.Text = currentUser.Age.ToString();
            txtBloodType.Text = currentUser.BloodType.ToString();
            txtEmail.Text = currentUser.Email;
            txtDormitoryRoom.Text = dormitoryRoom.ToString();

            txtActiveAssignments.Text = (await assignmentService.GetActiveAssignmentCountAsync(currentUser.Id)).ToString();
            txtHouse.Text = (await houseService.GetHouseTypeAsync(currentUser.Id)).ToString();
            txtHousePoints.Text = (await houseService.GetHousePointsAsync(currentUser.Id)).ToString();
        }
    }
}
