using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.SharedServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hogwarts.Views.ProfessorViews.Popups;

namespace Hogwarts.Views.ProfessorViews.Pages
{
    /// <summary>
    /// Interaction logic for AssignmentsView.xaml
    /// </summary>
    public partial class AssignmentsView : Page
    {
        private static Guid CurrentProfessorId => SessionManager.CurrentSession.User.Id;
        private static ObservableCollection<Assignment> Assignments => 
            StaticServiceProvidor.dbContext.GetList<Assignment>(orderBy: a => a.StartDate,
                                                                whereClause: a => a.ProfessorId == CurrentProfessorId,
                                                                includeProperties: a => a.Course);

        public AssignmentsView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            assignmentsDataGrid.ItemsSource = Assignments;
            assignmentsDataGrid.Items.Refresh();
        }

        private void AddGeade_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubmitScores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewDescription_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            Assignment? assignment = button.DataContext as Assignment;
            ViewAssignmentDescriptionPopup popup = new(assignment);
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
