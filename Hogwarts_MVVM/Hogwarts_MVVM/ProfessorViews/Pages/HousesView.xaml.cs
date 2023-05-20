using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.ForestManagement.Exceptions;
using Hogwarts.Core.Models.ForestManagement;
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
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.HouseManagement.Exceptions;
using Hogwarts.Views.AdminViews.Popups;

namespace Hogwarts.Views.ProfessorViews.Pages
{
    /// <summary>
    /// Interaction logic for HousesView.xaml
    /// </summary>
    public partial class HousesView : Page
    {
        private static ObservableCollection<House> Houses =>
            StaticServiceProvidor.dbContext.GetList<House>(orderBy: h => h.HouseType);

        public HousesView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            housesDataGrid.ItemsSource = Houses;
            housesDataGrid.Items.Refresh();
        }

        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                House? house = button.DataContext as House;

                StaticServiceProvidor.houseService.UpdatePoints(house.Id, dPoint: +5);
                MessageBox.Show($"5 Points Added To {house.HouseType}.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is HouseException)
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

        private void DeductPoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? button = sender as Button;
                House? house = button.DataContext as House;

                StaticServiceProvidor.houseService.UpdatePoints(house.Id, dPoint: -5);
                MessageBox.Show($"5 Points Deducted From {house.HouseType}.",
                                "Success!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                if (ex is ArgumentException ||
                    ex is HouseException)
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
    }
}
