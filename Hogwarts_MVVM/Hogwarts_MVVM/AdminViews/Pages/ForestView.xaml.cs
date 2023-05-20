using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.ForestManagement;
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
        private static ObservableCollection<Plant> Plants =>
            StaticServiceProvidor.dbContext.GetList<Plant>(orderBy: p => p.HarvestTime);

        public ForestView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }

        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            plantsDataGrid.ItemsSource = Plants;
            plantsDataGrid.Items.Refresh();
        }

        private void AddPlant_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddPlantPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
