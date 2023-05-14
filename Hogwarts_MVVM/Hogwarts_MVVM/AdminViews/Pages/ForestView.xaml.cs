using Hogwarts.Core.Models.Forest;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for ForestService.xaml
    /// </summary>
    public partial class ForestView : Page
    {
        private ObservableCollection<Plant> Plants
        {
            get { return StaticServiceProvidor.facultyService.GetList<Plant>(orderBy: p => p.HarvestTime); }
        }
        public ForestView()
        {
            InitializeComponent();
            OnDataGridChanged();
        }

        private void AddPlant_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddPlantPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged();

            // Reactivate this window
            IsEnabled = true;
        }
        private void OnDataGridChanged()
        {
            plantsDataGrid.ItemsSource = Plants;
            plantsDataGrid.Items.Refresh();
        }
    }
}
