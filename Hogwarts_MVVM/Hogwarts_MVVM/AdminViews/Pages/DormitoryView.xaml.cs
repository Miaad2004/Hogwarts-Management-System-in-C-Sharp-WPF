using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.ForestManagement;
using Hogwarts.Core.SharedServices;
using Hogwarts.Views.AdminViews.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
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

namespace Hogwarts.Views.AdminViews.Pages
{
    /// <summary>
    /// Interaction logic for DormitoryView.xaml
    /// </summary>
    public partial class DormitoryView : Page
    {
        private static ObservableCollection<Dormitory> Dormitories =>
            StaticServiceProvidor.dbContext.GetList<Dormitory>(orderBy: D => D.House);

        public DormitoryView()
        {
            InitializeComponent();
            Loaded += OnDataGridChanged;
        }
        private void OnDataGridChanged(object sender, RoutedEventArgs e)
        {
            dormitoriesDataGrid.ItemsSource = Dormitories;
            dormitoriesDataGrid.Items.Refresh();
        }

        private void AddDormitory_Click(object sender, RoutedEventArgs e)
        {
            // Deactivate this window
            IsEnabled = false;

            AddDormitoryPopup popup = new();
            _ = popup.ShowDialog();

            // Refresh the page
            OnDataGridChanged(this, new RoutedEventArgs());

            // Reactivate this window
            IsEnabled = true;
        }
    }
}
