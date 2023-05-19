using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private Guid CurrentStudentId => SessionManager.CurrentSession.User.Id;

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

            txtActiveCourses.Text = StaticServiceProvidor.courseService.GetActiveCourseCount(CurrentStudentId).ToString();
            //txtActiveAssignments.Text = StaticServiceProvidor.assignmentService.GetActiveAssignmentCount(CurrentStudentId).ToString();
            txtHouse.Text = StaticServiceProvidor.houseService.GetHouseType(CurrentStudentId).ToString();
            txtHousePoints.Text = StaticServiceProvidor.houseService.GetHousePoints(CurrentStudentId).ToString();
        }
    }
}
