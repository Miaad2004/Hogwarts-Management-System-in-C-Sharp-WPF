using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.SharedServices;
using System.Linq;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private string Username => SessionManager.CurrentSession.User.Username;
        private string FullName => SessionManager.CurrentSession.User.FullName;
        private string Age => SessionManager.CurrentSession.User.Age.ToString();
        private string BloodType => SessionManager.CurrentSession.User.BloodType.ToString();
        private string Email => SessionManager.CurrentSession.User.Email;

        public HomeView()
        {
            InitializeComponent();
            txtUsername.Text = Username;
            txtFullName.Text = FullName;
            txtAge.Text = Age;
            txtBloodType.Text = BloodType;
            txtEmail.Text = Email;

            txtStudentsCount.Text = StaticServiceProvidor.DbContext.Students.Count().ToString();
            txtTrainsCount.Text = StaticServiceProvidor.DbContext.Trains.Count().ToString();
            txtProfessorsCount.Text = StaticServiceProvidor.DbContext.Professors.Count().ToString();
            txtForestCollectablePlants.Text = StaticServiceProvidor.DbContext.Plants.Count().ToString();
        }
    }
}
