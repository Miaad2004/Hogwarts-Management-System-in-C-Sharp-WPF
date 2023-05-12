using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for HogwartsExpress.xaml
    /// </summary>
    public partial class HogwartsExpressView : Page
    {

        private ObservableCollection<Train> Trains
        {
            get { return StaticServiceProvidor.facultyService.GetList<Train>(t => t.DepartureTime); }
        }
        public HogwartsExpressView()
        {
            InitializeComponent();
            OnDataGridChanged();
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddTrainPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged();

            // Reactivate this window
            IsEnabled = true;
        }

        private void OnDataGridChanged()
        {
            trainsDataGrid.ItemsSource = Trains;
            trainsDataGrid.Items.Refresh();
        }
    }
}
