using Hogwarts.Core.Models.Authentication;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private string FullName => SessionManager.CurrentSession.User.FullName;
        public Home()
        {
            InitializeComponent();
            txtFullName.Text = FullName;
        }
    }
}
