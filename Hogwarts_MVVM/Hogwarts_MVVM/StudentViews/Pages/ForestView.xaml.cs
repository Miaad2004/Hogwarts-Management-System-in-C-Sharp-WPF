using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.StudentManagement;
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
using Hogwarts.Core.Models.ForestManagement;
using Hogwarts.Core.Models.Authentication;
using System.Collections.ObjectModel;
using Hogwarts.Core.Models.ForestManagement.Exceptions;

namespace Hogwarts.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for ForestView.xaml
    /// </summary>
    public partial class ForestView : Page
    {
        private static Guid CurrentStudentId => SessionManager.CurrentSession.User.Id;
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

        private void CollectPlant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                Plant? plant = button.DataContext as Plant;

                StaticServiceProvidor.forestService.CollectPlant(plant.Id, CurrentStudentId);
                MessageBox.Show($"Plant collected.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                if (ex is PlantNotCollectableException)
                {
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (ex is ArgumentException ||
                         ex is PlantException)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    throw ex;
                }
            }

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());
        }

        private void GetQuantity_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            Plant? plant = button.DataContext as Plant;

            int quantity = StaticServiceProvidor.forestService.GetStudentPlantQuantity(plant.Id, CurrentStudentId);
            MessageBox.Show($"You have {quantity} of this plant.",
                            "Success!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}
