using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Views.ProfessorViews.Popups;
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
    /// Interaction logic for AssignmentsView.xaml
    /// </summary>
    public partial class AssignmentsView : Page
    {
        private readonly HogwartsDbContext dbContext;
        private static Guid CurrentProfessorId => SessionManager.CurrentSession?.User.Id ?? throw new NullReferenceException(nameof(SessionManager.CurrentSession));

        public AssignmentsView()
        {
            InitializeComponent();
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            // Dependency Injection
            var serviceProvider = (Application.Current as App ?? throw new ArgumentNullException(nameof(Application))).ServiceProvider;
            dbContext = serviceProvider.GetRequiredService<HogwartsDbContext>();

            Loaded += OnLoaded;
        }

        private async void SubmitScores_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            Assignment assignment = button?.DataContext as Assignment ?? throw new NullReferenceException(nameof(button.DataContext));
            AddAssignmentScoresPopup popup = new(assignment);
            _ = popup.ShowDialog();

            // Refresh the page
            await PopulateDataGridAsync();

            // Reactivate this window
            IsEnabled = true;
        }

        private async void ViewDescription_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            Button? button = sender as Button;
            Assignment assignment = button?.DataContext as Assignment ?? throw new NullReferenceException(nameof(button.DataContext));
            ViewAssignmentDescriptionPopup popup = new(assignment);
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
            var assignments = new ObservableCollection<Assignment>(await dbContext.GetListAsync<Assignment>(orderBy: a => a.StartDate,
                                                                                                            whereClause: a => a.ProfessorId == CurrentProfessorId,
                                                                                                            includeProperties: a => a.Course));
            assignmentsDataGrid.ItemsSource = assignments;
        }
    }
}
