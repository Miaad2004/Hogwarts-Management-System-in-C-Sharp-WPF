using Hogwarts.Core.Models.DormitoryManagement;
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

        private static ObservableCollection<Train> Trains =>
            StaticServiceProvidor.dbContext.GetList<Train>(orderBy: t => t.DepartureTime);

        public HogwartsExpressView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            trainsDataGrid.ItemsSource = Trains;
            trainsDataGrid.Items.Refresh();
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddTrainPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
